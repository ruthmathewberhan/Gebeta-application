using System;
using System.Collections;
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
    public partial class WebForm15 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        List<int> IDs = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["category"] != "alcoholic" || Session["category"] != "non-alcoholic" )|| Session["category"].ToString() == "alcoholic")
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("SELECT * from recipe_detail_table where course_meal='" + "alcoholic" + "'", con);

                    SqlDataReader dr = cmd.ExecuteReader();



                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            string id_str = dr.GetValue(1).ToString();
                            int id = Convert.ToInt32(id_str);
                            IDs.Add(id);

                        }
                    }

                    else
                    {
                        no_match_cat.Visible = true;
                        //Response.Write("<script>alert('no search row');</script>");
                    }

                    dr.Close();
                    con.Close();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + " ');</script>");
                }
            }

            if (Session["category"] != null && Session["category"].ToString() == "non-alcoholic")
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("SELECT * from recipe_detail_table where course_meal='" + "non-alcoholic" + "'", con);

                    SqlDataReader dr = cmd.ExecuteReader();



                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            string id_str = dr.GetValue(1).ToString();
                            int id = Convert.ToInt32(id_str);
                            IDs.Add(id);

                        }
                    }

                    else
                    {
                        no_match_cat.Visible = true;
                        //Response.Write("<script>alert('no search row');</script>");
                    }

                    dr.Close();
                    con.Close();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + " ');</script>");
                }
            }
        }

        protected void non_alcholic_drink_button_Click(object sender, EventArgs e)
        {
            Session["category"] = "non-alcoholic";
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void alcholic_drink_button_Click(object sender, EventArgs e)
        {
            Session["category"] = "alcoholic";
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        public string getWhileLoopData()
        {
            string htmlStr = "";

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                foreach (int i in IDs)
                {
                    SqlCommand cmd2 = new SqlCommand("SELECT * from Recipe_table where Recipe_ID ='" + i + "'", con);

                    SqlDataReader dr2 = cmd2.ExecuteReader();


                    if (dr2.HasRows)
                    {
                        while (dr2.Read())
                        {
                            string title = dr2.GetValue(1).ToString();
                            string img_link = dr2.GetValue(5).ToString();
                            string link = img_link.Substring(1);
                            string desc = dr2.GetValue(2).ToString();

                            //Response.Write(source);
                            htmlStr +=
                                $"<div style='width: 30%;' class='bb col-xs-12 col-md-9 mb-5 pb-5'>" +
                                $"<div class='card new' style='width: 650px'>" +
                                $"<img src = '{link}' class='card-img-top' alt='...'>" +
                                $"<div class='card-body'>" +
                                $"<h5 class='card-title'>{title}</h5>" +
                                $"<p class='card-text'>{desc}</p>" +
                                $"<button class='btn btn-primary' id='btn' onclick='fun({i})'>Get This Recipe</button>" +
                                $"</div>" +
                                $"</div>" +
                                $"</div>";

                        }
                        no_match_cat.Visible = false;
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
    }
}