function showLatLong(lat, longi) {
    $("#direccion").html("La Flor de México, Zacatecas");
}

function dibujaMapa(lat, longi) {
    var myLatLng = new google.maps.LatLng(lat, longi);

    var mapOptions = {
        zoom: 16,
        center: myLatLng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    var map = new google.maps.Map(
        document.getElementById('mapa'),
        mapOptions
    );

    var marker = new google.maps.Marker({
        position: myLatLng,
        map: map,
        title: "La Flor de México"
    });

    $("#mapa").css("height", "350px");
}
