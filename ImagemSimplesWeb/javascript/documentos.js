function ShowDivPesquisa() {
    var x = document.getElementById("DivPanelPesquisa");
    if (x.style.display === "block") {
        x.style.display = "none";
    } else {
        x.style.display = "block";
        //}
    }
}

function ShowDivPreview() {
    var x = document.getElementById("DivPanelPreview");
    if (x.style.display === "block") {
        x.style.display = "none";
    } else {
        x.style.display = "block";
        //}
    }
}

function PesquisarDocs(parent, getChildrensChildren) {
    var txt = "";
    var link;
    var numeral = "";
    var text;
    var element = document.getElementById("DivPanelPesquisa");
    var c = getCount(element, true);
    for (var i = 1; i <= (c - 5) / 5; i++) {
        console.log(i);
        txt = document.getElementById("txt" + i);
        numeral = i + "=" + txt.value;
        console.log(numeral);
        link = link + numeral + "&";
    }
    link = link.replace("undefined", "");
    link = link.substring(0, link.length - 1)
    console.log(document.URL + "&" + link);
    txt = document.URL.split("&")[0];
    window.location.href = txt + "&" + link;
}

function getCount(parent, getChildrensChildren) {
    var relevantChildren = 0;
    var children = parent.childNodes.length;
    for (var i = 0; i < children; i++) {
        if (parent.childNodes[i].nodeType != 3) {
            if (getChildrensChildren)
                relevantChildren += getCount(parent.childNodes[i], true);
            relevantChildren++;
        }
    }
    return relevantChildren;
}

function openFile(row) {
    var cell = row.cells[0];
    console.log(row.cells[0]);
    var pdfname = cell.textContent;
    $.ajax({
        type: "POST",
        url: 'Documento.aspx/getPath',
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        success: function (data) {
            //window.open(data.d + '\\' + pdfname, '_blank');
            var pdf = document.getElementById('pdfFrame');
            pdf.src = data.d + '\\' + pdfname;
            console.log(data.d + '\\' + pdfname)
        }
    });
}

function openPdfNewTab(row) {
    var cell = row.cells[0];
    var pdfname = cell.textContent;
    $.ajax({
        type: "POST",
        url: 'Documento.aspx/getPath',
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        success: function (data) {
            window.open(data.d + '\\' + pdfname, '_blank');
            //var pdf = document.getElementById('pdfFrame');
            //pdf.src = data.d + '\\' + pdfname;
        }
    });
}
