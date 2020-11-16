function SalvarTelefone() {
    //Nome
    var nome = $("#nome").val();
    //Deve ser inserido devido ao tratamento de segurança "URL":
    var token = $('input[name="__RequestVerificationToken"]').val();
    var tokenadr = $('form[action="/Pessoa/Create"] input[name = "__RequestVerificationToken"]').val();
    var headers = {};
    var headersadr = {};
    headers['__RequestVerificationToken'] = token;
    headersadr['__RequestVerificationToken'] = tokenadr;
    //Gravar
    var url = "/tb_pessoa/Create";
    $.ajax({
        url: url
        , type: "POST"
        , datatype: "json"
        , headers: headersadr
        , data: { Id: 0, Nome: nome, __RequestVerificationToken: token }
        , success: function (data) {
            if (data.Resultado > 0) {
                debugger;
                ListarItens(data.Resultado);
            }
        }
    });
}
function ListarItens(idPessoa) {
    debugger;
    var url = "/Itens/ListarItens";
    $.ajax({
        url: url
        , type: "GET"
        , data: { id: idPessoa }
        , datatype: "html"
        , success: function (data) {
            var divItens = $("#divItens");
            divItens.empty();
            divItens.show();
            divItens.html(data);
        }
    });
}
function SalvarTelefones() {
    debugger;
    var numero = $("#numero").val();
    var tipo = $("#tipo").val();
    var idPessoa = $("#idPessoa").val();

    var url = "/Itens/SalvarTelefones";
    $.ajax({
        url: url
        , data: { numero: numero, tipo: tipo, idPessoa: idPessoa }
        , type: "GET"
        , datatype: "html"
        , success: function (data) {
            if (data.Resultado > 0) {
                ListarItens(idPessoa);
            }
        }
    });
}