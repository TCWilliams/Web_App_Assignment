/*
 * Login page, username is jay, password is password
 * Creates a .cs file Session variable of Server class
 * redirects to dummy client page
 * 
 * Author: Tim Williams
 */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        string name = nameTextBox.Text;
        string pword = passwordTextBox.Text;
        if (name.ToLower().Equals("jay") && pword.ToLower().Equals("password"))
        {
            Server server = new Server();

            System.Web.HttpContext.Current.Session["server"] = server;

            Response.Redirect("ServerDemoPage.aspx");

        }
    }
}