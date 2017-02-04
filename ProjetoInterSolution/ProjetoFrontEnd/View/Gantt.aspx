<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gantt.aspx.cs" Inherits="ProjetoFrontEnd.View.Gantt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Js/dhtmlxGantt_v3.1.0_gpl/codebase/dhtmlxgantt.js?v=3.1" type="text/javascript" charset="utf-8"></script>
    <script src="../Js/dhtmlxGantt_v3.1.0_gpl/codebase/sources/dhtmlxgantt.js.map" type="text/javascript" charset="utf-8"></script>
    
    <script type="text/javascript" src="../Js/gantt/startGantt.js"></script>

    <link rel="stylesheet" href="../Js/dhtmlxGantt_v3.1.0_gpl/codebase/skins/dhtmlxgantt_broadway.css?v=3.1" type="text/css" media="screen" title="no title" charset="utf-8"/>
    <style type="text/css">
        

        .gantt_task_link.start_to_start .gantt_line_wrapper div {
            background-color: #dd5640;
        }

        .gantt_task_link.start_to_start:hover .gantt_line_wrapper div {
            box-shadow: 0 0 5px 0px #dd5640;
        }

        .gantt_task_link.start_to_start .gantt_link_arrow_right {
            border-left-color: #dd5640;
        }


        .gantt_task_link.finish_to_start .gantt_line_wrapper div {
            background-color: #7576ba;
        }

        .gantt_task_link.finish_to_start:hover .gantt_line_wrapper div {
            box-shadow: 0 0 5px 0px #7576ba;
        }

        .gantt_task_link.finish_to_start .gantt_link_arrow_right {
            border-left-color: #7576ba;
        }


        .gantt_task_link.finish_to_finish .gantt_line_wrapper div {
            background-color: #55d822;
        }

        .gantt_task_link.finish_to_finish:hover .gantt_line_wrapper div {
            box-shadow: 0 0 5px 0px #55d822;
        }

        .gantt_task_link.finish_to_finish .gantt_link_arrow_left {
            border-right-color: #55d822;
        }
    </style>
</head>
<body>
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
         <div class="well well-sm well-light">
        <!-- seleciona o projeto-->
        <div class="col-xs-11">
            <select class="select2" id="project" name="project">
                <asp:Literal ID="selecionaprojeto" runat="server"></asp:Literal>
            </select>
        </div>
        <div class="btn-header transparent pull-right">
            <input type="button" class="btn btn-success" id="create" onclick="GenrateGantt()" value="Create" />
        </div>
        <br />
        <br />
        
       <div class="well" id="wid-id-1" data-widget-editbutton="false" data-widget-fullscreenbutton="false">
            <div id="gantt_here" style=' height:390px;'></div>
           </div>
            <script type="text/javascript">
                
            </script>
            <!--tabela-->
        </div>
    </div>

    <script type="text/javascript">

        pageSetUp();
        var pagefunction = function () {
        };

        // run pagefunction on load

        pagefunction();
    </script>
</body>
</html>
