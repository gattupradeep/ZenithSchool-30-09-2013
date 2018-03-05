var currentUpdateEvent;
var addStartDate;
var addEndDate;
var globalAllDay;

function updateEvent(event, element) {
    //alert(event.description);

    if ($(this).data("qtip")) $(this).qtip("destroy");

    currentUpdateEvent = event;

    $('#updatedialog').dialog('open');

    $("#eventName").val(event.title);
    $("#eventDesc").val(event.description);
    $("#eventId").val(event.id);
    $("#eventStart").text("" + event.start.toLocaleString());

    if (event.end === null) {
        $("#eventEnd").text("");
    }
    else {
        $("#eventEnd").text("" + event.end.toLocaleString());
    }
    $("#updatecolorBackground").val(event.backgroundcolor);
    $("#updatecolorForeground").val(event.textcolor);
    $("#eventpatrontype").val(event.patrontype);
    $("#eventuserid").val(event.userid);

}

function updateSuccess(updateResult) {
    //alert(updateResult);
}

function deleteSuccess(deleteResult) {
    //alert(deleteResult);
}

function addSuccess(addResult) {
// if addresult is -1, means event was not added
//    alert("added key: " + addResult);

    if (addResult != -1) {
        $('#calendar').fullCalendar('renderEvent',
						{
						    title: $("#addEventName").val(),
						    start: addStartDate,
						    end: addEndDate,
						    id: addResult,
						    description: $("#addEventDesc").val(),
						    backgroundcolor: $("#colorBackground").val(),
						    textcolor: $("#colorForeground").val(),
						    allDay: globalAllDay
						},
						true // make the event "stick"
					);


        $('#calendar').fullCalendar('unselect');
    }

}

function UpdateTimeSuccess(updateResult) {
    //alert(updateResult);
}


function selectDate(start, end, allDay) {

    $('#addDialog').dialog('open');


    $("#addEventStartDate").text("" + start.toLocaleString());
    $("#addEventEndDate").text("" + end.toLocaleString());


    addStartDate = start;
    addEndDate = end;
    globalAllDay = allDay;
    //alert(allDay);

}

function updateEventOnDropResize(event, allDay) {

    //alert("allday: " + allDay);
    var eventToUpdate = {
        id: event.id,
        start: event.start

    };

    if (allDay) {
        eventToUpdate.start.setHours(0, 0, 0);

    }

    if (event.end === null) {
        eventToUpdate.end = eventToUpdate.start;

    }
    else {
        eventToUpdate.end = event.end;
        if (allDay) {
            eventToUpdate.end.setHours(0, 0, 0);
        }
    }

    eventToUpdate.start = eventToUpdate.start.format("dd-MM-yyyy hh:mm:ss tt");
    eventToUpdate.end = eventToUpdate.end.format("dd-MM-yyyy hh:mm:ss tt");

    PageMethods.UpdateEventTime(eventToUpdate, UpdateTimeSuccess);

}

function eventDropped(event, dayDelta, minuteDelta, allDay, revertFunc) {

    if ($(this).data("qtip")) $(this).qtip("destroy");

    updateEventOnDropResize(event, allDay);



}

function eventResized(event, dayDelta, minuteDelta, revertFunc) {

    if ($(this).data("qtip")) $(this).qtip("destroy");

    updateEventOnDropResize(event);

}

function checkForSpecialChars(stringToCheck) {
    var pattern = /[^A-Za-z0-9 ]/;
    return pattern.test(stringToCheck); 
}

