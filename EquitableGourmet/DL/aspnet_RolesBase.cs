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
	public abstract class aspnet_RolesBase
	{
		#region < VARIABLES >
		private Guid _ApplicationId;
		private Guid _RoleId;
		private string _RoleName;
		private string _LoweredRoleName;
		private string _Description;
		private bool _isNew;
		#endregion
		
		#region < CONSTRUCTORES >
		protected aspnet_RolesBase()
		{
			_RoleId = Guid.Empty;
			_Description = string.Empty;
		}
		
		protected aspnet_RolesBase(Guid RoleId) : this()
		{
			_RoleId = RoleId;
		}
	
		protected aspnet_RolesBase(Guid ApplicationId, Guid RoleId, string RoleName, string LoweredRoleName, string Description) : this()
		{
			_ApplicationId = ApplicationId;
			_RoleId = RoleId;
			_RoleName = RoleName;
			_LoweredRoleName = LoweredRoleName;
			_Description = Description;
		}

		#endregion
		
		#region < Metodos para Obtención de Detalles >

		#endregion
		
		#region < PROPIEDADES >
		
		public Guid ApplicationId
		{
			get	{ return _ApplicationId; }
			set	{ _ApplicationId = value; }
		}
		
		public Guid RoleId
		{
			get	{ return _RoleId; }
			set	{ _RoleId = value; }
		}
		
		public string RoleName
		{
			get	{ return _RoleName; }
			set	{ _RoleName = value; }
		}
		
		public string LoweredRoleName
		{
			get	{ return _LoweredRoleName; }
			set	{ _LoweredRoleName = value; }
		}
		
		public string Description
		{
			get	{ return _Description; }
			set	{ _Description = value; }
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
		public static bool Existe(Guid RoleId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = "daab_Existsaspnet_Roles";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add in parameters
			db.AddInParameter(dbCommandWrapper, "@RoleId", DbType.Guid, RoleId);

			// DataSet that will hold the returned results		
			// Note: connection closed by ExecuteDataSet method call 
			bool ret = false;
			int num = Convert.ToInt32(db.ExecuteScalar(dbCommandWrapper));
			ret = num > 0;
			return ret;
		}
		
		public static DataTable GetAllaspnet_Roles()
		{
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_GetAllaspnet_Roles";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);
			DataTable ret = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
            ret.PrimaryKey = new DataColumn[] { ret.Columns["RoleId"] };
			
            return ret;
		}
		
		public static void SaveAll(DataTable tabla)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbDataAdapter da = db.GetDataAdapter();
			
			da.SelectCommand = db.GetStoredProcCommand("daab_GetAllaspnet_Roles");
            da.InsertCommand = db.GetStoredProcCommand("daab_Addaspnet_Roles");
            da.UpdateCommand = db.GetStoredProcCommand("daab_Updateaspnet_Roles");
            da.DeleteCommand = db.GetStoredProcCommand("daab_Deleteaspnet_Roles");
			
			#region Parametros de InsertCommand
			db.AddInParameter(da.InsertCommand, "@ApplicationId", DbType.Guid, "ApplicationId", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@RoleId", DbType.Guid, "RoleId", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@RoleName", DbType.String, "RoleName", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@LoweredRoleName", DbType.String, "LoweredRoleName", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@Description", DbType.String, "Description", DataRowVersion.Default);

			#endregion
			
			#region Parametros de UpdateCommand
			db.AddInParameter(da.UpdateCommand, "@ApplicationId", DbType.Guid, "ApplicationId", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@RoleId", DbType.Guid, "RoleId", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@RoleName", DbType.String, "RoleName", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@LoweredRoleName", DbType.String, "LoweredRoleName", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Description", DbType.String, "Description", DataRowVersion.Default);

			#endregion
			
			#region Parametros de DeleteCommand
			db.AddInParameter(da.DeleteCommand, "@RoleId", DbType.Guid, "RoleId", DataRowVersion.Default);

			#endregion

			db.UpdateDataSet(tabla.DataSet, tabla.TableName, da.InsertCommand, da.UpdateCommand, da.DeleteCommand, UpdateBehavior.Standard);
		}
		#endregion

		/// <summary>
		/// Populates a dataset with info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="RoleId"></param>
		/// <returns>A DataSet containing the results of the query</returns>
		private DataSet LoadByPrimaryKey(Guid RoleId)
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_Getaspnet_Roles";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add in parameters
			db.AddInParameter(dbCommandWrapper, "@RoleId", DbType.Guid, RoleId);

			// DataSet that will hold the returned results		
			// Note: connection closed by ExecuteDataSet method call 
			return db.ExecuteDataSet(dbCommandWrapper);
		}
	
		/// <summary>
		/// Populates current instance of the object with info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="RoleId"></param>
		public virtual void Load(Guid RoleId)
		{
			// DataSet that will hold the returned results		
			DataSet ds = this.LoadByPrimaryKey(RoleId);
			
			// Load member variables from datarow
			DataRow row = ds.Tables[0].Rows[0];
			_ApplicationId = (Guid)row["ApplicationId"];
			_RoleId = (Guid)row["RoleId"];
			_RoleName = (string)row["RoleName"];
			_LoweredRoleName = (string)row["LoweredRoleName"];
			_Description = row.IsNull("Description") ? string.Empty : (string)row["Description"];
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

			string sqlCommand = "daab_Addaspnet_Roles";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add parameters
			db.AddInParameter(dbCommandWrapper, "@ApplicationId", DbType.Guid, _ApplicationId);
			db.AddInParameter(dbCommandWrapper, "@RoleId", DbType.Guid, _RoleId);
			db.AddInParameter(dbCommandWrapper, "@RoleName", DbType.String, _RoleName);
			db.AddInParameter(dbCommandWrapper, "@LoweredRoleName", DbType.String, _LoweredRoleName);
			db.AddInParameter(dbCommandWrapper, "@Description", DbType.String, SetNullValue((_Description == string.Empty), _Description));

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

			string sqlCommand = "daab_Updateaspnet_Roles";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add parameters
			db.AddInParameter(dbCommandWrapper, "@ApplicationId", DbType.Guid, _ApplicationId);
			db.AddInParameter(dbCommandWrapper, "@RoleId", DbType.Guid, _RoleId);
			db.AddInParameter(dbCommandWrapper, "@RoleName", DbType.String, _RoleName);
			db.AddInParameter(dbCommandWrapper, "@LoweredRoleName", DbType.String, _LoweredRoleName);
			db.AddInParameter(dbCommandWrapper, "@Description", DbType.String, SetNullValue((_Description == string.Empty), _Description));

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
		public static void Remove(Guid RoleId)
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_Deleteaspnet_Roles";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add primary keys to command wrapper.
			db.AddInParameter(dbCommandWrapper, "@RoleId", DbType.Guid, RoleId);

			db.ExecuteNonQuery(dbCommandWrapper);
		}
		
		/// <summary>
		/// Serializes the current instance data to an Xml string.
		/// </summary>
		/// <returns>A string containing the Xml representation of the object.</returns>
		virtual public string ToXml()
		{
			// DataSet that will hold the returned results		
			DataSet ds = this.LoadByPrimaryKey(_RoleId);
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

        public DataSet GetAllPagesRole(String roleName)
        {
            // Create the Database object, using the default database service. The
            // default database service is determined through configuration.
            Database db = DatabaseFactory.CreateDatabase();

            string sqlCommand = "GetAllPagesRole";
            DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

            // Add in parameters
            db.AddInParameter(dbCommandWrapper, "@RoleName", DbType.String, roleName);

            return db.ExecuteDataSet(dbCommandWrapper);
        }
	}
}