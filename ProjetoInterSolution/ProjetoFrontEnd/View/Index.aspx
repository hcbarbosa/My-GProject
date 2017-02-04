<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ProjetoInter.View.Index" %>
<!DOCTYPE html>
<html lang="en-us">
<head runat="server">
    <meta charset="utf-8">
    <title>My GProject</title>
    <meta name="description" content="">
    <meta name="author" content="">

    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">

    <!-- #CSS Links -->
    <!-- Basic Styles -->

    <link rel="stylesheet" type="text/css" media="screen" href="../bootstrap-3.2.0-dist/css/bootstrap.css">
    <link rel="stylesheet" type="text/css" media="screen" href="../bootstrap-3.2.0-dist/css/bootstrap-theme.css">
    <link rel="stylesheet" type="text/css" media="screen" href="../bootstrap-3.2.0-dist/css/bootstrap-theme.css.map">
    <link rel="stylesheet" type="text/css" media="screen" href="../bootstrap-3.2.0-dist/css/bootstrap-theme.min.css">
    <link rel="stylesheet" type="text/css" media="screen" href="../bootstrap-3.2.0-dist/css/bootstrap.css.map">
        
    <link rel="stylesheet" type="text/css" media="screen" href="../bootstrap-3.2.0-dist/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" media="screen" href="../Css/font-awesome.min.css">

    
    <link rel="stylesheet" type="text/css" media="screen" href="../Css/smartadmin-production.min.css">
    <link rel="stylesheet" type="text/css" media="screen" href="../Css/smartadmin-skins.min.css">

    <!-- configuraçao do layout-->
    <link rel="stylesheet" type="text/css" media="screen" href="../Css/demo.min.css">

    
    <link rel="shortcut icon" href="../Images/favicon/favicon.ico" type="image/x-iscon">
    <link rel="icon" href="../Images/favicon.png" type="image/x-icon">

    <!-- #GOOGLE FONT -->
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,700italic,300,400,700">

    <!-- #APP SCREEN / ICONS -->
    <!-- Specifying a Webpage Icon for Web Clip 
			 Ref: https://developer.apple.com/library/ios/documentation/AppleApplications/Reference/SafariWebContent/ConfiguringWebApplications/ConfiguringWebApplications.html -->
    <link rel="apple-touch-icon" href="../Images/splash/sptouch-icon-iphone.png">
    <link rel="apple-touch-icon" sizes="76x76" href="../Images/splash/touch-icon-ipad.png">
    <link rel="apple-touch-icon" sizes="120x120" href="../Images/splash/touch-icon-iphone-retina.png">
    <link rel="apple-touch-icon" sizes="152x152" href="../Images/splash/touch-icon-ipad-retina.png">

    <!-- iOS web-app metas : hides Safari UI Components and Changes Status Bar Appearance -->
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">

    <!-- Startup image for web apps -->
    <link rel="apple-touch-startup-image" href="../Images/splash/ipad-landscape.png" media="screen and (min-device-width: 481px) and (max-device-width: 1024px) and (orientation:landscape)">
    <link rel="apple-touch-startup-image" href="../Images/splash/ipad-portrait.png" media="screen and (min-device-width: 481px) and (max-device-width: 1024px) and (orientation:portrait)">
    <link rel="apple-touch-startup-image" href="../Images/splash/iphone.png" media="screen and (max-device-width: 320px)">
