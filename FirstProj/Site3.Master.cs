using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstProj
{
    public partial class Site3 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            //logout - forget session variables

            Session["username"] = "";
            Session["role"] = "";
            Response.Redirect("adminLogin.aspx");
        }
    }
}