namespace WindowsFormsUI.AdminMainForm
{
    partial class AdminForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.timetableCreationTab = new System.Windows.Forms.TabPage();
            this.subjectsTeachersTab = new System.Windows.Forms.TabPage();
            this.groupsSpecialtiesTab = new System.Windows.Forms.TabPage();
            this.planTab = new System.Windows.Forms.TabPage();
            this.timetableLogLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.timetableCreationTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabControl1.Controls.Add(this.timetableCreationTab);
            this.tabControl1.Controls.Add(this.subjectsTeachersTab);
            this.tabControl1.Controls.Add(this.groupsSpecialtiesTab);
            this.tabControl1.Controls.Add(this.planTab);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(768, 432);
            this.tabControl1.TabIndex = 0;
            // 
            // timetableCreationTab
            // 
            this.timetableCreationTab.Controls.Add(this.button1);
            this.timetableCreationTab.Controls.Add(this.timetableLogLabel);
            this.timetableCreationTab.Location = new System.Drawing.Point(4, 24);
            this.timetableCreationTab.Name = "timetableCreationTab";
            this.timetableCreationTab.Padding = new System.Windows.Forms.Padding(3);
            this.timetableCreationTab.Size = new System.Drawing.Size(760, 404);
            this.timetableCreationTab.TabIndex = 0;
            this.timetableCreationTab.Text = "Создание расписания";
            this.timetableCreationTab.UseVisualStyleBackColor = true;
            // 
            // subjectsTeachersTab
            // 
            this.subjectsTeachersTab.Location = new System.Drawing.Point(4, 24);
            this.subjectsTeachersTab.Name = "subjectsTeachersTab";
            this.subjectsTeachersTab.Padding = new System.Windows.Forms.Padding(3);
            this.subjectsTeachersTab.Size = new System.Drawing.Size(760, 404);
            this.subjectsTeachersTab.TabIndex = 1;
            this.subjectsTeachersTab.Text = "Предметы и преподаватели";
            this.subjectsTeachersTab.UseVisualStyleBackColor = true;
            // 
            // groupsSpecialtiesTab
            // 
            this.groupsSpecialtiesTab.BackColor = System.Drawing.Color.White;
            this.groupsSpecialtiesTab.Location = new System.Drawing.Point(4, 24);
            this.groupsSpecialtiesTab.Name = "groupsSpecialtiesTab";
            this.groupsSpecialtiesTab.Size = new System.Drawing.Size(760, 404);
            this.groupsSpecialtiesTab.TabIndex = 2;
            this.groupsSpecialtiesTab.Text = "Специальности и группы";
            // 
            // planTab
            // 
            this.planTab.BackColor = System.Drawing.Color.White;
            this.planTab.Location = new System.Drawing.Point(4, 24);
            this.planTab.Name = "planTab";
            this.planTab.Size = new System.Drawing.Size(760, 404);
            this.planTab.TabIndex = 3;
            this.planTab.Text = "Учебный план";
            // 
            // timetableLogLabel
            // 
            this.timetableLogLabel.Location = new System.Drawing.Point(3, 378);
            this.timetableLogLabel.Name = "timetableLogLabel";
            this.timetableLogLabel.Size = new System.Drawing.Size(458, 23);
            this.timetableLogLabel.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Создать";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 457);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.tabControl1.ResumeLayout(false);
            this.timetableCreationTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage timetableCreationTab;
        private System.Windows.Forms.TabPage subjectsTeachersTab;
        private System.Windows.Forms.TabPage groupsSpecialtiesTab;
        private System.Windows.Forms.TabPage planTab;
        private System.Windows.Forms.Label timetableLogLabel;
        private System.Windows.Forms.Button button1;
    }
}