</head>
<body class="">

    <!-- #HEADER -->
    <header id="header">
        <div id="logo-group">

            <!-- cor verde do layout options #74f268-->
            <span id="logo">
                <img src="../Images/Logo/logo.png" "> 
            </span>
            <!-- END LOGO PLACEHOLDER -->

           <asp:Literal ID="comecocoment" runat="server"> </asp:Literal>
            <span id="activity" class="activity-dropdown"><i class="fa fa-user"></i><b class="badge">
                <asp:Literal ID="numeronotificacao" runat="server"></asp:Literal>
             </b> </span>

            <div class="ajax-dropdown">

                <div class=" btn-group btn-group-justified" data-toggle="buttons">
                   
                    <label class="btn btn-success">
                        <input type="radio" name="activity" id="Notifications.aspx">
                        Notification
                    </label>
                    <label class="btn btn-success">
                        <input type="radio" name="activity" id="Activities.aspx">
                        Activities
                    </label>                    
                </div>

                <div class="ajax-notifications custom-scroll">

                    <div class="alert alert-transparent">
                        <h4>Notification Content </h4>
                    </div>
                    <i class="fa fa-lock fa-4x fa-border"></i>

                </div>
            </div>
            <asp:Literal ID="fimcoment" runat="server"> </asp:Literal>
        </div>

        <div class="pull-right">
            <!-- collapse menu button -->
            <div id="hide-menu" class="btn-header pull-right">
                <span><a href="javascript:void(0);" data-action="toggleMenu" title="Collapse Menu"><i class="fa fa-reorder"></i></a></span>
            </div>
            <!-- end collapse menu -->

           
            <!-- logout button -->
            <div id="logout" class="btn-header transparent pull-right">
                <span><a href="Login.aspx" title="Sign Out" data-action="userLogout" data-logout-msg="Are you sure you want to exit the system?"><i class="fa fa-sign-out"></i></a></span>
            </div>
            <!-- end logout button -->

            <!-- search mobile button (this is hidden till mobile view port) -->
            <div id="search-mobile" class="btn-header transparent pull-right">
                <span><a href="javascript:void(0)" title="Search projects"><i class="fa fa-search"></i></a></span>
            </div>
            <!-- end search mobile button -->

            <!-- #SEARCH -->
            <!-- input: search field -->
            <form action="#Search.aspx" class="header-search pull-right">
                <input id="search-fld" type="text" name="param" placeholder="Search project">
                <button type="submit">
                    <i class="fa fa-search"></i>
                </button>
                <a href="javascript:void(0);" id="cancel-search-js" title="Cancel Search"><i class="fa fa-times"></i></a>
            </form>
            <!-- end input: search field -->

            <!-- myaccount button -->
            <div id="account" class="btn-header transparent pull-right">
                <span class="menu-item-parent"><a href="Index.aspx#Account.aspx" title="My Account"><i class="fa fa-cogs"></i></a></span>
            </div>
            <!-- end -->   

            <!-- fullscreen button -->
            <div id="fullscreen" class="btn-header transparent pull-right">
                <span><a href="javascript:void(0);" data-action="launchFullscreen" title="Full Screen"><i class="fa fa-arrows-alt"></i></a></span>
            </div>
            <!-- end fullscreen button -->     

        </div>
        <!-- end pulled right: nav area -->

    </header>
    <!-- END HEADER -->

    <!-- #NAVIGATION -->
    <!-- Left panel : Navigation area -->
    <!-- Note: This width of the aside area can be adjusted through LESS variables -->
    <aside id="left-panel">

        <!-- User info -->
        <div class="login-info">
            <span>
                <!-- User image size is adjusted inside CSS, it should stay as is -->

                <a href="Index.aspx#Account.aspx" title="My Account"  data-action="">
                    <asp:Image runat="server" ID="imguser" Cssclass="online" />
                    <span><asp:Label ID="usuario" runat="server" />
                    </span>
                    
                </a>

            </span>
        </div>
        <!-- end user info -->

        <!-- NAVIGATION : This navigation is also responsive

			To make this navigation dynamic please make sure to link the node
			(the reference to the nav > ul) after page load. Or the navigation
			will not initialize.
			-->
        <nav>
            
            <asp:Literal ID="painelnavegacao" runat="server"></asp:Literal>
            
        </nav>
        <span class="minifyme" data-action="minifyMenu"><i class="fa fa-arrow-circle-left hit"></i></span>

    </aside>
    <!-- END NAVIGATION -->

    <!-- #MAIN PANEL -->
    <div id="main" role="main">

        <!-- RIBBON -->
        <div id="ribbon">

            <span class="ribbon-button-alignment">
                <span id="refresh" class="btn btn-ribbon" data-action="resetWidgets" data-title="refresh" rel="tooltip" data-placement="bottom" data-original-title="<i class='text-warning fa fa-warning'></i> Warning! This will reset all your widget settings." data-html="true" data-reset-msg="Would you like to RESET all layout?"><i class="fa fa-refresh"></i></span>
            </span>

            <!-- breadcrumb -->
            <ol class="breadcrumb">
                <!-- This is auto generated -->
            </ol>
            <!-- end breadcrumb -->
        </div>
        <!-- END RIBBON -->

        <!-- #MAIN CONTENT -->
        <div id="content">
        </div>
        <!-- END #MAIN CONTENT -->

    </div>
    <!-- END #MAIN PANEL -->

    <!-- #PAGE FOOTER -->
    <div class="page-footer">
        <div class="row">
            <div class="col-xs-12">
                <span class="txt-color-white">Interdisciplinar Fatec Rio Preto © 2/2014</span>
            </div>
        </div>
        <!-- end row -->
    </div>
    <!-- END FOOTER -->

    
    <!-- #PLUGINS -->
    <!-- Link to Google CDN's jQuery + jQueryUI; fall back to local -->
    <script src="../Js/jquery.min.js"></script>
    <script>
        if (!window.jQuery) {
            document.write('<script src="../Js/libs/jquery-2.0.2.min.js"><\/script>');
        }
    </script>

    <script src="../Js/jquery-ui.min.js"></script>
    <script>
        if (!window.jQuery.ui) {
            document.write('<script src="../Js/libs/jquery-ui-1.10.3.min.js"><\/script>');
        }
    </script>

    <!-- IMPORTANT: APP CONFIG acao no menu de notificaçao -->
    <script src="../Js/app.config.js"></script>

    <!-- CUSTOM NOTIFICATION -- mensagens de logout clear config -->
    <script src="../Js/notification/SmartNotification.min.js"></script>

    <!-- JARVIS WIDGETS -- mensagens de notificacao -->
    <script src="../Js/smartwidgets/jarvis.widget.min.js"></script>

    <!-- Configuracao do layout -->
    <script src="../Js/demo.min.js"></script>

    <!-- Efeitos dos menus -->
    <script src="../Js/app.min.js"></script>
    <script src="../bootstrap-3.2.0-dist/js/bootstrap.js"></script>
    <script src="../bootstrap-3.2.0-dist/js/bootstrap.min.js"></script>
    
        <!-- JQUERY VALIDATE -->
		<script src="../Js/plugin/jquery-validate/jquery.validate.min.js"></script>

		<!-- JQUERY MASKED INPUT -->
		<script src="../Js/plugin/masked-input/jquery.maskedinput.min.js"></script>
       		
		<!-- BOOTSTRAP JS -->
		<script src="../Js/bootstrap/bootstrap.min.js"></script>

		
		<!-- SPARKLINES -->
		<script src="../Js/plugin/sparkline/jquery.sparkline.min.js"></script>

		
		<!-- JQUERY SELECT2 INPUT -->
		<script src="../Js/plugin/select2/select2.min.js"></script>	
    
    <!-- EASY PIE CHARTS -->
		<script src="../Js/plugin/easy-pie-chart/jquery.easy-pie-chart.min.js"></script>

    
    <script src="../Js/plugin/jquery-form/jquery-form.min.js"></script>
</body>
</html>
