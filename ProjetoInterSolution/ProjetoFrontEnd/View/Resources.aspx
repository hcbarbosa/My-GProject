
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resources.aspx.cs" Inherits="ProjetoInter.View.Resources" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
   <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                  <!--botao new-->              
             <div class="col-xs-offset-11 col-xs-1">              
              <div class="btn-header transparent pull-right">                 
                    <input type="button" class="btn btn-success" id="new" value="New"/>                   
              </div>
             </div>
        <br /><br /><br />

       <div class="jarviswidget jarviswidget-color-green" id="wid-id-2" data-widget-editbutton="false">
								
				<header>
					<span class="widget-icon"> <i class="fa fa-table"></i> </span>
					<h2>Resources</h2>

				</header>
                <!--registros-->
				<div>
					<div class="jarviswidget-editbox">						
					</div>
					<div class="widget-body no-padding">
						<asp:Literal ID="ListResources" runat="server"></asp:Literal>									
					</div>
				</div>
			</div>

      

         <div id="registerresource">

              <div class="jarviswidget" id="wid-id-3" data-widget-editbutton="false" data-widget-custombutton="false">
							
				<div>					
					
					<div class="widget-body no-padding">
						
						<form runat="server" id="orderform" class="smart-form" novalidate="novalidate">
							<fieldset>  
                                <legend>Information</legend>                              
                                <!--descricao e tipo-->
                                <div class="row">                                    
                                        <section class="col col-6">             
                                            <label class="input"> Select type:	                                 
											<select  class="form-control" name="type" id="type" autofocus="autofocus" onchange="mostraQtd()"> 
                                                    <asp:Literal ID="tipos" runat="server"></asp:Literal>                                                    											        
										     </select> 
                                            </label>                                      
                                        </section>	
                                    	 <section class="col col-6"> 
                                             <label class="input"> Quantity (Before, choose a type):                                            
                                             <input type="time" class="form-control" required="required" title="Please enter number" name="hora" id="hora" style="display:none;" />                                             
											 <input type="text" class="form-control" required="required" title="Please enter number" name="unidade" id="unidade"  style="display:none;" /> 
                                             </label>                                 
                                        </section>					        
                                   
                                </div>
								<div class="row">
									<section class="col col-6">
										<label class="input"> Description:											
                                        <textarea class="form-control" rows="2" name="description" placeholder="Enter description"></textarea>
										</label>
								    </section>
                                    <section class="col col-6"> 
                                             <label class="input"> Value (R$):	
                                              <input type="text" name="value" id="value" maxlength="13" class="form-control" dir="rtl"/>                                         
											   </label>                                 
                                        </section>
								</div>
                               </fieldset>
                            <div class="btn-header transparent pull-right">          
                                <asp:Button ID="Register" runat="server" Text="Register" CssClass="btn btn-lg btn-success" OnClick="Register_Click" /> 
                                                 
                          </div>
                            <div class="btn-header transparent pull-right">                 
                                <input type="reset" class="btn btn-lg btn-danger"  id="cancel" value="Cancel" />                    
                          </div>                           		
                        </form>
                    </div>
               </div>
               </div>
                   
         </div>

         <div id="viewresource">

              <div class="jarviswidget" id="wid-id-4" data-widget-editbutton="false" data-widget-custombutton="false">
							
				<div>					
					
					<div class="widget-body no-padding">
						<div class="col-xs-offset-11 col-xs-1">              
                          <div class="btn-header transparent pull-right">                 
                                <button type="button" class="btn  btn-sm btn-warning" id="edit" onclick="FormResourceEdit();">
                                        <span class="glyphicon glyphicon-pencil"></span>
                                </button>                  
                          </div>
                         </div>
						<form  id="orderform1" method="post" action="Resources.aspx" class="smart-form" novalidate="novalidate" style="display:none">
							
							<fieldset>  
                                <legend>Information</legend>                              
                                <!--descricao e tipo-->
                                <div id="FormItens"></div>
                               </fieldset>
                            <div class="btn-header transparent pull-right">                 
                                 <input type="submit" id="saveview" onclick="UpdateResource();" value="Save" class="btn btn-lg btn-success"  /> 
                                                    
                          </div>
                            <div class="btn-header transparent pull-right">                 
                                <input type="reset" class="btn btn-lg btn-danger" id="cancelview" value="Cancel" />                    
                          </div>                           		
                        </form>
                        <div class="col col-xs-12" id="table1" style ="display:block">
                        <div id="teste"></div>
                    </div>

                    </div>
               </div>
               </div>
                   
         </div>
        <div id="deleteresource">
						<h4> Are you sure you want to delete the resource?</h4>	
                        <div id="recurso"></div>
         </div>



       <br /><br />

       <script src="../Js/resource/edit.js"></script>
       
       <script src="../Js/MaskMoney.js"></script>

<script type="text/javascript">
    
</script>

         </div>      
</body>
</html>
