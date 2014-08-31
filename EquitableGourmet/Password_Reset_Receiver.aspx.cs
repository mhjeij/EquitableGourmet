using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Password_Reset_Receiver : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.QueryString["C"] != null)
            {

                //get code..
                String ReceivedCode = Request.QueryString["C"].ToString();

                DataTable dt = EquitableGourmet.ResetPassword.ValidateCode(ReceivedCode);
                if (dt.Rows.Count == 0)
                {// if no code is generated..

                    Response.Redirect("Login.aspx");

                }
                else
                {
                    // if code exists, but with expirydate more than 1 hour..
                    DateTime CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    TimeSpan t = CreatedOn - DateTime.Now;
                    if (t.TotalHours > 1)
                    {
                        Response.Redirect("Login.aspx");
                    }

                }

                string u_name = Convert.ToString(dt.Rows[0]["Username"]);
                txtUsername.Value = u_name;
                Session["Username"] = u_name;

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(txtUsername.Value) == "" || Convert.ToString(txtPassword.Value) == "" || Convert.ToString(txtConfirmPassword.Value) == "")
        {
            //no user input! alert appears with same page remins.
            litError.Text = "Please add a valid username and password!";
            divError.Attributes["Class"] = "alert alert-danger";
        }
        else
        {
            EquitableGourmet.User user = new EquitableGourmet.User();
            string u_name = Convert.ToString(Session["Username"]);
            DataTable dt = EquitableGourmet.User.UserExists(u_name);
            int uid = Convert.ToInt16(dt.Rows[0]["UserID"]);

            user.Load(uid);
            user.Password = EquitableGourmet.Crypto.GetHashString(txtPassword.Value);
            user.Save();

            Response.Redirect("Login.aspx");
        }
    }
}