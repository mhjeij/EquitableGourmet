using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;

namespace EquitableGourmet
{
    public partial class Main : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserTypeID"] != null)
            {
                ltWelcomeUser.Text = " Welcome " + Session["Name"].ToString();
                PopoulateMenu();
            }

        }

        protected void PopoulateMenu()
        {
            int UserTypeID = Convert.ToInt32(Session["UserTypeID"]);
            DataTable dt = EquitableGourmet.Menu.GetMenuAccordingToRole(UserTypeID);
            DataView dv = dt.DefaultView;
            dv.Sort = "DisplayOrder";
            DataTable sortedDT = dv.ToTable();

            rptMenu.DataSource = sortedDT;
            rptMenu.DataBind();

        }

    }
}