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
    public partial class WebForm2 : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        List<string> ingredients = new List<string>();
        List<string> instructions = new List<string>();
        List<int> rev_id_lst = new List<int>();
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((Session["user_id"]) == null)
            {
                review.Visible = true;
                return;
            }
            review.Visible = false;
            string id = Request.QueryString["id"];
            int user_id = Convert.ToInt32(Session["user_id"].ToString());
            string user_name = Session["username"].ToString();
            //string review = review_Textarea.Value;
            //string rating = rate.Value;
            int recipe_id = Convert.ToInt32(id);

            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO review_table(user_id,username,review,rating,recipe_ID) " +
                    "values(@user_id,@username,@review,@rating,@recipe_ID )", con);

                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@username", user_name);
                cmd.Parameters.AddWithValue("@review", review_Textarea.Value);
                cmd.Parameters.AddWithValue("@rating", rate.Value);
                cmd.Parameters.AddWithValue("@recipe_ID", recipe_id);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('review added');</script>");
                no_rev.Visible = false;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }

            Response.Write(user_id);
            Response.Write(user_name);
            //Response.Write(review);
            //Response.Write(rating);
        }


        public string get_recipe()
        {
            string htmlStr = "";
            int id = Convert.ToInt32(Request.QueryString["id"]);

            try
            {
                string recipe_title;

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from recipe_table_temp where recipe_ID ='" + id + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        recipe_title = dr.GetValue(1).ToString();
                        int chef_id = Convert.ToInt32(dr.GetValue(6).ToString());
                        string img_link = dr.GetValue(5).ToString();
                        string link = img_link.Substring(1);
                        string description = dr.GetValue(2).ToString();
                        string full_name = getFullName(chef_id);
                        string video_link = dr.GetValue(7).ToString();
                        string total_time = dr.GetValue(4).ToString();

                        htmlStr += $"<div class='container title-box mt-5 p-5'>" +
                            $"<div class='row'> " +
                            $" <div class='col-md-9'> " +
                            $"<div class='recipe-title'>" +
                            $"<p class= 'title-text'>{recipe_title}</p>" +
                            $"<p class='rec-desc'><span class='me-2'>By Chef <span>{full_name}</span> </span> | <span class='ms-2 me-2'>Gebeta</span>  | <span class='ms-2'>May 2018</span> </p>" +
                            $"</div>" +
                            $"</div>" +
                            $"<div class='col-md-1 title-addons'>" +
                            $" <p class='revs'>4/4</p>" +
                            $"<p class=''>reviews(4)</p>" +
                            $"</div>" +
                            $"</div>" +
                            $"</div>" +
                            $"<div class='container w-75'>" +
                            $"<div class='card recipe-imgs'>" +
                            $"<img src = '{link}' class='img-fluid card-img-top r-card-img' alt='...'>" +
                            $"</div>" +
                            $"<div class='overview'>" +
                            $"<p>{description}</p>" +
                            $"<hr>" +
                            $"<iframe class='pt-3 ps-5 pb-5 iframe'  src='{video_link}' title='YouTube video player' frameborder='0' allow='accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>" +
                            $"</div>" +
                            $"<div class='recipe-box p-5 mb-5 pb-5'>" +
                            $"<p><span class='title'>Total time: </span>{total_time}</p>" +
                            $"<hr>" +
                            $"<p class='title pb-0 mb-2'>Ingredients</p>" +
                            $"<ul class='ps-3 ingdts'>";

                        getIngredientList(id);

                        foreach (string s in ingredients)
                        {
                            htmlStr += $"<li>{s}</li>";
                        }

                        htmlStr +=
                        $"</ul>" +
                        $"<hr>" +
                        $"<p class='title'>Preparation</p>" +
                        $"<ol class='ps-4 prep'>";

                        getInstruction(id);

                        foreach (string s in instructions)
                        {
                            htmlStr += $"<li class='pb-4'>{s}</li>";
                        }

                        htmlStr +=
                            $"</ol>" +
                            $"</div>";



                    }
                }
                else
                {
                    Response.Write("Invalid");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }
            return htmlStr;
        }

        public string getReviews()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string htmlStr = "";
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from review_table where recipe_ID='" + id + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();



                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        int rating = Convert.ToInt32(dr.GetValue(4).ToString());
                        string review = dr.GetValue(3).ToString();
                        string uname = dr.GetValue(2).ToString();

                        htmlStr +=
                            $"<div class='row'>" +
                            $"<div class='col-1 rev-stars mt-5 me-0 pe-0'>" +
                            $"<p class='rev-star'>{rating}/5</p>" +
                            $"</div>" +
                            $"<div class='col-11 ms-0 ps-0'>" +
                            $"<p class='rev-text pt-4 mb-1'>{review}</p>" +
                            $"<p class='username pt-0 mt-0'>{uname}</p>" +
                            $"</div>" +
                            $"</div>" +
                            $"<hr>" +
                            $"</div>" +
                            $"</div>";
                    }

                }
                else
                {
                    no_rev.Visible = true;
                    //Response.Write("Invalid credentials");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }
            return htmlStr;
        }

        public string getFullName(int id)
        {

            string Fname = "";
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from user_table where user_id='" + id + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Fname = dr.GetValue(1).ToString();
                    }

                }
                else
                {
                    Response.Write("Invalid credentials");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }
            return Fname;
        }

        public void getIngredientList(int id)
        {
            List<int> ing_id_list = new List<int>();

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from recipe_ingred_temp where recipe_ID='" + id + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ing_id_list.Add(Convert.ToInt32(dr.GetValue(2).ToString()));
                    }

                }
                else
                {
                    Response.Write("Invalid credentials");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                foreach (int i in ing_id_list)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * from ingredient_table_temp where ingredient_ID='" + i + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();


                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ingredients.Add(dr.GetValue(1).ToString());
                        }

                    }
                    else
                    {
                        Response.Write("no results");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }
        }

        public string getInstruction(int id)
        {

            string Fname = "";
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from recipestep_tbl_temp where recipe_ID='" + id + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        instructions.Add(dr.GetValue(3).ToString());
                    }

                }
                else
                {
                    Response.Write("no results");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }
            return Fname;
        }


    }
}