namespace WindowsFormsUI.UserMainForm
{
    partial class UserForm
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
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.btnTimetableTeacher = new System.Windows.Forms.Button();
            this.timetableTeacherList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.teacherList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnShowTeachers = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.specialtyList = new System.Windows.Forms.ComboBox();
            this.btnShowPlan = new System.Windows.Forms.Button();
            this.preDataLoaderPanel = new System.Windows.Forms.Panel();
            this.preDataLoadStateText = new System.Windows.Forms.Label();
            this.preDataLoaderPictureBox = new System.Windows.Forms.PictureBox();
            this.btnShowView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupsList = new System.Windows.Forms.ComboBox();
            this.dataViewPanel = new System.Windows.Forms.Panel();
            this.dataLoadStatePanel = new System.Windows.Forms.Panel();
            this.loadingPictureBox = new System.Windows.Forms.PictureBox();
            this.dataLoadStateText = new System.Windows.Forms.Label();
            this.timetableGridView = new System.Windows.Forms.DataGridView();
            this.btnSaveAsPdf = new System.Windows.Forms.Button();
            this.settingsPanel.SuspendLayout();
            this.preDataLoaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.preDataLoaderPictureBox)).BeginInit();
            this.dataViewPanel.SuspendLayout();
            this.dataLoadStatePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsPanel
            // 
            this.settingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.settingsPanel.Controls.Add(this.btnSaveAsPdf);
            this.settingsPanel.Controls.Add(this.btnTimetableTeacher);
            this.settingsPanel.Controls.Add(this.timetableTeacherList);
            this.settingsPanel.Controls.Add(this.label4);
            this.settingsPanel.Controls.Add(this.teacherList);
            this.settingsPanel.Controls.Add(this.label3);
            this.settingsPanel.Controls.Add(this.btnShowTeachers);
            this.settingsPanel.Controls.Add(this.label2);
            this.settingsPanel.Controls.Add(this.specialtyList);
            this.settingsPanel.Controls.Add(this.btnShowPlan);
            this.settingsPanel.Controls.Add(this.preDataLoaderPanel);
            this.settingsPanel.Controls.Add(this.btnShowView);
            this.settingsPanel.Controls.Add(this.label1);
            this.settingsPanel.Controls.Add(this.groupsList);
            this.settingsPanel.Location = new System.Drawing.Point(20, 15);
            this.settingsPanel.Margin = new System.Windows.Forms.Padding(11);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Padding = new System.Windows.Forms.Padding(11);
            this.settingsPanel.Size = new System.Drawing.Size(205, 673);
            this.settingsPanel.TabIndex = 0;
            // 
            // btnTimetableTeacher
            // 
            this.btnTimetableTeacher.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnTimetableTeacher.Enabled = false;
            this.btnTimetableTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimetableTeacher.ForeColor = System.Drawing.Color.White;
            this.btnTimetableTeacher.Location = new System.Drawing.Point(7, 433);
            this.btnTimetableTeacher.Name = "btnTimetableTeacher";
            this.btnTimetableTeacher.Size = new System.Drawing.Size(175, 44);
            this.btnTimetableTeacher.TabIndex = 12;
            this.btnTimetableTeacher.Text = "Вывести расписание преподавателя";
            this.btnTimetableTeacher.UseVisualStyleBackColor = false;
            // 
            // timetableTeacherList
            // 
            this.timetableTeacherList.FormattingEnabled = true;
            this.timetableTeacherList.Location = new System.Drawing.Point(7, 400);
            this.timetableTeacherList.Name = "timetableTeacherList";
            this.timetableTeacherList.Size = new System.Drawing.Size(175, 25);
            this.timetableTeacherList.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 356);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 41);
            this.label4.TabIndex = 10;
            this.label4.Text = "Выберите преподавателя:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // teacherList
            // 
            this.teacherList.FormattingEnabled = true;
            this.teacherList.Items.AddRange(new object[] {
            "Все преподаватели"});
            this.teacherList.Location = new System.Drawing.Point(7, 260);
            this.teacherList.Name = "teacherList";
            this.teacherList.Size = new System.Drawing.Size(175, 25);
            this.teacherList.TabIndex = 9;
            this.teacherList.Text = "Все преподаватели";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 34);
            this.label3.TabIndex = 8;
            this.label3.Text = "Выберите преподавателя:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnShowTeachers
            // 
            this.btnShowTeachers.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnShowTeachers.Enabled = false;
            this.btnShowTeachers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowTeachers.ForeColor = System.Drawing.Color.White;
            this.btnShowTeachers.Location = new System.Drawing.Point(7, 297);
            this.btnShowTeachers.Name = "btnShowTeachers";
            this.btnShowTeachers.Size = new System.Drawing.Size(176, 44);
            this.btnShowTeachers.TabIndex = 7;
            this.btnShowTeachers.Text = "Вывести информацию о преподавателе";
            this.btnShowTeachers.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 37);
            this.label2.TabIndex = 6;
            this.label2.Text = "Выберите специальность:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // specialtyList
            // 
            this.specialtyList.FormattingEnabled = true;
            this.specialtyList.Location = new System.Drawing.Point(7, 144);
            this.specialtyList.Name = "specialtyList";
            this.specialtyList.Size = new System.Drawing.Size(175, 25);
            this.specialtyList.TabIndex = 0;
            // 
            // btnShowPlan
            // 
            this.btnShowPlan.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnShowPlan.Enabled = false;
            this.btnShowPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPlan.ForeColor = System.Drawing.Color.White;
            this.btnShowPlan.Location = new System.Drawing.Point(7, 177);
            this.btnShowPlan.Name = "btnShowPlan";
            this.btnShowPlan.Size = new System.Drawing.Size(176, 34);
            this.btnShowPlan.TabIndex = 3;
            this.btnShowPlan.Text = "Вывести план";
            this.btnShowPlan.UseVisualStyleBackColor = false;
            // 
            // preDataLoaderPanel
            // 
            this.preDataLoaderPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.preDataLoaderPanel.Controls.Add(this.preDataLoadStateText);
            this.preDataLoaderPanel.Controls.Add(this.preDataLoaderPictureBox);
            this.preDataLoaderPanel.Location = new System.Drawing.Point(7, 565);
            this.preDataLoaderPanel.Name = "preDataLoaderPanel";
            this.preDataLoaderPanel.Size = new System.Drawing.Size(176, 108);
            this.preDataLoaderPanel.TabIndex = 5;
            this.preDataLoaderPanel.Visible = false;
            // 
            // preDataLoadStateText
            // 
            this.preDataLoadStateText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.preDataLoadStateText.Location = new System.Drawing.Point(0, 16);
            this.preDataLoadStateText.Name = "preDataLoadStateText";
            this.preDataLoadStateText.Size = new System.Drawing.Size(176, 48);
            this.preDataLoadStateText.TabIndex = 2;
            this.preDataLoadStateText.Text = "Загружаем необходимые данные...";
            this.preDataLoadStateText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // preDataLoaderPictureBox
            // 
            this.preDataLoaderPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.preDataLoaderPictureBox.Location = new System.Drawing.Point(67, 67);
            this.preDataLoaderPictureBox.Name = "preDataLoaderPictureBox";
            this.preDataLoaderPictureBox.Size = new System.Drawing.Size(37, 36);
            this.preDataLoaderPictureBox.TabIndex = 4;
            this.preDataLoaderPictureBox.TabStop = false;
            // 
            // btnShowView
            // 
            this.btnShowView.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnShowView.Enabled = false;
            this.btnShowView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowView.ForeColor = System.Drawing.Color.White;
            this.btnShowView.Location = new System.Drawing.Point(7, 62);
            this.btnShowView.Name = "btnShowView";
            this.btnShowView.Size = new System.Drawing.Size(176, 34);
            this.btnShowView.TabIndex = 3;
            this.btnShowView.Text = "Вывести расписание";
            this.btnShowView.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите группу:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupsList
            // 
            this.groupsList.FormattingEnabled = true;
            this.groupsList.Items.AddRange(new object[] {
            "Все группы"});
            this.groupsList.Location = new System.Drawing.Point(7, 29);
            this.groupsList.Name = "groupsList";
            this.groupsList.Size = new System.Drawing.Size(175, 25);
            this.groupsList.TabIndex = 0;
            this.groupsList.Text = "Все группы";
            // 
            // dataViewPanel
            // 
            this.dataViewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataViewPanel.Controls.Add(this.dataLoadStatePanel);
            this.dataViewPanel.Controls.Add(this.timetableGridView);
            this.dataViewPanel.Location = new System.Drawing.Point(234, 15);
            this.dataViewPanel.Name = "dataViewPanel";
            this.dataViewPanel.Size = new System.Drawing.Size(706, 673);
            this.dataViewPanel.TabIndex = 0;
            // 
            // dataLoadStatePanel
            // 
            this.dataLoadStatePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataLoadStatePanel.BackColor = System.Drawing.Color.White;
            this.dataLoadStatePanel.Controls.Add(this.loadingPictureBox);
            this.dataLoadStatePanel.Controls.Add(this.dataLoadStateText);
            this.dataLoadStatePanel.Location = new System.Drawing.Point(257, 260);
            this.dataLoadStatePanel.Name = "dataLoadStatePanel";
            this.dataLoadStatePanel.Size = new System.Drawing.Size(229, 136);
            this.dataLoadStatePanel.TabIndex = 1;
            this.dataLoadStatePanel.Visible = false;
            // 
            // loadingPictureBox
            // 
            this.loadingPictureBox.BackColor = System.Drawing.Color.White;
            this.loadingPictureBox.Location = new System.Drawing.Point(57, 43);
            this.loadingPictureBox.Name = "loadingPictureBox";
            this.loadingPictureBox.Size = new System.Drawing.Size(114, 82);
            this.loadingPictureBox.TabIndex = 1;
            this.loadingPictureBox.TabStop = false;
            // 
            // dataLoadStateText
            // 
            this.dataLoadStateText.Location = new System.Drawing.Point(2, 14);
            this.dataLoadStateText.Name = "dataLoadStateText";
            this.dataLoadStateText.Size = new System.Drawing.Size(223, 26);
            this.dataLoadStateText.TabIndex = 0;
            this.dataLoadStateText.Text = "Загрузка данных...";
            this.dataLoadStateText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timetableGridView
            // 
            this.timetableGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timetableGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.timetableGridView.Location = new System.Drawing.Point(0, 0);
            this.timetableGridView.Name = "timetableGridView";
            this.timetableGridView.Size = new System.Drawing.Size(706, 673);
            this.timetableGridView.TabIndex = 0;
            this.timetableGridView.Text = "dataGridView1";
            this.timetableGridView.Visible = false;
            // 
            // btnSaveAsPdf
            // 
            this.btnSaveAsPdf.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSaveAsPdf.Enabled = false;
            this.btnSaveAsPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAsPdf.ForeColor = System.Drawing.Color.White;
            this.btnSaveAsPdf.Location = new System.Drawing.Point(8, 497);
            this.btnSaveAsPdf.Name = "btnSaveAsPdf";
            this.btnSaveAsPdf.Size = new System.Drawing.Size(175, 44);
            this.btnSaveAsPdf.TabIndex = 13;
            this.btnSaveAsPdf.Text = "Сохранить таблицу в PDF";
            this.btnSaveAsPdf.UseVisualStyleBackColor = false;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(952, 700);
            this.Controls.Add(this.dataViewPanel);
            this.Controls.Add(this.settingsPanel);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserForm";
            this.settingsPanel.ResumeLayout(false);
            this.preDataLoaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.preDataLoaderPictureBox)).EndInit();
            this.dataViewPanel.ResumeLayout(false);
            this.dataLoadStatePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timetableGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.Panel dataViewPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox groupsList;
        private System.Windows.Forms.Label preDataLoadStateText;
        private System.Windows.Forms.Button btnShowView;
        private System.Windows.Forms.DataGridView timetableGridView;
        private System.Windows.Forms.Panel dataLoadStatePanel;
        private System.Windows.Forms.Label dataLoadStateText;
        private System.Windows.Forms.PictureBox loadingPictureBox;
        private System.Windows.Forms.PictureBox preDataLoaderPictureBox;
        private System.Windows.Forms.Panel preDataLoaderPanel;
        private System.Windows.Forms.ComboBox specialtyList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnShowPlan;
        private System.Windows.Forms.Button btnShowTeachers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox teacherList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTimetableTeacher;
        private System.Windows.Forms.ComboBox timetableTeacherList;
        private System.Windows.Forms.Button btnSaveAsPdf;
    }
}