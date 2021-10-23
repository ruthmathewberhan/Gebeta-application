using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstProj
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        // start a connection string b/n the database and ui
        string ConnectionStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // update row
        protected void button1_Click(object sender, EventArgs e)
        {
            if (hasRecpie())
            {
                UpdateRecpie();
                UpdateRecpieDetail();
                Response.Write("<script>alert(' recipe updated sucessfully ');</script>");

            }
            else
            {
                Response.Write("<script>alert(' the recpie does not exist ');</script>");
            }

        }

        protected void button3_Click(object sender, EventArgs e)
        {

            if (hasRecpie())
            {
                Delete();
                Response.Write("<script>alert(' recipe deleted sucessfully ');</script>");
            }
            else
            {
                Response.Write("<script>alert(' the recpie does not exist ');</script>");
            }


        }


        // update Recpie method
        public void UpdateRecpie()
        {
            // save the id of the selected recpie id
            int recpieId = Int32.Parse(id.Value);

            
            try
            {
                // connect to the sql using the connection string
                SqlConnection Con1 = new SqlConnection(ConnectionStr);

                // check wetheer the sql connection is open or closed 
                // if true open it
                if (Con1.State == ConnectionState.Closed)
                {
                    Con1.Open();
                }

                // the comand for Updating the information for specfic recpie id
                SqlCommand command2 = new SqlCommand("UPDATE Recipe_table SET Recipe_Title=@recipeTitle, Description=@description, Serving_Quantity=@quantity, total-time=@time WHERE Recipe_ID='" + recpieId + "'", Con1);

                /// pass the values
                command2.Parameters.AddWithValue("@recipeTitle", title.Value);
                command2.Parameters.AddWithValue("@description", description.Value);
                command2.Parameters.AddWithValue("@quantity", quantity.Value);
                command2.Parameters.AddWithValue("@time", time.Value);

                command2.ExecuteNonQuery();

                Con1.Close();
                Response.Write("<script>alert('recipe has been sucessfully updated');</script>");
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }

        }

        

        // update Recpie method
        public void UpdateRecpieDetail()
        {

            string dish = this.Request.Form.Get("dish");
            string meal = this.Request.Form.Get("meal");
            string season = this.Request.Form.Get("season");



            // save the id of the selected recpie id
            string recpieId = id.Value;


            try
            {
                // connect to the sql using the connection string
                SqlConnection Con2 = new SqlConnection(ConnectionStr);

                // check wetheer the sql connection is open or closed 
                // if true open it
                if (Con2.State == ConnectionState.Closed)
                {
                    Con2.Open();
                }

                // the comand for Updating the information for specfic recpie id
                SqlCommand command3 = new SqlCommand("UPDATE recipe_detail_table SET dish_type=@recipeTitle, course_meal=@description, " +
                    "season=@quantuty  WHERE recipe_ID='" + recpieId + "'", Con2);

                /// pass the values
                command3.Parameters.AddWithValue("@recipeDish", dish);
                command3.Parameters.AddWithValue("@description", meal);
                command3.Parameters.AddWithValue("@quantity", season);
               

                command3.ExecuteNonQuery();

                Con2.Close();
                Response.Write("<script>alert('recipe has been sucessfully updated');</script>");
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }

        }


        // delete a recpie
        public void Delete()
        {
            string recipe_id = id.Value;

            try
            {

                SqlConnection con = new SqlConnection(ConnectionStr);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                // delete from recpie table
                SqlCommand cmd1 = new SqlCommand("delete from  dbo.Recipe_table where Recipe_ID ='" + recipe_id + "'", con);

                cmd1.ExecuteNonQuery();

                // delete from ingredient table
                SqlCommand cmd2 = new SqlCommand("delete from  dbo.recipe_ingredient_table where recipe_ID ='" + recipe_id + "'", con);

                cmd2.ExecuteNonQuery();

                // delete from preparation step table
                SqlCommand cmd3 = new SqlCommand("delete from  dbo.recipe_step_table where recipe_ID ='" + recipe_id + "'", con);

                cmd3.ExecuteNonQuery();

                // from recpie detail table
                SqlCommand cmd4 = new SqlCommand("delete from  dbo.recipe_detail_table where recipe_ID ='" + recipe_id + "'", con);

                cmd4.ExecuteNonQuery();


                Response.Write("<script>alert(' Recpie Deleted Sucessfully');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }


        // check if the recpie exists
        public bool hasRecpie()
        {

            try
            {
                // save the id of the selected recpie id
                string recpieId = id.Value;

                // start a connection string b/n the database and ui
                string ConnectionStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

                // connect to the sql using the connection string
                SqlConnection Con = new SqlConnection(ConnectionStr);

                // check wetheer the sql connection is open or closed 
                // if true open it
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }

                // the comand for selecting the information for specfic recpie id
                SqlCommand command = new SqlCommand("SELECT * from Recipe_table where Recipe_ID ='" + recpieId + "'", Con);

                // the adapter for the above command
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                // create a data table object for the result
                DataTable dt = new DataTable();

                // fill the datatable with the result from the data reader
                dataAdapter.Fill(dt);

                if(dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                Con.Close();

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
                return false;
            }

        }

        
    }

}
