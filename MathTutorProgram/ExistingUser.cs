using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO; 

namespace MathTutorProgram
{
    public partial class ExistingUser : Form
    {
        public ExistingUser()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            using (IntroScreen mTutorProgram = new IntroScreen())
            {
                this.Hide();     // hides current
                mTutorProgram.ShowDialog();
                this.Close(); 
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (isUsernameAndPasswordAlreadyExists(userNameTextBox.Text, passwordTextBox.Text) == true)
            {
                //MessageBox.Show("OK");
                //UserInformation uI1 = new UserInformation(userNameTextBox.Text, UsersCurrentLevel(userNameTextBox.Text));
                UserInformation.User = userNameTextBox.Text;
                UserInformation.Level = UsersCurrentLevel(userNameTextBox.Text);
                using (WelcomeForm wF1 = new WelcomeForm())
                {
                    this.Hide();
                    wF1.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Credentials do not match anyone in database!",
                    "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static int UsersCurrentLevel(string username)
        {             
            try
            {
                StreamReader reader = new StreamReader("UserInformation.txt");
                string line = "";

                while (line != null)
                {

                    line = reader.ReadLine();
                    if (line != null)
                    {
                        string[] userInformation = line.Split('/');
                        if (userInformation[0] == username)
                        {
                            reader.Close();
                            return int.Parse(userInformation[2]);
                        }
                    }
                }
                reader.Close();
                return -1;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading from text file: " + ex.Message,
                    "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -1; 

            }
        
        }

        private static bool isUsernameAndPasswordAlreadyExists(string username, string password)
        {
            try
            {
                StreamReader reader = new StreamReader("UserInformation.txt");
                string line = "";

                while (line != null)
                {

                    line = reader.ReadLine();
                    if (line != null)
                    {
                        string[] userInformation = line.Split('/');
                        if (userInformation[0] == username && userInformation[1] == password)
                        {
                            reader.Close(); 
                            return true;
                        }
                    }
                }
                reader.Close();
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading from text file: " + ex.Message,
                    "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
    }
}
