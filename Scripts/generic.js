function addRoute_Country_onChange(el) {
    console.log(el);
    var countryId = el.value;
    console.log(countryId);

    $.ajax({
        url: 'GetAreas',
        type: 'get',
        data: { countryId: countryId },
        dataType: 'json',
        success: function (response) {

            var len = response.length;
            console.log(response);
            $("#area_dropdown").empty();
            var default_value = null;
            var default_text = "Select Area"
            $("#area_dropdown").append("<option value='" + default_value + "'>" + default_text + "</option>");
            for (var i = 0; i < len; i++) {
                var id = response[i]['Id'];
                var name = response[i]['Name'];

                $("#area_dropdown").append("<option value='" + id + "'>" + name + "</option>");
            }
        }
    });

}

function addRoute_Area_onChange(el) {
    console.log(el);
    var areaId = el.value;
    console.log(areaId);

    $.ajax({
        url: 'GetCrags',
        type: 'get',
        data: { areaId: areaId },
        dataType: 'json',
        success: function (response) {

            var len = response.length;
            console.log(response);
            $("#crag_dropdown").empty();
            var default_value = null;
            var default_text = "Select Crag"
            $("#crag_dropdown").append("<option value='" + default_value + "'>" + default_text + "</option>");
            for (var i = 0; i < len; i++) {
                var id = response[i]['Id'];
                var name = response[i]['Name'];

                $("#crag_dropdown").append("<option value='" + id + "'>" + name + "</option>");
            }
        }
    });
}

function addRoute_Crag_onChange(el) {
    console.log(el);
    var cragId = el.value;
    console.log(cragId);

    $.ajax({
        url: 'GetSectors',
        type: 'get',
        data: { cragId: cragId },
        dataType: 'json',
        success: function (response) {

            var len = response.length;
            console.log(response);
            $("#sector_dropdown").empty();
            var default_value = null;
            var default_text = "Select Sector"
            $("#sector_dropdown").append("<option value='" + default_value + "'>" + default_text + "</option>");
            for (var i = 0; i < len; i++) {
                var id = response[i]['Id'];
                var name = response[i]['Name'];

                $("#sector_dropdown").append("<option value='" + id + "'>" + name + "</option>");
            }
        }
    });
}

