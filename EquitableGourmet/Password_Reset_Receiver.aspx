<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Password_Reset_Receiver.aspx.cs" Inherits="Password_Reset_Receiver" %>

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
    <link href="assets/css/plugins.min.css" rel="stylesheet">
    <link href="assets/css/style.min.css" rel="stylesheet">
    <link href="#" rel="stylesheet" id="theme-color">
    <!-- END  MANDATORY STYLE -->
    <!-- BEGIN PAGE LEVEL STYLE -->
    <link href="assets/css/animate-custom.css" rel="stylesheet">
    <!-- END PAGE LEVEL STYLE -->
    <script src="assets/plugins/modernizr/modernizr-2.6.2-respond-1.1.0.min.js"></script>
</head>

<body class="login fade-in" data-page="password">
    <!-- BEGIN PASSWORD BOX -->
    <div class="container" id="login-block">
        <div class="row">
            <div class="col-sm-6 col-md-4 col-sm-offset-3 col-md-offset-4">
                <div class="login-box clearfix animated flipInY">
                    <div class="page-icon animated bounceInDown">
                    </div>
                    <div class="login-logo">
                        <a href="#">
                            <img class="img-responsive" src="/img/logo.png" alt="Company Logo" />
                        </a>
                    </div>
                    <hr />
                    <div class="login-form">
                        <!-- BEGIN ERROR BOX -->
                        <div class="alert alert-danger hide" runat="server" id="divError">
                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                            <h4>Error!</h4>

                            <asp:Literal runat="server" ID="litError"></asp:Literal>
                        </div>
                        <!-- END ERROR BOX -->
                        <form runat="server" data-parsley-validate>
                            <input runat="server" name="txtUsername" id="txtUsername" type="text" placeholder="username" class="input-field" required />
                            <input runat="server" name="txtPassword" id="txtPassword" type="password" placeholder="Password" class="input-field" required />
                            <input runat="server" name="txtConfirmPassword" id="txtConfirmPassword" type="password" placeholder="Confirm Password" class="input-field" required data-parsley-equalto="#txtPassword" />
                            <asp:button id="btnSubmit" class="btn btn-login btn-reset" data-style="expand-left" runat="server" text="RESET password" onclick="btnSubmit_Click" />

                             </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- END PASSWORD BOX -->
    <!-- BEGIN MANDATORY SCRIPTS -->
    <script src="assets/plugins/jquery-1.11.js"></script>
    <script src="assets/plugins/jquery-migrate-1.2.1.js"></script>
    <script src="assets/plugins/jquery-ui/jquery-ui-1.10.4.min.js"></script>
    <script src="assets/plugins/jquery-mobile/jquery.mobile-1.4.2.js"></script>
    <script src="assets/plugins/bootstrap/bootstrap.min.js"></script>
    <script src="assets/plugins/jquery.cookie.min.js" type="text/javascript"></script>
    <!-- END MANDATORY SCRIPTS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="assets/plugins/backstretch/backstretch.min.js"></script>
    <script src="assets/js/account.js"></script>
    <!-- END PAGE LEVEL SCRIPTS -->
</body>

</html>
