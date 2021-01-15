namespace Smocktest
{
    partial class Form1
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
            this.Start_Test = new System.Windows.Forms.Button();
            this.Environment = new System.Windows.Forms.Label();
            this.Server_Name = new System.Windows.Forms.TextBox();
            this.Individual_ID_lable = new System.Windows.Forms.Label();
            this.Individual_ID = new System.Windows.Forms.TextBox();
            this.NewApp = new System.Windows.Forms.RadioButton();
            this.AppReview = new System.Windows.Forms.RadioButton();
            this.Capreview = new System.Windows.Forms.RadioButton();
            this.Assessments_assin = new System.Windows.Forms.RadioButton();
            this.AssessmentTask = new System.Windows.Forms.RadioButton();
            this.AssessmentsReview = new System.Windows.Forms.RadioButton();
            this.ProgramCode_lable = new System.Windows.Forms.Label();
            this.ProgramCodeSelection = new System.Windows.Forms.ListBox();
            this.Create_Incident_Report = new System.Windows.Forms.RadioButton();
            this.Create_Risk_Mitigation_Report = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // Start_Test
            // 
            this.Start_Test.Location = new System.Drawing.Point(331, 460);
            this.Start_Test.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Start_Test.Name = "Start_Test";
            this.Start_Test.Size = new System.Drawing.Size(147, 42);
            this.Start_Test.TabIndex = 2;
            this.Start_Test.Text = "Start Test";
            this.Start_Test.UseVisualStyleBackColor = true;
            this.Start_Test.Click += new System.EventHandler(this.button1_Click);
            // 
            // Environment
            // 
            this.Environment.AutoSize = true;
            this.Environment.Location = new System.Drawing.Point(189, 35);
            this.Environment.Name = "Environment";
            this.Environment.Size = new System.Drawing.Size(98, 20);
            this.Environment.TabIndex = 3;
            this.Environment.Text = "Environment";
            this.Environment.Click += new System.EventHandler(this.Environment_Click);
            // 
            // Server_Name
            // 
            this.Server_Name.Location = new System.Drawing.Point(300, 35);
            this.Server_Name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Server_Name.Name = "Server_Name";
            this.Server_Name.Size = new System.Drawing.Size(196, 26);
            this.Server_Name.TabIndex = 4;
            this.Server_Name.TextChanged += new System.EventHandler(this.Server_Name_TextChanged);
            // 
            // Individual_ID_lable
            // 
            this.Individual_ID_lable.AutoSize = true;
            this.Individual_ID_lable.Location = new System.Drawing.Point(189, 85);
            this.Individual_ID_lable.Name = "Individual_ID_lable";
            this.Individual_ID_lable.Size = new System.Drawing.Size(100, 20);
            this.Individual_ID_lable.TabIndex = 5;
            this.Individual_ID_lable.Text = "Individual ID ";
            this.Individual_ID_lable.Click += new System.EventHandler(this.Individual_ID_lable_Click);
            // 
            // Individual_ID
            // 
            this.Individual_ID.Location = new System.Drawing.Point(300, 85);
            this.Individual_ID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Individual_ID.Name = "Individual_ID";
            this.Individual_ID.Size = new System.Drawing.Size(196, 26);
            this.Individual_ID.TabIndex = 6;
            this.Individual_ID.TextChanged += new System.EventHandler(this.Individual_ID_TextChanged);
            // 
            // NewApp
            // 
            this.NewApp.AutoSize = true;
            this.NewApp.Location = new System.Drawing.Point(18, 195);
            this.NewApp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NewApp.Name = "NewApp";
            this.NewApp.Size = new System.Drawing.Size(151, 24);
            this.NewApp.TabIndex = 7;
            this.NewApp.TabStop = true;
            this.NewApp.Text = "New Application ";
            this.NewApp.UseVisualStyleBackColor = true;
            this.NewApp.CheckedChanged += new System.EventHandler(this.NewApp_CheckedChanged);
            // 
            // AppReview
            // 
            this.AppReview.AutoSize = true;
            this.AppReview.Location = new System.Drawing.Point(184, 195);
            this.AppReview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AppReview.Name = "AppReview";
            this.AppReview.Size = new System.Drawing.Size(231, 24);
            this.AppReview.TabIndex = 8;
            this.AppReview.TabStop = true;
            this.AppReview.Text = "Resume Application Review";
            this.AppReview.UseVisualStyleBackColor = true;
            this.AppReview.CheckedChanged += new System.EventHandler(this.AppReview_CheckedChanged);
            // 
            // Capreview
            // 
            this.Capreview.AutoSize = true;
            this.Capreview.Location = new System.Drawing.Point(431, 195);
            this.Capreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Capreview.Name = "Capreview";
            this.Capreview.Size = new System.Drawing.Size(214, 24);
            this.Capreview.TabIndex = 9;
            this.Capreview.TabStop = true;
            this.Capreview.Text = "Resume Capacity Review";
            this.Capreview.UseVisualStyleBackColor = true;
            this.Capreview.CheckedChanged += new System.EventHandler(this.Capreview_CheckedChanged);
            // 
            // Assessments_assin
            // 
            this.Assessments_assin.AutoSize = true;
            this.Assessments_assin.Location = new System.Drawing.Point(18, 261);
            this.Assessments_assin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Assessments_assin.Name = "Assessments_assin";
            this.Assessments_assin.Size = new System.Drawing.Size(163, 24);
            this.Assessments_assin.TabIndex = 10;
            this.Assessments_assin.TabStop = true;
            this.Assessments_assin.Text = "Assessments new";
            this.Assessments_assin.UseVisualStyleBackColor = true;
            this.Assessments_assin.CheckedChanged += new System.EventHandler(this.Assessments_assin_CheckedChanged);
            // 
            // AssessmentTask
            // 
            this.AssessmentTask.AutoSize = true;
            this.AssessmentTask.Location = new System.Drawing.Point(184, 261);
            this.AssessmentTask.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AssessmentTask.Name = "AssessmentTask";
            this.AssessmentTask.Size = new System.Drawing.Size(198, 24);
            this.AssessmentTask.TabIndex = 11;
            this.AssessmentTask.TabStop = true;
            this.AssessmentTask.Text = "Resume Assessments ";
            this.AssessmentTask.UseVisualStyleBackColor = true;
            this.AssessmentTask.CheckedChanged += new System.EventHandler(this.AssessmentTask_CheckedChanged);
            // 
            // AssessmentsReview
            // 
            this.AssessmentsReview.AutoSize = true;
            this.AssessmentsReview.Location = new System.Drawing.Point(390, 261);
            this.AssessmentsReview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AssessmentsReview.Name = "AssessmentsReview";
            this.AssessmentsReview.Size = new System.Drawing.Size(185, 24);
            this.AssessmentsReview.TabIndex = 12;
            this.AssessmentsReview.TabStop = true;
            this.AssessmentsReview.Text = "Assessments Review";
            this.AssessmentsReview.UseVisualStyleBackColor = true;
            this.AssessmentsReview.CheckedChanged += new System.EventHandler(this.AssessmentsReview_CheckedChanged);
            // 
            // ProgramCode_lable
            // 
            this.ProgramCode_lable.AutoSize = true;
            this.ProgramCode_lable.Location = new System.Drawing.Point(188, 142);
            this.ProgramCode_lable.Name = "ProgramCode_lable";
            this.ProgramCode_lable.Size = new System.Drawing.Size(111, 20);
            this.ProgramCode_lable.TabIndex = 13;
            this.ProgramCode_lable.Text = "Program Code";
            // 
            // ProgramCodeSelection
            // 
            this.ProgramCodeSelection.FormattingEnabled = true;
            this.ProgramCodeSelection.ItemHeight = 20;
            this.ProgramCodeSelection.Items.AddRange(new object[] {
            "MPW",
            "SCL",
            "MII",
            "ABI",
            "HCB",
            "ABI-Acute"});
            this.ProgramCodeSelection.Location = new System.Drawing.Point(300, 142);
            this.ProgramCodeSelection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProgramCodeSelection.Name = "ProgramCodeSelection";
            this.ProgramCodeSelection.ScrollAlwaysVisible = true;
            this.ProgramCodeSelection.Size = new System.Drawing.Size(190, 24);
            this.ProgramCodeSelection.TabIndex = 14;
            this.ProgramCodeSelection.SelectedIndexChanged += new System.EventHandler(this.ProgramCodeSelection_SelectedIndexChanged);
            // 
            // Create_Incident_Report
            // 
            this.Create_Incident_Report.AutoSize = true;
            this.Create_Incident_Report.Location = new System.Drawing.Point(18, 333);
            this.Create_Incident_Report.Name = "Create_Incident_Report";
            this.Create_Incident_Report.Size = new System.Drawing.Size(196, 24);
            this.Create_Incident_Report.TabIndex = 16;
            this.Create_Incident_Report.TabStop = true;
            this.Create_Incident_Report.Text = "Create Incident Report";
            this.Create_Incident_Report.UseVisualStyleBackColor = true;
            // 
            // Create_Risk_Mitigation_Report
            // 
            this.Create_Risk_Mitigation_Report.AutoSize = true;
            this.Create_Risk_Mitigation_Report.Enabled = false;
            this.Create_Risk_Mitigation_Report.Location = new System.Drawing.Point(300, 333);
            this.Create_Risk_Mitigation_Report.Name = "Create_Risk_Mitigation_Report";
            this.Create_Risk_Mitigation_Report.Size = new System.Drawing.Size(242, 24);
            this.Create_Risk_Mitigation_Report.TabIndex = 17;
            this.Create_Risk_Mitigation_Report.TabStop = true;
            this.Create_Risk_Mitigation_Report.Text = "Create Risk Mitigation Report";
            this.Create_Risk_Mitigation_Report.UseVisualStyleBackColor = true;
            this.Create_Risk_Mitigation_Report.CheckedChanged += new System.EventHandler(this.Create_RiskMitigation_Report_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(879, 554);
            this.Controls.Add(this.Create_Risk_Mitigation_Report);
            this.Controls.Add(this.Create_Incident_Report);
            this.Controls.Add(this.ProgramCodeSelection);
            this.Controls.Add(this.ProgramCode_lable);
            this.Controls.Add(this.AssessmentsReview);
            this.Controls.Add(this.AssessmentTask);
            this.Controls.Add(this.Assessments_assin);
            this.Controls.Add(this.Capreview);
            this.Controls.Add(this.AppReview);
            this.Controls.Add(this.NewApp);
            this.Controls.Add(this.Individual_ID);
            this.Controls.Add(this.Individual_ID_lable);
            this.Controls.Add(this.Server_Name);
            this.Controls.Add(this.Environment);
            this.Controls.Add(this.Start_Test);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Smoke Test_Dev";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Start_Test;
        private System.Windows.Forms.Label Environment;
        private System.Windows.Forms.TextBox Server_Name;
        private System.Windows.Forms.Label Individual_ID_lable;
        private System.Windows.Forms.TextBox Individual_ID;
        private System.Windows.Forms.RadioButton NewApp;
        private System.Windows.Forms.RadioButton AppReview;
        private System.Windows.Forms.RadioButton Capreview;
        private System.Windows.Forms.RadioButton Assessments_assin;
        private System.Windows.Forms.RadioButton AssessmentTask;
        private System.Windows.Forms.RadioButton AssessmentsReview;
        private System.Windows.Forms.Label ProgramCode_lable;
        private System.Windows.Forms.ListBox ProgramCodeSelection;
        private System.Windows.Forms.RadioButton Create_Incident_Report;
        private System.Windows.Forms.RadioButton Create_Risk_Mitigation_Report;
    }
}

