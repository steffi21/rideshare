//Example Code

YAHOO.namespace('rideShare');

YAHOO.rideShare.map = {

    init:function(){
    // Create a lat/lon object
    var myPoint = "UK";
    // Create a map object
    map = new YMap(document.getElementById('mapContainer'));
    // Display the map centered on a latitude and longitude
    map.drawZoomAndCenter(myPoint, 13); //default to UK View

    // Add map type control
    map.addTypeControl();
    
     // Add a pan control
    map.addPanControl();

    // Add a slider zoom control
    map.addZoomLong();
    
    map.geoCodeAddress("l9 8df, england")

    // Set map type to either of: YAHOO_MAP_SAT YAHOO_MAP_HYB YAHOO_MAP_REG
    map.setMapType(YAHOO_MAP_REG);

    //Get valid map types, returns array [YAHOO_MAP_REG, YAHOO_MAP_SAT, YAHOO_MAP_HYB]
    var myMapTypes = map.getMapTypes();
    },
    
    updateMap:function(e){
      var myNewPoint = this.value;
      map.drawZoomAndCenter(myNewPoint, 4); //default to UK View
      var myLatLan = document.getElementById("hiddenLatLan");
      myGeoPoint = map.getCenterLatLon();
      myLatLan.value = myGeoPoint.Lat + ',' + myGeoPoint.Lon;
      myMarker = new YMarker(myGeoPoint, "homeMarker");
      myMarker.addAutoExpand = "Location: "+ document.getElementById("txtPostCode").value;
      
      map.addMarker(myNewPoint);
    },
    
    loadAttendees:function(){
        var eventid = document.getElementById('selectEvent');
        map.YGeoRSS('http://rideShare.geeksbox.co.uk/datafeed.ashx/xml/mapdata/'+ eventid);
    }
};

YAHOO.util.Event.onContentReady('mapContainer', YAHOO.rideShare.map.init);
YAHOO.util.Event.addListener('txtPostCode', 'change', YAHOO.rideShare.map.updateMap);
YAHOO.util.Event.addListener('hiddenEventPostCode', 'change', YAHOO.rideShare.map.updateMap);
//YAHOO.util.Event.addListener('hiddenEventPostCode', 'change', YAHOO.rideShare.map.loadAttendees);
