namespace Optical
{
    partial class Dashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            container = new Panel();
            buttonCreate = new Button();
            label6 = new Label();
            label5 = new Label();
            panel2 = new Panel();
            button2 = new Button();
            panel1 = new Panel();
            dashboardContainer = new Panel();
            pictureBox4 = new PictureBox();
            labelUsersKey = new Label();
            labelUsersValue = new Label();
            pictureBox5 = new PictureBox();
            labelPrescriptionsKey = new Label();
            labelPrescriptionsValue = new Label();
            pictureBox3 = new PictureBox();
            labelEyeTestRecordsKey = new Label();
            labelEyeTestRecordsValue = new Label();
            pictureBox2 = new PictureBox();
            labelPatientsHistoryKey = new Label();
            labelPatientsHistoryValue = new Label();
            pictureBox1 = new PictureBox();
            labelPatientRecordsKey = new Label();
            labelPatientRecordsValue = new Label();
            button1 = new Button();
            container.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            dashboardContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // container
            // 
            container.BackColor = Color.FromArgb(215, 215, 215);
            container.Controls.Add(buttonCreate);
            container.Controls.Add(label6);
            container.Controls.Add(label5);
            container.Dock = DockStyle.Top;
            container.Location = new Point(0, 0);
            container.Margin = new Padding(4, 5, 4, 5);
            container.Name = "container";
            container.Size = new Size(1339, 342);
            container.TabIndex = 23;
            // 
            // buttonCreate
            // 
            buttonCreate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCreate.BackColor = Color.RoyalBlue;
            buttonCreate.FlatAppearance.BorderSize = 0;
            buttonCreate.FlatStyle = FlatStyle.Flat;
            buttonCreate.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCreate.ForeColor = Color.White;
            buttonCreate.Location = new Point(1879, 253);
            buttonCreate.Margin = new Padding(4, 5, 4, 5);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(314, 63);
            buttonCreate.TabIndex = 29;
            buttonCreate.Text = "Create Patient Record";
            buttonCreate.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.FromArgb(50, 50, 50);
            label6.Location = new Point(104, 122);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(927, 183);
            label6.TabIndex = 22;
            label6.Text = resources.GetString("label6.Text");
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(50, 50, 50);
            label5.Location = new Point(43, 45);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(483, 54);
            label5.TabIndex = 21;
            label5.Text = "-- AdOptix Dashboard --";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(button2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 342);
            panel2.Margin = new Padding(4, 5, 4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(1339, 67);
            panel2.TabIndex = 25;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.BackColor = Color.RoyalBlue;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(3633, 253);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(314, 63);
            button2.TabIndex = 29;
            button2.Text = "Create Patient Record";
            button2.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(215, 215, 215);
            panel1.Controls.Add(dashboardContainer);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 409);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1339, 471);
            panel1.TabIndex = 26;
            // 
            // dashboardContainer
            // 
            dashboardContainer.Controls.Add(pictureBox4);
            dashboardContainer.Controls.Add(labelUsersKey);
            dashboardContainer.Controls.Add(labelUsersValue);
            dashboardContainer.Controls.Add(pictureBox5);
            dashboardContainer.Controls.Add(labelPrescriptionsKey);
            dashboardContainer.Controls.Add(labelPrescriptionsValue);
            dashboardContainer.Controls.Add(pictureBox3);
            dashboardContainer.Controls.Add(labelEyeTestRecordsKey);
            dashboardContainer.Controls.Add(labelEyeTestRecordsValue);
            dashboardContainer.Controls.Add(pictureBox2);
            dashboardContainer.Controls.Add(labelPatientsHistoryKey);
            dashboardContainer.Controls.Add(labelPatientsHistoryValue);
            dashboardContainer.Controls.Add(pictureBox1);
            dashboardContainer.Controls.Add(labelPatientRecordsKey);
            dashboardContainer.Controls.Add(labelPatientRecordsValue);
            dashboardContainer.Location = new Point(64, 37);
            dashboardContainer.Margin = new Padding(4, 5, 4, 5);
            dashboardContainer.Name = "dashboardContainer";
            dashboardContainer.Size = new Size(1210, 397);
            dashboardContainer.TabIndex = 33;
            dashboardContainer.Paint += dashboardContainer_Paint;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.MediumSlateBlue;
            pictureBox4.Location = new Point(441, 340);
            pictureBox4.Margin = new Padding(4, 5, 4, 5);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(730, 12);
            pictureBox4.TabIndex = 62;
            pictureBox4.TabStop = false;
            // 
            // labelUsersKey
            // 
            labelUsersKey.AutoSize = true;
            labelUsersKey.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelUsersKey.ForeColor = SystemColors.WindowFrame;
            labelUsersKey.Location = new Point(543, 268);
            labelUsersKey.Margin = new Padding(4, 0, 4, 0);
            labelUsersKey.Name = "labelUsersKey";
            labelUsersKey.Size = new Size(192, 28);
            labelUsersKey.TabIndex = 61;
            labelUsersKey.Text = "ADMINISTRATOR(S)";
            // 
            // labelUsersValue
            // 
            labelUsersValue.AutoSize = true;
            labelUsersValue.Font = new Font("Segoe UI", 35F, FontStyle.Bold, GraphicsUnit.Point);
            labelUsersValue.ForeColor = Color.MediumSlateBlue;
            labelUsersValue.Location = new Point(441, 228);
            labelUsersValue.Margin = new Padding(4, 0, 4, 0);
            labelUsersValue.Name = "labelUsersValue";
            labelUsersValue.Size = new Size(120, 93);
            labelUsersValue.TabIndex = 60;
            labelUsersValue.Text = "13";
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.DodgerBlue;
            pictureBox5.Location = new Point(37, 340);
            pictureBox5.Margin = new Padding(4, 5, 4, 5);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(326, 12);
            pictureBox5.TabIndex = 59;
            pictureBox5.TabStop = false;
            // 
            // labelPrescriptionsKey
            // 
            labelPrescriptionsKey.AutoSize = true;
            labelPrescriptionsKey.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelPrescriptionsKey.ForeColor = SystemColors.WindowFrame;
            labelPrescriptionsKey.Location = new Point(139, 268);
            labelPrescriptionsKey.Margin = new Padding(4, 0, 4, 0);
            labelPrescriptionsKey.Name = "labelPrescriptionsKey";
            labelPrescriptionsKey.Size = new Size(171, 28);
            labelPrescriptionsKey.TabIndex = 58;
            labelPrescriptionsKey.Text = "PRESCRIPTION(S)";
            // 
            // labelPrescriptionsValue
            // 
            labelPrescriptionsValue.AutoSize = true;
            labelPrescriptionsValue.Font = new Font("Segoe UI", 35F, FontStyle.Bold, GraphicsUnit.Point);
            labelPrescriptionsValue.ForeColor = Color.DodgerBlue;
            labelPrescriptionsValue.Location = new Point(37, 228);
            labelPrescriptionsValue.Margin = new Padding(4, 0, 4, 0);
            labelPrescriptionsValue.Name = "labelPrescriptionsValue";
            labelPrescriptionsValue.Size = new Size(120, 93);
            labelPrescriptionsValue.TabIndex = 57;
            labelPrescriptionsValue.Text = "54";
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.DarkViolet;
            pictureBox3.Location = new Point(846, 162);
            pictureBox3.Margin = new Padding(4, 5, 4, 5);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(326, 12);
            pictureBox3.TabIndex = 56;
            pictureBox3.TabStop = false;
            // 
            // labelEyeTestRecordsKey
            // 
            labelEyeTestRecordsKey.AutoSize = true;
            labelEyeTestRecordsKey.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelEyeTestRecordsKey.ForeColor = SystemColors.WindowFrame;
            labelEyeTestRecordsKey.Location = new Point(947, 90);
            labelEyeTestRecordsKey.Margin = new Padding(4, 0, 4, 0);
            labelEyeTestRecordsKey.Name = "labelEyeTestRecordsKey";
            labelEyeTestRecordsKey.Size = new Size(118, 28);
            labelEyeTestRecordsKey.TabIndex = 55;
            labelEyeTestRecordsKey.Text = "EYE TEST(S)";
            // 
            // labelEyeTestRecordsValue
            // 
            labelEyeTestRecordsValue.AutoSize = true;
            labelEyeTestRecordsValue.Font = new Font("Segoe UI", 35F, FontStyle.Bold, GraphicsUnit.Point);
            labelEyeTestRecordsValue.ForeColor = Color.DarkViolet;
            labelEyeTestRecordsValue.Location = new Point(846, 50);
            labelEyeTestRecordsValue.Margin = new Padding(4, 0, 4, 0);
            labelEyeTestRecordsValue.Name = "labelEyeTestRecordsValue";
            labelEyeTestRecordsValue.Size = new Size(120, 93);
            labelEyeTestRecordsValue.TabIndex = 54;
            labelEyeTestRecordsValue.Text = "16";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.OrangeRed;
            pictureBox2.Location = new Point(441, 162);
            pictureBox2.Margin = new Padding(4, 5, 4, 5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(326, 12);
            pictureBox2.TabIndex = 53;
            pictureBox2.TabStop = false;
            // 
            // labelPatientsHistoryKey
            // 
            labelPatientsHistoryKey.AutoSize = true;
            labelPatientsHistoryKey.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelPatientsHistoryKey.ForeColor = SystemColors.WindowFrame;
            labelPatientsHistoryKey.Location = new Point(543, 90);
            labelPatientsHistoryKey.Margin = new Padding(4, 0, 4, 0);
            labelPatientsHistoryKey.Name = "labelPatientsHistoryKey";
            labelPatientsHistoryKey.Size = new Size(201, 28);
            labelPatientsHistoryKey.TabIndex = 52;
            labelPatientsHistoryKey.Text = "PATIENTS HISTORIES";
            // 
            // labelPatientsHistoryValue
            // 
            labelPatientsHistoryValue.AutoSize = true;
            labelPatientsHistoryValue.Font = new Font("Segoe UI", 35F, FontStyle.Bold, GraphicsUnit.Point);
            labelPatientsHistoryValue.ForeColor = Color.OrangeRed;
            labelPatientsHistoryValue.Location = new Point(441, 50);
            labelPatientsHistoryValue.Margin = new Padding(4, 0, 4, 0);
            labelPatientsHistoryValue.Name = "labelPatientsHistoryValue";
            labelPatientsHistoryValue.Size = new Size(120, 93);
            labelPatientsHistoryValue.TabIndex = 51;
            labelPatientsHistoryValue.Text = "43";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.RoyalBlue;
            pictureBox1.Location = new Point(39, 162);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(326, 12);
            pictureBox1.TabIndex = 50;
            pictureBox1.TabStop = false;
            // 
            // labelPatientRecordsKey
            // 
            labelPatientRecordsKey.AutoSize = true;
            labelPatientRecordsKey.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelPatientRecordsKey.ForeColor = SystemColors.WindowFrame;
            labelPatientRecordsKey.Location = new Point(140, 90);
            labelPatientRecordsKey.Margin = new Padding(4, 0, 4, 0);
            labelPatientRecordsKey.Name = "labelPatientRecordsKey";
            labelPatientRecordsKey.Size = new Size(113, 28);
            labelPatientRecordsKey.TabIndex = 49;
            labelPatientRecordsKey.Text = "PATIENT(S)";
            // 
            // labelPatientRecordsValue
            // 
            labelPatientRecordsValue.AutoSize = true;
            labelPatientRecordsValue.Font = new Font("Segoe UI", 35F, FontStyle.Bold, GraphicsUnit.Point);
            labelPatientRecordsValue.ForeColor = Color.RoyalBlue;
            labelPatientRecordsValue.Location = new Point(39, 50);
            labelPatientRecordsValue.Margin = new Padding(4, 0, 4, 0);
            labelPatientRecordsValue.Name = "labelPatientRecordsValue";
            labelPatientRecordsValue.Size = new Size(120, 93);
            labelPatientRecordsValue.TabIndex = 48;
            labelPatientRecordsValue.Text = "22";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.RoyalBlue;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(3833, 253);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(314, 63);
            button1.TabIndex = 29;
            button1.Text = "Create Patient Record";
            button1.UseVisualStyleBackColor = false;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(container);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Dashboard";
            Size = new Size(1339, 880);
            container.ResumeLayout(false);
            container.PerformLayout();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            dashboardContainer.ResumeLayout(false);
            dashboardContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel container;
        private Button buttonCreate;
        private Label label6;
        private Label label5;
        private Panel panel2;
        private Button button2;
        private Panel panel1;
        private Panel dashboardContainer;
        private PictureBox pictureBox4;
        private Label labelUsersKey;
        private Label labelUsersValue;
        private PictureBox pictureBox5;
        private Label labelPrescriptionsKey;
        private Label labelPrescriptionsValue;
        private PictureBox pictureBox3;
        private Label labelEyeTestRecordsKey;
        private Label labelEyeTestRecordsValue;
        private PictureBox pictureBox2;
        private Label labelPatientsHistoryKey;
        private Label labelPatientsHistoryValue;
        private PictureBox pictureBox1;
        private Label labelPatientRecordsKey;
        private Label labelPatientRecordsValue;
        private Button button1;
    }
}
