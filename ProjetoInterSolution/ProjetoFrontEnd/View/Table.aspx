<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Table.aspx.cs" Inherits="ProjetoInter.View.Table" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">

            <!-- seleciona o projeto-->
        <div class="col-xs-11">
			<select class="select2" id="project" name="project">
                               <asp:Literal ID="selecionaprojeto" runat="server"></asp:Literal>                               
                            </select>
        </div>
                    <div class="btn-header transparent pull-right">                 
                    <input type="button" class="btn btn-success" id="create" value="Create"/>                    
                    </div>

            <br /><br /><br />

            <!--tabela-->
       
			<div class="jarviswidget jarviswidget-color-green" id="wid" data-widget-editbutton="false" >
				<header>
					<span class="widget-icon"> <i class="fa fa-table"></i> </span>
					<h2>Schedule's Project Name</h2>
				</header>

				<div>
                    <!-- botao de showing-->
					<div class="jarviswidget-editbox">	
					</div>

					<div class="widget-body no-padding">						
						<asp:Literal ID="tabelacron" runat="server"></asp:Literal>
					    <div id="nada" runat="server"><center><br /><br />Nothing found</center></div>

					</div>
				</div>
			</div>
            
<br /><br />
		</div>
    

<script type="text/javascript">

    pageSetUp();


    var pagefunction = function () {

        var responsiveHelper_dt_basic = undefined;
        var responsiveHelper_datatable_fixed_column = undefined;
        var responsiveHelper_datatable_col_reorder = undefined;
        var responsiveHelper_datatable_tabletools = undefined;

        var breakpointDefinition = {
            tablet: 1024,
            phone: 480
        };

        $('#create').click(function () {
            if ($('#project').val() != 0) {
                window.location = "Index.aspx#Table.aspx?projeto=" + $('#project').val();
            }
        });


        $('#dt_basic').dataTable({
            "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6'f><'col-sm-6 col-xs-12 hidden-xs'l>r>" +
                "t" +
                "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
            "autoWidth": true,
            "preDrawCallback": function () {
                // Initialize the responsive datatables helper once.
                if (!responsiveHelper_dt_basic) {
                    responsiveHelper_dt_basic = new ResponsiveDatatablesHelper($('#dt_basic'), breakpointDefinition);
                }
            },
            "rowCallback": function (nRow) {
                responsiveHelper_dt_basic.createExpandIcon(nRow);
            },
            "drawCallback": function (oSettings) {
                responsiveHelper_dt_basic.respond();
            }
        });       

        /* TABLETOOLS */
        $('#tableproject').dataTable({

            "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6'f><'col-sm-6 col-xs-6 hidden-xs'T>r>" +
					"t" +
					"<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-sm-6 col-xs-12'p>>",
            "oTableTools": {
                "aButtons": [               
                "xls",
                   {
                       "sExtends": "pdf",
                       "sTitle": "Schedule's Project",
                       "sPdfMessage": "",
                       "sPdfSize": "letter"
                   },
                   {
                       "sExtends": "print",
                       "sMessage": "Schedule's Project by ADS 2/2014 <i>(press Esc to close)</i>"
                   }
                ],
                "sSwfPath": "../Js/plugin/datatables/swf/copy_csv_xls_pdf.swf"
            },
            "autoWidth": true,
            "preDrawCallback": function () {
                // Initialize the responsive datatables helper once.
                if (!responsiveHelper_datatable_tabletools) {
                    responsiveHelper_datatable_tabletools = new ResponsiveDatatablesHelper($('#tableproject'), breakpointDefinition);
                }
            },
            "rowCallback": function (nRow) {
                responsiveHelper_datatable_tabletools.createExpandIcon(nRow);
            },
            "drawCallback": function (oSettings) {
                responsiveHelper_datatable_tabletools.respond();
            }
        });

        /* END TABLETOOLS */

    };

    // load related plugins

    loadScript("../Js/plugin/datatables/jquery.dataTables.min.js", function () {
        loadScript("../Js/plugin/datatables/dataTables.colVis.min.js", function () {
            loadScript("../Js/plugin/datatables/dataTables.tableTools.min.js", function () {
                loadScript("../Js/plugin/datatables/dataTables.bootstrap.min.js", function () {
                    loadScript("../Js/plugin/datatable-responsive/datatables.responsive.min.js", pagefunction)
                });
            });
        });
    });


</script>
</body>
</html>
