$('#modelconfirm').append("No");
$('#divconfirm').append("Please, enter step and activity");
$('#divcriafase').append("Please, before create one step");

var codigo, nome, contfase=0,contativ=0;
var namep = "", startp = "",startpcomp = "",  finishp = "", finishpcomp = "", valuep = "", companyp = "", customerp = "";
//preenche o confirm apos perder foco
$('#name').focusout(function () {
    $('#pjname').empty();
    $('#pjname').append("" + $('#name').val() + "");

    $('#pjnameconfirm').empty();
    $('#pjnameconfirm').append("" + $('#name').val() + "");

    $('#nameconfirm').empty();
    $('#nameconfirm').append($('#name').val());
    namep = "";
    namep = $('#name').val();

    if (namep != "" && startp != "" && finishp != "" && valuep != "" && companyp != "" && customerp != ""  && startp <= finishp && contativ != 0 && contfase!=0) {
        document.getElementById("confirm").disabled = false;
        $('#divconfirm').empty();
    }
    else {
        $('#divconfirm').empty();
        $('#divconfirm').append("Please, enter Basic Information");
    }
});

$('#startdate').focusout(function () {
    $('#startconfirm').empty();
    var data = $('#startdate').val()
    var ano = data.slice(0, 4);
    var mes = data.slice(5, 7);
    var dia = data.slice(8, 10);
    startpcomp = "" + dia + "/" + mes + "/" + ano;
    $('#startconfirm').append(""+dia+"/"+mes+"/"+ano);
    startp = "";
    startp = $('#startdate').val();
    if (namep != "" && startp != "" && finishp != "" && valuep != "" && companyp != "" && customerp != "" && startp <= finishp && contativ != 0 && contfase != 0) {
        document.getElementById("confirm").disabled = false;
        $('#divconfirm').empty();
    }
    else {
        $('#divconfirm').empty();
        $('#divconfirm').append("Please, enter Basic Information");
    }
});

$('#finishdate').focusout(function () {
    if ($('#finishdate').val() >= $('#startdate').val()) {
        $('#divfinishdatep').empty();
        $('#finishconfirm').empty();
        var data = $('#finishdate').val()
        var ano = data.slice(0, 4);
        var mes = data.slice(5, 7);
        var dia = data.slice(8, 10);
        finishpcomp = "" + dia + "/" + mes + "/" + ano;
        $('#finishconfirm').append("" + dia + "/" + mes + "/" + ano);
        finishp = "";
        finishp = $('#finishdate').val();
        if (namep != "" && startp != "" && finishp != "" && valuep != "" && companyp != "" && customerp != "" && startp <= finishp) {
            document.getElementById("confirm").disabled = false;
            $('#divconfirm').empty();
        }
        else {
            $('#divconfirm').empty();
            $('#divconfirm').append("Please, enter Basic Information");
        }
    }
    else {
        $('#divfinishdatep').empty();
        $('#divfinishdatep').append("Expiry Date < Start Date ");
    }
});

$('#valuetotal').focusout(function () {
    $('#valueconfirm').empty();
    $('#valueconfirm').append(($('#valuetotal').val()));
    valuep = "";
    valuep = $('#valuetotal').val();
    if (namep != "" && startp != "" && finishp != "" && valuep != "" && companyp != "" && customerp != "" && startp <= finishp && contativ != 0 && contfase != 0) {
        document.getElementById("confirm").disabled = false;
        $('#divconfirm').empty();
    }
    else {
        $('#divconfirm').empty();
        $('#divconfirm').append("Please, enter Basic Information");
    }
});

$('#model').change(function () {
    $('#modelconfirm').empty();
    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetProject.aspx?model="+ $('#model').val() + "",

        success: function (data) {
            if (data != null) {
                $.each(data, function (index, m) {
                    var op = {
                        'name': m.name
                    };              
                    $('#modelconfirm').append(op.name);
                });
            }
        }
    });
});

