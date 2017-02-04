<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="ProjetoInter.View.Customers" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
 
          <!--botao new-->              
             <div class="col-xs-offset-11 col-xs-1">              
              <div class="btn-header transparent pull-right">                 
                    <input type="button" class="btn btn-success"  id="new" value="New"/>                    
              </div>
             </div>
        
        <br /><br /><br />

			<div class="jarviswidget jarviswidget-color-green" id="wid-id-2" data-widget-editbutton="false">
								
				<header>
					<span class="widget-icon"> <i class="fa fa-table"></i> </span>
					<h2>Customers</h2>

				</header>
                <!--registros-->
				<div>
					<div class="jarviswidget-editbox">						
					</div>
					<div class="widget-body no-padding">						
                        
                        <asp:Literal ID="ListCustomers" runat="server"  />						
		
					</div>
				</div>
			</div>
         

    <!-- div q contem a pagina de registrar cliente -->
     <div id="registercustomer" style="display:none">           
             
			<div class="jarviswidget" id="wid-id-3" data-widget-editbutton="false" data-widget-custombutton="false">			
				<div>										
					<div class="widget-body no-padding">
						
						<form id="orderform"  runat="server" class="smart-form" novalidate="novalidate">						

							<fieldset> 
                                <legend>Information & Address</legend>                               
                                <!--nome e empresa-->
								<div class="row">
									<section class="col col-xs-12">
										<label class="input"> <i class="icon-append fa fa-user"></i>
											<input type="text" name="name" placeholder="Name" maxlength="50" autofocus="autofocus"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-user txt-color-teal"></i> Please enter customer's name</b>
										</label>
									</section>
                                    
                                    </div>

                                <div class="row">
                                    <section class="col col-6">
                            			<label class="input"> <i class="icon-append fa fa-info"></i>
											<input type="text" name="cpf" data-mask="999.999.999-99" placeholder="CPF" maxlength="14"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-info txt-color-teal"></i> Please enter customer's cpf</b>
										</label>
									</section>                                    
                                
                                     <section class="col col-6">

                                         <div class="form-group">
									        <select style="width:100%" class="select2" name="company">
                                                    <asp:Literal ID="selecionaempresas" runat="server"></asp:Literal>											        
										        </select> 
									        
                                             </div>									       
									</section>    
                                    
                                </div>
                                      <!--profisso e cep-->
								<div class="row">
                                    <section class="col col-6">
										<label class="input"> <i class="icon-append fa fa-info "></i>
											<input type="text" name="profession" placeholder="Profession" />
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-info txt-color-teal"></i> Please enter customer's profession</b>										
										</label>
									</section>
									<section class="col col-6">
										<label class="input"> <i class="icon-append fa fa-pencil-square-o "></i>
											<input type="text" name="zip" placeholder="Zip Code" data-mask="99999-999" maxlength="9"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-pencil-square-o txt-color-teal"></i> Please enter customer's zip Code</b>										
										</label>
									</section>
                                </div>
                                <!--rua e numero-->
									<div class="row">
                                    <section class="col col-6">
										<label class="input"> <i class="icon-append fa fa-pencil-square-o "></i>
											<input type="text" name="street" placeholder="Street" maxlength="200"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-pencil-square-o txt-color-teal"></i> Please enter customer's street</b>										
										</label>
									</section>	
									<section class="col col-6">
										<label class="input"> <i class="icon-append fa fa-pencil-square-o "></i>
											<input type="number" name="number"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-pencil-square-o txt-color-teal"></i> Please enter customer's number</b>										
										</label>
									</section>
									</div> 
                                <!--bairro e complemento-->
                                 <div class="row">
									<section class="col col-6">
										<label class="input"> <i class="icon-append fa fa-pencil-square-o "></i>
											<input type="text" name="neighborhood" placeholder="Neighborhood" maxlength="50"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-pencil-square-o txt-color-teal"></i> Please enter customer's neighborhood</b>										
										</label>
									</section>	
									<section class="col col-6 ">
										<label class="input"> <i class="icon-append fa fa-pencil-square-o "></i>
											<input type="text" name="complement" placeholder="Complement" maxlength="200"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-pencil-square-o txt-color-teal"></i> Please enter customer's complement</b>										
										</label>									
									</section>
								</div>
                                <!--estado e cidade-->
                                <div class="row">
									<section class="col col-6">
										<label class="select" id="select">
											<select name="state" id="state">
												<asp:Literal ID="selecionaestado" runat="server"></asp:Literal>
											</select> <i></i> </label>
									</section>
									<section class="col col-6">
										<label class="select">
											<select name="city" id="city" >
												
											</select> <i></i> </label>
									</section>
								</div>		
                                </fieldset>
                            <fieldset>
                                <legend>Login & Communication</legend>
                                <!--login e senha-->
								<div class="row">
									<section class="col col-6">
										<label class="input"> <i class="icon-append fa fa-user "></i>
											<input type="text" name="login" placeholder="Login" maxlength="50"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-user txt-color-teal"></i> Please enter login</b>										
										</label>
									</section>
                                    <section class="col col-6">                                        
                                    <label for="file" class="input input-file">			
                                       <asp:FileUpload ID="file" runat="server" Cssclass="form-control" />                                       
									</label>


                                   </section>
                                   </div>
                                <div class="row">
									<section class="col col-6">
										<label class="input"> <i class="icon-append fa fa-unlock-alt "></i>
											<input type="password" name="password" id="password" placeholder="Password"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-unlock-alt txt-color-teal"></i> Please enter password</b>										
										</label>
									</section>
                                    <section class="col col-6">
										<label class="input"> <i class="icon-append fa fa-unlock-alt "></i>
											<input type="password" name="confirmpassword" placeholder="Confirm Password"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-unlock-alt txt-color-teal"></i> Please enter confirm password</b>										
										</label>
									</section>
								</div>
								<div class="row">
									<section class="col col-5 criaemail">
										<label class="input"> <i class="icon-append fa fa-envelope-o "></i>
											<input type="email" name="email[]" required="required" title="Please enter your email" placeholder="Email"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-envelope-o txt-color-teal"></i> Please enter customer's default email</b>										
										                                       
                                        </label><br />
									</section>                                   
                                    <section class="col col-1">
                                         <button type="button" class="btn  btn-sm btn-success" onclick="add_email()">
                                        <span class="glyphicon glyphicon-plus"></span>
                                        </button>	
									</section> 
                                   <section class="col col-5 criaphone">
										<label class="input"> <i class="icon-append fa fa-phone "></i>
											<input type="tel" name="phone[]" required="required" title="Please enter your phone" data-mask="(99)9999-9999" placeholder="Phone" maxlength="15"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-phone txt-color-teal"></i> Please enter customer's default phone</b>										
										</label><br />
									</section>
                                    <section class="col col-1">
										<button type="button" class="btn  btn-sm btn-success" onclick="add_phone()">
                                        <span class="glyphicon glyphicon-plus"></span>
                                        </button>
                                    </section>									
								</div>
                           </fieldset>
                            <div class="btn-header transparent pull-right">                 
                                <asp:Button ID="Register" runat="server" Text="Register" CssClass="btn btn-lg btn-success" OnClick="Register_Click" /> 
                                               
                          </div>
                            <div class="btn-header transparent pull-right">                 
                                <input type="reset" class="btn btn-lg btn-danger"  id="cancel" value="Cancel"/>                    
                          </div>
                           				
						</form>
					</div>

				</div>
			</div>	       
            
        </div>
         <br /><br />
         </div>

    
         <div id="viewcustomer" style="display:none">

              <div class="jarviswidget" id="wid-id-4" data-widget-editbutton="false" data-widget-custombutton="false">
							
				<div>					
					
					<div class="widget-body no-padding">
						<div class="col-xs-offset-11 col-xs-1">              
                          <div class="btn-header transparent pull-right">                 
                                <button type="button" class="btn  btn-sm btn-warning" id="edit" onclick="FormCustomerEdit();">
                                        <span class="glyphicon glyphicon-pencil"></span>
                                </button>                  
                          </div>
                         </div>
						<form  id="orderform1" action="Customers.aspx" class="smart-form" novalidate="novalidate" method="post" style="display:none">
							<fieldset> 
                                <legend>Information & Address</legend>                               
                                <!--nome e empresa-->                                
                                <div id="FormItens"></div>							
								
                           </fieldset>
                            <div class="btn-header transparent pull-right">                 
                                <input type="submit" class="btn btn-lg btn-success" onclick="UpdateCustomer();" id="saveview" value="Save"/>                    
                          </div>
                            <div class="btn-header transparent pull-right">                 
                                <input type="reset" class="btn btn-lg btn-danger"  id="cancelview" value="Cancel"/>                    
                          </div>
                           				                         		
							
                        </form>
                        <div class="col col-xs-12" id="table1" style ="display:block">
                        <div id="teste"></div>
                    </div>

                    </div>
               </div>
               </div>
                   
         </div>
        <div id="deletecustomer" style="display:none">
						<h4> Are you sure want delete the customer?</h4>	
                        <div id="cliente"></div>
         </div>



	<script src="../Js/customer/edit.js"></script>

<script type="text/javascript">
    
   
</script>


</body>
</html>
