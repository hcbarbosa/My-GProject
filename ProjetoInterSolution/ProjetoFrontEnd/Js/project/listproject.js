var codigo;
var recurso;
var atividade;

$('#tabs').tabs();

function ShowDocument(doc) {
    document.getElementById("visualizadocumento").style.display = "block";
    var d = document.getElementById("visualizadocumento");
    d.setAttribute("src", "../Documents/" + doc);
}

function comment(id, proj) {
    var c = document.getElementById("comentarioescrito").value;
    if (c != null && c != undefined && c != '') {
        codigo = proj;
        return $.ajax({
            dataType: "json",
            url: "../Ajax/GetListProject.aspx?acao=comment&projeto=" + codigo + "&comentario=" + c + "&id=" + id,

            success: function (data) {
                if (data != null) {
                    $.each(data, function (index, p) {
                        var r = {
                            'comentario': p.comentario, 'img': p.img, 'data': p.data, 'id': p.id, 'usuario': p.usuario
                        };
                        var com = "<li class='message'>" +
                                        "<img src='../Images/avatars/" + r.img + "' id='imgcomment' class='online' alt='' />" +
                                        "<div class='message-text'>" +
                                            "<time>" +
                                                r.data + "| " +
                                                "<button type='button' class='btn  btn-xs btn-danger remove' value='" + r.id + "'>" +
                                                                                "<span class='glyphicon glyphicon-remove'></span>" +
                                                                                "</button>" +
                                            "</time> <a href='javascript:void(0);' style='color:green' class='username'>" + r.usuario + "</a> " +
                                            r.comentario +
                                        "</div>" +
                                    "<br />" +
                                    "<br />" +
                                    "<hr />" +
                                    "</li>";
                        $('#listcomentarios').append(com);
                        $('#comentarioescrito').val('');
                    });

                }
            }
        });
    }
    else {
        $('#comentarioescrito').val('');
        $('#comentarioescrito').attr("placeholder", "Please, write here");
    }
}

function Edit(proj) {
    codigo = proj;
    $('#editproject').dialog('open');
    preenche();
    return false;
}


