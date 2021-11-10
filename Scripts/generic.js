
//Add Route
function addRoute_Country_onChange(el) {
    var countryId = el.value;
    AreaDropdown_Populate(countryId, $("#area_dropdown"));
}

function addRoute_Area_onChange(el) {
    var areaId = el.value;
    CragDropdown_Populate(areaId, $("#crag_dropdown"));
}

function addRoute_Crag_onChange(el) {
    var cragId = el.value;
    SectorDropdown_Populate(cragId, $("#sector_dropdown"));
}

function addClimb_Country_onChange(el) {
    var countryId = el.value;
    AreaDropdown_Populate(countryId, $("#area_dropdown"));
}

function addClimb_Area_onChange(el) {
    var areaId = el.value;
    CragDropdown_Populate(areaId, $("#crag_dropdown"));
}

function addClimb_Crag_onChange(el) {
    var cragId = el.value;
    SectorDropdown_Populate(cragId, $("#sector_dropdown"));
}

function addClimb_Sector_onChange(el) {
    var sectorId = el.value;
    RouteDropdown_Populate(sectorId, $("#route_dropdown"));
}


//Generic
function AreaDropdown_Populate(countryId, areaDropdown) {
    $(areaDropdown).empty();
    $(areaDropdown).change();
    if (countryId == null || countryId == "") {
        return;
    }
    $.ajax({
        url: '/Area/GetAreasByCountry',
        type: 'get',
        data: { countryId: countryId },
        dataType: 'json',
        success: function (response) {
            PopulateDropdown(response, areaDropdown);
        }
    });
}

function CragDropdown_Populate(areaId, cragDropdown) {
    $(cragDropdown).empty();
    $(cragDropdown).change();
    if (areaId == null || areaId == "") {
        return;
    }
    $.ajax({
        url: '/Crag/GetCragsByArea',
        type: 'get',
        data: { areaId: areaId },
        dataType: 'json',
        success: function (response) {
            PopulateDropdown(response, cragDropdown);
        }
    });
}

function SectorDropdown_Populate(cragId, sectorDropdown) {
    $(sectorDropdown).empty();
    $(sectorDropdown).change();
    if (cragId == null || cragId == "") {
        return;
    }
    $.ajax({
        url: '/Sector/GetSectorsByCrag',
        type: 'get',
        data: { cragId: cragId },
        dataType: 'json',
        success: function (response) {
            PopulateDropdown(response, sectorDropdown);
        }
    });
}

function RouteDropdown_Populate(sectorId, routeDropdown) {
    $(routeDropdown).empty();
    $(routeDropdown).change();
    if (sectorId == null || sectorId == "") {
        return;
    }
    $.ajax({
        url: '/Route/GetRoutesBySector',
        type: 'get',
        data: { sectorId: sectorId },
        dataType: 'json',
        success: function (response) {
            PopulateDropdown(response, routeDropdown);
        }
    });
}

function PopulateDropdown(items, dropdownElement) {
    var len = items.length;
    $(dropdownElement).append("<option></option>");
    for (var i = 0; i < len; i++) {
        var id = items[i]['Id'];
        var name = items[i]['Name'];
        $(dropdownElement).append("<option value='" + id + "'>" + name + "</option>");
    }
    var currentValue = $(dropdownElement).attr("data-initial-value");
    if (currentValue == "") {
        return;
    }
    $(dropdownElement).val(currentValue).change();
    $(dropdownElement).removeAttr("data-initial-value");

}