$('#company').change(function () {
    $('#companyconfirm').empty();
    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetProject.aspx?company=" + $('#company').val() + "",

        success: function (data) {
            if (data != null) {
                $.each(data, function (index, m) {
                    var op = {
                        'name': m.name
                    };
                    $('#companyconfirm').append(op.name);
                    companyp = "";
                    companyp = op.name;
                    if (namep != "" && startp != "" && finishp != "" && valuep != "" && companyp != "" && customerp != "" && startp <= finishp && contativ != 0 && contfase != 0) {
                        document.getElementById("confirm").disabled = false;
                        $('#divconfirm').empty();
                    }
                    else {
                        $('#divconfirm').empty();
                        $('#divconfirm').append("Please, enter Basic Information");
                    }
                });
            }
        }
    });
  
});

$('#customers').change(function () {
    if ($('#customers').val() != null && $('#customers').val() != "") {
        $('#customerconfirm').empty();
        return $.ajax({
            dataType: "json",
            url: "../Ajax/GetProject.aspx?customers=" + $('#customers').val() + "",

            success: function (data) {
                if (data != null) {
                    $.each(data, function (index, m) {
                        var op = {
                            'clientes': m.clientes
                        };
                        $('#customerconfirm').append(op.clientes);
                        customerp = "";
                        customerp = op.clientes;
                        if (namep != "" && startp != "" && finishp != "" && valuep != "" && companyp != "" && customerp != "" && startp <= finishp && contativ != 0 && contfase != 0) {
                            document.getElementById("confirm").disabled = false;
                            $('#divconfirm').empty();
                        }
                        else {
                            $('#divconfirm').empty();
                            $('#divconfirm').append("Please, enter Basic Information");
                        }
                    });
                }
            }
        });
    }
});

//novas fases e atividades
$('#newstep').click(function () {
    document.getElementById("formnewstep").style.display = "block";
   
});

$('#cancelstep').click(function () {
    document.getElementById("formnewstep").style.display = "none";
    document.getElementById("stepname").value = "";
    document.getElementById("stepdescription").value = "";
    document.getElementById("stepstartdate").value = "";
    document.getElementById("stepfinishdate").value = "";
    $('#divfinishstep').empty();
    $('#divstartstep').empty();
    $('#divdescstep').empty();
    $('#divnamestep').empty();
});

$('#newactiv').click(function () {
    document.getElementById("formnewactiv").style.display = "block";    
});

$('#cancelactiv').click(function () {
    document.getElementById("formnewactiv").style.display = "none";
    document.getElementById("actname").value = "";
    document.getElementById("actdescription").value = "";
    document.getElementById("actstar").value = "";
    document.getElementById("actfinish").value = "";
    document.getElementById("qtdhours").value = "";
    $('#divfinishact').empty();
    $('#divstartact').empty();
    $('#divdescact').empty();
    $('#divnameact').empty();
    $('#divhouract').empty();
    $('#divfaseescolhida').empty();
});

