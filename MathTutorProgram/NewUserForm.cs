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
    public partial class NewUserForm : Form
    {
        public NewUserForm()
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

        protected void submitButton_Click(object sender, EventArgs e)
        {
            bool passwordCorrect = true;
            //isUsernameAlreadyExists(userNameTextBox.Text);
            if (userNameTextBox.Text != "" && isUsernameAlreadyExists(userNameTextBox.Text) == false)
            {
                if (passwordTextBox.Text != "" && rePasswordTextBox.Text != "")
                {
                    if (passwordTextBox.Text == rePasswordTextBox.Text)
                    {
                        PasswordVerifier pv1 = new PasswordVerifier(passwordTextBox.Text);
                        if (!pv1.IsCharacterLengthCorrect())
                        {
                            passwordCorrect = false;
                            MessageBox.Show("Password must include at least six characters!", 
                                "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        if (!pv1.IsUpperLowerCharacterCaseAmountCorrect())
                        {
                            passwordCorrect = false;
                            MessageBox.Show
                                ("Password must include at least one uppercase letter and one lowercase letter!", 
                                "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        if (!pv1.IsDigitAmountCorrect())
                        {
                            passwordCorrect = false;
                            MessageBox.Show("Password must include at least one digit!", 
                                "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        passwordCorrect = false;
                        MessageBox.Show("The two passwords entered do not match each other!", 
                            "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    passwordCorrect = false;
                    MessageBox.Show("Neither password box can be empty!", 
                        "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (userNameTextBox.Text == "")
                {
                    passwordCorrect = false;
                    MessageBox.Show("Username cannot be empty!",
                        "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    passwordCorrect = false;
                    MessageBox.Show("Username already exists!",
                        "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (passwordCorrect == true)
            {
                WriteToFlatFile(userNameTextBox.Text, passwordTextBox.Text);
                //UserInformation uI1 = new UserInformation(userNameTextBox.Text, 1);
                UserInformation.User = userNameTextBox.Text;
                UserInformation.Level = 1; 
                using (WelcomeForm wF1 = new WelcomeForm())
                {
                    this.Hide();
                    wF1.ShowDialog();
                    this.Close();
                }
            }
        }

        protected bool isUsernameAlreadyExists(string userName)
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
                        if (userInformation[0] == userName)
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

        protected static void WriteToFlatFile(string userName, string password)
        {
            string userInfo = userName + "/" + password + "/" + "1/"; 

            try
            {
                using (StreamWriter writer = File.AppendText("UserInformation.txt"))
                {
                    writer.WriteLine(userInfo);
                    writer.Close(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing to text file: " + ex.Message, 
                    "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }


    }
}
