using System;
using System.Collections.Generic;
using System.Text;

namespace rideShareBackEnd
{
    public class GeoBox
    {
        public System.Data.SqlClient.SqlParameter[] Parameters()
        {
            System.Data.SqlClient.SqlParameter[] retVal = new System.Data.SqlClient.SqlParameter[4];

            if (MaxLong != 0.0m)
            {
                retVal[0] = new System.Data.SqlClient.SqlParameter("maxlong", MaxLong);
                retVal[1] = new System.Data.SqlClient.SqlParameter("minLong", MinLong);
                retVal[2] = new System.Data.SqlClient.SqlParameter("maxlat", MaxLat);
                retVal[3] = new System.Data.SqlClient.SqlParameter("minlat", MinLat);

            }
            else
            {
                retVal = GeoBox.NullParameters();
            }
            return retVal;

        }

        public static System.Data.SqlClient.SqlParameter[] NullParameters()
        {
                System.Data.SqlClient.SqlParameter[] retVal = new System.Data.SqlClient.SqlParameter[4];

                retVal[0] = new System.Data.SqlClient.SqlParameter("maxlong", null);
                retVal[1] = new System.Data.SqlClient.SqlParameter("minLong", null);
                retVal[2] = new System.Data.SqlClient.SqlParameter("maxlat", null);
                retVal[3] = new System.Data.SqlClient.SqlParameter("minlat", null);
            return retVal;

        }

        public decimal MaxLong;
        public decimal MinLong;
        public decimal MaxLat;
        public decimal MinLat;

        public void fillFromString(string str)
        {
            string[] vals = str.Split('|');
            MinLong = decimal.Parse(vals[0]);
            MinLat = decimal.Parse(vals[1]);
            MaxLong = decimal.Parse(vals[2]);
            MaxLat = decimal.Parse(vals[3]);

        }


    }

    
}
