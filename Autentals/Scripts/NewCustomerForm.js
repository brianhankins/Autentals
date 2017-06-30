$(document).ready(function () {
            $('#fnLblError').hide();
            $('#lnLblError').hide();
            $('#bdayLblError').hide();

            var errorFirstName = false;
            var errorLastName = false;
            var errorBday = false;

            $('#FirstName').focusout(function () {
                var firstNameCheck = $('#FirstName').val().length;

                if (firstNameCheck < 2 || firstNameCheck > 20) {
                    $('#fnLblError').html("Error: Enter a name between 2 - 20 characters");
                    $('#fnLblError').show();

                    errorFirstName = false;
                    checkbutton();

                } else {
                    $('#fnLblError').hide();
                    errorFirstName = true;
                    checkbutton();
                };
            });

            $('#LastName').focusout(function () {
                var lastNameCheck = $('#LastName').val().length;

                if (lastNameCheck < 2 || lastNameCheck > 20) {
                    $('#lnLblError').html("Error: Enter a name between 2 - 20 characters");
                    $('#lnLblError').show();

                    errorLastName = false;
                    checkbutton();

                } else {
                    $('#lnLblError').hide();
                    errorLastName = true;
                    checkbutton();
                };
            });

            $('#BirthDate').focusout(function () {
                var userInputDateValue = $('#BirthDate').val();

                var getMinAgeDate = Date.today().addYears(-16);
                var minAgeDate = getMinAgeDate.toString('yyyy-MM-dd');

                if (userInputDateValue > minAgeDate) {
                    $('#bdayLblError').html("Error: You must be at least 16 years old");
                    $('#bdayLblError').show();

                    errorBday = false;
                    checkbutton();

                } else {
                    $('#bdayLblError').hide();
                    errorBday = true;
                    checkbutton();

                };
            });

            var checkbutton = function () {
                if (errorFirstName && errorLastName && errorBday) {
                    $('#submitBtn').removeClass('disabled');
                }
                else {
                    $('#submitBtn').addClass('disabled');
                }
            };
        });