﻿using System;
using Core;

namespace Admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLabel.Text = "Invalid username or password";
        }

        protected void SignInButton_Click(object sender, EventArgs e)
        {
            var U = UsersRepository.AuthenticateUser(UsernameTextBox.Text, PasswordTextBox.Text);
            if (U != null && U.IsAuthenticated)
            {
                var ReturnUrl = Request.QueryString["ReturnUrl"];
                if (string.IsNullOrWhiteSpace(ReturnUrl))
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Response.Redirect(ReturnUrl);
                }
            }
            else
            {
                ErrorLabel.Visible = true;
            }
        }
    }
}