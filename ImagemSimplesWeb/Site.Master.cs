using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ImagemSimplesWeb
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //[WebMethod(EnableSession = true)]
        //public static void ClearYourSessionValue()
        //{
        //    //// This will leave the key in the Session cache, but clear the value
        //    //Session["YourKey"] = null;

        //    //// This will remove both the key and value from the Session cache
        //    //Session.Remove("YourKey");
        //    HttpContext.Current.Session.Abandon();
        //}

    }
}