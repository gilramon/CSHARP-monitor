﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Spetrotec.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2002")]
        public string Start_Port {
            get {
                return ((string)(this["Start_Port"]));
            }
            set {
                this["Start_Port"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Default_Server_Message {
            get {
                return ((string)(this["Default_Server_Message"]));
            }
            set {
                this["Default_Server_Message"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" />")]
        public global::System.Collections.Specialized.StringCollection PhoneBook {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["PhoneBook"]));
            }
            set {
                this["PhoneBook"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("COM1")]
        public string Comport_Port {
            get {
                return ((string)(this["Comport_Port"]));
            }
            set {
                this["Comport_Port"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("115200")]
        public string Comport_BaudRate {
            get {
                return ((string)(this["Comport_BaudRate"]));
            }
            set {
                this["Comport_BaudRate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("None")]
        public string Comport_Parity {
            get {
                return ((string)(this["Comport_Parity"]));
            }
            set {
                this["Comport_Parity"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("8")]
        public string Comport_DataBits {
            get {
                return ((string)(this["Comport_DataBits"]));
            }
            set {
                this["Comport_DataBits"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("One")]
        public string Comport_StopBit {
            get {
                return ((string)(this["Comport_StopBit"]));
            }
            set {
                this["Comport_StopBit"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" +
            "tring>;&lt;S1BM&gt;BAT=,2,;</string>\r\n  <string>;&lt;S1BM&gt;SPD=,5,;</string>\r\n" +
            "  <string>;&lt;S1BM&gt;POSDUR=,3,;</string>\r\n  <string>;&lt;S1BM&gt;CDC=,1111,;<" +
            "/string>\r\n  <string>;&lt;S1BM&gt;ENOUT=,1,1,;</string>\r\n  <string>;&lt;S1BM&gt;S" +
            "TATSLP=,duration value,;</string>\r\n  <string>;&lt;S1BM&gt;STAT?,;</string>\r\n  <s" +
            "tring>;&lt;S1BM&gt;MDM=,82.80.123.56,2002,;</string>\r\n  <string>;&lt;S1BM&gt;HNA" +
            "PN=,internetg,,,,;</string>\r\n  <string>;&lt;S1BM&gt;TOW=,2,3,4,;</string>\r\n  <st" +
            "ring>;&lt;S1BM&gt;TILT=,2,3,4,;</string>\r\n  <string>;S1BFR=,;</string>\r\n  <strin" +
            "g>;&lt;S1BM&gt;TD=,01/01/12,09:50:00,;</string>\r\n  <string>;&lt;S1BM&gt;NUM=,&lt" +
            ";054111111&gt;,&lt; 054222222&gt;,&lt; 054333333&gt;,;</string>\r\n  <string>;&lt;" +
            "S1BM&gt;SMSPASS=,4321,;</string>\r\n  <string>;&lt;S1BM&gt;RST=,;</string>\r\n  <str" +
            "ing>;&lt;S1BM&gt;POSANGLE=,21,;</string>\r\n  <string>;&lt;S1BM&gt;POSDISTANCE=,11" +
            ",;</string>\r\n  <string>;&lt;S1BM&gt;SETKM=,50000,;</string>\r\n  <string>;&lt;S1BM" +
            "&gt;GETLOC?,;</string>\r\n  <string>;&lt;S1BM&gt;SMSSTAT?,;</string>\r\n  <string>;&" +
            "lt;S1BM&gt;GETCONFIG?,;</string>\r\n  <string>;&lt;S1BM&gt;GPRSEN=,1,;</string>\r\n " +
            " <string>;&lt;S1BM&gt;JAMEN=,1,;</string>\r\n  <string>;&lt;S1BM&gt;JAMLEVEL=,LEVE" +
            "L,;</string>\r\n  <string>;&lt;S1BM&gt;SIRENEN=,1,;</string>\r\n  <string>;&lt;S1BM&" +
            "gt;GARAGE=,EN,;</string>\r\n  <string>;&lt;S1BM&gt;DISARM=,1,;</string>\r\n  <string" +
            ">;&lt;S1BM&gt;ARM=,1,;</string>\r\n  <string>;&lt;S1BM&gt;DOORIGDEL=,5,;</string>\r" +
            "\n  <string>;&lt;S1BM&gt;AUTOARM=,3,;</string>\r\n</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection SMS_Commands {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["SMS_Commands"]));
            }
            set {
                this["SMS_Commands"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" +
            "tring>;&lt;1234&gt;STAT?,;</string>\r\n</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection SerialPort_History {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["SerialPort_History"]));
            }
            set {
                this["SerialPort_History"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" +
            "tring>PagesToRemove</string>\r\n</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection RemovePages {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["RemovePages"]));
            }
            set {
                this["RemovePages"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string Setting {
            get {
                return ((string)(this["Setting"]));
            }
            set {
                this["Setting"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.DateTime LastRunTime {
            get {
                return ((global::System.DateTime)(this["LastRunTime"]));
            }
            set {
                this["LastRunTime"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.DateTime LastSaveSMSTime {
            get {
                return ((global::System.DateTime)(this["LastSaveSMSTime"]));
            }
            set {
                this["LastSaveSMSTime"] = value;
            }
        }
    }
}
