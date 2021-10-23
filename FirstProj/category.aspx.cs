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
    public partial class WebForm6 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        List<int> IDs = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["category"] == null || Session["category"].ToString() == "breakfast")
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("SELECT * from recipe_detail_temp where course_meal='" + "breakfast" + "'", con);

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

            if (Session["category"] != null && Session["category"].ToString() == "non-fasting")
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("SELECT * from recipe_detail_temp where season='" + "non-fasting" + "'", con);

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

            if (Session["category"] != null && Session["category"].ToString() == "fasting")
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("SELECT * from recipe_detail_temp where season='" + "fasting" + "'", con);

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

            if (Session["category"] != null && Session["category"].ToString() == "fast food")
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("SELECT * from recipe_detail_temp where course_meal='" + "fast food" + "'", con);

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

            if (Session["category"] != null && Session["category"].ToString() == "main")
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("SELECT * from recipe_detail_temp where course_meal='" + "breakfast" + "'", con);

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

        protected void breakfast_button_Click(object sender, EventArgs e)
        {
            Session["category"] = "breakfast";
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void fast_food_button_Click(object sender, EventArgs e)
        {
            Session["category"] = "fast food";
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        

        protected void misa_button_Click(object sender, EventArgs e)
        {
            Session["category"] = "main";
            Page.Response.Redirect(Page.Request.Url.ToString(), true);

        }

        protected void fasting_button_Click(object sender, EventArgs e)
        {

            Session["category"] = "fasting";
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }


        protected void non_fasting_button_Click(object sender, EventArgs e)
        {
            Session["category"] = "non-fasting";
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void alcholic_drink_button_Click(object sender, EventArgs e)
        {
            Session["category"] = "alcoholic";
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }


        protected void non_alcholic_drink_button_Click(object sender, EventArgs e)
        {
            Session["category"] = "non-alcoholic";
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
                    SqlCommand cmd2 = new SqlCommand("SELECT * from recipe_table_temp where recipe_ID ='" + i + "'", con);

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


                                /*$"<div class='col-xs-6 col-md-4'>" +
                                $"<div class='row average'>";
                                $"<p>Average Review</p><br>" +
                                $"<p>4/6</p> " +
                                $"</div>" +
                                $"<div class='row average1'>" +
                                $"<p>Good</p> " +
                                $"<p>Lorem ipsum dolor sit amet consectetur adipisicing elit.Nulla sequi explicabo aliquam esse temporibus quae aliquid possimus? Odio ratione sed excepturi earum, dolor voluptatem libero quis soluta quasi, a consequuntur.</p>" +
                                $"</div>" +
                                $"<div class='row average1'>" +
                                "<p>veryGood</p> " +
                                "<p> Lorem ipsum dolor sit amet consectetur adipisicing elit.Nulla sequi explicabo aliquam esse temporibus quae aliquid possimus? Odio ratione sed excepturi earum, dolor voluptatem libero quis soluta quasi, a consequuntur.</p>" +
                                "</div></div>" +
                                "</div>";
                                */

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
       
    }
}