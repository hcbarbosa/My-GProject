var idc;
var nome;
var co;
var tel;
var mail;
var empresas;

function add_email() {
    //alert(Profoption)
    $('.criaemail').append(
                                        
                                        "<div class='row' style='width:260%;'><section class='col col-5'>" +
										"<label class='input'> <i class='icon-append fa fa-envelope-o '></i>"+
											"<input type='email' name='email[]' placeholder='Email'/>"+
                                            "<b class='tooltip tooltip-top-right'><i class='fa fa-envelope-o txt-color-teal'>"+
                                        "</i> Please enter company's email</b>" +
                                    "</label></section>" +
                                    "<section class='col col-1'>" +
                                         "<button type='button' class='btn  btn-sm btn-danger email-remove'>" +
                                        "<span class='glyphicon glyphicon-remove'></span>" +
                                        "</button>" +
									"</section></div>");


    
    $(document).on('click', '.email-remove', function () {
        $(this).parent().parent().remove();
    });
}

function add_phone() {
    //alert(Profoption)
    $('.criaphone').append(

                                        "<div class='row' style='width:260%;'><section class='col col-5'>" +
										"<label class='input'> <i class='icon-append fa  fa-phone  '></i>" +
											"<input type='tel' name='phone[]' placeholder='Phone' " +
                                            " data-mask='(99)9999-9999' placeholder='Phone' maxlength='15'/>" +
                                            "<b class='tooltip tooltip-top-right'><i class='fa fa-phone  txt-color-teal'>" +
                                        "</i> Please enter company's phone</b>" +
                                    "</label></section>" +
                                    "<section class='col col-1'>" +
                                         "<button type='button' class='btn  btn-sm btn-danger phone-remove'>" +
                                        "<span class='glyphicon glyphicon-remove'></span>" +
                                        "</button>" +
									"</section></div>"
                                    );


    $(document).on('click', '.phone-remove', function () {
        $(this).parent().parent().remove();
    });
}


buscaCidade = function (id_select_do_estado, campo) {
    var uf, elemento, img_html, options;
    elemento = $("#" + id_select_do_estado);
    uf = $(elemento).val();
    if (uf) {
        return $.ajax({
            dataType: "json",
            url: "../Ajax/GetCidade.aspx?uf= " + uf,
           
            
            success: function (data) {
                options = '<option selected="selected" disabled="disabled">Select a City</option>';
                if (data != null) {
                    $.each(data, function (index, cidade) {
                        options += '<option value="' + cidade.id+ '">' + cidade.nome + '</option>';
                    });
                }

                return $('#' + campo).empty().append(options);
            },
            error: function (xhr) {
                var errors;
                errors = $.parseJSON(xhr.responseText).errors;
                $(".uf.error").remove();
                return elemento.parent().append("<label class='uf error'>" + errors + "</label>");
            }
        });
    } else {
        return elemento.parent().append("<label class='uf error'>State invalid</label>");
    }
};

$(document).ready(function () {
    // coloca o evento pra mudar as cidades, quando vc mudar o estado
    $('#select').change(function () {
        buscaCidade('state', 'city');
    });
})

//altera empresa
function UpdateCompany() {
    $("#orderform1").submit(function (event) {
    });
}

///Parte relacionada a listagens de clientes por empresa 
// essa funcao passara o id da empresa para um campo hidden na div onde a janela modal aparece 

function GetCompaniesId(id,empresa)
{
    nome = empresa;
    document.getElementById("Company").value = id;
    idc = id;
}


function ChangeLink(iten)
{   
    $(iten).attr("href", "Index.aspx#Customers.aspx?id=" + document.getElementById("Company").value);
}


function deleteCompany()
{
    $('#deletecompany').dialog('open');
    document.getElementById("empresa").innerHTML = "<h3>"+nome+"</h3>";
}

function DeleteCompanyYes() {
    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetCompany.aspx?id=" + idc + "&acao=delete",
        success: location.reload()
    });
}

function viewCompany() {
    $('#viewcompany').dialog('open');
    document.getElementById("orderform1").style.display = 'none';
    document.getElementById("table1").style.display = 'block';
    document.getElementById("edit").style.display = 'block';
    EditCompany(idc);
}