$('#okstep').click(function () {  

    var name = document.getElementById("stepname").value;
    var descricao = document.getElementById("stepdescription").value;
    var datainicio = document.getElementById("stepstartdate").value;
    var datafinal = document.getElementById("stepfinishdate").value;
    if (name == "" && descricao == "" && datainicio == "" && datafinal == "") {
        $('#divfinishstep').empty();
        $('#divstartstep').empty();
        $('#divdescstep').empty();
        $('#divnamestep').empty();
        $('#divfinishstep').append("Please, enter expiry date");
        $('#divstartstep').append("Please, enter start date");
        $('#divdescstep').append("Please, enter description");
        $('#divnamestep').append("Please, enter name");
    }
    else if (name != null && name != "" && descricao != null && descricao != "" && datainicio != null && datafinal != null && datainicio != "" && datafinal != "" && datafinal >= datainicio && datafinal <= finishp && datafinal >= startp && datainicio <= finishp && datainicio >= startp) {
                    return $.ajax({
                        dataType: "json",
                        url: "../Ajax/GetProject.aspx?stepname=" + name + "&stepdescr=" + descricao + "&stepstart=" + datainicio + "&stepfinish=" + datafinal + "",

                        success: function (data) {
                            if (data != null) {
                                $.each(data, function (index, p) {
                                    var op = {
                                        'fase': p.fase, 'numero': p.numero, 'treesteps': p.treesteps, 'curActivity': p.curActivity
                                    };
                                    $('#steps').append(op.fase);
                                    $('#treesteps').append(op.treesteps);
                                    $('#treestepsconfirm').empty();
                                    $('#treestepsconfirm').append($('#treesteps').html());
                                    $('#curActivity').append(op.curActivity);
                                    document.getElementById("formnewstep").style.display = "none";
                                    document.getElementById("stepname").value = "";
                                    document.getElementById("stepdescription").value = "";
                                    document.getElementById("stepstartdate").value = "";
                                    document.getElementById("stepfinishdate").value = "";
                                    if (contfase == 0) {
                                        document.getElementById("newactiv").style.display = "block";
                                        document.getElementById("reqsteps").value = 1;
                                    }
                                    if (contativ == 0) {
                                        $('#divconfirm').empty();
                                        $('#divconfirm').append("Please, enter 1 activity");
                                        contfase++;
                                        $('#divcriafase').empty();                                        
                                    }
                                    
                                });
                            }
                        }
                    });
    }                  
      
});

$('#stepname').focusout(function () {
    if (document.getElementById("stepname").value != null && document.getElementById("stepname").value != "") {
        $('#divnamestep').empty();
    }
    else {
     $('#divnamestep').empty();
     $('#divnamestep').append("Please, enter name");
    }
});

$('#stepdescription').focusout(function () {
    if (document.getElementById("stepdescription").value != null && document.getElementById("stepdescription").value != "") {
        $('#divdescstep').empty();
    }
    else {
        $('#divdescstep').empty();
        $('#divdescstep').append("Please, enter description");
    }
});

$('#stepstartdate').focusout(function () {
    if (document.getElementById("stepstartdate").value != null && document.getElementById("stepstartdate").value != "") {
        if (document.getElementById("stepstartdate").value >= startp && document.getElementById("stepstartdate").value <= finishp) {
            $('#divstartstep').empty();
        }
        else {
            $('#divstartstep').empty();
            $('#divstartstep').append("Invalid(to:"+startpcomp+".."+finishpcomp+")");
        }
    }
    else {
        $('#divstartstep').empty();
        $('#divstartstep').append("Please, enter start date");
    }
});

$('#stepfinishdate').change(function () {
    if (document.getElementById("stepfinishdate").value != null && document.getElementById("stepfinishdate").value != "") {
        if (document.getElementById("stepfinishdate").value >= document.getElementById("stepstartdate").value) {
            if (document.getElementById("stepfinishdate").value >= startp && document.getElementById("stepfinishdate").value <= finishp) {
                $('#divfinishstep').empty();
            }
            else {
                $('#divfinishstep').empty();
                $('#divfinishstep').append("Invalid(to:" + startpcomp + ".." + finishpcomp + ")");
            }
        }
        else {
            $('#divfinishstep').empty();
            $('#divfinishstep').append("Expiry < Start date");
        }
    }
    else {
        $('#divfinishstep').empty();
        $('#divfinishstep').append("Please, enter expiry date");
    }    
});

