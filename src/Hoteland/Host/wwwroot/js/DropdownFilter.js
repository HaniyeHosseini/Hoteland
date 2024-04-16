$(document).ready(function () {
    $("#country").on("change", function () {
        var countryId = $("#country").val;
        $.ajax({
            url: "@(Url.Action("FilterCitiesByCountry", "Hotel"))",
            success: function (data) {
                var cities = [];
                for (i = 0; i < data.length; i++) {
                    cities.push(data[i]);
                }
                $("#city").val = cities;
            },
        })
    })
});

