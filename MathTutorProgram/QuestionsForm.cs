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
    public partial class QuestionsForm : Form
    {

        Random randomizer = new Random();
        protected int level;
        private int timeLeft;
        private int[] number = new int[20];

        public QuestionsForm()
        {
            InitializeComponent();
        }

        public QuestionsForm(int level)
        {
            this.level = level; 
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (this.level == 1)
            {
                Level1SetUp();
                startButton.Enabled = false; 
            }
            else if(this.level == 2)
            {
                Level2SetUp();
                startButton.Enabled = false; 
            }
            else if (this.level == 3)
            {
                Level3SetUp();
                startButton.Enabled = false;
            }
            else if (this.level == 4)
            {
                Level4SetUp();
                startButton.Enabled = false;
            }
        }

        private void Level1SetUp()
        {           
            for (int i = 0; i < 20; i++)
            {
                number[i] = randomizer.Next(51); 
            }

            SetPannelsVisible();
            AssignNumbersForQuestion();
            SetOperatorsForLevel1(); 
            SetTimer();
        }

        private void Level2SetUp()
        {
            for (int i = 0; i < 16; i=i+2)
            {
                number[i] = randomizer.Next(1, 101);
                number[i + 1] = randomizer.Next(1, number[i]);
            }

            for (int i = 16; i < 20; i++)
            {
                number[i] = randomizer.Next(51);
            }

            SetPannelsVisible();
            AssignNumbersForQuestion();
            SetOperatorsForLevel2();
            SetTimer();
        }

        private void Level3SetUp()
        {
            for (int i = 0; i < 12; i++)
            {
                number[i] = randomizer.Next(2, 11);
            }

            for (int i = 12; i < 16; i = i + 2)
            {
                number[i] = randomizer.Next(1, 101);
                number[i + 1] = randomizer.Next(1, number[i]);
            }

            for (int i = 16; i < 20; i++)
            {
                number[i] = randomizer.Next(51);
            }

            SetPannelsVisible();
            AssignNumbersForQuestion();
            SetOperatorsForLevel3();
            SetTimer();
        }

        private void Level4SetUp()
        {
            for (int i = 0; i < 6; i=i+2)
            {
                number[i+1] = randomizer.Next(2, 11);
                int temporaryQuotient = randomizer.Next(2, 11);
                number[i] = number[i+1] * temporaryQuotient;
            }

            for (int i = 6; i < 12; i++)
            {
                number[i] = randomizer.Next(2, 11);
            }

            for (int i = 12; i < 16; i = i + 2)
            {
                number[i] = randomizer.Next(1, 101);
                number[i + 1] = randomizer.Next(1, number[i]);
            }

            for (int i = 16; i < 20; i++)
            {
                number[i] = randomizer.Next(51);
            }

            SetPannelsVisible();
            AssignNumbersForQuestion();
            SetOperatorsForLevel4();
            SetTimer();
        }

        private void SetPannelsVisible()
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = true;
            panel6.Visible = true;
            panel7.Visible = true;
            panel8.Visible = true;
            panel9.Visible = true;
            panel10.Visible = true; 
        }

        private void AssignNumbersForQuestion()
        {
            leftNum1Label.Text = number[0].ToString();
            rightNum1Label.Text = number[1].ToString();
            leftNum2Label.Text = number[2].ToString();
            rightNum2Label.Text = number[3].ToString();
            leftNum3Label.Text = number[4].ToString();
            rightNum3Label.Text = number[5].ToString();
            leftNum4Label.Text = number[6].ToString();
            rightNum4Label.Text = number[7].ToString();
            leftNum5Label.Text = number[8].ToString();
            rightNum5Label.Text = number[9].ToString();
            leftNum6Label.Text = number[10].ToString();
            rightNum6Label.Text = number[11].ToString();
            leftNum7Label.Text = number[12].ToString();
            rightNum7Label.Text = number[13].ToString();
            leftNum8Label.Text = number[14].ToString();
            rightNum8Label.Text = number[15].ToString();
            leftNum9Label.Text = number[16].ToString();
            rightNum9Label.Text = number[17].ToString();
            leftNum10Label.Text = number[18].ToString();
            rightNum10Label.Text = number[19].ToString();
        }

        private void SetOperatorsForLevel1()
        {
            operator1.Text = "+";
            operator2.Text = "+";
            operator3.Text = "+";
            operator4.Text = "+";
            operator5.Text = "+";
            operator6.Text = "+";
            operator7.Text = "+";
            operator8.Text = "+";
            operator9.Text = "+";
            operator10.Text = "+"; 
        }

        private void SetOperatorsForLevel2()
        {
            operator1.Text = "-";
            operator2.Text = "-";
            operator3.Text = "-";
            operator4.Text = "-";
            operator5.Text = "-";
            operator6.Text = "-";
            operator7.Text = "-";
            operator8.Text = "-";
            operator9.Text = "+";
            operator10.Text = "+";
        }

        private void SetOperatorsForLevel3()
        {
            operator1.Text = "*";
            operator2.Text = "*";
            operator3.Text = "*";
            operator4.Text = "*";
            operator5.Text = "*";
            operator6.Text = "*";
            operator7.Text = "-";
            operator8.Text = "-";
            operator9.Text = "+";
            operator10.Text = "+";
        }

        private void SetOperatorsForLevel4()
        {
            operator1.Text = "/";
            operator2.Text = "/";
            operator3.Text = "/";
            operator4.Text = "*";
            operator5.Text = "*";
            operator6.Text = "*";
            operator7.Text = "-";
            operator8.Text = "-";
            operator9.Text = "+";
            operator10.Text = "+";
        }

        private void SetTimer()
        {
            timeLeft = 60;
            timeLabel.Text = "60 seconds";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer(this.level))
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations");

                UserInformation.Level = ++this.level;
                WriteNewLevelToFile();
                using (WelcomeForm wF1 = new WelcomeForm())
                {
                    this.Hide();
                    wF1.ShowDialog();
                    this.Close(); 
                }
            }
            else if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry");
               // startButton.Enabled = true;

                using (WelcomeForm wF1 = new WelcomeForm())
                {
                    this.Hide();
                    wF1.ShowDialog();
                    this.Close();
                }
            }
        }

        private bool CheckTheAnswer(int level)
        {
            switch (level)
            {
                case 1:
                    return ForLevel1(); 
                case 2:
                    return ForLevel2();      
                case 3:
                    return ForLevel3(); 
                case 4:
                    return ForLevel4();
            }
            return false ; 
        }

        private bool ForLevel1()
        {
            if (number[0] + number[1] == answer1.Value
                && number[2] + number[3] == answer2.Value
                && number[4] + number[5] == answer3.Value
                && number[6] + number[7] == answer4.Value
                && number[8] + number[9] == answer5.Value
                && number[10] + number[11] == answer6.Value
                && number[12] + number[13] == answer7.Value
                && number[14] + number[15] == answer8.Value
                && number[16] + number[17] == answer9.Value
                && number[18] + number[19] == answer10.Value)
                return true;
            else
                return false;
        }

        private bool ForLevel2()
        {
            if (number[0] - number[1] == answer1.Value
                && number[2] - number[3] == answer2.Value
                && number[4] - number[5] == answer3.Value
                && number[6] - number[7] == answer4.Value
                && number[8] - number[9] == answer5.Value
                && number[10] - number[11] == answer6.Value
                && number[12] - number[13] == answer7.Value
                && number[14] - number[15] == answer8.Value
                && number[16] + number[17] == answer9.Value
                && number[18] + number[19] == answer10.Value)
                return true;
            else
                return false; 
        }

        private bool ForLevel3()
        {
            if (number[0] * number[1] == answer1.Value
                && number[2] * number[3] == answer2.Value
                && number[4] * number[5] == answer3.Value
                && number[6] * number[7] == answer4.Value
                && number[8] * number[9] == answer5.Value
                && number[10] * number[11] == answer6.Value
                && number[12] - number[13] == answer7.Value
                && number[14] - number[15] == answer8.Value
                && number[16] + number[17] == answer9.Value
                && number[18] + number[19] == answer10.Value)
                return true;
            else
                return false;
        }

        private bool ForLevel4()
        {
            if (number[0] / number[1] == answer1.Value
                && number[2] / number[3] == answer2.Value
                && number[4] / number[5] == answer3.Value
                && number[6] * number[7] == answer4.Value
                && number[8] * number[9] == answer5.Value
                && number[10] * number[11] == answer6.Value
                && number[12] - number[13] == answer7.Value
                && number[14] - number[15] == answer8.Value
                && number[16] + number[17] == answer9.Value
                && number[18] + number[19] == answer10.Value)
                return true;
            else
                return false;
        }

        private void WriteNewLevelToFile()
        {
            //string userInfo = userName + "/" + password + "/" + "1/";
            //string userInfo = UserInformation.User + "/" + password + "/" + UserInformation.Level;
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
                                string userInfo = UserInformation.User + "/" + userInformation[1] + "/" + UserInformation.Level;
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


        private void answer_Enter(object sender, EventArgs e)
        {

            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            using (WelcomeForm wF1 = new WelcomeForm())
            {
                this.Hide();
                wF1.ShowDialog();
                this.Close();
            }
        }


 
    }
}
