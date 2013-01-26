using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace MathTutorProgram
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }
        public WelcomeForm(int level)
        {
            UserInformation.Level = level;
            InitializeComponent();
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {

            welcomeUserLabel.Text += " " + UserInformation.User.ToString() + "!";

            if (UserInformation.Level >= 1)
                level1Button.Enabled = true;
            if (UserInformation.Level >= 2)
                level2Button.Enabled = true;
            if (UserInformation.Level >= 3)
                leve3Button.Enabled = true;
            if (UserInformation.Level >= 4)
                level4Button.Enabled = true;
            if (UserInformation.Level >= 5)
                level5Button.Enabled = true;
            if (UserInformation.Level >= 6)
                level6Button.Enabled = true; 
        }


        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInformation.Clear();

            using (IntroScreen iS1 = new IntroScreen())
            {
                this.Hide();
                iS1.ShowDialog();
                this.Close(); 

            }
        }

        private void level1Button_Click(object sender, EventArgs e)
        {
            using (QuestionsForm qF1 = new QuestionsForm(1))
            {
                this.Hide();
                qF1.ShowDialog();
                this.Close(); 
            }
        }

        private void level2Button_Click(object sender, EventArgs e)
        {
            using (QuestionsForm qF1 = new QuestionsForm(2))
            {
                this.Hide();
                qF1.ShowDialog();
                this.Close();
            }
        }

        private void leve3Button_Click(object sender, EventArgs e)
        {
            using (QuestionsForm qF1 = new QuestionsForm(3))
            {
                this.Hide();
                qF1.ShowDialog();
                this.Close();
            }
        }

        private void level4Button_Click(object sender, EventArgs e)
        {
            using (QuestionsForm qF1 = new QuestionsForm(4))
            {
                this.Hide();
                qF1.ShowDialog();
                this.Close();
            }
        }

        private void level5Button_Click(object sender, EventArgs e)
        {
            using (FractionQuestionForm qF1 = new FractionQuestionForm(5))
            {
                this.Hide();
                qF1.ShowDialog();
                this.Close();
            }
        }

        private void level6Button_Click(object sender, EventArgs e)
        {
            using (FractionQuestionForm qF1 = new FractionQuestionForm(6))
            {
                this.Hide();
                qF1.ShowDialog();
                this.Close();
            }
        }


        private void levelOneToolStripMenuItem_Click(object sender, EventArgs e)
        {
                        MessageBox.Show("10 addition problems which must be completed within 60 seconds",
                    "Level One Info",
            MessageBoxButtons.OK); 
        }

        private void levelTwoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("10 total addition and subtraction problems which must be completed within 60 seconds",
                    "Level Two Info",
                    MessageBoxButtons.OK); 
        }

        private void levelThreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("10 total addition, subtraction and multiplication problems which must be completed within 60 seconds",
                    "Level Three Info",
                MessageBoxButtons.OK); 
        }

        private void levelFourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("10 total addition, subtraction, multiplication and division problems which must be completed within 60 seconds",
                    "Level Four Info",
                MessageBoxButtons.OK); 
        }

        private void levelFiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("10 total fraction addition and subtraction problems which must be completed within 60 seconds",
                "Level Five Info",
                MessageBoxButtons.OK); 
        }

        private void levelSixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("10 total fraction addition, subtraction, multiplication and division problems which must be completed within 60 seconds",
                "Level Six Info",
                MessageBoxButtons.OK); 
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ChangePassword cP1 = new ChangePassword())
            {
                //this.Hide();
                cP1.ShowDialog();
                //this.Close();
            }
        }

        private void signOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you would like to exit?", "Sign Out",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation);

            if (dialogResult == DialogResult.Yes)
            {
                UserInformation.Clear();

                using (IntroScreen iS1 = new IntroScreen())
                {
                    this.Hide();
                    iS1.ShowDialog();
                    this.Close();

                }
            }
        }





    }
}
