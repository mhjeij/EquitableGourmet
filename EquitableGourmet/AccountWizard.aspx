<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AccountWizard.aspx.cs" Inherits="AccountWizard" %>

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
    <link href="assets/css/style.css" rel="stylesheet">
    <link href="#" rel="stylesheet" id="theme-color">
    <!-- END  MANDATORY STYLE -->
    <!-- BEGIN PAGE LEVEL STYLE -->
    <link rel="stylesheet" href="assets/plugins/wizard/wizard.css">
    <link rel="stylesheet" href="assets/plugins/jquery-steps/jquery.steps.css">
    <!-- END PAGE LEVEL STYLE -->
    <script src="assets/plugins/modernizr/modernizr-2.6.2-respond-1.1.0.min.js"></script>
    <style>
        .wizard-inline > .steps > ul > li {
            width: 20%;
        }

        .wizard-inline > .content {
            width: 50%;
            margin: 30px auto 0px auto;
        }

            .wizard-inline > .content > .body {
                width: 100%;
            }
    </style>
</head>

<body data-page="form_wizard">

    <!-- BEGIN MAIN CONTENT -->
    <div id="main-content">
        <div class="page-title">
            <i class="icon-custom-left"></i>
            <h3><strong>Equitable Gourmet</strong> Healthy Food. Healthy Life!</h3>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title"><strong>Welcome to Marigold!</strong></h3>
                    </div>
                    <div class="panel-body">

                        <div class="row">
                            <div class="col-md-12">

                                <h3><strong>Account </strong>Wizard</h3>
                                <p>Suppliers and Retailers</p>
                                <!-- BEGIN FORM WIZARD WITH VALIDATION -->
                                <form class="form-wizard" data-parsley-validate>
                                    <h1>Administrator User</h1>
                                    <section>
                                        <h2 class="hidden">&nbsp;</h2>

                                       


                                        <div class="form-group">
                                            <label for="userName">Name *</label>
                                            <input id="U_Name" name="U_Name" type="text" class="form-control required">
                                        </div>

                                        <div class="form-group">
                                            <label for="userName">User name *</label>
                                            <input id="U_UserName" name="U_UserName" type="text" class="form-control required">
                                        </div>

                                        <div class="form-group">
                                            <label for="password">Password *</label>
                                            <input id="U_Password" name="U_Password" type="password" class="form-control required">
                                        </div>
                                        <div class="form-group">
                                            <label for="confirm">Confirm Password *</label>
                                            <input id="txtconfirm" name="txtconfirmpassword" type="password" class="form-control required" data-parsley-equalto="#U_Password">
                                        </div>

                                        <div class="form-group">
                                            <label for="userName">Email *</label>
                                            <input id="U_Email" name="U_Email" type="email" class="form-control required">
                                        </div>
                                        <div class="form-group">
                                            <input class="required" tabindex="13" type="radio" id="like" name="optimize">
                                            <label for="like">
                                                I have read the <a href="#" onclick="window.open('PrivacyPolicy.aspx');">Privacy Policy</a>
                                            </label>

                                        </div>
                                    </section>

                                    <h1>Account Info</h1>
                                    <section>
                                        <h2 class="hidden">&nbsp;</h2>
                                         <div class="form-group">
                                            <label for="title">Title *</label>
                                            <select class="form-control" title="Select an account title..." name="accountTitleSelect" id="accountTitleSelect">
                                            </select>
                                        </div>

                                        <div class="form-group">
                                            <label for="company name">Company Name *</label>
                                            <input id="txtCompanyName" name="txtCompanyName" type="text" class="form-control required">
                                        </div>
                                        <div class="form-group">
                                            <label for="surname">Display Name *</label>
                                            <input id="txtDisplayName" name="txtDisplayName" type="text" class="form-control required">
                                        </div>
                                        <div class="form-group">
                                            <label for="surname">Marigold Number *</label>
                                            <input id="txtMarigoldNumber" name="txtMarigoldNumber" type="text" class="form-control required" />
                                        </div>
                                    </section>
                                    <h1>More Info</h1>
                                    <section>
                                        <h2 class="hidden">&nbsp;</h2>

                                        <div class="form-group">
                                            <label for="industry">Industry *</label>

                                            <select class="form-control" title="Select an account industry..." name="accountIndustrySelect" id="accountIndustrySelect">
                                            </select>
                                        </div>

                                        <div class="form-group">
                                            <label for="class">Class *</label>
                                            <select class="form-control" title="Select an account class..." name="accountClassSelect" id="accountClassSelect">
                                            </select>
                                        </div>
                                        <div class="form-group">
                                            <label for="surname">Type *</label>

                                            <select class="form-control" title="Select an account type..." name="accountTypeSelect" id="accountTypeSelect">
                                            </select>
                                        </div>
                                    </section>
                                    <h1>Contact Info</h1>
                                    <section>
                                        <h2 class="hidden">&nbsp;</h2>
                                        <div class="form-group">
                                            <label for="surname">Email *</label>
                                            <input name="txtEmail" id="txtEmail" type="email" class="form-control required" />
                                        </div>
                                        <div class="form-group">
                                            <label for="surname">Website *</label>
                                            <input name="txtWebsite" id="txtWebsite" type="text" class="form-control required" />
                                        </div>
                                        <div class="form-group">
                                            <label for="surname">Telephone *</label>
                                            <input name="txtTelephone1" id="txtTelephone1" type="tel" class="form-control required" />
                                        </div>
                                        <div class="form-group">
                                            <label for="surname">Telephone *</label>
                                            <input name="txtTelephone2" id="txtTelephone2" type="tel" class="form-control required" />
                                        </div>

                                    </section>
                                    <h1>Finish</h1>
                                    <section>
                                        <h2 class="hidden">&nbsp;</h2>
                                        <span>Terms and Conditions</span>
                                        <div class="pos-rel p-l-30">
                                            <input id="acceptTerms" name="acceptTerms" type="checkbox" class="pos-rel p-l-30 required">
                                            <label for="acceptTerms">
                                                I agree with the <a href="#" onclick="window.open('TermsAndConditions.aspx');">Terms and Conditions.</a>
                                            </label>
                                        </div>
                                    </section>
                                </form>
                                <!-- END FORM WIZARD WITH VALIDATION -->
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- END MAIN CONTENT -->

    <!-- BEGIN MANDATORY SCRIPTS -->
    <script src="assets/plugins/jquery-1.11.js"></script>
    <script src="assets/plugins/jquery-migrate-1.2.1.js"></script>
    <script src="assets/plugins/jquery-ui/jquery-ui-1.10.4.min.js"></script>
    <script src="assets/plugins/jquery-mobile/jquery.mobile-1.4.2.js"></script>
    <script src="assets/plugins/bootstrap/bootstrap.min.js"></script>
    <script src="assets/plugins/bootstrap-dropdown/bootstrap-hover-dropdown.min.js"></script>
    <script src="assets/plugins/bootstrap-select/bootstrap-select.js"></script>
    <script src="assets/plugins/mcustom-scrollbar/jquery.mCustomScrollbar.concat.min.js"></script>
    <script src="assets/plugins/mmenu/js/jquery.mmenu.min.all.js"></script>
    <script src="assets/plugins/nprogress/nprogress.js"></script>
    <script src="assets/plugins/charts-sparkline/sparkline.min.js"></script>
    <script src="assets/plugins/breakpoints/breakpoints.js"></script>
    <script src="assets/plugins/numerator/jquery-numerator.js"></script>
    <script src="assets/plugins/jquery.cookie.min.js" type="text/javascript"></script>
    <!-- END MANDATORY SCRIPTS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script type="text/javascript" src="assets/plugins/jquery-validation/jquery.validate.min.js"></script>
    <script type="text/javascript" src="assets/plugins/jquery-validation/additional-methods.min.js"></script>
    <script src="assets/plugins/wizard/wizard.js"></script>
    <script src="assets/plugins/jquery-steps/jquery.steps.js"></script>
    <script src="assets/js/form_wizard.js"></script>
    <!-- END  PAGE LEVEL SCRIPTS -->
    <script src="assets/js/application.js"></script>

    <!--Fill the title select list on client side-->
    <!--Begin-->
    <script>
        $.ajax({
            type: "GET",
            url: "AccountSubmit.ashx?select=1",
            dataType: "json",
            //data: form.serialize(), // serializes the form's elements.
            success: function (data) {
                $.each(data, function (index, element) {
                    $('#accountTitleSelect')
                         .append($("<option></option>")
                         .attr("value", element.AccountTitleID)
                         .text(element.Name));
                    
                });

            }
        });
    </script>
    <!--END-->

    <!--Fill the class select list on client side-->
    <!--Begin-->
     <script>
        $.ajax({
            type: "GET",
            url: "AccountSubmit.ashx?select=2",
            dataType: "json",
            //data: form.serialize(), // serializes the form's elements.
            success: function (data) {
                $.each(data, function (index, element) {
                    $('#accountClassSelect')
                         .append($("<option></option>")
                         .attr("value", element.AccountClassID)
                         .text(element.Name));
                });

            }
        });
    </script>
    <!--END-->

    <!--Fill the industry select list on client side-->
    <!--Begin-->
    <script>
        $.ajax({
            type: "GET",
            url: "AccountSubmit.ashx?select=3",
            dataType: "json",
            //data: form.serialize(), // serializes the form's elements.
            success: function (data) {
                $.each(data, function (index, element) {
                    $('#accountIndustrySelect')
                         .append($("<option></option>")
                         .attr("value", element.AccountIndustryID)
                         .text(element.Name));
                    
                });

            }
        });
    </script>
    <!--END-->

    <!--Fill the type select list on client side-->
    <!--Begin-->
     <script>
        $.ajax({
            type: "GET",
            url: "AccountSubmit.ashx?select=4",
            dataType: "json",
            //data: form.serialize(), // serializes the form's elements.
            success: function (data) {
                $.each(data, function (index, element) {
                    $('#accountTypeSelect')
                         .append($("<option></option>")
                         .attr("value", element.AccountTypeID)
                         .text(element.Name));
                });

            }
        });
    </script>
    <!--END-->


</body>

</html>
