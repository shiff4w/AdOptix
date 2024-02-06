using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SQLite;

namespace Optical
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
            //Setting the click to the login button
            buttonLogin.Click += (s, e) =>
            {
                //Get username and password from textbox fields
                string username = textBoxUsername.Text.ToLower().Trim();
                string password = textBoxPassword.Text;

                //Open sql connection from the static 'Helper' class
                Helper.sqliteConn.Open();

                //Create a command to sql, to select the database user that matches the given username and password 
                SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM users WHERE LOWER(LTRIM(RTRIM(username))) = @user and PASSWORD = @pass", Helper.sqliteConn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);

                //Fetch results
                SQLiteDataReader dr = cmd.ExecuteReader();

                //If the username and password are correct
                if (dr.HasRows) //True
                {
                    dr.Close();

                    Helper.sqliteConn.Close();

                    //Open main form
                    MainDashboard dashboard = new MainDashboard();
                    dashboard.Show();
                    System.Windows.Forms.Application.OpenForms.OfType<MainPage>().FirstOrDefault().Hide();
                    this.Close();
                }
                else
                {
                    //If the sql data reader object did not receive any value from the database
                    //if the user did not input a correct username and password
                    MessageBox.Show("Username or password is incorrect.");
                }

                dr.Close();

                //Close the sql connection from the static 'Helper' class
                Helper.sqliteConn.Close();
            };
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
