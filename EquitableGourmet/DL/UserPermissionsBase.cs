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
	public abstract class UserPermissionsBase
	{
		#region < VARIABLES >
		private int _UserPermissionsID;
		private string _ControlName;
		private string _PageName;
		private int _ControlTypeID;
		private int _UserTypeID;
		private bool _IsVisible;
		private bool _IsEnabled;
		private bool _Del;
		private bool _isNew;
		#endregion
		
		#region < CONSTRUCTORES >
		protected UserPermissionsBase()
		{
			_UserPermissionsID = 0;
			_ControlName = string.Empty;
			_PageName = string.Empty;
			_ControlTypeID = 0;
			_UserTypeID = 0;
			_IsVisible = false;
			_IsEnabled = false;
			_Del = false;
		}
		
		protected UserPermissionsBase(int UserPermissionsID) : this()
		{
			_UserPermissionsID = UserPermissionsID;
		}
	
		protected UserPermissionsBase(int UserPermissionsID, string ControlName, string PageName, int ControlTypeID, int UserTypeID, bool IsVisible, bool IsEnabled, bool Del) : this()
		{
			_UserPermissionsID = UserPermissionsID;
			_ControlName = ControlName;
			_PageName = PageName;
			_ControlTypeID = ControlTypeID;
			_UserTypeID = UserTypeID;
			_IsVisible = IsVisible;
			_IsEnabled = IsEnabled;
			_Del = Del;
		}

		#endregion
		
		#region < Metodos para Obtención de Detalles >

		public static DataTable GetByControlType(int ControlTypeID)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Select * From UserPermissions Where ControlTypeID = @ControlTypeID";
            DbCommand dbCommandWrapper = db.GetSqlStringCommand(sqlCommand);
			db.AddInParameter(dbCommandWrapper, "@ControlTypeID", DbType.Int32, ControlTypeID);

			DataTable t = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
			t.Columns["ControlTypeID"].DefaultValue = ControlTypeID;

            return t;
		}

		public static DataTable GetByUserType(int UserTypeID)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Select * From UserPermissions Where UserTypeID = @UserTypeID";
            DbCommand dbCommandWrapper = db.GetSqlStringCommand(sqlCommand);
			db.AddInParameter(dbCommandWrapper, "@UserTypeID", DbType.Int32, UserTypeID);

			DataTable t = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
			t.Columns["UserTypeID"].DefaultValue = UserTypeID;

            return t;
		}

		#endregion
		
		#region < PROPIEDADES >
		
		public int UserPermissionsID
		{
			get	{ return _UserPermissionsID; }
			set	{ _UserPermissionsID = value; }
		}
		
		public string ControlName
		{
			get	{ return _ControlName; }
			set	{ _ControlName = value; }
		}
		
		public string PageName
		{
			get	{ return _PageName; }
			set	{ _PageName = value; }
		}
		
		public int ControlTypeID
		{
			get	{ return _ControlTypeID; }
			set	{ _ControlTypeID = value; }
		}
		
		public int UserTypeID
		{
			get	{ return _UserTypeID; }
			set	{ _UserTypeID = value; }
		}
		
		public bool IsVisible
		{
			get	{ return _IsVisible; }
			set	{ _IsVisible = value; }
		}
		
		public bool IsEnabled
		{
			get	{ return _IsEnabled; }
			set	{ _IsEnabled = value; }
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
				_isNew = (_UserPermissionsID == 0);
				return _isNew; 
			}
			set { _isNew = value; }
		}
		#endregion		

		#region Utilerias
		public static bool Existe(int UserPermissionsID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = "daab_ExistsUserPermissions";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add in parameters
			db.AddInParameter(dbCommandWrapper, "@UserPermissionsID", DbType.Int32, UserPermissionsID);

			// DataSet that will hold the returned results		
			// Note: connection closed by ExecuteDataSet method call 
			bool ret = false;
			int num = Convert.ToInt32(db.ExecuteScalar(dbCommandWrapper));
			ret = num > 0;
			return ret;
		}
		
		public static DataTable GetAllUserPermissions()
		{
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_GetAllUserPermissions";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);
			DataTable ret = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
            ret.PrimaryKey = new DataColumn[] { ret.Columns["UserPermissionsID"] };
			
            return ret;
		}
		
		public static void SaveAll(DataTable tabla)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbDataAdapter da = db.GetDataAdapter();
			
			da.SelectCommand = db.GetStoredProcCommand("daab_GetAllUserPermissions");
            da.InsertCommand = db.GetStoredProcCommand("daab_AddUserPermissions");
            da.UpdateCommand = db.GetStoredProcCommand("daab_UpdateUserPermissions");
            da.DeleteCommand = db.GetStoredProcCommand("daab_DeleteUserPermissions");
			
			#region Parametros de InsertCommand
			db.AddOutParameter(da.InsertCommand, "@UserPermissionsID", DbType.Int32, 4);
			db.AddInParameter(da.InsertCommand, "@ControlName", DbType.String, "ControlName", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@PageName", DbType.String, "PageName", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@ControlTypeID", DbType.Int32, "ControlTypeID", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@UserTypeID", DbType.Int32, "UserTypeID", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@IsVisible", DbType.Boolean, "IsVisible", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@IsEnabled", DbType.Boolean, "IsEnabled", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@Del", DbType.Boolean, "Del", DataRowVersion.Default);

			#endregion
			
			#region Parametros de UpdateCommand
			db.AddInParameter(da.UpdateCommand, "@UserPermissionsID", DbType.Int32, "UserPermissionsID", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@ControlName", DbType.String, "ControlName", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@PageName", DbType.String, "PageName", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@ControlTypeID", DbType.Int32, "ControlTypeID", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@UserTypeID", DbType.Int32, "UserTypeID", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@IsVisible", DbType.Boolean, "IsVisible", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@IsEnabled", DbType.Boolean, "IsEnabled", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Del", DbType.Boolean, "Del", DataRowVersion.Default);

			#endregion
			
			#region Parametros de DeleteCommand
			db.AddInParameter(da.DeleteCommand, "@UserPermissionsID", DbType.Int32, "UserPermissionsID", DataRowVersion.Default);

			#endregion

			db.UpdateDataSet(tabla.DataSet, tabla.TableName, da.InsertCommand, da.UpdateCommand, da.DeleteCommand, UpdateBehavior.Standard);
		}
		#endregion

		/// <summary>
		/// Populates a dataset with info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="UserPermissionsID"></param>
		/// <returns>A DataSet containing the results of the query</returns>
		private DataSet LoadByPrimaryKey(int UserPermissionsID)
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_GetUserPermissions";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add in parameters
			db.AddInParameter(dbCommandWrapper, "@UserPermissionsID", DbType.Int32, UserPermissionsID);

			// DataSet that will hold the returned results		
			// Note: connection closed by ExecuteDataSet method call 
			return db.ExecuteDataSet(dbCommandWrapper);
		}
	
		/// <summary>
		/// Populates current instance of the object with info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="UserPermissionsID"></param>
		public virtual void Load(int UserPermissionsID)
		{
			// DataSet that will hold the returned results		
			DataSet ds = this.LoadByPrimaryKey(UserPermissionsID);
			
			// Load member variables from datarow
			DataRow row = ds.Tables[0].Rows[0];
			_UserPermissionsID = (int)row["UserPermissionsID"];
			_ControlName = row.IsNull("ControlName") ? string.Empty : (string)row["ControlName"];
			_PageName = row.IsNull("PageName") ? string.Empty : (string)row["PageName"];
			_ControlTypeID = row.IsNull("ControlTypeID") ? 0 : (int)row["ControlTypeID"];
			_UserTypeID = row.IsNull("UserTypeID") ? 0 : (int)row["UserTypeID"];
			_IsVisible = row.IsNull("IsVisible") ? false : (bool)row["IsVisible"];
			_IsEnabled = row.IsNull("IsEnabled") ? false : (bool)row["IsEnabled"];
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

			string sqlCommand = "daab_AddUserPermissions";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add parameters
			db.AddOutParameter(dbCommandWrapper, "@UserPermissionsID", DbType.Int32, 4);
			db.AddInParameter(dbCommandWrapper, "@ControlName", DbType.String, SetNullValue((_ControlName == string.Empty), _ControlName));
			db.AddInParameter(dbCommandWrapper, "@PageName", DbType.String, SetNullValue((_PageName == string.Empty), _PageName));
			db.AddInParameter(dbCommandWrapper, "@ControlTypeID", DbType.Int32, SetNullValue((_ControlTypeID == 0), _ControlTypeID));
			db.AddInParameter(dbCommandWrapper, "@UserTypeID", DbType.Int32, SetNullValue((_UserTypeID == 0), _UserTypeID));
			db.AddInParameter(dbCommandWrapper, "@IsVisible", DbType.Boolean, SetNullValue((_IsVisible == false), _IsVisible));
			db.AddInParameter(dbCommandWrapper, "@IsEnabled", DbType.Boolean, SetNullValue((_IsEnabled == false), _IsEnabled));
			db.AddInParameter(dbCommandWrapper, "@Del", DbType.Boolean, SetNullValue((_Del == false), _Del));

			db.ExecuteNonQuery(dbCommandWrapper);
			
			// Save output parameter values
			object param;
			param = db.GetParameterValue(dbCommandWrapper, "@UserPermissionsID");
			if (param == DBNull.Value) return false;
			_UserPermissionsID = (int)param;
			
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

			string sqlCommand = "daab_UpdateUserPermissions";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add parameters
			db.AddInParameter(dbCommandWrapper, "@UserPermissionsID", DbType.Int32, _UserPermissionsID);
			db.AddInParameter(dbCommandWrapper, "@ControlName", DbType.String, SetNullValue((_ControlName == string.Empty), _ControlName));
			db.AddInParameter(dbCommandWrapper, "@PageName", DbType.String, SetNullValue((_PageName == string.Empty), _PageName));
			db.AddInParameter(dbCommandWrapper, "@ControlTypeID", DbType.Int32, SetNullValue((_ControlTypeID == 0), _ControlTypeID));
			db.AddInParameter(dbCommandWrapper, "@UserTypeID", DbType.Int32, SetNullValue((_UserTypeID == 0), _UserTypeID));
			db.AddInParameter(dbCommandWrapper, "@IsVisible", DbType.Boolean, SetNullValue((_IsVisible == false), _IsVisible));
			db.AddInParameter(dbCommandWrapper, "@IsEnabled", DbType.Boolean, SetNullValue((_IsEnabled == false), _IsEnabled));
			db.AddInParameter(dbCommandWrapper, "@Del", DbType.Boolean, SetNullValue((_Del == false), _Del));

			try
			{
				db.ExecuteNonQuery(dbCommandWrapper);
				
				// Save output parameter values
				object param;
				param = db.GetParameterValue(dbCommandWrapper, "@UserPermissionsID");
				if (param == DBNull.Value) return false;
				_UserPermissionsID = (int)param;
				
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
		/// <param name="UserPermissionsID"></param>
		public static void Remove(int UserPermissionsID)
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_DeleteUserPermissions";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add primary keys to command wrapper.
			db.AddInParameter(dbCommandWrapper, "@UserPermissionsID", DbType.Int32, UserPermissionsID);

			db.ExecuteNonQuery(dbCommandWrapper);
		}
		
		/// <summary>
		/// Serializes the current instance data to an Xml string.
		/// </summary>
		/// <returns>A string containing the Xml representation of the object.</returns>
		virtual public string ToXml()
		{
			// DataSet that will hold the returned results		
			DataSet ds = this.LoadByPrimaryKey(_UserPermissionsID);
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