$('#okactiv').click(function () {

    var name = document.getElementById("actname").value;
    var descricao = document.getElementById("actdescription").value;
    var datainicio = document.getElementById("actstart").value;
    var datafinal = document.getElementById("actfinish").value;
    var horas = document.getElementById("qtdhours").value;
    var e = document.getElementById("curActivity");
    var faseescolhida = e.options[e.selectedIndex].value;
    if (name == "" && descricao == "" && datainicio == "" && datafinal == "" && horas == "" && faseescolhida == 0) {
        $('#divfinishact').empty();
        $('#divstartact').empty();
        $('#divdescact').empty();
        $('#divnameact').empty();
        $('#divhouract').empty();
        $('#divfaseescolhida').empty();
        $('#divfinishact').append("Please, enter expiry date");
        $('#divstartact').append("Please, enter start date");
        $('#divdescact').append("Please, enter description");
        $('#divnameact').append("Please, enter name");
        $('#divhouract').append("Please, enter hours");
        $('#divfaseescolhida').append("Please, choose the step");
    }
    else if (faseescolhida != 0 && name != null && name != "" && descricao != null && descricao != "" && datainicio != null && datafinal != null && datainicio != "" && datafinal != "" && datafinal >= datainicio && datafinal <= finishp && datafinal >= startp && datainicio <= finishp && datainicio >= startp && horas != null && horas!= "") {

        return $.ajax({
            dataType: "json",
            url: "../Ajax/GetProject.aspx?actname=" + name + "&actdescr=" + descricao + "&actstart=" + datainicio + "&actfinish=" + datafinal + "&qtdhours=" + horas + "",

            success: function (data) {
                if (data != null) {
                    $.each(data, function (index, p) {
                        var op = {
                            'act': p.act, 'actid': p.actid
                        };
                        $('#' + $('#curActivity').val()).append(op.act);
                        $('#divActivities').append("<input type='hidden' name='" + $('#curActivity').val() + "_activity[]' value='" + op.actid + "'/>");
                        $('#treestepsconfirm').empty();
                        $('#treestepsconfirm').append($('#treesteps').html());
                        document.getElementById("formnewactiv").style.display = "none";
                        document.getElementById("actname").value = "";
                        document.getElementById("actdescription").value = "";
                        document.getElementById("actstart").value = "";
                        document.getElementById("actfinish").value = "";
                        document.getElementById("qtdhours").value = "";
                        if (contativ == 0 ) {
                            $('#divconfirm').empty();
                            document.getElementById("reqact").value = 1;
                        }
                        if (namep != "", startp != "", finishp != "", valuep != "", companyp != "", customerp != "") {
                            document.getElementById("confirm").disabled = false;
                        }
                        else {
                            $('#divconfirm').empty();
                            $('#divconfirm').append("Please, enter Basic Information");
                        }
                    });
                }
            }
        });
    }
});

$('#curActivity').change(function () {
    if (document.getElementById("curActivity").value != 0) {
        $('#divfaseescolhida').empty();
    }
    else {
        $('#divfaseescolhida').empty();
        $('#divfaseescolhida').append("Please, choose the step");
    }
});


$('#actname').focusout(function () {
    if (document.getElementById("actname").value != null && document.getElementById("actname").value != "") {
        $('#divnameact').empty();
    }
    else {
        $('#divnameact').empty();
        $('#divnameact').append("Please, enter name");
    }
});

$('#actdescription').focusout(function () {
    if (document.getElementById("actdescription").value != null && document.getElementById("actdescription").value != "") {
        $('#divdescact').empty();
    }
    else {
        $('#divdescact').empty();
        $('#divdescact').append("Please, enter description");
    }
});

$('#actstart').focusout(function () {
    if (document.getElementById("actstart").value != null && document.getElementById("actstart").value != "") {
        if (document.getElementById("actstart").value >= startp && document.getElementById("actstart").value <= finishp) {
            $('#divstartact').empty();
        }
        else {
            $('#divstartact').empty();
            $('#divstartact').append("Invalid(to:" + startpcomp + ".." + finishpcomp + ")");
        }
    }
    else {
        $('#divstartact').empty();
        $('#divstartact').append("Please, enter start date");
    }
});

