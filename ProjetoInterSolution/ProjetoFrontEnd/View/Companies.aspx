<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Companies.aspx.cs" Inherits="ProjetoInter.View.Companies" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body runat="server">
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
         <div class="col-xs-11 col-sm-11 col-md-11 col-lg-11">
         <table style="background:#d7d2d2" >
             <tr>
                 <td> <a href="Index.aspx#Companies.aspx?letra=All" class="btn btn-default ">All</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=A" class="btn btn-default ">A</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=B" class="btn btn-default ">B</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=C" class="btn btn-default ">C</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=D" class="btn btn-default ">D</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=E" class="btn btn-default ">E</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=F" class="btn btn-default ">F</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=G" class="btn btn-default ">G</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=H" class="btn btn-default ">H</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=I" class="btn btn-default ">I</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=J" class="btn btn-default ">J</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=K" class="btn btn-default ">K</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=L" class="btn btn-default ">L</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=M" class="btn btn-default ">M</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=N" class="btn btn-default ">N</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=O" class="btn btn-default ">O</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=P" class="btn btn-default ">P</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=Q" class="btn btn-default ">Q</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=R" class="btn btn-default ">R</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=S" class="btn btn-default ">S</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=T" class="btn btn-default ">T</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=U" class="btn btn-default ">U</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=V" class="btn btn-default ">V</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=W" class="btn btn-default ">W</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=X" class="btn btn-default ">X</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=Y" class="btn btn-default ">Y</a></td>
                 <td> <a href="Index.aspx#Companies.aspx?letra=Z" class="btn btn-default ">Z</a></td>
             </tr>    
         </table>
             </div>

         <!--botao new-->              
                          
              <div class="btn-header transparent pull-right">                 
                    <input type="button" class="btn btn-success" id="new" value="New"/>                    
              </div>
        <br /><br /><br />


<!-- row -->
<div class="row">

	<!-- SuperBox -->
	<div class="superbox col-xs-12">
		<asp:literal ID="listcompanies"  runat="server" ></asp:literal>		
	</div>
	<!-- /SuperBox -->
	<input type="hidden" id="Company" value="" />
	<div class="superbox-show">
        
	</div>
