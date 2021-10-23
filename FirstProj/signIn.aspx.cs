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
    public partial class WebForm7 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from user_table where user_name='"+TextBoxUName.Text.Trim()+"' AND password='"+ TextBoxPass.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();

                
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        invalid_cred.Visible = false;
                        //Response.Write("<script>alert('Login Successful');</script>");
                        //session variables
                        Session["username"] = dr.GetValue(2).ToString();
                        Session["fullname"] = dr.GetValue(1).ToString();
                        Session["usertype"] = dr.GetValue(5).ToString();
                        Session["user_id"] = dr.GetValue(0).ToString();
                        Session["role"] = "user";
                    }
                    Response.Redirect("index.aspx");
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
            //Response.Write("<script>alert('Button click');</script>");
        }

        //user defined functions

    }
}