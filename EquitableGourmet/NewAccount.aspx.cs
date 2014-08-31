using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using EquitableGourmet;

public partial class NewAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillCombo();

    }

    protected void FillCombo()
    {

       

        DataTable dtAccountType = AccountType.GetAllAccountType();
        DataView dv = dtAccountType.DefaultView;
        dv.RowFilter = "Name like 'Public%'";
        ddlAccountType.DataSource = dv;
        ddlAccountType.DataTextField = "Name";
        ddlAccountType.DataValueField = "AccountTypeID";
        ddlAccountType.DataBind();

        DataTable dtAccountClass = AccountClass.GetAllAccountClass();
        ddlAccountClass.DataSource = dtAccountClass;
        ddlAccountClass.DataTextField = "Name";
        ddlAccountClass.DataValueField = "AccountClassID";
        ddlAccountClass.DataBind();

        DataTable dtAccountTitle = AccountTitle.GetAllAccountTitle();
        ddlAccountTitle.DataSource = dtAccountTitle;
        ddlAccountTitle.DataTextField = "Name";
        ddlAccountTitle.DataValueField = "AccountTitleID";
        ddlAccountTitle.DataBind();

        DataTable dtAccountIndustry = AccountIndustry.GetAllAccountIndustry();
        ddlAccountIndustry.DataSource = dtAccountIndustry;
        ddlAccountIndustry.DataTextField = "Name";
        ddlAccountIndustry.DataValueField = "AccountIndustryID";
        ddlAccountIndustry.DataBind();
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
        DataTable dt = EquitableGourmet.Account.AccountExists(txtMarigoldNumber.Value);
        if (dt.Rows.Count > 0)
        {
            litError.Text = "Account Already Exists!";
            divError.Attributes["Class"] = "alert alert-danger";

        }
        else
        {


            EquitableGourmet.Account NewAccount = new Account();

            NewAccount.IsNew = true;
            NewAccount.AccountClassID = Convert.ToInt32(ddlAccountClass.SelectedValue);
            NewAccount.AccountIndustryID = Convert.ToInt32(ddlAccountIndustry.SelectedValue);
            NewAccount.AccountStatusID = 1;
            NewAccount.AccountTitleID = Convert.ToInt32(ddlAccountTitle.SelectedValue);
           
            
            NewAccount.AccountTypeID = Convert.ToInt32(ddlAccountType.SelectedValue);
            NewAccount.CompanyName = txtCompanyName.Value;
            
            NewAccount.CreatedOn = DateTime.Now;
            NewAccount.CreditDays = Convert.ToInt16(txtCreditDays.Value);
            NewAccount.CreditLimit = Convert.ToDouble(txtCreditLimit.Value);
            NewAccount.DisplayName = txtDisplayName.Value;
            NewAccount.Email = txtEmail.Value;
            NewAccount.MarigoldNumber = txtMarigoldNumber.Value;
            NewAccount.ModifiedOn = DateTime.Now;
            NewAccount.Telephone1 = txtTelephone1.Value;
            NewAccount.Telephone2 = txtTelephone2.Value;
            NewAccount.Website = txtWebsite.Value;
           

            NewAccount.Save();
        
        }

    }
}