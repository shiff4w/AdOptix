﻿namespace Optical
{
    partial class EyeTestProcess
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
            pictureBoxProcess = new PictureBox();
            buttonProceed = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProcess).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxProcess
            // 
            pictureBoxProcess.Location = new Point(156, 107);
            pictureBoxProcess.Margin = new Padding(4, 5, 4, 5);
            pictureBoxProcess.Name = "pictureBoxProcess";
            pictureBoxProcess.Size = new Size(214, 250);
            pictureBoxProcess.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxProcess.TabIndex = 31;
            pictureBoxProcess.TabStop = false;
            // 
            // buttonProceed
            // 
            buttonProceed.BackColor = Color.RoyalBlue;
            buttonProceed.FlatAppearance.BorderSize = 0;
            buttonProceed.FlatStyle = FlatStyle.Flat;
            buttonProceed.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            buttonProceed.ForeColor = Color.White;
            buttonProceed.Location = new Point(93, 652);
            buttonProceed.Margin = new Padding(4, 5, 4, 5);
            buttonProceed.Name = "buttonProceed";
            buttonProceed.Size = new Size(340, 63);
            buttonProceed.TabIndex = 32;
            buttonProceed.Text = "Proceed to prescription";
            buttonProceed.UseVisualStyleBackColor = false;
            // 
            // EyeTestProcess
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(526, 797);
            Controls.Add(buttonProceed);
            Controls.Add(pictureBoxProcess);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "EyeTestProcess";
            StartPosition = FormStartPosition.CenterScreen;
            Load += EyeTestProcess_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxProcess).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxProcess;
        private Button buttonProceed;
    }
}