using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace FirstProj
{

    public partial class WebForm1 : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        List<int> ids = new List<int>();
        public static int rec_id;
        public static string rec_title;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public int getRecID()
        {
            return rec_id;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection sqlcon = new SqlConnection(strcon);
                sqlcon.Open();
                SqlCommand sqlconn = new SqlCommand();
                string sqlquery = "select * from  [dbo].[recipe_table_temp] where recipe_title like'%'+@Recipe_Title+'%'";
                sqlconn.CommandText = sqlquery;
                sqlconn.Connection = sqlcon;

                sqlconn.Parameters.AddWithValue("Recipe_Title", Txtsearch.Text);

                SqlDataReader dr = sqlconn.ExecuteReader();
                if (dr.HasRows)
                {
                    search_res.Visible = true;
                    no_res.Visible = false;
                    while (dr.Read())
                    {
                        int id = Convert.ToInt32(dr.GetValue(0).ToString());
                        ids.Add(id);
                    }
                }

                else
                {
                    search_res.Visible = false;
                    no_res.Visible = true;
                }

                sqlcon.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);

            }

        }

        protected void breakfastClick(object sender, EventArgs e)
        {
            Session["category"] = "breakfast";
            Response.Redirect("category.aspx");
        }

        protected void nonfastClick(object sender, EventArgs e)
        {
            Session["category"] = "non-fasting";
            Response.Redirect("category.aspx");
        }

        protected void fastClick(object sender, EventArgs e)
        {
            Session["category"] = "fast food";
            Response.Redirect("category.aspx");
        }

        protected void fastingClick(object sender, EventArgs e)
        {
            Session["category"] = "fasting";
            Response.Redirect("category.aspx");
        }

        protected void mainClick(object sender, EventArgs e)
        {
            Session["category"] = "main";
            Response.Redirect("category.aspx");
        }

        protected void alcClick(object sender, EventArgs e)
        {
            Session["category"] = "alcoholic";
            Response.Redirect("categoryDrinks.aspx");
        }

        protected void nonClick(object sender, EventArgs e)
        {
            Session["category"] = "non-alcoholic";
            Response.Redirect("categoryDrinks.aspx");
        }


        public string search_result()
        {
            string htmlStr = "";


            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //Session["id"] = 1;

                foreach (int i in ids)
                {

                    SqlCommand cmd2 = new SqlCommand("SELECT * from recipe_table_temp where recipe_ID ='" + i + "'", con);

                    SqlDataReader dr2 = cmd2.ExecuteReader();


                    if (dr2.HasRows)
                    {
                        while (dr2.Read())
                        {
                            string title = dr2.GetValue(1).ToString();
                            string img_link = dr2.GetValue(5).ToString();
                            string link = img_link.Substring(1);

                            //Response.Write(source);
                            htmlStr += $"<div class = 'col-4'>" +
                                $"<div class='card new' style='width: 18rem'>" +
                                $"<img class='card-img-top' src='{link}' style='height: 150px;' alt='...'>" +
                                $"<button style='width: 100%; background-color:grey; color:white;' id='btn-get' class='title-link btn ml-0 pl-0' href='' onclick='fun({i.ToString()})'>{title}</button>" +
                                $"</div>" +
                                $"</div>";
                        }
                    }
                }

            con.Close(); 

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }
            

            return htmlStr;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('"+ System.Web.HttpContext.Current.Session["id"].ToString() + "');</script>");
        }
    }
}