$('#actfinish').change(function () {
    if (document.getElementById("actfinish").value != null && document.getElementById("actfinish").value != "") {
        if (document.getElementById("actfinish").value >= document.getElementById("actstart").value) {
            if (document.getElementById("actfinish").value >= startp && document.getElementById("actfinish").value <= finishp) {
                $('#divfinishact').empty();
            }
            else {
                $('#divfinishact').empty();
                $('#divfinishact').append("Invalid(to:" + startpcomp + ".." + finishpcomp + ")");
            }
        }
        else {
            $('#divfinishact').empty();
            $('#divfinishact').append("Expiry date < Start date");
        }
    }
    else {
        $('#divfinishact').empty();
        $('#divfinishact').append("Please, enter expiry date");
    }
});

$('#qtdhours').focusout(function () {
    if (document.getElementById("qtdhours").value != null && document.getElementById("qtdhours").value != "") {
        $('#divhouract').empty();
    }
    else {
        $('#divhouract').empty();
        $('#divhouract').append("Please, enter hours");
    }
});

function preenche() {
    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetProject.aspx?acao=preenche",

        success: function (data) {
            if (data != null) {
                $.each(data, function (index, p) {
                    var op = {
                        'companies': p.companies, 'modelos': p.modelos
                    };
                    document.getElementById("company").innerHTML = "<option selected='selected' disabled='disabled'>Select Company</option>" + op.companies;
                    document.getElementById("model").innerHTML = "<option selected='selected' disabled='disabled'>Select Model</option>" + op.modelos;

                    $(document).ready(function () {
                        // coloca o evento pra mudar os clientes, quando vc mudar a empresa
                        $('#select').change(function () {
                            buscaCliente('company', 'customers');
                        });
                        
                        $("#valuetotal").maskMoney();
                    })

                });
            }
        }
    });
}

buscaCliente = function (select_do_cliente, campo) {
    var empresacodigo, elemento, img_html, options = "";
    elemento = $("#" + select_do_cliente);
    empresacodigo = $(elemento).val();
    if (empresacodigo) {
        return $.ajax({
            dataType: "json",
            url: "../Ajax/GetProject.aspx?empresa= " + empresacodigo,

            success: function (data) {
                if (data != null) {
                    $.each(data, function (index, c) {
                        options += '<option value="' + c.id + '">' + c.nome + '</option>';
                    });
                }
                return $('#' + campo).empty().append(options);
            }

        });
    } else {
        return elemento.parent().append("<label class='empresacodigo error'>Company invalid</label>");
    }
};

function DeleteProject(cod, name) {
    codigo = cod;
    nome = name;
    document.getElementById("nomeprojetodelete").innerHTML = "<h3>" + nome + "</h3>";
    document.getElementById("deleteproject").style.display = "block";
    $('#deleteproject').dialog('open');
    return false;

};

function AtivarProject(cod, name) {
    codigo = cod;
    nome = name;
    document.getElementById("nomeprojetoativar").innerHTML = "<h3>" + nome + "</h3>";
    document.getElementById("ativarproject").style.display = "block";
    $('#ativarproject').dialog('open');
    return false;

};

function DeleteYesProject() {
    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetProject.aspx?acao=delete&codigo= " + codigo,

        success: location.reload()
    });
}


function AtivarYesProject() {
    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetProject.aspx?acao=ativar&codigo= " + codigo,

        success: location.reload()
    });
}

function btnViewModel(proj) {
    codigo = proj;
    document.getElementById("viewmodel").style.display = 'block';
    $('#viewmodel').dialog('open');
    preencheviewmodel();
}

$('#viewmodel').dialog({
    autoOpen: false,
    width: 500,
    resizable: true,
    modal: true,
    title: "<div class='widget-header'><h4><i class='fa fa-eye'></i>Model</h4></div>",
    position: 'center',
});

