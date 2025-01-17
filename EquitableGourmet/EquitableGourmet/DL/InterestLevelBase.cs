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
	public abstract class InterestLevelBase
	{
		#region < VARIABLES >
		private int _InterestLevelID;
		private string _Name;
		private bool _Del;
		private bool _isNew;
		#endregion
		
		#region < CONSTRUCTORES >
		protected InterestLevelBase()
		{
			_InterestLevelID = 0;
			_Name = string.Empty;
			_Del = false;
		}
		
		protected InterestLevelBase(int InterestLevelID) : this()
		{
			_InterestLevelID = InterestLevelID;
		}
	
		protected InterestLevelBase(int InterestLevelID, string Name, bool Del) : this()
		{
			_InterestLevelID = InterestLevelID;
			_Name = Name;
			_Del = Del;
		}

		#endregion
		
		#region < Metodos para Obtención de Detalles >

		#endregion
		
		#region < PROPIEDADES >
		
		public int InterestLevelID
		{
			get	{ return _InterestLevelID; }
			set	{ _InterestLevelID = value; }
		}
		
		public string Name
		{
			get	{ return _Name; }
			set	{ _Name = value; }
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
				_isNew = (_InterestLevelID == 0);
				return _isNew; 
			}
			set { _isNew = value; }
		}
		#endregion		

		#region Utilerias
		public static bool Existe(int InterestLevelID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = "daab_ExistsInterestLevel";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add in parameters
			db.AddInParameter(dbCommandWrapper, "@InterestLevelID", DbType.Int32, InterestLevelID);

			// DataSet that will hold the returned results		
			// Note: connection closed by ExecuteDataSet method call 
			bool ret = false;
			int num = Convert.ToInt32(db.ExecuteScalar(dbCommandWrapper));
			ret = num > 0;
			return ret;
		}
		
		public static DataTable GetAllInterestLevel()
		{
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_GetAllInterestLevel";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);
			DataTable ret = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
            ret.PrimaryKey = new DataColumn[] { ret.Columns["InterestLevelID"] };
			
            return ret;
		}
		
		public static void SaveAll(DataTable tabla)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbDataAdapter da = db.GetDataAdapter();
			
			da.SelectCommand = db.GetStoredProcCommand("daab_GetAllInterestLevel");
            da.InsertCommand = db.GetStoredProcCommand("daab_AddInterestLevel");
            da.UpdateCommand = db.GetStoredProcCommand("daab_UpdateInterestLevel");
            da.DeleteCommand = db.GetStoredProcCommand("daab_DeleteInterestLevel");
			
			#region Parametros de InsertCommand
			db.AddOutParameter(da.InsertCommand, "@InterestLevelID", DbType.Int32, 4);
			db.AddInParameter(da.InsertCommand, "@Name", DbType.String, "Name", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@Del", DbType.Boolean, "Del", DataRowVersion.Default);

			#endregion
			
			#region Parametros de UpdateCommand
			db.AddInParameter(da.UpdateCommand, "@InterestLevelID", DbType.Int32, "InterestLevelID", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Name", DbType.String, "Name", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Del", DbType.Boolean, "Del", DataRowVersion.Default);

			#endregion
			
			#region Parametros de DeleteCommand
			db.AddInParameter(da.DeleteCommand, "@InterestLevelID", DbType.Int32, "InterestLevelID", DataRowVersion.Default);

			#endregion

			db.UpdateDataSet(tabla.DataSet, tabla.TableName, da.InsertCommand, da.UpdateCommand, da.DeleteCommand, UpdateBehavior.Standard);
		}
		#endregion

		/// <summary>
		/// Populates a dataset with info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="InterestLevelID"></param>
		/// <returns>A DataSet containing the results of the query</returns>
		private DataSet LoadByPrimaryKey(int InterestLevelID)
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_GetInterestLevel";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add in parameters
			db.AddInParameter(dbCommandWrapper, "@InterestLevelID", DbType.Int32, InterestLevelID);

			// DataSet that will hold the returned results		
			// Note: connection closed by ExecuteDataSet method call 
			return db.ExecuteDataSet(dbCommandWrapper);
		}
	
		/// <summary>
		/// Populates current instance of the object with info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="InterestLevelID"></param>
		public virtual void Load(int InterestLevelID)
		{
			// DataSet that will hold the returned results		
			DataSet ds = this.LoadByPrimaryKey(InterestLevelID);
			
			// Load member variables from datarow
			DataRow row = ds.Tables[0].Rows[0];
			_InterestLevelID = (int)row["InterestLevelID"];
			_Name = row.IsNull("Name") ? string.Empty : (string)row["Name"];
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

			string sqlCommand = "daab_AddInterestLevel";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add parameters
			db.AddOutParameter(dbCommandWrapper, "@InterestLevelID", DbType.Int32, 4);
			db.AddInParameter(dbCommandWrapper, "@Name", DbType.String, SetNullValue((_Name == string.Empty), _Name));
			db.AddInParameter(dbCommandWrapper, "@Del", DbType.Boolean, SetNullValue((_Del == false), _Del));

			db.ExecuteNonQuery(dbCommandWrapper);
			
			// Save output parameter values
			object param;
			param = db.GetParameterValue(dbCommandWrapper, "@InterestLevelID");
			if (param == DBNull.Value) return false;
			_InterestLevelID = (int)param;
			
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

			string sqlCommand = "daab_UpdateInterestLevel";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add parameters
			db.AddInParameter(dbCommandWrapper, "@InterestLevelID", DbType.Int32, _InterestLevelID);
			db.AddInParameter(dbCommandWrapper, "@Name", DbType.String, SetNullValue((_Name == string.Empty), _Name));
			db.AddInParameter(dbCommandWrapper, "@Del", DbType.Boolean, SetNullValue((_Del == false), _Del));

			try
			{
				db.ExecuteNonQuery(dbCommandWrapper);
				
				// Save output parameter values
				object param;
				param = db.GetParameterValue(dbCommandWrapper, "@InterestLevelID");
				if (param == DBNull.Value) return false;
				_InterestLevelID = (int)param;
				
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
		/// <param name="InterestLevelID"></param>
		public static void Remove(int InterestLevelID)
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_DeleteInterestLevel";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add primary keys to command wrapper.
			db.AddInParameter(dbCommandWrapper, "@InterestLevelID", DbType.Int32, InterestLevelID);

			db.ExecuteNonQuery(dbCommandWrapper);
		}
		
		/// <summary>
		/// Serializes the current instance data to an Xml string.
		/// </summary>
		/// <returns>A string containing the Xml representation of the object.</returns>
		virtual public string ToXml()
		{
			// DataSet that will hold the returned results		
			DataSet ds = this.LoadByPrimaryKey(_InterestLevelID);
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