function EditCompany(id) {
    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetCompany.aspx?id=" + id + "&acao=edit",

        success: function (data) {

            if (data != null) {
                $.each(data, function (index, c) {

                    co = {
                        'empresa': c.empresa, 'cnpj': c.cnpj, 'area': c.area, 'zip': c.zip, 'street': c.street, 'number': c.number, 'neighborhood': c.neighborhood, 'complement': c.complement, 'state': c.state, 'city': c.city,'img': c.img, 'email': c.email, 'phone': c.phone
                    };

                    tel = co.phone.split(";");
                    mail = co.email.split(";");
                    TableCompanyEdit(co);
                });
            }


        }
    });
}


function TableCompanyEdit(co) {
    document.getElementById("teste").innerHTML =
    "<table class='table table-hover'>" +
    "<thead>" +
    "<tr>" +
    "<th class='col col-xs-4'>Information</th> " +
    "<th class='col col-xs-8'></th>" +
    "</tr>" +
    "</thead>" +
    "<tbody>" +
    "<tr>" +
    "<td> Name:</td>" +
    "<td> " + co.empresa + "</td>" +
    "</tr>" +
    "<tr>" +
    "<td> Cnpj:</td>" +
    "<td> " + co.cnpj + "</td>" +
    "</tr>" +
    "<tr>" +
    "<td> Business area: </td>" +
    "<td>" + co.area + "</td> " +
    "</tr>" +
    "<tr>" +
    "<td> Zip Code:</td>" +
    "<td>" + co.zip + "</td>" +
    "</tr>" +
    "<tr>" +
    "<td> Street:</td> " +
    "<td>" + co.street + "</td>" +
    "</tr>" +
    "<tr>" +
    "<td> Number:</td> " +
    "<td>" + co.number + "</td>" +
    "</tr>" +
    "<tr>" +
    "<td> Neighborhood:</td>" +
    "<td>" + co.neighborhood + "</td> " +
    "</tr>" +
    "<tr>" +
    "<td> Complement:</td>" +
    "<td>" + co.complement + "</td> " +
    "</tr>" +
    "<tr>" +
    "<td> State:</td> " +
    "<td>" + co.state + "</td>" +
    "</tr>" +
    "<tr>" +
    "<td> City:</td>" +
    "<td>" + co.city + "</td>" +
    "</tr>" +
    "<tr>" +
    "<td> Emails:</td> " +
    "<td>" + co.email + "</td>" +
    "</tr>" +
    "<tr>" +
    "<td> Phones:</td> " +
    "<td>" + co.phone + "</td> " +
    "</tr>" +
    "</tbody>" +
    "</table>";
}

