using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace rideShareApp
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String applicationIDYahooMaps = System.Configuration.ConfigurationManager.AppSettings["applicationIDYAHOOMaps"].ToString();
            LiteralControl element = new LiteralControl();
            element.Text = "<script type=\"text/javascript\" src=\"http://api.maps.yahoo.com/ajaxymap?v=3.0&amp;appid=" + applicationIDYahooMaps +  "\"></script>";
            Page.Header.Controls.Add(element);
            LiteralControl element2 = new LiteralControl();
            element2.Text = "<script type=\"text/javascript\" src=\"/javascript/map.js\"> </script>";
            Page.Header.Controls.Add(element2);
            
            
        }
    }
}