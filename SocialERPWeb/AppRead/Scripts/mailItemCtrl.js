//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//           http://www.apache.org/licenses/LICENSE-2.0 
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
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