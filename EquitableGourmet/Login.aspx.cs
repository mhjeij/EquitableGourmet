using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EquitableGourmet;


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        {
            if (!IsPostBack)
                Session["Logged"] = "false";
        }
    }

    protected void SignIn_Click(object sender, EventArgs e)
    {
        //server side check..
        if (Convert.ToString(txtUsername.Value) == "" || Convert.ToString(txtPassword.Value) == "")
        {
            //no user input! alert appears with same page remins.
            litError.Text = "Please add a valid username and password!";
            divError.Attributes["Class"] = "alert alert-danger";
        }
        else
        {
            //take entered username and password (the hashed value)
            string u_name = txtUsername.Value;
            string u_pass = Crypto.GetHashString(txtPassword.Value);

            DataTable dt = EquitableGourmet.User.Authenticate(u_name, u_pass);

            //check if user is found..
            if (dt.Rows.Count == 1)
            {
                if (Convert.ToInt16(dt.Rows[0]["UserStatusID"]) == 1)
                {
                    //user found, then then take this record values and assign them for session variables to be used in the master page.
                    Session["Logged"] = "true"; //flag for logged Y/N 
                    Session["Username"] = u_name; //
                    Session["UserTypeid"] = dt.Rows[0]["UserTypeID"]; //according to usertype, pages will be loaded
                    Session["Name"] = dt.Rows[0]["Name"]; //the name of the user, to be added in the welcome label

                    //Go to main page
                    Response.Redirect("Main.aspx");
                }
                else
                {
                    //user is not active! alert appears with same page remins.
                    litError.Text = "Inactive User! Kindly sign in with another user.";
                    divError.Attributes["Class"] = "alert alert-danger";
                }
            }
            else
            {
                //no user found! alert appears with same page remins.
                litError.Text = "Your Username and Password Don't Match";
                divError.Attributes["Class"] = "alert alert-danger";
            }

        }
    }

}