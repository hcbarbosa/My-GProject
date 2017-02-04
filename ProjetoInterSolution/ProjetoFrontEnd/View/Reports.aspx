<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="ProjetoInter.View.Reports" %>

<!--arruma o print-->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
</head>
<body>
     <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
         
          <!-- seleciona o projeto-->
         <div class="col-xs-11">
			<select class="select2" name="project" id="project">
             <asp:Literal ID="selecionaprojeto" runat="server"></asp:Literal>                              
           </select> 
        </div> 
              
             <!--botao create-->            
              <div class="btn-header transparent pull-right">                 
                    <input type="button" onclick="createreport()"  class="btn btn-success" id="create"  value="Create"/>                    
                   </div>
               
            <br /><br /><br />
			
            <div id="dados"></div>	
          
            
         </div>       
	<br /><br /><br /><br />
   
<!-- end row -->

    <script type="text/javascript" src="../Js/plugin/morris/raphael.min.js"></script>
    <script type="text/javascript" src="../Js/plugin/morris/morris.min.js"></script>

   <script type="text/javascript" src="../Js/reports/CreateReprot.js"></script>
    
</body>
</html>
