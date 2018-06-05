function SalvarIndexacao() {
    var q = document.getElementById("qtdeatb");
    var atribs = "";
    for (var i = 1; i <= q.value; i++) {
        var x = document.getElementById("txt" + i);
        atribs = atribs + ";" + x.value;
        atribs[i] = x.value;
    }

    var idcateg = document.getElementById("idcateg").value;
    var nmfile = document.getElementById("nmfile").value;

    $.ajax({
        type: "POST",
        url: 'Indexar.aspx/SalvarIndexacao',
        data: "{atribs:'" + atribs + "', idcateg:'" + idcateg + "', nmfile:'" + nmfile + "'}",
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        success: function (ret) {
            if (ret.d == "") {
                window.location = "../Documentos/ListaIndexar";
            } else {
                var lblerro = document.getElementById("lblMsgErro");
                lblerro.textContent = ret.d;
            }

        }
    });

}