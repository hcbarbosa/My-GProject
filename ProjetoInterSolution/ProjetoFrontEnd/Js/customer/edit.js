var cl;
var idc;
var tel;
var mail;

function EditCustomer(id) {
    document.getElementById("viewcustomer").style.display = "block";
    idc = id;
    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetCustomer.aspx?id=" + id + "&acao=edit",
        
        success: function (data) {

            if (data != null) {
                $.each(data, function (index, c) {
                    
                    cl = {'cliente': c.cliente , 'cpf': c.cpf , 'profession':c.profession, 'empresa':  c.empresa , 'zip': c.zip , 'street':  c.street , 'number': c.number , 'neighborhood':  c.neighborhood , 'complement':  c.complement , 'state':  c.state , 'city':  c.city , 'login': c.login , 'senha': c.senha, 'img':  c.img, 'email':  c.email , 'phone': c.phone
                    };
                    tel = cl.phone.split(";");
                    mail = cl.email.split(";");                    
                    TableCustomerEdit(cl);

                   
                });
            }


        }
    });
}


function TableCustomerEdit(cl) {
    document.getElementById("teste").innerHTML = 
    "<table class='table table-hover'>"+
    "<thead>"+
    "<tr>"+
    "<th class='col col-xs-4'>Information</th> "+
    "<th class='col col-xs-8'></th>"+
    "</tr>"+
    "</thead>"+
    "<tbody>"+
    "<tr>"+
    "<td> Name:</td>"+      
    "<td> "+cl.cliente+"</td>"+                  
    "</tr>"+
    "<tr>"+
    "<td> Cpf:</td>"+      
    "<td> "+cl.cpf+"</td>"+                  
    "</tr>"+
    "<tr>"+
    "<td> Company: </td>"+
    "<td>"+cl.empresa+"</td> "+                       
    "</tr>" +
    "<tr>" +
    "<td> Profession: </td>" +
    "<td>" + cl.profession + "</td> " +
    "</tr>" +
    "<tr>"+
    "<td> Zip Code:</td>"+      
    "<td>"+cl.zip+"</td>"+                  
    "</tr>"+
    "<tr>"+
    "<td> Street:</td> "+     
    "<td>"+cl.street+"</td>"+                  
    "</tr>"+
    "<tr>"+
    "<td> Number:</td> "+     
    "<td>"+cl.number+"</td>"+                  
    "</tr>"+
    "<tr>"+
    "<td> Neighborhood:</td>"+      
    "<td>"+cl.neighborhood+"</td> "+                 
    "</tr>"+
    "<tr>"+
    "<td> Complement:</td>"+      
    "<td>"+cl.complement+"</td> "+                 
    "</tr>"+
    "<tr>"+
    "<td> State:</td> "+     
    "<td>"+cl.state+"</td>"+                  
    "</tr>"+
    "<tr>"+
    "<td> City:</td>"+      
    "<td>"+cl.city+"</td>"+                  
    "</tr>"+
    "<tr>"+
    "<td> Emails:</td> "+     
    "<td>"+cl.email+"</td>"+                  
    "</tr>"+
    "<tr>"+
    "<td> Phones:</td> "+     
    "<td>"+cl.phone+"</td> "+                 
    "</tr>"+                                 
    "</tbody>"+
    "</table>";
}




