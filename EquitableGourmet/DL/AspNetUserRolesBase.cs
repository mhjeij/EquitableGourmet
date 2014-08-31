/*
'===============================================================================
'  Generated From - CSharp_DAAB_BusinessEntity.vbgen
' 
'  ** IMPORTANT  ** 
'  How to Generate your stored procedures:
' 
'  SQL      = SQL_DAAB_Net2_StoredProcs.vbgen
'  
'  This object is 'abstract' which means you need to inherit from it to be able
'  to instantiate it.  This is very easily done. You can override properties and
'  methods in your derived class, this allows you to regenerate this class at any
'  time and not worry about overwriting custom code. 
'
'  NEVER EDIT THIS FILE.
'
'  public class YourObject :  YourObjectBase
'  {
'
'  }
'
'===============================================================================
*/

// Generated by MyGeneration Version # (1.3.0.3)

using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Xml;
using System.IO;

using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace EquitableGourmet
{
	public abstract class AspNetUserRolesBase
	{
		#region < VARIABLES >
		private string _UserId;
		private string _RoleId;
		private bool _isNew;
		#endregion
		
		#region < CONSTRUCTORES >
		protected AspNetUserRolesBase()
		{
			_RoleId = string.Empty;
			_UserId = string.Empty;
		}
		
		protected AspNetUserRolesBase(string RoleId, string UserId) : this()
		{
			_RoleId = RoleId;
			_UserId = UserId;
		}

		#endregion
		
		#region < Metodos para Obtención de Detalles >

		public static DataTable GetByAspNetRoles(string RoleId)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Select * From AspNetUserRoles Where RoleId = @RoleId";
            DbCommand dbCommandWrapper = db.GetSqlStringCommand(sqlCommand);
			db.AddInParameter(dbCommandWrapper, "@RoleId", DbType.String, RoleId);

			DataTable t = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
			t.Columns["RoleId"].DefaultValue = RoleId;

            return t;
		}

		public static DataTable GetByAspNetUsers(string UserId)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Select * From AspNetUserRoles Where UserId = @UserId";
            DbCommand dbCommandWrapper = db.GetSqlStringCommand(sqlCommand);
			db.AddInParameter(dbCommandWrapper, "@UserId", DbType.String, UserId);

			DataTable t = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
			t.Columns["UserId"].DefaultValue = UserId;

            return t;
		}

		#endregion
		
		#region < PROPIEDADES >
		
		public string UserId
		{
			get	{ return _UserId; }
			set	{ _UserId = value; }
		}
		
		public string RoleId
		{
			get	{ return _RoleId; }
			set	{ _RoleId = value; }
		}
		
		public bool IsNew
		{
			get 
			{ 
				return _isNew; 
			}
			set { _isNew = value; }
		}
		#endregion		

		#region Utilerias
		public static bool Existe(string RoleId, string UserId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = "daab_ExistsAspNetUserRoles";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add in parameters
			db.AddInParameter(dbCommandWrapper, "@RoleId", DbType.String, RoleId);
			db.AddInParameter(dbCommandWrapper, "@UserId", DbType.String, UserId);

			// DataSet that will hold the returned results		
			// Note: connection closed by ExecuteDataSet method call 
			bool ret = false;
			int num = Convert.ToInt32(db.ExecuteScalar(dbCommandWrapper));
			ret = num > 0;
			return ret;
		}
		
		public static DataTable GetAllAspNetUserRoles()
		{
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_GetAllAspNetUserRoles";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);
			DataTable ret = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
            ret.PrimaryKey = new DataColumn[] { ret.Columns["RoleId"], ret.Columns["UserId"] };
			
            return ret;
		}
		
		public static void SaveAll(DataTable tabla)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbDataAdapter da = db.GetDataAdapter();
			
			da.SelectCommand = db.GetStoredProcCommand("daab_GetAllAspNetUserRoles");
            da.InsertCommand = db.GetStoredProcCommand("daab_AddAspNetUserRoles");
            da.UpdateCommand = db.GetStoredProcCommand("daab_UpdateAspNetUserRoles");
            da.DeleteCommand = db.GetStoredProcCommand("daab_DeleteAspNetUserRoles");
			
			#region Parametros de InsertCommand
			db.AddInParameter(da.InsertCommand, "@UserId", DbType.String, "UserId", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@RoleId", DbType.String, "RoleId", DataRowVersion.Default);

			#endregion
			
			#region Parametros de UpdateCommand
			db.AddInParameter(da.UpdateCommand, "@UserId", DbType.String, "UserId", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@RoleId", DbType.String, "RoleId", DataRowVersion.Default);

			#endregion
			
			#region Parametros de DeleteCommand
			db.AddInParameter(da.DeleteCommand, "@RoleId", DbType.String, "RoleId", DataRowVersion.Default);
			db.AddInParameter(da.DeleteCommand, "@UserId", DbType.String, "UserId", DataRowVersion.Default);

			#endregion

			db.UpdateDataSet(tabla.DataSet, tabla.TableName, da.InsertCommand, da.UpdateCommand, da.DeleteCommand, UpdateBehavior.Standard);
		}
		#endregion

		/// <summary>
		/// Populates a dataset with info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="RoleId"></param>
		/// <param name="UserId"></param>
		/// <returns>A DataSet containing the results of the query</returns>
		private DataSet LoadByPrimaryKey(string RoleId, string UserId)
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_GetAspNetUserRoles";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add in parameters
			db.AddInParameter(dbCommandWrapper, "@RoleId", DbType.String, RoleId);
			db.AddInParameter(dbCommandWrapper, "@UserId", DbType.String, UserId);

			// DataSet that will hold the returned results		
			// Note: connection closed by ExecuteDataSet method call 
			return db.ExecuteDataSet(dbCommandWrapper);
		}
	
		/// <summary>
		/// Populates current instance of the object with info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="RoleId"></param>
		/// <param name="UserId"></param>
		public virtual void Load(string RoleId, string UserId)
		{
			// DataSet that will hold the returned results		
			DataSet ds = this.LoadByPrimaryKey(RoleId, UserId);
			
			// Load member variables from datarow
			DataRow row = ds.Tables[0].Rows[0];
			_UserId = (string)row["UserId"];
			_RoleId = (string)row["RoleId"];
		}

		/// <summary>
		/// Adds or updates information in the database depending on the primary key stored in the object instance.
		/// </summary>
		/// <returns>Returns True if saved successfully, False otherwise.</returns>
		public bool Save()
		{
			if (this.IsNew)
				return Insert();
			else
				return Update();
		}

		/// <summary>
		/// Inserts the current instance data into the database.
		/// </summary>
		/// <returns>Returns True if saved successfully, False otherwise.</returns>
		private bool Insert()
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_AddAspNetUserRoles";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add parameters
			db.AddInParameter(dbCommandWrapper, "@UserId", DbType.String, _UserId);
			db.AddInParameter(dbCommandWrapper, "@RoleId", DbType.String, _RoleId);

			db.ExecuteNonQuery(dbCommandWrapper);
			
			return true;
		}

		/// <summary>
		/// Updates the current instance data in the database.
		/// </summary>
		/// <returns>Returns True if saved successfully, False otherwise.</returns>
		public bool Update()
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_UpdateAspNetUserRoles";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add parameters
			db.AddInParameter(dbCommandWrapper, "@UserId", DbType.String, _UserId);
			db.AddInParameter(dbCommandWrapper, "@RoleId", DbType.String, _RoleId);

			try
			{
				db.ExecuteNonQuery(dbCommandWrapper);
				
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Removes info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="RoleId"></param>
		/// <param name="UserId"></param>
		public static void Remove(string RoleId, string UserId)
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_DeleteAspNetUserRoles";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add primary keys to command wrapper.
			db.AddInParameter(dbCommandWrapper, "@RoleId", DbType.String, RoleId);
			db.AddInParameter(dbCommandWrapper, "@UserId", DbType.String, UserId);

			db.ExecuteNonQuery(dbCommandWrapper);
		}
		
		/// <summary>
		/// Serializes the current instance data to an Xml string.
		/// </summary>
		/// <returns>A string containing the Xml representation of the object.</returns>
		virtual public string ToXml()
		{
			// DataSet that will hold the returned results		
			DataSet ds = this.LoadByPrimaryKey(_RoleId, _UserId);
			StringWriter writer = new StringWriter(); 
			ds.WriteXml(writer); 
			return writer.ToString(); 
		}

		/// <summary>
		/// Utility function that returns a DBNull.Value if requested. The comparison is done inline
		/// in the Insert() and Update() functions.
		/// </summary>
		private object SetNullValue(bool isNullValue, object value)
		{
			if (isNullValue)
				return DBNull.Value;
			else
				return value;
		}
	}
}
