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
    public partial class WebForm8 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //register button click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {
                ExistedID.Visible = true;
                emptyID.Visible = false;
                successID.Visible = false;
                // Response.Write("<script>alert('Member Already Exist with this username, try another username');</script>");
            }
            else if (checkEmpty(TextBoxFName.Text.Trim(), TextBoxUName.Text.Trim(), TextBoxEmail.Text.Trim(), TextBoxPass.Text.Trim(), DropDownListUType.SelectedItem.Value))
            {
                ExistedID.Visible = false;
                emptyID.Visible = true;
                successID.Visible = false;
                // Response.Write("<script>alert('every boxes should be filled!!');</script>");

            }
            else
            {
                signUpNewMember();
            }  
        }

        // user defined method

        bool checkMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from user_table where user_name='"+TextBoxUName.Text.Trim()+"';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                con.Close();
         
                //Response.Write("<script>alert('Sign up Successful. Go to user Login to Login');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
                return false;
            }
            
        }
        bool checkEmpty(string Fname,string Uname,string email,string password,string Utype)
        {
            if (Fname == "" || Uname == "" || email == "" || password == "" || Utype == "" )
            {
                return true;
            }
            return false;
        }
        void signUpNewMember()
        {
            
            //Response.Write("<script>alert('Testing');</script>");
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO user_table(full_name,user_name,email,password,user_type) " +
                    "values(@full_name,@user_name,@email,@password,@user_type)", con);



                cmd.Parameters.AddWithValue("@full_name", TextBoxFName.Text.Trim());
                cmd.Parameters.AddWithValue("@user_name", TextBoxUName.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBoxEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBoxPass.Text.Trim());
                cmd.Parameters.AddWithValue("@user_type", DropDownListUType.SelectedItem.Value);

                cmd.ExecuteNonQuery();
                con.Close();
                ExistedID.Visible = false;
                emptyID.Visible = false;
                successID.Visible = true;
                // Response.Write("<script>alert('Sign up Successful. Go to user Login to Login');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + " ');</script>");
            }
        }
    }
}