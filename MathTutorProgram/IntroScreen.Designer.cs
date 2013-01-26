namespace MathTutorProgram
{
    partial class IntroScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.newUserButton = new System.Windows.Forms.Button();
            this.existingUserButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(66, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 118);
            this.label1.TabIndex = 0;
            this.label1.Text = "Math Tutor Program";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // newUserButton
            // 
            this.newUserButton.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newUserButton.Location = new System.Drawing.Point(32, 180);
            this.newUserButton.Name = "newUserButton";
            this.newUserButton.Size = new System.Drawing.Size(115, 47);
            this.newUserButton.TabIndex = 1;
            this.newUserButton.Text = "New User";
            this.newUserButton.UseVisualStyleBackColor = true;
            this.newUserButton.Click += new System.EventHandler(this.newUserButton_Click);
            // 
            // existingUserButton
            // 
            this.existingUserButton.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.existingUserButton.Location = new System.Drawing.Point(178, 180);
            this.existingUserButton.Name = "existingUserButton";
            this.existingUserButton.Size = new System.Drawing.Size(116, 47);
            this.existingUserButton.TabIndex = 2;
            this.existingUserButton.Text = "Existing User";
            this.existingUserButton.UseVisualStyleBackColor = true;
            this.existingUserButton.Click += new System.EventHandler(this.existingUserButton_Click);
            // 
            // IntroScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 267);
            this.Controls.Add(this.existingUserButton);
            this.Controls.Add(this.newUserButton);
            this.Controls.Add(this.label1);
            this.Name = "IntroScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Math Tutor Program";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.mathTutorProgram_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button newUserButton;
        private System.Windows.Forms.Button existingUserButton;
    }
}

