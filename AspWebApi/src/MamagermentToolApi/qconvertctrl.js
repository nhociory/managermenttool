var app = angular.module('qconvertctrlmodule', [])
    .controller('QConvertController', function($scope, $http, $log, $interval) {

        $scope.currencyObject = {
                from : "",
                to  : "",
                amount : "",
                amount_converted : "",
                exchangeRate : ""
        };

        $scope.currencyCodes = [{value : 'INR', display : 'Indian Rupee'}, {value : 'USD', display : 'US Dollar'}, {value : 'GBP', display : 'British Pound'}];

        $scope.getexchangerate = function() {

            $log.info("FROM : " + $scope.currencyObject.from);

            $log.info("TO : " + $scope.currencyObject.to);

            $http.get("http://api.decoded.cf/currency.php", {params : {from : $scope.currencyObject.from,
                to : $scope.currencyObject.to, amount : 1}})
                .then(function(response) {

                    $scope.currencyObject.exchangeRate = response.data.amount_converted;

                    $log.info(response.data.amount_converted);


            });

        };


        $interval(function() {
            $scope.getexchangerate();
            console.log('Exchange rates refreshed!');
        }, 5000);

    });

app.filter('toDecimal', function() {
    return function(input, precision) {
        return input.toFixed(precision);
    };
});