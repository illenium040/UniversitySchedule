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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.tabMainControl = new System.Windows.Forms.TabControl();
            this.databaseTab = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSaveDatabaseFolderDialog = new System.Windows.Forms.Button();
            this.btnDatabaseFileDialog = new System.Windows.Forms.Button();
            this.tbxBackupFileName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbxDatabasePathSaveBackup = new System.Windows.Forms.TextBox();
            this.tbxDatabasePathBackup = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnCreateBackup = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveConStrings = new System.Windows.Forms.Button();
            this.chbxDefaultConStringSettings = new System.Windows.Forms.CheckBox();
            this.tbxUserConString = new System.Windows.Forms.TextBox();
            this.tbxAdminConString = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.timetableCreationTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCreateTimetable = new System.Windows.Forms.Button();
            this.btnSaveToDatabase = new System.Windows.Forms.Button();
            this.btnTimetableTrain = new System.Windows.Forms.Button();
            this.btnShowUserForm = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.pictureBoxTimetableCreation = new System.Windows.Forms.PictureBox();
            this.panelTimetableCreationLog = new System.Windows.Forms.Panel();
            this.lblSolverLog = new System.Windows.Forms.Label();
            this.rbxTimetableResultLog = new System.Windows.Forms.RichTextBox();
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
            this.tabAddToDB = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tabUpdateDB = new System.Windows.Forms.TabPage();
            this.lblExtraInfoToDataGrid = new System.Windows.Forms.Label();
            this.updatedExtraInfoDataGrid = new System.Windows.Forms.DataGridView();
            this.lblSubTableName = new System.Windows.Forms.Label();
            this.lblMainTableName = new System.Windows.Forms.Label();
            this.loadingPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.updatedMainDataGrid = new System.Windows.Forms.DataGridView();
            this.isConfirmation = new System.Windows.Forms.CheckBox();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.tableNameList = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnRefreshDataGrid = new System.Windows.Forms.Button();
            this.tabMainControl.SuspendLayout();
            this.databaseTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.timetableCreationTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTimetableCreation)).BeginInit();
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
            this.tabAddToDB.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabUpdateDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updatedExtraInfoDataGrid)).BeginInit();
            this.loadingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updatedMainDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMainControl
            // 
            this.tabMainControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMainControl.Controls.Add(this.databaseTab);
            this.tabMainControl.Controls.Add(this.timetableCreationTab);
            this.tabMainControl.Controls.Add(this.tabAddToDB);
            this.tabMainControl.Controls.Add(this.tabUpdateDB);
            this.tabMainControl.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabMainControl.Location = new System.Drawing.Point(10, 13);
            this.tabMainControl.Name = "tabMainControl";
            this.tabMainControl.SelectedIndex = 0;
            this.tabMainControl.Size = new System.Drawing.Size(948, 503);
            this.tabMainControl.TabIndex = 0;
            // 
            // databaseTab
            // 
            this.databaseTab.BackColor = System.Drawing.Color.White;
            this.databaseTab.Controls.Add(this.groupBox3);
            this.databaseTab.Controls.Add(this.groupBox1);
            this.databaseTab.Location = new System.Drawing.Point(4, 26);
            this.databaseTab.Name = "databaseTab";
            this.databaseTab.Size = new System.Drawing.Size(940, 473);
            this.databaseTab.TabIndex = 4;
            this.databaseTab.Text = "База данных";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSaveDatabaseFolderDialog);
            this.groupBox3.Controls.Add(this.btnDatabaseFileDialog);
            this.groupBox3.Controls.Add(this.tbxBackupFileName);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.tbxDatabasePathSaveBackup);
            this.groupBox3.Controls.Add(this.tbxDatabasePathBackup);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.btnCreateBackup);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(511, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(239, 211);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Бэкап";
            // 
            // btnSaveDatabaseFolderDialog
            // 
            this.btnSaveDatabaseFolderDialog.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSaveDatabaseFolderDialog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDatabaseFolderDialog.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSaveDatabaseFolderDialog.ForeColor = System.Drawing.Color.White;
            this.btnSaveDatabaseFolderDialog.Location = new System.Drawing.Point(203, 87);
            this.btnSaveDatabaseFolderDialog.Name = "btnSaveDatabaseFolderDialog";
            this.btnSaveDatabaseFolderDialog.Size = new System.Drawing.Size(30, 23);
            this.btnSaveDatabaseFolderDialog.TabIndex = 8;
            this.btnSaveDatabaseFolderDialog.Text = "...";
            this.btnSaveDatabaseFolderDialog.UseVisualStyleBackColor = false;
            // 
            // btnDatabaseFileDialog
            // 
            this.btnDatabaseFileDialog.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDatabaseFileDialog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatabaseFileDialog.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDatabaseFileDialog.ForeColor = System.Drawing.Color.White;
            this.btnDatabaseFileDialog.Location = new System.Drawing.Point(203, 42);
            this.btnDatabaseFileDialog.Name = "btnDatabaseFileDialog";
            this.btnDatabaseFileDialog.Size = new System.Drawing.Size(30, 23);
            this.btnDatabaseFileDialog.TabIndex = 7;
            this.btnDatabaseFileDialog.Text = "...";
            this.btnDatabaseFileDialog.UseVisualStyleBackColor = false;
            // 
            // tbxBackupFileName
            // 
            this.tbxBackupFileName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbxBackupFileName.Location = new System.Drawing.Point(7, 135);
            this.tbxBackupFileName.Name = "tbxBackupFileName";
            this.tbxBackupFileName.Size = new System.Drawing.Size(226, 25);
            this.tbxBackupFileName.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(7, 117);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(186, 17);
            this.label13.TabIndex = 5;
            this.label13.Text = "Имя сохраняемого файла:";
            // 
            // tbxDatabasePathSaveBackup
            // 
            this.tbxDatabasePathSaveBackup.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbxDatabasePathSaveBackup.Location = new System.Drawing.Point(7, 87);
            this.tbxDatabasePathSaveBackup.Name = "tbxDatabasePathSaveBackup";
            this.tbxDatabasePathSaveBackup.Size = new System.Drawing.Size(196, 25);
            this.tbxDatabasePathSaveBackup.TabIndex = 4;
            // 
            // tbxDatabasePathBackup
            // 
            this.tbxDatabasePathBackup.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbxDatabasePathBackup.Location = new System.Drawing.Point(7, 42);
            this.tbxDatabasePathBackup.Name = "tbxDatabasePathBackup";
            this.tbxDatabasePathBackup.Size = new System.Drawing.Size(196, 25);
            this.tbxDatabasePathBackup.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(7, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(146, 17);
            this.label12.TabIndex = 2;
            this.label12.Text = "Путь к базе данных:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(6, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(221, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "Путь сохранения базы данных:";
            // 
            // btnCreateBackup
            // 
            this.btnCreateBackup.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCreateBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateBackup.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCreateBackup.ForeColor = System.Drawing.Color.White;
            this.btnCreateBackup.Location = new System.Drawing.Point(133, 166);
            this.btnCreateBackup.Name = "btnCreateBackup";
            this.btnCreateBackup.Size = new System.Drawing.Size(100, 30);
            this.btnCreateBackup.TabIndex = 0;
            this.btnCreateBackup.Text = "Создать";
            this.btnCreateBackup.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveConStrings);
            this.groupBox1.Controls.Add(this.chbxDefaultConStringSettings);
            this.groupBox1.Controls.Add(this.tbxUserConString);
            this.groupBox1.Controls.Add(this.tbxAdminConString);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 196);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Строки подключения";
            // 
            // btnSaveConStrings
            // 
            this.btnSaveConStrings.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSaveConStrings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveConStrings.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSaveConStrings.ForeColor = System.Drawing.Color.White;
            this.btnSaveConStrings.Location = new System.Drawing.Point(6, 150);
            this.btnSaveConStrings.Name = "btnSaveConStrings";
            this.btnSaveConStrings.Size = new System.Drawing.Size(100, 30);
            this.btnSaveConStrings.TabIndex = 5;
            this.btnSaveConStrings.Text = "Сохранить";
            this.btnSaveConStrings.UseVisualStyleBackColor = false;
            // 
            // chbxDefaultConStringSettings
            // 
            this.chbxDefaultConStringSettings.AutoSize = true;
            this.chbxDefaultConStringSettings.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chbxDefaultConStringSettings.Location = new System.Drawing.Point(7, 123);
            this.chbxDefaultConStringSettings.Name = "chbxDefaultConStringSettings";
            this.chbxDefaultConStringSettings.Size = new System.Drawing.Size(298, 21);
            this.chbxDefaultConStringSettings.TabIndex = 4;
            this.chbxDefaultConStringSettings.Text = "Использовать настройки по умолчанию";
            this.chbxDefaultConStringSettings.UseVisualStyleBackColor = true;
            // 
            // tbxUserConString
            // 
            this.tbxUserConString.Location = new System.Drawing.Point(7, 87);
            this.tbxUserConString.Name = "tbxUserConString";
            this.tbxUserConString.ReadOnly = true;
            this.tbxUserConString.Size = new System.Drawing.Size(489, 25);
            this.tbxUserConString.TabIndex = 3;
            // 
            // tbxAdminConString
            // 
            this.tbxAdminConString.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbxAdminConString.Location = new System.Drawing.Point(7, 42);
            this.tbxAdminConString.Name = "tbxAdminConString";
            this.tbxAdminConString.ReadOnly = true;
            this.tbxAdminConString.Size = new System.Drawing.Size(489, 25);
            this.tbxAdminConString.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(7, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(385, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Строка подключения к базе данных для пользователя:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(7, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(404, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Строка подключения к базе данных для администратора:";
            // 
            // timetableCreationTab
            // 
            this.timetableCreationTab.Controls.Add(this.panel1);
            this.timetableCreationTab.Controls.Add(this.groupBox2);
            this.timetableCreationTab.Location = new System.Drawing.Point(4, 26);
            this.timetableCreationTab.Name = "timetableCreationTab";
            this.timetableCreationTab.Padding = new System.Windows.Forms.Padding(3);
            this.timetableCreationTab.Size = new System.Drawing.Size(940, 473);
            this.timetableCreationTab.TabIndex = 0;
            this.timetableCreationTab.Text = "Создание расписания";
            this.timetableCreationTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.btnCreateTimetable);
            this.panel1.Controls.Add(this.btnSaveToDatabase);
            this.panel1.Controls.Add(this.btnTimetableTrain);
            this.panel1.Controls.Add(this.btnShowUserForm);
            this.panel1.Location = new System.Drawing.Point(3, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(145, 441);
            this.panel1.TabIndex = 14;
            // 
            // btnCreateTimetable
            // 
            this.btnCreateTimetable.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCreateTimetable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTimetable.ForeColor = System.Drawing.Color.White;
            this.btnCreateTimetable.Location = new System.Drawing.Point(11, 14);
            this.btnCreateTimetable.Name = "btnCreateTimetable";
            this.btnCreateTimetable.Size = new System.Drawing.Size(123, 35);
            this.btnCreateTimetable.TabIndex = 2;
            this.btnCreateTimetable.Text = "Создать";
            this.btnCreateTimetable.UseVisualStyleBackColor = false;
            // 
            // btnSaveToDatabase
            // 
            this.btnSaveToDatabase.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSaveToDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveToDatabase.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSaveToDatabase.ForeColor = System.Drawing.Color.White;
            this.btnSaveToDatabase.Location = new System.Drawing.Point(9, 147);
            this.btnSaveToDatabase.Name = "btnSaveToDatabase";
            this.btnSaveToDatabase.Size = new System.Drawing.Size(125, 45);
            this.btnSaveToDatabase.TabIndex = 9;
            this.btnSaveToDatabase.Text = "Сохранить в базу данных";
            this.btnSaveToDatabase.UseVisualStyleBackColor = false;
            // 
            // btnTimetableTrain
            // 
            this.btnTimetableTrain.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnTimetableTrain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimetableTrain.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTimetableTrain.ForeColor = System.Drawing.Color.White;
            this.btnTimetableTrain.Location = new System.Drawing.Point(11, 55);
            this.btnTimetableTrain.Name = "btnTimetableTrain";
            this.btnTimetableTrain.Size = new System.Drawing.Size(123, 35);
            this.btnTimetableTrain.TabIndex = 8;
            this.btnTimetableTrain.Text = "Тренировать";
            this.btnTimetableTrain.UseVisualStyleBackColor = false;
            // 
            // btnShowUserForm
            // 
            this.btnShowUserForm.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnShowUserForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowUserForm.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShowUserForm.ForeColor = System.Drawing.Color.White;
            this.btnShowUserForm.Location = new System.Drawing.Point(9, 96);
            this.btnShowUserForm.Name = "btnShowUserForm";
            this.btnShowUserForm.Size = new System.Drawing.Size(125, 45);
            this.btnShowUserForm.TabIndex = 4;
            this.btnShowUserForm.Text = "Показать в форме пользователя";
            this.btnShowUserForm.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnSaveSettings);
            this.groupBox2.Controls.Add(this.pictureBoxTimetableCreation);
            this.groupBox2.Controls.Add(this.panelTimetableCreationLog);
            this.groupBox2.Controls.Add(this.groupBoxAlgorithmSettings);
            this.groupBox2.Controls.Add(this.checkBoxDefaultSettings);
            this.groupBox2.Controls.Add(this.groupBoxTimetableSettings);
            this.groupBox2.Location = new System.Drawing.Point(154, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(773, 441);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Создание расписания";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSettings.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSaveSettings.ForeColor = System.Drawing.Color.White;
            this.btnSaveSettings.Location = new System.Drawing.Point(636, 386);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(125, 45);
            this.btnSaveSettings.TabIndex = 13;
            this.btnSaveSettings.Text = "Сохранить настройки";
            this.btnSaveSettings.UseVisualStyleBackColor = false;
            // 
            // pictureBoxTimetableCreation
            // 
            this.pictureBoxTimetableCreation.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTimetableCreation.Image")));
            this.pictureBoxTimetableCreation.InitialImage = null;
            this.pictureBoxTimetableCreation.Location = new System.Drawing.Point(162, 0);
            this.pictureBoxTimetableCreation.Name = "pictureBoxTimetableCreation";
            this.pictureBoxTimetableCreation.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxTimetableCreation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTimetableCreation.TabIndex = 13;
            this.pictureBoxTimetableCreation.TabStop = false;
            this.pictureBoxTimetableCreation.Visible = false;
            // 
            // panelTimetableCreationLog
            // 
            this.panelTimetableCreationLog.Controls.Add(this.lblSolverLog);
            this.panelTimetableCreationLog.Controls.Add(this.rbxTimetableResultLog);
            this.panelTimetableCreationLog.Location = new System.Drawing.Point(8, 20);
            this.panelTimetableCreationLog.Name = "panelTimetableCreationLog";
            this.panelTimetableCreationLog.Padding = new System.Windows.Forms.Padding(3);
            this.panelTimetableCreationLog.Size = new System.Drawing.Size(492, 411);
            this.panelTimetableCreationLog.TabIndex = 7;
            // 
            // lblSolverLog
            // 
            this.lblSolverLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSolverLog.Location = new System.Drawing.Point(7, 369);
            this.lblSolverLog.Name = "lblSolverLog";
            this.lblSolverLog.Size = new System.Drawing.Size(476, 31);
            this.lblSolverLog.TabIndex = 9;
            // 
            // rbxTimetableResultLog
            // 
            this.rbxTimetableResultLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbxTimetableResultLog.Location = new System.Drawing.Point(7, 6);
            this.rbxTimetableResultLog.Name = "rbxTimetableResultLog";
            this.rbxTimetableResultLog.Size = new System.Drawing.Size(476, 358);
            this.rbxTimetableResultLog.TabIndex = 8;
            this.rbxTimetableResultLog.Text = "";
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
            this.groupBoxAlgorithmSettings.Location = new System.Drawing.Point(506, 24);
            this.groupBoxAlgorithmSettings.Name = "groupBoxAlgorithmSettings";
            this.groupBoxAlgorithmSettings.Size = new System.Drawing.Size(255, 198);
            this.groupBoxAlgorithmSettings.TabIndex = 5;
            this.groupBoxAlgorithmSettings.TabStop = false;
            this.groupBoxAlgorithmSettings.Text = "Настройки алгоритма";
            // 
            // numericTrainCount
            // 
            this.numericTrainCount.BackColor = System.Drawing.Color.White;
            this.numericTrainCount.ForeColor = System.Drawing.Color.Black;
            this.numericTrainCount.Location = new System.Drawing.Point(196, 112);
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
            this.numericTrainCount.Size = new System.Drawing.Size(52, 25);
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
            this.label1.Location = new System.Drawing.Point(16, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Количество тренировок:";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(9, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(239, 45);
            this.label8.TabIndex = 11;
            this.label8.Text = "Примечание: количество популяций должно нацело делиться на часть лучших популяций" +
    "";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericPopulationCount
            // 
            this.numericPopulationCount.BackColor = System.Drawing.Color.White;
            this.numericPopulationCount.ForeColor = System.Drawing.Color.Black;
            this.numericPopulationCount.Location = new System.Drawing.Point(196, 83);
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
            this.numericPopulationCount.Size = new System.Drawing.Size(52, 25);
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
            this.label7.Location = new System.Drawing.Point(22, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Количество популяций:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Часть лучших популяций:";
            // 
            // numericPartOfBest
            // 
            this.numericPartOfBest.BackColor = System.Drawing.Color.White;
            this.numericPartOfBest.ForeColor = System.Drawing.Color.Black;
            this.numericPartOfBest.Location = new System.Drawing.Point(196, 51);
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
            this.numericPartOfBest.Size = new System.Drawing.Size(52, 25);
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
            this.label5.Location = new System.Drawing.Point(30, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Количество итераций:";
            // 
            // numericIterationsCount
            // 
            this.numericIterationsCount.BackColor = System.Drawing.Color.White;
            this.numericIterationsCount.ForeColor = System.Drawing.Color.Black;
            this.numericIterationsCount.Location = new System.Drawing.Point(196, 22);
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
            this.numericIterationsCount.Size = new System.Drawing.Size(52, 25);
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
            this.checkBoxDefaultSettings.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxDefaultSettings.Location = new System.Drawing.Point(508, 356);
            this.checkBoxDefaultSettings.Name = "checkBoxDefaultSettings";
            this.checkBoxDefaultSettings.Size = new System.Drawing.Size(254, 24);
            this.checkBoxDefaultSettings.TabIndex = 12;
            this.checkBoxDefaultSettings.Text = "Использовать настройки по умолчанию";
            this.checkBoxDefaultSettings.UseVisualStyleBackColor = true;
            this.checkBoxDefaultSettings.CheckStateChanged += new System.EventHandler(this.checkBoxDefaultSettings_CheckStateChanged);
            // 
            // groupBoxTimetableSettings
            // 
            this.groupBoxTimetableSettings.Controls.Add(this.numericSemesterPart);
            this.groupBoxTimetableSettings.Controls.Add(this.numericHoursDay);
            this.groupBoxTimetableSettings.Controls.Add(this.numericDaysWeek);
            this.groupBoxTimetableSettings.Controls.Add(this.label4);
            this.groupBoxTimetableSettings.Controls.Add(this.label3);
            this.groupBoxTimetableSettings.Controls.Add(this.label2);
            this.groupBoxTimetableSettings.Location = new System.Drawing.Point(508, 228);
            this.groupBoxTimetableSettings.Name = "groupBoxTimetableSettings";
            this.groupBoxTimetableSettings.Size = new System.Drawing.Size(254, 122);
            this.groupBoxTimetableSettings.TabIndex = 4;
            this.groupBoxTimetableSettings.TabStop = false;
            this.groupBoxTimetableSettings.Text = "Настройки расписания";
            // 
            // numericSemesterPart
            // 
            this.numericSemesterPart.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numericSemesterPart.BackColor = System.Drawing.Color.White;
            this.numericSemesterPart.ForeColor = System.Drawing.Color.Black;
            this.numericSemesterPart.Location = new System.Drawing.Point(195, 86);
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
            this.numericSemesterPart.Size = new System.Drawing.Size(52, 25);
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
            this.numericHoursDay.BackColor = System.Drawing.Color.White;
            this.numericHoursDay.ForeColor = System.Drawing.Color.Black;
            this.numericHoursDay.Location = new System.Drawing.Point(195, 56);
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
            this.numericHoursDay.Size = new System.Drawing.Size(52, 25);
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
            this.numericDaysWeek.BackColor = System.Drawing.Color.White;
            this.numericDaysWeek.ForeColor = System.Drawing.Color.Black;
            this.numericDaysWeek.Location = new System.Drawing.Point(195, 25);
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
            this.numericDaysWeek.Size = new System.Drawing.Size(52, 25);
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
            this.label4.Location = new System.Drawing.Point(117, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Семестр:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Максимум пар в день:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Дней в неделю:";
            // 
            // tabAddToDB
            // 
            this.tabAddToDB.Controls.Add(this.panel2);
            this.tabAddToDB.Location = new System.Drawing.Point(4, 26);
            this.tabAddToDB.Name = "tabAddToDB";
            this.tabAddToDB.Size = new System.Drawing.Size(940, 473);
            this.tabAddToDB.TabIndex = 5;
            this.tabAddToDB.Text = "Добавить в БД";
            this.tabAddToDB.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox5);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(924, 456);
            this.panel2.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Location = new System.Drawing.Point(0, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(408, 274);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Преподаватель-предмет";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(396, 25);
            this.textBox1.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 59);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 17);
            this.label15.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(154, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = "ФИО преподавателя:";
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(414, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 100);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Группа-специальность";
            // 
            // tabUpdateDB
            // 
            this.tabUpdateDB.Controls.Add(this.btnRefreshDataGrid);
            this.tabUpdateDB.Controls.Add(this.lblExtraInfoToDataGrid);
            this.tabUpdateDB.Controls.Add(this.updatedExtraInfoDataGrid);
            this.tabUpdateDB.Controls.Add(this.lblSubTableName);
            this.tabUpdateDB.Controls.Add(this.lblMainTableName);
            this.tabUpdateDB.Controls.Add(this.loadingPanel);
            this.tabUpdateDB.Controls.Add(this.updatedMainDataGrid);
            this.tabUpdateDB.Controls.Add(this.isConfirmation);
            this.tabUpdateDB.Controls.Add(this.btnSaveChanges);
            this.tabUpdateDB.Controls.Add(this.tableNameList);
            this.tabUpdateDB.Controls.Add(this.label16);
            this.tabUpdateDB.Location = new System.Drawing.Point(4, 26);
            this.tabUpdateDB.Name = "tabUpdateDB";
            this.tabUpdateDB.Size = new System.Drawing.Size(940, 473);
            this.tabUpdateDB.TabIndex = 6;
            this.tabUpdateDB.Text = "Изменить записи в БД";
            this.tabUpdateDB.UseVisualStyleBackColor = true;
            // 
            // lblExtraInfoToDataGrid
            // 
            this.lblExtraInfoToDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExtraInfoToDataGrid.AutoSize = true;
            this.lblExtraInfoToDataGrid.Location = new System.Drawing.Point(505, 17);
            this.lblExtraInfoToDataGrid.Name = "lblExtraInfoToDataGrid";
            this.lblExtraInfoToDataGrid.Size = new System.Drawing.Size(211, 17);
            this.lblExtraInfoToDataGrid.TabIndex = 12;
            this.lblExtraInfoToDataGrid.Text = "Дополнительная информация";
            // 
            // updatedExtraInfoDataGrid
            // 
            this.updatedExtraInfoDataGrid.AllowUserToAddRows = false;
            this.updatedExtraInfoDataGrid.AllowUserToDeleteRows = false;
            this.updatedExtraInfoDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updatedExtraInfoDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.updatedExtraInfoDataGrid.Location = new System.Drawing.Point(505, 37);
            this.updatedExtraInfoDataGrid.Name = "updatedExtraInfoDataGrid";
            this.updatedExtraInfoDataGrid.RowTemplate.Height = 25;
            this.updatedExtraInfoDataGrid.Size = new System.Drawing.Size(432, 433);
            this.updatedExtraInfoDataGrid.TabIndex = 11;
            // 
            // lblSubTableName
            // 
            this.lblSubTableName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubTableName.AutoSize = true;
            this.lblSubTableName.Location = new System.Drawing.Point(241, 200);
            this.lblSubTableName.Name = "lblSubTableName";
            this.lblSubTableName.Size = new System.Drawing.Size(0, 17);
            this.lblSubTableName.TabIndex = 10;
            // 
            // lblMainTableName
            // 
            this.lblMainTableName.AutoSize = true;
            this.lblMainTableName.Location = new System.Drawing.Point(241, 16);
            this.lblMainTableName.Name = "lblMainTableName";
            this.lblMainTableName.Size = new System.Drawing.Size(0, 17);
            this.lblMainTableName.TabIndex = 9;
            // 
            // loadingPanel
            // 
            this.loadingPanel.Controls.Add(this.pictureBox1);
            this.loadingPanel.Location = new System.Drawing.Point(5, 174);
            this.loadingPanel.Name = "loadingPanel";
            this.loadingPanel.Padding = new System.Windows.Forms.Padding(80, 0, 80, 0);
            this.loadingPanel.Size = new System.Drawing.Size(225, 91);
            this.loadingPanel.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(82, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // updatedMainDataGrid
            // 
            this.updatedMainDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updatedMainDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.updatedMainDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.updatedMainDataGrid.Location = new System.Drawing.Point(241, 37);
            this.updatedMainDataGrid.Name = "updatedMainDataGrid";
            this.updatedMainDataGrid.RowTemplate.Height = 25;
            this.updatedMainDataGrid.Size = new System.Drawing.Size(258, 433);
            this.updatedMainDataGrid.TabIndex = 6;
            // 
            // isConfirmation
            // 
            this.isConfirmation.AutoSize = true;
            this.isConfirmation.Checked = true;
            this.isConfirmation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isConfirmation.Location = new System.Drawing.Point(5, 147);
            this.isConfirmation.Name = "isConfirmation";
            this.isConfirmation.Size = new System.Drawing.Size(228, 21);
            this.isConfirmation.TabIndex = 5;
            this.isConfirmation.Text = "Запрашивать подтверждение";
            this.isConfirmation.UseVisualStyleBackColor = true;
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSaveChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveChanges.ForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.Location = new System.Drawing.Point(4, 68);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(229, 35);
            this.btnSaveChanges.TabIndex = 3;
            this.btnSaveChanges.Text = "Сохранить изменения";
            this.btnSaveChanges.UseVisualStyleBackColor = false;
            // 
            // tableNameList
            // 
            this.tableNameList.FormattingEnabled = true;
            this.tableNameList.Location = new System.Drawing.Point(4, 37);
            this.tableNameList.Name = "tableNameList";
            this.tableNameList.Size = new System.Drawing.Size(225, 25);
            this.tableNameList.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 17);
            this.label16.TabIndex = 0;
            this.label16.Text = "Таблица";
            // 
            // btnRefreshDataGrid
            // 
            this.btnRefreshDataGrid.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRefreshDataGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshDataGrid.ForeColor = System.Drawing.Color.White;
            this.btnRefreshDataGrid.Location = new System.Drawing.Point(4, 109);
            this.btnRefreshDataGrid.Name = "btnRefreshDataGrid";
            this.btnRefreshDataGrid.Size = new System.Drawing.Size(229, 35);
            this.btnRefreshDataGrid.TabIndex = 13;
            this.btnRefreshDataGrid.Text = "Обновить";
            this.btnRefreshDataGrid.UseVisualStyleBackColor = false;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(966, 528);
            this.Controls.Add(this.tabMainControl);
            this.DoubleBuffered = true;
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.tabMainControl.ResumeLayout(false);
            this.databaseTab.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.timetableCreationTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTimetableCreation)).EndInit();
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
            this.tabAddToDB.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabUpdateDB.ResumeLayout(false);
            this.tabUpdateDB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updatedExtraInfoDataGrid)).EndInit();
            this.loadingPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updatedMainDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMainControl;
        private System.Windows.Forms.TabPage timetableCreationTab;
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
        private System.Windows.Forms.Panel panelTimetableCreationLog;
        private System.Windows.Forms.RichTextBox timetableResultLog;
        private System.Windows.Forms.Label lblSolverLog;
        private System.Windows.Forms.RichTextBox rbxTimetableResultLog;
        private System.Windows.Forms.Button btnSaveToDatabase;
        private System.Windows.Forms.TabPage databaseTab;
        private System.Windows.Forms.PictureBox pictureBoxTimetableCreation;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxAdminConString;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chbxDefaultConStringSettings;
        private System.Windows.Forms.TextBox tbxUserConString;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCreateBackup;
        private System.Windows.Forms.TextBox tbxDatabasePathSaveBackup;
        private System.Windows.Forms.TextBox tbxDatabasePathBackup;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSaveConStrings;
        private System.Windows.Forms.Button btnSaveDatabaseFolderDialog;
        private System.Windows.Forms.Button btnDatabaseFileDialog;
        private System.Windows.Forms.TextBox tbxBackupFileName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tabUpdateDB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTimetableTrain;
        private System.Windows.Forms.TabPage tabAddToDB;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView updatedMainDataGrid;
        private System.Windows.Forms.CheckBox isConfirmation;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.ComboBox tableNameList;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel loadingPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSubTableName;
        private System.Windows.Forms.Label lblMainTableName;
        private System.Windows.Forms.DataGridView updatedExtraInfoDataGrid;
        private System.Windows.Forms.Label lblExtraInfoToDataGrid;
        private System.Windows.Forms.DataGridView Inf;
        private System.Windows.Forms.Button btnRefreshDataGrid;
    }
}