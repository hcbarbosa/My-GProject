
var res;
var tp;
var idr;

function EditResource(id, tipo) {    
    tp = tipo;
    idr = id;

    if (tipo == 1)
    {

        return $.ajax({
            dataType: "json",
            url: "../Ajax/GetResourceHuman.aspx?id=" + id + "&acao=edit",


            success: function (data) {
               
                if (data != null) {
                    $.each(data, function (index, recurso) {
                        res = {
                            'descricao': recurso.descricao, 'tipo': recurso.tipo, 'hora':recurso.hora, 'valor':recurso.valor };
                        TableResourceEdit(res);
                    });
                }      
            }
        });
    }
    else if(tipo == 2)
    {
        return $.ajax({
            dataType: "json",
            url: "../Ajax/GetResourceMaterial.aspx?id=" + id + "&acao=edit",

            success: function (data) {

                if (data != null) {
                    $.each(data, function (index, recurso) {
                        res = {
                            'descricao': recurso.descricao, 'tipo': recurso.tipo, 'unidade': recurso.unidade, 'valor': recurso.valor
                        };
                        TableResourceEdit(res);
                    });
                }
            }
        });
    }
}

function TableResourceEdit(res) {
    if (tp == 1) {
        document.getElementById("teste").innerHTML = "<table class='table table-hover'>" +
          "<thead>" +
          "<tr>" +
          "<th class='col col-xs-4'>Information</th>" +
          "<th class='col col-xs-8'></th> " +
          "</tr>" +
          "</thead>" +
          "<tbody>" +
          "<tr>" +
          "<td> Description:</td>" +
          "<td> " + res.descricao + "</td> " +
          "</tr>" +
          "<tr>" +
          "<td> Type: </td>" +
          "<td>" + res.tipo + "</td> " +
          "</tr>" +
          "<tr>" +
          "<td> Quantity:</td>" +
          "<td>" + res.hora + " hr.</td>  " +
          "</tr>" +
          "<tr>" +
          "<td> Value</td>" +
          "<td>" + res.valor + "</td>" +
          "</tr>" +

          "</tbody>" +
          "</table>";
    }
    else if (tp == 2) {
        document.getElementById("teste").innerHTML = "<table class='table table-hover'>" +
          "<thead>" +
          "<tr>" +
          "<th class='col col-xs-4'>Information</th>" +
          "<th class='col col-xs-8'></th> " +
          "</tr>" +
          "</thead>" +
          "<tbody>" +
          "<tr>" +
          "<td> Description:</td>" +
          "<td> " + res.descricao + "</td> " +
          "</tr>" +
          "<tr>" +
          "<td> Type: </td>" +
          "<td>" + res.tipo + "</td> " +
          "</tr>" +
          "<tr>" +
          "<td> Quantity:</td>" +
          "<td>" + res.unidade + " unid.</td>  " +
          "</tr>" +
          "<tr>" +
          "<td> Value</td>" +
          "<td>" + res.valor + "</td>" +
          "</tr>" +

          "</tbody>" +
          "</table>";
    }
};