function FormCompanyEdit() {

    var conteudoemail;
    var conteudotel;

    if (tel.length > 1) {


        conteudotel = "<section class='col col-5 criaphone'>" +
                                      "<label class='input'> <i class='icon-append fa fa-phone '></i>" +
                                          "<input type='tel' name='phone[]' required='required' title='Please enter phone' data-mask='(99)9999-9999' placeholder='Phone' maxlength='15' value='" + tel[0] + "'/>" +
                                          "<b class='tooltip tooltip-top-right'><i class='fa fa-phone txt-color-teal'></i> Please enter company's phone</b>" +
                                      "</label><br />";
        for (i = 1 ; i < tel.length - 1; i++) {
            conteudotel += "<div class='row' style='width:261%;'><section class='col col-5'>" +
              "<label class='input'> <i class='icon-append fa  fa-phone  '></i>" +
                  "<input type='tel' name='phone[]' required='required' title='Please enter phone' value='" + tel[i] + "' " +
                  "data-mask='(99)9999-9999' placeholder='CelPhone' maxlength='15'>" +
                  "<b class='tooltip tooltip-top-right'><i class='fa fa-mobile-phone  txt-color-teal'>" +
              "</i> Please enter company's phone</b>" +
          "</label></section>" +
          "<section class='col col-1'>" +
               "<button type='button' class='btn  btn-sm btn-danger phone-remove'>" +
              "<span class='glyphicon glyphicon-remove'></span>" +
              "</button>" +
          "</section></div>";
        }
        conteudotel += "</section>" +
                                   "<section class='col col-1'>" +
                                       "<button type='button' class='btn  btn-sm btn-success' onclick='add_phone()'>" +
                                       "<span class='glyphicon glyphicon-plus'></span>" +
                                       "</button>" +
                                   "</section>	";

        $(document).on('click', '.phone-remove', function () {
            $(this).parent().parent().remove();
        });
    } else {

        conteudotel = "<section class='col col-5 criaphone'>" +
             "<label class='input'> <i class='icon-append fa fa-phone '></i>" +
                 "<input type='tel' name='phone[]'  required='required' title='Please enter phone' data-mask='(99)9999-9999' placeholder='Phone' maxlength='15' value='" + tel[0] + "'/>" +
                 "<b class='tooltip tooltip-top-right'><i class='fa fa-phone txt-color-teal'></i> Please enter company's phone</b>" +
             "</label><br />" +
         "</section>" +
         "<section class='col col-1'>" +
             "<button type='button' class='btn  btn-sm btn-success' onclick='add_phone()'>" +
             "<span class='glyphicon glyphicon-plus'></span>" +
             "</button>" +
         "</section>	"

    }

    if (mail.length > 1) {

        conteudoemail = "<section class='col col-5 criaemail'>" +
                                         "<label class='input'> <i class='icon-append fa fa-envelope-o '></i>" +
                                             "<input type='email' name='email[]' required='required' title='Please enter email' placeholder='Email' value='" + mail[0] + "'/>" +
                                             "<b class='tooltip tooltip-top-right'><i class='fa fa-envelope-o txt-color-teal'></i> Please enter company's email</b><br />";
        "</label><br />";

        for (i = 1 ; i < mail.length - 1; i++) {


            conteudoemail += "<div class='row' style='width:261%;'><section class='col col-5'>" +
										"<label class='input'> <i class='icon-append fa fa-envelope-o '></i>" +
											"<input type='email' name='email[]' required title='Please enter email'  value='" + mail[i] + "'          placeholder='Email'/>" +
                                            "<b class='tooltip tooltip-top-right'><i class='fa fa-envelope-o txt-color-teal'>" +
                                        "</i> Please enter company's email</b>" +
                                    "</label></section>" +
                                    "<section class='col col-1'>" +
                                         "<button type='button' class='btn  btn-sm btn-danger email-remove'>" +
                                        "<span class='glyphicon glyphicon-remove'></span>" +
                                        "</button>" +
									"</section></div>";
        }

        conteudoemail += "</section>" +
                                    "<section class='col col-1'>" +
                                         "<button type='button' class='btn  btn-sm btn-success' onclick='add_email()'>" +
                                        "<span class='glyphicon glyphicon-plus'></span>" +
                                        "</button>" +
									"</section> ";

        $(document).on('click', '.email-remove', function () {
            $(this).parent().parent().remove();
        });

    } else {
        conteudoemail = "<section class='col col-5 criaemail'>" +
                                     "<label class='input'> <i class='icon-append fa fa-envelope-o '></i>" +
                                         "<input type='email' name='email[]' required='required' title='Please enter email' placeholder='Email' value='" + mail[0] + "'/>" +
                                         "<b class='tooltip tooltip-top-right'><i class='fa fa-envelope-o txt-color-teal'></i> Please enter email</b>" +

                                     "</label><br />" +
                                       "</section>" +
                                    "<section class='col col-1'>" +
                                         "<button type='button' class='btn  btn-sm btn-success' onclick='add_email()'>" +
                                        "<span class='glyphicon glyphicon-plus'></span>" +
                                        "</button>" +
									"</section> ";

    }

    document.getElementById("orderform1").style.display = 'block';
    document.getElementById("table1").style.display = 'none';
    document.getElementById("edit").style.display = 'none';
    document.getElementById("FormItens").onload = preencheeditCompany(idc);
    document.getElementById("FormItens").onload = "<script type='text/javascript'>" +
        loadScript("../Js/company/edit.js", pagefunction) + "</script>";


    document.getElementById("FormItens").innerHTML = "<div class='row'><input type='hidden' value='" + idc + "' name='idCompany'/>" +
									"<section class='col col-xs-6'>" +
									"	<label class='input'> <i class='icon-append fa fa-user'></i>" +
									"		<input type='text' id='name' name='name' placeholder='Name' maxlength='50' autofocus='autofocus' value='" + co.empresa + "'/>" +
                                     "       <b class='tooltip tooltip-top-right'><i class='fa fa-user txt-color-teal'></i> Please enter company's name</b>" +
										"</label>" +
									"</section>" +
                                    "<section class='col col-xs-6'>" +
									"	<label class='input'>" +
									"  	<input type='file' id='files'  name='files'/> <input type='hidden' id='filecompany' name='filecompany'/>" +

										"</label><div id='resposta'></div>" +
									"</section>" +

                                    "</div>" +
                                "<div class='row'>" +
                                    "<section class='col col-6'>" +
                            			"<label class='input'> <i class='icon-append fa fa-info'></i>" +
											"<input type='text'  name='cnpj' data-mask='99.999.999/9999-99' placeholder='CNPJ' maxlength='18' value='" + co.cnpj + "'>" +
                                            "<b class='tooltip tooltip-top-right'><i class='fa fa-info txt-color-teal'></i> Please enter company's cpf</b>" +
										"</label>" +
									"</section>" +      
                                    "<section class='col col-6'>" +
										"<label class='input'> <i class='icon-append fa fa-info '></i>" +
											"<input type='text' name='area' placeholder='Profession'  value='" + co.area + "'/>" +
                                            "<b class='tooltip tooltip-top-right'><i class='fa fa-info txt-color-teal'></i> Please enter business area</b>" +
										"</label>" +
									"</section>" +
                                    "</div>" +
                                    "<div class='row'>" +
									"<section class='col col-6'>" +
										"<label class='input'> <i class='icon-append fa fa-pencil-square-o '></i>" +
											"<input type='text' name='zip' placeholder='Zip Code' data-mask='99999-999' maxlength='9' value='" + co.zip + "'/>" +
                                            "<b class='tooltip tooltip-top-right'><i class='fa fa-pencil-square-o txt-color-teal'></i> Please enter company's zip Code</b>" +
										"</label>" +
									"</section>" +                               
                                    "<section class='col col-6'>" +
										"<label class='input'> <i class='icon-append fa fa-pencil-square-o '></i>" +
											"<input type='text' name='street' placeholder='Street' maxlength='200' value='" + co.street + "'/>" +
                                            "<b class='tooltip tooltip-top-right'><i class='fa fa-pencil-square-o txt-color-teal'></i> Please enter company's street</b>" +
										"</label>" +
									"</section>" +
                                    "</div>" +
									"<div class='row'>" +
									"<section class='col col-6'>" +
										"<label class='input'> <i class='icon-append fa fa-pencil-square-o '></i>" +
											"<input type='number' name='number' value='" + co.number + "'/>" +
                                            "<b class='tooltip tooltip-top-right'><i class='fa fa-pencil-square-o txt-color-teal'></i> Please enter company's number</b>" +
										"</label>" +
									"</section>" +									
									"<section class='col col-6'>" +
										"<label class='input'> <i class='icon-append fa fa-pencil-square-o '></i>" +
											"<input type='text' name='neighborhood' placeholder='Neighborhood' maxlength='50' value='" + co.neighborhood + "'/>" +
                                            "<b class='tooltip tooltip-top-right'><i class='fa fa-pencil-square-o txt-color-teal'></i> Please enter company's neighborhood</b>" +
										"</label>" +
									"</section>" +
                                    "</div>" +
                                 "<div class='row'>" +
									"<section class='col col-xs-12 '>" +
										"<label class='input'> <i class='icon-append fa fa-pencil-square-o '></i>" +
											"<input type='text' name='complement' placeholder='Complement' maxlength='200' value='" + co.complement + "'/>" +
                                            "<b class='tooltip tooltip-top-right'><i class='fa fa-pencil-square-o txt-color-teal'></i> Please enter company's complement</b>" +
										"</label>" +
									"</section>" +
								"</div>" +
                                "<div class='row'>" +
									"<section class='col col-6'>" +
										"<label class='select' name='stateedit' id='stateedit'>" +
											"</label>" +
									"</section>" +
									"<section class='col col-6'>" +
										"<label class='select'name='cityedit' id='cityedit'>" +
                                             "</label>" +
									"</section>" +
								"</div>	" +
                                "</fieldset>" +
                            "<fieldset>" +
                                "<legend>Communication</legend>" +
								"<div class='row'>" +
								  conteudoemail + conteudotel
								"</div>";

								$('#stateedit').change(function () {
								    buscaCidade('stateCompany', 'cityCompany');
								});
                                
								upload();
}

