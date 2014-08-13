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

namespace DL
{
	public abstract class AccountStatusBase
	{
		#region < VARIABLES >
		private int _AccountStatusID;
		private string _Name;
		private string _Description;
		private bool _Del;
		private bool _isNew;
		#endregion
		
		#region < CONSTRUCTORES >
		protected AccountStatusBase()
		{
			_AccountStatusID = 0;
			_Name = string.Empty;
			_Description = string.Empty;
			_Del = false;
		}
		
		protected AccountStatusBase(int AccountStatusID) : this()
		{
			_AccountStatusID = AccountStatusID;
		}
	
		protected AccountStatusBase(int AccountStatusID, string Name, string Description, bool Del) : this()
		{
			_AccountStatusID = AccountStatusID;
			_Name = Name;
			_Description = Description;
			_Del = Del;
		}

		#endregion
		
		#region < Metodos para Obtención de Detalles >

		public static DataTable GetByAccount(int AccountStatusID)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Select * From AccountStatus Where AccountStatusID = @AccountStatusID";
            DbCommand dbCommandWrapper = db.GetSqlStringCommand(sqlCommand);
			db.AddInParameter(dbCommandWrapper, "@AccountStatusID", DbType.Int32, AccountStatusID);

			DataTable t = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
			t.Columns["AccountStatusID"].DefaultValue = AccountStatusID;

            return t;
		}

		#endregion
		
		#region < PROPIEDADES >
		
		public int AccountStatusID
		{
			get	{ return _AccountStatusID; }
			set	{ _AccountStatusID = value; }
		}
		
		public string Name
		{
			get	{ return _Name; }
			set	{ _Name = value; }
		}
		
		public string Description
		{
			get	{ return _Description; }
			set	{ _Description = value; }
		}
		
		public bool Del
		{
			get	{ return _Del; }
			set	{ _Del = value; }
		}
		
		public bool IsNew
		{
			get 
			{ 
				_isNew = (_AccountStatusID == 0);
				return _isNew; 
			}
			set { _isNew = value; }
		}
		#endregion		

		#region Utilerias
		public static bool Existe(int AccountStatusID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = "daab_ExistsAccountStatus";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add in parameters
			db.AddInParameter(dbCommandWrapper, "@AccountStatusID", DbType.Int32, AccountStatusID);

			// DataSet that will hold the returned results		
			// Note: connection closed by ExecuteDataSet method call 
			bool ret = false;
			int num = Convert.ToInt32(db.ExecuteScalar(dbCommandWrapper));
			ret = num > 0;
			return ret;
		}
		
		public static DataTable GetAllAccountStatus()
		{
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_GetAllAccountStatus";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);
			DataTable ret = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
            ret.PrimaryKey = new DataColumn[] { ret.Columns["AccountStatusID"] };
			
            return ret;
		}
		
		public static void SaveAll(DataTable tabla)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbDataAdapter da = db.GetDataAdapter();
			
			da.SelectCommand = db.GetStoredProcCommand("daab_GetAllAccountStatus");
            da.InsertCommand = db.GetStoredProcCommand("daab_AddAccountStatus");
            da.UpdateCommand = db.GetStoredProcCommand("daab_UpdateAccountStatus");
            da.DeleteCommand = db.GetStoredProcCommand("daab_DeleteAccountStatus");
			
			#region Parametros de InsertCommand
			db.AddOutParameter(da.InsertCommand, "@AccountStatusID", DbType.Int32, 4);
			db.AddInParameter(da.InsertCommand, "@Name", DbType.String, "Name", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@Description", DbType.String, "Description", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@Del", DbType.Boolean, "Del", DataRowVersion.Default);

			#endregion
			