function preenche() {
    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetListProject.aspx?acao=preenche&projeto="+codigo,

        success: function (data) {
            if (data != null) {
                $.each(data, function (index, p) {
                    var op = {
                        'companies': p.companies, 'modelos': p.modelos, 'name': p.name, 'start':p.start , 'finish':p.finish, 'value':p.value, 'customers':p.customers
                    };
                    document.getElementById("company").innerHTML = op.companies;
                    document.getElementById("model").innerHTML = op.modelos;
                    $('#name').val(op.name);
                    $('#startdate').val(op.start);
                    $('#finishdate').val(op.finish);
                    $('#valuetotal').val(op.value);
                    document.getElementById("customers").innerHTML = op.customers;


                    $(document).ready(function () {
                        // coloca o evento pra mudar os clientes, quando vc mudar a empresa
                        $('#select').change(function () {
                            buscaCliente('company', 'customers');
                        });
                        $("#valuetotal").maskMoney();
                        pageSetUp();
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
            url: "../Ajax/GetListProject.aspx?empresa= " + empresacodigo,

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

function Model(proj) {
    codigo = proj;
    $('#registermodel').dialog('open');
}

function btnViewModel(proj) {
    codigo = proj;
    document.getElementById("viewmodel").style.display = 'block';
    $('#viewmodel').dialog('open');
    preencheviewmodel();
}

function btnEditModel(proj) {
    codigo = proj;
    document.getElementById("editmodel").style.display = 'block';
    $('#editmodel').dialog('open');
    preenchemodel();
}


function btnDeleteModel(proj) {
    codigo = proj;
    document.getElementById("deletemodel").style.display = 'block';
    $('#deletemodel').dialog('open');
    }

function preenchemodel()
{
    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetListProject.aspx?acao=preenchemodel&projeto=" + codigo,

        success: function (data) {
            if (data != null) {
                $.each(data, function (index, p) {
                    var op = {
                        'name': p.name, 'desc': p.desc
                    };
                    $('#editnamemodel').val('');
                    $('#editnamemodel').val(op.name);
                    $('#editdescmodel').empty();
                    $('#editdescmodel').append(op.desc);
                });
            }
        }
    });
}

function preencheviewmodel() {
    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetListProject.aspx?acao=preenchemodel&projeto=" + codigo,

        success: function (data) {
            if (data != null) {
                $.each(data, function (index, p) {
                    var op = {
                        'name': p.name, 'desc': p.desc, 'numero':p.numero
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

function EditYesModel() {
    var modelo = document.getElementById("editnamemodel").value;
    var descmodelo = document.getElementById("editdescmodel").value;
    if (modelo == "" && descmodelo == "") {
        $('#diveditnamemodel').empty();
        $('#diveditdescmodel').empty();
        $('#diveditdescmodel').append("Please enter description");
        $('#diveditnamemodel').append("Please enter name");
    }
    else
        if (modelo != null && modelo != undefined && modelo != "") {
            if (descmodelo != null && descmodelo != undefined && descmodelo != "") {
                return $.ajax({
                    dataType: "json",
                    url: "../Ajax/GetListProject.aspx?acao=alterar&modelo=" + modelo + "&desc=" + descmodelo + "&codigo=" + codigo,

                    success: location.reload()
                });
            }
            else {
                $('#diveditdescmodel').empty();
                $('#diveditdescmodel').append("Please enter description");
            }
        }
        else {
            $('#diveditnamemodel').empty();
            $('#diveditnamemodel').append("Please enter name");
        }
}

function DeleteYesModel() {
    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetListProject.aspx?acao=deletemodel&numero=" + codigo,

        success: location.reload()
    });
}


$(document).on('click', '.deleterecurso', function () {
    var rec = $(this).val();
    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetListProject.aspx?acao=deleterecurso&recat=" + rec,

        success: //$(this).parent().parent().remove();
        $(this).parent().parent().remove()

    });
});

function RegisterModel() {
    var modelo = document.getElementById("namemodel").value;
    var descmodelo = document.getElementById("descmodel").value;
    if (modelo == "" && descmodelo == "") {
        $('#divnamemodel').empty();
        $('#divdescmodel').empty();
        $('#divdescmodel').append("Please enter description");
        $('#divnamemodel').append("Please enter name");
    }
    else
    if (modelo != null && modelo != undefined && modelo != "") {
        if (descmodelo != null && descmodelo != undefined && descmodelo != "") {
            return $.ajax({
                dataType: "json",
                url: "../Ajax/GetListProject.aspx?acao=inserir&modelo=" + modelo + "&desc=" + descmodelo + "&codigo=" + codigo,

                success: location.reload()
            });
        }
        else {
            $('#divdescmodel').empty();
            $('#divdescmodel').append("Please enter description");
        }
    }
    else {
        $('#divnamemodel').empty();
        $('#divnamemodel').append("Please enter name");
    }
}

$('#namemodel').focusout(function () {
    if (document.getElementById("namemodel").value != "") {
        $('#divnamemodel').empty();
    }
    else {
        $('#divnamemodel').empty();
        $('#divnamemodel').append("Please enter name");
    }
});

$('#descmodel').focusout(function () {
    if (document.getElementById("descmodel").value != "") {
        $('#divdescmodel').empty();
    }
    else {
        $('#divdescmodel').empty();
        $('#divdescmodel').append("Please enter description");
    }
});


$('#editnamemodel').focusout(function () {
    if (document.getElementById("editnamemodel").value != "") {
        $('#diveditnamemodel').empty();
    }
    else {
        $('#diveditnamemodel').empty();
        $('#diveditnamemodel').append("Please enter name");
    }
});

$('#editdescmodel').focusout(function () {
    if (document.getElementById("editdescmodel").value != "") {
        $('#diveditdescmodel').empty();
    }
    else {
        $('#diveditdescmodel').empty();
        $('#diveditdescmodel').append("Please enter description");
    }
});

function Complete(proj) {
    codigo = proj;
    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetProject.aspx?acao=completar&codigo= " + proj,

        success: location.reload()
    });
}


function Reactive(proj) {
    codigo = proj;
    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetProject.aspx?acao=ativar&codigo= " + proj,

        success: location.reload()
    });
}

$.widget("ui.dialog", $.extend({}, $.ui.dialog.prototype, {
    _title: function (title) {
        if (!this.options.title) {
            title.html("&#160;");
        } else {
            title.html(this.options.title);
        }
    }
}));


$('#registermodel').dialog({
    autoOpen: false,
    width: 500,
    resizable: true,
    modal: true,
    title: "<div class='widget-header'><h4><i class='fa fa-pencil'></i>Register Model</h4></div>",
    position: 'center',
    buttons: [{
        html: "Cancel",
        "class": "btn btn-danger",
        click: function () {
            $(this).dialog("close");
        }
    }, {
        html: "Save",
        "class": "btn btn-success",
        click: function () {
            RegisterModel();
        }
    }]
});


$('#editproject').dialog({
    autoOpen: false,
    width: 900,
    resizable: true,
    modal: true,
    title: "<div class='widget-header'><h4><i class='fa fa-pencil'></i> Edit Project</h4></div>",
    position: 'center',
   
});

$('#editmodel').dialog({
    autoOpen: false,
    width: 500,
    resizable: true,
    modal: true,
    title: "<div class='widget-header'><h4><i class='fa fa-pencil'></i> Edit Model</h4></div>",
    position: 'center',
    buttons: [{
        html: "Cancel",
        "class": "btn btn-danger",
        click: function () {
            $(this).dialog("close");
            document.getElementById("editmodel").style.display = 'none';
        }
    }, {
        html: "Save",
        "class": "btn btn-success",
        click: function () {
            EditYesModel();
        }
    }]
});

$('#deletemodel').dialog({
    autoOpen: false,
    width: 500,
    resizable: true,
    modal: true,
    title: "<div class='widget-header'><h4><i class='fa fa-pencil'></i>Delete Model</h4></div>",
    position: 'center',
    buttons: [{
        html: "Cancel",
        "class": "btn btn-danger",
        click: function () {
            $(this).dialog("close");
        }
    }, {
        html: "Save",
        "class": "btn btn-success",
        click: function () {
            DeleteYesModel();
        }
    }]
});

$('#deleterec').dialog({
    autoOpen: false,
    width: 500,
    resizable: true,
    modal: true,
    title: "<div class='widget-header'><h4><i class='fa fa-pencil'></i>Delete Resource</h4></div>",
    position: 'center',
    buttons: [{
        html: "Cancel",
        "class": "btn btn-danger",
        click: function () {
            $(this).dialog("close");
        }
    }, {
        html: "Save",
        "class": "btn btn-success",
        click: function () {
            DeleteYesRecurso();
        }
    }]
});

$('#viewmodel').dialog({
    autoOpen: false,
    width: 500,
    resizable: true,
    modal: true,
    title: "<div class='widget-header'><h4><i class='fa fa-eye'></i>Model</h4></div>",
    position: 'center',
});

$('#cancel').click(function () {
    $('#editproject').dialog("close");
});

$(document).on('click', '.remove', function () {
    //function remove(id) {
    var c = $(this).val();
    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetListProject.aspx?deletecomment= " + c,

        success: $(this).parent().parent().parent().remove()
    });
});

$(function () {
    // Validation
    $("#formedit").validate({
        // Rules for form validation
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
            valuetotal:{
                required: true
            },
            company: {
                required: true
            }            
        },

        // Messages for form validation
        messages: {
            name: {
                required: 'Please enter name'
            },
            startdate: {
                required: 'Please enter start date'
            },
            finishdate: {
                required: 'Please enter expiry date'
            },
            valuetotal: {
                required: 'Please enter total cost'
            },
            company: {
                required: 'Please choose a company'
            }
        },

        // Do not change code below
        errorPlacement: function (error, element) {
            error.insertAfter(element.parent());
        }

    });
});


