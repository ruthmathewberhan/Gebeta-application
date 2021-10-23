using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstProj
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //no one's logged in
                string sessionRole = Session["role"] as string;
                if (string.IsNullOrEmpty(sessionRole))
                {
                    signInbtn.Visible = true; //user login link button
                    signUpbtn.Visible = true; //signup link button
                    logoutbtn.Visible = false; //logout link button
                    userbtn.Visible = false; // hello user link button
                    recipebtn.Visible = false; //your recipes link button
                }

                else if (Session["role"].Equals("user"))
                {
                    signInbtn.Visible = false; //user login link button
                    signUpbtn.Visible = false; //signup link button
                    logoutbtn.Visible = true; //logout link button
                    userbtn.Visible = true;
                    recipebtn.Visible = true; //your recipes link button
                    userbtn.Text = "Hello " + Session["username"].ToString();   ; // hello user link button
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void signUpbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }

        protected void signInbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("signIn.aspx");
        }

        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            //logout - forget session variables

            Session["username"] = "";
            Session["fullname"] = "";
            Session["usertype"] = "";
            Session["role"] = "";

            signInbtn.Visible = true; //user login link button
            signUpbtn.Visible = true; //signup link button
            logoutbtn.Visible = false; //logout link button
            userbtn.Visible = false; // hello user link button
            recipebtn.Visible = false; //your recipes link button
            Response.Redirect("index.aspx");
        }

        protected void recipebtn_Click(object sender, EventArgs e)
        {
            if (Session["usertype"].ToString() == "user")
            {
                Response.Redirect("userProfile_all.aspx");
            }
            else if (Session["usertype"].ToString() == "chef")
            {
                Response.Redirect("userProfile_favs.aspx");
            }
            
        }
    }
}