function preencheviewmodel() {
    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetListProject.aspx?acao=preenchemodel&projeto=" + codigo,

        success: function (data) {
            if (data != null) {
                $.each(data, function (index, p) {
                    var op = {
                        'name': p.name, 'desc': p.desc, 'numero': p.numero
                    };
                    var texto = "<table><tr class='col-xs-12'><td class='col-xs-4'><b>Number: </b></td><td>" + op.numero + "</td></tr>" +
                                        "<tr class='col-xs-12'><td class='col-xs-3'><b>Name: </b></td><td>" + op.name + "</td></tr>" +
                                        "<tr class='col-xs-12'><td class='col-xs-4'><b>Description: </b></td><td>" + op.desc + "</td></tr></table>";
                    $('#viewmodel').empty();
                    $('#viewmodel').append(texto);
                });
            }
        }
    });
}

function Open(cod) {
    window.location = 'Index.aspx#ListProject.aspx?codigo='+cod;    
}


// pagefunction	
var pagefunction = function () {


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
        document.getElementById("registerproject").style.display = "block";
        $('#registerproject').dialog('open');
        preenche();
        return false;

    });

    
    $('#registerproject').dialog({
        autoOpen: false,
        width: 900,
        resizable: true,
        modal: true,
        title: "<div class='widget-header'><h4><i class='fa fa-pencil'></i> Register Project</h4></div>",
        position: 'center',

    });

    $('#deleteproject').dialog({
        autoOpen: false,
        width: 400,
        resizable: true,
        modal: true,
        title: "<div class='widget-header'><h4><i class='fa fa-pencil'></i> Cancel Project</h4></div>",
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
                DeleteYesProject();
            }
        }]
    });

    $('#ativarproject').dialog({
        autoOpen: false,
        width: 400,
        resizable: true,
        modal: true,
        title: "<div class='widget-header'><h4><i class='fa fa-pencil'></i> Reactivate Project</h4></div>",
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
                AtivarYesProject();
            }
        }]
    });

 

    // load bootstrap wizard

    loadScript("../Js/plugin/bootstrap-wizard/jquery.bootstrap.wizard.min.js", runBootstrapWizard);

    //Bootstrap Wizard Validations

    function runBootstrapWizard() {

        var $validator = $("#wizard1").validate({

            rules: {

                name: {
                    required: true
                },
                startdate: {
                    required: true
                },
                finishdate: {
                    required: true
                },
                valuetotal: {
                    required: true
                },
                company: {
                    required: true
                },
                customers: {
                    required: true
                },
                resources: {
                    required: true
                }
            },

            messages: {
                name: {
                    required: 'Please enter your name'
                },
                startdate: {
                    required: 'Please enter your start date'
                },
                finishdate: {
                    required: 'Please enter your expiry date'                    
                },
                valuetotal: {
                    required: 'Please enter total value'
                },
                company: {
                    required: 'Please enter company'
                },
                customers: {
                    required: 'Please enter customers'
                },
                resources: {
                    required: 'Please enter resources'
                }
                
            },

            highlight: function (element) {
                $(element).closest('.form-group').removeClass('has-success').addClass('has-error');
            },
            unhighlight: function (element) {
                $(element).closest('.form-group').removeClass('has-error').addClass('has-success');
            },
            errorElement: 'span',
            errorClass: 'help-block',
            errorPlacement: function (error, element) {
                if (element.parent('.input-group').length) {
                    error.insertAfter(element.parent());
                } else {
                    error.insertAfter(element);
                }
            }
        });

        $('#bootstrap-wizard1').bootstrapWizard({

            'tabClass': 'form-wizard',
            'onNext': function (tab, navigation, index) {
                var $valid = $("#wizard1").valid();
                if (!$valid) {
                    $validator.focusInvalid();
                    return false;
                } else {
                    $('#bootstrap-wizard1').find('.form-wizard').children('li').eq(index - 1).addClass('complete');
                    $('#bootstrap-wizard1').find('.form-wizard').children('li').eq(index - 1).find('.step').html('<i class="fa fa-check"></i>');
                }
            }
        });

    };


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
