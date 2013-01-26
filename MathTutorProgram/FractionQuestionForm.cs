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
    public partial class FractionQuestionForm : Form
    {
        Random randomizer = new Random();
        private int level;
        private int timeLeft;
        private FractionClass[] number = new FractionClass[20];

        public FractionQuestionForm(int level)
        {
            this.level = level; 
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (this.level == 5)
            {
                Level5SetUp();
                startButton.Enabled = false;
            }
            else if (this.level == 6)
            {
                Level6SetUp();
                startButton.Enabled = false;
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

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void Level5SetUp()
        {
            for (int i = 0; i < 6; i=i+2)
            {
                int num1 = randomizer.Next(1, 11);
                int num2 = randomizer.Next(1,11); 
                int den = randomizer.Next(1, 16);
                int cd = randomizer.Next(1, 4);
                if (i == 0 || i == 4)
                {
                    number[i] = new FractionClass(num1, den);
                    number[i + 1] = new FractionClass(num2, den * cd);
                }
                else
                {
                    number[i+1] = new FractionClass(num1, den);
                    number[i] = new FractionClass(num2, den * cd);
                }
            }

            for (int i = 6; i < 12; i = i + 2)
            {
                int num1 = randomizer.Next(1, 11);
                int num2 = randomizer.Next(1, num1);
                int den = randomizer.Next(1, 16);
                number[i] = new FractionClass(num1, den);
                number[i + 1] = new FractionClass(num2, den * randomizer.Next(1, 4));
            }

            SetPannelsVisible();
            AssignNumbersForQuestion();
            SetOperatorsForLevel5();
            SetTimer();
        }

        private void Level6SetUp()
        {
            for (int i = 0; i < 8; i++)
            {
                int num = randomizer.Next(1, 11);
                int den = randomizer.Next(1, 11);
                number[i] = new FractionClass(num, den);
            }

            for (int i = 8; i < 10; i = i + 2)
            {
                int num1 = randomizer.Next(1, 11);
                int num2 = randomizer.Next(1, 11);
                int den = randomizer.Next(1, 16);
                if (i == 6)
                {
                    number[i] = new FractionClass(num1, den);
                    number[i + 1] = new FractionClass(num2, den * randomizer.Next(1, 4));
                }
                else
                {
                    number[i + 1] = new FractionClass(num1, den);
                    number[i] = new FractionClass(num2, den * randomizer.Next(1, 4));
                }
            }

            for (int i = 10; i < 12; i = i + 2)
            {
                int num1 = randomizer.Next(1, 11);
                int num2 = randomizer.Next(1, num1);
                int den = randomizer.Next(1, 16);
                number[i] = new FractionClass(num1, den);
                number[i + 1] = new FractionClass(num2, den * randomizer.Next(1, 4));
            }

            SetPannelsVisible();
            AssignNumbersForQuestion();
            SetOperatorsForLevel6();
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
        }

        private void AssignNumbersForQuestion()
        {
            leftNumNumerator1Label.Text = number[0].Numerator.ToString();
            leftNumDenominator1Label.Text = number[0].Denominator.ToString();
            rightNumNumerator1Label.Text = number[1].Numerator.ToString();
            rightNumDenominator1Label.Text = number[1].Denominator.ToString();

            leftNumNumerator2Label.Text = number[2].Numerator.ToString();
            leftNumDenominator2Label.Text = number[2].Denominator.ToString();
            rightNumNumerator2Label.Text = number[3].Numerator.ToString();
            rightNumDenominator2Label.Text = number[3].Denominator.ToString();

            leftNumNumerator3Label.Text = number[4].Numerator.ToString();
            leftNumDenominator3Label.Text = number[4].Denominator.ToString();
            rightNumNumerator3Label.Text = number[5].Numerator.ToString();
            rightNumDenominator3Label.Text = number[5].Denominator.ToString();

            leftNumNumerator4Label.Text = number[6].Numerator.ToString();
            leftNumDenominator4Label.Text = number[6].Denominator.ToString();
            rightNumNumerator4Label.Text = number[7].Numerator.ToString();
            rightNumDenominator4Label.Text = number[7].Denominator.ToString();

            leftNumNumerator5Label.Text = number[8].Numerator.ToString();
            leftNumDenominator5Label.Text = number[8].Denominator.ToString();
            rightNumNumerator5Label.Text = number[9].Numerator.ToString();
            rightNumDenominator5Label.Text = number[9].Denominator.ToString();

            leftNumNumerator6Label.Text = number[10].Numerator.ToString();
            leftNumDenominator6Label.Text = number[10].Denominator.ToString();
            rightNumNumerator6Label.Text = number[11].Numerator.ToString();
            rightNumDenominator6Label.Text = number[11].Denominator.ToString(); 
        }

        private void SetOperatorsForLevel5()
        {
            operator1.Text = "+";
            operator2.Text = "+";
            operator3.Text = "+";
            operator4.Text = "-";
            operator5.Text = "-";
            operator6.Text = "-";
        }

        private void SetOperatorsForLevel6()
        {
            operator1.Text = "x";
            operator2.Text = "x";
            operator3.Text = "÷";
            operator4.Text = "÷";
            operator5.Text = "+";
            operator6.Text = "-";
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
                // If the user got the answer right, stop the timer  
                // and show a MessageBox.
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
                // Decrease the time left by one second and display  
                // the new time left by updating the Time Left label.
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // If the user ran out of time, stop the timer, show 
                // a MessageBox, and fill in the answers.
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
                case 5:
                    return ForLevel5();
                case 6:
                    return ForLevel6(); 
            }
            return false;
        }

        private bool ForLevel6()
        {
            FractionClass answer1 = number[0].Multiply(number[1]);
            FractionClass answer2 = number[2].Multiply(number[3]);
            FractionClass answer3 = number[4].Divide(number[5]);
            FractionClass answer4 = number[6].Divide(number[7]);
            FractionClass answer5 = number[8].Add(number[9]);
            FractionClass answer6 = number[10].Suubtract(number[11]);

            if (answer1.Equals(numeratorAnswer1.Value, denominatorAnswer1.Value) == true
                    && answer2.Equals(numeratorAnswer2.Value, denominatorAnswer2.Value) == true
                    && answer3.Equals(numeratorAnswer3.Value, denominatorAnswer3.Value) == true
                    && answer4.Equals(numeratorAnswer4.Value, denominatorAnswer4.Value) == true
                    && answer5.Equals(numeratorAnswer5.Value, denominatorAnswer5.Value) == true
                    && answer6.Equals(numeratorAnswer6.Value, denominatorAnswer6.Value) == true)
                return true;
            else
                return false;
        }

        private bool ForLevel5()
        {
            FractionClass answer1 = number[0].Add(number[1]);
            FractionClass answer2 = number[2].Add(number[3]);
            FractionClass answer3 = number[4].Add(number[5]); 
            FractionClass answer4 = number[6].Suubtract(number[7]);
            FractionClass answer5 = number[8].Suubtract(number[9]);
            FractionClass answer6 = number[10].Suubtract(number[11]);

            if (answer1.Equals(numeratorAnswer1.Value, denominatorAnswer1.Value) == true
                && answer2.Equals(numeratorAnswer2.Value, denominatorAnswer2.Value) == true
                && answer3.Equals(numeratorAnswer3.Value, denominatorAnswer3.Value) == true
                && answer4.Equals(numeratorAnswer4.Value, denominatorAnswer4.Value) == true
                && answer5.Equals(numeratorAnswer5.Value, denominatorAnswer5.Value) == true
                && answer6.Equals(numeratorAnswer6.Value, denominatorAnswer6.Value) == true
                )
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



    }
}
