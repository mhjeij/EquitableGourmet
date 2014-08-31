using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EquitableGourmet;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class SignUp : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        FillCombo();

    }

    protected void FillCombo()
    {

        DataTable dtUserTypes = UserType.GetAllUserType();
        ddlUserType.DataSource = dtUserTypes;
        ddlUserType.DataTextField = "Name";
        ddlUserType.DataValueField = "UserTypeID";
        ddlUserType.DataBind();

        DataTable dtAccounts = Account.GetAllAccount();
        ddlAccount.DataSource = dtAccounts;
        ddlAccount.DataTextField = "CompanyName";
        ddlAccount.DataValueField = "AccountID";
        ddlAccount.DataBind();

    }

    protected void SignUp_Click(object sender, EventArgs e)
    {
        //basic check!
        foreach (Control c in Page.Controls)
        {
            System.Web.UI.HtmlControls.HtmlInputGenericControl _c = c as System.Web.UI.HtmlControls.HtmlInputGenericControl;

            if (_c != null)
            {
                if (_c.Value == string.Empty)
                {
                    litError.Text = "All Fields Are Required!";
                    divError.Attributes["Class"] = "alert alert-danger";
                    return;
                }
            }

        }


        //user duplicates check!
        DataTable dt = EquitableGourmet.User.UserExists(txtUsername.Value);
        if (dt.Rows.Count > 0)
        {
            litError.Text = "Username Already Exists!";
            divError.Attributes["Class"] = "alert alert-danger";

        }
        else
        {


            EquitableGourmet.User NewUser = new User();

            NewUser.IsNew = true;
            NewUser.Name = txtName.Value;
            NewUser.Username = txtUsername.Value;
            NewUser.Password =  Crypto.GetHashString(txtPassword.Value);
            NewUser.UserTypeID = Convert.ToInt32(ddlUserType.SelectedValue);
            NewUser.AccountID = Convert.ToInt32(ddlAccount.SelectedValue);
            NewUser.Email = txtEmail.Value;
            NewUser.Website = txtWebsite.Value;
            NewUser.Telephone = txtTelephone.Value;
            NewUser.CreatedOn = DateTime.Now;
            NewUser.LastLogin = DateTime.Now;
            NewUser.UserStatusID = 1;
           

            NewUser.Save();
            Response.Redirect("Login.aspx");
        }

    }
}