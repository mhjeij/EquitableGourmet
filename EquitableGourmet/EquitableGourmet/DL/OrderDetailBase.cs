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
	public abstract class OrderDetailBase
	{
		#region < VARIABLES >
		private int _OrderDetailID;
		private int _OrderID;
		private int _ProductID;
		private int _Quantity;
		private double _UnitPrice;
		private double _Discount;
		private double _Tax;
		private double _Total;
		private bool _Del;
		private bool _isNew;
		#endregion
		
		#region < CONSTRUCTORES >
		protected OrderDetailBase()
		{
			_OrderDetailID = 0;
			_OrderID = 0;
			_ProductID = 0;
			_Quantity = 0;
			_UnitPrice = 0;
			_Discount = 0;
			_Tax = 0;
			_Total = 0;
			_Del = false;
		}
		
		protected OrderDetailBase(int OrderDetailID) : this()
		{
			_OrderDetailID = OrderDetailID;
		}
	
		protected OrderDetailBase(int OrderDetailID, int OrderID, int ProductID, int Quantity, double UnitPrice, double Discount, double Tax, double Total, bool Del) : this()
		{
			_OrderDetailID = OrderDetailID;
			_OrderID = OrderID;
			_ProductID = ProductID;
			_Quantity = Quantity;
			_UnitPrice = UnitPrice;
			_Discount = Discount;
			_Tax = Tax;
			_Total = Total;
			_Del = Del;
		}

		#endregion
		
		#region < Metodos para Obtención de Detalles >

		public static DataTable GetByOrder(int OrderID)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Select * From OrderDetail Where OrderID = @OrderID";
            DbCommand dbCommandWrapper = db.GetSqlStringCommand(sqlCommand);
			db.AddInParameter(dbCommandWrapper, "@OrderID", DbType.Int32, OrderID);

			DataTable t = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
			t.Columns["OrderID"].DefaultValue = OrderID;

            return t;
		}

		public static DataTable GetByProduct(int ProductID)
		{
			Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "Select * From OrderDetail Where ProductID = @ProductID";
            DbCommand dbCommandWrapper = db.GetSqlStringCommand(sqlCommand);
			db.AddInParameter(dbCommandWrapper, "@ProductID", DbType.Int32, ProductID);

			DataTable t = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
			t.Columns["ProductID"].DefaultValue = ProductID;

            return t;
		}

		#endregion
		
		#region < PROPIEDADES >
		
		public int OrderDetailID
		{
			get	{ return _OrderDetailID; }
			set	{ _OrderDetailID = value; }
		}
		
		public int OrderID
		{
			get	{ return _OrderID; }
			set	{ _OrderID = value; }
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
		
		public double Tax
		{
			get	{ return _Tax; }
			set	{ _Tax = value; }
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
				_isNew = (_OrderDetailID == 0);
				return _isNew; 
			}
			set { _isNew = value; }
		}
		#endregion		

		#region Utilerias
		public static bool Existe(int OrderDetailID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			string sqlCommand = "daab_ExistsOrderDetail";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add in parameters
			db.AddInParameter(dbCommandWrapper, "@OrderDetailID", DbType.Int32, OrderDetailID);

			// DataSet that will hold the returned results		
			// Note: connection closed by ExecuteDataSet method call 
			bool ret = false;
			int num = Convert.ToInt32(db.ExecuteScalar(dbCommandWrapper));
			ret = num > 0;
			return ret;
		}
		
		public static DataTable GetAllOrderDetail()
		{
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_GetAllOrderDetail";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);
			DataTable ret = db.ExecuteDataSet(dbCommandWrapper).Tables[0];
			
            ret.PrimaryKey = new DataColumn[] { ret.Columns["OrderDetailID"] };
			
            return ret;
		}
		
		public static void SaveAll(DataTable tabla)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbDataAdapter da = db.GetDataAdapter();
			
			da.SelectCommand = db.GetStoredProcCommand("daab_GetAllOrderDetail");
            da.InsertCommand = db.GetStoredProcCommand("daab_AddOrderDetail");
            da.UpdateCommand = db.GetStoredProcCommand("daab_UpdateOrderDetail");
            da.DeleteCommand = db.GetStoredProcCommand("daab_DeleteOrderDetail");
			
			#region Parametros de InsertCommand
			db.AddOutParameter(da.InsertCommand, "@OrderDetailID", DbType.Int32, 4);
			db.AddInParameter(da.InsertCommand, "@OrderID", DbType.Int32, "OrderID", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@ProductID", DbType.Int32, "ProductID", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@Quantity", DbType.Int32, "Quantity", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@UnitPrice", DbType.Double, "UnitPrice", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@Discount", DbType.Double, "Discount", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@Tax", DbType.Double, "Tax", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@Total", DbType.Double, "Total", DataRowVersion.Default);
			db.AddInParameter(da.InsertCommand, "@Del", DbType.Boolean, "Del", DataRowVersion.Default);

			#endregion
			
			#region Parametros de UpdateCommand
			db.AddInParameter(da.UpdateCommand, "@OrderDetailID", DbType.Int32, "OrderDetailID", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@OrderID", DbType.Int32, "OrderID", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@ProductID", DbType.Int32, "ProductID", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Quantity", DbType.Int32, "Quantity", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@UnitPrice", DbType.Double, "UnitPrice", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Discount", DbType.Double, "Discount", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Tax", DbType.Double, "Tax", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Total", DbType.Double, "Total", DataRowVersion.Default);
			db.AddInParameter(da.UpdateCommand, "@Del", DbType.Boolean, "Del", DataRowVersion.Default);

			#endregion
			
			#region Parametros de DeleteCommand
			db.AddInParameter(da.DeleteCommand, "@OrderDetailID", DbType.Int32, "OrderDetailID", DataRowVersion.Default);

			#endregion

			db.UpdateDataSet(tabla.DataSet, tabla.TableName, da.InsertCommand, da.UpdateCommand, da.DeleteCommand, UpdateBehavior.Standard);
		}
		#endregion

		/// <summary>
		/// Populates a dataset with info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="OrderDetailID"></param>
		/// <returns>A DataSet containing the results of the query</returns>
		private DataSet LoadByPrimaryKey(int OrderDetailID)
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_GetOrderDetail";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add in parameters
			db.AddInParameter(dbCommandWrapper, "@OrderDetailID", DbType.Int32, OrderDetailID);

			// DataSet that will hold the returned results		
			// Note: connection closed by ExecuteDataSet method call 
			return db.ExecuteDataSet(dbCommandWrapper);
		}
	
		/// <summary>
		/// Populates current instance of the object with info from the database, based on the requested primary key.
		/// </summary>
		/// <param name="OrderDetailID"></param>
		public virtual void Load(int OrderDetailID)
		{
			// DataSet that will hold the returned results		
			DataSet ds = this.LoadByPrimaryKey(OrderDetailID);
			
			// Load member variables from datarow
			DataRow row = ds.Tables[0].Rows[0];
			_OrderDetailID = (int)row["OrderDetailID"];
			_OrderID = row.IsNull("OrderID") ? 0 : (int)row["OrderID"];
			_ProductID = row.IsNull("ProductID") ? 0 : (int)row["ProductID"];
			_Quantity = row.IsNull("Quantity") ? 0 : (int)row["Quantity"];
			_UnitPrice = row.IsNull("UnitPrice") ? 0 : (double)row["UnitPrice"];
			_Discount = row.IsNull("Discount") ? 0 : (double)row["Discount"];
			_Tax = row.IsNull("Tax") ? 0 : (double)row["Tax"];
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

			string sqlCommand = "daab_AddOrderDetail";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add parameters
			db.AddOutParameter(dbCommandWrapper, "@OrderDetailID", DbType.Int32, 4);
			db.AddInParameter(dbCommandWrapper, "@OrderID", DbType.Int32, SetNullValue((_OrderID == 0), _OrderID));
			db.AddInParameter(dbCommandWrapper, "@ProductID", DbType.Int32, SetNullValue((_ProductID == 0), _ProductID));
			db.AddInParameter(dbCommandWrapper, "@Quantity", DbType.Int32, SetNullValue((_Quantity == 0), _Quantity));
			db.AddInParameter(dbCommandWrapper, "@UnitPrice", DbType.Double, SetNullValue((_UnitPrice == 0), _UnitPrice));
			db.AddInParameter(dbCommandWrapper, "@Discount", DbType.Double, SetNullValue((_Discount == 0), _Discount));
			db.AddInParameter(dbCommandWrapper, "@Tax", DbType.Double, SetNullValue((_Tax == 0), _Tax));
			db.AddInParameter(dbCommandWrapper, "@Total", DbType.Double, SetNullValue((_Total == 0), _Total));
			db.AddInParameter(dbCommandWrapper, "@Del", DbType.Boolean, SetNullValue((_Del == false), _Del));

			db.ExecuteNonQuery(dbCommandWrapper);
			
			// Save output parameter values
			object param;
			param = db.GetParameterValue(dbCommandWrapper, "@OrderDetailID");
			if (param == DBNull.Value) return false;
			_OrderDetailID = (int)param;
			
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

			string sqlCommand = "daab_UpdateOrderDetail";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add parameters
			db.AddInParameter(dbCommandWrapper, "@OrderDetailID", DbType.Int32, _OrderDetailID);
			db.AddInParameter(dbCommandWrapper, "@OrderID", DbType.Int32, SetNullValue((_OrderID == 0), _OrderID));
			db.AddInParameter(dbCommandWrapper, "@ProductID", DbType.Int32, SetNullValue((_ProductID == 0), _ProductID));
			db.AddInParameter(dbCommandWrapper, "@Quantity", DbType.Int32, SetNullValue((_Quantity == 0), _Quantity));
			db.AddInParameter(dbCommandWrapper, "@UnitPrice", DbType.Double, SetNullValue((_UnitPrice == 0), _UnitPrice));
			db.AddInParameter(dbCommandWrapper, "@Discount", DbType.Double, SetNullValue((_Discount == 0), _Discount));
			db.AddInParameter(dbCommandWrapper, "@Tax", DbType.Double, SetNullValue((_Tax == 0), _Tax));
			db.AddInParameter(dbCommandWrapper, "@Total", DbType.Double, SetNullValue((_Total == 0), _Total));
			db.AddInParameter(dbCommandWrapper, "@Del", DbType.Boolean, SetNullValue((_Del == false), _Del));

			try
			{
				db.ExecuteNonQuery(dbCommandWrapper);
				
				// Save output parameter values
				object param;
				param = db.GetParameterValue(dbCommandWrapper, "@OrderDetailID");
				if (param == DBNull.Value) return false;
				_OrderDetailID = (int)param;
				
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
		/// <param name="OrderDetailID"></param>
		public static void Remove(int OrderDetailID)
		{
			// Create the Database object, using the default database service. The
			// default database service is determined through configuration.
			Database db = DatabaseFactory.CreateDatabase();

			string sqlCommand = "daab_DeleteOrderDetail";
			DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);

			// Add primary keys to command wrapper.
			db.AddInParameter(dbCommandWrapper, "@OrderDetailID", DbType.Int32, OrderDetailID);

			db.ExecuteNonQuery(dbCommandWrapper);
		}
		
		/// <summary>
		/// Serializes the current instance data to an Xml string.
		/// </summary>
		/// <returns>A string containing the Xml representation of the object.</returns>
		virtual public string ToXml()
		{
			// DataSet that will hold the returned results		
			DataSet ds = this.LoadByPrimaryKey(_OrderDetailID);
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
