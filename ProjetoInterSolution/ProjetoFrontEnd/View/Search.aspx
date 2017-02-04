<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="ProjetoInter.View.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">

         <p><h4>Search's Results:</h4> </p>
            <asp:Literal ID="projetos" runat="server"></asp:Literal>
         <br /><br />
                  
    </div>
    <script type="text/javascript">
        function Open(cod) {
            window.location = 'Index.aspx#ListProject.aspx?codigo=' + cod;
        }
    </script>
</body>
</html>
