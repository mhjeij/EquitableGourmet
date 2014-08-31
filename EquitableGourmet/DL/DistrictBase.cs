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
	public abstract class DistrictBase
	{
		#region < VARIABLES >
		private int _DistrictID;
		private string _Name;
		private int _CityID;
		private bool _Del;
		private bool _isNew;
		#endregion
		
		#region < CONSTRUCTORES >
		protected DistrictBase()
		{
			_DistrictID = 0;
			_Name = string.Empty;
			_CityID = 0;
			_Del = false;
		}
		
		protected DistrictBase(int DistrictID) : this()
		{
			_DistrictID = DistrictID;
		}
	
		protected DistrictBase(int DistrictID, string Name, int CityID, bool Del) : this()
		{
			_DistrictID = DistrictID;
			_Name = Name;
			_CityID = CityID;
			_Del = Del;
		}

		#endregion
		
		#region < Metodos para Obtención de Detalles >

		public static DataTable GetByCity(int CityID)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Select * From District Where CityID = @CityID";
            DbCommand dbCommandWrapper = db.GetSqlStringCommand(sqlCommand);
			db.AddInParameter(dbCommandWrapper, "@CityID", DbType.Int32, CityID);

			DataTable t = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
			t.Columns["CityID"].DefaultValue = CityID;

            return t;
		}

		#endregion
		
		#region < PROPIEDADES >
		
		public int DistrictID
		{
			get	{ return _DistrictID; }
			set	{ _DistrictID = value; }
		}
		
		public string Name
		{
			get	{ return _Name; }
			set	{ _Name = value; }
		}
		
		public int CityID
		{
			get	{ return _CityID; }
			set	{ _CityID = value; }
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
				_isNew = (_DistrictID == 0);
				return _isNew; 
			}
			set { _isNew = value; }
		}
		#endregion		

		#region Utilerias
		public static bool Existe(int DistrictID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = "daab_ExistsDistrict";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add in parameters
			db.AddInParameter(dbCommandWrapper, "@DistrictID", DbType.Int32, DistrictID);

			// DataSet that will hold the returned results		
			// Note: connection closed by ExecuteDataSet method call 
			bool ret = false;
			int num = Convert.ToInt32(db.ExecuteScalar(dbCommandWrapper));
			ret = num > 0;
			return ret;
		}
		
		public static DataTable GetAllDistrict()
		{
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_GetAllDistrict";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);
			DataTable ret = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
            ret.PrimaryKey = new DataColumn[] { ret.Columns["DistrictID"] };
			
            return ret;
		}
		
		public static void SaveAll(DataTable tabla)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbDataAdapter da = db.GetDataAdapter();
			
			da.SelectCommand = db.GetStoredProcCommand("daab_GetAllDistrict");
            da.InsertCommand = db.GetStoredProcCommand("daab_AddDistrict");
            da.UpdateCommand = db.GetStoredProcCommand("daab_UpdateDistrict");
            da.DeleteCommand = db.GetStoredProcCommand("daab_DeleteDistrict");
			
			#region Parametros de InsertCommand
			db.AddOutParameter(da.InsertCommand, "@DistrictID", DbType.Int32, 4);
			db.AddInParameter(da.InsertCommand, "@Name", DbType.String, "Name", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@CityID", DbType.Int32, "CityID", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@Del", DbType.Boolean, "Del", DataRowVersion.Default);

			#endregion
			
			#region Parametros de UpdateCommand
			db.AddInParameter(da.UpdateCommand, "@DistrictID", DbType.Int32, "DistrictID", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Name", DbType.String, "Name", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@CityID", DbType.Int32, "CityID", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Del", DbType.Boolean, "Del", DataRowVersion.Default);

			#endregion
			
			#region Parametros de DeleteCommand
			db.AddInParameter(da.DeleteCommand, "@DistrictID", DbType.Int32, "DistrictID", DataRowVersion.Default);

			#endregion

			db.UpdateDataSet(tabla.DataSet, tabla.TableName, da.InsertCommand, da.UpdateCommand, da.DeleteCommand, UpdateBehavior.Standard);
		}
		#endregion

		/// <summary>
		/// Populates a dataset with info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="DistrictID"></param>
		/// <returns>A DataSet containing the results of the query</returns>
		private DataSet LoadByPrimaryKey(int DistrictID)
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_GetDistrict";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add in parameters
			db.AddInParameter(dbCommandWrapper, "@DistrictID", DbType.Int32, DistrictID);

			// DataSet that will hold the returned results		
			// Note: connection closed by ExecuteDataSet method call 
			return db.ExecuteDataSet(dbCommandWrapper);
		}
	
		/// <summary>
		/// Populates current instance of the object with info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="DistrictID"></param>
		public virtual void Load(int DistrictID)
		{
			// DataSet that will hold the returned results		
			DataSet ds = this.LoadByPrimaryKey(DistrictID);
			
			// Load member variables from datarow
			DataRow row = ds.Tables[0].Rows[0];
			_DistrictID = (int)row["DistrictID"];
			_Name = row.IsNull("Name") ? string.Empty : (string)row["Name"];
			_CityID = row.IsNull("CityID") ? 0 : (int)row["CityID"];
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

			string sqlCommand = "daab_AddDistrict";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add parameters
			db.AddOutParameter(dbCommandWrapper, "@DistrictID", DbType.Int32, 4);
			db.AddInParameter(dbCommandWrapper, "@Name", DbType.String, SetNullValue((_Name == string.Empty), _Name));
			db.AddInParameter(dbCommandWrapper, "@CityID", DbType.Int32, SetNullValue((_CityID == 0), _CityID));
            db.AddInParameter(dbCommandWrapper, "@Del", DbType.Boolean, SetNullValue((_Del == true), _Del));

			db.ExecuteNonQuery(dbCommandWrapper);
			
			// Save output parameter values
			object param;
			param = db.GetParameterValue(dbCommandWrapper, "@DistrictID");
			if (param == DBNull.Value) return false;
			_DistrictID = (int)param;
			
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

			string sqlCommand = "daab_UpdateDistrict";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add parameters
			db.AddInParameter(dbCommandWrapper, "@DistrictID", DbType.Int32, _DistrictID);
			db.AddInParameter(dbCommandWrapper, "@Name", DbType.String, SetNullValue((_Name == string.Empty), _Name));
			db.AddInParameter(dbCommandWrapper, "@CityID", DbType.Int32, SetNullValue((_CityID == 0), _CityID));
			db.AddInParameter(dbCommandWrapper, "@Del", DbType.Boolean, SetNullValue((_Del == false), _Del));

			try
			{
				db.ExecuteNonQuery(dbCommandWrapper);
				
				// Save output parameter values
				object param;
				param = db.GetParameterValue(dbCommandWrapper, "@DistrictID");
				if (param == DBNull.Value) return false;
				_DistrictID = (int)param;
				
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
		/// <param name="DistrictID"></param>
		public static void Remove(int DistrictID)
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_DeleteDistrict";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add primary keys to command wrapper.
			db.AddInParameter(dbCommandWrapper, "@DistrictID", DbType.Int32, DistrictID);

			db.ExecuteNonQuery(dbCommandWrapper);
		}
		
		/// <summary>
		/// Serializes the current instance data to an Xml string.
		/// </summary>
		/// <returns>A string containing the Xml representation of the object.</returns>
		virtual public string ToXml()
		{
			// DataSet that will hold the returned results		
			DataSet ds = this.LoadByPrimaryKey(_DistrictID);
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
