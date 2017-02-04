

function Show() {
    var projeto = $('#project').val();
    if (projeto != 0) {
        window.location = "Index.aspx#Documents.aspx?projeto=" + projeto;
    }
}

function ShowDocument(doc) {
    document.getElementById("visualizadocumento").style.display = "block";
    var d = document.getElementById("visualizadocumento");
    d.setAttribute("src", "../Documents/" + doc);
}

        pageSetUp();
var pagefunction = function () {


};

// run pagefunction on load

pagefunction();


