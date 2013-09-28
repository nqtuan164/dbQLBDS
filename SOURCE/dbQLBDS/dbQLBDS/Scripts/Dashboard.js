
///<reference path="jquery-1.10.2.js" />

$("document").ready(function () {
    //loadmap();
    initialize(10.823099, 10.823099);
});





/*/
var map;
function initialize() {
    var mapOptions = {
        zoom: 8,
        center: new google.maps.LatLng(-34.397, 150.644),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById('map-canvas'),
        mapOptions);
}
//*/


//*/
var marker;
var mapOptions;

var loadmap = function () {
    var toado = $("#txtToaDo").val();

    var arr = toado.split(",");
    var lat = arr[0];
    var lng = arr[1];

    if (lat != "" && lng != "") {
        initialize(lat, lng);
    }
}

var initialize = function (lat, lng) {
    mapOptions = {
        zoom: 10,
        center: new google.maps.LatLng(lat, lng),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    }

    var map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);

    marker = new google.maps.Marker({
        position: map.getCenter(),
        map: map,
        draggable: true,
        animation: google.maps.Animation.DROP,
        title: 'Drag n Drop to get the Location'
    })

    google.maps.event.addListener(marker, 'mousedown', moveMarker);
    google.maps.event.addListener(marker, 'mouseup', pointMarker);
}

var moveMarker = function () {
    if (marker.getAnimation() != null) {
        marker.setAnimation(null);
    } else {
        marker.setAnimation(google.maps.Animation.BOUNCE);
    }
}

var pointMarker = function () {
    var pos = new google.maps.LatLng();
    pos = marker.getPosition();

    $(".frmEditor[rel=location] .txtLat").val(pos.lat());
    $(".frmEditor[rel=location] .txtLng").val(pos.lng());
}
//*/