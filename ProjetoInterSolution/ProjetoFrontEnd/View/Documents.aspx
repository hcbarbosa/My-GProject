<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Documents.aspx.cs" Inherits="ProjetoInter.View.Documents" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
        <form id="esolheprojeto" runat="server">
         <div class="col-xs-11">
			<select class="select2" id="project" name="project" style="width:100%">
            <asp:Literal ID="selecionaprojeto" runat="server"></asp:Literal>                             
           </select> 
        </div> 
         <div class="btn-header transparent pull-right">                 
                    <input type="button" id="show" class="btn btn-success" onclick="Show()" value="Show"/>                    
                    </div>
        </form>  
        <br /><br />

        <!-- widget div-->
				<div style="float:left">

					<!-- widget edit box -->
					<div class="jarviswidget-editbox">
						<!-- This area used as dropdown edit box -->

					</div>
					<!-- end widget edit box -->

					<!-- widget content -->
					<div class="widget-body">

						<div class="tree smart-form">
							<asp:Literal ID="arvoreprojeto" runat="server"></asp:Literal>                              
                        </div>
                        </div>
					<!-- end widget content -->

				</div>
				<!-- end widget div -->
        <div style="float:right">
            <iframe  id="visualizadocumento" style="display:none" width="650" height="450"></iframe>  
        </div>
             <br /><br />
       </div> 
    
     <script src="../Js/document/edit.js"></script>
    <script src="../Js/plugin/bootstraptree/bootstrap-tree.min.js"></script>
</body>
</html>
