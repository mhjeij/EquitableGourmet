<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewAccount.aspx.cs" Inherits="NewAccount" %>

<!DOCTYPE html>
<!--[if lt IE 7]>      <html class="no-js sidebar-large lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="no-js sidebar-large lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="no-js sidebar-large lt-ie9"> <![endif]-->
<!--[if gt IE 8]><!-->
<html class="no-js sidebar-large">
<!--<![endif]-->

<head>
    <!-- BEGIN META SECTION -->
    <meta charset="utf-8">
    <title>Equitable Gourmet</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta content="" name="description" />
    <meta content="themes-lab" name="author" />
    <link rel="shortcut icon" href="assets/img/favicon.png">
    <!-- END META SECTION -->
    <!-- BEGIN MANDATORY STYLE -->
    <link href="assets/css/icons/icons.min.css" rel="stylesheet">
    <link href="assets/css/bootstrap.min.css" rel="stylesheet">
    <link href="assets/css/plugins.css" rel="stylesheet">
    <link href="assets/plugins/bootstrap-loading/lada.min.css" rel="stylesheet">
    <link href="assets/css/style.min.css" rel="stylesheet">
    <!-- END  MANDATORY STYLE -->
    <script src="assets/plugins/modernizr/modernizr-2.6.2-respond-1.1.0.min.js"></script>
</head>

<body class="login fade-in" data-page="signup">
    <!-- START SIGNUP BOX -->
    <div class="container" id="login-block">
        <div class="row">
            <div class="col-sm-6 col-md-4 col-sm-offset-3 col-md-offset-4">
                <div class="login-box clearfix animated flipInY">
                    <div class="page-icon animated bounceInDown">
                        <img src="assets/img/account/register-icon.png" alt="Register icon" />
                    </div>
                    <div class="login-logo">
                        <a href="#">
                            <img src="img/logo.png" alt="Company Logo" />
                        </a>
                    </div>
                    <hr>
                    <div class="login-form">
                        <!-- Start Error box -->
                        <div class="alert alert-danger hide" runat="server" id="divError">
                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                            <h4>Error!</h4>

                            <asp:Literal runat="server" ID="litError"></asp:Literal>
                        </div>
                        <!-- End Error box -->
                        <form runat="server" data-parsley-validate>
                           
                            <asp:DropDownList runat="server" ID="ddlAccountTitle" />
                            <asp:DropDownList runat="server" ID="ddlAccountIndustry" />
                            <asp:DropDownList runat="server" ID="ddlAccountClass" />

                            <input runat="server" name="txtCompanyName" id="txtCompanyName" type="text" placeholder="Company Name" class="input-field" required />
                            <input runat="server" name="txtDisplayName" id="txtDisplayName" type="text" placeholder="Display Name" class="input-field" required />
                            <input runat="server" name="txtMarigoldNumber" id="txtMarigoldNumber" type="text" placeholder="Marigold Number" class="input-field" required />
                            <input runat="server" name="txtEmail" id="txtEmail" type="email" placeholder="E-mail" class="input-field" required />
                            <input runat="server" name="txtWebsite" id="txtWebsite" type="text" placeholder="Website" class="input-field" required />
                            <input runat="server" name="txtTelephone1" id="txtTelephone1" type="tel" placeholder="Telephone" class="input-field" required />
                            <input runat="server" name="txtTelephone2" id="txtTelephone2" type="tel" placeholder="Telephone" class="input-field" required />

                            <asp:DropDownList runat="server" ID="ddlAccountType" />
                           
                            
                            <input runat="server" name="txtCreditLimit" id="txtCreditLimit" type="number" placeholder="Credit Limit" class="input-field" required />
                            <input runat="server" name="txtCreditDays" id="txtCreditDays" type="number" placeholder="Credit Days" class="input-field" required />

                            <asp:Button ID="btnSignUp" class="btn btn-login ladda-button" data-style="expand-left" runat="server" Text="Sign Up" OnClick="SignUp_Click" />


                        </form>
                        <div class="login-links">
                            <a href="Password_Reset.aspx">Forgot password?</a>
                            <br>
                            <a href="Login.aspx">Already have an account? <strong>Sign In</strong></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- END SIGNUP BOX -->
    <!-- BEGIN MANDATORY SCRIPTS -->
    <script src="assets/plugins/jquery-1.11.js"></script>
    <script src="assets/plugins/jquery-migrate-1.2.1.js"></script>
    <script src="assets/plugins/jquery-ui/jquery-ui-1.10.4.min.js"></script>
    <script src="assets/plugins/jquery-mobile/jquery.mobile-1.4.2.js"></script>
    <script src="assets/plugins/bootstrap/bootstrap.min.js"></script>
    <script src="assets/plugins/jquery.cookie.min.js" type="text/javascript"></script>
    <script src="assets/plugins/mandatoryJs.min.js"></script>

    <!-- END MANDATORY SCRIPTS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="assets/plugins/backstretch/backstretch.min.js"></script>
    <script src="assets/plugins/bootstrap-loading/lada.min.js"></script>
    <script src="assets/js/account.js"></script>
    <!-- END PAGE LEVEL SCRIPTS -->

    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="assets/plugins/parsley/parsley.min.js"></script>
    <script src="assets/plugins/parsley/parsley.extend.js"></script>

</body>

</html>
