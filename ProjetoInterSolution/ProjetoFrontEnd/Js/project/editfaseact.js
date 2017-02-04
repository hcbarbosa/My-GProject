var f;
var projeto;
var a;
var profaat;
var qtd;
///////////////////////////////////////////////////////
//////////////////////////////////////////////////////
//aba de atividades

$(document).on('click', '.deleteat', function () {

    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetListProject.aspx?acao=deleteat&at=" + $(this).val(),

        success: function (data) {
            if (data != null) {
                $.each(data, function (index, p) {
                    var op = {
                        'ok': p.ok
                    };
                    location.reload()
                });
            }
        }
    });
});


$(document).on('click', '.reactivateat', function () {

    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetListProject.aspx?acao=reactivateat&at=" + $(this).val(),

        success: function (data) {
            if (data != null) {
                $.each(data, function (index, p) {
                    var op = {
                        'ok': p.ok
                    };
                    location.reload()
                });
            }
        }
    });
});

$(document).on('click', '.completeat', function () {

    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetListProject.aspx?acao=completeat&at=" + $(this).val(),

        success: function (data) {
            if (data != null) {
                $.each(data, function (index, p) {
                    var op = {
                        'ok': p.ok
                    };
                    location.reload()
                });
            }
        }
    });
});

$(document).on('click', '.viewactivity', function () {

    document.getElementById("btneditat").style.display = 'block';
    document.getElementById("btnsatividade").style.display = 'none';

    document.getElementById("namea").disabled = true;
    document.getElementById("desca").disabled = true;
    document.getElementById("starta").disabled = true;
    document.getElementById("finisha").disabled = true;
    document.getElementById("houra").disabled = true;

    $('#divat').dialog('open');

    var atividade = $(this).val();
    a = atividade;
    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetListProject.aspx?acao=editat&at=" + atividade,

        success: function (data) {
            if (data != null) {
                $.each(data, function (index, p) {
                    var op = {
                        'name': p.name, 'desc': p.desc, 'start': p.start, 'finish': p.finish, 'hour': p.hora
                    };
                    $('#namea').val('');
                    $('#namea').val(op.name);
                    document.getElementById("desca").val = '';
                    $('#desca').val(op.desc);
                    var datas = op.start;
                    var ano = datas.slice(6, 10);
                    var mes = datas.slice(3, 5);
                    var dia = datas.slice(0, 2);
                    $('#starta').val('');
                    $('#starta').val(ano + "-" + mes + "-" + dia);
                    var dataf = op.finish;
                    ano = dataf.slice(6, 10);
                    mes = dataf.slice(3, 5);
                    dia = dataf.slice(0, 2);
                    $('#finisha').val('');
                    $('#finisha').val(ano + "-" + mes + "-" + dia);
                    $('#houra').val('');
                    $('#houra').val(p.hour);
                });
            }
        }
    });
});


$(document).on('click', '.viewactivitycliente', function () {

    document.getElementById("btneditat").style.display = 'none';
    document.getElementById("btnsatividade").style.display = 'none';

    document.getElementById("namea").disabled = true;
    document.getElementById("desca").disabled = true;
    document.getElementById("starta").disabled = true;
    document.getElementById("finisha").disabled = true;
    document.getElementById("houra").disabled = true;

    $('#divat').dialog('open');

    var atividade = $(this).val();
    a = atividade;
    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetListProject.aspx?acao=editat&at=" + atividade,

        success: function (data) {
            if (data != null) {
                $.each(data, function (index, p) {
                    var op = {
                        'name': p.name, 'desc': p.desc, 'start': p.start, 'finish': p.finish, 'hour': p.hora
                    };
                    $('#namea').val('');
                    $('#namea').val(op.name);
                    document.getElementById("desca").val = '';
                    $('#desca').val(op.desc);
                    var datas = op.start;
                    var ano = datas.slice(6, 10);
                    var mes = datas.slice(3, 5);
                    var dia = datas.slice(0, 2);
                    $('#starta').val('');
                    $('#starta').val(ano + "-" + mes + "-" + dia);
                    var dataf = op.finish;
                    ano = dataf.slice(6, 10);
                    mes = dataf.slice(3, 5);
                    dia = dataf.slice(0, 2);
                    $('#finisha').val('');
                    $('#finisha').val(ano + "-" + mes + "-" + dia);
                    $('#houra').val('');
                    $('#houra').val(p.hour);
                });
            }
        }
    });
});


$('#btneditat').click(function () {
    document.getElementById("btneditat").style.display = 'none';
    document.getElementById("btnsatividade").style.display = 'block';

    document.getElementById("namea").disabled = false;
    document.getElementById("desca").disabled = false;
    document.getElementById("starta").disabled = false;
    document.getElementById("finisha").disabled = false;
    document.getElementById("houra").disabled = false;
});


