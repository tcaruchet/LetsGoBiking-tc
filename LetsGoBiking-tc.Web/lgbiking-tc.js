var vector;
var map = new ol.Map({
    target: 'map', // <-- This is the id of the div in which the map will be built.
    layers: [
        new ol.layer.Tile({
            source: new ol.source.OSM()
        })
    ],

    view: new ol.View({
        center: ol.proj.fromLonLat([7.187043, 43.792614]), // <-- Those are the GPS coordinates to center the map to.
        zoom: 10 // You can adjust the default zoom.
    })
});

function CenterMap(long, lat) {
    console.log("Long: " + long + " Lat: " + lat);
    map.getView().setCenter(ol.proj.transform([long, lat], 'EPSG:4326', 'EPSG:3857'));
    map.getView().setZoom(15);
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

$(document).ready(function () {
     $('#submit').click(function (event) {
           $(this).attr('disabled', 'disabled');
           $(this).html('Chargement...');
           PathComputing(event);
     });
   });


function PathComputing(e) {
    e.preventDefault()
    var lat, lng;

    var addrFrom = document.querySelector("#locationOrigin").value.replaceAll(" ", "+")
    if (addrFrom === "") {
        alert("Please enter a Departure Address");
        $("#submit").attr('disabled', false);
        $("#submit").html('Je pars !');
        return;
    }

    var addrTo = document.querySelector("#locationDest").value.replaceAll(" ", "+")
    if (addrTo === "") {
        alert("Please enter a Destination Address");
        $("#submit").attr('disabled', false);
        $("#submit").html('Je pars !');
        return;
    }
    $.ajax({
        url: "http://localhost:8733/Design_Time_Addresses/LetsGoBiking_tc.RoutingWCF/BikeRoutingService/rest/Position/" + addrFrom,
        type: "GET",
        success: function (data) {
            if((data === undefined || data === null || data === "")) {
                alert("Adresse de départ non trouvée")
                $("#submit").attr('disabled', false);
                $("#submit").html('Je pars !');
                return;
            }
            else{
                lng = data["longitude"]
                lat = data["latitude"]
                $.ajax({
                    url: "http://localhost:8733/Design_Time_Addresses/LetsGoBiking_tc.RoutingWCF/BikeRoutingService/rest/Position/" + addrTo,
                    type: "GET",
                    success: function (data) {
                        if(data === undefined || data === null || data === "") {
                            alert("Adresse d'arrivée non trouvée")
                            $("#submit").attr('disabled', false);
                            $("#submit").html('Je pars !');
                            return;
                        }
                        else{
                            lngTo = data["longitude"]
                            latTo = data["latitude"]
                            computeRoute([lat, lng], [latTo, lngTo])
                        }
                    },
                    error: function (data) {
                        alert("Erreur lors de la requête pour chercher l'adresse d'arrivée.")
                        $("#submit").attr('disabled', false);
                        $("#submit").html('Je pars !');
                    }
                });
            }
            
        },
        error: function (data) {
            alert("Erreur lors de la requête pour chercher l'adresse de départ.")
            $("#submit").attr('disabled', false);
            $("#submit").html('Je pars !');
        }
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

function addMarkers(currentPositionMap, distance){
    //clearAllLayers()
    //call ajax ttp://localhost:5157/api/LGBiking/Stations/Around/addrFrom/addrTo
    if(distance < 100)
        distance = 500
    $.ajax({
        url: "http://localhost:8733/Design_Time_Addresses/LetsGoBiking_tc.RoutingWCF/BikeRoutingService/rest/Stations/Around/" + currentPositionMap[1] + "/" + currentPositionMap[0] + "/" + distance,
        type: "GET",
        success: function (data) {
            if(data === undefined || data === []) {
                alert("Aucune station trouvée ici :(")
            }
            else{
                var features = []
                for(var i = 0; i < data.length; i++){
                    var point = data[i];
                    console.log(point)
                    var longitude = point.position.longitude;                         //coordinates
                    var latitude = point.position.latitude;
                    /*....
                    * now get your specific icon...('..../ic_customMarker.png')
                    * by e.g. switch case...
                    */

                    //create Feature... with coordinates
                    var iconFeature = new ol.Feature({
                        geometry: new ol.geom.Point(ol.proj.transform([longitude, latitude], 'EPSG:4326',     
                        'EPSG:3857'))
                    });

                    //create style for your feature...
                    var iconStyle = new ol.style.Style({
                        image: new ol.style.Icon(/** @type {olx.style.IconOptions} */ ({
                        anchor: [0.5, 46],
                        anchorXUnits: 'fraction',
                        anchorYUnits: 'pixels',
                        opacity: 0.75,
                        src: "marker.png"
                        }))
                    });

                    iconFeature.setStyle(iconStyle);
                    features.push(iconFeature);
                }
                /*
                * create vector source
                * you could set the style for all features in your vectoreSource as well
                */
                var vectorSource = new ol.source.Vector({
                    features: features      //add an array of features
                    //,style: iconStyle     //to set the style for all your features...
                });

                var vectorLayer = new ol.layer.Vector({
                    source: vectorSource
                });
                map.addLayer(vectorLayer);
                console.log("markers added")
                
            }
        },
        error: function (data) {
            alert("Erreur lors de la requête pour chercher les stations.")
        },
        complete: function () {
            $("#submit").attr('disabled', false);
            $("#submit").html('Je pars !');
        }   
    });

}

function computeRoute(addrFrom, addrTo) {
    toggleClass();
    var button = document.querySelector('.button')
    button.addEventListener('transitionend', toggleClass);
    button.addEventListener('transitionend', removeClass);

    //call http://localhost:5157/api/LGBiking/Route/Path with ajax
    $.ajax({
        url: "http://localhost:8733/Design_Time_Addresses/LetsGoBiking_tc.RoutingWCF/BikeRoutingService/rest/Route/Path",
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

            var totalDistance = 0
            
            if(data["type"] === "foot-walking" || data["type"] === "FeatureCollection"){
                //draw only foot walking
                drawLine(data["features"][0]["geometry"]["coordinates"], '#7700B3')
                totalDistance = data["features"][0]["properties"]["summary"]["distance"]
            }
            else if (data["type"] === "walking-cycling"){
                //draw only walking-cycling
                // features[0] go from addrFrom to station start walking
                drawLine(data["features"][0]["geometry"]["coordinates"], '#7700B3')
                // features[1] go from station start to station end cycling
                drawLine(data["features"][1]["geometry"]["coordinates"], '#00B3E6')
                // features[2] go from station end to addrTo walking
                drawLine(data["features"][2]["geometry"]["coordinates"], '#7700B3')
                totalDistance = data["features"][0]["properties"]["summary"]["distance"] + data["features"][1]["properties"]["summary"]["distance"] + data["features"][2]["properties"]["summary"]["distance"]
                addMarkers(data["features"][1]["geometry"]["coordinates"][0], totalDistance)
                addMarkers(data["features"][2]["geometry"]["coordinates"][0], totalDistance)
            }
            else{
                //draw only cycling
                drawLine(data["features"][0]["geometry"]["coordinates"], '#00B3E6')
                totalDistance = data["features"][0]["properties"]["summary"]["distance"]
                addMarkers(data["features"][0]["geometry"]["coordinates"][0], totalDistance)
            }
            $("#distance").html(totalDistance/1000 + " km")
        },
        error: function (err) {
            alert("Erreur lors de la requête pour calculer l'itinéraire.")
        },
        complete: function () {
            $("#submit").attr('disabled', false);
            $("#submit").html('Je pars !');
        } 
    });


}