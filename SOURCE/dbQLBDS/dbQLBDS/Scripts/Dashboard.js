///<reference path="jquery-1.10.2.js" />

$("document").ready(function () {
    loadmap();

    $("#MaThanhPho").change(function () {
        var thanhphoid = $(this).val();
        console.log(thanhphoid);
        $.post("/Quan/ListQuan", { "mathanhpho": thanhphoid }, function (data) {
            console.log(data);
            $("#MaQuan").children("option").remove();
            $("#MaQuan").append("<option value=''></option>");

            var str = "";
            $.each(data, function (idx, value) {
                str += "<option value='" + value.MaQuan + "'>" + value.TenQuan + "</option>";
            });
            
            $("#MaQuan").append(str);
        });

    });

    $("#MaQuan").change(function () {
        var quanid = $(this).val();
        console.log(quanid);
        $.post("/Duong/ListDuong", { "maquan": quanid }, function (data) {
            console.log(data);
            $("#MaDuong").children("option").remove();
            $("#MaDuong").append("<option value=''></option>");

            var str = "";
            $.each(data, function (idx, value) {
                str += "<option value='" + value.MaDuong + "'>" + value.TenDuong + "</option>";
            });

            $("#MaDuong").append(str);
        });
    });

});

//*/
var marker;
var mapOptions;

var loadmap = function () {
    var toado = $("#ToaDo").val();
    var lat = "10.779565";
    var lng = "106.699375";
    if (toado != "") {
        var arr = toado.split(',');
        lat = arr[0];
        lng = arr[1];
    }
    

    if (lat != "" && lng != "") {
        initialize(lat, lng);
    }
}

var initialize = function (lat, lng) {
    mapOptions = {
        zoom: 18,
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

    var strToaDo = pos.lat() + "," + pos.lng();
    $("#ToaDo").val(strToaDo);
    //$(".frmEditor[rel=location] .txtLat").val(pos.lat());
    //$(".frmEditor[rel=location] .txtLng").val(pos.lng());
}
//*/