function EditCancelAtividade()
{
    document.getElementById("btneditat").style.display = 'block';
    document.getElementById("btnsatividade").style.display = 'none';
    $('#divnamea').empty();
    $('#divdesca').empty();
    $('#divstarta').empty();
    $('#divfinisha').empty();
    $('#divhoura').empty();

    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetListProject.aspx?acao=editat&at=" + a,

        success: function (data) {
            if (data != null) {
                $.each(data, function (index, p) {
                    var op = {
                        'name': p.name, 'desc': p.desc, 'start': p.start, 'finish': p.finish, 'hour': p.hora
                    };
                    $('#namea').val('');
                    $('#namea').val(op.name);
                    document.getElementById("desca").value = '';
                    $('#desca').val(op.desc);
                    var datas = op.start;
                    var ano = datas.slice(6, 10);
                    var mes = datas.slice(3, 5);
                    var dia = datas.slice(0, 2);
                    $('#starta').val('');
                    $('#starta').val(ano + "-" + mes + "-" + dia);
                    var dataf = op.finish;
                    ano = dataf.slice(6, 10);
                    mes = dataf.slice(3, 5);
                    dia = dataf.slice(0, 2);
                    $('#finisha').val('');
                    $('#finisha').val(ano + "-" + mes + "-" + dia);
                    $('#houra').val('');
                    $('#houra').val(p.hour);

                    document.getElementById("namea").disabled = true;
                    document.getElementById("desca").disabled = true;
                    document.getElementById("starta").disabled = true;
                    document.getElementById("finisha").disabled = true;
                    document.getElementById("houra").disabled = true;
                });
            }
        }
    });

}


function EditSaveAtividade() {
    var nome = document.getElementById("namea").value;
    var desc = document.getElementById("desca").value;
    var start = document.getElementById("starta").value;
    var finish = document.getElementById("finisha").value;
    var hora = document.getElementById("houra").value;
    if (nome == "" && desc == "" && start == "" && finish == "" && hora == "") {
        $('#divnamea').empty();
        $('#divdesca').empty();
        $('#divstarta').empty();
        $('#divfinisha').empty();
        $('#divhoura').empty();
        $('#divdesca').append("Please enter description");
        $('#divnamea').append("Please enter name");
        $('#divstarta').append("Please enter start");
        $('#divfinisha').append("Please enter finish");
        $('#divhoura').append("Please enter hours");
    }
    else
        if (nome != null && nome != undefined && nome != "") {
            if (desc != null && desc != undefined && desc != "") {
                if (start != null && start != undefined && start != "") {
                    if (finish != null && finish != undefined && finish != "" && finish >= start) {
                        if (hora != null && hora != undefined && hora != "") {
                            $('#divnamea').empty();
                            $('#divdesca').empty();
                            $('#divstarta').empty();
                            $('#divfinisha').empty();
                            $('#divhoura').empty();
                            return $.ajax({
                                dataType: "json",
                                url: "../Ajax/GetListProject.aspx?acao=alteraat&nome=" + nome + "&desc=" + desc + "&start=" + start + "&finish=" + finish + "&hora=" + hora + "&numero=" + a,

                                success: function (data) {
                                    if (data != null) {
                                        $.each(data, function (index, p) {
                                            var op = {
                                                'name': p.name, 'numero': p.numero, 'desc': p.desc, 'start': p.start, 'finish': p.finish, 'hour': p.hour
                                            };
                                            $('#tdnomeat' + op.numero).empty();
                                            $('#tdnomeat' + op.numero).append(op.name);
                                            $('#tdstartat' + op.numero).empty();
                                            $('#tdstartat' + op.numero).append(op.start);
                                            $('#tdfinishat' + op.numero).empty();
                                            $('#tdfinishat' + op.numero).append(op.finish);
                                            ShowViewEditAt();
                                        });
                                    }
                                }
                            });
                        }
                        else {
                            $('#divhoura').empty();
                            $('#divhoura').append("Please enter hours");
                        }
                    }
                    else {
                        $('#divfinisha').empty();
                        $('#divfinisha').append("Please enter valid expiry date");
                    }
                }
                else {
                    $('#divstarta').empty();
                    $('#divstarta').append("Please enter start date");
                }
            }
            else {
                $('#divdesca').empty();
                $('#divdesca').append("Please enter description");
            }
        }
        else {
            $('#divnamea').empty();
            $('#divnamea').append("Please enter name");
        }
}

$('#houra').focusout(function () {
    if (document.getElementById("houra").value != null && document.getElementById("houra").value != "") {
        $('#divhoura').empty();
    }
    else {
        $('#divhoura').empty();
        $('#divhoura').append("Please, enter hours");
    }
});

$('#namea').focusout(function () {
    if (document.getElementById("namea").value != null && document.getElementById("namea").value != "") {
        $('#divnamea').empty();
    }
    else {
        $('#divnamea').empty();
        $('#divnamea').append("Please, enter name");
    }
});

$('#desca').focusout(function () {
    if (document.getElementById("desca").value != null && document.getElementById("desca").value != "") {
        $('#divdesca').empty();
    }
    else {
        $('#divdesca').empty();
        $('#divdesca').append("Please, enter description");
    }
});

$('#starta').focusout(function () {
    if (document.getElementById("starta").value != null && document.getElementById("starta").value != "") {
        $('#divstarta').empty();
    }
    else {
        $('#divstarta').empty();
        $('#divstarta').append("Please, enter start date");
    }
});

