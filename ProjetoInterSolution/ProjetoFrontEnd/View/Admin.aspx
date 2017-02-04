<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ProjetoFrontEnd.View.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>


    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">

        <div class="well well-sm well-light">

            <div id="tabs">
                <ul>
                    <li>
                        <a href="#tabs-companies"><i class="fa fa-building fa-sm fa-fw"></i>Companies</a>
                    </li>
                    <li>
                        <a href="#tabs-customers"><i class="fa fa-user fa-sm fa-fw"></i>Customers</a>
                    </li>
                    <li>
                        <a href="#tabs-resources"><i class="fa fa-pencil fa-sm fa-fw"></i>Resources</a>
                    </li>
                    <li>
                        <a href="#tabs-documents"><i class="fa fa-book fa-sm fa-fw"></i>Documents</a>
                    </li>
                </ul>

                <div id="tabs-companies">
                    <table>
                        <!-- Listar companias inativas -->
                         <asp:Literal ID="listcompanies" runat="server"></asp:Literal> 
                    </table>
                </div>
                <div id="tabs-customers">
                    <table>
                        <!-- Listar companias inativas -->
                         <asp:Literal ID="listcustomers" runat="server"></asp:Literal> 
                    </table>
                </div>
                <div id="tabs-resources">
                    <table>
                        <!-- Listar companias inativas -->
                         <asp:Literal ID="listresources" runat="server"></asp:Literal> 
                    </table>
                </div>

                <div id="tabs-documents">
                  <table>
                        <!-- Listar companias inativas -->
                         <asp:Literal ID="listdocuments" runat="server"></asp:Literal> 
                    </table>
                    
                </div>


            </div>
            <br />
            <br />
        </div>
    </div>

    <script>
        $('#tabs').tabs();

        
        //Reativar company e troca de botoes
        $(document).on('click', '.confirmcompany', function () {
            var c = $(this).val();
            return $.ajax({
                dataType: "json",
                url: "../Ajax/GetAtiva.aspx?company= " + c,

                success: $(this).parent().parent().parent().remove()
            });
        });
        $(document).on('click', '.activecompany', function () {
            var c = $(this).val();
            document.getElementById(c).innerHTML = '<center> <button type=\'button\'class=\'btn  btn-sm btn-danger  cancelcompany\' value=\'' + c + '\' ><span class=\'glyphicon glyphicon-remove\'></span></button> <button type=\'button\'class=\'btn  btn-sm btn-success  confirmcompany\' value=\'' + c + '\' > <span class=\'glyphicon glyphicon-ok\'></span></button>   </center>';
           
                success: $(this).parent().remove()
           
        });
        $(document).on('click', '.cancelcompany', function () {
            var c = $(this).val();
            document.getElementById(c).innerHTML = '<center> <button type=\'button\'class=\'btn  btn-sm btn-success  activecompany\' value=\'' + c + '\' > <span class=\'glyphicon glyphicon-repeat\'></span></button> <center>  ';
           
                success: $(this).parent().remove()
           
        });
        //Fim company


        //Reativar customer e troca de botoes
        $(document).on('click', '.confirmcustomer', function () {
            var c = $(this).val();
            return $.ajax({
                dataType: "json",
                url: "../Ajax/GetAtiva.aspx?customer= " + c,

                success: $(this).parent().parent().parent().remove()
            });
        });
        $(document).on('click', '.activecustomer', function () {
            var c = $(this).val();
            document.getElementById(c).innerHTML = '<center> <button type=\'button\'class=\'btn  btn-sm btn-danger  cancelcustomer\' value=\'' + c + '\' ><span class=\'glyphicon glyphicon-remove\'></span></button> <button type=\'button\'class=\'btn  btn-sm btn-success  confirmcustomer\' value=\'' + c + '\' > <span class=\'glyphicon glyphicon-ok\'></span></button>   </center>';
            
                success: $(this).parent().remove()
           
        });
        $(document).on('click', '.cancelcustomer', function () {
            var c = $(this).val();
            document.getElementById(c).innerHTML = '<center> <button type=\'button\'class=\'btn  btn-sm btn-success  activecustomer\' value=\'' + c + '\' > <span class=\'glyphicon glyphicon-repeat\'></span></button> <center>  ';
          
                success: $(this).parent().remove()
           
        });
        //Fim customer



        //Reativar resource e troca de botoes
        $(document).on('click', '.confirmresource', function () {
            var r = $(this).val();
            return $.ajax({
                dataType: "json",
                url: "../Ajax/GetAtiva.aspx?resource= " + r,

                success: $(this).parent().parent().parent().remove()
            });
        });
        $(document).on('click', '.activeresource', function () {
            var c = $(this).val();
            document.getElementById(c).innerHTML = '<center> <button type=\'button\'class=\'btn  btn-sm btn-danger  cancelresource\' value=\'' + c + '\' ><span class=\'glyphicon glyphicon-remove\'></span></button> <button type=\'button\'class=\'btn  btn-sm btn-success  confirmresource\' value=\'' + c + '\' > <span class=\'glyphicon glyphicon-ok\'></span></button>   </center>';
            
                success: $(this).parent().remove()
           
        });
        $(document).on('click', '.cancelresource', function () {
            var c = $(this).val();
            document.getElementById(c).innerHTML = '<center> <button type=\'button\'class=\'btn  btn-sm btn-success  activeresource\' value=\'' + c + '\' > <span class=\'glyphicon glyphicon-repeat\'></span></button> <center>  ';
           
                success: $(this).parent().remove()
           
        });
        //Fim resource



        //Reativar documents e troca de botoes

        $(document).on('click', '.activedocument', function () {
            var c = $(this).val();
            document.getElementById(c).innerHTML = '<center>  <button type=\'button\'class=\'btn  btn-sm btn-danger  canceldocument\' value=\'' + c + '\' ><span class=\'glyphicon glyphicon-remove\'></span></button> <button type=\'button\'class=\'btn  btn-sm btn-success  downloaddocument\' value=\'' + c + '\' > <span class=\'glyphicon glyphicon-ok\'></span></button>  </center>';

            success: $(this).parent().remove()

        });
        $(document).on('click', '.canceldocument', function () {
            var c = $(this).val();
            document.getElementById(c).innerHTML = '<center> <button type=\'button\'class=\'btn  btn-sm btn-success  activedocument\' value=\'' + c + '\' > <span class=\'glyphicon glyphicon-repeat\'></span></button> <center>  ';

            success: $(this).parent().remove()

        });

        $(document).on('click', '.downloaddocument', function () {
            var c = $(this).val();
            var rep;
            var printWindow = window.open('', '', 'letf=0,top=0,toolbar=0,scrollbars=0,status=0,dir=ltr,height=600,width=1000');
            printWindow.document.write('<html><head><title>Document</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write('<iframe src =\'../Documents/' + c + '\' width=\'1000\' height=\'600\'></iframe>');
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.focus();
                //printWindow.print();
                //printWindow.close();
            }, 500);
            return false;
        });

        //Fim document

    </script>

    <script src="../Js/company/edit.js"></script>



</body>
</html>

