//Example Code

YAHOO.namespace('rideShare');

YAHOO.rideShare.map = {

    init:function(){
    // Create a lat/lon object
    var myPoint = "UK";
    // Create a map object
    var map = new YMap(document.getElementById('mapContainer'));
    // Display the map centered on a latitude and longitude
    map.drawZoomAndCenter(myPoint, 14); //default to UK View

    // Add map type control
    map.addTypeControl();
    
     // Add a pan control
    map.addPanControl();

    // Add a slider zoom control
    map.addZoomLong();
    
    map.geoCodeAddress("l9 8df, england")

    // Set map type to either of: YAHOO_MAP_SAT YAHOO_MAP_HYB YAHOO_MAP_REG
    map.setMapType(YAHOO_MAP_SAT);

    //Get valid map types, returns array [YAHOO_MAP_REG, YAHOO_MAP_SAT, YAHOO_MAP_HYB]
    var myMapTypes = map.getMapTypes();
    }
};

YAHOO.util.Event.onContentReady('mapContainer', YAHOO.rideShare.map.init);
