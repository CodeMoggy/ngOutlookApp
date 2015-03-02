'use strict';
angular.module('socialERPApp')
.controller('mailItemController', ['$scope', 'erpSvc', function ($scope, erpSvc) {

    //setting mail item values from global Variable Office
    var item = Office.cast.item.toItemRead(Office.context.mailbox.item);
    $scope.subject = item.subject;

    var from = app.getSendersEmailAddress(item);

    if (from) {

        $scope.from = from.displayName;

        $scope.fromClick = function () {
            app.showNotification(from.displayName, from.emailAddress);
        };
    }

    $scope.loaded = false;
    $scope.getOrders = function () {
       
        if (from) {
            $scope.message = "Loading..";
            $scope.loaded = true;
            erpSvc.getOrders(from).success(function (result) {                
                $scope.message = "";
                $scope.orders = result;
            }).error(function (err) {
                $scope.message = "Loading..";
                app.showNotification("StatusCode = " + err.status, err.data.Message);
            });
        }

    }
}]);