using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstProj
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        // start a connection string b/n the database and ui
        string ConnectionStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // display the recpie ingredients information
        public string DisplayNewRecipie()
        {
            string htmlStr = "";

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

                // the comand for selecting the information for specfic recpie id
                SqlCommand command1 = new SqlCommand("SELECT TOP 4 * FROM recipe_table_temp", Con2);

                // the data reader
                SqlDataReader dataReader1 = command1.ExecuteReader();

                // ask if iteration is needed?////

                /// check if there is a recpie for the given repie id
                if (dataReader1.HasRows)
                {
                    // if true while the reader is reading the data
                    while (dataReader1.Read())
                    {
                        // save the recpie information for display
                        string recpieTitle = dataReader1.GetValue(1).ToString();
                        string recpieDescription = dataReader1.GetValue(2).ToString();
                        string recpieServing = dataReader1.GetValue(3).ToString();
                        string recpieTime = dataReader1.GetValue(4).ToString();

                        //Response.Write(source);
                        htmlStr += $"<tr>" +
                            $"<td>{recpieTitle}</td>" +
                            $"<td>{recpieDescription}</td>" +
                            $"<td>{recpieServing}</td>" +
                            $"<td>{recpieTime}</td>" +
                            $"</tr>" +
                            $""
                            ;

                    }

                    Con2.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }


            return htmlStr;
        }
    }
}