function FormCustomerEdit() {

    var conteudoemail;
    var conteudotel;

    if (tel.length > 1 ) {      


        conteudotel = "<section class='col col-5 criaphone'>" +
                                      "<label class='input'> <i class='icon-append fa fa-phone '></i>" +
                                          "<input type='tel' name='phone[]' required='required' title='Please enter your phone' data-mask='(99)9999-9999' placeholder='Phone' maxlength='15' value='" + tel[0] + "'/>" +
                                          "<b class='tooltip tooltip-top-right'><i class='fa fa-phone txt-color-teal'></i> Please enter your phone</b>" +
                                      "</label><br />";
        for (i = 1 ; i < tel.length-1; i++) {
            conteudotel += "<div class='row' style='width:261%;'><section class='col col-5'>" +
              "<label class='input'> <i class='icon-append fa  fa-mobile-phone  '></i>" +
                  "<input type='tel' name='phone[]' required='required' title='Please enter your celphone' value='"+tel[i]+"' " +
                  "data-mask='(99)99999-9999' placeholder='CelPhone' maxlength='15'>" +
                  "<b class='tooltip tooltip-top-right'><i class='fa fa-mobile-phone  txt-color-teal'>" +
              "</i> Please enter your celphone</b>" +
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
                 "<input type='tel' name='phone[]' required='required' title='Please enter your phone' data-mask='(99)9999-9999' placeholder='Phone' maxlength='15' value='" + tel[0] + "'/>" +
                 "<b class='tooltip tooltip-top-right'><i class='fa fa-phone txt-color-teal'></i> Please enter your phone</b>" +
             "</label><br />" +
         "</section>" +
         "<section class='col col-1'>" +
             "<button type='button' class='btn  btn-sm btn-success' onclick='add_phone()'>" +
             "<span class='glyphicon glyphicon-plus'></span>" +
             "</button>" +
         "</section>	"
       
    }
   
    if (mail.length > 1  ) {
        
        conteudoemail = "<section class='col col-5 criaemail'>" +
                                         "<label class='input'> <i class='icon-append fa fa-envelope-o '></i>" +
                                             "<input type='email' name='email[]' required='required' title='Please enter your email' placeholder='Email' value='" + mail[0] + "'/>" +
                                             "<b class='tooltip tooltip-top-right'><i class='fa fa-envelope-o txt-color-teal'></i> Please enter your email</b><br />";
                                             "</label><br />";

        for (i = 1 ; i < mail.length-1; i++) {         


            conteudoemail += "<div class='row' style='width:261%;'><section class='col col-5'>" +
										"<label class='input'> <i class='icon-append fa fa-envelope-o '></i>" +
											"<input type='email' name='email[]' required title='Please enter your email'  value='" + mail[i] + "'          placeholder='Email'/>" +
                                            "<b class='tooltip tooltip-top-right'><i class='fa fa-envelope-o txt-color-teal'>" +
                                        "</i> Please enter customer's email</b>" +
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

    } else
    {
        conteudoemail = "<section class='col col-5 criaemail'>" +
                                     "<label class='input'> <i class='icon-append fa fa-envelope-o '></i>" +
                                         "<input type='email' name='email[]' required='required' title='Please enter your email' placeholder='Email' value='" + mail[0] + "'/>" +
                                         "<b class='tooltip tooltip-top-right'><i class='fa fa-envelope-o txt-color-teal'></i> Please enter company's email</b>" +

                                     "</label><br />"+
                                       "</section>" +
                                    "<section class='col col-1'>" +
                                         "<button type='button' class='btn  btn-sm btn-success' onclick='add_email()'>" +
                                        "<span class='glyphicon glyphicon-plus'></span>" +
                                        "</button>" +
									"</section> ";

    }

    document.getElementById("FormItens").onload = preencheeditCompany(idc);
    document.getElementById("FormItens").innerHTML = "<div class='row'><input type='hidden' value='" + idc + "' name='idCustomer'/>" +
									"<section class='col col-xs-12'>"+
									"	<label class='input'> <i class='icon-append fa fa-user'></i>"+
									"		<input type='text' name='name' placeholder='Name' maxlength='50' autofocus='autofocus' value='"+cl.cliente+"'/>"+
                                     "       <b class='tooltip tooltip-top-right'><i class='fa fa-user txt-color-teal'></i> Please enter customer's name</b>"+
										"</label>"+
									"</section>"+                                   
                                    "</div>"+
                                "<div class='row'>"+
                                    "<section class='col col-6'>"+
                            			"<label class='input'> <i class='icon-append fa fa-info'></i>"+
											"<input type='text' name='cpf' data-mask='999.999.999-99' placeholder='CPF' maxlength='14'/ value='"+cl.cpf+"'>"+
                                            "<b class='tooltip tooltip-top-right'><i class='fa fa-info txt-color-teal'></i> Please enter customer's cpf</b>"+
										"</label>"+
									"</section>"+   
                                     "<section class='col col-6'>" +
                                     "<label class='select'><select style='width:100%' class='select2' name='company' id='companyedit'>"+                                        									        									        
                                             "</select><i></i></label>" +
									"</section>"+                                    
                               "</div>"+
								"<div class='row'>"+
                                    "<section class='col col-6'>"+
										"<label class='input'> <i class='icon-append fa fa-info '></i>"+
											"<input type='text' name='profession' placeholder='Profession'  value='"+cl.profession+"'/>"+
                                            "<b class='tooltip tooltip-top-right'><i class='fa fa-info txt-color-teal'></i> Please enter customer's profession</b>"+										
										"</label>"+
									"</section>"+
									"<section class='col col-6'>"+
										"<label class='input'> <i class='icon-append fa fa-pencil-square-o '></i>"+
											"<input type='text' name='zip' placeholder='Zip Code' data-mask='99999-999' maxlength='9' value='"+cl.zip+"'/>"+
                                            "<b class='tooltip tooltip-top-right'><i class='fa fa-pencil-square-o txt-color-teal'></i> Please enter customer's zip Code</b>"+										
										"</label>"+
									"</section>"+
                                "</div>"+
									"<div class='row'>"+
                                    "<section class='col col-6'>"+
										"<label class='input'> <i class='icon-append fa fa-pencil-square-o '></i>"+
											"<input type='text' name='street' placeholder='Street' maxlength='200' value='"+cl.street+"'/>"+
                                            "<b class='tooltip tooltip-top-right'><i class='fa fa-pencil-square-o txt-color-teal'></i> Please enter customer's street</b>"+										
										"</label>"+
									"</section>"+	
									"<section class='col col-6'>"+
										"<label class='input'> <i class='icon-append fa fa-pencil-square-o '></i>"+
											"<input type='number' name='number' value='"+cl.number+"'/>"+
                                            "<b class='tooltip tooltip-top-right'><i class='fa fa-pencil-square-o txt-color-teal'></i> Please enter customer's number</b>"+										
										"</label>"+
									"</section>"+
									"</div>"+ 
                                 "<div class='row'>"+
									"<section class='col col-6'>"+
										"<label class='input'> <i class='icon-append fa fa-pencil-square-o '></i>"+
											"<input type='text' name='neighborhood' placeholder='Neighborhood' maxlength='50' value='"+cl.neighborhood+"'/>"+
                                            "<b class='tooltip tooltip-top-right'><i class='fa fa-pencil-square-o txt-color-teal'></i> Please enter customer's neighborhood</b>"+										
										"</label>"+
									"</section>"+	
									"<section class='col col-6 '>"+
										"<label class='input'> <i class='icon-append fa fa-pencil-square-o '></i>"+
											"<input type='text' name='complement' placeholder='Complement' maxlength='200' value='"+cl.complement+"'/>"+
                                            "<b class='tooltip tooltip-top-right'><i class='fa fa-pencil-square-o txt-color-teal'></i> Please enter customer's complement</b>"+										
										"</label>"+									
									"</section>"+
								"</div>"+
                                "<div class='row'>"+
									"<section class='col col-6'>"+
										"<label class='select' name='stateedit' id='stateedit'>" +
											"</label>"+
									"</section>"+
									"<section class='col col-6'>"+
										"<label class='select'name='cityedit' id='cityedit'>" +
                                             "</label>" +
									"</section>"+
								"</div>	"+	
                                "</fieldset>"+
                            "<fieldset>"+
                                "<legend>Communication</legend>"+								
								"<div class='row'>"+
								  conteudoemail+conteudotel									
								+ "</div>";


    $('#stateedit').change(function () {
        buscaCidade('state', 'city1');
    });
}

function preencheeditCompany(id) {
    idc = id;
    return $.ajax({
        dataType: "json",
        url: "../Ajax/GetCustomer.aspx?id=" + id + "&acao=preenche",

        success: function (data) {

            if (data != null) {
                $.each(data, function (index, c) {

                    var op = {'companies': c.companies, 'estados': c.estados, 'cidades':c.cidades
                    };
                    document.getElementById("companyedit").innerHTML = op.companies;
                    document.getElementById("stateedit").innerHTML = op.estados;
                    document.getElementById("cityedit").innerHTML = op.cidades;
                   
                });
            }
        }
    });
}


//altera cliente
function UpdateCustomer() {
    $("#orderform1").submit(function (event) {
    });
}

function DeleteCustomer(id,nome) {
    idc = id;
    document.getElementById("deletecustomer").style.display = "block";
    document.getElementById("cliente").innerHTML = "<h3>" + nome + "</h3>";
}

function DeleteCustomerYes() {   
        return $.ajax({
            dataType: "json",
            url: "../Ajax/GetCustomer.aspx?id=" + idc + "&acao=delete",
            success: location.reload()
        });
}


function add_email() {
    //alert(Profoption)
    $('.criaemail').append(

                                        "<div class='row' style='width:260%;'><section class='col col-5'>" +
										"<label class='input'> <i class='icon-append fa fa-envelope-o '></i>" +
											"<input type='email' name='email[]' required title='Please enter your email'            placeholder='Email'/>" +
                                            "<b class='tooltip tooltip-top-right'><i class='fa fa-envelope-o txt-color-teal'>" +
                                        "</i> Please enter customer's email</b>" +
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
										"<label class='input'> <i class='icon-append fa  fa-mobile-phone  '></i>" +
											"<input type='tel' name='phone[]' required='required' title='Please enter your celphone' " +
                                            "data-mask='(99)99999-9999' placeholder='CelPhone' maxlength='15'>" +
                                            "<b class='tooltip tooltip-top-right'><i class='fa fa-mobile-phone  txt-color-teal'>" +
                                        "</i> Please enter customer's phone</b>" +
                                    "</label></section>" +
                                    "<section class='col col-1'>" +
                                         "<button type='button' class='btn  btn-sm btn-danger phone-remove'>" +
                                        "<span class='glyphicon glyphicon-remove'></span>" +
                                        "</button>" +
									"</section></div>");


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
                        options += '<option value="' + cidade.id + '">' + cidade.nome + '</option>';
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


pageSetUp();


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
       document.getElementById("registercustomer").style.display = "block";
        $('#registercustomer').dialog('open');
        return false;

    });

    $('.view').click(function () {
        $('#viewcustomer').dialog('open');
        var formview = document.getElementById("orderform1");
        formview.style.display = 'none';
        var tab = document.getElementById("table1");
        tab.style.display = 'block';
        var botaoedit = document.getElementById("edit");
        botaoedit.style.display = 'block';
        return false;

    });

    $('.delete').click(function () {
        $('#deletecustomer').dialog('open');
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
        $("#FormItens").empty();
        var tab = document.getElementById("table1");
        tab.style.display = 'block';
        var botaoedit = document.getElementById("edit");
        botaoedit.style.display = 'block';
    });

    $('#cancel').click(function () {
        $('#registercustomer').dialog("close");
    });

    $('#viewcustomer').dialog({
        autoOpen: false,
        width: 900,
        resizable: true,
        modal: true,
        top:0,
        title: "<div class='widget-header'><h4><i class='fa fa-eye'></i>Customer</h4></div>",
        position: 'top',
        

    });

    $('#deletecustomer').dialog({
        autoOpen: false,
        width: 400,
        resizable: true,
        modal: true,
        title: "<div class='widget-header'><h4><i class='fa fa-pencil'></i> Delete Customer</h4></div>",
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
                DeleteCustomerYes();
            }
        }]
    });

    $('#registercustomer').dialog({
        autoOpen: false,
        width: 900,
        resizable: true,
        modal: true,
        title: "<div class='widget-header'><h4><i class='fa fa-pencil'></i> Register Customer</h4></div>",
        position: 'center',

    });

    $(function () {
        // Validation
        $("#orderform").validate({
            // Rules for form validation
            rules: {
                name: {
                    required: true
                },
                cpf: {
                    required: true
                },
                company: {
                    required: true
                },
                profession:{
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
                login: {
                    required: true
                },
                password: {
                    required: true,
                    minlength: 6,
                    maxlength: 20
                },
                confirmpassword: {
                    required: true,
                    minlength: 6,
                    maxlength: 20,
                    equalTo: '#password'

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
                    required: 'Please enter your name'
                },
                cpf: {
                    required: 'Please enter your cpf'
                },
                company: {
                    required: 'Please enter your company'
                },
                profession: {
                    required: 'Please enter your profession'
                },
                zip: {
                    required: 'Please enter your zip code'
                },
                street: {
                    required: 'Please enter your street'
                },
                number: {
                    required: 'Please enter your number'
                },
                neighborhood: {
                    required: 'Please enter your neighborhood'
                },
                state: {
                    required: 'Please enter your state'
                },
                city: {
                    required: 'Please enter your city'
                },
                login: {
                    required: 'Please enter your login'
                },
                email: {
                    required: 'Please enter your email'
                },
                phone: {
                    required: 'Please enter your phone'
                },
                password: {
                    required: 'Please enter your password (minlenght:6)'
                },
                confirmpassword: {
                    required: 'Please enter your confirm password (equals password)'
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
                name: {
                    required: true
                },
                cpf: {
                    required: true
                },
                company: {
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
                login: {
                    required: true
                },
                password: {
                    required: true,
                    minlength: 6,
                    maxlength: 20
                },
                confirmpassword: {
                    required: true,
                    minlength: 6,
                    maxlength: 20,
                    equalTo: '#passwordedit'

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
                    required: 'Please enter your name'
                },
                cpf: {
                    required: 'Please enter your cpf'
                },
                company: {
                    required: 'Please enter your companies'
                },
                zip: {
                    required: 'Please enter your zip code'
                },
                street: {
                    required: 'Please enter your street'
                },
                number: {
                    required: 'Please enter your number'
                },
                neighborhood: {
                    required: 'Please enter your neighborhood'
                },
                state: {
                    required: 'Please enter your state'
                },
                city: {
                    required: 'Please enter your city'
                },
                login: {
                    required: 'Please enter your login'
                },
                email: {
                    required: 'Please enter your email'
                },
                phone: {
                    required: 'Please enter your phone'
                },
                password: {
                    required: 'Please enter your password (minlenght:6)'
                },
                confirmpassword: {
                    required: 'Please enter your confirm password (equals password)'
                }
            },

            // Do not change code below
            errorPlacement: function (error, element) {
                error.insertAfter(element.parent());
            }

        });
    })

};

loadScript("../Js/plugin/datatables/jquery.dataTables.min.js", function () {
    loadScript("../Js/plugin/datatables/dataTables.colVis.min.js", function () {
        loadScript("../Js/plugin/datatables/dataTables.tableTools.min.js", function () {
            loadScript("../Js/plugin/datatables/dataTables.bootstrap.min.js", function () {
                loadScript("../Js/plugin/datatable-responsive/datatables.responsive.min.js", pagefunction)
            });
        });
    });
});