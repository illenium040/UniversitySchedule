﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsUI.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.8.1.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\illenium\\Desktop\\ScheduleP" +
            "roject\\UniversitySchedule.accdb;")]
        public string DatabaseAdminConString {
            get {
                return ((string)(this["DatabaseAdminConString"]));
            }
            set {
                this["DatabaseAdminConString"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\illenium\\Desktop\\ScheduleP" +
            "roject\\UniversitySchedule.accdb;")]
        public string DatabaseUserConString {
            get {
                return ((string)(this["DatabaseUserConString"]));
            }
            set {
                this["DatabaseUserConString"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("6")]
        public int DaysWeek {
            get {
                return ((int)(this["DaysWeek"]));
            }
            set {
                this["DaysWeek"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("7")]
        public int HoursDay {
            get {
                return ((int)(this["HoursDay"]));
            }
            set {
                this["HoursDay"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1000")]
        public int MaxIterations {
            get {
                return ((int)(this["MaxIterations"]));
            }
            set {
                this["MaxIterations"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4")]
        public int PartOfBest {
            get {
                return ((int)(this["PartOfBest"]));
            }
            set {
                this["PartOfBest"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100")]
        public int PopulationCount {
            get {
                return ((int)(this["PopulationCount"]));
            }
            set {
                this["PopulationCount"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("First")]
        public global::TimetableAlgorithm.SemestersParts SemesterPart {
            get {
                return ((global::TimetableAlgorithm.SemestersParts)(this["SemesterPart"]));
            }
            set {
                this["SemesterPart"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DatabaseSoursePath {
            get {
                return ((string)(this["DatabaseSoursePath"]));
            }
            set {
                this["DatabaseSoursePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DatabaseBackupsPath {
            get {
                return ((string)(this["DatabaseBackupsPath"]));
            }
            set {
                this["DatabaseBackupsPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\illenium\\Desktop\\ScheduleP" +
            "roject\\UniversitySchedule.accdb;")]
        public string DefaultConString {
            get {
                return ((string)(this["DefaultConString"]));
            }
            set {
                this["DefaultConString"] = value;
            }
        }
    }
}
