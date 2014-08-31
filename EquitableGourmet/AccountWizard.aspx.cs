using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AccountWizard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        FillCombo();
        FillDefaultValues();

    }

    protected void FillCombo()
    {
        //DataTable dt = EquitableGourmet.AccountClass.GetAllAccountClass();

        //rptAcctClass.DataSource = dt;
        //rptAcctClass.DataBind();

        //dt = EquitableGourmet.AccountIndustry.GetAllAccountIndustry();

        //rptAcctIndustry.DataSource = dt;
        //rptAcctIndustry.DataBind();

        //dt = EquitableGourmet.AccountTitle.GetAllAccountTitle();

        ////rptAcctTitle.DataSource = dt;
        ////rptAcctTitle.DataBind();

        //dt = EquitableGourmet.AccountType.GetAllAccountType();
        //DataView dv = dt.DefaultView;
        //dv.RowFilter = "Name like 'Public%'";

        //rptAcctType.DataSource = dv;
        //rptAcctType.DataBind();
    }

    protected void FillDefaultValues()
    {
        
        //DataTable dt = EquitableGourmet.AccountClass.GetAllAccountClass();

        //rptAcctClass.DataSource = dt;
        //rptAcctClass.DataBind();

        //dt = EquitableGourmet.AccountIndustry.GetAllAccountIndustry();

        //rptAcctIndustry.DataSource = dt;
        //rptAcctIndustry.DataBind();

        //dt = EquitableGourmet.AccountTitle.GetAllAccountTitle();

        ////rptAcctTitle.DataSource = dt;
        ////rptAcctTitle.DataBind();

        //dt = EquitableGourmet.AccountType.GetAllAccountType();
        //DataView dv = dt.DefaultView;
        //dv.RowFilter = "Name like 'Public%'";

        //rptAcctType.DataSource = dv;
        //rptAcctType.DataBind();
    }

}