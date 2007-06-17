using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace rideShareApp
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class DataFeed : IHttpHandler
    {
        private class PathVars
        {
            private string[] pathvar;


            public PathVars(string[] var)
            {
                pathvar = var;
            }
            private const int DATATYPE = 1;
            public string dataType
            {
                get
                {
                    return pathvar[DATATYPE].ToLower();
                }
            }
            private const int OBJECTTYPE = 2;
            public string objectType
            {
                get
                {
                    return pathvar[OBJECTTYPE].ToLower();
                }
            }

            public decimal GetDecimal(int index)
            {
                decimal retVal;
                decimal.TryParse(pathvar[index], out retVal);
                return retVal;

            }

            public string GetString(int index)
            {
                return pathvar[index].Replace("~","");
            }

            public int GetInt(int index)
            {
                int retVal;
                int.TryParse(pathvar[index], out retVal);
                return retVal;
            }





        }

        public void ProcessRequest(HttpContext context)
        {
           PathVars path = new PathVars(context.Request.PathInfo.Split('/'));

           if (path.dataType.ToLower() == "save")
           {
               System.IO.StreamReader sr = new System.IO.StreamReader(context.Request.InputStream);
               string xmlPost = sr.ReadToEnd();

               System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
               xd.LoadXml(xmlPost);
               int key;
               switch (path.objectType)
               {
                   case "user":
                       
                       key = rideShareBackEnd.UserDetails.Save(xd);
                       XmlSend(context, key);

                       break;

                   case "userevent":
                       key = rideShareBackEnd.UserEventDetails.Save(xd);

                       break;
               }

           }
           else
           {



               object retVal = "badData";

               switch (path.objectType)
               {
                   case "user":
                       //process users
                       rideShareBackEnd.GeoBox b = new rideShareBackEnd.GeoBox();
                       string boxdata = path.GetString(5);
                       b.fillFromString(boxdata);


                       IList<rideShareBackEnd.UserDetails> users = rideShareBackEnd.UserDetails.GetUsers(path.GetInt(3), path.GetString(4), b);
                       retVal = users;

                       break;
                   case "date":
                   default:
                       retVal = DateTime.Now;
                       break;

               }

               switch (path.dataType)
               {
                   case "json":
                       //do json presentation
                       context.Response.ContentType = "text/plain";
                       context.Response.Write(rideShareBackEnd.JsonSerialise.Serialise(retVal));
                       break;
                   case "xml":
                   default:
                       //Do XML Presentation
                       XmlSend(context, retVal);




                       break;
               }

           }





        }

        private static void XmlSend(HttpContext context, object retVal)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter sw = new System.IO.StringWriter(sb);
            System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(retVal.GetType());
            xs.Serialize(sw, retVal);
            context.Response.ContentType = "text/xml";
            context.Response.Write(sb.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
