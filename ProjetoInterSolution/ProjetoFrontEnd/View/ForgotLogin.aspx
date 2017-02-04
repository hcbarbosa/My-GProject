<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotLogin.aspx.cs" Inherits="ProjetoInter.View.ForgotLogin" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html>

<html lang="en-us" id="extr-page">
	<head runat="server">
		<meta charset="utf-8">
		<title>Forgot Login</title>
		<meta name="description" content="">
		<meta name="author" content="">
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
		
		<!-- #CSS Links -->
		<!-- Basic Styles -->
		<link rel="stylesheet" type="text/css" media="screen" href="../Css/bootstrap.min.css">
		<link rel="stylesheet" type="text/css" media="screen" href="../Css/font-awesome.min.css">

		<!-- SmartAdmin Styles : Please note (smartadmin-production.css) was created using LESS variables -->
		<link rel="stylesheet" type="text/css" media="screen" href="../Css/smartadmin-production.min.css">
		<link rel="stylesheet" type="text/css" media="screen" href="../Css/smartadmin-skins.min.css">

		<!-- Demo purpose only: goes with demo.js, you can delete this css when designing your own WebApp -->
		<link rel="stylesheet" type="text/css" media="screen" href="../Css/demo.min.css">

		<!-- #FAVICONS -->
		<link rel="shortcut icon" href="../Images/favicon/favicon.ico" type="image/x-iscon">
        <link rel="icon" href="../Images/favicon.png" type="image/x-icon">

		<!-- #GOOGLE FONT -->
		<link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,700italic,300,400,700">

	</head>
	
	<body class="animated fadeInDown">

		<header id="header">
            <br />
			<center>
                <image src="../Images/Logo/logo.png"></image>
            </center>				
		</header>

		<div id="main" role="main">

			<!-- MAIN CONTENT -->
			<div id="content" class="container">

				<div class="row">
					
					<div class="col-xs-offset-4 col-xs-4">
						<div class="well no-padding">
							<form runat="server" id="loginform" class="smart-form client-form">
								<header>
									<asp:Literal ID="lblforgot" Text="<%$ resources:forgot %>" runat="server"></asp:Literal>
								</header>

								<fieldset>									
									<section>                                        
										<label class="label"><asp:Literal ID="lblemail" Text="<%$ resources:email %>" runat="server"></asp:Literal></label>
										<label class="input"> <i class="icon-append fa fa-envelope-o"></i>
											<input type="email" name="email" autofocus="autofocus">
											<b class="tooltip tooltip-top-right"><i class="fa fa-envelope-o txt-color-teal"></i> <asp:Literal ID="lblpleaseemail" Text="<%$ resources:pleaseemail %>" runat="server"></asp:Literal></b></label>
									</section>
                                    <section>                                        
                                        <asp:Label runat="server" ID="resposta" ForeColor="Red" CssClass="label" meta:resourcekey="respostaResource1" ></asp:Label>
                                    </section>									                                   									
								</fieldset>
								<footer>
									<asp:Button ID="send" runat="server" Text="Send" Cssclass="btn btn-success" OnClick="send_Click" meta:resourcekey="sendResource1" >
									</asp:Button>
                                    <button type="reset" id="cancel" class="btn btn-danger" >
                                        <asp:Literal ID="btncancela" Text="<%$ resources: cancela %>" runat="server"></asp:Literal>
                                    </button>
                                    </footer>
							</form>

						</div>
						
						
						
					</div>
				</div>
			</div>

		</div>

		<!--================================================== -->	

		<!-- PACE LOADER - turn this on if you want ajax loading to show (caution: uses lots of memory on iDevices)-->
		<script src="../Js/plugin/pace/pace.min.js"></script>

	    <!-- Link to Google CDN's jQuery + jQueryUI; fall back to local -->
	    <script src="../Js/jquery.min.js"></script>
		<script> if (!window.jQuery) { document.write('<script src="../Js/libs/jquery-2.0.2.min.js"><\/script>'); } </script>

	    <script src="//ajax.googleapis.com/ajax/libs/jqueryui/1.10.3/jquery-ui.min.js"></script>
		<script> if (!window.jQuery.ui) { document.write('<script src="../Js/libs/jquery-ui-1.10.3.min.js"><\/script>'); } </script>

		<!-- IMPORTANT: APP CONFIG -->
		<script src="../Js/app.config.js"></script>

		<!-- JS TOUCH : include this plugin for mobile drag / drop touch events 		
		<script src="js/plugin/jquery-touch/jquery.ui.touch-punch.min.js"></script> -->

		<!-- BOOTSTRAP JS -->		
		<script src="../Js/bootstrap/bootstrap.min.js"></script>

		<!-- JQUERY VALIDATE -->
		<script src="../Js/plugin/jquery-validate/jquery.validate.min.js"></script>
		
		<!-- JQUERY MASKED INPUT -->
		<script src="../Js/plugin/masked-input/jquery.maskedinput.min.js"></script>
		
		<!--[if IE 8]>
			
			<h1>Your browser is out of date, please update your browser by going to www.microsoft.com/download</h1>
			
		<![endif]-->

		<!-- MAIN APP JS FILE -->
		<script src="../Js/app.min.js"></script>

		<script type="text/javascript">
		    runAllForms();

		    $('#cancel').click(function () {
		        window.location = "Login.aspx";
		    });

		    $(function () {
		        // Validation
		        $("#loginform").validate({
		            // Rules for form validation
		            rules: {
		                email: {
		                    required: true,
		                    email: true
		                }
		            },

		            // Messages for form validation
		            messages: {
		                email: {
		                    required: 'Please enter your email',
		                    email: 'Please enter with VALID email'
		                }
		            },

		            // Do not change code below
		            errorPlacement: function (error, element) {
		                error.insertAfter(element.parent());
		            }
		        });
		    });
		</script>

</body>
</html>
