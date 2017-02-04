<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ProjetoInter.View.Home" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">

        <div class="col-xs-6">
            <table class="well table">
                <thead>
                    <tr>
                        <th><h4><b>Daily Activities</b></h4> </th>                        
                    </tr>
                </thead>
                <tbody style="background-color:#f5f5f5">
                   <asp:Literal ID="atividadesdodia" runat="server"></asp:Literal>
                </tbody>
            </table>  
        </div>

         
             <div class="col-xs-6">
                	                                         
			        <div class="well no-padding">
                    <table class="table table-hover">
                                        <thead>
                                            <tr>
                                                <th><h4><b>Project Progress</b></h4> </th>
                                                <th class="col-xs-1"> <div class="bg-color-red" style="color:white;width:40px;"><center>Late</center></div></th>
                                                <th class="col-xs-1"><div class="bg-color-green" style="color:white;width:60px;"><center>Regular</center></div></th>
                                              </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                   </table>	
			        <div class="bar-holder">
                        <asp:Literal ID="listprojects" runat="server"></asp:Literal> 
	    	        </div>
                          <br /><br />
		        </div>
                 <br /><br />
		</div>
			</div>
             
<script type="text/javascript">

   
    pageSetUp();

    // PAGE RELATED SCRIPTS

    var pagefunction = function () {
        // Fill all progress bars with animation
        $('.progress-bar').progressbar({
            display_text: 'fill'
        });



    }
    // end pagefunction

    // load bootstrap-progress bar script and run pagefunction
    loadScript("../Js/plugin/bootstrap-progressbar/bootstrap-progressbar.min.js", pagefunction);
</script>


</body>
</html>
