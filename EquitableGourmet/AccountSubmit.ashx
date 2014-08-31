<%@ WebHandler Language="C#" Class="AccountSubmit" %>

using System;
using System.Web;
using System.Data;

public class AccountSubmit : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        if (context.Request.QueryString["select"] != null)
        {
            String select = context.Request.QueryString["select"];

            DataTable dt = EquitableGourmet.AccountTitle.GetAllAccountTitle(); //default value in order to be sent as parameter..
            switch (select)
            {
                case "1":
                    dt = EquitableGourmet.AccountTitle.GetAllAccountTitle();
                    break;
                case "2":
                    dt = EquitableGourmet.AccountClass.GetAllAccountClass();
                    break;
                case "3":
                    dt = EquitableGourmet.AccountIndustry.GetAllAccountIndustry();
                    break;

                case "4":
                    dt = EquitableGourmet.AccountType.GetAllAccountType();
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = "Name like 'Public%'";
                    dt = dv.ToTable();
                    break;
            }

            context.Response.Write(ConvertDataTabletoString(dt));
        }
        else
        {

            context.Response.ContentType = "text/plain";

            //Save Account..
            String Industry = context.Request.QueryString["accountIndustrySelect"];
            String Class = context.Request.QueryString["accountClassSelect"];
            String Title = context.Request.QueryString["accountTitleSelect"];
            String Type = context.Request.QueryString["accountTypeSelect"];
            String CompanyName = context.Request.QueryString["txtCompanyName"];
            String DisplayName = context.Request.QueryString["txtDisplayName"];
            String AEmail = context.Request.QueryString["txtEmail"];

            String MarigoldNumber = context.Request.QueryString["txtMarigoldNumber"];
            String Telephone1 = context.Request.QueryString["txtTelephone1"];
            String Telephone2 = context.Request.QueryString["txtTelephone2"];
            String Website = context.Request.QueryString["txtWebsite"];


            EquitableGourmet.Account NewAccount = new EquitableGourmet.Account();

            NewAccount.IsNew = true;
            NewAccount.AccountClassID = Convert.ToInt16(Class);
            NewAccount.AccountIndustryID = Convert.ToInt16(Industry);
            NewAccount.AccountStatusID = 1;
            NewAccount.AccountTitleID = Convert.ToInt16(Title);

            NewAccount.AccountTypeID = Convert.ToInt16(Type);
            NewAccount.CompanyName = CompanyName;

            NewAccount.CreatedOn = DateTime.Now;
            NewAccount.CreditDays = Convert.ToInt16("0");
            NewAccount.CreditLimit = Convert.ToInt16("0"); ;
            NewAccount.DisplayName = DisplayName;
            NewAccount.Email = AEmail;
            NewAccount.MarigoldNumber = MarigoldNumber;
            NewAccount.ModifiedOn = DateTime.Now;
            NewAccount.Telephone1 = Telephone1;
            NewAccount.Telephone2 = Telephone2;
            NewAccount.Website = Website;

            NewAccount.Save();


            //Save User..
            String U_Name = context.Request.QueryString["U_Name"];
            String U_UserName = context.Request.QueryString["U_UserName"];
            String U_Password = context.Request.QueryString["U_Password"];
            String U_UserTypeID = context.Request.QueryString["U_UserTypeID"];
            String U_AccountID = context.Request.QueryString["U_AccountID"];
            String U_Email = context.Request.QueryString["U_Email"];


            EquitableGourmet.User NewUser = new EquitableGourmet.User();
            DataTable dt = EquitableGourmet.Account.AccountExists(MarigoldNumber);
            Int16 AcctID = Convert.ToInt16(dt.Rows[0]["AccountID"]);


            NewUser.IsNew = true;
            NewUser.Name = U_Name;
            NewUser.Username = U_UserName;
            NewUser.Password = EquitableGourmet.Crypto.GetHashString(U_Password);
            NewUser.UserTypeID = 1;
            NewUser.AccountID = AcctID;
            NewUser.Email = U_Email;
            NewUser.Website = Website;
            NewUser.Telephone = Telephone1;
            NewUser.CreatedOn = DateTime.Now;
            NewUser.LastLogin = DateTime.Now;
            NewUser.UserStatusID = 1;

            NewUser.Save();

            context.Response.Write("success");
            context.Response.Redirect("Login.aspx");

        }


        //validation and database..
        /*  
          if() {}
        
            
          context.Response.Write("success");
          }
      else {
    
          context.Response.Write("failure");
  }*/
    }


    public string ConvertDataTabletoString(System.Data.DataTable dt)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> rows = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>>();
        System.Collections.Generic.Dictionary<string, object> row;
        foreach (System.Data.DataRow dr in dt.Rows)
        {
            row = new System.Collections.Generic.Dictionary<string, object>();
            foreach (System.Data.DataColumn col in dt.Columns)
            {

                row.Add(col.ColumnName, dr[col]);

            }
            rows.Add(row);
        }
        return serializer.Serialize(rows);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}