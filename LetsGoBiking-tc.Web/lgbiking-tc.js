var vector;
var map = new ol.Map({
    target: 'map', // <-- This is the id of the div in which the map will be built.
    layers: [
        new ol.layer.Tile({
            source: new ol.source.OSM()
        })
    ],

    view: new ol.View({
        center: ol.proj.fromLonLat([22.2, 2.0]), // <-- Those are the GPS coordinates to center the map to.
        zoom: 10 // You can adjust the default zoom.
    })
});

function CenterMap(long, lat) {
    console.log("Long: " + long + " Lat: " + lat);
    map.getView().setCenter(ol.proj.transform([long, lat], 'EPSG:4326', 'EPSG:3857'));
    map.getView().setZoom(12);
}

function drawLine(arr, couleur) {

    CenterMap(arr[0][0], arr[0][1])

    // Create an array containing the GPS positions you want to draw
    var coords = arr
    var lineString = new ol.geom.LineString(coords);

    // Transform to EPSG:3857
    lineString.transform('EPSG:4326', 'EPSG:3857');

    // Create the feature
    var feature = new ol.Feature({
        geometry: lineString,
        name: 'Line'
    });



    // Configure the style of the line
    var lineStyle = new ol.style.Style({
        stroke: new ol.style.Stroke({
            color: couleur,
            width: 10
        })
    });

    var source = new ol.source.Vector({
        features: [feature]
    });

    vector = new ol.layer.Vector({
        source: source,
        style: [lineStyle]
    });


    vector.set('name', 'my_layer_name');
    /*    var vectorLayer = new ol.layer.Vector({
            source: new ol.source.Vector({
                features: [new ol.Feature({
                    geometry: new ol.geom.Point(ol.proj.transform(arr[arr.length-1], 'EPSG:4326', 'EPSG:3857')),
                })]
            }),
            style: new ol.style.Style({
                image: new ol.style.Icon({
                    anchor: [0.5, 0.5],
                    anchorXUnits: "fraction",   
                    anchorYUnits: "fraction",
                    src: "https://img.icons8.com/officexs/16/000000/filled-flag.png"
                })
            })
        });*/

    //    vectorLayer.set('name', "drapeauTo")
    map.addLayer(vector);
    //    map.addLayer(vectorLayer);
}

function PathComputing(e) {
    e.preventDefault()

    var lat, lng;

    var addrFrom = document.querySelector("#locationOrigin").value.replaceAll(" ", "+")
    var addrTo = document.querySelector("#locationDest").value.replaceAll(" ", "+")

    const settings = {
        "async": true,
        "crossDomain": true,
        "url": "https://api-adresse.data.gouv.fr/search/?q=" + addrFrom,
        "method": "GET"
    };

    $.ajax(settings).done(function (response) {
        lng = response["features"][0]["geometry"].coordinates[0]
        lat = response["features"][0]["geometry"].coordinates[1]
        const settings = {
            "async": true,
            "crossDomain": true,
            "url": "https://api-adresse.data.gouv.fr/search/?q=" + addrTo,
            "method": "GET"
        };

        $.ajax(settings).done(function (response) {
            lngTo = response["features"][0]["geometry"].coordinates[0]
            latTo = response["features"][0]["geometry"].coordinates[1]
            computeRoute([lat, lng], [latTo, lngTo])
        });
    });
}

function toggleClass() {
    document.querySelector('.button').classList.toggle('active');
}

function removeClass() {
    document.querySelector('.button').classList.remove('finished');
}

function clearAllLayers() {
    map.getLayers().forEach(function (el) {
        if (el.get('name') === 'my_layer_name') {
            el.getSource().clear()
        }
    })
}

function computeRoute(addrFrom, addrTo) {
    toggleClass();
    var button = document.querySelector('.button')
    button.addEventListener('transitionend', toggleClass);
    button.addEventListener('transitionend', removeClass);

    //call http://localhost:5157/api/LGBiking/Route/Path with ajax
    $.ajax({
        url: "http://localhost:5157/api/LGBiking/Route/Path",
        type: "POST",
        data: JSON.stringify([
            {
                "latitude": addrFrom[0],
                "longitude": addrFrom[1]
            },
            {
                "latitude": addrTo[0],
                "longitude": addrTo[1]
            }
        ]),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data)
            clearAllLayers()
            // pour draw la line, on va recup le res de l'appel vers l'API en prenant geometry -> coordinates et chaque pts representeront la line a tracer
            // var res = JSON.parse(data)

            //En velo
            drawLine(data["features"][0]["geometry"]["coordinates"], '#7700B3')
        },
        error: function (err) {
            console.log(err)
        }
    });


}