$('#finisha').focusout(function () {
    if (document.getElementById("finisha").value != null && document.getElementById("finisha").value != "") {
        if (document.getElementById("finisha").value >= document.getElementById("starta").value) {
            $('#divfinisha').empty();
        }
        else {
            $('#divfinisha').empty();
            $('#divfinisha').append("Expiry < Start date");
        }
    }
    else {
        $('#divfinisha').empty();
        $('#divfinisha').append("Please, enter expiry date");
    }
});

function ShowViewEditAt() {

    document.getElementById("btneditat").style.display = 'block';
    document.getElementById("btnsatividade").style.display = 'none';
    $('#divnamea').empty();
    $('#divdesca').empty();
    $('#divstarta').empty();
    $('#divfinisha').empty();
    $('#divhoura').empty();
    document.getElementById("namea").disabled = true;
    document.getElementById("desca").disabled = true;
    document.getElementById("starta").disabled = true;
    document.getElementById("finisha").disabled = true;
    document.getElementById("houra").disabled = true;
}

function registerat(p){
    projeto = p;
    $('#divnamea').empty();
    $('#divdesca').empty();
    $('#divstarta').empty();
    $('#divfinisha').empty();
    $('#divhoura').empty();
    $('#divstepa').empty();
    document.getElementById("btneditat").style.display = 'none';
    document.getElementById("btnsatividade").style.display = 'block';
    document.getElementById("btneditsaveatividade").style.display = 'none';
    document.getElementById("registersaveatividade").style.display = 'block';
    document.getElementById("btneditcancelatividade").style.display = 'none';
    document.getElementById("registercancelatividade").style.display = 'block';
    document.getElementById("selecionastepat").style.display = 'block';

    $('#divat').dialog('open');

    document.getElementById("namea").disabled = false;
    document.getElementById("desca").disabled = false;
    document.getElementById("starta").disabled = false;
    document.getElementById("finisha").disabled = false;
    document.getElementById("houra").disabled = false;

}


function RegisterAtividade() {
    var nome = document.getElementById("namea").value;
    var desc = document.getElementById("desca").value;
    var start = document.getElementById("starta").value;
    var finish = document.getElementById("finisha").value;
    var hora = document.getElementById("houra").value;
    var fase = document.getElementById("stepat").value;
    if (nome == "" && desc == "" && start == "" && finish == "" && hora == "" && fase == 0) {
        $('#divnamea').empty();
        $('#divdesca').empty();
        $('#divstarta').empty();
        $('#divfinisha').empty();
        $('#divhoura').empty();
        $('#divstepa').empty();
        $('#divdesca').append("Please enter description");
        $('#divnamea').append("Please enter name");
        $('#divstarta').append("Please enter start");
        $('#divfinisha').append("Please enter finish");
        $('#divhoura').append("Please enter hours");
        $('#divstepa').append("Choose the step");
    }
    else
        if (nome != null && nome != undefined && nome != "") {
            if (desc != null && desc != undefined && desc != "") {
                if (start != null && start != undefined && start != "") {
                    if (finish != null && finish != undefined && finish != "" && finish >= start) {
                        if (hora != null && hora != undefined && hora != "") {
                            if (fase != null && fase != undefined && fase != "" && fase != 0) {
                                $('#divnamea').empty();
                                $('#divdesca').empty();
                                $('#divstarta').empty();
                                $('#divfinisha').empty();
                                $('#divhoura').empty();
                                $('#divstepa').empty();
                                return $.ajax({
                                    dataType: "json",
                                    url: "../Ajax/GetListProject.aspx?acao=novaat&nome=" + nome + "&desc=" + desc + "&start=" + start + "&finish=" + finish + "&hora=" + hora + "&projeto=" + projeto + "&fase=" + fase,

                                    success: function (data) {
                                        if (data != null) {
                                            $.each(data, function (index, p) {
                                                var op = {
                                                    'ok': p.ok
                                                };
                                                location.reload();
                                            });
                                        }
                                    }
                                });
                            }
                            else {
                                $('#divstepa').empty();
                                $('#divstepa').append("Choose the step");
                            }
                        }
                        else {
                            $('#divhoura').empty();
                            $('#divhoura').append("Please enter hours");
                        }
                    }
                    else {
                        $('#divfinisha').empty();
                        $('#divfinisha').append("Please enter valid expiry date");
                    }
                }
                else {
                    $('#divstarta').empty();
                    $('#divstarta').append("Please enter start date");
                }
            }
            else {
                $('#divdesca').empty();
                $('#divdesca').append("Please enter description");
            }
        }
        else {
            $('#divnamea').empty();
            $('#divnamea').append("Please enter name");
        }
}

function RegisterCancelAtividade()
{

    $('#divat').dialog('close');
}

///////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//ADD RECURSO

