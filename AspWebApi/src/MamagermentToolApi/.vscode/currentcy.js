var currencyModule = angular.module('currencyApp', []);
 
currencyModule.controller('currencyController', function ($scope,currencyService) {
    $scope.fromcurrval = 1;
    $scope.fromcurrency = "EUR";
    $scope.tocurrency = "USD";
    $scope.loading = true;
    $scope.update = function () {
        if ($scope.fromcurrency == $scope.tocurrency) {
            $scope.outcurrvalue = $scope.fromcurrval;
        }
        else if ($scope.fromcurrval == "") {
            $scope.outcurrvalue = "";
        }
        else {
            $scope.loading = true;
            currencyService.calculate($scope.fromcurrency, $scope.fromcurrval, $scope.tocurrency).success(function (outcurrvalue) {
                $scope.outcurrvalue = outcurrvalue
                $scope.loading = false
            });
        }        
    }         
});
// Factory
currencyModule.factory('currencyService', function ($http) {
    return {
        calculate: function (fromCurrCode, fromCurrVal, toCurrCode) {
            return $http.get('api/currency/convertcurrency/' + fromCurrCode + '/' + fromCurrVal + '/' + toCurrCode);
        }
    }
});
 
currencyModule.directive('isNumber', function (currencyService) {
    return {
        require: 'ngModel',
        link: function (scope) {
            scope.$watch('fromcurrval', function (newValue, oldValue) {
                var arr = String(newValue).split("");
                if (arr.length === 0) {
                    scope.outcurrvalue = "";
                }
                else if (arr.length === 1 && (arr[0] === '.')) return;
                else if (isNaN(newValue)) {
                    scope.fromcurrval = oldValue;
                }
                else {
                    if (scope.fromcurrency === scope.tocurrency) {
                        scope.outcurrvalue = scope.fromcurrval;
                    }
                    else {
                        scope.loading = true;
                        currencyService.calculate(scope.fromcurrency, scope.fromcurrval, scope.tocurrency).success(function (outcurrvalue) {
                            scope.outcurrvalue = outcurrvalue
                            scope.loading = false
                        });                        
                    }
                }                    
            });
        }
    };
});
