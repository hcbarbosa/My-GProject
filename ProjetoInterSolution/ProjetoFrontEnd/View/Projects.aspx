<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="ProjetoInter.View.Projects" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            
              <!--botao new-->              
             <asp:Literal ID="botaonew" runat="server"></asp:Literal>

             <br /><br />
             <div class="jarviswidget jarviswidget-color-green" id="wid-id-2" data-widget-editbutton="false">
								
				<header>
					<span class="widget-icon"> <i class="fa fa-table"></i> </span>
					<h2>Projects</h2>

				</header>
                <!--registros-->
				<div>
					<div class="jarviswidget-editbox">						
					</div>
					<div class="widget-body no-padding">
						<asp:Literal ID="ListProjects" runat="server"></asp:Literal>									
					</div>
                                        
				</div>
			</div>
         
                     <br /><br /> 

        </div>
        <br /><br /><br />

         <div id="registerproject" style="display:none">
            			
            <div class="jarviswidget jarviswidget-color-darken" id="wid-id-0" data-widget-editbutton="false" data-widget-deletebutton="false">
				
				<div>
					<div class="widget-body ">
						<div class="row">
							<form id="wizard1" novalidate="novalidate" runat="server" >
								<div id="bootstrap-wizard1" class="col-xs-12">
									<div class="form-bootstrapWizard">
										<ul class="bootstrapWizard form-wizard">
											<li class="active" data-target="#step1">
												<a href="#tab1" data-toggle="tab"> <span class="step">1</span> <span class="title">Basic information & Participants</span> </a>
											</li>
											<li data-target="#step2">
												<a href="#tab2" data-toggle="tab"> <span class="step">2</span> <span class="title">Steps</span> </a>
											</li>
											<li data-target="#step3">
												<a href="#tab3" data-toggle="tab"> <span class="step">3</span> <span class="title">Activities</span> </a>
											</li>
											<li data-target="#step4">
												<a href="#tab4" data-toggle="tab"> <span class="step">4</span> <span class="title">Confirm</span> </a>
											</li>
										</ul>
										<div class="clearfix"></div>
									</div>
									<div class="tab-content">
										<div class="tab-pane active" id="tab1">
											<br/>
											<h3>Basic Information & Participants</h3>

											<div class="row">

												<div class="col-xs-12">
													<div class="form-group">
														<div class="input-group">
															<span class="input-group-addon"><i class="fa fa-folder-o fa-sm fa-fw"></i></span>
															<input class="form-control input-sm" placeholder="Enter with project's name" type="text" name="name" id="name"/>

														</div>
													</div>

												</div>

											</div>

											<div class="row">
												<div class="col-xs-3">
													<div class="form-group">						                                                           
									
											            <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
												           <input type="date" class="form-control" name="startdate"  id="startdate"/>
                                                                        
                                                        </div>
													</div>
												</div>
												<div class="col-xs-3">
													<div class="form-group">
														 <div class="input-group">
                                                             <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
												           <input type="date" class="form-control" name="finishdate" id="finishdate" />                                                        
                                                       
													</div> </div> <div id="divfinishdatep" style="color:red"></div>
												</div>										
                                            
												<div class="col-xs-3">
													<div class="form-group">
														<div class="input-group">
															<span class="input-group-addon"><i class="fa fa-dollar fa-sm fa-fw"></i></span>
															<input class="form-control input-sm" type="text"  placeholder="Enter total cost" name="valuetotal" id="valuetotal"/>

														</div>
													</div>
												</div>
												<div class="col-xs-3">
													<div class="form-group">
														<div class="input-group">
															<span class="input-group-addon"><i class="fa fa-book fa-sm fa-fw"></i></span>
															<select style="width:100%" class="form-control input-sm" id="model" name="model">
                                                                						        
										                    </select> 
														</div>
													</div>
												</div>
											
                                             
										</div>
                                            <div class="row">

												<div class="col-xs-6">
                                                    <div class="form-group">
													<div class="input-group" id="select">
															<span class="input-group-addon"><i class="fa fa-building fa-sm fa-fw"></i></span>															
                                                            <select style="width:100%" class="form-control input-sm" id="company" name="company">                                                               											        											        
										                    </select> 
														</div>
                                                        </div>
												</div>
                                               
                                                <div class="col-xs-6">
                                                    <div class="form-group">
													<div class="input-group">
															<span class="input-group-addon"><i class="fa fa-users fa-sm fa-fw"></i></span>
															<select style="width:100%;" multiple="multiple"  class="select2" id="customers" required="required" title="Please enter customers" name="customers[]"  >     
                                                                                                                                                                                         		
										                    </select> 
                                                                          
														</div>
                                                    </div>
												</div>

											</div>
                                            <br />
										
										</div>
										<div class="tab-pane" id="tab2">
													<br/>
											<h3>Steps</h3>
                                            <input type="button" class="btn btn-success" id="newstep" value="New" style="float:right;z-index:500"/> 
                                            <input type="text" id="reqsteps" style="width:1px;height:1px;visibility:hidden;" required="required" title=" "/>
                                                                                      
                                            <div class="row">
                                                    <div class="col col-xs-4">
                                                        <div class="select select-multiple" >
                                                            <!-- tabela de fases-->
                                                             <table class="table table-hover" style="width:100%;"  id="steps">
                                                                                                                                
                                                            </table> 								                      
                                                            				        
                                                         </div>		                                                 
                                                   </div>
                                               
                                            <div id="formnewstep" style="float:left;width:50%;display:none;">
                                                <div > 
                                                <h4>New Step</h4>
                                                    <section>
                                                        <label>Name:</label><br />
                                                        <input type="text" name="stepname" id="stepname" required="required" title="Please enter Step's name" style="width:100%"/><br />
                                                        <div id="divnamestep" style="color:red"></div>
                                                    </section>
                                                    <section>
                                                        <label>Description:</label><br />
                                                        <textarea name="stepdescription" id="stepdescription" required="required" title="Please enter Step'sdescription" style="width:100%"/><br />
                                                        <div id="divdescstep" style="color:red"></div>
                                                    </section>
                                                    <section>
                                                        <div style="float:left">
                                                        <label>Start Date:</label><br />
                                                        <input type="date"  name="stepstartdate" id="stepstartdate" style="height:25px;" required="required" title="Please enter Step's Start Date"/> 
                                                        <div id="divstartstep" style="color:red"></div>
                                                        </div>
                                                        <div style="float:right">
                                                        <label>Expiry Date:</label><br />
                                                        <input type="date"  name="stepfinishdate" id="stepfinishdate" style="height:25px;" required="required" title="Please enter Step's Expiry Date" />
                                                        <div id="divfinishstep" style="color:red"></div>
                                                        </div>  <br />
                                                    </section>
                                                    <section>
                                                    <br /><br /><br />
                                                     <input type="button" class="btn btn-success" id="okstep" value="Ok" style="float:right"/> 
                                                     <input type="button" class="btn btn-danger" id="cancelstep" value="Cancel" style="float:right"/>   
                                                    </section>
                                                </div>     
                                                    </div>
                                               
                                            </div>
											
										</div>
										<div class="tab-pane" id="tab3">
											<br/>
											<h3>Activities</h3>
                                            <input type="button" class="btn btn-success" id="newactiv" value="New" style="float:right;z-index:500;display:none;"/>                   
                                             <input type="text" id="reqact" style="width:1px;height:1px;visibility:hidden;" required="required" title=" "/>
                                                    
                                            <div class="row">
                                                    <div class="col col-xs-4">
                                                        <div class="widget-body">

						                                        <div class="tree smart-form">
							                                        <ul>
								                                        <li>
									                                        <span><i class="fa fa-lg fa-folder-open"></i> <div id="pjname"></div></span>
									                                        <ul id="treesteps">
										                                        
                                                                         </ul>
                                                                       </li>
                                                                     </ul>                                                                           	                                                 
                                                                </div>
                                                              </div>
                                                  </div>
                                               <div id="divcriafase" style="color:red"></div>
                                            <div id="formnewactiv" style="float:left;width:50%;display:none;">
                                                    <h4>New Activity</h4>
                                                        <section>
                                                        <label>Step:</label><br />
                                                        <select name="curActivity" id="curActivity" style="width:100%;">
                                                            <option selected="selected" value="0" disabled="disabled">Choose the Step</option>
                                                        </select>
                                                             <div id="divfaseescolhida" style="color:red"></div>                                                         
                                                    </section>
                                                    <section>
                                                        <label>Name:</label><br />
                                                        <input type="text" name="actname" id="actname"style="width:100%"/><br />
                                                        <div id="divnameact" style="color:red"></div>
                                                    </section>
                                                    <section>
                                                        <label>Description:</label><br />
                                                        <textarea name="actdescription" id="actdescription" style="width:100%"/><br />
                                                        <div id="divdescact" style="color:red"></div>
                                                    </section>
                                                    <section>
                                                        <div style="float:left">
                                                        <label>Start Date:</label><br />
                                                        <input type="date"  style="height:25px;" name="actstart" id="actstart" /> 
                                                        <div id="divstartact" style="color:red"></div>
                                                        </div>
                                                        <div style="float:right">                                                            
                                                        <label>Expiry Date:</label><br />
                                                        <input type="date"   style="height:25px;" name="actfinish" id="actfinish"/>
                                                        <div id="divfinishact" style="color:red"></div>
                                                        </div><br /><br /><br /><br />
                                                    </section>
                                                        <div style="float:left">
                                                        <label>Hours:</label><br />
                                                        <input type="number" name="qtdhours" id="qtdhours" min="0" style="width:80%"/><div id="divhouract" style="color:red"></div>
                                                        <br /><br /><br />                                                        
                                                        </div><br />

                                                     <input type="button" class="btn btn-success" id="okactiv" value="Ok" style="float:right"/> 
                                                     <input type="button" class="btn btn-danger" id="cancelactiv" value="Cancel" style="float:right"/>                                                 
                                                    </div>
                                               
                                            </div>
                                            <div id="divActivities"></div>
                                        </div>

										<div class="tab-pane" id="tab4">
											<br/>
											<h3>Confirm</h3>                                            
                                            <div class="row"> 
                                                <div class="col col-xs-8" style="float:left">                                             
                                                   <table class="table table-hover" style="align-items:center">
                                                      <!--registros-->								
                                                             <tr>                                                                
									                            <td><b>Project</b></td>
                                                                <td colspan="3"><label id="nameconfirm"></label></td> 
                                                            </tr>
                                                            <tr>
                                                                <td><b>Start Date</b></td>
                                                                <td><label id="startconfirm"></label></td>                                                                 
                                                                <td><b>Expiry Date</b></td>
                                                                <td><label id="finishconfirm"></label></td>
                                                            </tr>
                                                            <tr>
                                                                <td><b>Total Cost:</b></td>
                                                                <td><label id="valueconfirm"></label></td>                                                            
                                                                <td><b>Model</b></td>
                                                                <td><label  id="modelconfirm"></label></td> 
                                                            </tr>
                                                            <tr>
                                                                <td><b>Company</b></td>
                                                                <td colspan="3"><label id="companyconfirm"></label></td>  
                                                            </tr>
                                                            <tr>                                                              
                                                                <td><b>Customers</b></td>
                                                                <td colspan="3"><label id="customerconfirm"></label></td>
                                                            </tr>                                                     
                                                   </table>
                                                    </div>
                                                    <div class="col-xs-4" style="float:right" >
                                                        <div class="widget-body">

						                                        <div class="tree smart-form">
							                                        <ul>
								                                        <li>
									                                        <span><i class="fa fa-lg fa-folder-open"></i> <div id="pjnameconfirm"></div></span>
									                                        <ul id="treestepsconfirm">
										                                        
                                                                         </ul>
                                                                       </li>
                                                                     </ul>                                                                           	                                                 
                                                                </div>
                                                              </div>
                                                    </div>                                                                                                  
                                                     
                                            </div> 
                                            <div style="margin-left:42%">
                                                        <br />
                                                        <asp:Button ID="confirm" runat="server"  Cssclass="btn btn-success" Text="Confirm the project" OnClick="confirm_Click" Enabled="False" />
                                                   <br />
                                                   <div id="divconfirm" style="color:red">                                                       
                                                   </div>
                                                 </div> 
										</div>

										<div class="form-actions">
											<div class="row">
												<div class="col-xs-12">
													<ul class="pager wizard no-margin">
														<!--<li class="previous first disabled">
														<a href="javascript:void(0);" class="btn btn-lg btn-default"> First </a>
														</li>-->
														<li class="previous disabled">
															<a href="javascript:void(0);" class="btn btn-default txt-color-green"> Previous </a>
														</li>
														<!--<li class="next last">
														<a href="javascript:void(0);" class="btn btn-lg btn-primary"> Last </a>
														</li>-->
														<li class="next">
															<a href="javascript:void(0);" class="btn txt-color-green"> Next </a>
														</li>
													</ul>
												</div>
											</div>
										</div>

									</div>
								</div>
							</form>
						</div>

					</div>
					<!-- end widget content -->

				</div>
				<!-- end widget div -->

			</div>
			<!-- end widget -->		
                    </div>   
    
     <div id="deleteproject" style="display:none">
						<h4> Are you sure you want to cancel the project?</h4>	
                        <div id="nomeprojetodelete"></div>
         </div>                 
     <div id="ativarproject" style="display:none">
						<h4> Are you sure want reactivate the project?</h4>	
                        <div id="nomeprojetoativar"></div>
         </div>   
     <div id="viewmodel" style="display:none"> 
      </div>   
    
    <br /><br /> 
 <script type="text/javascript">

     pageSetUp();
     var pagefunction = function () {

         loadScript("../Js/plugin/bootstraptree/bootstrap-tree.min.js");
     };

     // run pagefunction on load

     pagefunction();

</script>
        <script src="../Js/MaskMoney.js"></script>
       <script src="../Js/project/edit.js"></script>

</body>
</html>
