/// <reference path="App.js" />
/// <reference path="../../Scripts/angular.min.js" />


(function () {
    "use strict";

    // The Office initialize function must be run each time a new page is loaded
    Office.initialize = function (reason) {

        $(document).ready(function () {

            app.initialize();

            // Bootstrap Main Content Div with the Angular App
            // Ensure the page is loaded first with the Office Context
            angular.bootstrap($('#mailItemContainer'), ['socialERPApp']);
        });
    };




})();