function FormResourceEdit()
{
    if (tp == 1) {
        document.getElementById("FormItens").innerHTML = " <div class='row'>  <input type='hidden' value='" + idr + "' name='idRecurso'/><input type='hidden' value='" + tp + "' name='idtype'/>" +
                                                        "<section class='col col-6'> " +
                                                             "<label class='input'> Type: <h4>" + res.tipo + "</h4></label></section>" +
                                                        "<section class='col col-6'> " +
                                                            "<label class='input'> Quantity:" +
                                                            " <input type='time' class='form-control' required='required' title='Please enter number' name='hora' id='hora' value='" + res.hora + "'/>  " +
                                                            "</label>" +
                                                        "</section>	</div>" +
                                                        "<div class='row'>" +
                                                        "<section class='col col-6'>" +
                                                            "<label class='input'> Description:" +
                                                            "<textarea class='form-control' rows='2' name='description' >" + res.descricao + "</textarea>" +
                                                            "</label>" +
                                                        "</section>" +
                                                        "<section class='col col-6'> " +
                                                            "<label class='input'> Value (R$):	" +
                                                            "<input type='text' name='value' id='value' maxlength='13' class='form-control'  dir='rtl' value='" + res.valor + "'/>" +
                                                            "</label>" +
                                                        "</section></div>";
    }
    else if (tp == 2) {
        document.getElementById("FormItens").innerHTML = " <div class='row'>  <input type='hidden' value='" + idr + "' name='idRecurso'/><input type='hidden' value='" + tp + "' name='idtype'/>" +
                                                       "<section class='col col-6'> " +
                                                            "<label class='input'> Type: <h4>" + res.tipo + "</h4></label></section>" +
                                                       "<section class='col col-6'> " +
                                                           "<label class='input'> Quantity:" +
                                                           " <input type='text' class='form-control' required='required' title='Please enter number' name='unidade' id='unidade' min='0' value='" + res.unidade + "'/>  " +
                                                           "</label>" +
                                                       "</section>	</div>" +
                                                       "<div class='row'>" +
                                                       "<section class='col col-6'>" +
                                                           "<label class='input'> Description:" +
                                                           "<textarea class='form-control' rows='2' name='description' >" + res.descricao + "</textarea>" +
                                                           "</label>" +
                                                       "</section>" +
                                                       "<section class='col col-6'> " +
                                                           "<label class='input'> Value (R$):	" +
                                                           "<input type='text' name='value' id='value' maxlength='13' class='form-control' dir='rtl' value='" + res.valor + "'/>" +
                                                           "</label>" +
                                                       "</section></div>";
    }

    $("#value").maskMoney();
    $("#unidade").maskMoney();
};

function UpdateResource() {
    $("#orderform1").submit(function (event) {        
    });
}

function DeleteResource(id, tipo, desc) {
    idr = id;
    tp = tipo;
    document.getElementById("recurso").innerHTML = "<h3>" + desc + "</h3>";
}

function DeleteResourceYes() {

    if (tp == 1) {
        return $.ajax({
            dataType: "json",
            url: "../Ajax/GetResourceHuman.aspx?id=" + idr + "&acao=delete",
            success: location.reload()

        });
    }
    else if (tp == 2) {
        return $.ajax({
            dataType: "json",
            url: "../Ajax/GetResourceMaterial.aspx?id=" + idr + "&acao=delete",
            success: location.reload()
        });
    }
}

function mostraQtd() {
    // mudar quantity referente ao tipo de recurso   
        var idtipo = $('#type').val();

        if (idtipo == 1) {
            document.getElementById('hora').style.display = 'block';
            document.getElementById('unidade').style.display = 'none';
        }
        else if (idtipo == 2)
        {
            document.getElementById('unidade').style.display = 'block';
            document.getElementById('hora').style.display = 'none';
        }
        return false;
    };


// pagefunction

