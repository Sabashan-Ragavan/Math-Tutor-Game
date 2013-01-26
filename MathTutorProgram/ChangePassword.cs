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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {        
            InitializeComponent();
        }

        private void submitButtonChangePassword_Click(object sender, EventArgs e)
        {
            bool passwordCorrect = true;
            //isUsernameAlreadyExists(userNameTextBox.Text);

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


            if (passwordCorrect == true)
            {
                ChangePasswordInFlatFile(passwordTextBox.Text);
                this.Close(); 
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

        protected static void ChangePasswordInFlatFile(string password)
        {
            //string userInfo = userName + "/" + password + "/" + "1/";
            string userInfo = UserInformation.User + "/" + password + "/" + UserInformation.Level; 
            try
            {
                string tempFile = Path.GetTempFileName();

                using (var sr = new StreamReader("UserInformation.txt"))
                {
                    using (var sw = new StreamWriter(tempFile))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] userInformation = line.Split('/');
                            if (userInformation[0] == UserInformation.User)
                            {
                                sw.WriteLine(userInfo);
                            }
                            else
                            {
                                sw.WriteLine(line); 
                            }
                        }
                    }
                }

                File.Delete("UserInformation.txt");
                File.Move(tempFile, "UserInformation.txt");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error writing to text file: " + ex.Message,
                    "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


    }
}