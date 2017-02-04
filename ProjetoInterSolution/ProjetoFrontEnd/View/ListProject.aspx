<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListProject.aspx.cs" Inherits="ProjetoInter.View.ListProject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #imgcomment {
            width: 60px;
            height: auto;
            display: inline-block;
            vertical-align: middle;
            margin-top: 1px;
            margin-right: 5px;
            margin-left: 0;
            border-left: 3px solid #fff;
        }
        #atrasada
        {
            color:red;
        }
        #completada {
            color:green;
        }
        
    </style>
</head>
<body>
     <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
         <div class="well well-sm well-light">
			
			<div id="tabs">		
						<ul>
							<asp:Literal ID="permissoes" runat="server"></asp:Literal>							
						</ul>					
							<!--information-->
                            <div id="inform">
                               <asp:Literal ID="info" runat="server"></asp:Literal>
                                <div id="editproject">
                                    <form id="formedit" runat="server">
												<div class="col-xs-12">
													<div class="form-group">
														<div class="input-group">
															<span class="input-group-addon"><i class="fa fa-folder-o fa-sm fa-fw"></i></span>
															<input class="form-control input-sm" placeholder="Enter with project's name" type="text" name="name" id="name"/>
														</div>
													</div>
												</div>

												<div class="col-xs-3">
													<div class="form-group">	  
											            <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
												           <input type="date" class="form-control" name="startdate" value=""  id="startdate"/>
                                                                        
                                                        </div>
													</div>
												</div>
												<div class="col-xs-3">
													<div class="form-group">
														 <div class="input-group">
                                                             <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
												           <input type="date" class="form-control" name="finishdate" value="" id="finishdate" />
													    </div>
													</div> <div id="divfinishdatep" style="color:red"></div>
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
                                                   <div style="color:white"><</div> 												<div class="col-xs-6" style="float:left">
                                                    <div class="form-group">
													<div class="input-group" id="select">
															<span class="input-group-addon"><i class="fa fa-building fa-sm fa-fw"></i></span>															
                                                            <select style="width:100%" class="form-control input-sm" id="company" name="company">                                                               											        											        
										                    </select> 
														</div>
                                                        </div>
												</div>
                                               
                                                 <div class="col-xs-offset-6">
                                                    <div class="form-group">
													<div class="input-group">
															<span class="input-group-addon"><i class="fa fa-users fa-sm fa-fw"></i></span>
															<select style="width:100%;" multiple="multiple"  class="select2" id="customers" required="required" title="Please enter customers" name="customers[]"  > 
										                    </select>                                                                           
														</div>
                                                    </div>
												</div>
                            <div><div class="btn-header transparent pull-right">                 
                                 <asp:Button ID="save" Text="Save" runat="server" OnClick="save_Click" Cssclass="btn btn-lg btn-success"  /> 
                                                    
                          </div>
                            <div class="btn-header transparent pull-right">                 
                                <input type="button" class="btn btn-lg btn-danger" id="cancel" value="Cancel" />                    
                          </div>  
                                </div>
                                        </form>									
                                </div>

                                <!--modal modelo-->
                                <div id="registermodel">
                                    <form id="regmodel">
                                    
												<div class="col-xs-12">
													<div class="form-group">
														<div class="input-group">
															<span class="input-group-addon"><i class="fa fa-book fa-sm fa-fw"></i></span>
															<input class="form-control input-sm" placeholder="Enter with model's name" type="text" required="required" title="Please enter name" name="namemodel" id="namemodel"/>
														   </div>
                                                         <div id="divnamemodel" style="color:red"></div>
													</div>
												</div>
											

												<div class="col-xs-12">
													<div class="form-group">	  
											            <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-pencil"></i></span>
												           <textarea class="form-control" placeholder="Enter description" name="descmodel" required="required" title="Please enter description" id="descmodel"></textarea>                                                                        
                                                        </div>
                                                        <div id="divdescmodel" style="color:red"></div>
													</div>
												</div>
												                                        
										</form>                                         
                                    </div>
                                <div id="editmodel" style="display:none">
                                    <form id="editmodelform">
                                   
												<div class="col-xs-12">
													<div class="form-group">
														<div class="input-group">
															<span class="input-group-addon"><i class="fa fa-book fa-sm fa-fw"></i></span>
															<input class="form-control input-sm" placeholder="Enter with model's name" type="text" required="required" title="Please enter name" name="editnamemodel" id="editnamemodel"/>
														   </div>
                                                         <div id="diveditnamemodel" style="color:red"></div>
													</div>
												</div>
											
												<div class="col-xs-12">
													<div class="form-group">	  
											            <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-pencil"></i></span>
												           <textarea class="form-control" placeholder="Enter description" required="required" title="Please enter description" name="editdescmodel" id="editdescmodel"></textarea>                                                                        
                                                             </div>
                                                        <div id="diveditdescmodel" style="color:red"></div>                                                       
													</div>
												</div>
												                                       
										</form>                                         
                                    </div>
                                         <div id="deletemodel" style="display:none">
                                             <h4> Are you sure want delete the model?</h4>	                        
                                             </div> 
                                        <div id="viewmodel" style="display:none"> 
                                             </div>      
							</div>
                            <!--comentarios-->
                             <div id="area">                                 

                                 	<!-- new widget -->
			<div class="jarviswidget jarviswidget-color-blueDark" id="wid-id-1" data-widget-editbutton="false" data-widget-fullscreenbutton="false">
                
				<header>
					<span class="widget-icon"> <i class="fa fa-comments txt-color-white"></i> </span>
					<h2> Comments </h2>
					<div class="widget-toolbar">
						<!-- add: non-hidden - to disable auto hide -->

					</div>
				</header>

				<!-- widget div-->
				<div>
					<!-- widget edit box -->
					<div class="jarviswidget-editbox">
						<div>
							<label>Title:</label>
							<input type="text" />
						</div>
					</div>
					<!-- end widget edit box -->
					<div class="widget-body widget-hide-overflow no-padding">
						<!-- content goes here -->					
						<!-- CHAT BODY -->
						<div id="chat-body" class="chat-body custom-scroll">
							<ul id="listcomentarios">
								<asp:Literal ID="comentarios" runat="server"></asp:Literal>
							</ul>
						</div>

						<!-- CHAT FOOTER -->
						<div class="chat-footer">
							<!-- CHAT TEXTAREA -->
							<div class="textarea-div">
								<div class="typearea">
									<textarea placeholder="Write here..." id="comentarioescrito" class="custom-scroll"></textarea>
								</div>
							</div>
							<!-- CHAT SEND -->
							<span class="textarea-controls">
								<asp:Literal ID="btncomment" runat="server"></asp:Literal>
							</span>
						</div>
						<!-- end content -->
					</div>
				</div>
				<!-- end widget div -->
			</div>
			<!-- end widget -->
                             </div>
                            <!--steps-->
                            <div id="steps">								
                                
                                <asp:Literal ID="listfases" runat="server"></asp:Literal>                                                              
								
                                 <div id="editstep" style="display:none">   
                                         <button type='button' class='btn  btn-sm btn-warning pull-right' id="botaoeditstep">
                                                    <span class='glyphicon glyphicon-pencil'></span>
                                        </button>
                                    <form id="formeditstep">                                   
												<div class="col-xs-12">
													<div class="form-group">Name:
														<div class="input-group">                                                            
															<span class="input-group-addon"><i class="fa fa-pencil fa-sm fa-fw"></i></span>
															<input class="form-control input-sm" placeholder="Enter step's name" type="text" required="required" title="Please enter name" name="editnamestep" id="editnamestep" disabled="disabled"/>
														   </div>
                                                         <div id="diveditnamestep" style="color:red"></div>
													</div>
												</div>
											
												<div class="col-xs-12">
													<div class="form-group">Description: 	  
											            <div class="input-group">                                                           
                                                            <span class="input-group-addon"><i class="fa fa-pencil"></i></span>
												           <textarea class="form-control" placeholder="Enter description" required="required" title="Please enter description" name="editdescstep" id="editdescstep" disabled="disabled"></textarea>                                                                        
                                                             </div>
                                                        <div id="diveditdescstep" style="color:red"></div>                                                       
													</div>
												</div>

                                                <div class="col-xs-5">
													<div class="form-group"> Start Date:	  
											            <div class="input-group">                                                           
                                                            <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
												             <input type="date"  name="editstartstep" id="editstartstep" style="height:30px;" title="Please enter Step's Start Date" disabled="disabled"/> 
                                                         </div>
                                                        <div id="diveditstartstep" style="color:red"></div>                                             
													</div>
												</div>

                                                <div class="col-xs-5">
													<div class="form-group">	Finish Date:  
											            <div class="input-group">                                                            
                                                            <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
												             <input type="date"  name="editfinishstep" id="editfinishstep" style="height:30px;" title="Please enter Step's Start Date" disabled="disabled"/> 
                                                         </div>
                                                        <div id="diveditfinishstep" style="color:red"></div>                                             
													</div>
												</div>
												<div id="btneditstep" class="col-xs-12" style="display:none">
                                                    <div class="btn-header transparent pull-right">                 
                                                     <input type="button" class="btn btn-sm btn-success" id="saveeditstep" onclick="EditYesStep()" value="Save" />  
                                                    </div>
                                                    <div class="btn-header transparent pull-right">                 
                                                        <input type="button" class="btn btn-sm btn-danger" id="canceleditstep" value="Cancel" />                    
                                                    </div>  
                                               </div>                                       
										</form>                                         
                                    </div>

                                <div id="newstep" style="display:none">                                          
                                    <form id="formnewstep" style="display:none">                                   
												<div class="col-xs-12">
                                                    <font color="red">Is necessary to have an activity in the step to complete the registration</font>
													<div class="form-group">Name:
														<div class="input-group">                                                            
															<span class="input-group-addon"><i class="fa fa-pencil fa-sm fa-fw"></i></span>
															<input class="form-control input-sm" placeholder="Enter step's name" type="text" title="Please enter name" name="namestep" id="namestep"/>
														   </div>
                                                         <div id="divnamestep" style="color:red"></div>
													</div>
												</div>
											
												<div class="col-xs-12">
													<div class="form-group">Description: 	  
											            <div class="input-group">                                                           
                                                            <span class="input-group-addon"><i class="fa fa-pencil"></i></span>
												           <textarea class="form-control" placeholder="Enter description" title="Please enter description" name="descstep" id="descstep"></textarea>                                                                        
                                                             </div>
                                                        <div id="divdescstep" style="color:red"></div>                                                       
													</div>
												</div>

                                                <div class="col-xs-5">
													<div class="form-group"> Start Date:	  
											            <div class="input-group">                                                           
                                                            <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
												             <input type="date"  name="startstep" id="startstep" style="height:30px;" title="Please enter Step's Start Date"/> 
                                                         </div>
                                                        <div id="divstartstep" style="color:red"></div>                                             
													</div>
												</div>

                                                <div class="col-xs-5">
													<div class="form-group">	Finish Date:  
											            <div class="input-group">                                                            
                                                            <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
												             <input type="date"  name="finishstep" id="finishstep" style="height:30px;" title="Please enter Step's Expiry Date" /> 
                                                         </div>
                                                        <div id="divfinishstep" style="color:red"></div>                                             
													</div>
												</div>
                                                                                      
										</form>   
                                        <form id="formnewatstep" style="display:none">  
                                            <input type="hidden" id="numerofase" />                                 
												<div class="col-xs-12">
													<div class="form-group">Activity's Name :
														<div class="input-group">                                                            
															<span class="input-group-addon"><i class="fa fa-pencil fa-sm fa-fw"></i></span>
															<input class="form-control input-sm" placeholder="Enter name" type="text" title="Please enter name" name="nameat" id="nameat"/>
														   </div>
                                                         <div id="divnameat" style="color:red"></div>
													</div>
												</div>
											
												<div class="col-xs-12">
													<div class="form-group">Activity's Description: 	  
											            <div class="input-group">                                                           
                                                            <span class="input-group-addon"><i class="fa fa-pencil"></i></span>
												           <textarea class="form-control" placeholder="Enter description" title="Please enter description" name="descat" id="descat" ></textarea>                                                                        
                                                             </div>
                                                        <div id="divdescat" style="color:red"></div>                                                       
													</div>
												</div>

                                                <div class="col-xs-5">
													<div class="form-group">Activity's Start Date:	  
											            <div class="input-group">                                                           
                                                            <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
												             <input type="date"  name="startat" id="startat" style="height:30px;" title="Please enter Start Date"/> 
                                                         </div>
                                                        <div id="divstartat" style="color:red"></div>                                             
													</div>
												</div>

                                                <div class="col-xs-5">
													<div class="form-group">Activity's Finish Date:  
											            <div class="input-group">                                                            
                                                            <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
												             <input type="date"  name="finishat" id="finishat" style="height:30px;" title="Please enter Expiry Date"/> 
                                                         </div>
                                                        <div id="divfinishat" style="color:red"></div>                                             
													</div>
												</div>

                                                <div class="col-xs-5">
													<div class="form-group">Activity's Hours:  
											            <div class="input-group">                                                            
                                                            <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
												             <input type="number" min="1"  name="hourat" id="hourat" style="height:30px;" title="Please enter hours"/> 
                                                         </div>
                                                        <div id="divhourat" style="color:red"></div>                                             
													</div>
												</div>
                                                                                      
										</form> 
                                        <div id="btnnextstep" class="col-xs-12" style="display:block">
                                                    <div class="btn-header transparent pull-right">                 
                                                     <input type="button" class="btn btn-sm btn-success"  onclick="NewStep()" value="Next" />  
                                                    </div>
                                                    </div>
												<div id="btnconfirmstep" class="col-xs-12" style="display:none">
                                                    <div class="btn-header transparent pull-right">                 
                                                     <input type="button" class="btn btn-sm btn-success"  onclick="SaveStep()" value="Save" />  
                                                    </div>
                                                    <div class="btn-header transparent pull-right">                 
                                                        <input type="button" class="btn btn-sm btn-danger" onclick="CancelStep()" value="Cancel" />                    
                                                    </div>  
                                               </div>                                       
                                    </div>

							</div>
                             <!--dependencies-->
                            <div id="dependecie">

                                <asp:Literal ID="listdependencias" runat="server"></asp:Literal>

                                <div id="editdependencia" style="display:none">
                                   
                                                <div class="col-xs-12">
													
                                                        <div class="form-group">Choose the dependencie:
														<select id="selecionadependencia" class="select2"> 
                                                            <asp:Literal ID="listselecionadependencia" runat="server"></asp:Literal>
                                                        </select>
                                                    </div>
                                                           
														
                                                            
                                                    </div>
												
                                    <div class="col-xs-12">
													<div class="form-group">Choose the type:
														<select id="Select1" class="select2"> 
                                                           <option value="0">Finish-to-start</option>
                                                           <option value="1">Start-to-start</option>
                                                           <option value="2">Finish-to-finish</option>
                                                                
                                                        </select>
                                                    </div>
												</div>
                                                <div class="btn-header transparent pull-right">                 
                                                     <input type="button" class="btn btn-sm btn-success"  onclick="SaveDep();" value="Save" />  
                                                    </div>
                                                    <div class="btn-header transparent pull-right">                 
                                                        <input type="button" class="btn btn-sm btn-danger" id="dpcancel" value="Cancel" />                    
                                                    </div>                                   
                                </div>
                                
                            </div>                           
                            <!--activities-->
                            <div id="activities">
								
                                <asp:Literal ID="listact" runat="server"></asp:Literal>
                                <div id="divat">   
                                         <button type='button' class='btn  btn-sm btn-warning pull-right' id="btneditat" style="display:none">
                                                    <span class='glyphicon glyphicon-pencil'></span>
                                        </button>
                                    <form id="formatividade">    
                                                <div class="col-xs-12" id="selecionastepat" style="display:none">
													<div class="form-group">Step :
														<select class="select2"  id="stepat" name="stepat">
                                                            <asp:Literal ID="listafasesat" runat="server"></asp:Literal>
														</select>   <div id="divstepa" style="color:red"></div>                                                    
													</div>
												</div>                              
												<div class="col-xs-12">
													<div class="form-group">Activity's Name :
														<div class="input-group">                                                            
															<span class="input-group-addon"><i class="fa fa-pencil fa-sm fa-fw"></i></span>
															<input class="form-control input-sm" placeholder="Enter name" type="text" title="Please enter name" name="namea" id="namea"/>
														   </div>
                                                         <div id="divnamea" style="color:red"></div>
													</div>
												</div>
											
												<div class="col-xs-12">
													<div class="form-group">Activity's Description: 	  
											            <div class="input-group">                                                           
                                                            <span class="input-group-addon"><i class="fa fa-pencil"></i></span>
												           <textarea class="form-control" placeholder="Enter description" title="Please enter description" name="desca" id="desca" ></textarea>                                                                        
                                                             </div>
                                                        <div id="divdesca" style="color:red"></div>                                                       
													</div>
												</div>

                                                <div class="col-xs-5">
													<div class="form-group">Activity's Start Date:	  
											            <div class="input-group">                                                           
                                                            <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
												             <input type="date"  name="starta" id="starta" style="height:30px;" title="Please enter Start Date"/> 
                                                         </div>
                                                        <div id="divstarta" style="color:red"></div>                                             
													</div>
												</div>

                                                <div class="col-xs-5">
													<div class="form-group">Activity's Finish Date:  
											            <div class="input-group">                                                            
                                                            <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
												             <input type="date"  name="finisha" id="finisha" style="height:30px;" title="Please enter Expiry Date"/> 
                                                         </div>
                                                        <div id="divfinisha" style="color:red"></div>                                             
													</div>
												</div>

                                                <div class="col-xs-5">
													<div class="form-group">Activity's Hours:  
											            <div class="input-group">                                                            
                                                            <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
												             <input type="number" min="1"  name="houra" id="houra" style="height:30px;" title="Please enter hours"/> 
                                                         </div>
                                                        <div id="divhoura" style="color:red"></div>                                             
													</div>
												</div>                                                                                      
										</form>   
                                        <div id="btnsatividade" class="col-xs-12" style="display:none">
                                                    <div class="btn-header transparent pull-right" id="registersaveatividade" style="display:none">                 
                                                     <input type="button" class="btn btn-sm btn-success"  onclick="RegisterAtividade()" value="Save" />  
                                                    </div>
                                                    <div class="btn-header transparent pull-right" id="registercancelatividade" style="display:none">                 
                                                     <input type="button" class="btn btn-sm btn-danger"  onclick="RegisterCancelAtividade()" value="Cancel" />  
                                                    </div>
                                                     <div class="btn-header transparent pull-right" id="btneditsaveatividade">                 
                                                     <input type="button" class="btn btn-sm btn-success"  onclick="EditSaveAtividade()" value="Save" />  
                                                    </div>
                                                    <div class="btn-header transparent pull-right">                 
                                                        <input type="button" class="btn btn-sm btn-danger" id="btneditcancelatividade" onclick="EditCancelAtividade()" value="Cancel" />                    
                                                    </div>  
                                               </div>                                          
                                    </div>

                                    <div id="divaddrecurso"> 
                                    <form id="formaddrecurso">    
                                                <div class="col-xs-12">
													<div class="form-group">Type :
														<select class="select2"  id="selecttipo" name="selecttipo">
                                                            <option  value ="0" selected='selected'>Choose the type</option>
                                                             <option  value ="1" >Human</option>
                                                             <option  value ="2">Material</option>
														</select>                                                     
													</div>
												</div>                              
												<div class="col-xs-12">
													<div class="form-group">Resource:
														<select class="select2"  id="selecionarecurso" name="selecionarecurso">
                                                             
														</select>
                                                        <div id="divredselectrecurso" style="color:red"></div>
													</div> 
												</div>
											
												<div class="col-xs-12">
													<div class="form-group">Used Quantity: 	  
											            <div class="input-group">                                                           
                                                          <input type="time" class="form-control" required="required" title="Please enter number" name="hora" id="hora" style="display:none;" />                                             
											              <input type="text" class="form-control" required="required" title="Please enter number" name="unidade" id="unidade"  style="display:none;" /> 
                                              
                                                        </div>
                                                        <div id="divqtd" style="color:red"></div>                                                       
													</div>
												</div>                                                                                   
										</form>  
                                                    <div class="btn-header transparent pull-right">                 
                                                     <input type="button" class="btn btn-sm btn-success"  id="recadd" value="Save" />  
                                                    </div>
                                                    <div class="btn-header transparent pull-right">                 
                                                        <input type="button" class="btn btn-sm btn-danger" onclick="$('#divaddrecurso').dialog('close');" value="Cancel" />                    
                                                    </div>  
                                           </div>
							</div>
                           
                            <!--documents-->
                          <!--documents-->
                <div id="documents" style="height: 500px">

                    <asp:Literal ID="btnnewdocument" runat="server"></asp:Literal>
                    <br />
                    <br />

                    <div id="registerdoc" runat="server">
                        <div class="form-group">
                            <div id="projectname" runat="server"></div>
                            <table>
                                <asp:Literal ID="selstep" runat="server"></asp:Literal>
                            </table>

                            <table id='datatable_col_reorder' class='table  table-bordered table-hover' width='100%'>
                                <thead>
                                    <tr>
                                        <!--cabecalho-->
                                        <th data-hide='hours' class='sorting_asc' tabindex='0' aria-controls='datatable_col_reorder' rowspan='1' colspan='1' aria-sort='ascending' aria-label='Document: Select an Document'>Select an Document</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <input type='file' id='files' name='files' style="display: none" />
                                            <input type='hidden' id='filedoc' name='filedoc' />
                                            <input type="hidden" id="ativIdAux" runat="server" style="width: 1px; height: 1px;" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                            <div class="actions col-xs-offset-7">
                                <button type='button' class='btn btn-sm btn-danger' id='botaoclosedocument' value="Cancel">Cancel</button>
                                <button type='button' class='btn btn-sm btn-success' id='botaoconfirmdoc' onclick="SaveDoc()" value="Confirm">Save</button>
                            </div>
                        </div>
                    </div>




                    <!-- widget div-->
                    <div style="float: left">

                        <!-- widget content -->
                        <div class="widget-body">

                            <div class="tree smart-form">
                                <asp:Literal ID="arvoreprojeto" runat="server"></asp:Literal>
                            </div>

                        </div>
                        <!-- end widget content -->

                    </div>
                    <!-- end widget div -->
                    <div style="float: right">
                        <iframe width='650' id="visualizadocumento" height='450' style="display: none"></iframe>
                    </div>


                </div>
                <!-- fecha documento -->	
                         <!--Resources-->
                            <div id="resources">
                                
								 <asp:Literal ID="listrecursos" runat="server"></asp:Literal>                             
                               
							</div>		
                         <!--History-->
                            <div id="history">
								<ul style="list-style-type:none">
                                    <asp:Literal ID="listlogs" runat="server"></asp:Literal>
								</ul>
							</div>
				<!-- end widget div -->