function preencheeditCompany(id) {
    idc = id;
    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetCompany.aspx?id=" + id + "&acao=preenche",

        success: function (data) {

            if (data != null) {
                $.each(data, function (index, c) {

                    var op = { 'estados': c.estados, 'cidades': c.cidades };
                    document.getElementById("stateedit").innerHTML = op.estados;
                    document.getElementById("cityedit").innerHTML = op.cidades;

                });
            }
        }
    });
}


pageSetUp();


// pagefunction

var pagefunction = function () {

    $('.superbox').SuperBox();


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
        $('#registercompany').dialog('open');
        return false;

    });

    $('#cancel').click(function () {

        $('#registercompany').dialog("close");
    });

    $('#registercompany').dialog({
        autoOpen: false,
        width: 900,
        resizable: true,
        modal: true,
        title: "<div class='widget-header'><h4><i class='fa fa-pencil'></i> Register Company</h4></div>",
        position: 'center',

    });

    $('#viewcompany').dialog({
        autoOpen: false,
        width: 900,
        resizable: true,
        modal: true,
        top: 0,
        title: "<div class='widget-header'><h4><i class='fa fa-eye'></i>Company</h4></div>",
        position: 'top',
        
    });


    $('#deletecompany').dialog({
        autoOpen: false,
        width: 400,
        resizable: true,
        modal: true,
        title: "<div class='widget-header'><h4><i class='fa fa-pencil'></i> Delete Company</h4></div>",
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
                DeleteCompanyYes();
            }
        }]
    });

    $('#cancelview').click(function () {
        var formview = document.getElementById("orderform1");
        formview.style.display = 'none';
        $("#FormItens").empty();
        var tab = document.getElementById("table1");
        tab.style.display = 'block';
        var botaoedit = document.getElementById("edit");
        botaoedit.style.display = 'block';
    });

    $(function () {
        // Validation
        $("#orderform").validate({
            // Rules for form validation
            rules: {
                name: {
                    required: true
                },
                cnpj: {
                    required: true
                },
                area: {
                    required: true
                },
                zip: {
                    required: true
                },
                street: {
                    required: true
                },
                number: {
                    required: true
                },
                neighborhood: {
                    required: true
                },
                state: {
                    required: true
                },
                city: {
                    required: true
                },
                email: {
                    required: true
                },
                phone: {
                    required: true
                }
            },

            // Messages for form validation
            messages: {
                name: {
                    required: 'Please enter name'
                },
                cnpj: {
                    required: 'Please enter cnpj'
                },
                area: {
                    required: 'Please enter area of company'
                },
                zip: {
                    required: 'Please enter zip code'
                },
                street: {
                    required: 'Please enter street'
                },
                number: {
                    required: 'Please enter number'
                },
                neighborhood: {
                    required: 'Please enter neighborhood'
                },
                state: {
                    required: 'Please enter state'
                },
                city: {
                    required: 'Please enter city'
                },
                email: {
                    required: 'Please enter email'
                },
                phone: {
                    required: 'Please enter phone'
                }
            },

            // Do not change code below
            errorPlacement: function (error, element) {
                error.insertAfter(element.parent());
            }

        });

        // Validation
        $("#orderform1").validate({
            // Rules for form validation
            rules: {
                name: {
                    required: true
                },
                cnpj: {
                    required: true
                },
                area: {
                    required: true
                },
                zip: {
                    required: true
                },
                street: {
                    required: true
                },
                number: {
                    required: true
                },
                neighborhood: {
                    required: true
                },
                state: {
                    required: true
                },
                city: {
                    required: true
                },
                email: {
                    required: true
                },
                phone: {
                    required: true
                }
            },

            // Messages for form validation
            messages: {
                name: {
                    required: 'Please enter name'
                },
                cnpj: {
                    required: 'Please enter cnpj'
                },
                area: {
                    required: 'Please enter area of company'
                },
                zip: {
                    required: 'Please enter zip code'
                },
                street: {
                    required: 'Please enter street'
                },
                number: {
                    required: 'Please enter number'
                },
                neighborhood: {
                    required: 'Please enter neighborhood'
                },
                state: {
                    required: 'Please enter state'
                },
                city: {
                    required: 'Please enter city'
                },
                email: {
                    required: 'Please enter email'
                },
                phone: {
                    required: 'Please enter phone'
                }
            },

            // Do not change code below
            errorPlacement: function (error, element) {
                error.insertAfter(element.parent());
            }

        });

    })

};

// end pagefunction

// run pagefunction on load

// load bootstrap-progress bar script
loadScript("../Js/plugin/superbox/superbox.min.js", pagefunction);

///////////////////////////Upload de imagens

function upload() {
    $(document).ready(function () {        
        var interval = 0;
        var options = {
            action: '../Ajax/FileUpload.ashx',
            autoSubmit: true,
            onSubmit: function (file, ext) {
                {
                    interval = window.setInterval(function () {
                    }, 200);
                }
            },
            onComplete: function (file, response) {
                $('#filecompany').val(file)               
            }
        };
        new AjaxUpload('#files', options);
    });
}

