
// Generated by MyGeneration Version # (1.3.0.3)

using System;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace EquitableGourmet
{
	public class Menu : MenuBase
	{
		#region < CONSTRUCTORES >
		
		public Menu() : base()	{}
		
		#endregion



        public static DataTable GetMenuAccordingToRole(int UserTypeID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            string sqlCommand = "GetMenuAccordingToRole";
            DbCommand dbCommandWrapper = db.GetStoredProcCommand(sqlCommand);
            db.AddInParameter(dbCommandWrapper, "@UserTypeID", DbType.Int32, UserTypeID);
            DataSet ds = db.ExecuteDataSet(dbCommandWrapper);

            DataTable dt = ds.Tables[0];

            return dt;

        }
	}
}