<br /><br />
			</div>
			<!-- end widget -->         
       </div>    
      </div>
         <script type="text/javascript">

             pageSetUp();
             var pagefunction = function () {

                 loadScript("../Js/plugin/bootstraptree/bootstrap-tree.min.js");
             };

             // run pagefunction on load

             pagefunction();




    </script>

    <script>
        $(document).on('click', '.btnatividade', function () {
            var c = $(this).val();
            document.getElementById("ativIdAux").value = c;
            document.getElementById("files").style.display = 'block';
        });

    </script>


    <script>

        function SaveDoc() {
            var d = $('#filedoc').val();
            var atividadedoc = $('#ativIdAux').val();
            if (d != null) {
                return $.ajax({
                    dataType: "json",
                    url: "../Ajax/GetListProject.aspx?savedoc=" + d + "&at=" + atividadedoc,

                    success: function (data) {

                        if (data != null) {
                            $.each(data, function (index, c) {

                                var op = { 'ok': c.ok };
                                location.reload();

                            });
                        }
                    }
                });
            }
        }


        $('#botaonewdocument').click(function () {
            $('#registerdoc').dialog('open');
            return false;
        });

        $('#botaoclosedocument').click(function () {
            $('#registerdoc').dialog('close');
            return false;
        });

        $.widget("ui.dialog", $.extend({}, $.ui.dialog.prototype, {
            _title: function (title) {
                if (!this.options.title) {
                    title.html("&#160;");
                } else {
                    title.html(this.options.title);
                }
            }
        }));

        //???
        $('#registerdoc').dialog({
            autoOpen: false,
            width: 900,
            resizable: true,
            modal: true,
            title: "<div>New Document</div>",
            position: 'center'
        });
    </script>



    <script src="../Js/FileUp/AjaxUpload.js"></script>
    <script src="../Js/MaskMoney.js"></script>
    <script src="../Js/project/listproject.js"></script>
    <script src="../Js/project/editfaseact.js"></script>
    <!-- <script src="../Js/plugin/bootstraptree/bootstrap-tree.min.js"></script>-->
    <script>

        function upload() {
            $(document).ready(function () {
                var interval = 0;
                var options = {
                    action: '../Ajax/FileUploadDoc.ashx',
                    autoSubmit: true,
                    onSubmit: function (file, ext) {
                        {
                            interval = window.setInterval(function () {
                            }, 200);
                        }
                    },
                    onComplete: function (file, response) {
                        $('#filedoc').val(file)
                        alert("Upload ok");
                    }
                };
                new AjaxUpload('#files', options);
            });
        }

        upload();

    </script>
</body>
</html>
