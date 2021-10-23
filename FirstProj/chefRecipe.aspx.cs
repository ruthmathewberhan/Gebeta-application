using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FirstProj
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddIngredient(object sender, EventArgs e)
        {
            string value = this.Request.Form.Get("ingredient");
            string value2 = this.Request.Form.Get("quantity");
            string value3 = this.Request.Form.Get("unit");
            string value4 = this.Request.Form.Get("select");
            string value5 = this.Request.Form.Get("steps");
            string dish = this.Request.Form.Get("dish");
            string meal = this.Request.Form.Get("meal");
            string season = this.Request.Form.Get("season");
            string[] array = value.Split(',');
            string[] quant_arr = value2.Split(',');
            string[] unit_arr = value3.Split(',');
            string[] select_arr = value4.Split(',');
            string[] steps_arr = value5.Split(',');

            //string[] array = 
            int user_id = Convert.ToInt32(Session["user_id"].ToString());
            try
            {
                string filepath = "~/Uploaded_Imgs/kitfo.jpg";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("Uploaded_Imgs/" + filename));
                filepath = "~/Uploaded_Imgs/" + filename;

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd1 = new SqlCommand("INSERT INTO dbo.recipe_table_temp(recipe_title,description,serving_quantity,total_time,recipe_img_link,chef_id,video_link) " +
                    "values(@recipe_title,@description,@serving_quantity,@total_time,@recipe_img_link,@chef_id,@video_link)", con);

                

                cmd1.Parameters.AddWithValue("@recipe_title", RecipeTitle.Text.Trim());
                cmd1.Parameters.AddWithValue("@description", RecipeIntro.InnerText.Trim());
                cmd1.Parameters.AddWithValue("@serving_quantity", servingQuantity.SelectedItem.Value);
                cmd1.Parameters.AddWithValue("@total_time", totalTime.Text.Trim());
                cmd1.Parameters.AddWithValue("@recipe_img_link", filepath);
                cmd1.Parameters.AddWithValue("@chef_id", user_id);
                cmd1.Parameters.AddWithValue("@video_link", video_link.Text.Trim());
                

                cmd1.ExecuteNonQuery();

                SqlCommand select1 = new SqlCommand("select * from dbo.recipe_table_temp where recipe_title='" + RecipeTitle.Text.Trim() + "';", con);
                SqlDataReader dr = select1.ExecuteReader();

                string recipe_id = "";
                int rec_id;

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        recipe_id = dr.GetValue(0).ToString();
                        break;
                    }
                }
                Response.Write("a");
                rec_id = int.Parse(recipe_id);

                foreach (var item in array)
                {
                    SqlCommand cmd = new SqlCommand("insert into dbo.ingredient_table_temp(ingredient_name) values (@ing_name)", con);

                    cmd.Parameters.AddWithValue("@ing_name", item);
                    cmd.ExecuteNonQuery();


                }
                Response.Write("b");

                int[] ing_array = new int[array.Length];

                for (int i = 0; i < array.Length; i++)
                {
                    SqlCommand select2 = new SqlCommand("select * from dbo.ingredient_table_temp where ingredient_name='" + array[i] + "';", con);
                    SqlDataReader dr2 = select2.ExecuteReader();

                    string ingredient_id = "";
                    int ing_id;

                    
                if (dr2.HasRows)
                    {
                        while (dr2.Read())
                        {
                            ingredient_id = dr2.GetValue(0).ToString();
                            break;
                        }
                    }

                    ing_id = int.Parse(ingredient_id);
                    ing_array[i] = ing_id;
                }
                Response.Write("c");

                for (int i = 0; i < unit_arr.Length; i++)
                {
                    SqlCommand cmd = new SqlCommand("insert into dbo.recipe_ingred_temp(recipe_ID, ingredient_id, quantity, unit) values (@recipe_ID, @ingredient_id, @quantity, @unit)", con);

                    cmd.Parameters.AddWithValue("@recipe_ID", rec_id);
                    cmd.Parameters.AddWithValue("@ingredient_id", ing_array[i]);
                    cmd.Parameters.AddWithValue("@quantity", quant_arr[i]);
                    cmd.Parameters.AddWithValue("@unit", unit_arr[i]);

                    cmd.ExecuteNonQuery();
                }
                Response.Write("d");

                for (int i = 0; i < select_arr.Length; i++)
                {
                    SqlCommand cmd = new SqlCommand("insert into dbo.recipestep_tbl_temp(recipe_ID, step_number, instruction) values (@recipe_ID, @step_number, @instruction)", con);

                    cmd.Parameters.AddWithValue("@recipe_ID", rec_id);
                    cmd.Parameters.AddWithValue("@step_number", select_arr[i]);
                    cmd.Parameters.AddWithValue("@instruction", steps_arr[i]);

                    cmd.ExecuteNonQuery();
                }
                Response.Write("e");


                SqlCommand detail = new SqlCommand("INSERT INTO dbo.recipe_detail_temp(recipe_ID,dish_type,course_meal,season) " +
                    "values(@recipe_ID,@dish_type,@course_meal,@season)", con);

                detail.Parameters.AddWithValue("@recipe_ID", rec_id);
                detail.Parameters.AddWithValue("@dish_type", dish);
                detail.Parameters.AddWithValue("@course_meal", meal);
                detail.Parameters.AddWithValue("@season", season);
                detail.ExecuteNonQuery();

                //Response.Write("<script>alert('Success');</script>");
                add_success.Visible = true;
                con.Close();
                Response.Write("f");

            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private string Split(string value, char v)
        {
            throw new NotImplementedException();
        }
    }
}