$(document).ready(function() {
    // update Dialog
    $('#updatedialog').dialog({
        autoOpen: false,
        width: 470,
        buttons: {
            "update": function() {
//                alert(currentUpdateEvent.title);
                var eventToUpdate = {
                    id: currentUpdateEvent.id,
                    title: $("#eventName").val(),
                    description: $("#eventDesc").val(),
                    backgroundcolor: $("#updatecolorBackground").val(),
                    textcolor: $("#updatecolorForeground").val()
                };

                if (checkForSpecialChars(eventToUpdate.title) || checkForSpecialChars(eventToUpdate.description)) {
                    alert("please enter characters: A to Z, a to z, 0 to 9, spaces");
                }
                else {
                    PageMethods.UpdateEvent(eventToUpdate, updateSuccess);
                    $(this).dialog("close");

                    currentUpdateEvent.title = $("#eventName").val();
                    currentUpdateEvent.description = $("#eventDesc").val();
                    currentUpdateEvent.backgroundcolor = $("#updatecolorBackground").val();
                    currentUpdateEvent.textcolor = $("#updatecolorForeground").val();
                    $('#calendar').fullCalendar('updateEvent', currentUpdateEvent);
                }

            },
            "delete": function() {

                if (confirm("do you really want to delete this event?")) {

                    PageMethods.deleteEvent($("#eventId").val(), deleteSuccess);
                    $(this).dialog("close");
                    $('#calendar').fullCalendar('removeEvents', $("#eventId").val());
                }

            }


        }
    });
    $("#updatecolorSelectorBackground").ColorPicker({
        onShow: function(colpkr) {
            $(colpkr).css("z-index", "10000");
            $(colpkr).fadeIn(500);
            return false;
        },
        onHide: function(colpkr) {
            $(colpkr).fadeOut(500);
            return false;
        },
        onChange: function(hsb, hex, rgb) {
            $("#updatecolorSelectorBackground div").css("backgroundColor", "#" + hex);
            $("#updatecolorBackground").val("#" + hex);
        }
    });
    //$("#colorBackground").val("#1040b0");		
    $("#updatecolorSelectorForeground").ColorPicker({
        onShow: function(colpkr) {
            $(colpkr).css("z-index", "10000");
            $(colpkr).fadeIn(500);
            return false;
        },
        onHide: function(colpkr) {
            $(colpkr).fadeOut(500);
            return false;
        },
        onChange: function(hsb, hex, rgb) {
            $("#updatecolorSelectorForeground div").css("backgroundColor", "#" + hex);
            $("#updatecolorForeground").val("#" + hex);
        }
    });
    /* Barathi- This section start here for color picker */
    /* Barathi- This section start here for color picker */
    /* Barathi- This section start here for color picker */
    $("#colorSelectorBackground").ColorPicker({
        color: "#333333",
        onShow: function(colpkr) {
            $(colpkr).css("z-index", "10000");
            $(colpkr).fadeIn(500);
            return false;
        },
        onHide: function(colpkr) {
            $(colpkr).fadeOut(500);
            return false;
        },
        onChange: function(hsb, hex, rgb) {
            $("#colorSelectorBackground div").css("backgroundColor", "#" + hex);
            $("#colorBackground").val("#" + hex);
        }
    });
    //$("#colorBackground").val("#1040b0");		
    $("#colorSelectorForeground").ColorPicker({
        color: "#ffffff",
        onShow: function(colpkr) {
            $(colpkr).css("z-index", "10000");
            $(colpkr).fadeIn(500);
            return false;
        },
        onHide: function(colpkr) {
            $(colpkr).fadeOut(500);
            return false;
        },
        onChange: function(hsb, hex, rgb) {
            $("#colorSelectorForeground div").css("backgroundColor", "#" + hex);
            $("#colorForeground").val("#" + hex);
        }
    });
    //$("#colorForeground").val("#ffffff");
    /* Barathi- This section ends here for color picker */
    /* Barathi- This section ends here for color picker */
    /* Barathi- This section ends here for color picker */

    //add dialog
    $('#addDialog').dialog({
        autoOpen: false,
        width: 470,
        buttons: {
            "Add": function() {

                //alert("sent:" + addStartDate.format("dd-MM-yyyy hh:mm:ss tt") + "==" + addStartDate.toLocaleString());
                var eventToAdd = {
                    title: $("#addEventName").val(),
                    description: $("#addEventDesc").val(),
                    start: addStartDate.format("dd-MM-yyyy hh:mm:ss tt"),
                    end: addEndDate.format("dd-MM-yyyy hh:mm:ss tt"),
                    backgroundcolor: $("#colorBackground").val(),
                    textcolor: $("#colorForeground").val()

                };

                if (checkForSpecialChars(eventToAdd.title) || checkForSpecialChars(eventToAdd.description)) {
                    alert("please enter characters: A to Z, a to z, 0 to 9, spaces");
                }
                else if (eventToAdd.title == "" && eventToAdd.description == "") {
                    alert("please enter characters");
                }
                else {
                    //alert("sending " + eventToAdd.title);

                    PageMethods.addEvent(eventToAdd, addSuccess);
                    $(this).dialog("close");

                }

            }

        }
    });


    var date = new Date();
    var d = date.getDate();
    var m = date.getMonth();
    var y = date.getFullYear();

    var calendar = $('#calendar').fullCalendar({
        theme: true,
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        eventClick: updateEvent,
        selectable: true,
        selectHelper: true,
        select: selectDate,
        editable: true,
        events: "JsonResponse.ashx",
        eventDrop: eventDropped,
        eventResize: eventResized,

        eventRender: function(event, element, views) {
            //element.draggable = false;
            if (event.className.length > 0) {
                var customStyle = {};
                if (event.backgroundcolor != '') {
                    customStyle['background-color'] = event.backgroundcolor;
                    customStyle['color'] = event.textcolor;
                }
                event.backgroundcolor ? customStyle['backgroundcolor'] = event.backgroundcolor : ''
                $j('.' + event.className + ', .fc-event, .' + event.className + ', .fc-agenda .' + event.className + ' .fc-event-time,.' + event.className + ' a').css(customStyle);
            }




            //alert(event.title);
            element.qtip({
                content: event.description,
                position: { corner: { tooltip: 'bottomRight', target: 'topMiddle'} },
                style: {
                    border: {
                        width: 1,
                        radius: 3,
                        color: event.backgroundcolor

                    },
                    padding: 10,
                    textAlign: 'center',
                    tip: true, // Give it a speech bubble tip with automatic corner detection
                    name: 'cream' // Style it according to the preset 'cream' style
                }

            });



        }


    });

});

