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


    public partial class userInterface : System.Web.UI.UserControl
    {
        private int iStep;

        public int uiStep
        {
            get { return iStep; }
            set { iStep = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            loadUI();
        }

        protected void loadEvent(object sender, EventArgs e)
        {
            loadEventDetails();
            //loadUI();
        }

        private void loadUI()
        {

            switch (this.uiStep)
            {
                case 1:
                    placeholderStep1.Visible = true;
                    break;
                case 2:
                    placeholderStep2.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void loadEventDetails()
        {
            //get our data from a seperate class tjem assign to our literal control
            eventDetails.Text = "Woo Hoo";
            
        }

    }
}