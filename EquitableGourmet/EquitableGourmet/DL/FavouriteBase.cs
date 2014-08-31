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
	public abstract class FavouriteBase
	{
		#region < VARIABLES >
		private int _FavouriteID;
		private int _UserID;
		private int _ProductID;
		private bool _Del;
		private bool _isNew;
		#endregion
		
		#region < CONSTRUCTORES >
		protected FavouriteBase()
		{
			_FavouriteID = 0;
			_UserID = 0;
			_ProductID = 0;
			_Del = false;
		}
		
		protected FavouriteBase(int FavouriteID) : this()
		{
			_FavouriteID = FavouriteID;
		}
	
		protected FavouriteBase(int FavouriteID, int UserID, int ProductID, bool Del) : this()
		{
			_FavouriteID = FavouriteID;
			_UserID = UserID;
			_ProductID = ProductID;
			_Del = Del;
		}

		#endregion
		
		#region < Metodos para Obtención de Detalles >

		public static DataTable GetByProduct(int ProductID)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Select * From Favourite Where ProductID = @ProductID";
            DbCommand dbCommandWrapper = db.GetSqlStringCommand(sqlCommand);
			db.AddInParameter(dbCommandWrapper, "@ProductID", DbType.Int32, ProductID);

			DataTable t = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
			t.Columns["ProductID"].DefaultValue = ProductID;

            return t;
		}

		#endregion
		
		#region < PROPIEDADES >
		
		public int FavouriteID
		{
			get	{ return _FavouriteID; }
			set	{ _FavouriteID = value; }
		}
		
		public int UserID
		{
			get	{ return _UserID; }
			set	{ _UserID = value; }
		}
		
		public int ProductID
		{
			get	{ return _ProductID; }
			set	{ _ProductID = value; }
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
				_isNew = (_FavouriteID == 0);
				return _isNew; 
			}
			set { _isNew = value; }
		}
		#endregion		

		#region Utilerias
		public static bool Existe(int FavouriteID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = "daab_ExistsFavourite";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add in parameters
			db.AddInParameter(dbCommandWrapper, "@FavouriteID", DbType.Int32, FavouriteID);

			// DataSet that will hold the returned results		
			// Note: connection closed by ExecuteDataSet method call 
			bool ret = false;
			int num = Convert.ToInt32(db.ExecuteScalar(dbCommandWrapper));
			ret = num > 0;
			return ret;
		}
		
		public static DataTable GetAllFavourite()
		{
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_GetAllFavourite";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);
			DataTable ret = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
            ret.PrimaryKey = new DataColumn[] { ret.Columns["FavouriteID"] };
			
            return ret;
		}
		
		public static void SaveAll(DataTable tabla)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbDataAdapter da = db.GetDataAdapter();
			
			da.SelectCommand = db.GetStoredProcCommand("daab_GetAllFavourite");
            da.InsertCommand = db.GetStoredProcCommand("daab_AddFavourite");
            da.UpdateCommand = db.GetStoredProcCommand("daab_UpdateFavourite");
            da.DeleteCommand = db.GetStoredProcCommand("daab_DeleteFavourite");
			
			#region Parametros de InsertCommand
			db.AddOutParameter(da.InsertCommand, "@FavouriteID", DbType.Int32, 4);
			db.AddInParameter(da.InsertCommand, "@UserID", DbType.Int32, "UserID", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@ProductID", DbType.Int32, "ProductID", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@Del", DbType.Boolean, "Del", DataRowVersion.Default);

			#endregion
			
			#region Parametros de UpdateCommand
			db.AddInParameter(da.UpdateCommand, "@FavouriteID", DbType.Int32, "FavouriteID", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@UserID", DbType.Int32, "UserID", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@ProductID", DbType.Int32, "ProductID", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Del", DbType.Boolean, "Del", DataRowVersion.Default);

			#endregion
			
			#region Parametros de DeleteCommand
			db.AddInParameter(da.DeleteCommand, "@FavouriteID", DbType.Int32, "FavouriteID", DataRowVersion.Default);

			#endregion

			db.UpdateDataSet(tabla.DataSet, tabla.TableName, da.InsertCommand, da.UpdateCommand, da.DeleteCommand, UpdateBehavior.Standard);
		}
		#endregion

		/// <summary>
		/// Populates a dataset with info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="FavouriteID"></param>
		/// <returns>A DataSet containing the results of the query</returns>
		private DataSet LoadByPrimaryKey(int FavouriteID)
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_GetFavourite";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add in parameters
			db.AddInParameter(dbCommandWrapper, "@FavouriteID", DbType.Int32, FavouriteID);

			// DataSet that will hold the returned results		
			// Note: connection closed by ExecuteDataSet method call 
			return db.ExecuteDataSet(dbCommandWrapper);
		}
	
		/// <summary>
		/// Populates current instance of the object with info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="FavouriteID"></param>
		public virtual void Load(int FavouriteID)
		{
			// DataSet that will hold the returned results		
			DataSet ds = this.LoadByPrimaryKey(FavouriteID);
			
			// Load member variables from datarow
			DataRow row = ds.Tables[0].Rows[0];
			_FavouriteID = (int)row["FavouriteID"];
			_UserID = row.IsNull("UserID") ? 0 : (int)row["UserID"];
			_ProductID = row.IsNull("ProductID") ? 0 : (int)row["ProductID"];
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

			string sqlCommand = "daab_AddFavourite";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add parameters
			db.AddOutParameter(dbCommandWrapper, "@FavouriteID", DbType.Int32, 4);
			db.AddInParameter(dbCommandWrapper, "@UserID", DbType.Int32, SetNullValue((_UserID == 0), _UserID));
			db.AddInParameter(dbCommandWrapper, "@ProductID", DbType.Int32, SetNullValue((_ProductID == 0), _ProductID));
			db.AddInParameter(dbCommandWrapper, "@Del", DbType.Boolean, SetNullValue((_Del == false), _Del));

			db.ExecuteNonQuery(dbCommandWrapper);
			
			// Save output parameter values
			object param;
			param = db.GetParameterValue(dbCommandWrapper, "@FavouriteID");
			if (param == DBNull.Value) return false;
			_FavouriteID = (int)param;
			
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

			string sqlCommand = "daab_UpdateFavourite";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add parameters
			db.AddInParameter(dbCommandWrapper, "@FavouriteID", DbType.Int32, _FavouriteID);
			db.AddInParameter(dbCommandWrapper, "@UserID", DbType.Int32, SetNullValue((_UserID == 0), _UserID));
			db.AddInParameter(dbCommandWrapper, "@ProductID", DbType.Int32, SetNullValue((_ProductID == 0), _ProductID));
			db.AddInParameter(dbCommandWrapper, "@Del", DbType.Boolean, SetNullValue((_Del == false), _Del));

			try
			{
				db.ExecuteNonQuery(dbCommandWrapper);
				
				// Save output parameter values
				object param;
				param = db.GetParameterValue(dbCommandWrapper, "@FavouriteID");
				if (param == DBNull.Value) return false;
				_FavouriteID = (int)param;
				
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
		/// <param name="FavouriteID"></param>
		public static void Remove(int FavouriteID)
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_DeleteFavourite";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add primary keys to command wrapper.
			db.AddInParameter(dbCommandWrapper, "@FavouriteID", DbType.Int32, FavouriteID);

			db.ExecuteNonQuery(dbCommandWrapper);
		}
		
		/// <summary>
		/// Serializes the current instance data to an Xml string.
		/// </summary>
		/// <returns>A string containing the Xml representation of the object.</returns>
		virtual public string ToXml()
		{
			// DataSet that will hold the returned results		
			DataSet ds = this.LoadByPrimaryKey(_FavouriteID);
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
