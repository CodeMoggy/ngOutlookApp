'use strict';
angular.module('socialERPApp')
.factory('erpSvc', ['$http', function ($http) {
    return {
        getOrders: function (from) {
            //This call will automatically acquire the access token via the ADAL.js endpoints initialization
            return $http.get('https://socialerp.azurewebsites.net/api/orders?customer=' + from.emailAddress);
        }
    };
}]);