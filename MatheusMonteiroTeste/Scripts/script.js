var app = angular.module('myApp', ["ngRoute"]);
app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            controller: "listController",
            templateUrl: "Pages/list.html"
        })
        .when("/propriedades", {
            controller: "propriedadesController",
            templateUrl: "Pages/propriedades.html"
        })
        .when("/propriedades/:key", {
            controller: "propriedadesController",
            templateUrl: "Pages/propriedades.html"
        })
});
app.controller('propriedadesController', function ($scope, $routeParams) {
    $scope.key = $routeParams.key;

    $scope.model = null;
    $scope.getModel = function (retorno) {
        console.log(retorno);
        if (!isNull(retorno)) {
            $scope.model = retorno;
            $scope.produtos = $("#produtos").DataTable({
                "data": $scope.model.Produtos,
                "columns": [
                    { "data": "Id" },
                    { "data": "Nome" },
                    { "data": "Valor" },
                    { "data": "Tipo" },
                    { "data": "Quantidade" }
                ]
            });
            $('#produtos tbody').on('click', 'tr', function () {
                $scope.modalP = $scope.produtos.row(this).data();
                $('#modalProduto').modal('show');
                $scope.$applyAsync();
            });
            $scope.$applyAsync();
            return true;
        }
        //newHttp("Clientes", null, $scope.getModel, "GET");
        newHttp("Clientes/Details/" + $scope.key, null, $scope.getModel, "GET");
        // editar newHttp("Clientes/Details/" + $scope.key, $scope.model, $scope.getModel, "POST");
    }
    if ($scope.key != undefined && $scope.key != null)
        $scope.getModel();

    $scope.termino = function () {
        location.reload();
    }
    $scope.inserirProduto = function (produto) {
        if (produto == undefined) {
            $('#modalProduto').modal('show');
            return;
        }
        produto.Cliente = $scope.key;
        if (produto.Id == undefined) {
            //alert("criando produto");
            newHttp("Produtos/Create", produto, $scope.termino, "POST");
        } else {
            //alert("editando produto");
            newHttp("Produtos/Edit/" + produto.Id, produto, $scope.termino, "POST");

        }
        console.log(produto);
    }
    $scope.save = function (retorno) {
        //$scope.model.ClienteProduto = null;
        if ($scope.model.DataCadastro != undefined && $scope.model.DataCadastro != null) {
            var d = new Date($scope.model.DataCadastro);
            var dt = d.getDate();
            var mn = d.getMonth();
            //var mn++;
            var yy = d.getFullYear();
            $scope.model.DataCadastro = dt + "/" + mn + "/" + yy;
        }
        if (!isNull(retorno)) {
            $scope.model = retorno;
            $scope.$applyAsync();
            return true;
        }
        if ($scope.key == undefined || $scope.key == null) {
            //alert("criando produto");
            newHttp("Clientes/Create", $scope.model, null, "POST");
        } else {
            //alert("editando produto");
            newHttp("Clientes/Edit/" + $scope.key, $scope.model, null, "POST");
        }
    }
});
app.controller('listController', function ($scope) {
    $scope.model = null;
    $scope.inserirCliente = function () {
        window.location.href = "/#!/propriedades/";
    }
    $scope.getList = function (retorno) {
        if (!isNull(retorno)) {
            $scope.model = retorno;
            $scope.tabela = $("#example").DataTable({
                "data": retorno,
                "columns": [
                    { "data": "Id" },
                    { "data": "Nome" },
                    { "data": "CPF_CNPJ" },
                    { "data": "DataCadastroString" }
                ]
            });
            $('#example tbody').on('click', 'tr', function () {
                var d = $scope.tabela.row(this).data();
                window.location.href = "/#!/propriedades/" + d.Id;
            });
            $scope.$applyAsync();
            return true;
        }
        newHttp("Clientes", null, $scope.getList);
    }
    $scope.getList();
});

var urlApi = "http://localhost:65218";

function newHttp(rota, dados, callback, method, qtd) {
    if (qtd == undefined) {
        qtd = 0;
    } else {
        qtd++;
    }
    //$scope.app.aguarde(true);
    if (callback == undefined) callback = null;
    if (method == undefined) method = "GET";
    jQuery.ajax({
        url: urlApi + "/" + rota, //URL de destino
        type: method,
        data: dados,
        dataType: "json", //Tipo de Retorno
        success: function (json) { //Se ocorrer tudo certo
            console.log(json);
            //$scope.app.aguarde(false);
            if (callback != null) callback(json);
        },
        error: function (request, status, error) {
            //$scope.app.aguarde(false);
            if (qtd < 2) newHttp(dados, callback, method, qtd);
        }
    });
}

function isNull(value, isBlank) {
    if (isBlank != undefined && isBlank == false)
        return (value == undefined || value == null);

    return (value == undefined || value == null || value == "");
}
