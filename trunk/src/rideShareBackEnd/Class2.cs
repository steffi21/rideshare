using System;
using System.Collections.Generic;
using System.Text;

namespace rideShareBackEnd
{
    public abstract class BaseObject
    {

        public static System.Data.SqlClient.SqlConnection ObtainDatabaseConnection()
        {
            return new System.Data.SqlClient.SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=rideshare;User Id=rideShare;Password=rideShare;");
        }   
    }
}