var started = false;
var obj = {
    3: 'teste'
};


var getProperty = function (propertyName) {
    return obj[propertyName];
};
/*$('#search').click(function () {
   

    if (started == false) {
        started = true;
        var table = document.getElementById('tabledep');
        var table = $('tabledep');

        $('#tabledep tbody tr').each(function (indice, i) {
            var dados = $(i).find('td:eq(2)').text();
            if (dados != "" && dados != " ") {
                var teste = dados.split(",");
                alert(teste[0])
                alert(getProperty(teste[0]));
            }
            });
        
    }

});*/

var ob;
var pri;
var pj;
function addDependencia(obj, principal, projeto) {
    pri = principal;
    pj = projeto;
    ob = obj;
    $('#editdependencia').dialog('open');
    $('#dpcancel').click(function () {
        $('#editdependencia').dialog("close");
    });


}


function SaveDep() {

    //post data to handler script. note the JSON.stringify call
    $.ajax({
        url: '../Ajax/GetDependency.aspx',
        data: { 'dependencias': $('#selecionadependencia').val(), 'principal': pri, 'projeto': pj, 'tipo': $('#Select1').val() },
        type: 'POST',
        success: function (data) {
            $('#editdependencia').dialog("close");


        }
    });

    location.reload();
    //window.location.href = "../View/Index.aspx#ListProject.aspx?codigo=" + pj;

}





