using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstProj
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginAdmin_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from admin_table where username='" + TextBoxUName.Text.Trim() + "' AND password='" + TextBoxPass.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        //Response.Write("<script>alert('" + dr.GetValue(2).ToString() + "');</script>");
                        //session variables
                        Session["username"] = dr.GetValue(1).ToString();
                        Session["role"] = "admin";
                    }
                    //for now - homepage has to change to admin dashboard
                    Response.Redirect("admin_dashboard.aspx");
                }
                else
                {
                    invalid_cred.Visible = true;
                    //Response.Write("Invalid credentials");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }
        }
    }
}