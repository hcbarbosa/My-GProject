using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ProjetoBackEnd.Data;
using ProjetoBackEnd.Model;

namespace ProjetoInter.View
{
    public partial class ListProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] is Cliente )
            {
                permissoes.Text = @"<li>
                                 <a href='#inform'><i class='fa fa-fw fa-lg fa-info'></i>Information</a>
							</li>
                            <li>
								<a href='#area'><i class='fa fa-fw fa-lg fa-comments'></i>Discussion</a>
							</li>
							<li>
								<a href='#steps'><i class='fa fa-fw fa-lg fa-pencil'></i>Steps</a>
							</li>
                            <li>
								<a href='#activities'><i class='fa fa-fw fa-lg fa-pencil'></i>Activities</a>
							</li>
                            <li>
								<a href='#documents'><i class='fa fa-fw fa-lg fa-file'></i>Attached Documents</a>
							</li>							
                            <li>
								<a href='#history'><i class='fa fa-fw fa-lg fa-history'></i>Event History</a>								
							</li>";
                ProjectModel pm = new ProjectModel();
                Projeto p = pm.GetProjeto(Int32.Parse(Request.Params["codigo"]));
                string modelo = "";
                if (p.modelo_numero != null)
                {
                    ModeloModel mm = new ModeloModel();
                    modelo = mm.GetModelo(p.modelo_numero.Value).nome;
                }
                else
                {
                    modelo = "No";
                }

                string clientes = "";
                foreach (Cliente c in pm.GetClientesProjeto(Int32.Parse(Request.Params["codigo"])))
                {
                    clientes += c.Pessoa.nome + ";";
                }
                string statusproject = "";
                 switch (p.status)
                    {
                        case 0: statusproject = "<b>Status: <font color='red'> Canceled </font></b>";
                            break;
                        case 1: statusproject = "<b>Status: <font color='blue'>In progress</font></b>";
                            break;
                        case 2: statusproject = "<b>Status: <font color='gray'>Model</font></b>";
                            break;
                        case 3: statusproject = "<b>Status: <font color='green'>Completed</font></b>";
                            break;
                 }
                 string atrasado = "";
                 if (p.data_termino < DateTime.Now && p.status ==1)
                 {
                     atrasado = "<b><font color='red'>Late <i class='fa fa-warning fa-sm fa-fw'></i></font></b>";
                 }
                 string valueused = "";
                 if ((p.valor_previsto - p.valor_utilizado) < 0)
                 {
                     valueused = "<td style='color:red'>" + (p.valor_previsto - p.valor_utilizado) + @"</td>";
                 }
                 else
                 {
                     valueused = "<td>" + (p.valor_previsto - p.valor_utilizado) + @"</td>";
                 }
                info.Text = @"
                                <br />                   
                                                   <table class='table table-hover' style='align-items:center'>                                                      							
                                                             <tr>                                                                
									                            <td><b>Name</b></td>
                                                                <td>" + p.nome + @"</td> 
                                                                <td><b>Percentage:</b></td> 
                                                                <td>" + p.porc_completo + @" %</td> 
                                                                <td><center>" + statusproject + @"</center></td>
                                                            </tr>
                                                            <tr>
                                                                <td><b>Start Date</b></td>
                                                                <td>" + p.data_inicio.ToString("dd/MM/yyyy") + @"</td>                                                                 
                                                                <td><b>Expiry Date</b></td>
                                                                <td>" + p.data_termino.ToString("dd/MM/yyyy") + @"</td>
                                                                <td><center>" + atrasado + @"</center></td>
                                                            </tr>
                                                            <tr>
                                                                <td><b>Total Cost:</b></td>
                                                                <td>" + p.valor_previsto + @"</td>                                                            
                                                                <td><b>Remainder Value</b></td>
                                                                " + valueused+ @" 
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td><b>Used Cost:</b></td>
                                                                <td>" + p.valor_utilizado + @"</td>                                                         
                                                                <td><b>Model</b></td>
                                                                <td>" + modelo + @"</td> 
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td><b>Company</b></td>
                                                                <td>" + pm.GetEmpresaProjeto(p.codigo) + @"</td>                                                                
                                                                <td><b>Customers</b></td>
                                                                <td>" + clientes + @"</td>
                                                                <td></td>
                                                           </tr>                                                    
                                                   </table>";

                StepModel sm = new StepModel();
                ActivityModel am = new ActivityModel();

                string conteudofase = "";
                foreach (Fase f in sm.listFases(Int32.Parse(Request.Params["codigo"])))
                {
                    conteudofase += @"<tr>
                                                <td>" + f.nome + @"</td>      
                                                <td align='center'>" + (f.data_inicio.ToString()).Substring(0, 10) + @"</td>
                                                <td align='center'>" + (f.data_termino.ToString()).Substring(0, 10) + @"</td>
                                                <td align='center'>" + f.porc_completo + @"</td>
                                                <td align='center'>" + am.CountAtividades(f.numero) + @"</td>
                                                <td>
                                                    <button type='button' class='btn  btn-sm btn-primary  viewcliente' value='"+f.numero+@"' >
                                                    <span class='glyphicon glyphicon-eye-open'></span>                                        
                                                    </button>
                                                </td>  
                                            </tr>";
                }
                listfases.Text = @"<table class='table table-hover' style='align-items:center'>
                                        <thead>
                                            <tr>
                                                <th class='col col-xs-3'>Name</th>  
                                                <th class='col col-xs-1'>Start Date</th> 
                                                <th class='col col-xs-1'>Expiry Date</th>                                                 
                                                <th class='col col-xs-1'>Percentage(%)</th>  
                                                <th class='col col-xs-1'>Activities</th>   
                                                <th class='col col-xs-1'>View</th>                  
                                            </tr>
                                        </thead>
                                        <tbody>
                                            " + conteudofase
                                                 + @"                                                                             
                                        </tbody>
                                    </table> ";

                string conteudoact = "";
                Atividade at;
                foreach (Cronograma c in am.GetAtividadesProjeto(Int32.Parse(Request.Params["codigo"])))
                {
                    at = new Atividade();
                    at = am.GetAtividade(c.atividade_numero);
                    conteudoact += @"<tr>
                                                <td>" + (sm.GetFase(c.fase_numero)).nome + @"</td>  
                                                <td>" + at.nome + @"</td>    
                                                <td align='center'>" + (at.data_inicio.ToString()).Substring(0, 10) + @"</td>
                                                <td align='center'>" + (at.data_termino.ToString()).Substring(0, 10) + @"</td>
                                                <td>
                                                     <button type='button' class='btn  btn-sm btn-primary viewactivitycliente' value='" + at.numero + @"'>
                                                    <span class='glyphicon glyphicon-eye-open'></span>
                                                    </button>
                                                </td>                                                            
                                            </tr> ";

                }

                listact.Text = @"
                                <br /><br />
                                <table class='table table-hover'>
                                        <thead>
                                            <tr>
                                                <th class='col col-xs-2'>Step</th> 
                                                <th class='col col-xs-2'>Name</th>
                                                <th class='col col-xs-1'>Start Date</th> 
                                                <th class='col col-xs-1'>Expiry Date</th> 
                                                <th class='col col-xs-1'>View</th>                                                                     
                                            </tr>
                                        </thead>
                                        <tbody>
                                            " + conteudoact + @"                   
                                        </tbody>
                                    </table>";


            }
            else if (Session["usuario"] is Gerente)
            {
                  permissoes.Text = @"<li>
                                <a href='#inform'><i class='fa fa-fw fa-lg fa-info'></i>Information</a>
							</li>
                            <li>
								<a href='#area'><i class='fa fa-fw fa-lg fa-comments'></i>Discussion</a>
							</li>
							<li>
								<a href='#steps'><i class='fa fa-fw fa-lg fa-pencil'></i>Steps</a>
							</li>
                            <li>
								<a href='#activities'><i class='fa fa-fw fa-lg fa-pencil'></i>Activities</a>
							</li>
                            <li>
								<a href='#dependecie'><i class='fa fa-fw fa-lg fa-history'></i>Dependencies</a>								
							</li>
                            <li>
								<a href='#documents'><i class='fa fa-fw fa-lg fa-file'></i>Attached Documents</a>
							</li>
							<li>
								<a href='#resources'><i class='fa fa-fw fa-lg fa-asterisk'></i>Used Resources</a>								
							</li>
                            <li>
								<a href='#history'><i class='fa fa-fw fa-lg fa-history'></i>Event History</a>								
							</li>
                            ";

                    ProjectModel pm = new ProjectModel();
                    Projeto p = pm.GetProjeto(Int32.Parse(Request.Params["codigo"].ToString()));
                    string modelo = "";
                    if (p.modelo_numero != null)
                    {
                        ModeloModel mm = new ModeloModel();
                        modelo = mm.GetModelo(p.modelo_numero.Value).nome;
                    }
                    else
                    {
                        modelo = "No";
                    }

                    string clientes = "";
                    foreach (Cliente c in pm.GetClientesProjeto(Int32.Parse(Request.Params["codigo"])))
                    {
                        clientes += c.Pessoa.nome + ";";
                    }

                    string statusproject = "";
                    string btnacao = "";
                    switch (p.status)
                    {
                        case 0: statusproject = "<b>Status: <font color='red'> Canceled </font></b>";
                            btnacao = @"<div class='btn-header transparent pull-right'>                 
                                        <input type='button' class='btn btn-sm btn-success' id='reactiveproject' value='Reactivate' onclick='Reactive(" + p.codigo + @")' title='Are you want reactivate the project?'/>                    
                                  </div>";
                            break;
                        case 1: statusproject = "<b>Status: <font color='blue'>In progress</font></b>";
                            if (p.porc_completo == 100)
                            {
                                btnacao = @"<div class='btn-header transparent pull-right'>                 
                                        <input type='button' class='btn btn-sm btn-success' id='completeproject' value='Complete' onclick='Complete(" + p.codigo + @")' title='Are you want complete the project?'/>                    
                                  </div>";
                            }
                            else
                            {
                                btnacao = @"<div class='btn-header transparent pull-right'>                 
                                        <input type='button' class='btn btn-sm btn-success' id='completeproject' value='Complete' disabled='disabled' title='There is step in progress in the project.'/>                    
                                  </div>";
                            }
                            break;
                        case 2: statusproject = "<b>Status: <font color='gray'>Model</font></b>";
                            btnacao += @"<div class='btn-header transparent pull-right'>                 
                                        <input type='button' class='btn btn-sm' id='btnviewmodel' value='View model' onclick='btnViewModel(" + p.codigo + @")' />                    
                                  </div>";
                            btnacao += @"<div class='btn-header transparent pull-right'>                 
                                        <input type='button' class='btn btn-sm' id='btneditmodel' value='Edit model' onclick='btnEditModel(" + p.codigo + @")' />                    
                                  </div>";
                            btnacao += @"<div class='btn-header transparent pull-right'>                 
                                        <input type='button' class='btn btn-sm' id='btndeletemodel' value='Delete model' onclick='btnDeleteModel(" + p.codigo + @")' />                    
                                  </div>";
                            break;
                        case 3: statusproject = "<b>Status: <font color='green'>Completed</font></b>";
                            btnacao = @"<div class='btn-header transparent pull-right'>                 
                                        <input type='button' class='btn btn-sm ' id='modelproject' value='Model?' onclick='Model(" + p.codigo + @")' title='Are you want create a model?'/>                    
                                  </div>";
                            break;
                    }
                    string atrasado = "";
                    if (p.data_termino < DateTime.Now && p.status ==1)
                    {
                        atrasado = "<b><font color='red'>Late <i class='fa fa-warning fa-sm fa-fw'></i></font></b>";
                    }
                    string valueused = "";
                    if ((p.valor_previsto - p.valor_utilizado) < 0)
                    {
                        valueused = "<td style='color:red'>" + (p.valor_previsto - p.valor_utilizado) + @"</td>";
                    }
                    else
                    {
                        valueused = "<td>" + (p.valor_previsto - p.valor_utilizado) + @"</td>";
                    }
                    info.Text = @"<div class='col-xs-offset-7 col-xs-5'>              
                                 " + btnacao + @"
                                  <div class='btn-header transparent pull-right'>                 
                                        <input type='button' class='btn btn-sm btn-warning' id='edit' onclick='Edit(" + p.codigo + @")' value='Edit'/>                    
                                  </div>
                                 </div>

                                <br /> <br />                  
                                                   <table class='table table-hover'>                                                      							
                                                              <tr>                                                                
									                            <td><b>Name</b></td>
                                                                <td>" + p.nome + @"</td> 
                                                                <td><b>Percentage:</b></td>   
                                                                <td>" + p.porc_completo + @" %</td> 
                                                                <td><center>" + statusproject + @"</center></td>
                                                            </tr>
                                                            <tr>
                                                                <td><b>Start Date</b></td>
                                                                <td>" + p.data_inicio.ToString("dd/MM/yyyy") + @"</td>                                                                 
                                                                <td><b>Expiry Date</b></td>
                                                                <td>" + p.data_termino.ToString("dd/MM/yyyy") + @"</td>
                                                                <td><center>" + atrasado + @"</center></td>
                                                            </tr>
                                                            <tr>
                                                                <td><b>Total Cost:</b></td>
                                                                <td>" + p.valor_previsto + @"</td>                                                            
                                                                <td><b>Remainder Value</b></td>
                                                                " + valueused + @" 
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td><b>Used Cost:</b></td>
                                                                <td>" + p.valor_utilizado + @"</td>                                                           
                                                                <td><b>Model</b></td>
                                                                <td>" + modelo + @"</td> 
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td><b>Company</b></td>
                                                                <td>" + pm.GetEmpresaProjeto(p.codigo) + @"</td>                                                                
                                                                <td><b>Customers</b></td>
                                                                <td>" + clientes + @"</td>
                                                                <td></td>
                                                            </tr>                                                    
                                                   </table>";


                    StepModel sm = new StepModel();
                    ActivityModel am = new ActivityModel();
                    string conteudofase = "", btncomplete = "";
                    DateTime data = DateTime.Now;
                    data = DateTime.Parse((data.ToString()).Substring(0, 10));
                    //preenche select de atividade
                    listafasesat.Text = "<option  value =\"0\" selected='selected'>Choose the step</option>";
                    foreach (Fase f in sm.listFases(Int32.Parse(Request.Params["codigo"])))
                    {

                        listafasesat.Text += "<option  value ='"+f.numero+"'>"+f.nome+"</option>";
                        if (f.porc_completo == 100)
                        {
                            btncomplete = @"<td>
                                                    <button type='button' class='btn  btn-sm btn-success completefase' id='complete' value='"+f.numero+@"' title='Are you want complete the step?'>
                                                    <span class='glyphicon glyphicon-ok'></span>
                                                    </button>
                                                </td>";
                        }
                        else
                        {
                            btncomplete = @"<td>
                                                    <button type='button' class='btn  btn-sm btn-success completefase ' id='complete' disabled value='" + f.numero + @"'  title='There is activity in progress in the step.'>
                                                    <span class='glyphicon glyphicon-ok'></span>
                                                    </button>
                                                </td>";
                        }


                        if (f.status == 1)
                        {

                            btnacao = @"<td>
                                                     <button type='button' class='btn  btn-sm btn-danger deletefase' value='" + f.numero + @"'  title='Are you want cancel the step?'>
                                                    <span class='glyphicon glyphicon-remove'></span>
                                                    </button>
                                                </td>";                          
                        }
                        else if (f.status == 0)
                        {
                            btnacao = @"<td>
                                                     <button type='button' class='btn  btn-sm btn-success reactivefase' value='" + f.numero + @"'  title='Are you want reactivate the step?'>
                                                    <span class='glyphicon glyphicon-repeat'></span>
                                                    </button>
                                                </td>";
                            btncomplete = @"<td>
                                                    <button type='button' class='btn  btn-sm' disabled value='" + f.numero + @"'  title='The step is canceled.'>
                                                    <span class='glyphicon glyphicon-ok'></span>
                                                    </button>
                                                </td>";
                        }
                        else if (f.status == 3)
                        {
                            btncomplete = @"<td>
                                                    <button type='button' class='btn  btn-sm' value='" + f.numero + @"'  disabled title='The step is completed'>
                                                    <span class='glyphicon glyphicon-ok'></span>
                                                    </button>
                                                </td>";
                            btnacao = @"<td>
                                                    <button type='button' class='btn  btn-sm' value='" + f.numero + @"'  disabled title='The step is completed'>
                                                    <span class='glyphicon glyphicon-ok'></span>
                                                    </button>
                                                </td>";
                        }


                        if (f.status == 1 && f.data_termino < data)
                        {
                            conteudofase += @"<tr id='atrasada'>
                                               <td id='tdnomefase" + f.numero + "'>" + f.nome + @"</td>      
                                                <td id='tdstartfase" + f.numero + "' align='center'>" + (f.data_inicio.ToString()).Substring(0, 10) + @"</td>
                                                <td id='tdfinishfase" + f.numero + "' align='center'>" + (f.data_termino.ToString()).Substring(0, 10) + @"</td>
                                                <td align='center'>" + f.porc_completo + @"</td>                                        
                                                 <td>
                                                    <button type='button' class='btn  btn-sm btn-primary  view' value='" +f.numero+@"'  >
                                                    <span class='glyphicon glyphicon-eye-open'></span>                                        
                                                    </button>
                                                </td>                                                
                                                " + btnacao + @"   
                                                " + btncomplete + @"             
                                            </tr>";
                        }
                        else if(f.status == 3)
                        {
                            conteudofase += @"<tr id='completada'>
                                                <td id='tdnomefase" + f.numero + "'>" + f.nome + @"</td>      
                                                <td id='tdstartfase" + f.numero + "' align='center'>" + (f.data_inicio.ToString()).Substring(0, 10) + @"</td>
                                                <td id='tdfinishfase" + f.numero + "' align='center'>" + (f.data_termino.ToString()).Substring(0, 10) + @"</td>
                                                <td align='center'>" + f.porc_completo + @"</td>
                                                 <td>
                                                    <button type='button' class='btn  btn-sm btn-primary  view' value='" +f.numero+@"' >
                                                    <span class='glyphicon glyphicon-eye-open'></span>                                        
                                                    </button>
                                                </td>
                                               
                                                " + btnacao + @"   
                                                " + btncomplete + @"             
                                            </tr>";
                        }
                        else
                        {
                            conteudofase += @"<tr>
                                                <td id='tdnomefase"+f.numero+"'>" + f.nome + @"</td>      
                                                <td id='tdstartfase" + f.numero + "' align='center'>" + (f.data_inicio.ToString()).Substring(0, 10) + @"</td>
                                                <td id='tdfinishfase" + f.numero + "' align='center'>" + (f.data_termino.ToString()).Substring(0, 10) + @"</td>
                                                <td align='center'>" + f.porc_completo + @"</td>
                                                 <td>
                                                    <button type='button' class='btn  btn-sm btn-primary  view' value='"+f.numero+@"' >
                                                    <span class='glyphicon glyphicon-eye-open'></span>                                        
                                                    </button>
                                                </td>
                                                
                                                " + btnacao + @"   
                                                " + btncomplete + @"             
                                            </tr>";
                        }
                    }
                    listfases.Text = @"<div class='col-xs-offset-11 col-xs-1'>              
                                          <button type='button' class='btn btn-success pull-right btnnewstep' value='"+p.codigo+@"'>
                                                    New
                                        </button>
                                         </div>
                                        <br /><br />
                                        <table class='table table-hover' style='align-items:center'>
                                        <thead>
                                            <tr>
                                                <th class='col col-xs-3'>Name</th>  
                                                <th class='col col-xs-1'>Start Date</th> 
                                                <th class='col col-xs-1'>Expiry Date</th>                                                 
                                                <th class='col col-xs-1'>Percentage(%)</th> 
                                                <th class='col col-xs-1'>View</th>
                                                <th class='col col-xs-1'>Action</th>                                                
                                                <th class='col col-xs-1'>Complete</th>                    
                                            </tr>
                                        </thead>
                                        <tbody>
                                            " + conteudofase
                                                     + @"                                                                             
                                        </tbody>
                                    </table> ";

                    //dependencias
                    string conteudodep = "";
                    string aspa = "\"";

                    ActivityModel ad = new ActivityModel();
                    DependenciaModel dml = new DependenciaModel();
                    int auxf = 1;
                    int auxat = 1;
                    listselecionadependencia.Text = "<option value=''></option>";
                    foreach (Fase fdep in sm.listFases(Int32.Parse(Request.Params["codigo"])))
                    {
                        string tipo = "";
                        string depFase = " ";
                        foreach (Dependencia d in dml.DependenciaFase(Int32.Parse(Request.Params["codigo"]), fdep.numero))
                        {
                            tipo = (d.tipo == 0) ? "Finish-to-start" : d.tipo == 1 ? "Start-to-start" : d.tipo == 2 ? "Finish-to-finish" : "";
                            depFase += (d.faseDependente != null) ? (sm.GetFase((int)d.faseDependente)).nome + ";" : "";
                            depFase += (d.atividadeDependente != null) ? ad.GetAtividade((int)d.atividadeDependente).nome + ";" : "";

                            string t = ad.GetAtividade(1).nome;
                        }

                        conteudodep += @" <tr>
                                    <td>F" + auxf + @"</td>
									<td><b>" + fdep.nome + @"<b></td>
                                    <td class='dep'>" + depFase.Substring(0, depFase.Length - 1) + @"</td>
                                    <td class='tipodp'>" + tipo + @"</td>
                                    <td><button type='button' class='btn  btn-sm btn-warning' onclick='addDependencia(this," + aspa + "" + fdep.numero + @"F" + aspa + "," + Request.Params["codigo"] + @")' >
                                <span class='glyphicon glyphicon-pencil'></span>                                        
                                                    </button>
                                    </td>
								</tr>";
                        listselecionadependencia.Text += "<option value='" + fdep.numero + "F'>F" + auxf + " - " + fdep.nome + "</option>";
                        //  searchArray += "dependentes[" + fdep.numero + 1 + "]= \"F" + auxf + "\";";
                        foreach (Atividade atdep in ad.GetAtividadesFase(fdep.numero))
                        {
                            string depAtividade = " ";
                            tipo = "";

                            foreach (Dependencia d in dml.DependenciaAtividade(Int32.Parse(Request.Params["codigo"]), atdep.numero))
                            {
                                tipo = (d.tipo == 0) ? "Finish-to-start" : d.tipo == 1 ? "Start-to-start" : d.tipo == 2 ? "Finish-to-finish" : "";
                                depAtividade += (d.faseDependente != null) ? (sm.GetFase((int)d.faseDependente)).nome + ";" : "";
                                depAtividade += (d.atividadeDependente != null) ? ad.GetAtividade((int)d.atividadeDependente).nome + ";" : "";
                            }

                            conteudodep += @" <tr>
                                    <td>A" + auxf + "." + auxat + @"</td>
									<td >" + atdep.nome + @"</td>
                                    <td class='dep'>" + depAtividade.Substring(0, depAtividade.Length - 1) + @"</td>
                                    <td class='tipodp'>" + tipo + @"</td>
                                    <td><button type='button' class='btn  btn-sm btn-warning' onclick='addDependencia(this," + aspa + "" + atdep.numero + "A" + aspa + "," + Request.Params["codigo"] + @")' >
                                                                    <span class='glyphicon glyphicon-pencil'></span>                                        
                                                                                        </button>
                                                                        </td>                                    
                                </tr>";
                            listselecionadependencia.Text += "<option value='" + atdep.numero + "A'>A" + auxf + "." + auxat + " - " + atdep.nome + "</option>";
                            //searchArray += "dependentes[" + atdep.numero + 2 + "]= \"A" + auxf + "." + auxat + "\";";
                            auxat++;
                        }
                        auxat = 1;
                        auxf++;
                    }


                    listdependencias.Text = @"<table class='table table-hover' id='tabledep' style='align-items:center'>
                                        <thead>
                                            <tr>
                                                <th class='col col-xs-1'>Code</th> 
                                                <th class='col col-xs-4'>Name</th> 
                                                <th class='col col-xs-3'>Dependencie</th>
                                                <th class='col col-xs-2'>Type</th> 
                                                <th class='col col-xs-2'>Edit</th>                    
                                            </tr>
                                        </thead>
                                        <tbody>
                                            " + conteudodep + @"                   
                                        </tbody>
                                    </table>";


               

               


                    string conteudoact = "";
                    Atividade at;
                    btnacao = "";
                    btncomplete = "";
                    string btnadd = "";
                    CronogramaRecursoModel crm = new CronogramaRecursoModel();
                    foreach (Cronograma c in am.GetAtividadesProjeto(Int32.Parse(Request.Params["codigo"])))
                    {
                        at = new Atividade();
                        at = am.GetAtividade(c.atividade_numero);

                        if (at.status == 1)
                        {
                            btncomplete = @"        <td>
                                                     <button type='button' class='btn  btn-sm btn-success completeat' value='"+at.numero+@"' title='Are you want complete the activity?'>
                                                    <span class='glyphicon glyphicon-ok'></span>
                                                    </button>
                                                </td> ";
                            btnacao = @"        <td>
                                                     <button type='button' class='btn  btn-sm btn-danger deleteat'  value='" + at.numero + @"' title='Are you want cancel the activity?'>
                                                    <span class='glyphicon glyphicon-remove'></span>
                                                    </button>
                                                </td> ";
                           btnadd = @"<td>
                                                     <button type='button' class='btn  btn-sm btn-primary recursoadd'  value='" + Int32.Parse(Request.Params["codigo"]) + ',' + c.fase_numero + ','+ at.numero + @"' title='Are you want add resource in the activity?'>
                                                    <span class='glyphicon glyphicon-plus'></span>Resource
                                                    </button>
                                                </td> ";
                            
                        }
                        else if(at.status == 0)
                        {
                            btncomplete = @"        <td>
                                                     <button type='button' class='btn  btn-sm disabled' title='The activity is canceled.'>
                                                    <span class='glyphicon glyphicon-ok'></span>
                                                    </button>
                                                </td> ";

                            if (am.GetFaseDaAtividade(at.numero).status == 0)
                            {
                                btnacao = @"        <td>
                                                     <button type='button' class='btn  btn-sm btn-success reactivateat' disabled title='Are you want reactivate the activity?'>
                                                    <span class='glyphicon glyphicon-repeat'></span>
                                                    </button>
                                                </td> ";
                            }
                            else
                            {
                                btnacao = @"        <td>
                                                     <button type='button' class='btn  btn-sm btn-success reactivateat'  value='" + at.numero + @"' title='Are you want reactivate the activity?'>
                                                    <span class='glyphicon glyphicon-repeat'></span>
                                                    </button>
                                                </td> ";
                            }
                            
                            
                           
                            btnadd = @"<td>
                                                     <button type='button' class='btn  btn-sm' disabled title='The activity is canceled.'>
                                                    <span class='glyphicon glyphicon-plus'></span>Resource
                                                    </button>
                                                </td> ";

                        }
                        else if (at.status == 3)
                        {
                            btnacao = @"        <td>
                                                     <button type='button' class='btn  btn-sm' disabled title='The activity is completed.'>
                                                    <span class='glyphicon glyphicon-ok'></span>
                                                    </button>
                                                </td> ";
                            btnadd = @"<td>
                                                     <button type='button' class='btn  btn-sm' disabled title='The activity is completed.'>
                                                    <span class='glyphicon glyphicon-plus'></span>Resource
                                                    </button>
                                                </td> ";
                            btncomplete = @"        <td>
                                                     <button type='button' class='btn  btn-sm ' disabled title='The activity is completed.'>
                                                    <span class='glyphicon glyphicon-ok'></span>
                                                    </button>
                                                </td> ";
                        }

                        if (at.data_termino < data && at.status == 1)
                        {
                            conteudoact += @"<tr id='atrasada'>
                                                <td >" + (sm.GetFase(c.fase_numero)).nome + @"</td>  
                                                <td id='tdnomeat" + at.numero + "'>" + at.nome + @"</td>    
                                                <td id='tdstartat" + at.numero + "' align='center'>" + (at.data_inicio.ToString()).Substring(0, 10) + @"</td>
                                                <td id='tdfinishat" + at.numero + "' align='center'>" + (at.data_termino.ToString()).Substring(0, 10) + @"</td>
                                                <td>
                                                     <button type='button' class='btn  btn-sm btn-primary viewactivity' value='" +at.numero+@"'>
                                                    <span class='glyphicon glyphicon-eye-open'></span>
                                                    </button>
                                                </td>
                                                "+btnacao+@"
                                                "+btncomplete+@"
                                                "+btnadd+@"               
                                            </tr> ";
                        }
                        else if (at.status == 3)
                        {
                            conteudoact += @"<tr id='completada'>
                                                <td >" + (sm.GetFase(c.fase_numero)).nome + @"</td>  
                                                <td id='tdnomeat" + at.numero + "'>" + at.nome + @"</td>    
                                                <td id='tdstartat" + at.numero + "' align='center'>" + (at.data_inicio.ToString()).Substring(0, 10) + @"</td>
                                                <td id='tdfinishat" + at.numero + "' align='center'>" + (at.data_termino.ToString()).Substring(0, 10) + @"</td>
                                                <td>
                                                     <button type='button' class='btn  btn-sm btn-primary viewactivity' value='" + at.numero + @"'>
                                                    <span class='glyphicon glyphicon-eye-open'></span>
                                                    </button>
                                                </td>  
                                                 
                                                " + btnacao + @"
                                                " + btncomplete + @"
                                                " + btnadd + @"               
                                            </tr> ";
                        }
                        else
                        {
                            conteudoact += @"<tr>
                                                <td >" + (sm.GetFase(c.fase_numero)).nome + @"</td>  
                                                <td id='tdnomeat" + at.numero + "'>" + at.nome + @"</td>    
                                                <td id='tdstartat" + at.numero + "' align='center'>" + (at.data_inicio.ToString()).Substring(0, 10) + @"</td>
                                                <td id='tdfinishat" + at.numero + "' align='center'>" + (at.data_termino.ToString()).Substring(0, 10) + @"</td>
                                                <td>
                                                     <button type='button' class='btn  btn-sm btn-primary viewactivity' value='" + at.numero + @"'>
                                                    <span class='glyphicon glyphicon-eye-open'></span>
                                                    </button>
                                                </td>  
                                                
                                                " + btnacao + @"
                                                " + btncomplete + @"
                                                " + btnadd + @"             
                                            </tr> ";
                        }
                    }

                    listact.Text = @"<div class='col-xs-offset-11 col-xs-1'>              
                                  <div class='btn-header transparent pull-right'>                 
                                        <input type='button' class='btn btn-sm btn-success' id='newact' onclick='registerat("+Int32.Parse(Request.Params["codigo"])+@")' value='New'/>                    
                                  </div>
                                 </div>
                                <br /><br />
                                <table class='table table-hover' style='align-items:center'>
                                        <thead>
                                            <tr>
                                                <th class='col col-xs-2'>Step</th> 
                                                <th class='col col-xs-2'>Name</th>
                                                <th class='col col-xs-1'>Start Date</th> 
                                                <th class='col col-xs-1'>Expiry Date</th> 
                                                <th class='col col-xs-1'>View</th>  
                                                <th class='col col-xs-1'>Action</th>                                                
                                                <th class='col col-xs-1'>Complete</th> 
                                                <th class='col col-xs-1'>Resource</th>                   
                                            </tr>
                                        </thead>
                                        <tbody>
                                            " + conteudoact + @"                   
                                        </tbody>
                                    </table>";




                    btnnewdocument.Text = @"<div class='col-xs-offset-11 col-xs-1'>              
                                  <div class='btn-header transparent pull-right'>                 
                                        <input type='button' class='btn btn-sm btn-success' id='botaonewdocument' value='New'/>                    
                                  </div>
                                 </div>";

                    ResourceModel rm = new ResourceModel();
                    listrecursos.Text += "<table><tbody>";
                    Atividade a;
                    Recurso r;
                    int auxa = 0;
                    bool existerecurso = false;
                    int divfundo = 0;
                    foreach (CronogramaRecurso crmr in rm.ListResourcesProjeto(Int32.Parse(Request.Params["codigo"])))
                    {

                        existerecurso = true;
                        if (auxa != crmr.atividade_numero)
                        {
                            a = new Atividade();
                            a = am.GetAtividade(crmr.atividade_numero);
                            listrecursos.Text += @"</tbody></table><table class='col-xs-12 table  table-bordered table-hover' id='tableat"+crmr.atividade_numero+@"'><thead>
								<tr>                                                                                                         
                                    <th><center>"+ a.nome + @"</center></th> 
                                    <th><center>Used Qtd</center></th>
                                    <th>Delete</th>
								</tr>
							</thead><tbody>";
                            divfundo++;
                            divfundo++;
                        }
                        r = rm.GetResource(crmr.recurso_id);

                        if (r.Tipo.descricao == "Human")
                        {
                            listrecursos.Text += @"<tr ><td>" + r.descricao + @"</td><td style='width:100px'><center>" + crmr.qtd_hora_usada + @" h</center></td>  
                                                    <td style='width:40px'>
                                                    <button type='button' class='btn  btn-sm btn-danger deleterecurso' value='"+crmr.recurso_id+","+crmr.atividade_numero+@"' >
                                                    <span class='glyphicon glyphicon-remove'></span>
                                                    </button></td>
                                                   </tr>";
                        }
                        else
                        {
                            listrecursos.Text += @"<tr ><td>" + r.descricao + @"</td><td style='width:100px'><center>" + crmr.qtd_unid_usada + @" u</center></td>  
                                                    <td style='width:40px'>
                                                    <button type='button' class='btn  btn-sm btn-danger deleterecurso' value='" + crmr.recurso_id + "," + crmr.atividade_numero + @"' >
                                                    <span class='glyphicon glyphicon-remove'></span>
                                                    </button></td>
                                                   </tr>";
                        }
                        
                        
                        auxa = crmr.atividade_numero;
                        divfundo++;
                    }
                    if (existerecurso)
                    {
                        listrecursos.Text += "</tbody></table><div style='height:" + divfundo * 40 + "px'></div>";
                    }
                    else
                    {
                        listrecursos.Text += "</tbody></table><center>Nothing Found</center>";
                    }
                    
            }
            else
            {
                Session.Clear();
                Response.Redirect("Login.aspx?resp=proibido", false);
            }

            CommentModel cm = new CommentModel();
            PeopleModel ps = new PeopleModel();
            Pessoa pes = Session["pessoa"] as Pessoa;
            string btndeletecomment = "";
            foreach(Comentario c in cm.ListComentarios(Int32.Parse(Request.Params["codigo"])))
            {
                if (pes.id == c.pessoa_id)
                {
                    btndeletecomment = @"<button type='button' class='btn  btn-xs btn-danger remove' value='"+c.id+@"'>
                                                                            <span class='glyphicon glyphicon-remove'></span>
                                                                            </button>";
                }
                else
                {
                    btndeletecomment = "";
                }

            comentarios.Text += @"<li class='message' id='"+c.id+@"'>
									<img src='../Images/avatars/" + ps.GetImagem(c.pessoa_id) + @"' id='imgcomment' class='online' alt='' />
									<div class='message-text'>
										<time>
											" + c.data_hora + @"|                                             
                                            "+ btndeletecomment                                                                                    
                                             
                                             + @"
										</time> <a href='javascript:void(0);' style='color:green' class='username'>" + ps.GetPessoa(c.pessoa_id).nome+@"</a> 
                                        "+ c.descricao +@"
									</div>	
                                <br />							
                                <br />
                                <hr />
                                </li>
                                ";            
            }

            LogModel lm = new LogModel();
            string logstexto = "";
            int projeto = Int32.Parse(Request.Params["codigo"]);
            foreach(Log l in lm.listlogs(projeto))
            {
                logstexto +=@"<li class='message'>
                                                <div class='message-text'>
										        <time>
											        "+l.data_hora+@" |
										        </time>  <font color='green'><u><b>"+ps.GetPessoa(l.pessoa_id).nome+@"</b></u>:</font>
                                                    "+l.descricao+@" 
									            </div>
                                             </li><hr />"; 
            }
            listlogs.Text = logstexto;  
          
            DocumentModel dm = new DocumentModel();
            List<Cronograma> cr = new List<Cronograma>();
            cr = dm.GetDocumentosProjeto(projeto);
            string arvore = @"<ul>
								<li>
									<span><i class='fa fa-lg fa-folder-open'></i>" + dm.GetNomeProjeto(projeto) + @"</span>
									<ul>";
            int auxfase = 0;
            string fs = "";
            foreach (Cronograma c in cr)
            {
                fs = dm.GetNomeFase(c.fase_numero);
                if (auxfase == 0)
                {
                    arvore += @"<li>
											                    <span>" + fs + @"</span>
											                    <ul>";
                }
                else if (c.fase_numero != auxfase)
                {

                    arvore += @"</ul>
                                                                </li>
                                                                <li>
											                    <span>" + fs + @"</span>
											                    <ul>";
                }

                arvore += @"     <li>
													                    <span><label onclick="+"\"" +"ShowDocument('" + dm.GetDocumento(Int32.Parse((c.documento_numero).ToString())).local + "')\">" + dm.GetDocumento(Int32.Parse((c.documento_numero).ToString())).nome + @"</label> </span>
												                    </li>";

                auxfase = c.fase_numero;
            }
            arvore += @"</ul>
										                    </li>
									                            </ul>
								                            </li>								
							                            </ul>";

            arvoreprojeto.Text = arvore;
            
            Pessoa pessoa = Session["pessoa"] as Pessoa;
            btncomment.Text=@"<button class='btn btn-sm btn-primary pull-right' onclick='comment("+pessoa.id+","+projeto+@");'>
									Comment
								</button>";


            //Preencher modal
            int projeto1 = Int32.Parse(Request.Params["codigo"]);

            List<Cronograma> stepsproject = new List<Cronograma>();

            stepsproject = dm.GetProjetoFases(projeto1);

            projectname.InnerHtml = "<span><i class='fa fa-lg fa-folder-open'></i>" + dm.GetNomeProjeto(projeto1) + @"</span>";

            string fasename = "";
            int aux = 0;

            string conteudostep = "";

            foreach (Cronograma cro in stepsproject)
            {

                if (aux != cro.fase_numero)
                {
                    aux = cro.fase_numero;
                    fasename = dm.GetNomeFase(cro.fase_numero);
                    conteudostep += @" 
                                <tr   role='row' class='odd'>
									<td class='sorting_1'>
                                        
                                        <label value='" + cro.fase_numero + @"'>
                                        <span>" + fasename + @"</span>
                                        </label>
                                       <td>
                                        
                                                    	";

                }

                if (cro.documento_numero == null)
                {
                    conteudostep += @" <div>
                                                                                
                                        <button type='button'class='btn btn-sm btn-success btnatividade'   value='" + cro.atividade_numero + @"'>
                                        <span>" + cro.Atividade.nome + @"</span>                                        
                                        </button>
                                        </div>                                        
                                         ";

                }
            }




            selstep.Text = @"
            <table id='datatable_col_reorder' class='table  table-bordered table-hover' width='100%'>
							<thead>
								<tr><!--cabecalho-->                                                                                                              
                                     <th  data-hide='hours'class='sorting_asc'tabindex='0'aria-controls='datatable_col_reorder'rowspan='1'colspan='1'aria-sort='ascending'aria-label='Step: choose the step'>Steps</th>                                     
                                     <th  data-hide='hours'class='sorting_asc'tabindex='0'aria-controls='datatable_col_reorder'rowspan='1'colspan='1'aria-sort='ascending'aria-label='Activities: choose the Activity'>Activities</th>                                    
 								</tr>
							</thead>
							<tbody><!--registros-->											
                                " + conteudostep + @" 
                                </td>                                
                                </td>
								</tr>
							</tbody>
						</table> ";



            //Fim preencher modal
        }

        protected void save_Click(object sender, EventArgs e)
        {
           
                ProjectModel prm = new ProjectModel();
                Projeto pr = new Projeto();
                pr.codigo = Int32.Parse(Request.Params["codigo"]);
                pr.nome = Request.Params["name"];
                pr.valor_previsto = Decimal.Parse(Request.Params["valuetotal"]);
                pr.data_inicio = DateTime.Parse(Request.Params["startdate"]);
                pr.data_termino = DateTime.Parse(Request.Params["finishdate"]);
                if (Request.Params["model"] != null)
                {
                    pr.modelo_numero = Int32.Parse(Request.Params["model"]);
                }
                int empresa = Int32.Parse(Request.Params["company"]);
                string[] clientesvet = Request.Params["customers[]"].Split(',');
                prm.Update(pr, empresa, clientesvet);
                Response.Redirect("Index.aspx#ListProject.aspx?codigo=" + pr.codigo);

            }

                   

        }
    
    }
