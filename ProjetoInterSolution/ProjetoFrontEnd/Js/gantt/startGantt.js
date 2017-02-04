


function GenrateGantt() {

    $('#gantt_here').empty();
    var projeto = $('#project').val();
    if (projeto != 0) {
        return $.ajax({
            dataType: "json",
            url: "../Ajax/GetGantt.aspx?projeto=" + projeto + "",

            success: function (data) {
                if (data != null) {

                    gantt.init("gantt_here");
                    gantt.clearAll(true);
                    gantt.templates.link_class = function (link) {
                        var types = gantt.config.links;
                        switch (link.type) {
                            case types.finish_to_start:
                                return "finish_to_start";
                                break;
                            case types.start_to_start:
                                return "start_to_start";
                                break;
                            case types.finish_to_finish:
                                return "finish_to_finish";
                                break;
                        }
                    };

                    gantt.parse(data);

                }
            }
        });
    }
    
    
}

