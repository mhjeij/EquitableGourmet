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
	public abstract class PriceHistoryBase
	{
		#region < VARIABLES >
		private int _PriceHistoryID;
		private int _ProductID;
		private double _PreviousPrice;
		private double _CurrentPrice;
		private DateTime _CreatedOn;
		private bool _Del;
		private bool _isNew;
		#endregion
		
		#region < CONSTRUCTORES >
		protected PriceHistoryBase()
		{
			_PriceHistoryID = 0;
			_ProductID = 0;
			_PreviousPrice = 0;
			_CurrentPrice = 0;
			_CreatedOn = DateTime.Parse("01/01/1900");
			_Del = false;
		}
		
		protected PriceHistoryBase(int PriceHistoryID) : this()
		{
			_PriceHistoryID = PriceHistoryID;
		}
	
		protected PriceHistoryBase(int PriceHistoryID, int ProductID, double PreviousPrice, double CurrentPrice, DateTime CreatedOn, bool Del) : this()
		{
			_PriceHistoryID = PriceHistoryID;
			_ProductID = ProductID;
			_PreviousPrice = PreviousPrice;
			_CurrentPrice = CurrentPrice;
			_CreatedOn = CreatedOn;
			_Del = Del;
		}

		#endregion
		
		#region < Metodos para Obtención de Detalles >

		public static DataTable GetByProduct(int ProductID)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Select * From PriceHistory Where ProductID = @ProductID";
            DbCommand dbCommandWrapper = db.GetSqlStringCommand(sqlCommand);
			db.AddInParameter(dbCommandWrapper, "@ProductID", DbType.Int32, ProductID);

			DataTable t = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
			t.Columns["ProductID"].DefaultValue = ProductID;

            return t;
		}

		#endregion
		
		#region < PROPIEDADES >
		
		public int PriceHistoryID
		{
			get	{ return _PriceHistoryID; }
			set	{ _PriceHistoryID = value; }
		}
		
		public int ProductID
		{
			get	{ return _ProductID; }
			set	{ _ProductID = value; }
		}
		
		public double PreviousPrice
		{
			get	{ return _PreviousPrice; }
			set	{ _PreviousPrice = value; }
		}
		
		public double CurrentPrice
		{
			get	{ return _CurrentPrice; }
			set	{ _CurrentPrice = value; }
		}
		
		public DateTime CreatedOn
		{
			get	{ return _CreatedOn; }
			set	{ _CreatedOn = value; }
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
				_isNew = (_PriceHistoryID == 0);
				return _isNew; 
			}
			set { _isNew = value; }
		}
		#endregion		

		#region Utilerias
		public static bool Existe(int PriceHistoryID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = "daab_ExistsPriceHistory";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add in parameters
			db.AddInParameter(dbCommandWrapper, "@PriceHistoryID", DbType.Int32, PriceHistoryID);

			// DataSet that will hold the returned results		
			// Note: connection closed by ExecuteDataSet method call 
			bool ret = false;
			int num = Convert.ToInt32(db.ExecuteScalar(dbCommandWrapper));
			ret = num > 0;
			return ret;
		}
		
		public static DataTable GetAllPriceHistory()
		{
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_GetAllPriceHistory";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);
			DataTable ret = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
            ret.PrimaryKey = new DataColumn[] { ret.Columns["PriceHistoryID"] };
			
            return ret;
		}
		
		public static void SaveAll(DataTable tabla)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbDataAdapter da = db.GetDataAdapter();
			
			da.SelectCommand = db.GetStoredProcCommand("daab_GetAllPriceHistory");
            da.InsertCommand = db.GetStoredProcCommand("daab_AddPriceHistory");
            da.UpdateCommand = db.GetStoredProcCommand("daab_UpdatePriceHistory");
            da.DeleteCommand = db.GetStoredProcCommand("daab_DeletePriceHistory");
			
			#region Parametros de InsertCommand
			db.AddOutParameter(da.InsertCommand, "@PriceHistoryID", DbType.Int32, 4);
			db.AddInParameter(da.InsertCommand, "@ProductID", DbType.Int32, "ProductID", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@PreviousPrice", DbType.Double, "PreviousPrice", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@CurrentPrice", DbType.Double, "CurrentPrice", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@CreatedOn", DbType.DateTime, "CreatedOn", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@Del", DbType.Boolean, "Del", DataRowVersion.Default);

			#endregion
			
			#region Parametros de UpdateCommand
			db.AddInParameter(da.UpdateCommand, "@PriceHistoryID", DbType.Int32, "PriceHistoryID", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@ProductID", DbType.Int32, "ProductID", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@PreviousPrice", DbType.Double, "PreviousPrice", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@CurrentPrice", DbType.Double, "CurrentPrice", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@CreatedOn", DbType.DateTime, "CreatedOn", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Del", DbType.Boolean, "Del", DataRowVersion.Default);

			#endregion
			
			#region Parametros de DeleteCommand
			db.AddInParameter(da.DeleteCommand, "@PriceHistoryID", DbType.Int32, "PriceHistoryID", DataRowVersion.Default);

			#endregion

			db.UpdateDataSet(tabla.DataSet, tabla.TableName, da.InsertCommand, da.UpdateCommand, da.DeleteCommand, UpdateBehavior.Standard);
		}
		#endregion

		/// <summary>
		/// Populates a dataset with info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="PriceHistoryID"></param>
		/// <returns>A DataSet containing the results of the query</returns>
		private DataSet LoadByPrimaryKey(int PriceHistoryID)
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_GetPriceHistory";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add in parameters
			db.AddInParameter(dbCommandWrapper, "@PriceHistoryID", DbType.Int32, PriceHistoryID);

			// DataSet that will hold the returned results		
			// Note: connection closed by ExecuteDataSet method call 
			return db.ExecuteDataSet(dbCommandWrapper);
		}
	
		/// <summary>
		/// Populates current instance of the object with info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="PriceHistoryID"></param>
		public virtual void Load(int PriceHistoryID)
		{
			// DataSet that will hold the returned results		
			DataSet ds = this.LoadByPrimaryKey(PriceHistoryID);
			
			// Load member variables from datarow
			DataRow row = ds.Tables[0].Rows[0];
			_PriceHistoryID = (int)row["PriceHistoryID"];
			_ProductID = row.IsNull("ProductID") ? 0 : (int)row["ProductID"];
			_PreviousPrice = row.IsNull("PreviousPrice") ? 0 : (double)row["PreviousPrice"];
			_CurrentPrice = row.IsNull("CurrentPrice") ? 0 : (double)row["CurrentPrice"];
			_CreatedOn = row.IsNull("CreatedOn") ? DateTime.Parse("01/01/1900") : (DateTime)row["CreatedOn"];
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

			string sqlCommand = "daab_AddPriceHistory";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add parameters
			db.AddOutParameter(dbCommandWrapper, "@PriceHistoryID", DbType.Int32, 4);
			db.AddInParameter(dbCommandWrapper, "@ProductID", DbType.Int32, SetNullValue((_ProductID == 0), _ProductID));
			db.AddInParameter(dbCommandWrapper, "@PreviousPrice", DbType.Double, SetNullValue((_PreviousPrice == 0), _PreviousPrice));
			db.AddInParameter(dbCommandWrapper, "@CurrentPrice", DbType.Double, SetNullValue((_CurrentPrice == 0), _CurrentPrice));
			db.AddInParameter(dbCommandWrapper, "@CreatedOn", DbType.DateTime, SetNullValue((_CreatedOn == DateTime.Parse("01/01/1900")), _CreatedOn));
            db.AddInParameter(dbCommandWrapper, "@Del", DbType.Boolean, SetNullValue((_Del == true), _Del));

			db.ExecuteNonQuery(dbCommandWrapper);
			
			// Save output parameter values
			object param;
			param = db.GetParameterValue(dbCommandWrapper, "@PriceHistoryID");
			if (param == DBNull.Value) return false;
			_PriceHistoryID = (int)param;
			
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

			string sqlCommand = "daab_UpdatePriceHistory";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add parameters
			db.AddInParameter(dbCommandWrapper, "@PriceHistoryID", DbType.Int32, _PriceHistoryID);
			db.AddInParameter(dbCommandWrapper, "@ProductID", DbType.Int32, SetNullValue((_ProductID == 0), _ProductID));
			db.AddInParameter(dbCommandWrapper, "@PreviousPrice", DbType.Double, SetNullValue((_PreviousPrice == 0), _PreviousPrice));
			db.AddInParameter(dbCommandWrapper, "@CurrentPrice", DbType.Double, SetNullValue((_CurrentPrice == 0), _CurrentPrice));
			db.AddInParameter(dbCommandWrapper, "@CreatedOn", DbType.DateTime, SetNullValue((_CreatedOn == DateTime.Parse("01/01/1900")), _CreatedOn));
			db.AddInParameter(dbCommandWrapper, "@Del", DbType.Boolean, SetNullValue((_Del == false), _Del));

			try
			{
				db.ExecuteNonQuery(dbCommandWrapper);
				
				// Save output parameter values
				object param;
				param = db.GetParameterValue(dbCommandWrapper, "@PriceHistoryID");
				if (param == DBNull.Value) return false;
				_PriceHistoryID = (int)param;
				
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
		/// <param name="PriceHistoryID"></param>
		public static void Remove(int PriceHistoryID)
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_DeletePriceHistory";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add primary keys to command wrapper.
			db.AddInParameter(dbCommandWrapper, "@PriceHistoryID", DbType.Int32, PriceHistoryID);

			db.ExecuteNonQuery(dbCommandWrapper);
		}
		
		/// <summary>
		/// Serializes the current instance data to an Xml string.
		/// </summary>
		/// <returns>A string containing the Xml representation of the object.</returns>
		virtual public string ToXml()
		{
			// DataSet that will hold the returned results		
			DataSet ds = this.LoadByPrimaryKey(_PriceHistoryID);
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
