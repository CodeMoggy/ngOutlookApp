
/* Common app functionality */

var app = (function () {
    "use strict";

    var app = {};

    // Common initialization function (to be called from each page)
    app.initialize = function () {
        $('body').append(
            '<div id="notification-message">' +
                '<div class="padding">' +
                    '<div id="notification-message-close"></div>' +
                    '<div id="notification-message-header"></div>' +
                    '<div id="notification-message-body"></div>' +
                '</div>' +
            '</div>');

        $('#notification-message-close').click(function () {
            $('#notification-message').hide();
        });


        // After initialization, expose a common notification function
        app.showNotification = function (header, text) {
            $('#notification-message-header').text(header);
            $('#notification-message-body').text(text);
            $('#notification-message').slideDown('fast');
        };

        // helper to grab the senders email address
        app.getSendersEmailAddress = function(item) {

            var from = "";

            if (item.itemType === Office.MailboxEnums.ItemType.Message) {
                from = Office.cast.item.toMessageRead(item).from;
            } else if (item.itemType === Office.MailboxEnums.ItemType.Appointment) {
                from = Office.cast.item.toAppointmentRead(item).organizer;
            }

            return from;
        }
    };

    return app;
})();

