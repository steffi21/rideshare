using System;
using System.Collections.Generic;
using System.Text;

namespace rideShareBackEnd
{
    public class UserDetails : BaseObject
    {
        private int _userDetailsKey;

        public int UserDetailsKey
        {
            get { return _userDetailsKey; }
            set { _userDetailsKey = value; }
        }
        private string _yahooUsername;

        public string YahooUsername
        {
            get { return _yahooUsername; }
            set { _yahooUsername = value; }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private List<UserEventDetails> _fulfilledEvents = new List<UserEventDetails>();

        [System.Xml.Serialization.XmlArrayItem("Event", typeof(UserEventDetails))]
        public List<UserEventDetails> FulfilledEvents
        {
            get
            {
                return _fulfilledEvents;
            }
            set
            {
                _fulfilledEvents = value;
            }
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
            cmd.CommandText = "usp_saveUserDetails";
            cmd.Parameters.AddWithValue("userdetails_key", int.Parse(GetVal(xd, "UserDetailsKey")));
            cmd.Parameters.AddWithValue("yahoousername", GetVal(xd,"YahooUsername"));
            cmd.Parameters.AddWithValue("email", GetVal(xd, "Email"));
            cmd.Parameters.AddWithValue("password", GetVal(xd, "Password"));
            object o = cmd.ExecuteScalar();
            int retVal = int.Parse(o.ToString());
            return retVal;


            

        }

        public static IList<UserDetails> GetUsers(int key, string eventID, GeoBox box)
        {
            IList<UserDetails> retVal;
            System.Data.SqlClient.SqlConnection conn = ObtainDatabaseConnection();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = conn;
            cmd.CommandText = "usp_getUserDetails";
            object oKey;
            if (key == 0)
            {
                oKey = null;
            }
            else
            {
                oKey = key;
            }
            
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("UserKey", oKey));
            if (eventID == "")
            {
                eventID = null;
            }
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("eventId", eventID));


            if (box == null)
            {
                cmd.Parameters.AddRange(GeoBox.NullParameters());
            }
            else
            {
                cmd.Parameters.AddRange(box.Parameters());
            }

            conn.Open();
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds);

            retVal = buildUsers(ds);

            return retVal; ;
            

        }

        private static IList<UserDetails> buildUsers(System.Data.DataSet ds)
        {
            IList<UserDetails> retVal = new List<UserDetails>();

            foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
            {
                UserDetails u = new UserDetails();
                u.fillData(dr);
                retVal.Add(u);
                foreach (System.Data.DataRow dre in ds.Tables[1].Rows)
                {
                    if ((int)dre["userDetails_fkey"] == u.UserDetailsKey)
                    {
                        UserEventDetails ed = new UserEventDetails();
                        ed.filldata(dre);
                        u.FulfilledEvents.Add(ed);
                    }
                }
            }
            return retVal;
        }

        private void fillData(System.Data.DataRow dr)
        {
            this.UserDetailsKey = (int)dr["userDetails_key"];
            this.YahooUsername = (string)dr["yahoouser"];
            this.Email = (string)dr["email"];
            this.Password = (string)dr["password"];


        }



    }
}