$(document).on('click', '.recursoadd', function () {
    var dadosaddrecurso = $(this).val().split(',');
    a = dadosaddrecurso[2];
    f = dadosaddrecurso[1];
    projeto = dadosaddrecurso[0];
    $('#divaddrecurso').dialog('open');
    $("#unidade").maskMoney();
    $('#divredselectrecurso').empty();
    $('#selecionarecurso').empty();
    $('#divqtd').empty();
    $('#unidade').val('');
    $('#hora').val('');
});

    $('#selecttipo').change(function () {
        // mudar quantity referente ao tipo de recurso   
        var idtipo = $('#selecttipo').val();
        if (idtipo == 1) {
            document.getElementById('hora').style.display = 'block';
            document.getElementById('unidade').style.display = 'none';
            return $.ajax({
                dataType: "json",
                url: "../Ajax/GetListProject.aspx?acao=preencherecurso&tipo=" + idtipo + "&atividade=" + a.trim() + "&fase=" + f.trim() + "&projeto=" + projeto.trim(),

                success: function (data) {
                    if (data != null) {
                        $.each(data, function (index, p) {
                            var op = {
                                'recursos': p.recursos
                            };
                            $('#selecionarecurso').val('');
                            $('#selecionarecurso').empty();
                            $('#selecionarecurso').append(op.recursos);
                        });
                    }
                }
            });
        }
        else if (idtipo == 2) {
            document.getElementById('unidade').style.display = 'block';
            document.getElementById('hora').style.display = 'none';
            return $.ajax({
                dataType: "json",
                url: "../Ajax/GetListProject.aspx?acao=preencherecurso&tipo=" + idtipo.trim() + "&atividade=" + a.trim() + "&fase=" + f.trim() + "&projeto=" + projeto.trim(),

                success: function (data) {
                    if (data != null) {
                        $.each(data, function (index, p) {
                            var op = {
                                'recursos': p.recursos
                            };
                            $('#selecionarecurso').empty();
                            $('#selecionarecurso').append(op.recursos);
                        });
                    }
                }
            });
        }
        else if(idtipo == 0 ){
            document.getElementById('hora').style.display = 'none';
            document.getElementById('unidade').style.display = 'none';
            $('#divredselectrecurso').empty();
            $('#selecionarecurso').empty();
            $('#divredselectrecurso').append('Choose the type')
            $('#divqtd').empty();
            $('#divqtd').append('Choose the type');
        }
    });

    $('#hora').focusout(function () {
        // mudar quantity referente ao tipo de recurso   
        var id = $('#selecionarecurso').val();
        return $.ajax({
            dataType: "json",
            url: "../Ajax/GetListProject.aspx?acao=qtdrecurso&recurso=" + id,

            success: function (data) {
                if (data != null) {
                    $.each(data, function (index, p) {
                        var op = {
                            'qtd': p.qtd
                        };
                        qtd = op.qtd;
                        $('#divqtd').empty();
                    });
                }
            }
        });
    });

    $('#unidade').focusout(function () {
        // mudar quantity referente ao tipo de recurso   
        var id = $('#selecionarecurso').val();
        return $.ajax({
            dataType: "json",
            url: "../Ajax/GetListProject.aspx?acao=qtdrecurso&recurso=" + id,

            success: function (data) {
                if (data != null) {
                    $.each(data, function (index, p) {
                        var op = {
                            'qtd': p.qtd
                        };
                        qtd = op.qtd;
                        $('#divqtd').empty();
                    });
                }
            }
        });
    });


    $(document).on('click', '#recadd', function () {

        var r = document.getElementById("selecionarecurso").value;
        var tipo = document.getElementById("selecttipo").value;
        var hora = document.getElementById("hora").value;
        var unid = document.getElementById("unidade").value;
        if (r == null && tipo == 0 && hora == "" && unidade == "") {
            $('#divredselectrecurso').empty();
            $('#divredselectrecurso').append('Choose the type')
            $('#divqtd').empty();
            $('#divqtd').append('Choose the type and enter quantity');
        }
        else if (tipo != null && tipo != undefined && tipo != "" && tipo != 0) {
            if (r != null && r != undefined && r != "") {
                if (tipo == 1) {
                    if (hora != null && hora != undefined && hora != "") {
                        if (hora <= qtd) {
                            $('#divqtd').empty();
                            $('#divredselectrecurso').empty();
                            //alert("projeto:" + projeto + " fase:" + f + " atividade:" + a + " recurso:" + r + " hora:" + hora + " unid:"+unid);
                            return $.ajax({
                                dataType: "json",
                                url: "../Ajax/GetListProject.aspx?acao=addrecurso&recurso=" + r.trim() + "&hora=" + hora.trim() + "&unid=" + unid + "&projeto=" + projeto.trim() + "&fase=" + f.trim() + "&atividade=" + a.trim() + "&tipo=" + tipo.trim(),

                                success: function (data) {
                                    if (data != null) {
                                        $.each(data, function (index, p) {
                                            var op = {
                                                'ok': p.ok
                                            };
                                            
                                                location.reload();
                                           
                                        });
                                    }
                                }
                            });
                        }
                        else {
                            $('#divqtd').empty();
                            $('#divqtd').append("Please enter valid hours(x<" + qtd + ")");
                        }
                    }
                    else {

                        $('#divqtd').empty();
                        $('#divqtd').append("Please enter hours");
                    }
                }
                else if (tipo == 2) {
                    if (unid != null && unid != undefined && unid != "") { 
                            $('#divqtd').empty();
                            $('#divredselectrecurso').empty();
                            return $.ajax({
                                dataType: "json",
                                url: "../Ajax/GetListProject.aspx?acao=addrecurso&recurso=" + r.trim() + "&hora=" + hora + "&unid=" + unid.trim() + "&projeto=" + projeto.trim() + "&fase=" + f.trim() + "&atividade=" + a.trim() + "&tipo=" + tipo.trim() + "&qtd=" + qtd.trim(),

                                success: function (data) {
                                    if (data != null) {
                                        $.each(data, function (index, p) {
                                            var op = {
                                                'ok': p.ok
                                            };
                                           
                                                location.reload();
                                           
                                        });
                                    }
                                }
                            });
                    }
                    else {
                        $('#divqtd').empty();
                        $('#divqtd').append("Please enter number");
                    }
                }
            }
            else {
                $('#divredselectrecurso').empty();
                $('#divredselectrecurso').append("Choose the type");
            }
        }
        else {
            $('#divredselectrecurso').empty();
            $('#divredselectrecurso').append("Choose the type");
        }

    });


    /////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////
    // aba de fases
    $(document).on('click', '.btnnewstep', function () {

        projeto = $(this).val();
        document.getElementById("btnnextstep").style.display = 'block';
        document.getElementById("btnconfirmstep").style.display = 'none';

        document.getElementById("formnewstep").style.display = 'block';
        document.getElementById("formnewatstep").style.display = 'none';

        $('#newstep').dialog('open');    

    });

    function CancelStep() {
        $('#newstep').dialog('close');
    }

    function ShowViewEdit() {
        document.getElementById("botaoeditstep").style.display = 'block';
        document.getElementById("btneditstep").style.display = 'none';
        document.getElementById("editnamestep").disabled = true;
        document.getElementById("editdescstep").disabled = true;
        document.getElementById("editstartstep").disabled = true;
        document.getElementById("editfinishstep").disabled = true;
    }

    function NewStep() {
        var nomefase = document.getElementById("namestep").value;
        var descfase = document.getElementById("descstep").value;
        var start = document.getElementById("startstep").value;
        var finish = document.getElementById("finishstep").value;

        if (nomefase == "" && descfase == "" && start == "" && finish=="") {
            $('#divnamestep').empty();
            $('#divdescstep').empty();
            $('#divstartstep').empty();
            $('#divfinishstep').empty();
            $('#divdescstep').append("Please enter description");
            $('#divnamestep').append("Please enter name");
            $('#divstartstep').append("Please enter start");
            $('#divfinishstep').append("Please enter finish");
        }
        else
            if (nomefase != null && nomefase != undefined && nomefase != "") {
                if (descfase != null && descfase != undefined && descfase != "") {
                    if (start != null && start != undefined && start != "") {
                        if (finish != null && finish != undefined && finish != "" && finish >= start) {
                            return $.ajax({
                                dataType: "json",
                                url: "../Ajax/GetListProject.aspx?acao=novafase&nome=" + nomefase + "&desc=" + descfase + "&start=" + start + "&finish=" + finish,

                                success: function (data) {
                                    if (data != null) {
                                        $.each(data, function (index, p) {
                                            var op = {
                                                'numero': p.numero
                                            };
                                            $('#numerofase').val(op.numero);

                                            document.getElementById("btnnextstep").style.display = 'none';
                                            document.getElementById("btnconfirmstep").style.display = 'block';

                                            document.getElementById("formnewstep").style.display = 'none';
                                            document.getElementById("formnewatstep").style.display = 'block';
                                        });
                                    }
                                }
                            });
                        }
                        else {
                            $('#divfinishstep').empty();
                            $('#divfinishstep').append("Please enter valid expiry date");
                        }
                    }
                    else {
                        $('#divstartstep').empty();
                        $('#divstartstep').append("Please enter start date");
                    }
                }
                else {
                    $('#divdescstep').empty();
                    $('#divdescstep').append("Please enter description");
                }
            }
            else {
                $('#divnamestep').empty();
                $('#divnamestep').append("Please enter name");
            }
    }

    $('#namestep').focusout(function () {
        if (document.getElementById("namestep").value != null && document.getElementById("namestep").value != "") {
            $('#divnamestep').empty();
        }
        else {
            $('#divnamestep').empty();
            $('#divnamestep').append("Please, enter name");
        }
    });

    $('#descstep').focusout(function () {
        if (document.getElementById("descstep").value != null && document.getElementById("descstep").value != "") {
            $('#divdescstep').empty();
        }
        else {
            $('#divdescstep').empty();
            $('#divdescstep').append("Please, enter description");
        }
    });

    $('#startstep').focusout(function () {
        if (document.getElementById("startstep").value != null && document.getElementById("startstep").value != "") {
            $('#divstartstep').empty();
        }
        else {
            $('#divstartstep').empty();
            $('#divstartstep').append("Please, enter start date");
        }
    });

    $('#finishstep').focusout(function () {
        if (document.getElementById("finishstep").value != null && document.getElementById("finishstep").value != "") {
            if (document.getElementById("finishstep").value >= document.getElementById("startstep").value) {
                $('#divfinishstep').empty();
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

    function SaveStep() {
        var nomefase = document.getElementById("nameat").value;
        var descfase = document.getElementById("descat").value;
        var start = document.getElementById("startat").value;
        var finish = document.getElementById("finishat").value;
        var hora = document.getElementById("hourat").value;
        var fase = document.getElementById("numerofase").value;
        if (nomefase == "" && descfase == "" && start == "" && finish == "" && hora == "") {
            $('#divnameat').empty();
            $('#divdescat').empty();
            $('#divstartat').empty();
            $('#divfinishat').empty();
            $('#divhourat').empty();
            $('#divdescat').append("Please enter description");
            $('#divnameat').append("Please enter name");
            $('#divstartat').append("Please enter start");
            $('#divfinishat').append("Please enter finish");
            $('#divhourat').append("Please enter hours");
        }
        else
            if (nomefase != null && nomefase != undefined && nomefase != "") {
                if (descfase != null && descfase != undefined && descfase != "") {
                    if (start != null && start != undefined && start != "") {
                        if (finish != null && finish != undefined && finish != "" && finish >= start) {
                            if (hora != null && hora != undefined && hora != "") {
                                $('#divnamestep').empty();
                                $('#divdescstep').empty();
                                $('#divstartstep').empty();
                                $('#divfinishstep').empty();
                                return $.ajax({
                                    dataType: "json",
                                    url: "../Ajax/GetListProject.aspx?acao=novaat&nome=" + nomefase + "&desc=" + descfase + "&start=" + start + "&finish=" + finish + "&hora=" + hora + "&fase=" + fase + "&projeto=" + projeto,

                                    success: location.reload()

                                });
                            }
                            else {
                                $('#divhourat').empty();
                                $('#divhourat').append("Please enter hours");
                            }
                        }
                        else {
                            $('#divfinishat').empty();
                            $('#divfinishat').append("Please enter valid expiry date");
                        }
                    }
                    else {
                        $('#divstartat').empty();
                        $('#divstartat').append("Please enter start date");
                    }
                }
                else {
                    $('#divdescat').empty();
                    $('#divdescat').append("Please enter description");
                }
            }
            else {
                $('#divnameat').empty();
                $('#divnameat').append("Please enter name");
            }
    }

    $('#hourat').focusout(function () {
        if (document.getElementById("hourat").value != null && document.getElementById("hourat").value != "") {
            $('#divhourat').empty();
        }
        else {
            $('#divhourat').empty();
            $('#divhourat').append("Please, enter name");
        }
    });

    $('#nameat').focusout(function () {
        if (document.getElementById("nameat").value != null && document.getElementById("nameat").value != "") {
            $('#divnameat').empty();
        }
        else {
            $('#divnameat').empty();
            $('#divnameat').append("Please, enter name");
        }
    });

    $('#descat').focusout(function () {
        if (document.getElementById("descat").value != null && document.getElementById("descat").value != "") {
            $('#divdescat').empty();
        }
        else {
            $('#divdescat').empty();
            $('#divdescat').append("Please, enter description");
        }
    });

    $('#startat').focusout(function () {
        if (document.getElementById("startsat").value != null && document.getElementById("startat").value != "") {
            $('#divstartat').empty();
        }
        else {
            $('#divstartat').empty();
            $('#divstartat').append("Please, enter start date");
        }
    });

    $('#finishat').focusout(function () {
        if (document.getElementById("finishat").value != null && document.getElementById("finishat").value != "") {
            if (document.getElementById("finishat").value >= document.getElementById("startat").value) {
                $('#divfinishat').empty();
            }
            else {
                $('#divfinishat').empty();
                $('#divfinishat').append("Expiry < Start date");
            }
        }
        else {
            $('#divfinishat').empty();
            $('#divfinishat').append("Please, enter expiry date");
        }
    });


    $(document).on('click', '.deletefase', function () {
    
        var fase = $(this).val();
        f = fase;
        return $.ajax({
            dataType: "json",
            url: "../Ajax/GetListProject.aspx?acao=deletefase&fase=" + fase,

            success: function (data) {
                if (data != null) {
                    $.each(data, function (index, p) {
                        var op = {
                            'ok': p.ok
                        };
                        location.reload()
                    });
                }
            }
        });
    });

    $(document).on('click', '.reactivefase', function () {

        var fase = $(this).val();
        f = fase;
        return $.ajax({
            dataType: "json",
            url: "../Ajax/GetListProject.aspx?acao=reactivefase&fase=" + fase,

            success: function (data) {
                if (data != null) {
                    $.each(data, function (index, p) {
                        var op = {
                            'ok': p.ok
                        };
                        location.reload()
                    });
                }
            }
        });
    });

    $(document).on('click', '.completefase', function () {

        var fase = $(this).val();
        f = fase;
        return $.ajax({
            dataType: "json",
            url: "../Ajax/GetListProject.aspx?acao=completefase&fase=" + fase,
            success: function (data) {
                if (data != null) {
                    $.each(data, function (index, p) {
                        var op = {
                            'ok': p.ok
                        };
                        location.reload()
                    });
                }
            }
        });
    });

    $('#botaoeditstep').click(function () {
        document.getElementById("botaoeditstep").style.display = 'none';
        document.getElementById("btneditstep").style.display = 'block';
        document.getElementById("editnamestep").disabled = false;
        document.getElementById("editdescstep").disabled = false;
        document.getElementById("editstartstep").disabled = false;
        document.getElementById("editfinishstep").disabled = false;
    });


    $('#canceleditstep').click(function () {
        $('#diveditnamestep').empty();
        $('#diveditdescstep').empty();
        $('#diveditstartstep').empty();
        $('#diveditfinishstep').empty();
        document.getElementById("botaoeditstep").style.display = 'block';
        document.getElementById("btneditstep").style.display = 'none';
    
        return $.ajax({
            dataType: "json",
            url: "../Ajax/GetListProject.aspx?acao=editfase&fase=" + f,

            success: function (data) {
                if (data != null) {
                    $.each(data, function (index, p) {
                        var op = {
                            'name': p.name, 'desc': p.desc, 'start': p.start, 'finish': p.finish
                        };
                        $('#editnamestep').val('');
                        $('#editnamestep').val(op.name);
                        document.getElementById("editdescstep").value = '';
                        $('#editdescstep').val(op.desc);
                        var datas = op.start;
                        var ano = datas.slice(6, 10);
                        var mes = datas.slice(3, 5);
                        var dia = datas.slice(0, 2);
                        $('#editstartstep').val('');
                        $('#editstartstep').val(ano + "-" + mes + "-" + dia);
                        var dataf = op.finish;
                        ano = dataf.slice(6, 10);
                        mes = dataf.slice(3, 5);
                        dia = dataf.slice(0, 2);
                        $('#editfinishstep').val('');
                        $('#editfinishstep').val(ano + "-" + mes + "-" + dia);

                        document.getElementById("editnamestep").disabled = true;
                        document.getElementById("editdescstep").disabled = true;
                        document.getElementById("editstartstep").disabled = true;
                        document.getElementById("editfinishstep").disabled = true;
                    });
                }
            }
        });

    });

    $(document).on('click', '.viewcliente', function () {

        document.getElementById("botaoeditstep").style.display = 'none';
        document.getElementById("btneditstep").style.display = 'none';

        $('#editstep').dialog('open');
        var fase = $(this).val();
        f = fase;
        return $.ajax({
            dataType: "json",
            url: "../Ajax/GetListProject.aspx?acao=editfase&fase=" + fase,

            success: function (data) {
                if (data != null) {
                    $.each(data, function (index, p) {
                        var op = {
                            'name': p.name, 'desc': p.desc, 'start': p.start, 'finish': p.finish
                        };
                        $('#editnamestep').val('');
                        $('#editnamestep').val(op.name);
                        $('#editdescstep').empty();
                        $('#editdescstep').append(op.desc);
                        var datas = op.start;
                        var ano = datas.slice(6, 10);
                        var mes = datas.slice(3, 5);
                        var dia = datas.slice(0, 2);
                        $('#editstartstep').val('');
                        $('#editstartstep').val(ano + "-" + mes + "-" + dia);
                        var dataf = op.finish;
                        ano = dataf.slice(6, 10);
                        mes = dataf.slice(3, 5);
                        dia = dataf.slice(0, 2);
                        $('#editfinishstep').val('');
                        $('#editfinishstep').val(ano + "-" + mes + "-" + dia);
                    });
                }
            }
        });
    });


    $(document).on('click', '.view', function () {
    
        document.getElementById("botaoeditstep").style.display = 'block';
        document.getElementById("btneditstep").style.display = 'none';
        $('#diveditnamestep').empty();
        $('#diveditdescstep').empty();
        $('#diveditstartstep').empty();
        $('#diveditfinishstep').empty();

        $('#editstep').dialog('open');
        var fase = $(this).val();
        f = fase;
        return $.ajax({
            dataType: "json",
            url: "../Ajax/GetListProject.aspx?acao=editfase&fase=" + fase,

            success: function (data) {
                if (data != null) {
                    $.each(data, function (index, p) {
                        var op = {
                            'name': p.name, 'desc': p.desc, 'start':p.start , 'finish':p.finish
                        };
                        $('#editnamestep').val('');
                        $('#editnamestep').val(op.name);
                        document.getElementById("editdescstep").value = '';
                        $('#editdescstep').val(op.desc);
                        var datas = op.start;
                        var ano = datas.slice(6, 10);
                        var mes = datas.slice(3, 5);
                        var dia = datas.slice(0, 2);
                        $('#editstartstep').val('');
                        $('#editstartstep').val(ano + "-" + mes + "-" + dia);
                        var dataf = op.finish;
                        ano = dataf.slice(6, 10);
                        mes = dataf.slice(3, 5);
                        dia = dataf.slice(0, 2);
                        $('#editfinishstep').val('');
                        $('#editfinishstep').val(ano + "-" + mes + "-" + dia);
                    });
                }
            }
        });
    });

    function EditYesStep() {
        var nomefase = document.getElementById("editnamestep").value;
        var descfase = document.getElementById("editdescstep").value;
        var start = document.getElementById("editstartstep").value;
        var finish = document.getElementById("editfinishstep").value;

        if (nomefase == "" && descfase == "" && start == "" && finish=="") {
            $('#diveditnamestep').empty();
            $('#diveditdescstep').empty();
            $('#diveditstartstep').empty();
            $('#diveditfinishstep').empty();
            $('#diveditdescstep').append("Please enter description");
            $('#diveditnamestep').append("Please enter name");
            $('#diveditstartstep').append("Please enter start");
            $('#diveditfinishstep').append("Please enter finish");
        }
        else
            if (nomefase != null && nomefase != undefined && nomefase != "") {
                if (descfase != null && descfase != undefined && descfase != "") {
                    if (start != null && start != undefined && start != "") {
                        if (finish != null && finish != undefined && finish != "" && finish >= start) {
                            $('#diveditnamestep').empty();
                            $('#diveditdescstep').empty();
                            $('#diveditstartstep').empty();
                            $('#diveditfinishstep').empty();
                            return $.ajax({
                                dataType: "json",
                                url: "../Ajax/GetListProject.aspx?acao=alterar&fase="+f + "&nome=" + nomefase + "&desc=" + descfase + "&start=" + start + "&finish=" + finish,

                                success: function (data) {
                                    if (data != null) {
                                        $.each(data, function (index, p) {
                                            var op = {
                                                'name': p.name, 'numero':p.numero, 'desc': p.desc, 'start': p.start, 'finish': p.finish
                                            };
                                            $('#tdnomefase' + op.numero).empty();
                                            $('#tdnomefase' + op.numero).append(op.name);
                                            $('#tdstartfase' + op.numero).empty();
                                            $('#tdstartfase' + op.numero).append(op.start);
                                            $('#tdfinishfase' + op.numero).empty();
                                            $('#tdfinishfase' + op.numero).append(op.finish);
                                            ShowViewEdit();
                                        });
                                    }
                                }
                            });
                        }
                        else {
                            $('#diveditfinishstep').empty();
                            $('#diveditfinishstep').append("Please enter valid expiry date");
                        }
                    }
                    else {
                        $('#diveditstartstep').empty();
                        $('#diveditstartstep').append("Please enter start date");
                    }
                }
                else {
                    $('#diveditdescstep').empty();
                    $('#diveditdescstep').append("Please enter description");
                }
            }
            else {
                $('#diveditnamestep').empty();
                $('#diveditnamestep').append("Please enter name");
            }
    }

    $('#editnamestep').focusout(function () {
        if (document.getElementById("editnamestep").value != null && document.getElementById("editnamestep").value != "") {
            $('#diveditnamestep').empty();
        }
        else {
            $('#diveditnamestep').empty();
            $('#diveditnamestep').append("Please, enter name");
        }
    });

    $('#editdescstep').focusout(function () {
        if (document.getElementById("editdescstep").value != null && document.getElementById("editdescstep").value != "") {
            $('#diveditdescstep').empty();
        }
        else {
            $('#diveditdescstep').empty();
            $('#diveditdescstep').append("Please, enter description");
        }
    });

    $('#editstartstep').focusout(function () {
        if (document.getElementById("editstartstep").value != null && document.getElementById("editstartstep").value != "") {
            $('#diveditstartstep').empty();
        }
        else {
            $('#diveditstartstep').empty();
            $('#diveditstartstep').append("Please, enter start date");
        }
    });

    $('#editfinishstep').focusout(function () {
        if (document.getElementById("editfinishstep").value != null && document.getElementById("editfinishstep").value != "") {
            if (document.getElementById("editfinishstep").value >= document.getElementById("editstartstep").value) {            
                $('#diveditfinishstep').empty();           
            }
            else {
                $('#diveditfinishstep').empty();
                $('#diveditfinishstep').append("Expiry < Start date");
            }
        }
        else {
            $('#diveditfinishstep').empty();
            $('#diveditfinishstep').append("Please, enter expiry date");
        }
    });

    //////////////////////////////////////////
    //////////////////////////////////////////
    /////////////////////////////////////////
    //modais
    $.widget("ui.dialog", $.extend({}, $.ui.dialog.prototype, {
        _title: function (title) {
            if (!this.options.title) {
                title.html("&#160;");
            } else {
                title.html(this.options.title);
            }
        }
    }));

    $('#editstep').dialog({
        autoOpen: false,
        width: 500,
        resizable: true,
        modal: true,
        title: "<div class='widget-header'><h4><i class='fa fa-eye'></i>View Step</h4></div>",
        position: 'center',
    
    });

    $('#newstep').dialog({
        autoOpen: false,
        width: 500,
        resizable: true,
        modal: true,
        title: "<div class='widget-header'><h4><i class='fa fa-eye'></i>New Step</h4></div>",
        position: 'center',

    });

    $('#divat').dialog({
        autoOpen: false,
        width: 500,
        resizable: true,
        modal: true,
        title: "<div class='widget-header'><h4><i class='fa fa-eye'></i>Activity</h4></div>",
        position: 'center',

    });

    $('#divaddrecurso').dialog({
        autoOpen: false,
        width: 500,
        resizable: true,
        modal: true,
        title: "<div class='widget-header'><h4><i class='fa fa-eye'></i>Add Resource</h4></div>",
        position: 'center',

    });

    $('#editdependencia').dialog({
        autoOpen: false,
        width: 500,
        resizable: true,
        modal: true,
        title: "<div class='widget-header'><h4><i class='fa fa-eye'></i>Dependency</h4></div>",
        position: 'center',

    });

