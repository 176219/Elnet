using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Load saved username if Remember Me was checked
            if (Properties.Settings.Default.RememberUser)
            {
                txtboxEmailAdd.Text = Properties.Settings.Default.SavedUsername;
                rmbrBox.Checked = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = txtboxEmailAdd.Text.Trim();
            string password = txtBoxPassword.Text.Trim();

            // simple demo login
            if (username == "admin" && password == "password")
            {
                // SAVE REMEMBER ME
                if (rmbrBox.Checked)
                {
                    Properties.Settings.Default.SavedUsername = username;
                    Properties.Settings.Default.RememberUser = true;
                }
                else
                {
                    Properties.Settings.Default.SavedUsername = "";
                    Properties.Settings.Default.RememberUser = false;
                }

                Properties.Settings.Default.Save();

                // Open dashboard
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.",
                                "Login Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void txtboxEmailAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void rmbrBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
