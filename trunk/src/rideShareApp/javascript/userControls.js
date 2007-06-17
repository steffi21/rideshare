// userFunctions

YAHOO.rideShare.user=function(){
    var userid;
    saveUser:function(){
        if (validateForm){
            xmlData = buildXML()
            var sURL = "http://rideShare.geeksbox.co.uk/datafeed.ashx/save/user";
            var request = YAHOO.util.Connect.asyncRequest('POST', sUrl, callback, xmlData); 

        }
    },
    saveUserEvent:function(){
    
    },
    
    var buildXML = function(){
    	
    },
    
    var validateForm = function(){
        var valid = false;
        
        valid = true;
        return valid;
    }
    
    var callback =
    {
      success:handleSuccess,
      failure:handleFailure
    };
    
    var handleSuccess = function(o){
        userid = o.responseText;
    }
    
    var handleFailure = function(o){
        alert("An Error has occured:" + o.responseText);
    }
    

};

YAHOO.util.event.addListener("submitUser", "click", YAHOO.rideShare.user.saveUser)
YAHOO.util.event.PreventDefault("submit");