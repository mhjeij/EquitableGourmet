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
	public abstract class PromotionDetailBase
	{
		#region < VARIABLES >
		private int _PromotionDetailID;
		private string _Name;
		private string _Number;
		private int _PromotionID;
		private int _ProductID;
		private int _Quantity;
		private double _UnitPrice;
		private double _Discount;
		private double _Total;
		private bool _Del;
		private bool _isNew;
		#endregion
		
		#region < CONSTRUCTORES >
		protected PromotionDetailBase()
		{
			_PromotionDetailID = 0;
			_Name = string.Empty;
			_Number = string.Empty;
			_PromotionID = 0;
			_ProductID = 0;
			_Quantity = 0;
			_UnitPrice = 0;
			_Discount = 0;
			_Total = 0;
			_Del = false;
		}
		
		protected PromotionDetailBase(int PromotionDetailID) : this()
		{
			_PromotionDetailID = PromotionDetailID;
		}
	
		protected PromotionDetailBase(int PromotionDetailID, string Name, string Number, int PromotionID, int ProductID, int Quantity, double UnitPrice, double Discount, double Total, bool Del) : this()
		{
			_PromotionDetailID = PromotionDetailID;
			_Name = Name;
			_Number = Number;
			_PromotionID = PromotionID;
			_ProductID = ProductID;
			_Quantity = Quantity;
			_UnitPrice = UnitPrice;
			_Discount = Discount;
			_Total = Total;
			_Del = Del;
		}

		#endregion
		
		#region < Metodos para Obtención de Detalles >

		public static DataTable GetByProduct(int ProductID)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Select * From PromotionDetail Where ProductID = @ProductID";
            DbCommand dbCommandWrapper = db.GetSqlStringCommand(sqlCommand);
			db.AddInParameter(dbCommandWrapper, "@ProductID", DbType.Int32, ProductID);

			DataTable t = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
			t.Columns["ProductID"].DefaultValue = ProductID;

            return t;
		}

		public static DataTable GetByPromotion(int PromotionID)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Select * From PromotionDetail Where PromotionID = @PromotionID";
            DbCommand dbCommandWrapper = db.GetSqlStringCommand(sqlCommand);
			db.AddInParameter(dbCommandWrapper, "@PromotionID", DbType.Int32, PromotionID);

			DataTable t = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
			t.Columns["PromotionID"].DefaultValue = PromotionID;

            return t;
		}

		#endregion
		
		#region < PROPIEDADES >
		
		public int PromotionDetailID
		{
			get	{ return _PromotionDetailID; }
			set	{ _PromotionDetailID = value; }
		}
		
		public string Name
		{
			get	{ return _Name; }
			set	{ _Name = value; }
		}
		
		public string Number
		{
			get	{ return _Number; }
			set	{ _Number = value; }
		}
		
		public int PromotionID
		{
			get	{ return _PromotionID; }
			set	{ _PromotionID = value; }
		}
		
		public int ProductID
		{
			get	{ return _ProductID; }
			set	{ _ProductID = value; }
		}
		
		public int Quantity
		{
			get	{ return _Quantity; }
			set	{ _Quantity = value; }
		}
		
		public double UnitPrice
		{
			get	{ return _UnitPrice; }
			set	{ _UnitPrice = value; }
		}
		
		public double Discount
		{
			get	{ return _Discount; }
			set	{ _Discount = value; }
		}
		
		public double Total
		{
			get	{ return _Total; }
			set	{ _Total = value; }
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
				_isNew = (_PromotionDetailID == 0);
				return _isNew; 
			}
			set { _isNew = value; }
		}
		#endregion		

		#region Utilerias
		public static bool Existe(int PromotionDetailID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = "daab_ExistsPromotionDetail";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add in parameters
			db.AddInParameter(dbCommandWrapper, "@PromotionDetailID", DbType.Int32, PromotionDetailID);

			// DataSet that will hold the returned results		
			// Note: connection closed by ExecuteDataSet method call 
			bool ret = false;
			int num = Convert.ToInt32(db.ExecuteScalar(dbCommandWrapper));
			ret = num > 0;
			return ret;
		}
		
		public static DataTable GetAllPromotionDetail()
		{
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_GetAllPromotionDetail";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);
			DataTable ret = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
            ret.PrimaryKey = new DataColumn[] { ret.Columns["PromotionDetailID"] };
			
            return ret;
		}
		
		public static void SaveAll(DataTable tabla)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbDataAdapter da = db.GetDataAdapter();
			
			da.SelectCommand = db.GetStoredProcCommand("daab_GetAllPromotionDetail");
            da.InsertCommand = db.GetStoredProcCommand("daab_AddPromotionDetail");
            da.UpdateCommand = db.GetStoredProcCommand("daab_UpdatePromotionDetail");
            da.DeleteCommand = db.GetStoredProcCommand("daab_DeletePromotionDetail");
			
			#region Parametros de InsertCommand
			db.AddOutParameter(da.InsertCommand, "@PromotionDetailID", DbType.Int32, 4);
			db.AddInParameter(da.InsertCommand, "@Name", DbType.String, "Name", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@Number", DbType.String, "Number", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@PromotionID", DbType.Int32, "PromotionID", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@ProductID", DbType.Int32, "ProductID", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@Quantity", DbType.Int32, "Quantity", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@UnitPrice", DbType.Double, "UnitPrice", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@Discount", DbType.Double, "Discount", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@Total", DbType.Double, "Total", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@Del", DbType.Boolean, "Del", DataRowVersion.Default);

			#endregion
			
			#region Parametros de UpdateCommand
			db.AddInParameter(da.UpdateCommand, "@PromotionDetailID", DbType.Int32, "PromotionDetailID", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Name", DbType.String, "Name", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Number", DbType.String, "Number", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@PromotionID", DbType.Int32, "PromotionID", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@ProductID", DbType.Int32, "ProductID", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Quantity", DbType.Int32, "Quantity", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@UnitPrice", DbType.Double, "UnitPrice", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Discount", DbType.Double, "Discount", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Total", DbType.Double, "Total", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Del", DbType.Boolean, "Del", DataRowVersion.Default);

			#endregion
			
			#region Parametros de DeleteCommand
			db.AddInParameter(da.DeleteCommand, "@PromotionDetailID", DbType.Int32, "PromotionDetailID", DataRowVersion.Default);

			#endregion

			db.UpdateDataSet(tabla.DataSet, tabla.TableName, da.InsertCommand, da.UpdateCommand, da.DeleteCommand, UpdateBehavior.Standard);
		}
		#endregion

		/// <summary>
		/// Populates a dataset with info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="PromotionDetailID"></param>
		/// <returns>A DataSet containing the results of the query</returns>
		private DataSet LoadByPrimaryKey(int PromotionDetailID)
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_GetPromotionDetail";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add in parameters
			db.AddInParameter(dbCommandWrapper, "@PromotionDetailID", DbType.Int32, PromotionDetailID);

			// DataSet that will hold the returned results		
			// Note: connection closed by ExecuteDataSet method call 
			return db.ExecuteDataSet(dbCommandWrapper);
		}
	
		/// <summary>
		/// Populates current instance of the object with info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="PromotionDetailID"></param>
		public virtual void Load(int PromotionDetailID)
		{
			// DataSet that will hold the returned results		
			DataSet ds = this.LoadByPrimaryKey(PromotionDetailID);
			
			// Load member variables from datarow
			DataRow row = ds.Tables[0].Rows[0];
			_PromotionDetailID = (int)row["PromotionDetailID"];
			_Name = row.IsNull("Name") ? string.Empty : (string)row["Name"];
			_Number = row.IsNull("Number") ? string.Empty : (string)row["Number"];
			_PromotionID = row.IsNull("PromotionID") ? 0 : (int)row["PromotionID"];
			_ProductID = row.IsNull("ProductID") ? 0 : (int)row["ProductID"];
			_Quantity = row.IsNull("Quantity") ? 0 : (int)row["Quantity"];
			_UnitPrice = row.IsNull("UnitPrice") ? 0 : (double)row["UnitPrice"];
			_Discount = row.IsNull("Discount") ? 0 : (double)row["Discount"];
			_Total = row.IsNull("Total") ? 0 : (double)row["Total"];
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

			string sqlCommand = "daab_AddPromotionDetail";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add parameters
			db.AddOutParameter(dbCommandWrapper, "@PromotionDetailID", DbType.Int32, 4);
			db.AddInParameter(dbCommandWrapper, "@Name", DbType.String, SetNullValue((_Name == string.Empty), _Name));
			db.AddInParameter(dbCommandWrapper, "@Number", DbType.String, SetNullValue((_Number == string.Empty), _Number));
			db.AddInParameter(dbCommandWrapper, "@PromotionID", DbType.Int32, SetNullValue((_PromotionID == 0), _PromotionID));
			db.AddInParameter(dbCommandWrapper, "@ProductID", DbType.Int32, SetNullValue((_ProductID == 0), _ProductID));
			db.AddInParameter(dbCommandWrapper, "@Quantity", DbType.Int32, SetNullValue((_Quantity == 0), _Quantity));
			db.AddInParameter(dbCommandWrapper, "@UnitPrice", DbType.Double, SetNullValue((_UnitPrice == 0), _UnitPrice));
			db.AddInParameter(dbCommandWrapper, "@Discount", DbType.Double, SetNullValue((_Discount == 0), _Discount));
			db.AddInParameter(dbCommandWrapper, "@Total", DbType.Double, SetNullValue((_Total == 0), _Total));
			db.AddInParameter(dbCommandWrapper, "@Del", DbType.Boolean, SetNullValue((_Del == false), _Del));

			db.ExecuteNonQuery(dbCommandWrapper);
			
			// Save output parameter values
			object param;
			param = db.GetParameterValue(dbCommandWrapper, "@PromotionDetailID");
			if (param == DBNull.Value) return false;
			_PromotionDetailID = (int)param;
			
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

			string sqlCommand = "daab_UpdatePromotionDetail";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add parameters
			db.AddInParameter(dbCommandWrapper, "@PromotionDetailID", DbType.Int32, _PromotionDetailID);
			db.AddInParameter(dbCommandWrapper, "@Name", DbType.String, SetNullValue((_Name == string.Empty), _Name));
			db.AddInParameter(dbCommandWrapper, "@Number", DbType.String, SetNullValue((_Number == string.Empty), _Number));
			db.AddInParameter(dbCommandWrapper, "@PromotionID", DbType.Int32, SetNullValue((_PromotionID == 0), _PromotionID));
			db.AddInParameter(dbCommandWrapper, "@ProductID", DbType.Int32, SetNullValue((_ProductID == 0), _ProductID));
			db.AddInParameter(dbCommandWrapper, "@Quantity", DbType.Int32, SetNullValue((_Quantity == 0), _Quantity));
			db.AddInParameter(dbCommandWrapper, "@UnitPrice", DbType.Double, SetNullValue((_UnitPrice == 0), _UnitPrice));
			db.AddInParameter(dbCommandWrapper, "@Discount", DbType.Double, SetNullValue((_Discount == 0), _Discount));
			db.AddInParameter(dbCommandWrapper, "@Total", DbType.Double, SetNullValue((_Total == 0), _Total));
			db.AddInParameter(dbCommandWrapper, "@Del", DbType.Boolean, SetNullValue((_Del == false), _Del));

			try
			{
				db.ExecuteNonQuery(dbCommandWrapper);
				
				// Save output parameter values
				object param;
				param = db.GetParameterValue(dbCommandWrapper, "@PromotionDetailID");
				if (param == DBNull.Value) return false;
				_PromotionDetailID = (int)param;
				
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
		/// <param name="PromotionDetailID"></param>
		public static void Remove(int PromotionDetailID)
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_DeletePromotionDetail";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add primary keys to command wrapper.
			db.AddInParameter(dbCommandWrapper, "@PromotionDetailID", DbType.Int32, PromotionDetailID);

			db.ExecuteNonQuery(dbCommandWrapper);
		}
		
		/// <summary>
		/// Serializes the current instance data to an Xml string.
		/// </summary>
		/// <returns>A string containing the Xml representation of the object.</returns>
		virtual public string ToXml()
		{
			// DataSet that will hold the returned results		
			DataSet ds = this.LoadByPrimaryKey(_PromotionDetailID);
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