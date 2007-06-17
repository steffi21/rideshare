using System;
using System.Collections.Generic;
using System.Text;

namespace rideShareBackEnd
{
    public class UserEventDetails : BaseObject
    {
        private int _userEventDataKey;


        public int UserEventDataKey
        {
            get { return _userEventDataKey; }
            set { _userEventDataKey = value; }
        }

        private string _eventId;

        public string EventId
        {
            get { return _eventId; }
            set { _eventId = value; }
        }
        private string _destinationName;

        public string DestinationName
        {
            get { return _destinationName; }
            set { _destinationName = value; }
        }
        private decimal _long;

        public decimal _long1
        {
            get { return _long; }
            set { _long = value; }
        }
        private decimal _lat;

        public decimal Lat
        {
            get { return _lat; }
            set { _lat = value; }
        }




        internal void filldata(System.Data.DataRow dre)
        {
            this.UserEventDataKey = (int)dre["UserEventData_key"];
            this.Lat = (decimal)dre["lat"];
            this._long1 = (decimal)dre["long"];
            this.EventId = (string)dre["eventid"];
            this.DestinationName = (string)dre["destinationName"];
            
        }
        private static string GetVal(System.Xml.XmlDocument xd, string field)
        {
            return xd.SelectSingleNode("//" + field).InnerXml;
        }


        public static int Save(System.Xml.XmlDocument xd)
        {
            System.Data.SqlClient.SqlConnection conn = ObtainDatabaseConnection();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = "usp_saveUserEventDetails";
            cmd.Parameters.AddWithValue("userEventdetails_key", int.Parse(GetVal(xd, "UserEventData")));
            cmd.Parameters.AddWithValue("EventID", GetVal(xd, "EventId"));
            cmd.Parameters.AddWithValue("destinationName", GetVal(xd, "DestinationName"));
            cmd.Parameters.AddWithValue("Long", decimal.Parse(GetVal(xd, "Long")));
            cmd.Parameters.AddWithValue("Lat", decimal.Parse(GetVal(xd, "Lat")));
            cmd.Parameters.AddWithValue("UserDetails_key", int.Parse(GetVal(xd, "UserKey")));
    
            object o = cmd.ExecuteScalar();
            int retVal = int.Parse(o.ToString());
            return retVal;
        }
    }
}
