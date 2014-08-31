using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using EquitableGourmet;
using System.Configuration;
using System.Text.RegularExpressions;


public partial class Password_Reset : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        {
            if (!IsPostBack)
                Session["Logged"] = "false";
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //server side check..
        if (Convert.ToString(txtUsername.Value) == "")
        {
            //no user input! alert appears with same page remins.
            litError.Text = "Please add a valid username!";
            divError.Attributes["Class"] = "alert alert-danger";
        }
        else
        {
            //check if user exsits in the db..
            DataTable dt = EquitableGourmet.User.UserExists(txtUsername.Value);
            if (dt.Rows.Count == 0)
            {
                litError.Text = "Username Does Not Exist!";
                divError.Attributes["Class"] = "alert alert-danger";
            }
            else
            {
                if (Convert.ToInt16(dt.Rows[0]["UserStatusID"]) == 1) //if the user is active!! then:  
                {
                    //generate an automatic code valid for one hour..
                    ResetPassword NewRes = new ResetPassword();
                    string GenCode = System.Web.Security.Membership.GeneratePassword(16, 0);
                    string newGenCode;
                    newGenCode = Regex.Replace(GenCode, @"[^a-zA-Z0-9]", m => "9");

                    NewRes.Code = newGenCode;
                    NewRes.Username = Convert.ToString(txtUsername.Value);
                    NewRes.CreatedOn = DateTime.Now;
                    NewRes.IsValid = true;
                    NewRes.IsNew = true;

                    NewRes.Save();

                    //Send email for the specified user..
                    string from = System.Configuration.ConfigurationManager.AppSettings["EmailFrom"];
                    string to = Convert.ToString(dt.Rows[0]["Email"]);
                    string resetURL = "http://localhost:50848/Password_Reset_Receiver.aspx" + "?C=" + newGenCode;
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                    mail.To.Add(to);

                    mail.From = new System.Net.Mail.MailAddress(from, "Equitable Gourmet", System.Text.Encoding.UTF8);
                    mail.Subject = "Equitable Gourmet - PASSWORD";
                    mail.SubjectEncoding = System.Text.Encoding.UTF8;
                    mail.Body = "Dear " + Convert.ToString(dt.Rows[0]["Name"]) + ",\n\n" + "To reset your password please follow this link:\n" + resetURL + "\nBest Regards,";
                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

                    string passFrom = System.Configuration.ConfigurationManager.AppSettings["PasswordEmailFrom"];
                    client.Credentials = new System.Net.NetworkCredential(from, passFrom);

                    client.Port = 587; // Gmail works on this port<o:p />
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true; //Gmail works on Server Secured Layer

                    client.Send(mail);
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    //user is not active! alert appears with same page remins.
                    litError.Text = "Inactive User! Kindly sign in with another user.";
                    divError.Attributes["Class"] = "alert alert-danger";
                }


            }

        }
    }
}