			#region Parametros de UpdateCommand
			db.AddInParameter(da.UpdateCommand, "@AccountStatusID", DbType.Int32, "AccountStatusID", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Name", DbType.String, "Name", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Description", DbType.String, "Description", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Del", DbType.Boolean, "Del", DataRowVersion.Default);

			#endregion
			
			#region Parametros de DeleteCommand
			db.AddInParameter(da.DeleteCommand, "@AccountStatusID", DbType.Int32, "AccountStatusID", DataRowVersion.Default);

			#endregion

			db.UpdateDataSet(tabla.DataSet, tabla.TableName, da.InsertCommand, da.UpdateCommand, da.DeleteCommand, UpdateBehavior.Standard);
		}
		#endregion

		/// <summary>
		/// Populates a dataset with info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="AccountStatusID"></param>
		/// <returns>A DataSet containing the results of the query</returns>
		private DataSet LoadByPrimaryKey(int AccountStatusID)
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_GetAccountStatus";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add in parameters
			db.AddInParameter(dbCommandWrapper, "@AccountStatusID", DbType.Int32, AccountStatusID);

			// DataSet that will hold the returned results		
			// Note: connection closed by ExecuteDataSet method call 
			return db.ExecuteDataSet(dbCommandWrapper);
		}
	
		/// <summary>
		/// Populates current instance of the object with info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="AccountStatusID"></param>
		public virtual void Load(int AccountStatusID)
		{
			// DataSet that will hold the returned results		
			DataSet ds = this.LoadByPrimaryKey(AccountStatusID);
			
			// Load member variables from datarow
			DataRow row = ds.Tables[0].Rows[0];
			_AccountStatusID = (int)row["AccountStatusID"];
			_Name = row.IsNull("Name") ? string.Empty : (string)row["Name"];
			_Description = row.IsNull("Description") ? string.Empty : (string)row["Description"];
			_Del = row.IsNull("Del") ? false : (bool)row["Del"];
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

			string sqlCommand = "daab_AddAccountStatus";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add parameters
			db.AddOutParameter(dbCommandWrapper, "@AccountStatusID", DbType.Int32, 4);
			db.AddInParameter(dbCommandWrapper, "@Name", DbType.String, SetNullValue((_Name == string.Empty), _Name));
			db.AddInParameter(dbCommandWrapper, "@Description", DbType.String, SetNullValue((_Description == string.Empty), _Description));
			db.AddInParameter(dbCommandWrapper, "@Del", DbType.Boolean, SetNullValue((_Del == false), _Del));

			db.ExecuteNonQuery(dbCommandWrapper);
			
			// Save output parameter values
			object param;
			param = db.GetParameterValue(dbCommandWrapper, "@AccountStatusID");
			if (param == DBNull.Value) return false;
			_AccountStatusID = (int)param;
			
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

			string sqlCommand = "daab_UpdateAccountStatus";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add parameters
			db.AddInParameter(dbCommandWrapper, "@AccountStatusID", DbType.Int32, _AccountStatusID);
			db.AddInParameter(dbCommandWrapper, "@Name", DbType.String, SetNullValue((_Name == string.Empty), _Name));
			db.AddInParameter(dbCommandWrapper, "@Description", DbType.String, SetNullValue((_Description == string.Empty), _Description));
			db.AddInParameter(dbCommandWrapper, "@Del", DbType.Boolean, SetNullValue((_Del == false), _Del));

			try
			{
				db.ExecuteNonQuery(dbCommandWrapper);
				
				// Save output parameter values
				object param;
				param = db.GetParameterValue(dbCommandWrapper, "@AccountStatusID");
				if (param == DBNull.Value) return false;
				_AccountStatusID = (int)param;
				
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
		/// <param name="AccountStatusID"></param>
		public static void Remove(int AccountStatusID)
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_DeleteAccountStatus";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add primary keys to command wrapper.
			db.AddInParameter(dbCommandWrapper, "@AccountStatusID", DbType.Int32, AccountStatusID);

			db.ExecuteNonQuery(dbCommandWrapper);
		}
		
		/// <summary>
		/// Serializes the current instance data to an Xml string.
		/// </summary>
		/// <returns>A string containing the Xml representation of the object.</returns>
		virtual public string ToXml()
		{
			// DataSet that will hold the returned results		
			DataSet ds = this.LoadByPrimaryKey(_AccountStatusID);
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