var pagefunction = function () {

    $("#value").maskMoney();
    $("#unidade").maskMoney();
    /* BASIC ;*/
    var responsiveHelper_dt_basic = undefined;
    var responsiveHelper_datatable_fixed_column = undefined;
    var responsiveHelper_datatable_col_reorder = undefined;
    var responsiveHelper_datatable_tabletools = undefined;

    var breakpointDefinition = {
        tablet: 1024,
        phone: 480
    };

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

    /* END BASIC */


    /* COLUMN SHOW - HIDE */
    $('#datatable_col_reorder').dataTable({
        "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6'f><'col-sm-6 col-xs-6 hidden-xs'C>r>" +
                "t" +
                "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-sm-6 col-xs-12'p>>",
        "autoWidth": true,
        "preDrawCallback": function () {
            // Initialize the responsive datatables helper once.
            if (!responsiveHelper_datatable_col_reorder) {
                responsiveHelper_datatable_col_reorder = new ResponsiveDatatablesHelper($('#datatable_col_reorder'), breakpointDefinition);
            }
        },
        "rowCallback": function (nRow) {
            responsiveHelper_datatable_col_reorder.createExpandIcon(nRow);
        },
        "drawCallback": function (oSettings) {
            responsiveHelper_datatable_col_reorder.respond();
        }
    });

    /* END COLUMN SHOW - HIDE */

    $.widget("ui.dialog", $.extend({}, $.ui.dialog.prototype, {
        _title: function (title) {
            if (!this.options.title) {
                title.html("&#160;");
            } else {
                title.html(this.options.title);
            }
        }
    }));


    /*
           * DIALOG SIMPLE
           */

    // Dialog click
    $('#new').click(function () {
        $('#registerresource').dialog('open');
        return false;

    });

    $('.view').click(function () {
        $('#viewresource').dialog('open');
        var formview = document.getElementById("orderform1");
        formview.style.display = 'none';
        var tab = document.getElementById("table1");
        tab.style.display = 'block';
        var botaoedit = document.getElementById("edit");
        botaoedit.style.display = 'block';
        return false;

    });

    $('.delete').click(function () {
        $('#deleteresource').dialog('open');
        return false;
    });

    $('#edit').click(function () {
        var tab = document.getElementById("table1");
        tab.style.display = 'none';
        var formview = document.getElementById("orderform1");
        formview.style.display = 'block';
        var botaoedit = document.getElementById("edit");
        botaoedit.style.display = 'none';
    });

    $('#cancelview').click(function () {
        var formview = document.getElementById("orderform1");
        formview.style.display = 'none';
        //limpa o html
        $("#FormItens").empty();
        var tab = document.getElementById("table1");
        tab.style.display = 'block';
        var botaoedit = document.getElementById("edit");
        botaoedit.style.display = 'block';
    });   

    $('#cancel').click(function () {
        $('#registerresource').dialog("close");
    });

    $('#registerresource').dialog({
        autoOpen: false,
        width: 900,
        resizable: true,
        modal: true,
        title: "<div class='widget-header'><h4><i class='fa fa-pencil'></i> Register Resource</h4></div>",
        position: 'center',

    });

    $('#viewresource').dialog({
        autoOpen: false,
        width: 900,
        resizable: true,
        modal: true,
        top:10,
        title: "<div class='widget-header'><h4><i class='fa fa-eye'></i>Resource</h4></div>",
        position: 'fixed',

    });

    $('#deleteresource').dialog({
        autoOpen: false,
        width: 400,
        resizable: true,
        modal: true,
        title: "<div class='widget-header'><h4><i class='fa fa-pencil'></i> Delete Resource</h4></div>",
        position: 'center',
        buttons: [{
            html: "No",
            "class": "btn btn-danger",
            click: function () {
                $(this).dialog("close");
            }
        }, {
            html: "Yes",
            "class": "btn btn-success",
            click: function () {
                DeleteResourceYes();
            }
        }]
    });

    $(function () {
        // Validation
        $("#orderform").validate({
            // Rules for form validation
            rules: {
                type: {
                    required: true
                },
                description: {
                    required: true
                },
                value: {
                    required: true
                },
                hora: {
                    required: true
                },
                unidade: {
                    required:true
                }

            },

            // Messages for form validation
            messages: {
                type: {
                    required: 'Please select one type'
                },
                description: {
                    required: 'Please enter with description'
                },
                value: {
                    required: 'Please enter with value'
                },
                hora: {
                    required: 'Please enter with hours'
                },
                unidade: {
                    required: 'Please enter with number of unities'
                }

            },

            // Do not change code below
            errorPlacement: function (error, element) {
                error.insertAfter(element.parent());
            }

        });

        $("#orderform1").validate({
            // Rules for form validation
            rules: {
                type: {
                    required: true
                },
                description: {
                    required: true
                },
                description: {
                    required: true
                },
                value: {
                    required: true
                },
                hora: {
                    required: true
                },
                unidade: {
                    required: true
                }

            },

            // Messages for form validation
            messages: {
                type: {
                    required: 'Please select one type'
                },
                description: {
                    required: 'Please enter with description'
                },
                value: {
                    required: 'Please enter with value'
                },
                hora: {
                    required: 'Please enter with hours'
                },
                unidade: {
                    required: 'Please enter with number of unities'
                }
            },

            // Do not change code below
            errorPlacement: function (error, element) {
                error.insertAfter(element.parent());
            }

        });
    });

};// end pagefunction

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


