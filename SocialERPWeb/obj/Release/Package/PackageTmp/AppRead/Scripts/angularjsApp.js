////define custom directive - this provides a way of loading the page after the home page has been initialised
angular.module("socialERPApp", [])
.directive('mailItem', function () {
    return {
        restrict: 'A',// We have created Attribute because in some browsers Element creates issue.
        templateUrl: '../Views/MailItem.html'
    };
});