</div>

	<!-- end row -->

         <!-- div q contem a pagina de registrar cliente -->
     <div id="registercompany">
     
         
   
			<div class="jarviswidget" id="wid-id-3" data-widget-editbutton="false" data-widget-custombutton="false">
				
				
				<div>			
					<div class="widget-body no-padding">						
						<form  id="orderform" runat="server" class="smart-form">
							
							<fieldset>
                                <legend>Information & Address</legend>
								<div class="row">
									<section class="col col-6">
                            			<label class="input"> <i class="icon-append fa fa-building"></i>
											<input type="text" name="name" placeholder="Name" maxlength="50"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-building txt-color-teal"></i> Please enter company's name</b>
										</label>
									</section>
                                    <section class="col col-6">                                        
                                   <label for="file" class="input input-file">			
                                       <asp:FileUpload ID="file" runat="server" Cssclass="form-control"/>							
                                        
									</label>
                                   </section>
									
								</div>
                                <div class="row">
                                    <section class="col col-6">
                            			<label class="input"> <i class="icon-append fa fa-info"></i>
											<input type="text" name="cnpj" data-mask="99.999.999/9999-99" placeholder="CNPJ" maxlength="18"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-info txt-color-teal"></i> Please enter company's cnpj</b>
										</label>
									</section>
                                    <section class="col col-6">
										<label class="input"> <i class="icon-append fa fa-group"></i>
											<input type="text" name="area" placeholder="Business area" maxlength="50"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-group txt-color-teal"></i> Please enter business area</b>
										</label>
                                    </section>
                                </div>
							
								<div class="row">
									<section class="col col-6">
										<label class="input"> <i class="icon-append fa fa-pencil-square-o "></i>
											<input type="text" name="zip" placeholder="Zip Code" data-mask="99999-999" maxlength="15"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-pencil-square-o txt-color-teal"></i> Please enter company's zip Code</b>										
										</label>
									</section>
									<section class="col col-6">
										<label class="input"> <i class="icon-append fa fa-pencil-square-o "></i>
											<input type="text" name="street" placeholder="Street" maxlength="200"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-pencil-square-o txt-color-teal"></i> Please enter company's street</b>										
										</label>
									</section>
								</div>

								<div class="row">
									<section class="col col-6">
										<label class="input"> <i class="icon-append fa fa-pencil-square-o "></i>
											<input type="number" name="number"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-pencil-square-o txt-color-teal"></i> Please enter company's number</b>										
										</label>
									</section>
									<section class="col col-6">
										<label class="input"> <i class="icon-append fa fa-pencil-square-o "></i>
											<input type="text" name="neighborhood" placeholder="Neighborhood" maxlength="50"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-pencil-square-o txt-color-teal"></i> Please enter company's neighborhood</b>										
										</label>
									</section>
								</div>

                                <div class="row">
									<section class="col col-xs-12 ">
										<label class="input"> <i class="icon-append fa fa-pencil-square-o "></i>
											<input type="text" name="complement" placeholder="Complement" maxlength="200"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-pencil-square-o txt-color-teal"></i> Please enter company's complement</b>										
										</label>									
									</section>
								</div>

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
                                <legend>Communication</legend>
                            
								<div class="row">
									<section class="col col-5 criaemail">
										<label class="input"> <i class="icon-append fa fa-envelope-o "></i>
											<input type="email" name="email[]" required="required" title="Please enter your email" placeholder="Email"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-envelope-o txt-color-teal"></i> Please enter company's default email</b>										
										                                       
                                        </label>
                                        <br />
									</section>                                   
                                    <section class="col col-1">
                                         <button type="button" class="btn  btn-sm btn-success" onclick="add_email()">
                                        <span class="glyphicon glyphicon-plus"></span>
                                        </button>	
									</section> 
                                   <section class="col col-5 criaphone">
										<label class="input"> <i class="icon-append fa fa-phone "></i>
											<input type="tel" name="phone[]" required="required" title="Please enter your phone" data-mask="(99)9999-9999" placeholder="Phone" maxlength="15"/>
                                            <b class="tooltip tooltip-top-right"><i class="fa fa-phone txt-color-teal"></i> Please enter company's default phone</b>										
										</label>
                                       <br />
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
             
        <div id="viewcompany">

              <div class="jarviswidget" id="wid-id-4" data-widget-editbutton="false" data-widget-custombutton="false">
							
				<div>					
					
					<div class="widget-body no-padding">
						<div class="col-xs-offset-11 col-xs-1">              
                          <div class="btn-header transparent pull-right">                 
                                <button type="button" class="btn  btn-sm btn-warning" id="edit" onclick="FormCompanyEdit();">
                                        <span class="glyphicon glyphicon-pencil"></span>
                                </button>                  
                          </div>
                         </div>
						<form  id="orderform1" action="Companies.aspx" enctype="multipart/form-data" class ="smart-form" novalidate="novalidate" method="post" style="display:none">
							<fieldset> 
                                <legend>Information & Address</legend>     
                                <div id="FormItens"></div>							
								
                           </fieldset>
                            <div class="btn-header transparent pull-right">                 
                                <input type="submit" class="btn btn-lg btn-success"  onclick="UpdateCompany();" id="saveview" value="Save"/>                    
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

		<div id="deletecompany">
						<h4> Are you sure want delete the company?</h4>	
                        <div id="empresa"></div>
         </div>

<script type="text/javascript">
    
 
</script>
    
       <script src="../Js/company/edit.js"></script>
        
       <script src="../Js/FileUp/AjaxUpload.js"></script>
         </div>      
</body>
</html>
