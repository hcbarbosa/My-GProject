    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="ProjetoInter.View.Calendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">

        <!--calendario-->
		<div class="jarviswidget jarviswidget-color-green">            			
			<header>
				<span class="widget-icon"> <i class="fa fa-calendar"></i> </span>
				<h2> My Activities </h2>
                <!--Botao de mes/semana/dia-->
				<div class="widget-toolbar">					
					<div class="btn-group">
						<button class="btn dropdown-toggle btn-xs btn-default" data-toggle="dropdown">
							Showing <i class="fa fa-caret-down"></i>
						</button>
						<ul class="dropdown-menu js-status-update pull-right">
							<li>
								<a href="javascript:void(0);" id="mt">Month</a>
							</li>
							<li>
								<a href="javascript:void(0);" id="ag">Week</a>
							</li>
							<li>
								<a href="javascript:void(0);" id="td">Today</a>
							</li>
						</ul>
					</div>
				</div>
			</header>

			<!--dias, onde estao as atividades-->
			<div>
				<div class="widget-body no-padding">					
					<div class="widget-body-toolbar">
						<div id="calendar-buttons">
							<div class="btn-group">
								<a href="javascript:void(0)" class="btn btn-default btn-xs" id="btn-prev"><i class="fa fa-chevron-left"></i></a>
								<a href="javascript:void(0)" class="btn btn-default btn-xs" id="btn-next"><i class="fa fa-chevron-right"></i></a>
							</div>
						</div>
					</div>
					<div id="calendar"></div>					
				</div>
			</div>
		</div>
        <br /><br />
	</div>
    <input type="hidden" id="idgerente" runat="server" />
<script type="text/javascript">

    pageSetUp();


    // pagefunction

    var pagefunction = function () {

        // full calendar

        var date = new Date();
        var d = date.getDate();
        var m = date.getMonth();
        var y = date.getFullYear();

        var hdr = {
            left: 'title',
            center: 'month,agendaWeek,agendaDay',
            right: 'prev,today,next'
        };

        var initDrag = function (e) {


            var eventObject = {
                title: $.trim(e.children().text()), // use the element's text as the event title
                description: $.trim(e.children('span').attr('data-description')),
                icon: $.trim(e.children('span').attr('data-icon')),
                className: $.trim(e.children('span').attr('class')) // use the element's children as the event class
            };
            // store the Event Object in the DOM element so we can get to it later
            e.data('eventObject', eventObject);

            // make the event draggable using jQuery UI
            e.draggable({
                zIndex: 999,
                revert: true, // will cause the event to go back to its
                revertDuration: 0 //  original position after the drag
            });
        };

        var addEvent = function (title, priority, description, icon) {
            title = title.length === 0 ? "Untitled Event" : title;
            description = description.length === 0 ? "No Description" : description;
            icon = icon.length === 0 ? " " : icon;
            priority = priority.length === 0 ? "label label-default" : priority;

            var html = $('<li><span class="' + priority + '" data-description="' + description + '" data-icon="' +
	            icon + '">' + title + '</span></li>').prependTo('ul#external-events').hide().fadeIn();

            $("#event-container").effect("highlight", 800);

            initDrag(html);
        };

        /* initialize the external events
		 -----------------------------------------------------------------*/
        
        function carrega() {
            var id = $('#idgerente').val();
            return $.ajax({
                dataType: "json",
                url: "../Ajax/GetCalendar.aspx?id=" + id,


                success: function (data) {

                    if (data != null) {

                            $('#calendar').fullCalendar({

                                header: hdr,
                                buttonText: {
                                    prev: '<i class="fa fa-chevron-left"></i>',
                                    next: '<i class="fa fa-chevron-right"></i>'
                                },

                                editable: true,
                                droppable: true, // this allows things to be dropped onto the calendar !!!

                                drop: function (date, allDay) { // this function is called when something is dropped

                                    // retrieve the dropped element's stored Event Object
                                    var originalEventObject = $(this).data('eventObject');

                                    // we need to copy it, so that multiple events don't have a reference to the same object
                                    var copiedEventObject = $.extend({}, originalEventObject);

                                    // assign it the date that was reported
                                    copiedEventObject.start = date;
                                    copiedEventObject.allDay = allDay;

                                    $('#calendar').fullCalendar('renderEvent', copiedEventObject, true);

                                    // is the "remove after drop" checkbox checked?
                                    if ($('#drop-remove').is(':checked')) {
                                        // if so, remove the element from the "Draggable Events" list
                                        $(this).remove();
                                    }

                                },

                                select: function (start, end, allDay) {
                                    var title = prompt('Event Title:');
                                    if (title) {
                                        calendar.fullCalendar('renderEvent', {
                                            title: title,
                                            start: start,
                                            end: end,
                                            allDay: allDay
                                        }, true // make the event "stick"
                                        );
                                    }
                                    calendar.fullCalendar('unselect');
                                },

                                events:
                                    data.eventos
                                ,

                                eventRender: function (event, element, icon) {
                                    if (!event.description == "") {
                                        element.find('.fc-event-title').append("<br/><span class='ultra-light'>" + event.description +
                                            "</span>");
                                    }
                                    if (!event.icon == "") {
                                        element.find('.fc-event-title').append("<i class='air air-top-right fa " + event.icon +
                                            " '></i>");
                                    }
                                },

                                windowResize: function (event, ui) {
                                    $('#calendar').fullCalendar('render');
                                }
                            });
                            $('#external-events > li').each(function () {
                                initDrag($(this));
                            });

                            $('#add-event').click(function () {
                                var title = $('#title').val(),
                                    priority = $('input:radio[name=priority]:checked').val(),
                                    description = $('#description').val(),
                                    icon = $('input:radio[name=iconselect]:checked').val();

                                addEvent(title, priority, description, icon);
                            });

                            $('.fc-header-right, .fc-header-center').hide();



                            $('#calendar-buttons #btn-prev').click(function () {
                                $('.fc-button-prev').click();
                                return false;
                            });

                            $('#calendar-buttons #btn-next').click(function () {
                                $('.fc-button-next').click();
                                return false;
                            });

                            $('#calendar-buttons #btn-today').click(function () {
                                $('.fc-button-today').click();
                                return false;
                            });

                            $('#mt').click(function () {
                                $('#calendar').fullCalendar('changeView', 'month');
                            });

                            $('#ag').click(function () {
                                $('#calendar').fullCalendar('changeView', 'agendaWeek');
                            });

                            $('#td').click(function () {
                                $('#calendar').fullCalendar('changeView', 'agendaDay');
                            });



                      

                    }


                },
                error: function () {
                    
                }
            });

        }

        carrega();

        /* initialize the calendar
		 -----------------------------------------------------------------*/
        
        
        /* hide default buttons */
       

    };

    // end pagefunction

    // loadscript and run pagefunction
    loadScript("../Js/plugin/fullcalendar/jquery.fullcalendar.min.js", pagefunction);


</script>
</body>
</html>
