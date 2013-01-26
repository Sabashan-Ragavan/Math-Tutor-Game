using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MathTutorProgram
{
    public partial class IntroScreen : Form
    {
        public IntroScreen()
        {
            InitializeComponent();
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {
            using (NewUserForm nUserForm = new NewUserForm())
            {
                this.Hide();     // hides current
                nUserForm.ShowDialog();
                this.Close(); 
            }
            
        }

        private void existingUserButton_Click(object sender, EventArgs e)
        {
            using (ExistingUser eUser = new ExistingUser())
            {
                this.Hide();     // hides current
                eUser.ShowDialog();
                this.Close(); 
            }
        }

        private void mathTutorProgram_Load(object sender, EventArgs e)
        {

        }

    }
}
