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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveToDatabase = new System.Windows.Forms.Button();
            this.btnTimetableTrain = new System.Windows.Forms.Button();
            this.panelTimetableCreationLog = new System.Windows.Forms.Panel();
            this.lblSolverLog = new System.Windows.Forms.Label();
            this.rbxTimetableResultLog = new System.Windows.Forms.RichTextBox();
            this.btnCancelTimetableCreation = new System.Windows.Forms.Button();
            this.btnShowUserForm = new System.Windows.Forms.Button();
            this.btnCreateTimetable = new System.Windows.Forms.Button();
            this.groupBoxAlgorithmSettings = new System.Windows.Forms.GroupBox();
            this.numericTrainCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numericPopulationCount = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericPartOfBest = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericIterationsCount = new System.Windows.Forms.NumericUpDown();
            this.checkBoxDefaultSettings = new System.Windows.Forms.CheckBox();
            this.groupBoxTimetableSettings = new System.Windows.Forms.GroupBox();
            this.numericSemesterPart = new System.Windows.Forms.NumericUpDown();
            this.numericHoursDay = new System.Windows.Forms.NumericUpDown();
            this.numericDaysWeek = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.subjectsTeachersTab = new System.Windows.Forms.TabPage();
            this.groupsSpecialtiesTab = new System.Windows.Forms.TabPage();
            this.planTab = new System.Windows.Forms.TabPage();
            this.pictureBoxTimetableCreation = new System.Windows.Forms.PictureBox();
            this.databaseTab = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.timetableCreationTab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelTimetableCreationLog.SuspendLayout();
            this.groupBoxAlgorithmSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTrainCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPopulationCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPartOfBest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIterationsCount)).BeginInit();
            this.groupBoxTimetableSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSemesterPart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHoursDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDaysWeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTimetableCreation)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.databaseTab);
            this.tabControl1.Controls.Add(this.timetableCreationTab);
            this.tabControl1.Controls.Add(this.subjectsTeachersTab);
            this.tabControl1.Controls.Add(this.groupsSpecialtiesTab);
            this.tabControl1.Controls.Add(this.planTab);
            this.tabControl1.Location = new System.Drawing.Point(10, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(716, 406);
            this.tabControl1.TabIndex = 0;
            // 
            // timetableCreationTab
            // 
            this.timetableCreationTab.Controls.Add(this.groupBox2);
            this.timetableCreationTab.Controls.Add(this.groupBoxAlgorithmSettings);
            this.timetableCreationTab.Controls.Add(this.checkBoxDefaultSettings);
            this.timetableCreationTab.Controls.Add(this.groupBoxTimetableSettings);
            this.timetableCreationTab.Location = new System.Drawing.Point(4, 24);
            this.timetableCreationTab.Name = "timetableCreationTab";
            this.timetableCreationTab.Padding = new System.Windows.Forms.Padding(3);
            this.timetableCreationTab.Size = new System.Drawing.Size(708, 378);
            this.timetableCreationTab.TabIndex = 0;
            this.timetableCreationTab.Text = "Создание расписания";
            this.timetableCreationTab.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.pictureBoxTimetableCreation);
            this.groupBox2.Controls.Add(this.btnSaveToDatabase);
            this.groupBox2.Controls.Add(this.btnTimetableTrain);
            this.groupBox2.Controls.Add(this.panelTimetableCreationLog);
            this.groupBox2.Controls.Add(this.btnCancelTimetableCreation);
            this.groupBox2.Controls.Add(this.btnShowUserForm);
            this.groupBox2.Controls.Add(this.btnCreateTimetable);
            this.groupBox2.Location = new System.Drawing.Point(235, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 325);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Создание расписания";
            // 
            // btnSaveToDatabase
            // 
            this.btnSaveToDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveToDatabase.Location = new System.Drawing.Point(139, 279);
            this.btnSaveToDatabase.Name = "btnSaveToDatabase";
            this.btnSaveToDatabase.Size = new System.Drawing.Size(120, 40);
            this.btnSaveToDatabase.TabIndex = 9;
            this.btnSaveToDatabase.Text = "Сохранить в базу данных";
            this.btnSaveToDatabase.UseVisualStyleBackColor = true;
            // 
            // btnTimetableTrain
            // 
            this.btnTimetableTrain.Location = new System.Drawing.Point(119, 22);
            this.btnTimetableTrain.Name = "btnTimetableTrain";
            this.btnTimetableTrain.Size = new System.Drawing.Size(100, 35);
            this.btnTimetableTrain.TabIndex = 8;
            this.btnTimetableTrain.Text = "Тренировать";
            this.btnTimetableTrain.UseVisualStyleBackColor = true;
            // 
            // panelTimetableCreationLog
            // 
            this.panelTimetableCreationLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTimetableCreationLog.Controls.Add(this.lblSolverLog);
            this.panelTimetableCreationLog.Controls.Add(this.rbxTimetableResultLog);
            this.panelTimetableCreationLog.Location = new System.Drawing.Point(6, 62);
            this.panelTimetableCreationLog.Name = "panelTimetableCreationLog";
            this.panelTimetableCreationLog.Padding = new System.Windows.Forms.Padding(3);
            this.panelTimetableCreationLog.Size = new System.Drawing.Size(458, 211);
            this.panelTimetableCreationLog.TabIndex = 7;
            // 
            // lblSolverLog
            // 
            this.lblSolverLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSolverLog.Location = new System.Drawing.Point(7, 181);
            this.lblSolverLog.Name = "lblSolverLog";
            this.lblSolverLog.Size = new System.Drawing.Size(442, 22);
            this.lblSolverLog.TabIndex = 9;
            // 
            // rbxTimetableResultLog
            // 
            this.rbxTimetableResultLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbxTimetableResultLog.Location = new System.Drawing.Point(7, 6);
            this.rbxTimetableResultLog.Name = "rbxTimetableResultLog";
            this.rbxTimetableResultLog.Size = new System.Drawing.Size(408, 172);
            this.rbxTimetableResultLog.TabIndex = 8;
            this.rbxTimetableResultLog.Text = "";
            // 
            // btnCancelTimetableCreation
            // 
            this.btnCancelTimetableCreation.Location = new System.Drawing.Point(225, 22);
            this.btnCancelTimetableCreation.Name = "btnCancelTimetableCreation";
            this.btnCancelTimetableCreation.Size = new System.Drawing.Size(100, 35);
            this.btnCancelTimetableCreation.TabIndex = 5;
            this.btnCancelTimetableCreation.Text = "Отмена";
            this.btnCancelTimetableCreation.UseVisualStyleBackColor = true;
            // 
            // btnShowUserForm
            // 
            this.btnShowUserForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnShowUserForm.Location = new System.Drawing.Point(13, 278);
            this.btnShowUserForm.Name = "btnShowUserForm";
            this.btnShowUserForm.Size = new System.Drawing.Size(120, 40);
            this.btnShowUserForm.TabIndex = 4;
            this.btnShowUserForm.Text = "Показать в форме пользователя";
            this.btnShowUserForm.UseVisualStyleBackColor = true;
            // 
            // btnCreateTimetable
            // 
            this.btnCreateTimetable.Location = new System.Drawing.Point(13, 22);
            this.btnCreateTimetable.Name = "btnCreateTimetable";
            this.btnCreateTimetable.Size = new System.Drawing.Size(100, 35);
            this.btnCreateTimetable.TabIndex = 2;
            this.btnCreateTimetable.Text = "Создать";
            this.btnCreateTimetable.UseVisualStyleBackColor = true;
            // 
            // groupBoxAlgorithmSettings
            // 
            this.groupBoxAlgorithmSettings.Controls.Add(this.numericTrainCount);
            this.groupBoxAlgorithmSettings.Controls.Add(this.label1);
            this.groupBoxAlgorithmSettings.Controls.Add(this.label8);
            this.groupBoxAlgorithmSettings.Controls.Add(this.numericPopulationCount);
            this.groupBoxAlgorithmSettings.Controls.Add(this.label7);
            this.groupBoxAlgorithmSettings.Controls.Add(this.label6);
            this.groupBoxAlgorithmSettings.Controls.Add(this.numericPartOfBest);
            this.groupBoxAlgorithmSettings.Controls.Add(this.label5);
            this.groupBoxAlgorithmSettings.Controls.Add(this.numericIterationsCount);
            this.groupBoxAlgorithmSettings.Location = new System.Drawing.Point(3, 3);
            this.groupBoxAlgorithmSettings.Name = "groupBoxAlgorithmSettings";
            this.groupBoxAlgorithmSettings.Size = new System.Drawing.Size(225, 198);
            this.groupBoxAlgorithmSettings.TabIndex = 5;
            this.groupBoxAlgorithmSettings.TabStop = false;
            this.groupBoxAlgorithmSettings.Text = "Настройки алгоритма";
            // 
            // numericTrainCount
            // 
            this.numericTrainCount.Location = new System.Drawing.Point(158, 110);
            this.numericTrainCount.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericTrainCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTrainCount.Name = "numericTrainCount";
            this.numericTrainCount.ReadOnly = true;
            this.numericTrainCount.Size = new System.Drawing.Size(52, 23);
            this.numericTrainCount.TabIndex = 14;
            this.numericTrainCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Количество тренировок:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(9, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(210, 45);
            this.label8.TabIndex = 11;
            this.label8.Text = "Примечание: количество популяций должно нацело делиться на часть лучших популяций" +
    "";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericPopulationCount
            // 
            this.numericPopulationCount.Location = new System.Drawing.Point(158, 81);
            this.numericPopulationCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericPopulationCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericPopulationCount.Name = "numericPopulationCount";
            this.numericPopulationCount.ReadOnly = true;
            this.numericPopulationCount.Size = new System.Drawing.Size(52, 23);
            this.numericPopulationCount.TabIndex = 10;
            this.numericPopulationCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Количество популяций:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Часть лучших популяций:";
            // 
            // numericPartOfBest
            // 
            this.numericPartOfBest.Location = new System.Drawing.Point(158, 49);
            this.numericPartOfBest.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericPartOfBest.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericPartOfBest.Name = "numericPartOfBest";
            this.numericPartOfBest.ReadOnly = true;
            this.numericPartOfBest.Size = new System.Drawing.Size(52, 23);
            this.numericPartOfBest.TabIndex = 7;
            this.numericPartOfBest.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Количество итераций:";
            // 
            // numericIterationsCount
            // 
            this.numericIterationsCount.Location = new System.Drawing.Point(158, 20);
            this.numericIterationsCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericIterationsCount.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericIterationsCount.Name = "numericIterationsCount";
            this.numericIterationsCount.ReadOnly = true;
            this.numericIterationsCount.Size = new System.Drawing.Size(52, 23);
            this.numericIterationsCount.TabIndex = 5;
            this.numericIterationsCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // checkBoxDefaultSettings
            // 
            this.checkBoxDefaultSettings.Checked = true;
            this.checkBoxDefaultSettings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDefaultSettings.Location = new System.Drawing.Point(4, 335);
            this.checkBoxDefaultSettings.Name = "checkBoxDefaultSettings";
            this.checkBoxDefaultSettings.Size = new System.Drawing.Size(257, 40);
            this.checkBoxDefaultSettings.TabIndex = 12;
            this.checkBoxDefaultSettings.Text = "Использовать настройки по умолчанию";
            this.checkBoxDefaultSettings.UseVisualStyleBackColor = true;
            // 
            // groupBoxTimetableSettings
            // 
            this.groupBoxTimetableSettings.Controls.Add(this.numericSemesterPart);
            this.groupBoxTimetableSettings.Controls.Add(this.numericHoursDay);
            this.groupBoxTimetableSettings.Controls.Add(this.numericDaysWeek);
            this.groupBoxTimetableSettings.Controls.Add(this.label4);
            this.groupBoxTimetableSettings.Controls.Add(this.label3);
            this.groupBoxTimetableSettings.Controls.Add(this.label2);
            this.groupBoxTimetableSettings.Location = new System.Drawing.Point(4, 207);
            this.groupBoxTimetableSettings.Name = "groupBoxTimetableSettings";
            this.groupBoxTimetableSettings.Size = new System.Drawing.Size(225, 122);
            this.groupBoxTimetableSettings.TabIndex = 4;
            this.groupBoxTimetableSettings.TabStop = false;
            this.groupBoxTimetableSettings.Text = "Настройки расписания";
            // 
            // numericSemesterPart
            // 
            this.numericSemesterPart.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numericSemesterPart.Location = new System.Drawing.Point(166, 86);
            this.numericSemesterPart.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericSemesterPart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSemesterPart.Name = "numericSemesterPart";
            this.numericSemesterPart.ReadOnly = true;
            this.numericSemesterPart.Size = new System.Drawing.Size(52, 23);
            this.numericSemesterPart.TabIndex = 7;
            this.numericSemesterPart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericHoursDay
            // 
            this.numericHoursDay.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numericHoursDay.Location = new System.Drawing.Point(166, 56);
            this.numericHoursDay.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericHoursDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericHoursDay.Name = "numericHoursDay";
            this.numericHoursDay.ReadOnly = true;
            this.numericHoursDay.Size = new System.Drawing.Size(52, 23);
            this.numericHoursDay.TabIndex = 6;
            this.numericHoursDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericDaysWeek
            // 
            this.numericDaysWeek.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numericDaysWeek.Location = new System.Drawing.Point(166, 25);
            this.numericDaysWeek.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericDaysWeek.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericDaysWeek.Name = "numericDaysWeek";
            this.numericDaysWeek.ReadOnly = true;
            this.numericDaysWeek.Size = new System.Drawing.Size(52, 23);
            this.numericDaysWeek.TabIndex = 5;
            this.numericDaysWeek.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Семестр:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Максимум пар в день:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Дней в неделю:";
            // 
            // subjectsTeachersTab
            // 
            this.subjectsTeachersTab.Location = new System.Drawing.Point(4, 24);
            this.subjectsTeachersTab.Name = "subjectsTeachersTab";
            this.subjectsTeachersTab.Padding = new System.Windows.Forms.Padding(3);
            this.subjectsTeachersTab.Size = new System.Drawing.Size(708, 378);
            this.subjectsTeachersTab.TabIndex = 1;
            this.subjectsTeachersTab.Text = "Предметы и преподаватели";
            this.subjectsTeachersTab.UseVisualStyleBackColor = true;
            // 
            // groupsSpecialtiesTab
            // 
            this.groupsSpecialtiesTab.BackColor = System.Drawing.Color.White;
            this.groupsSpecialtiesTab.Location = new System.Drawing.Point(4, 24);
            this.groupsSpecialtiesTab.Name = "groupsSpecialtiesTab";
            this.groupsSpecialtiesTab.Size = new System.Drawing.Size(708, 378);
            this.groupsSpecialtiesTab.TabIndex = 2;
            this.groupsSpecialtiesTab.Text = "Специальности и группы";
            // 
            // planTab
            // 
            this.planTab.BackColor = System.Drawing.Color.White;
            this.planTab.Location = new System.Drawing.Point(4, 24);
            this.planTab.Name = "planTab";
            this.planTab.Size = new System.Drawing.Size(708, 378);
            this.planTab.TabIndex = 3;
            this.planTab.Text = "Учебный план";
            // 
            // pictureBoxTimetableCreation
            // 
            this.pictureBoxTimetableCreation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxTimetableCreation.InitialImage = null;
            this.pictureBoxTimetableCreation.Location = new System.Drawing.Point(432, 24);
            this.pictureBoxTimetableCreation.Name = "pictureBoxTimetableCreation";
            this.pictureBoxTimetableCreation.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxTimetableCreation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTimetableCreation.TabIndex = 13;
            this.pictureBoxTimetableCreation.TabStop = false;
            this.pictureBoxTimetableCreation.Visible = false;
            // 
            // databaseTab
            // 
            this.databaseTab.Location = new System.Drawing.Point(4, 24);
            this.databaseTab.Name = "databaseTab";
            this.databaseTab.Size = new System.Drawing.Size(708, 378);
            this.databaseTab.TabIndex = 4;
            this.databaseTab.Text = "База данных";
            this.databaseTab.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 431);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(750, 470);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.tabControl1.ResumeLayout(false);
            this.timetableCreationTab.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panelTimetableCreationLog.ResumeLayout(false);
            this.groupBoxAlgorithmSettings.ResumeLayout(false);
            this.groupBoxAlgorithmSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericTrainCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPopulationCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPartOfBest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIterationsCount)).EndInit();
            this.groupBoxTimetableSettings.ResumeLayout(false);
            this.groupBoxTimetableSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericSemesterPart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHoursDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDaysWeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTimetableCreation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage timetableCreationTab;
        private System.Windows.Forms.TabPage subjectsTeachersTab;
        private System.Windows.Forms.TabPage groupsSpecialtiesTab;
        private System.Windows.Forms.TabPage planTab;
        private System.Windows.Forms.Button btnCreateTimetable;
        private System.Windows.Forms.GroupBox groupBoxAlgorithmSettings;
        private System.Windows.Forms.GroupBox groupBoxTimetableSettings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericSemesterPart;
        private System.Windows.Forms.NumericUpDown numericHoursDay;
        private System.Windows.Forms.NumericUpDown numericDaysWeek;
        private System.Windows.Forms.NumericUpDown numericIterationsCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericPopulationCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxDefaultSettings;
        private System.Windows.Forms.Button btnShowUserForm;
        private System.Windows.Forms.NumericUpDown numericTrainCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericPartOfBest;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancelTimetableCreation;
        private System.Windows.Forms.Panel panelTimetableCreationLog;
        private System.Windows.Forms.RichTextBox timetableResultLog;
        private System.Windows.Forms.Label lblSolverLog;
        private System.Windows.Forms.RichTextBox rbxTimetableResultLog;
        private System.Windows.Forms.Button btnTimetableTrain;
        private System.Windows.Forms.Button btnSaveToDatabase;
        private System.Windows.Forms.TabPage databaseTab;
        private System.Windows.Forms.PictureBox pictureBoxTimetableCreation;
    }
}