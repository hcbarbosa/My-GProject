

function createreport() {

    var projeto = $('#project').val();
    $('#dados').empty();

    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetReport.aspx?projeto=" + projeto,


        success: function (data) {
           
            if (data != null) {
               
                $.each(data, function (index, dados) {
                    
                    ShowReport(dados);
                    Grafico(dados);
                   // Load();

                    
                });
            }

           
        },
        error: function () {
            
        }
    });
 
}

function Grafico(dados) {
    //alert(dados.fases);
    
    var teste = [{x:'teste',y:9}];
    // bar graph color
    if ($('#bar-graph').length) {

        Morris.Bar({
            element: 'bar-graph',
            data: dados.fases,
            xkey: 'x',
            ykeys: ['y'],
            labels: ['%'],
            barColors: function (row, series, type) {
                if (type === 'bar') {
                    var green = Math.ceil(150 * row.y / this.ymax);
                    return 'rgb(0,' + green + ',0)';
                }
                else {
                    return '#000';
                }
            }
        });
    }
    Load();
}
function ShowReport(p) {

    $('#dados').append("<div id='report' class='well'><div><div class='easy-pie-chart txt-color-green easyPieChart' data-percent='" +p.porc_completo+ "' data-pie-size='220'>"+
						"<span class='percent percent-sign txt-color-green font-xl semi-bold'>" + p.porc_completo + "</span> completed"+
    "</div>"+
    "       <table class='table table-hover table-border' style='width:70%;float:right'>"+
    " <thead>"+
    "                            <tr>"+
    "                                <th>Information</th>"+
    "                                <th></th>"+
    "                                <th></th>"+
    "                                <th></th>"+
    "                            </tr>"+
    "                        </thead>"+
    "                        <tbody>"+
    "                            <tr>"+
    "                                <td>Project:</td>"+
    "                                <td colspan='3'>" + p.nome + "</td>"+
    "                           </tr>"+
    "                            <tr>"+
    "                                <td>Customers:</td>"+
    "                                <td colspan='3'>" + p.clientes + "</td>"+
    "                           </tr>"+
    "                            <tr>"+
    "                                <td>Company:</td>"+
    "                                <td>" + p.company+ "</td>"+
    "                                <td>Model:</td>"+
    "                                <td>" + p.modelo + "</td>"+
    "                           </tr>"+
    "                            <tr>"+
    "                                <td>Start Date:</td>"+
    "                                <td>" + p.data_inicio + "</td>"+
    "                                <td>Expiry Date:</td>"+
    "                                <td>" + p.data_termino + "</td>"+
    "                            </tr> "+
    "                            <tr>"+
    "                                <td>Total Cost:</td>"+
    "                                <td>" + p.valor_previsto + "</td>"+
    "                                <td>Used Cost:</td>"+
    "                                <td>" + p.valor_utilizado + "</td>"+
    "                            </tr>                                  "+
    "                        </tbody>"+
    "                    </table>"+
    "                    </div><div class='col-xs-12' style='float:left' ><div class='widget-body no-padding'><div id='bar-graph' class='chart no-padding'></div> </div> </div></div>" );



    
}

function Load(){

    loadScript('../Js/plugin/morris/raphael.min.js', function () {
        loadScript('../Js/plugin/morris/morris.min.js', pagefunction);
    });
    pageSetUp();

}


function pagefunction() { }
pageSetUp();


