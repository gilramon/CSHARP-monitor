using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Text.RegularExpressions;
using Spetrotec;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace SocketServer
{


    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// 
        /// </summary>
		public AsyncCallback pfnWorkerCallBack;
        /// <summary>
        /// 
        /// </summary>
		public Socket m_socListener;
        /// <summary>
        /// 
        /// </summary>
		public Socket m_socWorker;
        private System.Windows.Forms.GroupBox groupBox_ServerSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPortNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDataTx;
        private System.Windows.Forms.Button button1;
        //TcpListener tcpListener;
        //private Thread listenThread;
        private CheckBox ListenBox;


        //TcpClient tcpClient;
        private RichTextBox txtGeneral;
        private CheckBox PauseCheck;

        private Button Clear_btn;
        //NetworkStream clientStream;

        bool New_Line = false;
        bool Show_Time;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private ToolTip toolTip1;
        private IContainer components;
        private GroupBox groupBox5;
        private CheckBox checkBox_S1Pause;
        private Button txtS1_Clear;
        private RichTextBox SerialPortLogger_TextBox;
        private GroupBox S1_Configuration;
        private GroupBox groupBox12;
        private Button button13;
        private GroupBox groupBox22;
        private Button button19;
        private GroupBox groupBox28;
        private Button button25;
        private TextBox textBox_ModemPrimeryPort;
        private TextBox textBox_ModemPrimeryHost;
        private GroupBox groupBox30;
        private TextBox textBox_ForginPassword;
        private Button button27;
        private TextBox textBox_ForginAcessPoint;
        private TextBox textBox_ForginSecondaryDNS;
        private TextBox textBox_ForginUserName;
        private TextBox textBox_ForginPrimeryDNS;
        private GroupBox groupBox29;
        private TextBox textBox_HomePassword;
        private Button button26;
        private TextBox textBox_HomeAcessPoint;
        private TextBox textBox_HomeSecondaryDNS;
        private TextBox textBox_HomeUserName;
        private TextBox textBox_HomePrimeryDNS;
        private GroupBox groupBox27;
        private Button button24;
        private GroupBox groupBox26;
        private Button button23;
        private GroupBox groupBox25;
        private Button button22;
        private GroupBox groupBox24;
        private ComboBox comboBox_DispatchSpeed;
        private Button button21;
        private GroupBox groupBox23;
        private ComboBox comboBox_KillEngine;
        private Button button20;
        private GroupBox groupBox21;
        private ComboBox comboBox_TiltTowSensState;
        private Button button18;
        private GroupBox groupBox20;
        private ComboBox comboBox_HitState;
        private Button button17;
        private GroupBox groupBox19;
        private ComboBox comboBox_ShockState;
        private Button button16;
        private GroupBox groupBox18;
        private ComboBox comboBox1_TiltState;
        private Button button15;
        private GroupBox groupBox17;
        private Button button14;
        private GroupBox groupBox11;
        private ComboBox comboBox_SleepPolicy;
        private Button button12;
        private GroupBox groupBox10;
        private ComboBox comboBox_AlarmPilicy;
        private Button button11;
        private GroupBox groupBox9;
        private DateTimePicker dateTimePicker_SetTimeDate;
        private Button button10;
        private GroupBox groupBox8;
        private ComboBox comboBox_BatThreshold;
        private Button button9;
        private GroupBox groupBox7;
        private ComboBox comboBox_OutputNum;
        private ComboBox comboBox_OutputControl;
        private Button button8;
        private ComboBox comboBox_OutputPulseLevel;
        private GroupBox groupBox6;
        private ComboBox comboBox_InputNum1;
        private ComboBox comboBox_Interupt;
        private Button button7;
        private GroupBox groupBox13;
        private Button btn_ChangePassword;
        private TextBox textBox_NewPassword;
        private GroupBox groupBox14;
        private ComboBox comboBox_SMSControl;
        private Button button_SMSControl;
        private GroupBox groupBox15;
        private ComboBox comboBox_InputIndex;
        private Button button_SetFreeText;
        private GroupBox groupBox16;
        private Button button4;
        private TabPage tabPage5;
        private TextBox maskedTextBox3_Subscriber3;
        private TextBox maskedTextBox2_Subscriber2;
        private TextBox maskedTextBox1_Subscriber1;
        private TextBox maskedTextBox_OutputDuration;
        private TextBox maskedTextBox_InputDuration;
        private TextBox maskedTextBox1;
        private TextBox TextBox_NormalStatusDuration;
        private TextBox textBox_FreeText;
        private TextBox textBox_ModemSocket;
        private TextBox textBox_ModemRetries;
        private TextBox textBox_ModemTimeOut;
        private TextBox TextBox_Odometer;
        private TextBox maskedTextBox_TowDetectNum;
        private TextBox maskedTextBox_TowWindow;
        private TextBox maskedTextBox_TowAngle;
        private TextBox maskedTextBox_TiltDetectNum;
        private TextBox maskedTextBox_TiltWindow;
        private TextBox maskedTextBox_TiltAngle;
        private TextBox maskedTextBox_ShockDetectNum;
        private TextBox maskedTextBox_ShockWindow;
        private TextBox maskedTextBox_SpeedLimit2;
        private TextBox maskedTextBox_SpeedLimit3;
        private TextBox maskedTextBox_SpeedLimit1;
        private TextBox maskedTextBox_TiltTowSens;
        private TextBox maskedTextBox_HitSensitivity;
        private TabPage tabPage6;
        private OpenFileDialog openFileDialog1;
        private CheckBox checkBox_RecordGeneral;
        private CheckBox checkBox_S1RecordLog;
        private System.Windows.Forms.Timer timer_General_100ms;
        private TextBox textBox_NumberOfOpenConnections;
        private System.Windows.Forms.Timer timer_General_1Second;
        private GroupBox gbPortSettings;
        private CheckBox checkBox_ComportOpen;
        private ComboBox cmbPortName;
        private ComboBox cmbBaudRate;
        private ComboBox cmbStopBits;
        private ComboBox cmbParity;
        private ComboBox cmbDataBits;
        private Label lblComPort;
        private Label lblStopBits;
        private Label lblBaudRate;
        private Label lblDataBits;
        private Label label3;
        private System.IO.Ports.SerialPort serialPort;
        private GroupBox groupBox_ConnectionTimedOut;
        private TextBox textBox_ConnectionTimedOut;
        private Button button_SetTimedOut;
        private TextBox textBox_CurrentTimeOut;
        private TextBox textBox_ServerOpen;
        private TabPage tabPage1;
        private TabPage tabPage4;
        private GroupBox groupBox36;
        private TextBox textBox_SMSPhoneNumber;
        private GroupBox groupBox_PhoneNumber;
        private ToolTip toolTip2;
        private CheckBox checkBox_EchoResponse;
        private GroupBox groupBox_FOTA;
        private Button button5;
        private TextBox textBox_FOTA;
        private TextBox textBox_TotalFrames1280Bytes;
        private Button button_StartFOTA;
        private Button button35;
        private ComboBox comboBox_ConnectionNumber;
        private GroupBox groupBox4;
        private Button button_SendSerialPort;
        private TabPage tabPage7;
        private Label label_TimeDate2;
        private GroupBox groupBox33;
        private Button button_AddContact;
        private CheckedListBox checkedListBox_PhoneBook;
        private GroupBox groupBox34;
        private RichTextBox richTextBox_TextSendSMS;
        private Button button_ImportToXML;
        private Button button_ExportToXML;
        private Button button_RemoveContact;
        private GroupBox groupBox37;
        private RichTextBox richTextBox_SMSConsole;
        private CheckBox checkBox_RecordSMSConsole;
        private CheckBox checkBox_PauseSMSConsole;
        private Button button_ClearSMSConsole;
        private GroupBox groupBox35;
        private RichTextBox richTextBox_ModemStatus;
        private Button button_SendSelectedSMS;
        private Button button_SendAllCheckedSMS;
        private Button button33;
        private Button button36;
        private Label label_SMSSendCharacters;
        private TextBox textBox_SerialPortRecognizePattern;
        private RichTextBox textBox_MaximumNumberReceivedRequest;
        private TextBox textBox_TotalFileLength;
        private GroupBox groupBox39;
        private Button button37;
        private Button button38;
        private Button button39;
        private Button button40;
        private Button button41;
        private CheckBox checkBox_SendSMSAsIs;
        private CheckBox checkBox1;
        private Button button_StartFOTAProcess;
        private RichTextBox textBox_IDKey;
        private CheckBox checkBox_StopLogging;
        private CheckBox checkBox_OpenPortSMS;
        private ComboBox comboBox_ComportSMS;
        private SerialPort serialPort_SMS;
        private CheckBox checkBox_DebugSMS;
        private RichTextBox richTextBox_ContactDetails;
        private Button button_SerialPortAdd;
        private ComboBox comboBox_SerialPortHistory;
        private CheckBox checkBox_SMSencrypted;
        private GroupBox GrooupBox_Encryption;
        private TextBox textBox_UnitIDForSMS;
        private Label label5;
        private TextBox textBox_CodeArrayForSMS;
        private Label label2;
        private TextBox textBox_SerialPortRecognizePattern2;
        private TextBox textBox_SerialPortRecognizePattern3;
        private Button button34;
        private Button button_Ring;
        private Button button_ReScanComPort;
        private Button button_StopwatchReset;
        private Button button_Stopwatch_Start_Stop;
        private TextBox textBox_StopWatch;
        private GroupBox groupBox_Stopwatch;
        private Button button_TimerLog;
        private CheckBox checkBox_ParseMessages;
        private GroupBox groupBox_Timer;
        private Button button_StartStopTimer;
        private Button button_ResetTimer;
        private TextBox textBox_SetTimerTime;
        private TextBox textBox_TimerTime;
        private GroupBox groupBox38;
        private Button button6;
        private Button button31;
        private RichTextBox textBox_SourceConfig;
        private Button button32;
        private ComboBox comboBox_SystemConfigType;
        private GroupBox groupBox_LoadedConfig;
        private Button button29;
        private Button button2;
        private GroupBox groupBox_Configuration;
        private Label label_Config42;
        private TextBox textBox_Config42;
        private Label label_Config41;
        private TextBox textBox_Config41;
        private Label label_Config40;
        private TextBox textBox_Config40;
        private Label label_Config39;
        private TextBox textBox_Config39;
        private TextBox textBox_UnitVersion;
        private Label label6;
        private TextBox textBox_SpeedLimit3;
        private TextBox textBox_SpeedLimit2;
        private TextBox textBox_SpeedLimit1;
        private Label label_Config38;
        private TextBox textBox_Config38;
        private Label label_Config37;
        private TextBox textBox_Config37;
        private Label label_Config36;
        private Label label_Config35;
        private TextBox textBox_Config36;
        private TextBox textBox_Config35;
        private Label label_Config34;
        private TextBox textBox_Config34;
        private Label label_Config2;
        private Label label_Config1;
        private TextBox textBox_Config2;
        private Label label_Config33;
        private Label label_Config3;
        private TextBox textBox_Config1;
        private TextBox textBox_Config3;
        private TextBox textBox_Config33;
        private Label label_Config32;
        private TextBox textBox_Config32;
        private Label label_Config31;
        private TextBox textBox_Config31;
        private TextBox textBox_ConfigUnitID;
        private Label label_Config30;
        private Label label4;
        private Label label_Config29;
        private Label label_Config28;
        private TextBox textBox_Config30;
        private TextBox textBox_Config29;
        private TextBox textBox_Config28;
        private Label label_Config27;
        private Label label_Config26;
        private Label label_Config25;
        private Label label_Config24;
        private Label label_Config23;
        private Label label_Config22;
        private Label label_Config21;
        private Label label_Config20;
        private Label label_Config19;
        private Label label_Config18;
        private Label label_Config17;
        private Label label_Config16;
        private Label label_Config15;
        private Label label_Config14;
        private Label label_Config12;
        private Label label_Config11;
        private Label label_Config10;
        private Label label_Config9;
        private Label label_Config8;
        private Label label_Config7;
        private Label label_Config6;
        private Label label_Config5;
        private Label label_Config4;
        private TextBox textBox_Config27;
        private TextBox textBox_Config26;
        private TextBox textBox_Config25;
        private TextBox textBox_Config19;
        private TextBox textBox_Config18;
        private TextBox textBox_Config17;
        private TextBox textBox_Config24;
        private TextBox textBox_Config23;
        private TextBox textBox_Config22;
        private TextBox textBox_Config21;
        private TextBox textBox_Config20;
        private TextBox textBox_Config16;
        private TextBox textBox_Config15;
        private TextBox textBox_Config14;
        private TextBox textBox_Config12;
        private TextBox textBox_Config11;
        private TextBox textBox_Config10;
        private TextBox textBox_Config9;
        private TextBox textBox_Config8;
        private TextBox textBox_Config6;
        private TextBox textBox_Config5;
        private TextBox textBox_Config4;
        private Label label_Config13;
        private TextBox textBox_Config13;
        private Button button30;
        private Button button_OpenFolder;
        private CheckBox checkBox_DeleteCommand;
        private TextBox textBox_Config7;
        private GroupBox groupBox31;
        private CheckBox checkBox_config_Bit10;
        private CheckBox checkBox_config_Bit9;
        private CheckBox checkBox_config_Bit8;
        private CheckBox checkBox_config_Bit7;
        private CheckBox checkBox_config_Bit6;
        private CheckBox checkBox_config_Bit5;
        private CheckBox checkBox_config_Bit4;
        private CheckBox checkBox_config_Bit3;
        private CheckBox checkBox_config_Bit2;
        private CheckBox checkBox_config_Bit1;
        private CheckBox checkBox_config_Bit0;
        private TabPage tabPage3;
        private TabPage tabPage8;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Button button_ScreenShot;
        private ListBox listBox_SMSCommands;
        private TextBox textBox_SendSerialPort;
        private TextBox textBox_graph_XY;
        private Button button_ResetGraphs;
        private Button Button_Export_excel;
        private Button button_GraphPause;
        private Button button_OpenFolder2;
        private HelpProvider helpProvider1;
        private TabPage tabPage9;
        private Button button43;
        private Button button_ClientClose;
        private Button button_ClientConnect;
        private Button button3;
        private RichTextBox richTextBox_ClientTx;
        private TextBox textBox_ClientPort;
        private TextBox textBox_ClientIP;
        private Label label8;
        private Label label7;
        private Label label10;
        private Label label9;
        private Button button_ClearRx;
        private RichTextBox richTextBox_ClientRx;
        private ListBox listBox_Charts;
        private TextBox textBox_ServerActive;

        //bool m_Exit = false;

        /// <summary> Convert a string of hex digits (ex: E4 CA B2) to a byte array. </summary>
        /// <param name="s"> The string containing the hex digits (with or without spaces). </param>
        /// <returns> Returns an array of bytes. </returns>
        private byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
            {
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            }
            return buffer;
        }

        /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
        /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
        /// <returns> Returns a well formatted string of hex digits with spacing. </returns>
        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
            {
                if (b == 0)
                {
                    //sb.Append("00 ");
                }
                else
                {
                    sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
                }
            }
            return sb.ToString().ToUpper();
        }


        class LogClass
        {
            public string msg { get; set; }
            public Color i_Color { get; set; }
            public Color i_TextBackgroundColor { get; set; }
        }

        private void Show_WebBrowserUrl(string i_Url)
        {
            try
            {
                Uri url = new Uri(i_Url);



            }
            catch (Exception ex)
            {
                ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), true, true);

            }

            return;

        }





        /// <summary>
        /// 
        /// </summary>
        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            try
            {
                //if( disposing )
                //{
                //    //if (components != null) 
                //    //{
                //    //    components.Dispose();
                //    //}
                //}

                base.Dispose(disposing);

                //if (this.tcpListener != null)
                //{
                //    //this.tcpListener.Server.Disconnect(false);
                //    if (this.clientStream != null)
                //    {
                //        this.clientStream.Close();
                //    }
                //    this.tcpListener.Server.Close();
                //    this.tcpListener.Stop();

                //}

                //if (listenThread != null)
                //{
                //    listenThread.Abort();
                //    m_Exit = true;

                //}

                if (m_Server != null)
                {
                    m_Server.Close_Server();
                }


            }
            catch
            {
            }


        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox_ServerSettings = new System.Windows.Forms.GroupBox();
            this.textBox_ServerOpen = new System.Windows.Forms.TextBox();
            this.textBox_ServerActive = new System.Windows.Forms.TextBox();
            this.txtPortNo = new System.Windows.Forms.TextBox();
            this.textBox_NumberOfOpenConnections = new System.Windows.Forms.TextBox();
            this.ListenBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_ConnectionNumber = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDataTx = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_StopLogging = new System.Windows.Forms.CheckBox();
            this.txtGeneral = new System.Windows.Forms.RichTextBox();
            this.checkBox_RecordGeneral = new System.Windows.Forms.CheckBox();
            this.PauseCheck = new System.Windows.Forms.CheckBox();
            this.Clear_btn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox_Timer = new System.Windows.Forms.GroupBox();
            this.textBox_TimerTime = new System.Windows.Forms.TextBox();
            this.button_StartStopTimer = new System.Windows.Forms.Button();
            this.button_ResetTimer = new System.Windows.Forms.Button();
            this.textBox_SetTimerTime = new System.Windows.Forms.TextBox();
            this.groupBox_Stopwatch = new System.Windows.Forms.GroupBox();
            this.button_TimerLog = new System.Windows.Forms.Button();
            this.button_Stopwatch_Start_Stop = new System.Windows.Forms.Button();
            this.button_StopwatchReset = new System.Windows.Forms.Button();
            this.textBox_StopWatch = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_SendSerialPort = new System.Windows.Forms.TextBox();
            this.checkBox_DeleteCommand = new System.Windows.Forms.CheckBox();
            this.button_SerialPortAdd = new System.Windows.Forms.Button();
            this.comboBox_SerialPortHistory = new System.Windows.Forms.ComboBox();
            this.button_SendSerialPort = new System.Windows.Forms.Button();
            this.gbPortSettings = new System.Windows.Forms.GroupBox();
            this.button_ReScanComPort = new System.Windows.Forms.Button();
            this.checkBox_ComportOpen = new System.Windows.Forms.CheckBox();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.lblComPort = new System.Windows.Forms.Label();
            this.lblStopBits = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.lblDataBits = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button_OpenFolder = new System.Windows.Forms.Button();
            this.textBox_SerialPortRecognizePattern3 = new System.Windows.Forms.TextBox();
            this.textBox_SerialPortRecognizePattern2 = new System.Windows.Forms.TextBox();
            this.textBox_SerialPortRecognizePattern = new System.Windows.Forms.TextBox();
            this.checkBox_S1RecordLog = new System.Windows.Forms.CheckBox();
            this.checkBox_S1Pause = new System.Windows.Forms.CheckBox();
            this.txtS1_Clear = new System.Windows.Forms.Button();
            this.SerialPortLogger_TextBox = new System.Windows.Forms.RichTextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.button32 = new System.Windows.Forms.Button();
            this.groupBox38 = new System.Windows.Forms.GroupBox();
            this.button29 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.textBox_SourceConfig = new System.Windows.Forms.RichTextBox();
            this.groupBox_LoadedConfig = new System.Windows.Forms.GroupBox();
            this.groupBox_Configuration = new System.Windows.Forms.GroupBox();
            this.label_Config42 = new System.Windows.Forms.Label();
            this.textBox_Config42 = new System.Windows.Forms.TextBox();
            this.label_Config41 = new System.Windows.Forms.Label();
            this.textBox_Config41 = new System.Windows.Forms.TextBox();
            this.label_Config40 = new System.Windows.Forms.Label();
            this.textBox_Config40 = new System.Windows.Forms.TextBox();
            this.label_Config39 = new System.Windows.Forms.Label();
            this.textBox_Config39 = new System.Windows.Forms.TextBox();
            this.textBox_UnitVersion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_SpeedLimit3 = new System.Windows.Forms.TextBox();
            this.textBox_SpeedLimit2 = new System.Windows.Forms.TextBox();
            this.textBox_SpeedLimit1 = new System.Windows.Forms.TextBox();
            this.label_Config38 = new System.Windows.Forms.Label();
            this.textBox_Config38 = new System.Windows.Forms.TextBox();
            this.label_Config37 = new System.Windows.Forms.Label();
            this.textBox_Config37 = new System.Windows.Forms.TextBox();
            this.label_Config36 = new System.Windows.Forms.Label();
            this.label_Config35 = new System.Windows.Forms.Label();
            this.textBox_Config36 = new System.Windows.Forms.TextBox();
            this.textBox_Config35 = new System.Windows.Forms.TextBox();
            this.label_Config34 = new System.Windows.Forms.Label();
            this.textBox_Config34 = new System.Windows.Forms.TextBox();
            this.label_Config2 = new System.Windows.Forms.Label();
            this.label_Config1 = new System.Windows.Forms.Label();
            this.textBox_Config2 = new System.Windows.Forms.TextBox();
            this.label_Config33 = new System.Windows.Forms.Label();
            this.label_Config3 = new System.Windows.Forms.Label();
            this.textBox_Config1 = new System.Windows.Forms.TextBox();
            this.textBox_Config3 = new System.Windows.Forms.TextBox();
            this.textBox_Config33 = new System.Windows.Forms.TextBox();
            this.label_Config32 = new System.Windows.Forms.Label();
            this.textBox_Config32 = new System.Windows.Forms.TextBox();
            this.label_Config31 = new System.Windows.Forms.Label();
            this.textBox_Config31 = new System.Windows.Forms.TextBox();
            this.groupBox31 = new System.Windows.Forms.GroupBox();
            this.checkBox_config_Bit10 = new System.Windows.Forms.CheckBox();
            this.checkBox_config_Bit9 = new System.Windows.Forms.CheckBox();
            this.checkBox_config_Bit8 = new System.Windows.Forms.CheckBox();
            this.checkBox_config_Bit7 = new System.Windows.Forms.CheckBox();
            this.checkBox_config_Bit6 = new System.Windows.Forms.CheckBox();
            this.checkBox_config_Bit5 = new System.Windows.Forms.CheckBox();
            this.checkBox_config_Bit4 = new System.Windows.Forms.CheckBox();
            this.checkBox_config_Bit3 = new System.Windows.Forms.CheckBox();
            this.checkBox_config_Bit2 = new System.Windows.Forms.CheckBox();
            this.checkBox_config_Bit1 = new System.Windows.Forms.CheckBox();
            this.checkBox_config_Bit0 = new System.Windows.Forms.CheckBox();
            this.textBox_ConfigUnitID = new System.Windows.Forms.TextBox();
            this.label_Config30 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_Config29 = new System.Windows.Forms.Label();
            this.label_Config28 = new System.Windows.Forms.Label();
            this.textBox_Config30 = new System.Windows.Forms.TextBox();
            this.textBox_Config29 = new System.Windows.Forms.TextBox();
            this.textBox_Config28 = new System.Windows.Forms.TextBox();
            this.label_Config27 = new System.Windows.Forms.Label();
            this.label_Config26 = new System.Windows.Forms.Label();
            this.label_Config25 = new System.Windows.Forms.Label();
            this.label_Config24 = new System.Windows.Forms.Label();
            this.label_Config23 = new System.Windows.Forms.Label();
            this.label_Config22 = new System.Windows.Forms.Label();
            this.label_Config21 = new System.Windows.Forms.Label();
            this.label_Config20 = new System.Windows.Forms.Label();
            this.label_Config19 = new System.Windows.Forms.Label();
            this.label_Config18 = new System.Windows.Forms.Label();
            this.label_Config17 = new System.Windows.Forms.Label();
            this.label_Config16 = new System.Windows.Forms.Label();
            this.label_Config15 = new System.Windows.Forms.Label();
            this.label_Config14 = new System.Windows.Forms.Label();
            this.label_Config12 = new System.Windows.Forms.Label();
            this.label_Config11 = new System.Windows.Forms.Label();
            this.label_Config10 = new System.Windows.Forms.Label();
            this.label_Config9 = new System.Windows.Forms.Label();
            this.label_Config8 = new System.Windows.Forms.Label();
            this.label_Config7 = new System.Windows.Forms.Label();
            this.label_Config6 = new System.Windows.Forms.Label();
            this.label_Config5 = new System.Windows.Forms.Label();
            this.label_Config4 = new System.Windows.Forms.Label();
            this.textBox_Config27 = new System.Windows.Forms.TextBox();
            this.textBox_Config26 = new System.Windows.Forms.TextBox();
            this.textBox_Config25 = new System.Windows.Forms.TextBox();
            this.textBox_Config19 = new System.Windows.Forms.TextBox();
            this.textBox_Config18 = new System.Windows.Forms.TextBox();
            this.textBox_Config17 = new System.Windows.Forms.TextBox();
            this.textBox_Config24 = new System.Windows.Forms.TextBox();
            this.textBox_Config23 = new System.Windows.Forms.TextBox();
            this.textBox_Config22 = new System.Windows.Forms.TextBox();
            this.textBox_Config21 = new System.Windows.Forms.TextBox();
            this.textBox_Config20 = new System.Windows.Forms.TextBox();
            this.textBox_Config16 = new System.Windows.Forms.TextBox();
            this.textBox_Config15 = new System.Windows.Forms.TextBox();
            this.textBox_Config14 = new System.Windows.Forms.TextBox();
            this.textBox_Config12 = new System.Windows.Forms.TextBox();
            this.textBox_Config11 = new System.Windows.Forms.TextBox();
            this.textBox_Config10 = new System.Windows.Forms.TextBox();
            this.textBox_Config9 = new System.Windows.Forms.TextBox();
            this.textBox_Config8 = new System.Windows.Forms.TextBox();
            this.textBox_Config6 = new System.Windows.Forms.TextBox();
            this.textBox_Config5 = new System.Windows.Forms.TextBox();
            this.textBox_Config4 = new System.Windows.Forms.TextBox();
            this.textBox_Config7 = new System.Windows.Forms.TextBox();
            this.label_Config13 = new System.Windows.Forms.Label();
            this.textBox_Config13 = new System.Windows.Forms.TextBox();
            this.button30 = new System.Windows.Forms.Button();
            this.comboBox_SystemConfigType = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox_ParseMessages = new System.Windows.Forms.CheckBox();
            this.textBox_IDKey = new System.Windows.Forms.RichTextBox();
            this.label_TimeDate2 = new System.Windows.Forms.Label();
            this.groupBox_FOTA = new System.Windows.Forms.GroupBox();
            this.button_StartFOTAProcess = new System.Windows.Forms.Button();
            this.textBox_TotalFileLength = new System.Windows.Forms.TextBox();
            this.textBox_MaximumNumberReceivedRequest = new System.Windows.Forms.RichTextBox();
            this.button35 = new System.Windows.Forms.Button();
            this.button_StartFOTA = new System.Windows.Forms.Button();
            this.textBox_TotalFrames1280Bytes = new System.Windows.Forms.TextBox();
            this.textBox_FOTA = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.checkBox_EchoResponse = new System.Windows.Forms.CheckBox();
            this.groupBox_ConnectionTimedOut = new System.Windows.Forms.GroupBox();
            this.textBox_CurrentTimeOut = new System.Windows.Forms.TextBox();
            this.button_SetTimedOut = new System.Windows.Forms.Button();
            this.textBox_ConnectionTimedOut = new System.Windows.Forms.TextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.groupBox39 = new System.Windows.Forms.GroupBox();
            this.listBox_SMSCommands = new System.Windows.Forms.ListBox();
            this.button37 = new System.Windows.Forms.Button();
            this.button38 = new System.Windows.Forms.Button();
            this.button39 = new System.Windows.Forms.Button();
            this.button40 = new System.Windows.Forms.Button();
            this.button41 = new System.Windows.Forms.Button();
            this.groupBox37 = new System.Windows.Forms.GroupBox();
            this.richTextBox_SMSConsole = new System.Windows.Forms.RichTextBox();
            this.checkBox_RecordSMSConsole = new System.Windows.Forms.CheckBox();
            this.checkBox_PauseSMSConsole = new System.Windows.Forms.CheckBox();
            this.button_ClearSMSConsole = new System.Windows.Forms.Button();
            this.groupBox35 = new System.Windows.Forms.GroupBox();
            this.checkBox_DebugSMS = new System.Windows.Forms.CheckBox();
            this.checkBox_OpenPortSMS = new System.Windows.Forms.CheckBox();
            this.button36 = new System.Windows.Forms.Button();
            this.comboBox_ComportSMS = new System.Windows.Forms.ComboBox();
            this.richTextBox_ModemStatus = new System.Windows.Forms.RichTextBox();
            this.groupBox34 = new System.Windows.Forms.GroupBox();
            this.button_Ring = new System.Windows.Forms.Button();
            this.GrooupBox_Encryption = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_CodeArrayForSMS = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_UnitIDForSMS = new System.Windows.Forms.TextBox();
            this.checkBox_SMSencrypted = new System.Windows.Forms.CheckBox();
            this.checkBox_SendSMSAsIs = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label_SMSSendCharacters = new System.Windows.Forms.Label();
            this.button_SendSelectedSMS = new System.Windows.Forms.Button();
            this.button_SendAllCheckedSMS = new System.Windows.Forms.Button();
            this.richTextBox_TextSendSMS = new System.Windows.Forms.RichTextBox();
            this.groupBox33 = new System.Windows.Forms.GroupBox();
            this.button34 = new System.Windows.Forms.Button();
            this.richTextBox_ContactDetails = new System.Windows.Forms.RichTextBox();
            this.button33 = new System.Windows.Forms.Button();
            this.button_ImportToXML = new System.Windows.Forms.Button();
            this.button_ExportToXML = new System.Windows.Forms.Button();
            this.button_RemoveContact = new System.Windows.Forms.Button();
            this.button_AddContact = new System.Windows.Forms.Button();
            this.checkedListBox_PhoneBook = new System.Windows.Forms.CheckedListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button_OpenFolder2 = new System.Windows.Forms.Button();
            this.button_GraphPause = new System.Windows.Forms.Button();
            this.Button_Export_excel = new System.Windows.Forms.Button();
            this.button_ResetGraphs = new System.Windows.Forms.Button();
            this.textBox_graph_XY = new System.Windows.Forms.TextBox();
            this.button_ScreenShot = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button_ClearRx = new System.Windows.Forms.Button();
            this.richTextBox_ClientRx = new System.Windows.Forms.RichTextBox();
            this.button43 = new System.Windows.Forms.Button();
            this.button_ClientClose = new System.Windows.Forms.Button();
            this.button_ClientConnect = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox_ClientTx = new System.Windows.Forms.RichTextBox();
            this.textBox_ClientPort = new System.Windows.Forms.TextBox();
            this.textBox_ClientIP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.S1_Configuration = new System.Windows.Forms.GroupBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.TextBox_Odometer = new System.Windows.Forms.TextBox();
            this.button19 = new System.Windows.Forms.Button();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.textBox_ModemSocket = new System.Windows.Forms.TextBox();
            this.textBox_ModemRetries = new System.Windows.Forms.TextBox();
            this.textBox_ModemTimeOut = new System.Windows.Forms.TextBox();
            this.button25 = new System.Windows.Forms.Button();
            this.textBox_ModemPrimeryPort = new System.Windows.Forms.TextBox();
            this.textBox_ModemPrimeryHost = new System.Windows.Forms.TextBox();
            this.groupBox30 = new System.Windows.Forms.GroupBox();
            this.textBox_ForginPassword = new System.Windows.Forms.TextBox();
            this.button27 = new System.Windows.Forms.Button();
            this.textBox_ForginAcessPoint = new System.Windows.Forms.TextBox();
            this.textBox_ForginSecondaryDNS = new System.Windows.Forms.TextBox();
            this.textBox_ForginUserName = new System.Windows.Forms.TextBox();
            this.textBox_ForginPrimeryDNS = new System.Windows.Forms.TextBox();
            this.groupBox29 = new System.Windows.Forms.GroupBox();
            this.textBox_HomePassword = new System.Windows.Forms.TextBox();
            this.button26 = new System.Windows.Forms.Button();
            this.textBox_HomeAcessPoint = new System.Windows.Forms.TextBox();
            this.textBox_HomeSecondaryDNS = new System.Windows.Forms.TextBox();
            this.textBox_HomeUserName = new System.Windows.Forms.TextBox();
            this.textBox_HomePrimeryDNS = new System.Windows.Forms.TextBox();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox1 = new System.Windows.Forms.TextBox();
            this.button24 = new System.Windows.Forms.Button();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.TextBox_NormalStatusDuration = new System.Windows.Forms.TextBox();
            this.button23 = new System.Windows.Forms.Button();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_SpeedLimit2 = new System.Windows.Forms.TextBox();
            this.maskedTextBox_SpeedLimit3 = new System.Windows.Forms.TextBox();
            this.maskedTextBox_SpeedLimit1 = new System.Windows.Forms.TextBox();
            this.button22 = new System.Windows.Forms.Button();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.comboBox_DispatchSpeed = new System.Windows.Forms.ComboBox();
            this.button21 = new System.Windows.Forms.Button();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.comboBox_KillEngine = new System.Windows.Forms.ComboBox();
            this.button20 = new System.Windows.Forms.Button();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_TiltTowSens = new System.Windows.Forms.TextBox();
            this.comboBox_TiltTowSensState = new System.Windows.Forms.ComboBox();
            this.button18 = new System.Windows.Forms.Button();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_HitSensitivity = new System.Windows.Forms.TextBox();
            this.comboBox_HitState = new System.Windows.Forms.ComboBox();
            this.button17 = new System.Windows.Forms.Button();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_ShockDetectNum = new System.Windows.Forms.TextBox();
            this.maskedTextBox_ShockWindow = new System.Windows.Forms.TextBox();
            this.comboBox_ShockState = new System.Windows.Forms.ComboBox();
            this.button16 = new System.Windows.Forms.Button();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_TiltDetectNum = new System.Windows.Forms.TextBox();
            this.maskedTextBox_TiltWindow = new System.Windows.Forms.TextBox();
            this.maskedTextBox_TiltAngle = new System.Windows.Forms.TextBox();
            this.comboBox1_TiltState = new System.Windows.Forms.ComboBox();
            this.button15 = new System.Windows.Forms.Button();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_TowDetectNum = new System.Windows.Forms.TextBox();
            this.maskedTextBox_TowWindow = new System.Windows.Forms.TextBox();
            this.maskedTextBox_TowAngle = new System.Windows.Forms.TextBox();
            this.button14 = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.comboBox_SleepPolicy = new System.Windows.Forms.ComboBox();
            this.button12 = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.comboBox_AlarmPilicy = new System.Windows.Forms.ComboBox();
            this.button11 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_SetTimeDate = new System.Windows.Forms.DateTimePicker();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.comboBox_BatThreshold = new System.Windows.Forms.ComboBox();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_OutputDuration = new System.Windows.Forms.TextBox();
            this.comboBox_OutputNum = new System.Windows.Forms.ComboBox();
            this.comboBox_OutputControl = new System.Windows.Forms.ComboBox();
            this.button8 = new System.Windows.Forms.Button();
            this.comboBox_OutputPulseLevel = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_InputDuration = new System.Windows.Forms.TextBox();
            this.comboBox_InputNum1 = new System.Windows.Forms.ComboBox();
            this.comboBox_Interupt = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.btn_ChangePassword = new System.Windows.Forms.Button();
            this.textBox_NewPassword = new System.Windows.Forms.TextBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.comboBox_SMSControl = new System.Windows.Forms.ComboBox();
            this.button_SMSControl = new System.Windows.Forms.Button();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.textBox_FreeText = new System.Windows.Forms.TextBox();
            this.comboBox_InputIndex = new System.Windows.Forms.ComboBox();
            this.button_SetFreeText = new System.Windows.Forms.Button();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox3_Subscriber3 = new System.Windows.Forms.TextBox();
            this.maskedTextBox2_Subscriber2 = new System.Windows.Forms.TextBox();
            this.maskedTextBox1_Subscriber1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.textBox_SMSPhoneNumber = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer_General_100ms = new System.Windows.Forms.Timer(this.components);
            this.timer_General_1Second = new System.Windows.Forms.Timer(this.components);
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.groupBox36 = new System.Windows.Forms.GroupBox();
            this.groupBox_PhoneNumber = new System.Windows.Forms.GroupBox();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.serialPort_SMS = new System.IO.Ports.SerialPort(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.listBox_Charts = new System.Windows.Forms.ListBox();
            this.groupBox_ServerSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox_Timer.SuspendLayout();
            this.groupBox_Stopwatch.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbPortSettings.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox38.SuspendLayout();
            this.groupBox_LoadedConfig.SuspendLayout();
            this.groupBox_Configuration.SuspendLayout();
            this.groupBox31.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox_FOTA.SuspendLayout();
            this.groupBox_ConnectionTimedOut.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.groupBox39.SuspendLayout();
            this.groupBox37.SuspendLayout();
            this.groupBox35.SuspendLayout();
            this.groupBox34.SuspendLayout();
            this.GrooupBox_Encryption.SuspendLayout();
            this.groupBox33.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage9.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.S1_Configuration.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox28.SuspendLayout();
            this.groupBox30.SuspendLayout();
            this.groupBox29.SuspendLayout();
            this.groupBox27.SuspendLayout();
            this.groupBox26.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox_PhoneNumber.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_ServerSettings
            // 
            this.groupBox_ServerSettings.Controls.Add(this.textBox_ServerOpen);
            this.groupBox_ServerSettings.Controls.Add(this.textBox_ServerActive);
            this.groupBox_ServerSettings.Controls.Add(this.txtPortNo);
            this.groupBox_ServerSettings.Controls.Add(this.textBox_NumberOfOpenConnections);
            this.groupBox_ServerSettings.Controls.Add(this.ListenBox);
            this.groupBox_ServerSettings.Controls.Add(this.label1);
            this.groupBox_ServerSettings.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_ServerSettings.Location = new System.Drawing.Point(6, 3);
            this.groupBox_ServerSettings.Name = "groupBox_ServerSettings";
            this.groupBox_ServerSettings.Size = new System.Drawing.Size(414, 58);
            this.groupBox_ServerSettings.TabIndex = 0;
            this.groupBox_ServerSettings.TabStop = false;
            this.groupBox_ServerSettings.Text = "Server Settings";
            // 
            // textBox_ServerOpen
            // 
            this.textBox_ServerOpen.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ServerOpen.ForeColor = System.Drawing.Color.White;
            this.textBox_ServerOpen.Location = new System.Drawing.Point(276, 17);
            this.textBox_ServerOpen.Multiline = true;
            this.textBox_ServerOpen.Name = "textBox_ServerOpen";
            this.textBox_ServerOpen.ReadOnly = true;
            this.textBox_ServerOpen.Size = new System.Drawing.Size(89, 25);
            this.textBox_ServerOpen.TabIndex = 7;
            this.textBox_ServerOpen.Text = "Connected";
            this.toolTip1.SetToolTip(this.textBox_ServerOpen, "Number of open connections");
            // 
            // textBox_ServerActive
            // 
            this.textBox_ServerActive.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ServerActive.ForeColor = System.Drawing.Color.White;
            this.textBox_ServerActive.Location = new System.Drawing.Point(210, 17);
            this.textBox_ServerActive.Multiline = true;
            this.textBox_ServerActive.Name = "textBox_ServerActive";
            this.textBox_ServerActive.ReadOnly = true;
            this.textBox_ServerActive.Size = new System.Drawing.Size(60, 25);
            this.textBox_ServerActive.TabIndex = 6;
            this.textBox_ServerActive.Text = "Active";
            this.toolTip1.SetToolTip(this.textBox_ServerActive, "Number of open connections");
            // 
            // txtPortNo
            // 
            this.txtPortNo.Location = new System.Drawing.Point(86, 16);
            this.txtPortNo.Name = "txtPortNo";
            this.txtPortNo.Size = new System.Drawing.Size(40, 23);
            this.txtPortNo.TabIndex = 1;
            this.txtPortNo.Text = "2002";
            this.txtPortNo.TextChanged += new System.EventHandler(this.txtPortNo_TextChanged);
            // 
            // textBox_NumberOfOpenConnections
            // 
            this.textBox_NumberOfOpenConnections.ForeColor = System.Drawing.Color.White;
            this.textBox_NumberOfOpenConnections.Location = new System.Drawing.Point(371, 17);
            this.textBox_NumberOfOpenConnections.Name = "textBox_NumberOfOpenConnections";
            this.textBox_NumberOfOpenConnections.ReadOnly = true;
            this.textBox_NumberOfOpenConnections.Size = new System.Drawing.Size(25, 23);
            this.textBox_NumberOfOpenConnections.TabIndex = 5;
            this.toolTip1.SetToolTip(this.textBox_NumberOfOpenConnections, "Number of open connections");
            this.textBox_NumberOfOpenConnections.TextChanged += new System.EventHandler(this.textBox_NumberOfOpenConnections_TextChanged);
            // 
            // ListenBox
            // 
            this.ListenBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.ListenBox.AutoSize = true;
            this.ListenBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListenBox.Location = new System.Drawing.Point(132, 15);
            this.ListenBox.Name = "ListenBox";
            this.ListenBox.Size = new System.Drawing.Size(74, 28);
            this.ListenBox.TabIndex = 4;
            this.ListenBox.Text = "Listening";
            this.ListenBox.UseVisualStyleBackColor = true;
            this.ListenBox.CheckedChanged += new System.EventHandler(this.ListenBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port Number:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_ConnectionNumber);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txtDataTx);
            this.groupBox2.Location = new System.Drawing.Point(3, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 217);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Send Data";
            // 
            // comboBox_ConnectionNumber
            // 
            this.comboBox_ConnectionNumber.FormattingEnabled = true;
            this.comboBox_ConnectionNumber.Location = new System.Drawing.Point(84, 188);
            this.comboBox_ConnectionNumber.Name = "comboBox_ConnectionNumber";
            this.comboBox_ConnectionNumber.Size = new System.Drawing.Size(170, 26);
            this.comboBox_ConnectionNumber.TabIndex = 2;
            this.comboBox_ConnectionNumber.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(14, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Send";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDataTx
            // 
            this.txtDataTx.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDataTx.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataTx.Location = new System.Drawing.Point(14, 19);
            this.txtDataTx.Multiline = true;
            this.txtDataTx.Name = "txtDataTx";
            this.txtDataTx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDataTx.Size = new System.Drawing.Size(257, 162);
            this.txtDataTx.TabIndex = 0;
            this.txtDataTx.TextChanged += new System.EventHandler(this.txtDataTx_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_StopLogging);
            this.groupBox3.Controls.Add(this.txtGeneral);
            this.groupBox3.Controls.Add(this.checkBox_RecordGeneral);
            this.groupBox3.Controls.Add(this.PauseCheck);
            this.groupBox3.Controls.Add(this.Clear_btn);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(282, 65);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(659, 665);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "General Console";
            // 
            // checkBox_StopLogging
            // 
            this.checkBox_StopLogging.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_StopLogging.AutoSize = true;
            this.checkBox_StopLogging.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_StopLogging.Location = new System.Drawing.Point(305, 629);
            this.checkBox_StopLogging.Name = "checkBox_StopLogging";
            this.checkBox_StopLogging.Size = new System.Drawing.Size(106, 26);
            this.checkBox_StopLogging.TabIndex = 8;
            this.checkBox_StopLogging.Text = "Stop Printing";
            this.checkBox_StopLogging.UseVisualStyleBackColor = true;
            // 
            // txtGeneral
            // 
            this.txtGeneral.EnableAutoDragDrop = true;
            this.txtGeneral.Location = new System.Drawing.Point(6, 16);
            this.txtGeneral.Name = "txtGeneral";
            this.txtGeneral.Size = new System.Drawing.Size(647, 607);
            this.txtGeneral.TabIndex = 0;
            this.txtGeneral.Text = "";
            this.txtGeneral.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // checkBox_RecordGeneral
            // 
            this.checkBox_RecordGeneral.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_RecordGeneral.AutoSize = true;
            this.checkBox_RecordGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_RecordGeneral.Location = new System.Drawing.Point(417, 629);
            this.checkBox_RecordGeneral.Name = "checkBox_RecordGeneral";
            this.checkBox_RecordGeneral.Size = new System.Drawing.Size(99, 26);
            this.checkBox_RecordGeneral.TabIndex = 7;
            this.checkBox_RecordGeneral.Text = "Record Log";
            this.checkBox_RecordGeneral.UseVisualStyleBackColor = true;
            this.checkBox_RecordGeneral.CheckedChanged += new System.EventHandler(this.checkBox_RecordGeneral_CheckedChanged);
            // 
            // PauseCheck
            // 
            this.PauseCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.PauseCheck.AutoSize = true;
            this.PauseCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PauseCheck.Location = new System.Drawing.Point(522, 629);
            this.PauseCheck.Name = "PauseCheck";
            this.PauseCheck.Size = new System.Drawing.Size(62, 26);
            this.PauseCheck.TabIndex = 5;
            this.PauseCheck.Text = "Pause";
            this.PauseCheck.UseVisualStyleBackColor = true;
            // 
            // Clear_btn
            // 
            this.Clear_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear_btn.Location = new System.Drawing.Point(590, 629);
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.Size = new System.Drawing.Size(62, 26);
            this.Clear_btn.TabIndex = 6;
            this.Clear_btn.Text = "Clear";
            this.Clear_btn.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Location = new System.Drawing.Point(4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1908, 967);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox_Timer);
            this.tabPage2.Controls.Add(this.groupBox_Stopwatch);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.gbPortSettings);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1900, 936);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Serial Port";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox_Timer
            // 
            this.groupBox_Timer.Controls.Add(this.textBox_TimerTime);
            this.groupBox_Timer.Controls.Add(this.button_StartStopTimer);
            this.groupBox_Timer.Controls.Add(this.button_ResetTimer);
            this.groupBox_Timer.Controls.Add(this.textBox_SetTimerTime);
            this.groupBox_Timer.Location = new System.Drawing.Point(6, 610);
            this.groupBox_Timer.Name = "groupBox_Timer";
            this.groupBox_Timer.Size = new System.Drawing.Size(270, 111);
            this.groupBox_Timer.TabIndex = 107;
            this.groupBox_Timer.TabStop = false;
            this.groupBox_Timer.Text = "Timer";
            // 
            // textBox_TimerTime
            // 
            this.textBox_TimerTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TimerTime.Location = new System.Drawing.Point(119, 66);
            this.textBox_TimerTime.Name = "textBox_TimerTime";
            this.textBox_TimerTime.ReadOnly = true;
            this.textBox_TimerTime.Size = new System.Drawing.Size(70, 31);
            this.textBox_TimerTime.TabIndex = 106;
            this.textBox_TimerTime.Text = "0";
            // 
            // button_StartStopTimer
            // 
            this.button_StartStopTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_StartStopTimer.Location = new System.Drawing.Point(9, 23);
            this.button_StartStopTimer.Name = "button_StartStopTimer";
            this.button_StartStopTimer.Size = new System.Drawing.Size(110, 37);
            this.button_StartStopTimer.TabIndex = 104;
            this.button_StartStopTimer.Text = "Start/Stop";
            this.button_StartStopTimer.UseVisualStyleBackColor = true;
            this.button_StartStopTimer.Click += new System.EventHandler(this.button_StartStopTimer_Click);
            // 
            // button_ResetTimer
            // 
            this.button_ResetTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ResetTimer.Location = new System.Drawing.Point(119, 23);
            this.button_ResetTimer.Name = "button_ResetTimer";
            this.button_ResetTimer.Size = new System.Drawing.Size(110, 37);
            this.button_ResetTimer.TabIndex = 105;
            this.button_ResetTimer.Text = "Reset (0)";
            this.button_ResetTimer.UseVisualStyleBackColor = true;
            this.button_ResetTimer.Click += new System.EventHandler(this.button_ResetTimer_Click);
            // 
            // textBox_SetTimerTime
            // 
            this.textBox_SetTimerTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SetTimerTime.Location = new System.Drawing.Point(9, 66);
            this.textBox_SetTimerTime.Name = "textBox_SetTimerTime";
            this.textBox_SetTimerTime.Size = new System.Drawing.Size(104, 31);
            this.textBox_SetTimerTime.TabIndex = 103;
            this.textBox_SetTimerTime.Text = "0";
            // 
            // groupBox_Stopwatch
            // 
            this.groupBox_Stopwatch.Controls.Add(this.button_TimerLog);
            this.groupBox_Stopwatch.Controls.Add(this.button_Stopwatch_Start_Stop);
            this.groupBox_Stopwatch.Controls.Add(this.button_StopwatchReset);
            this.groupBox_Stopwatch.Controls.Add(this.textBox_StopWatch);
            this.groupBox_Stopwatch.Location = new System.Drawing.Point(6, 492);
            this.groupBox_Stopwatch.Name = "groupBox_Stopwatch";
            this.groupBox_Stopwatch.Size = new System.Drawing.Size(270, 111);
            this.groupBox_Stopwatch.TabIndex = 106;
            this.groupBox_Stopwatch.TabStop = false;
            this.groupBox_Stopwatch.Text = "Stopwatch";
            // 
            // button_TimerLog
            // 
            this.button_TimerLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_TimerLog.Location = new System.Drawing.Point(189, 23);
            this.button_TimerLog.Name = "button_TimerLog";
            this.button_TimerLog.Size = new System.Drawing.Size(75, 37);
            this.button_TimerLog.TabIndex = 106;
            this.button_TimerLog.Text = "Log ->";
            this.toolTip2.SetToolTip(this.button_TimerLog, "Print the elapsed time to the terminal");
            this.toolTip1.SetToolTip(this.button_TimerLog, "Print the elapsed time to the terminal ");
            this.button_TimerLog.UseVisualStyleBackColor = true;
            this.button_TimerLog.Click += new System.EventHandler(this.button_TimerLog_Click);
            // 
            // button_Stopwatch_Start_Stop
            // 
            this.button_Stopwatch_Start_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Stopwatch_Start_Stop.Location = new System.Drawing.Point(9, 23);
            this.button_Stopwatch_Start_Stop.Name = "button_Stopwatch_Start_Stop";
            this.button_Stopwatch_Start_Stop.Size = new System.Drawing.Size(110, 37);
            this.button_Stopwatch_Start_Stop.TabIndex = 104;
            this.button_Stopwatch_Start_Stop.Text = "Start/Stop";
            this.button_Stopwatch_Start_Stop.UseVisualStyleBackColor = true;
            this.button_Stopwatch_Start_Stop.Click += new System.EventHandler(this.button_Stopwatch_Start_Stop_Click);
            // 
            // button_StopwatchReset
            // 
            this.button_StopwatchReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_StopwatchReset.Location = new System.Drawing.Point(119, 23);
            this.button_StopwatchReset.Name = "button_StopwatchReset";
            this.button_StopwatchReset.Size = new System.Drawing.Size(70, 37);
            this.button_StopwatchReset.TabIndex = 105;
            this.button_StopwatchReset.Text = "Reset";
            this.button_StopwatchReset.UseVisualStyleBackColor = true;
            this.button_StopwatchReset.Click += new System.EventHandler(this.button_StopwatchReset_Click);
            // 
            // textBox_StopWatch
            // 
            this.textBox_StopWatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_StopWatch.Location = new System.Drawing.Point(9, 66);
            this.textBox_StopWatch.Name = "textBox_StopWatch";
            this.textBox_StopWatch.ReadOnly = true;
            this.textBox_StopWatch.Size = new System.Drawing.Size(200, 31);
            this.textBox_StopWatch.TabIndex = 103;
            this.textBox_StopWatch.Text = "0";
            this.textBox_StopWatch.TextChanged += new System.EventHandler(this.textBox_StopWatch_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox_SendSerialPort);
            this.groupBox4.Controls.Add(this.checkBox_DeleteCommand);
            this.groupBox4.Controls.Add(this.button_SerialPortAdd);
            this.groupBox4.Controls.Add(this.comboBox_SerialPortHistory);
            this.groupBox4.Controls.Add(this.button_SendSerialPort);
            this.groupBox4.Location = new System.Drawing.Point(6, 78);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(343, 207);
            this.groupBox4.TabIndex = 69;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Send Data";
            // 
            // textBox_SendSerialPort
            // 
            this.textBox_SendSerialPort.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox_SendSerialPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_SendSerialPort.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SendSerialPort.Location = new System.Drawing.Point(15, 55);
            this.textBox_SendSerialPort.Name = "textBox_SendSerialPort";
            this.textBox_SendSerialPort.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_SendSerialPort.Size = new System.Drawing.Size(322, 31);
            this.textBox_SendSerialPort.TabIndex = 0;
            this.textBox_SendSerialPort.Text = "String_To_Send";
            this.toolTip1.SetToolTip(this.textBox_SendSerialPort, "Press help");
            this.textBox_SendSerialPort.TextChanged += new System.EventHandler(this.textBox_SendSerialPort_TextChanged);
            // 
            // checkBox_DeleteCommand
            // 
            this.checkBox_DeleteCommand.AutoSize = true;
            this.checkBox_DeleteCommand.Checked = true;
            this.checkBox_DeleteCommand.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_DeleteCommand.Location = new System.Drawing.Point(127, 94);
            this.checkBox_DeleteCommand.Name = "checkBox_DeleteCommand";
            this.checkBox_DeleteCommand.Size = new System.Drawing.Size(135, 22);
            this.checkBox_DeleteCommand.TabIndex = 4;
            this.checkBox_DeleteCommand.Text = "Delete after Send";
            this.toolTip1.SetToolTip(this.checkBox_DeleteCommand, "Delete after Send");
            this.checkBox_DeleteCommand.UseVisualStyleBackColor = true;
            // 
            // button_SerialPortAdd
            // 
            this.button_SerialPortAdd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SerialPortAdd.Location = new System.Drawing.Point(269, 20);
            this.button_SerialPortAdd.Name = "button_SerialPortAdd";
            this.button_SerialPortAdd.Size = new System.Drawing.Size(68, 24);
            this.button_SerialPortAdd.TabIndex = 3;
            this.button_SerialPortAdd.Text = "Add";
            this.button_SerialPortAdd.Click += new System.EventHandler(this.button_SerialPortAdd_Click);
            // 
            // comboBox_SerialPortHistory
            // 
            this.comboBox_SerialPortHistory.FormattingEnabled = true;
            this.comboBox_SerialPortHistory.Location = new System.Drawing.Point(16, 21);
            this.comboBox_SerialPortHistory.Name = "comboBox_SerialPortHistory";
            this.comboBox_SerialPortHistory.Size = new System.Drawing.Size(247, 26);
            this.comboBox_SerialPortHistory.TabIndex = 2;
            // 
            // button_SendSerialPort
            // 
            this.button_SendSerialPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SendSerialPort.Location = new System.Drawing.Point(16, 94);
            this.button_SendSerialPort.Name = "button_SendSerialPort";
            this.button_SendSerialPort.Size = new System.Drawing.Size(105, 24);
            this.button_SendSerialPort.TabIndex = 1;
            this.button_SendSerialPort.Text = "Send";
            this.button_SendSerialPort.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // gbPortSettings
            // 
            this.gbPortSettings.Controls.Add(this.button_ReScanComPort);
            this.gbPortSettings.Controls.Add(this.checkBox_ComportOpen);
            this.gbPortSettings.Controls.Add(this.cmbPortName);
            this.gbPortSettings.Controls.Add(this.cmbBaudRate);
            this.gbPortSettings.Controls.Add(this.cmbStopBits);
            this.gbPortSettings.Controls.Add(this.cmbParity);
            this.gbPortSettings.Controls.Add(this.cmbDataBits);
            this.gbPortSettings.Controls.Add(this.lblComPort);
            this.gbPortSettings.Controls.Add(this.lblStopBits);
            this.gbPortSettings.Controls.Add(this.lblBaudRate);
            this.gbPortSettings.Controls.Add(this.lblDataBits);
            this.gbPortSettings.Controls.Add(this.label3);
            this.gbPortSettings.Location = new System.Drawing.Point(6, 3);
            this.gbPortSettings.Name = "gbPortSettings";
            this.gbPortSettings.Size = new System.Drawing.Size(598, 74);
            this.gbPortSettings.TabIndex = 10;
            this.gbPortSettings.TabStop = false;
            this.gbPortSettings.Text = "COM Serial Port Settings";
            // 
            // button_ReScanComPort
            // 
            this.button_ReScanComPort.AutoSize = true;
            this.button_ReScanComPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ReScanComPort.Location = new System.Drawing.Point(413, 26);
            this.button_ReScanComPort.Name = "button_ReScanComPort";
            this.button_ReScanComPort.Size = new System.Drawing.Size(87, 29);
            this.button_ReScanComPort.TabIndex = 10;
            this.button_ReScanComPort.Text = "ReScan";
            this.button_ReScanComPort.UseVisualStyleBackColor = true;
            this.button_ReScanComPort.Click += new System.EventHandler(this.button_ReScanComPort_Click);
            // 
            // checkBox_ComportOpen
            // 
            this.checkBox_ComportOpen.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_ComportOpen.AutoSize = true;
            this.checkBox_ComportOpen.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_ComportOpen.Location = new System.Drawing.Point(506, 26);
            this.checkBox_ComportOpen.Name = "checkBox_ComportOpen";
            this.checkBox_ComportOpen.Size = new System.Drawing.Size(84, 29);
            this.checkBox_ComportOpen.TabIndex = 8;
            this.checkBox_ComportOpen.Text = "Open Port";
            this.checkBox_ComportOpen.UseVisualStyleBackColor = true;
            this.checkBox_ComportOpen.CheckedChanged += new System.EventHandler(this.checkBox_ComportOpen_CheckedChanged);
            // 
            // cmbPortName
            // 
            this.cmbPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            this.cmbPortName.Location = new System.Drawing.Point(7, 29);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(67, 26);
            this.cmbPortName.TabIndex = 1;
            this.cmbPortName.Tag = "1";
            this.cmbPortName.SelectedIndexChanged += new System.EventHandler(this.cmbPortName_SelectedIndexChanged);
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbBaudRate.Location = new System.Drawing.Point(80, 29);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(89, 26);
            this.cmbBaudRate.TabIndex = 3;
            this.cmbBaudRate.Text = "115200";
            this.cmbBaudRate.SelectedIndexChanged += new System.EventHandler(this.cmbBaudRate_SelectedIndexChanged);
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBits.FormattingEnabled = true;
            this.cmbStopBits.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbStopBits.Location = new System.Drawing.Point(307, 28);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(88, 26);
            this.cmbStopBits.TabIndex = 9;
            // 
            // cmbParity
            // 
            this.cmbParity.DisplayMember = "1";
            this.cmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.cmbParity.Location = new System.Drawing.Point(175, 28);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(60, 26);
            this.cmbParity.TabIndex = 5;
            this.cmbParity.Tag = "1";
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cmbDataBits.Location = new System.Drawing.Point(240, 28);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(60, 26);
            this.cmbDataBits.TabIndex = 7;
            this.cmbDataBits.Text = "8";
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Location = new System.Drawing.Point(6, 13);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(71, 18);
            this.lblComPort.TabIndex = 0;
            this.lblComPort.Text = "COM Port:";
            // 
            // lblStopBits
            // 
            this.lblStopBits.AutoSize = true;
            this.lblStopBits.Location = new System.Drawing.Point(309, 12);
            this.lblStopBits.Name = "lblStopBits";
            this.lblStopBits.Size = new System.Drawing.Size(66, 18);
            this.lblStopBits.TabIndex = 8;
            this.lblStopBits.Text = "Stop Bits:";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(79, 13);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(74, 18);
            this.lblBaudRate.TabIndex = 2;
            this.lblBaudRate.Text = "Baud Rate:";
            // 
            // lblDataBits
            // 
            this.lblDataBits.AutoSize = true;
            this.lblDataBits.Location = new System.Drawing.Point(243, 12);
            this.lblDataBits.Name = "lblDataBits";
            this.lblDataBits.Size = new System.Drawing.Size(66, 18);
            this.lblDataBits.TabIndex = 6;
            this.lblDataBits.Text = "Data Bits:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Parity:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button_OpenFolder);
            this.groupBox5.Controls.Add(this.textBox_SerialPortRecognizePattern3);
            this.groupBox5.Controls.Add(this.textBox_SerialPortRecognizePattern2);
            this.groupBox5.Controls.Add(this.textBox_SerialPortRecognizePattern);
            this.groupBox5.Controls.Add(this.checkBox_S1RecordLog);
            this.groupBox5.Controls.Add(this.checkBox_S1Pause);
            this.groupBox5.Controls.Add(this.txtS1_Clear);
            this.groupBox5.Controls.Add(this.SerialPortLogger_TextBox);
            this.groupBox5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(353, 73);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1541, 859);
            this.groupBox5.TabIndex = 68;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Serial Port Console";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // button_OpenFolder
            // 
            this.button_OpenFolder.Location = new System.Drawing.Point(626, 18);
            this.button_OpenFolder.Name = "button_OpenFolder";
            this.button_OpenFolder.Size = new System.Drawing.Size(108, 26);
            this.button_OpenFolder.TabIndex = 76;
            this.button_OpenFolder.Text = "Open Folder";
            this.button_OpenFolder.UseVisualStyleBackColor = true;
            this.button_OpenFolder.Click += new System.EventHandler(this.button43_Click);
            // 
            // textBox_SerialPortRecognizePattern3
            // 
            this.textBox_SerialPortRecognizePattern3.Location = new System.Drawing.Point(252, 17);
            this.textBox_SerialPortRecognizePattern3.Name = "textBox_SerialPortRecognizePattern3";
            this.textBox_SerialPortRecognizePattern3.Size = new System.Drawing.Size(117, 27);
            this.textBox_SerialPortRecognizePattern3.TabIndex = 75;
            this.toolTip2.SetToolTip(this.textBox_SerialPortRecognizePattern3, "Recognize Pattern by string");
            this.toolTip1.SetToolTip(this.textBox_SerialPortRecognizePattern3, "Recognize Pattern by string");
            // 
            // textBox_SerialPortRecognizePattern2
            // 
            this.textBox_SerialPortRecognizePattern2.Location = new System.Drawing.Point(129, 18);
            this.textBox_SerialPortRecognizePattern2.Name = "textBox_SerialPortRecognizePattern2";
            this.textBox_SerialPortRecognizePattern2.Size = new System.Drawing.Size(117, 27);
            this.textBox_SerialPortRecognizePattern2.TabIndex = 74;
            this.toolTip2.SetToolTip(this.textBox_SerialPortRecognizePattern2, "Recognize Pattern by string");
            this.toolTip1.SetToolTip(this.textBox_SerialPortRecognizePattern2, "Recognize Pattern by string");
            // 
            // textBox_SerialPortRecognizePattern
            // 
            this.textBox_SerialPortRecognizePattern.Location = new System.Drawing.Point(6, 18);
            this.textBox_SerialPortRecognizePattern.Name = "textBox_SerialPortRecognizePattern";
            this.textBox_SerialPortRecognizePattern.Size = new System.Drawing.Size(117, 27);
            this.textBox_SerialPortRecognizePattern.TabIndex = 73;
            this.toolTip2.SetToolTip(this.textBox_SerialPortRecognizePattern, "Recognize Pattern by string");
            this.toolTip1.SetToolTip(this.textBox_SerialPortRecognizePattern, "Recognize Pattern by string");
            // 
            // checkBox_S1RecordLog
            // 
            this.checkBox_S1RecordLog.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_S1RecordLog.AutoSize = true;
            this.checkBox_S1RecordLog.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_S1RecordLog.Location = new System.Drawing.Point(740, 18);
            this.checkBox_S1RecordLog.Name = "checkBox_S1RecordLog";
            this.checkBox_S1RecordLog.Size = new System.Drawing.Size(83, 29);
            this.checkBox_S1RecordLog.TabIndex = 69;
            this.checkBox_S1RecordLog.Text = "Log to file";
            this.checkBox_S1RecordLog.UseVisualStyleBackColor = true;
            this.checkBox_S1RecordLog.CheckedChanged += new System.EventHandler(this.checkBox_S1RecordLog_CheckedChanged);
            // 
            // checkBox_S1Pause
            // 
            this.checkBox_S1Pause.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_S1Pause.AutoSize = true;
            this.checkBox_S1Pause.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_S1Pause.Location = new System.Drawing.Point(832, 17);
            this.checkBox_S1Pause.Name = "checkBox_S1Pause";
            this.checkBox_S1Pause.Size = new System.Drawing.Size(58, 29);
            this.checkBox_S1Pause.TabIndex = 70;
            this.checkBox_S1Pause.Text = "Pause";
            this.checkBox_S1Pause.UseVisualStyleBackColor = true;
            this.checkBox_S1Pause.CheckedChanged += new System.EventHandler(this.checkBox_S1Pause_CheckedChanged);
            // 
            // txtS1_Clear
            // 
            this.txtS1_Clear.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtS1_Clear.Location = new System.Drawing.Point(900, 17);
            this.txtS1_Clear.Name = "txtS1_Clear";
            this.txtS1_Clear.Size = new System.Drawing.Size(62, 26);
            this.txtS1_Clear.TabIndex = 69;
            this.txtS1_Clear.Text = "Clear";
            this.txtS1_Clear.UseVisualStyleBackColor = true;
            // 
            // SerialPortLogger_TextBox
            // 
            this.SerialPortLogger_TextBox.BackColor = System.Drawing.Color.LightGray;
            this.SerialPortLogger_TextBox.EnableAutoDragDrop = true;
            this.SerialPortLogger_TextBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialPortLogger_TextBox.Location = new System.Drawing.Point(6, 53);
            this.SerialPortLogger_TextBox.Name = "SerialPortLogger_TextBox";
            this.SerialPortLogger_TextBox.Size = new System.Drawing.Size(1529, 806);
            this.SerialPortLogger_TextBox.TabIndex = 0;
            this.SerialPortLogger_TextBox.Text = "";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.button32);
            this.tabPage6.Controls.Add(this.groupBox38);
            this.tabPage6.Controls.Add(this.groupBox_LoadedConfig);
            this.tabPage6.Controls.Add(this.button30);
            this.tabPage6.Controls.Add(this.comboBox_SystemConfigType);
            this.tabPage6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage6.Location = new System.Drawing.Point(4, 27);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1900, 936);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Configuration";
            this.tabPage6.UseVisualStyleBackColor = true;
            this.tabPage6.Click += new System.EventHandler(this.tabPage6_Click);
            // 
            // button32
            // 
            this.button32.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button32.Location = new System.Drawing.Point(661, 149);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(140, 27);
            this.button32.TabIndex = 96;
            this.button32.Text = "Lock Config";
            this.button32.UseVisualStyleBackColor = true;
            this.button32.Click += new System.EventHandler(this.button32_Click_1);
            // 
            // groupBox38
            // 
            this.groupBox38.Controls.Add(this.button29);
            this.groupBox38.Controls.Add(this.button6);
            this.groupBox38.Controls.Add(this.button2);
            this.groupBox38.Controls.Add(this.button31);
            this.groupBox38.Controls.Add(this.textBox_SourceConfig);
            this.groupBox38.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox38.Location = new System.Drawing.Point(4, 5);
            this.groupBox38.Name = "groupBox38";
            this.groupBox38.Size = new System.Drawing.Size(505, 175);
            this.groupBox38.TabIndex = 102;
            this.groupBox38.TabStop = false;
            this.groupBox38.Text = "Configuration control";
            // 
            // button29
            // 
            this.button29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button29.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button29.Location = new System.Drawing.Point(129, 58);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(98, 32);
            this.button29.TabIndex = 63;
            this.button29.Text = "Save File";
            this.button29.UseVisualStyleBackColor = true;
            this.button29.Click += new System.EventHandler(this.button29_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(6, 24);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(120, 32);
            this.button6.TabIndex = 25;
            this.button6.Text = "Get Serial Port";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click_2);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(6, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 32);
            this.button2.TabIndex = 62;
            this.button2.Text = "Set Serial Port";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // button31
            // 
            this.button31.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button31.Location = new System.Drawing.Point(129, 25);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(98, 32);
            this.button31.TabIndex = 22;
            this.button31.Text = "Load File";
            this.button31.UseVisualStyleBackColor = true;
            this.button31.Click += new System.EventHandler(this.button31_Click);
            // 
            // textBox_SourceConfig
            // 
            this.textBox_SourceConfig.Location = new System.Drawing.Point(2, 95);
            this.textBox_SourceConfig.Name = "textBox_SourceConfig";
            this.textBox_SourceConfig.ReadOnly = true;
            this.textBox_SourceConfig.Size = new System.Drawing.Size(496, 62);
            this.textBox_SourceConfig.TabIndex = 28;
            this.textBox_SourceConfig.Text = "";
            this.textBox_SourceConfig.TextChanged += new System.EventHandler(this.textBox_SourceConfig_TextChanged);
            // 
            // groupBox_LoadedConfig
            // 
            this.groupBox_LoadedConfig.Controls.Add(this.groupBox_Configuration);
            this.groupBox_LoadedConfig.Controls.Add(this.textBox_Config7);
            this.groupBox_LoadedConfig.Controls.Add(this.label_Config13);
            this.groupBox_LoadedConfig.Controls.Add(this.textBox_Config13);
            this.groupBox_LoadedConfig.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_LoadedConfig.Location = new System.Drawing.Point(4, 186);
            this.groupBox_LoadedConfig.Name = "groupBox_LoadedConfig";
            this.groupBox_LoadedConfig.Size = new System.Drawing.Size(1294, 633);
            this.groupBox_LoadedConfig.TabIndex = 27;
            this.groupBox_LoadedConfig.TabStop = false;
            this.groupBox_LoadedConfig.Text = "Loaded Configuration";
            this.groupBox_LoadedConfig.Enter += new System.EventHandler(this.groupBox_LoadedConfig_Enter);
            // 
            // groupBox_Configuration
            // 
            this.groupBox_Configuration.Controls.Add(this.label_Config42);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config42);
            this.groupBox_Configuration.Controls.Add(this.label_Config41);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config41);
            this.groupBox_Configuration.Controls.Add(this.label_Config40);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config40);
            this.groupBox_Configuration.Controls.Add(this.label_Config39);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config39);
            this.groupBox_Configuration.Controls.Add(this.textBox_UnitVersion);
            this.groupBox_Configuration.Controls.Add(this.label6);
            this.groupBox_Configuration.Controls.Add(this.textBox_SpeedLimit3);
            this.groupBox_Configuration.Controls.Add(this.textBox_SpeedLimit2);
            this.groupBox_Configuration.Controls.Add(this.textBox_SpeedLimit1);
            this.groupBox_Configuration.Controls.Add(this.label_Config38);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config38);
            this.groupBox_Configuration.Controls.Add(this.label_Config37);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config37);
            this.groupBox_Configuration.Controls.Add(this.label_Config36);
            this.groupBox_Configuration.Controls.Add(this.label_Config35);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config36);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config35);
            this.groupBox_Configuration.Controls.Add(this.label_Config34);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config34);
            this.groupBox_Configuration.Controls.Add(this.label_Config2);
            this.groupBox_Configuration.Controls.Add(this.label_Config1);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config2);
            this.groupBox_Configuration.Controls.Add(this.label_Config33);
            this.groupBox_Configuration.Controls.Add(this.label_Config3);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config1);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config3);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config33);
            this.groupBox_Configuration.Controls.Add(this.label_Config32);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config32);
            this.groupBox_Configuration.Controls.Add(this.label_Config31);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config31);
            this.groupBox_Configuration.Controls.Add(this.groupBox31);
            this.groupBox_Configuration.Controls.Add(this.textBox_ConfigUnitID);
            this.groupBox_Configuration.Controls.Add(this.label_Config30);
            this.groupBox_Configuration.Controls.Add(this.label4);
            this.groupBox_Configuration.Controls.Add(this.label_Config29);
            this.groupBox_Configuration.Controls.Add(this.label_Config28);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config30);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config29);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config28);
            this.groupBox_Configuration.Controls.Add(this.label_Config27);
            this.groupBox_Configuration.Controls.Add(this.label_Config26);
            this.groupBox_Configuration.Controls.Add(this.label_Config25);
            this.groupBox_Configuration.Controls.Add(this.label_Config24);
            this.groupBox_Configuration.Controls.Add(this.label_Config23);
            this.groupBox_Configuration.Controls.Add(this.label_Config22);
            this.groupBox_Configuration.Controls.Add(this.label_Config21);
            this.groupBox_Configuration.Controls.Add(this.label_Config20);
            this.groupBox_Configuration.Controls.Add(this.label_Config19);
            this.groupBox_Configuration.Controls.Add(this.label_Config18);
            this.groupBox_Configuration.Controls.Add(this.label_Config17);
            this.groupBox_Configuration.Controls.Add(this.label_Config16);
            this.groupBox_Configuration.Controls.Add(this.label_Config15);
            this.groupBox_Configuration.Controls.Add(this.label_Config14);
            this.groupBox_Configuration.Controls.Add(this.label_Config12);
            this.groupBox_Configuration.Controls.Add(this.label_Config11);
            this.groupBox_Configuration.Controls.Add(this.label_Config10);
            this.groupBox_Configuration.Controls.Add(this.label_Config9);
            this.groupBox_Configuration.Controls.Add(this.label_Config8);
            this.groupBox_Configuration.Controls.Add(this.label_Config7);
            this.groupBox_Configuration.Controls.Add(this.label_Config6);
            this.groupBox_Configuration.Controls.Add(this.label_Config5);
            this.groupBox_Configuration.Controls.Add(this.label_Config4);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config27);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config26);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config25);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config19);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config18);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config17);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config24);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config23);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config22);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config21);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config20);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config16);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config15);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config14);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config12);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config11);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config10);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config9);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config8);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config6);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config5);
            this.groupBox_Configuration.Controls.Add(this.textBox_Config4);
            this.groupBox_Configuration.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Configuration.ImeMode = System.Windows.Forms.ImeMode.On;
            this.groupBox_Configuration.Location = new System.Drawing.Point(10, 16);
            this.groupBox_Configuration.Name = "groupBox_Configuration";
            this.groupBox_Configuration.Size = new System.Drawing.Size(1225, 458);
            this.groupBox_Configuration.TabIndex = 28;
            this.groupBox_Configuration.TabStop = false;
            this.groupBox_Configuration.Enter += new System.EventHandler(this.groupBox_Configuration_Enter);
            // 
            // label_Config42
            // 
            this.label_Config42.AutoSize = true;
            this.label_Config42.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config42.Location = new System.Drawing.Point(253, 425);
            this.label_Config42.Name = "label_Config42";
            this.label_Config42.Size = new System.Drawing.Size(67, 15);
            this.label_Config42.TabIndex = 124;
            this.label_Config42.Text = "Uart Listen";
            this.toolTip2.SetToolTip(this.label_Config42, "Description:\r\nConfig UART baudrate in listen mode\r\nFormat:\r\nnumber\r\nExamples:\r\n96" +
        "00\r\n38400\r\n115200");
            this.toolTip1.SetToolTip(this.label_Config42, "Description:\r\nConfig UART baudrate in listen mode\r\nFormat:\r\nnumber\r\nExamples:\r\n96" +
        "00\r\n38400\r\n115200");
            // 
            // textBox_Config42
            // 
            this.textBox_Config42.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config42.Location = new System.Drawing.Point(383, 419);
            this.textBox_Config42.Name = "textBox_Config42";
            this.textBox_Config42.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config42.TabIndex = 123;
            this.toolTip2.SetToolTip(this.textBox_Config42, "Description:\r\nEnable or Disable the Engine cut speed feature\r\nFormat:\r\nBoolean\r\nE" +
        "xamples:\r\n0 or 1");
            this.toolTip1.SetToolTip(this.textBox_Config42, "Description:\r\nEnable or Disable the Engine cut speed feature\r\nFormat:\r\nBoolean\r\nE" +
        "xamples:\r\n0 or 1");
            this.textBox_Config42.TextChanged += new System.EventHandler(this.textBox_Config42_TextChanged);
            // 
            // label_Config41
            // 
            this.label_Config41.AutoSize = true;
            this.label_Config41.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config41.Location = new System.Drawing.Point(510, 425);
            this.label_Config41.Name = "label_Config41";
            this.label_Config41.Size = new System.Drawing.Size(70, 15);
            this.label_Config41.TabIndex = 122;
            this.label_Config41.Text = "Lock Engine";
            this.toolTip2.SetToolTip(this.label_Config41, "Description:\r\nIngition on door in ARM mode\r\nFormat:\r\nnumber\r\nExamples:\r\n0\r\n5");
            this.toolTip1.SetToolTip(this.label_Config41, "Description:\r\nIngition on door in ARM mode\r\nFormat:\r\nnumber\r\nExamples:\r\n0\r\n5");
            // 
            // textBox_Config41
            // 
            this.textBox_Config41.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config41.Location = new System.Drawing.Point(635, 420);
            this.textBox_Config41.Name = "textBox_Config41";
            this.textBox_Config41.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config41.TabIndex = 121;
            this.toolTip2.SetToolTip(this.textBox_Config41, "Description:\r\nEnable or Disable the Engine cut speed feature\r\nFormat:\r\nBoolean\r\nE" +
        "xamples:\r\n0 or 1");
            this.toolTip1.SetToolTip(this.textBox_Config41, "Description:\r\nEnable or Disable the Engine cut speed feature\r\nFormat:\r\nBoolean\r\nE" +
        "xamples:\r\n0 or 1");
            this.textBox_Config41.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label_Config40
            // 
            this.label_Config40.AutoSize = true;
            this.label_Config40.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config40.Location = new System.Drawing.Point(509, 396);
            this.label_Config40.Name = "label_Config40";
            this.label_Config40.Size = new System.Drawing.Size(99, 15);
            this.label_Config40.TabIndex = 120;
            this.label_Config40.Text = "Engine cut speed";
            this.toolTip2.SetToolTip(this.label_Config40, "Description:\r\nIngition on door in ARM mode\r\nFormat:\r\nnumber\r\nExamples:\r\n0\r\n5");
            this.toolTip1.SetToolTip(this.label_Config40, "Description:\r\nIngition on door in ARM mode\r\nFormat:\r\nnumber\r\nExamples:\r\n0\r\n5");
            // 
            // textBox_Config40
            // 
            this.textBox_Config40.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config40.Location = new System.Drawing.Point(635, 387);
            this.textBox_Config40.Name = "textBox_Config40";
            this.textBox_Config40.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config40.TabIndex = 119;
            this.toolTip2.SetToolTip(this.textBox_Config40, "Description:\r\n\r\nCut off Speed Engine.\r\nThe Speed that the engine is cutting off.\r" +
        "\n0-20 - set the speed to cut off\r\n255 - disable\r\n\r\nValid data:\r\n0-20 ,255\r\n\r\n\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config40, "Description:\r\n\r\nCut off Speed Engine.\r\nThe Speed that the engine is cutting off.\r" +
        "\n0-20 - set the speed to cut off\r\n255 - disable\r\n\r\nValid data:\r\n0-20 ,255\r\n\r\n");
            this.textBox_Config40.TextChanged += new System.EventHandler(this.textBox_Config40_TextChanged);
            // 
            // label_Config39
            // 
            this.label_Config39.AutoSize = true;
            this.label_Config39.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config39.Location = new System.Drawing.Point(509, 363);
            this.label_Config39.Name = "label_Config39";
            this.label_Config39.Size = new System.Drawing.Size(98, 15);
            this.label_Config39.TabIndex = 118;
            this.label_Config39.Text = "Ring\\SMS Enable";
            this.toolTip2.SetToolTip(this.label_Config39, "Description:\r\nIngition on door in ARM mode\r\nFormat:\r\nnumber\r\nExamples:\r\n0\r\n5");
            this.toolTip1.SetToolTip(this.label_Config39, "Description:\r\nIngition on door in ARM mode\r\nFormat:\r\nnumber\r\nExamples:\r\n0\r\n5");
            // 
            // textBox_Config39
            // 
            this.textBox_Config39.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config39.Location = new System.Drawing.Point(635, 354);
            this.textBox_Config39.Name = "textBox_Config39";
            this.textBox_Config39.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config39.TabIndex = 117;
            this.toolTip2.SetToolTip(this.textBox_Config39, "Description:\r\nRing to subscribers\r\nValid data:\r\n0-2\r\n\r\n0-\tSMS ONLY\r\n1-\tRING ONLY\r" +
        "\n2-\tSMS  + RING\r\n\r\n\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config39, "Description:\r\nRing to subscribers\r\nValid data:\r\n0-2\r\n\r\n0-\tSMS ONLY\r\n1-\tRING ONLY\r" +
        "\n2-\tSMS  + RING\r\n\r\n");
            this.textBox_Config39.TextChanged += new System.EventHandler(this.textBox_Config39_TextChanged);
            // 
            // textBox_UnitVersion
            // 
            this.textBox_UnitVersion.AcceptsReturn = true;
            this.textBox_UnitVersion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_UnitVersion.Location = new System.Drawing.Point(1026, 50);
            this.textBox_UnitVersion.Multiline = true;
            this.textBox_UnitVersion.Name = "textBox_UnitVersion";
            this.textBox_UnitVersion.Size = new System.Drawing.Size(192, 101);
            this.textBox_UnitVersion.TabIndex = 116;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(924, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 19);
            this.label6.TabIndex = 115;
            this.label6.Text = "Unit Version:";
            // 
            // textBox_SpeedLimit3
            // 
            this.textBox_SpeedLimit3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SpeedLimit3.Location = new System.Drawing.Point(466, 56);
            this.textBox_SpeedLimit3.Name = "textBox_SpeedLimit3";
            this.textBox_SpeedLimit3.Size = new System.Drawing.Size(37, 27);
            this.textBox_SpeedLimit3.TabIndex = 114;
            this.textBox_SpeedLimit3.Text = "0";
            this.toolTip2.SetToolTip(this.textBox_SpeedLimit3, "Description:\r\nSet high speed limit threshold. \r\nSpeed beep enable field Should be" +
        " enable.\r\nValid data:\r\n0-255");
            this.toolTip1.SetToolTip(this.textBox_SpeedLimit3, "Description:\r\nSet high speed limit threshold. \r\nSpeed beep enable field Should be" +
        " enable.\r\nValid data:\r\n0-255");
            this.textBox_SpeedLimit3.TextChanged += new System.EventHandler(this.textBox_SpeedLimit3_TextChanged);
            // 
            // textBox_SpeedLimit2
            // 
            this.textBox_SpeedLimit2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SpeedLimit2.Location = new System.Drawing.Point(425, 56);
            this.textBox_SpeedLimit2.Name = "textBox_SpeedLimit2";
            this.textBox_SpeedLimit2.Size = new System.Drawing.Size(37, 27);
            this.textBox_SpeedLimit2.TabIndex = 113;
            this.textBox_SpeedLimit2.Text = "0";
            this.toolTip2.SetToolTip(this.textBox_SpeedLimit2, "Description:\r\nSet Medium speed limit threshold. \r\nSpeed beep enable field Should " +
        "be enable.\r\nValid data:\r\n0-255");
            this.toolTip1.SetToolTip(this.textBox_SpeedLimit2, "Description:\r\nSet Medium speed limit threshold. \r\nSpeed beep enable field Should " +
        "be enable.\r\nValid data:\r\n0-255");
            this.textBox_SpeedLimit2.TextChanged += new System.EventHandler(this.textBox_SpeedLimit2_TextChanged);
            // 
            // textBox_SpeedLimit1
            // 
            this.textBox_SpeedLimit1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SpeedLimit1.Location = new System.Drawing.Point(383, 56);
            this.textBox_SpeedLimit1.Name = "textBox_SpeedLimit1";
            this.textBox_SpeedLimit1.Size = new System.Drawing.Size(37, 27);
            this.textBox_SpeedLimit1.TabIndex = 112;
            this.textBox_SpeedLimit1.Text = "0";
            this.toolTip2.SetToolTip(this.textBox_SpeedLimit1, "Description:\r\nSet low speed limit threshold. \r\nSpeed beep enable field Should be " +
        "enable.\r\nValid data:\r\n0-255");
            this.toolTip1.SetToolTip(this.textBox_SpeedLimit1, "Description:\r\nSet low speed limit threshold. \r\nSpeed beep enable field Should be " +
        "enable.\r\nValid data:\r\n0-255\r\n");
            this.textBox_SpeedLimit1.TextChanged += new System.EventHandler(this.textBox_SpeedLimit1_TextChanged);
            // 
            // label_Config38
            // 
            this.label_Config38.AutoSize = true;
            this.label_Config38.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config38.Location = new System.Drawing.Point(509, 131);
            this.label_Config38.Name = "label_Config38";
            this.label_Config38.Size = new System.Drawing.Size(86, 15);
            this.label_Config38.TabIndex = 111;
            this.label_Config38.Text = "Garmin Enable";
            this.toolTip2.SetToolTip(this.label_Config38, "Description:\r\nIngition on door in ARM mode\r\nFormat:\r\nnumber\r\nExamples:\r\n0\r\n5");
            this.toolTip1.SetToolTip(this.label_Config38, "Description:\r\nIngition on door in ARM mode\r\nFormat:\r\nnumber\r\nExamples:\r\n0\r\n5");
            // 
            // textBox_Config38
            // 
            this.textBox_Config38.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config38.Location = new System.Drawing.Point(635, 122);
            this.textBox_Config38.Name = "textBox_Config38";
            this.textBox_Config38.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config38.TabIndex = 110;
            this.toolTip2.SetToolTip(this.textBox_Config38, "Description:\r\nEnable Gramin communication\r\nValid data:\r\n0,1\r\n\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config38, "Description:\r\nEnable Gramin communication\r\nValid data:\r\n0,1\r\n");
            this.textBox_Config38.TextChanged += new System.EventHandler(this.textBox_Config38_TextChanged);
            // 
            // label_Config37
            // 
            this.label_Config37.AutoSize = true;
            this.label_Config37.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config37.Location = new System.Drawing.Point(509, 95);
            this.label_Config37.Name = "label_Config37";
            this.label_Config37.Size = new System.Drawing.Size(111, 15);
            this.label_Config37.TabIndex = 109;
            this.label_Config37.Text = "Speed Beep Enable";
            this.label_Config37.Click += new System.EventHandler(this.label_Config37_Click);
            // 
            // textBox_Config37
            // 
            this.textBox_Config37.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config37.Location = new System.Drawing.Point(635, 89);
            this.textBox_Config37.Name = "textBox_Config37";
            this.textBox_Config37.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config37.TabIndex = 108;
            this.toolTip2.SetToolTip(this.textBox_Config37, "Description:\r\nan option to make a beep while enter sleep.\r\nValid data:\r\nboolean\r\n" +
        "");
            this.toolTip1.SetToolTip(this.textBox_Config37, "Description:\r\nan option to make a beep while enter sleep.\r\nValid data:\r\nboolean");
            this.textBox_Config37.TextChanged += new System.EventHandler(this.textBox_Config37_TextChanged);
            // 
            // label_Config36
            // 
            this.label_Config36.AutoSize = true;
            this.label_Config36.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config36.Location = new System.Drawing.Point(3, 128);
            this.label_Config36.Name = "label_Config36";
            this.label_Config36.Size = new System.Drawing.Size(86, 15);
            this.label_Config36.TabIndex = 107;
            this.label_Config36.Text = "APN password";
            // 
            // label_Config35
            // 
            this.label_Config35.AutoSize = true;
            this.label_Config35.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config35.Location = new System.Drawing.Point(3, 95);
            this.label_Config35.Name = "label_Config35";
            this.label_Config35.Size = new System.Drawing.Size(89, 15);
            this.label_Config35.TabIndex = 106;
            this.label_Config35.Text = "APN username";
            // 
            // textBox_Config36
            // 
            this.textBox_Config36.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config36.Location = new System.Drawing.Point(124, 121);
            this.textBox_Config36.Name = "textBox_Config36";
            this.textBox_Config36.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config36.TabIndex = 105;
            this.toolTip2.SetToolTip(this.textBox_Config36, "Description:\r\nAPN password.\r\nan option to set SIM card details according to cellu" +
        "lar provider operator. \r\nValid Data:\r\nstring");
            this.toolTip1.SetToolTip(this.textBox_Config36, "Description:\r\nAPN password.\r\nan option to set SIM card details according to cellu" +
        "lar provider operator. \r\nValid Data:\r\nstring");
            this.textBox_Config36.TextChanged += new System.EventHandler(this.textBox_Config36_TextChanged);
            // 
            // textBox_Config35
            // 
            this.textBox_Config35.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config35.Location = new System.Drawing.Point(124, 88);
            this.textBox_Config35.Name = "textBox_Config35";
            this.textBox_Config35.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config35.TabIndex = 104;
            this.toolTip2.SetToolTip(this.textBox_Config35, "Description:\r\nAPN username.\r\nan option to set SIM card details according to cellu" +
        "lar provider operator. \r\nValid Data:\r\nstring");
            this.toolTip1.SetToolTip(this.textBox_Config35, "Description:\r\nAPN username.\r\nan option to set SIM card details according to cellu" +
        "lar provider operator. \r\nValid Data:\r\nstring\r\n");
            this.textBox_Config35.TextChanged += new System.EventHandler(this.textBox_Config35_TextChanged);
            // 
            // label_Config34
            // 
            this.label_Config34.AutoSize = true;
            this.label_Config34.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config34.Location = new System.Drawing.Point(509, 330);
            this.label_Config34.Name = "label_Config34";
            this.label_Config34.Size = new System.Drawing.Size(122, 15);
            this.label_Config34.TabIndex = 103;
            this.label_Config34.Text = "Arm\\Disarm method";
            this.toolTip2.SetToolTip(this.label_Config34, "Description:\r\nIngition on door in ARM mode\r\nFormat:\r\nnumber\r\nExamples:\r\n0\r\n5");
            this.toolTip1.SetToolTip(this.label_Config34, "Description:\r\nIngition on door in ARM mode\r\nFormat:\r\nnumber\r\nExamples:\r\n0\r\n5");
            // 
            // textBox_Config34
            // 
            this.textBox_Config34.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config34.Location = new System.Drawing.Point(635, 321);
            this.textBox_Config34.Name = "textBox_Config34";
            this.textBox_Config34.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config34.TabIndex = 33;
            this.toolTip2.SetToolTip(this.textBox_Config34, "Description:\r\nArm accessory in order to arm and disarm the system\r\nValid data:\r\n0" +
        "-2\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config34, "Description:\r\nArm accessory in order to arm and disarm the system\r\nValid data:\r\n0" +
        "-2\r\n");
            this.textBox_Config34.TextChanged += new System.EventHandler(this.textBox_Config34_TextChanged);
            // 
            // label_Config2
            // 
            this.label_Config2.AutoSize = true;
            this.label_Config2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config2.Location = new System.Drawing.Point(1004, 202);
            this.label_Config2.Name = "label_Config2";
            this.label_Config2.Size = new System.Drawing.Size(74, 15);
            this.label_Config2.TabIndex = 61;
            this.label_Config2.Text = "Subscriber 2";
            this.label_Config2.Click += new System.EventHandler(this.label_Config2_Click);
            // 
            // label_Config1
            // 
            this.label_Config1.AutoSize = true;
            this.label_Config1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config1.Location = new System.Drawing.Point(1004, 169);
            this.label_Config1.Name = "label_Config1";
            this.label_Config1.Size = new System.Drawing.Size(74, 15);
            this.label_Config1.TabIndex = 33;
            this.label_Config1.Text = "Subscriber 1";
            this.label_Config1.Click += new System.EventHandler(this.label_Config1_Click);
            // 
            // textBox_Config2
            // 
            this.textBox_Config2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config2.Location = new System.Drawing.Point(1100, 197);
            this.textBox_Config2.Name = "textBox_Config2";
            this.textBox_Config2.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config2.TabIndex = 24;
            this.toolTip2.SetToolTip(this.textBox_Config2, "Description:\r\nSubscriber 2 to respond to SMS\'s\r\nFormat:\r\nstring 0-9 Max 20 charac" +
        "ters must starts with +.\r\nFor deleting the subscriber fill 0.\r\nExamples:\r\n+97250" +
        "23577894\r\n0\r\n\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config2, "Description:\r\nSubscriber 2 to respond to SMS\'s\r\nFormat:\r\nstring 0-9 Max 20 charac" +
        "ters must starts with +.\r\nFor deleting the subscriber fill 0.\r\nExamples:\r\n+97250" +
        "23577894\r\n0\r\n");
            this.textBox_Config2.TextChanged += new System.EventHandler(this.textBox_Config2_TextChanged);
            // 
            // label_Config33
            // 
            this.label_Config33.AutoSize = true;
            this.label_Config33.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config33.Location = new System.Drawing.Point(509, 301);
            this.label_Config33.Name = "label_Config33";
            this.label_Config33.Size = new System.Drawing.Size(74, 15);
            this.label_Config33.TabIndex = 101;
            this.label_Config33.Text = "Disarm code";
            this.toolTip2.SetToolTip(this.label_Config33, "Disarm Code: (CA)\r\nDescription:\r\nIngition on door in ARM mode\r\nFormat:\r\nnumber\r\nE" +
        "xamples:\r\n0\r\n5");
            this.toolTip1.SetToolTip(this.label_Config33, "Disarm Code: (CA)\r\nDescription:\r\nIngition on door in ARM mode\r\nFormat:\r\nnumber\r\nE" +
        "xamples:\r\n0\r\n5");
            // 
            // label_Config3
            // 
            this.label_Config3.AutoSize = true;
            this.label_Config3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config3.Location = new System.Drawing.Point(1004, 232);
            this.label_Config3.Name = "label_Config3";
            this.label_Config3.Size = new System.Drawing.Size(74, 15);
            this.label_Config3.TabIndex = 62;
            this.label_Config3.Text = "Subscriber 3";
            this.label_Config3.Click += new System.EventHandler(this.label_Config3_Click);
            // 
            // textBox_Config1
            // 
            this.textBox_Config1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config1.Location = new System.Drawing.Point(1100, 163);
            this.textBox_Config1.Name = "textBox_Config1";
            this.textBox_Config1.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config1.TabIndex = 23;
            this.toolTip2.SetToolTip(this.textBox_Config1, "Description:\r\nSubscriber 1 to respond to SMS\'s\r\nFormat:\r\nstring 0-9 Max 20 charac" +
        "ters must starts with +.\r\nFor deleting the subscriber fill 0.\r\nExamples:\r\n+97250" +
        "23577894\r\n0\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config1, "Description:\r\nSubscriber 1 to respond to SMS\'s\r\nFormat:\r\nstring 0-9 Max 20 charac" +
        "ters must starts with +.\r\nFor deleting the subscriber fill 0.\r\nExamples:\r\n+97250" +
        "23577894\r\n0");
            this.textBox_Config1.TextChanged += new System.EventHandler(this.textBox_Config1_TextChanged);
            // 
            // textBox_Config3
            // 
            this.textBox_Config3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config3.Location = new System.Drawing.Point(1100, 229);
            this.textBox_Config3.Name = "textBox_Config3";
            this.textBox_Config3.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config3.TabIndex = 25;
            this.toolTip2.SetToolTip(this.textBox_Config3, "Description:\r\nSubscriber 3 to respond to SMS\'s\r\nFormat:\r\nstring 0-9 Max 20 charac" +
        "ters must starts with +.\r\nFor deleting the subscriber fill 0.\r\nExamples:\r\n+97250" +
        "23577894\r\n0\r\n\r\n\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config3, "Description:\r\nSubscriber 3 to respond to SMS\'s\r\nFormat:\r\nstring 0-9 Max 20 charac" +
        "ters must starts with +.\r\nFor deleting the subscriber fill 0.\r\nExamples:\r\n+97250" +
        "23577894\r\n0\r\n\r\n");
            this.textBox_Config3.TextChanged += new System.EventHandler(this.textBox_Config3_TextChanged);
            // 
            // textBox_Config33
            // 
            this.textBox_Config33.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config33.Location = new System.Drawing.Point(635, 288);
            this.textBox_Config33.Name = "textBox_Config33";
            this.textBox_Config33.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config33.TabIndex = 32;
            this.toolTip2.SetToolTip(this.textBox_Config33, "Description:\r\nan option to configure the code for Arm/Disarm process for Wireless" +
        " keypad or for keypad which installed in the vehicle. \r\nValid data:\r\n4 digits co" +
        "de, 1111-5555");
            this.toolTip1.SetToolTip(this.textBox_Config33, "Description:\r\nan option to configure the code for Arm/Disarm process for Wireless" +
        " keypad or for keypad which installed in the vehicle. \r\nValid data:\r\n4 digits co" +
        "de, 1111-5555");
            this.textBox_Config33.TextChanged += new System.EventHandler(this.textBox_Config33_TextChanged);
            // 
            // label_Config32
            // 
            this.label_Config32.AutoSize = true;
            this.label_Config32.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config32.Location = new System.Drawing.Point(510, 31);
            this.label_Config32.Name = "label_Config32";
            this.label_Config32.Size = new System.Drawing.Size(64, 15);
            this.label_Config32.TabIndex = 99;
            this.label_Config32.Text = "GNSS type";
            this.toolTip2.SetToolTip(this.label_Config32, "Description:\r\nIngition on door in ARM mode\r\nFormat:\r\nnumber\r\nExamples:\r\n0\r\n5");
            this.toolTip1.SetToolTip(this.label_Config32, "Description:\r\nIngition on door in ARM mode\r\nFormat:\r\nnumber\r\nExamples:\r\n0\r\n5");
            this.label_Config32.Click += new System.EventHandler(this.label_Config32_Click);
            // 
            // textBox_Config32
            // 
            this.textBox_Config32.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config32.Location = new System.Drawing.Point(635, 25);
            this.textBox_Config32.Name = "textBox_Config32";
            this.textBox_Config32.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config32.TabIndex = 22;
            this.toolTip2.SetToolTip(this.textBox_Config32, "Description:\r\nan option to configure satellite type calculation. \r\nvalid Data:\r\nn" +
        "umber 0-2\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config32, "Description:\r\nan option to configure satellite type calculation. \r\nvalid Data:\r\nn" +
        "umber 0-2\r\n");
            this.textBox_Config32.TextChanged += new System.EventHandler(this.textBox_Config32_TextChanged);
            // 
            // label_Config31
            // 
            this.label_Config31.AutoSize = true;
            this.label_Config31.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config31.Location = new System.Drawing.Point(509, 268);
            this.label_Config31.Name = "label_Config31";
            this.label_Config31.Size = new System.Drawing.Size(75, 15);
            this.label_Config31.TabIndex = 97;
            this.label_Config31.Text = "Passive ARM";
            this.toolTip2.SetToolTip(this.label_Config31, "Description:\r\nIngition on door in ARM mode\r\nFormat:\r\nnumber\r\nExamples:\r\n0\r\n5");
            this.toolTip1.SetToolTip(this.label_Config31, "Description:\r\nIngition on door in ARM mode\r\nFormat:\r\nnumber\r\nExamples:\r\n0\r\n5");
            this.label_Config31.Click += new System.EventHandler(this.label_Config31_Click);
            // 
            // textBox_Config31
            // 
            this.textBox_Config31.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config31.Location = new System.Drawing.Point(635, 255);
            this.textBox_Config31.Name = "textBox_Config31";
            this.textBox_Config31.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config31.TabIndex = 31;
            this.toolTip2.SetToolTip(this.textBox_Config31, "Description:\r\nan option to configure time of entering to Arm state in case of not" +
        " activating by accessory device of Spetrotec Company or by original key of the v" +
        "ehicle. \r\nValid data:\r\n2-300\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config31, "Description:\r\nan option to configure time of entering to Arm state in case of not" +
        " activating by accessory device of Spetrotec Company or by original key of the v" +
        "ehicle. \r\nValid data:\r\n2-300");
            this.textBox_Config31.TextChanged += new System.EventHandler(this.textBox_Config31_TextChanged);
            // 
            // groupBox31
            // 
            this.groupBox31.Controls.Add(this.checkBox_config_Bit10);
            this.groupBox31.Controls.Add(this.checkBox_config_Bit9);
            this.groupBox31.Controls.Add(this.checkBox_config_Bit8);
            this.groupBox31.Controls.Add(this.checkBox_config_Bit7);
            this.groupBox31.Controls.Add(this.checkBox_config_Bit6);
            this.groupBox31.Controls.Add(this.checkBox_config_Bit5);
            this.groupBox31.Controls.Add(this.checkBox_config_Bit4);
            this.groupBox31.Controls.Add(this.checkBox_config_Bit3);
            this.groupBox31.Controls.Add(this.checkBox_config_Bit2);
            this.groupBox31.Controls.Add(this.checkBox_config_Bit1);
            this.groupBox31.Controls.Add(this.checkBox_config_Bit0);
            this.groupBox31.Location = new System.Drawing.Point(1003, 263);
            this.groupBox31.Name = "groupBox31";
            this.groupBox31.Size = new System.Drawing.Size(217, 187);
            this.groupBox31.TabIndex = 95;
            this.groupBox31.TabStop = false;
            this.groupBox31.Text = "Send event via SMS";
            // 
            // checkBox_config_Bit10
            // 
            this.checkBox_config_Bit10.AutoSize = true;
            this.checkBox_config_Bit10.Location = new System.Drawing.Point(106, 113);
            this.checkBox_config_Bit10.Name = "checkBox_config_Bit10";
            this.checkBox_config_Bit10.Size = new System.Drawing.Size(72, 23);
            this.checkBox_config_Bit10.TabIndex = 10;
            this.checkBox_config_Bit10.Text = "Empty";
            this.checkBox_config_Bit10.UseVisualStyleBackColor = true;
            this.checkBox_config_Bit10.Visible = false;
            this.checkBox_config_Bit10.CheckedChanged += new System.EventHandler(this.checkBox_config_Bit10_CheckedChanged);
            // 
            // checkBox_config_Bit9
            // 
            this.checkBox_config_Bit9.AutoSize = true;
            this.checkBox_config_Bit9.Location = new System.Drawing.Point(106, 91);
            this.checkBox_config_Bit9.Name = "checkBox_config_Bit9";
            this.checkBox_config_Bit9.Size = new System.Drawing.Size(50, 23);
            this.checkBox_config_Bit9.TabIndex = 9;
            this.checkBox_config_Bit9.Text = "Tilt";
            this.checkBox_config_Bit9.UseVisualStyleBackColor = true;
            this.checkBox_config_Bit9.CheckedChanged += new System.EventHandler(this.checkBox_config_Bit9_CheckedChanged);
            // 
            // checkBox_config_Bit8
            // 
            this.checkBox_config_Bit8.AutoSize = true;
            this.checkBox_config_Bit8.Location = new System.Drawing.Point(106, 69);
            this.checkBox_config_Bit8.Name = "checkBox_config_Bit8";
            this.checkBox_config_Bit8.Size = new System.Drawing.Size(56, 23);
            this.checkBox_config_Bit8.TabIndex = 8;
            this.checkBox_config_Bit8.Text = "Tow";
            this.checkBox_config_Bit8.UseVisualStyleBackColor = true;
            this.checkBox_config_Bit8.CheckedChanged += new System.EventHandler(this.checkBox_config_Bit8_CheckedChanged);
            // 
            // checkBox_config_Bit7
            // 
            this.checkBox_config_Bit7.AutoSize = true;
            this.checkBox_config_Bit7.Location = new System.Drawing.Point(106, 47);
            this.checkBox_config_Bit7.Name = "checkBox_config_Bit7";
            this.checkBox_config_Bit7.Size = new System.Drawing.Size(72, 23);
            this.checkBox_config_Bit7.TabIndex = 7;
            this.checkBox_config_Bit7.Text = "Falling";
            this.checkBox_config_Bit7.UseVisualStyleBackColor = true;
            this.checkBox_config_Bit7.CheckedChanged += new System.EventHandler(this.checkBox_config_Bit7_CheckedChanged);
            // 
            // checkBox_config_Bit6
            // 
            this.checkBox_config_Bit6.AutoSize = true;
            this.checkBox_config_Bit6.Location = new System.Drawing.Point(106, 23);
            this.checkBox_config_Bit6.Name = "checkBox_config_Bit6";
            this.checkBox_config_Bit6.Size = new System.Drawing.Size(100, 23);
            this.checkBox_config_Bit6.TabIndex = 6;
            this.checkBox_config_Bit6.Text = "Bat cut off";
            this.checkBox_config_Bit6.UseVisualStyleBackColor = true;
            this.checkBox_config_Bit6.CheckedChanged += new System.EventHandler(this.checkBox_config_Bit6_CheckedChanged);
            // 
            // checkBox_config_Bit5
            // 
            this.checkBox_config_Bit5.AutoSize = true;
            this.checkBox_config_Bit5.Location = new System.Drawing.Point(7, 139);
            this.checkBox_config_Bit5.Name = "checkBox_config_Bit5";
            this.checkBox_config_Bit5.Size = new System.Drawing.Size(146, 23);
            this.checkBox_config_Bit5.TabIndex = 5;
            this.checkBox_config_Bit5.Text = "Low level Battery";
            this.checkBox_config_Bit5.UseVisualStyleBackColor = true;
            this.checkBox_config_Bit5.CheckedChanged += new System.EventHandler(this.checkBox_config_Bit5_CheckedChanged);
            // 
            // checkBox_config_Bit4
            // 
            this.checkBox_config_Bit4.AutoSize = true;
            this.checkBox_config_Bit4.Location = new System.Drawing.Point(7, 115);
            this.checkBox_config_Bit4.Name = "checkBox_config_Bit4";
            this.checkBox_config_Bit4.Size = new System.Drawing.Size(105, 23);
            this.checkBox_config_Bit4.TabIndex = 4;
            this.checkBox_config_Bit4.Text = "Speed limit";
            this.checkBox_config_Bit4.UseVisualStyleBackColor = true;
            this.checkBox_config_Bit4.CheckedChanged += new System.EventHandler(this.checkBox_config_Bit4_CheckedChanged);
            // 
            // checkBox_config_Bit3
            // 
            this.checkBox_config_Bit3.AutoSize = true;
            this.checkBox_config_Bit3.Location = new System.Drawing.Point(7, 93);
            this.checkBox_config_Bit3.Name = "checkBox_config_Bit3";
            this.checkBox_config_Bit3.Size = new System.Drawing.Size(55, 23);
            this.checkBox_config_Bit3.TabIndex = 3;
            this.checkBox_config_Bit3.Text = "GP3";
            this.checkBox_config_Bit3.UseVisualStyleBackColor = true;
            this.checkBox_config_Bit3.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox_config_Bit2
            // 
            this.checkBox_config_Bit2.AutoSize = true;
            this.checkBox_config_Bit2.Location = new System.Drawing.Point(7, 71);
            this.checkBox_config_Bit2.Name = "checkBox_config_Bit2";
            this.checkBox_config_Bit2.Size = new System.Drawing.Size(55, 23);
            this.checkBox_config_Bit2.TabIndex = 2;
            this.checkBox_config_Bit2.Text = "GP2";
            this.checkBox_config_Bit2.UseVisualStyleBackColor = true;
            this.checkBox_config_Bit2.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox_config_Bit1
            // 
            this.checkBox_config_Bit1.AutoSize = true;
            this.checkBox_config_Bit1.Location = new System.Drawing.Point(7, 47);
            this.checkBox_config_Bit1.Name = "checkBox_config_Bit1";
            this.checkBox_config_Bit1.Size = new System.Drawing.Size(55, 23);
            this.checkBox_config_Bit1.TabIndex = 1;
            this.checkBox_config_Bit1.Text = "GP1";
            this.checkBox_config_Bit1.UseVisualStyleBackColor = true;
            this.checkBox_config_Bit1.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox_config_Bit0
            // 
            this.checkBox_config_Bit0.AutoSize = true;
            this.checkBox_config_Bit0.Location = new System.Drawing.Point(7, 22);
            this.checkBox_config_Bit0.Name = "checkBox_config_Bit0";
            this.checkBox_config_Bit0.Size = new System.Drawing.Size(53, 23);
            this.checkBox_config_Bit0.TabIndex = 0;
            this.checkBox_config_Bit0.Text = "IGN";
            this.checkBox_config_Bit0.UseVisualStyleBackColor = true;
            this.checkBox_config_Bit0.CheckedChanged += new System.EventHandler(this.checkBox_config_Bit0_CheckedChanged);
            // 
            // textBox_ConfigUnitID
            // 
            this.textBox_ConfigUnitID.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ConfigUnitID.Location = new System.Drawing.Point(1026, 18);
            this.textBox_ConfigUnitID.Name = "textBox_ConfigUnitID";
            this.textBox_ConfigUnitID.Size = new System.Drawing.Size(192, 27);
            this.textBox_ConfigUnitID.TabIndex = 60;
            this.textBox_ConfigUnitID.TextChanged += new System.EventHandler(this.textBox_ConfigUnitID_TextChanged);
            // 
            // label_Config30
            // 
            this.label_Config30.AutoSize = true;
            this.label_Config30.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config30.Location = new System.Drawing.Point(509, 235);
            this.label_Config30.Name = "label_Config30";
            this.label_Config30.Size = new System.Drawing.Size(101, 15);
            this.label_Config30.TabIndex = 94;
            this.label_Config30.Text = "Doors filter delay";
            this.toolTip2.SetToolTip(this.label_Config30, "Description:\r\nIngition on door in ARM mode\r\nFormat:\r\nnumber\r\nExamples:\r\n0\r\n5");
            this.toolTip1.SetToolTip(this.label_Config30, "Description:\r\nIngition on door in ARM mode\r\nFormat:\r\nnumber\r\nExamples:\r\n0\r\n5");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(960, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 19);
            this.label4.TabIndex = 29;
            this.label4.Text = "Unit ID:";
            // 
            // label_Config29
            // 
            this.label_Config29.AutoSize = true;
            this.label_Config29.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config29.Location = new System.Drawing.Point(510, 200);
            this.label_Config29.Name = "label_Config29";
            this.label_Config29.Size = new System.Drawing.Size(35, 15);
            this.label_Config29.TabIndex = 93;
            this.label_Config29.Text = "Siren";
            this.label_Config29.Click += new System.EventHandler(this.label_Config29_Click);
            // 
            // label_Config28
            // 
            this.label_Config28.AutoSize = true;
            this.label_Config28.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config28.Location = new System.Drawing.Point(509, 169);
            this.label_Config28.Name = "label_Config28";
            this.label_Config28.Size = new System.Drawing.Size(77, 15);
            this.label_Config28.TabIndex = 92;
            this.label_Config28.Text = "Can Car Type";
            this.label_Config28.Click += new System.EventHandler(this.label_Config28_Click);
            // 
            // textBox_Config30
            // 
            this.textBox_Config30.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config30.Location = new System.Drawing.Point(635, 221);
            this.textBox_Config30.Name = "textBox_Config30";
            this.textBox_Config30.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config30.TabIndex = 30;
            this.toolTip2.SetToolTip(this.textBox_Config30, "Description:\r\nan option to configure the neglecting time of the Door after Arm wa" +
        "s pressed. \r\nValid data:\r\nnumber\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config30, "Description:\r\nan option to configure the neglecting time of the Door after Arm wa" +
        "s pressed. \r\nValid data:\r\nnumber\r\n");
            this.textBox_Config30.TextChanged += new System.EventHandler(this.textBox_Config30_TextChanged);
            // 
            // textBox_Config29
            // 
            this.textBox_Config29.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config29.Location = new System.Drawing.Point(635, 188);
            this.textBox_Config29.Name = "textBox_Config29";
            this.textBox_Config29.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config29.TabIndex = 29;
            this.toolTip2.SetToolTip(this.textBox_Config29, "Description:\r\nan option to activate/deactivate the siren during the Alarm state. " +
        "\r\nValid data:\r\n0-1\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config29, "Description:\r\nan option to activate/deactivate the siren during the Alarm state. " +
        "\r\nValid data:\r\n0-1\r\n");
            this.textBox_Config29.TextChanged += new System.EventHandler(this.textBox_Config29_TextChanged);
            // 
            // textBox_Config28
            // 
            this.textBox_Config28.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config28.Location = new System.Drawing.Point(635, 155);
            this.textBox_Config28.Name = "textBox_Config28";
            this.textBox_Config28.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config28.TabIndex = 28;
            this.toolTip2.SetToolTip(this.textBox_Config28, "Description:\r\nAn option to set CAN car type\r\nValid data:\r\nnumber");
            this.toolTip1.SetToolTip(this.textBox_Config28, "Description:\r\nAn option to set CAN car type\r\nValid data:\r\nnumber\r\n");
            this.textBox_Config28.TextChanged += new System.EventHandler(this.textBox_Config28_TextChanged);
            // 
            // label_Config27
            // 
            this.label_Config27.AutoSize = true;
            this.label_Config27.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config27.Location = new System.Drawing.Point(510, 63);
            this.label_Config27.Name = "label_Config27";
            this.label_Config27.Size = new System.Drawing.Size(69, 15);
            this.label_Config27.TabIndex = 86;
            this.label_Config27.Text = "Time to ack";
            this.label_Config27.Click += new System.EventHandler(this.label_Config27_Click);
            // 
            // label_Config26
            // 
            this.label_Config26.AutoSize = true;
            this.label_Config26.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config26.Location = new System.Drawing.Point(253, 163);
            this.label_Config26.Name = "label_Config26";
            this.label_Config26.Size = new System.Drawing.Size(113, 15);
            this.label_Config26.TabIndex = 85;
            this.label_Config26.Text = "Jamming sensitivity";
            // 
            // label_Config25
            // 
            this.label_Config25.AutoSize = true;
            this.label_Config25.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config25.Location = new System.Drawing.Point(253, 97);
            this.label_Config25.Name = "label_Config25";
            this.label_Config25.Size = new System.Drawing.Size(84, 15);
            this.label_Config25.TabIndex = 84;
            this.label_Config25.Text = "Set odometer";
            // 
            // label_Config24
            // 
            this.label_Config24.AutoSize = true;
            this.label_Config24.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config24.Location = new System.Drawing.Point(253, 129);
            this.label_Config24.Name = "label_Config24";
            this.label_Config24.Size = new System.Drawing.Size(111, 15);
            this.label_Config24.TabIndex = 83;
            this.label_Config24.Text = "Jamming detection";
            // 
            // label_Config23
            // 
            this.label_Config23.AutoSize = true;
            this.label_Config23.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config23.Location = new System.Drawing.Point(253, 391);
            this.label_Config23.Name = "label_Config23";
            this.label_Config23.Size = new System.Drawing.Size(79, 15);
            this.label_Config23.TabIndex = 82;
            this.label_Config23.Text = "Logger mode";
            // 
            // label_Config22
            // 
            this.label_Config22.AutoSize = true;
            this.label_Config22.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config22.Location = new System.Drawing.Point(3, 299);
            this.label_Config22.Name = "label_Config22";
            this.label_Config22.Size = new System.Drawing.Size(80, 15);
            this.label_Config22.TabIndex = 81;
            this.label_Config22.Text = "Position time";
            // 
            // label_Config21
            // 
            this.label_Config21.AutoSize = true;
            this.label_Config21.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config21.Location = new System.Drawing.Point(3, 332);
            this.label_Config21.Name = "label_Config21";
            this.label_Config21.Size = new System.Drawing.Size(99, 15);
            this.label_Config21.TabIndex = 80;
            this.label_Config21.Text = "Position distance";
            this.toolTip2.SetToolTip(this.label_Config21, "Position Distance:\r\nDescription:\r\nPosition distance to transmit position message\r" +
        "\nFormat:\r\nnumber\r\nExamples:\r\n0\r\n1000\r\n");
            this.toolTip1.SetToolTip(this.label_Config21, "Position Distance:\r\nDescription:\r\nPosition distance to transmit position message\r" +
        "\nFormat:\r\nnumber\r\nExamples:\r\n0\r\n1000");
            // 
            // label_Config20
            // 
            this.label_Config20.AutoSize = true;
            this.label_Config20.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config20.Location = new System.Drawing.Point(4, 364);
            this.label_Config20.Name = "label_Config20";
            this.label_Config20.Size = new System.Drawing.Size(83, 15);
            this.label_Config20.TabIndex = 79;
            this.label_Config20.Text = "Position angle";
            this.toolTip2.SetToolTip(this.label_Config20, "Position Angel\r\nDescription:\r\nangel to transmit position message when turning\r\nFo" +
        "rmat:\r\n0.360\r\nExamples:\r\n0\r\n30\r\n\r\n");
            this.toolTip1.SetToolTip(this.label_Config20, "Position Angel\r\nDescription:\r\nangel to transmit position message when turning\r\nFo" +
        "rmat:\r\n0.360\r\nExamples:\r\n0\r\n30\r\n");
            // 
            // label_Config19
            // 
            this.label_Config19.AutoSize = true;
            this.label_Config19.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config19.Location = new System.Drawing.Point(253, 362);
            this.label_Config19.Name = "label_Config19";
            this.label_Config19.Size = new System.Drawing.Size(87, 15);
            this.label_Config19.TabIndex = 78;
            this.label_Config19.Text = "Tow sensitivity";
            // 
            // label_Config18
            // 
            this.label_Config18.AutoSize = true;
            this.label_Config18.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config18.Location = new System.Drawing.Point(253, 330);
            this.label_Config18.Name = "label_Config18";
            this.label_Config18.Size = new System.Drawing.Size(61, 15);
            this.label_Config18.TabIndex = 77;
            this.label_Config18.Text = "Tow const";
            // 
            // label_Config17
            // 
            this.label_Config17.AutoSize = true;
            this.label_Config17.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config17.Location = new System.Drawing.Point(253, 296);
            this.label_Config17.Name = "label_Config17";
            this.label_Config17.Size = new System.Drawing.Size(61, 15);
            this.label_Config17.TabIndex = 76;
            this.label_Config17.Text = "Tow angle";
            this.toolTip2.SetToolTip(this.label_Config17, "Tilt Angel\r\nDescription:\r\ngenerate event bigger than this angel\r\nFormat:\r\n0-360\r\n" +
        "Examples:\r\n0\r\n90\r\n\r\n");
            this.toolTip1.SetToolTip(this.label_Config17, "Tow Angel\r\nDescription:\r\ngenerate event bigger than this angel\r\nFormat:\r\n0-360\r\nE" +
        "xamples:\r\n0\r\n90\r\n\r\n");
            // 
            // label_Config16
            // 
            this.label_Config16.AutoSize = true;
            this.label_Config16.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config16.Location = new System.Drawing.Point(253, 263);
            this.label_Config16.Name = "label_Config16";
            this.label_Config16.Size = new System.Drawing.Size(82, 15);
            this.label_Config16.TabIndex = 75;
            this.label_Config16.Text = "Tilt sensitivity";
            // 
            // label_Config15
            // 
            this.label_Config15.AutoSize = true;
            this.label_Config15.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config15.Location = new System.Drawing.Point(252, 230);
            this.label_Config15.Name = "label_Config15";
            this.label_Config15.Size = new System.Drawing.Size(56, 15);
            this.label_Config15.TabIndex = 74;
            this.label_Config15.Text = "Tilt const";
            this.toolTip1.SetToolTip(this.label_Config15, "Tilt Num Of Detection\r\nDescription:\r\ngenerate event when detection number is bigg" +
        "er than this value\r\nFormat:\r\nnumber\r\nExamples:\r\n0\r\n1000\r\n\r\n");
            // 
            // label_Config14
            // 
            this.label_Config14.AutoSize = true;
            this.label_Config14.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config14.Location = new System.Drawing.Point(252, 197);
            this.label_Config14.Name = "label_Config14";
            this.label_Config14.Size = new System.Drawing.Size(56, 15);
            this.label_Config14.TabIndex = 73;
            this.label_Config14.Text = "Tilt angle";
            this.label_Config14.Click += new System.EventHandler(this.label26_Click);
            // 
            // label_Config12
            // 
            this.label_Config12.AutoSize = true;
            this.label_Config12.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config12.Location = new System.Drawing.Point(3, 194);
            this.label_Config12.Name = "label_Config12";
            this.label_Config12.Size = new System.Drawing.Size(38, 15);
            this.label_Config12.TabIndex = 71;
            this.label_Config12.Text = "Port1";
            this.label_Config12.Click += new System.EventHandler(this.label_Config12_Click);
            // 
            // label_Config11
            // 
            this.label_Config11.AutoSize = true;
            this.label_Config11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config11.Location = new System.Drawing.Point(3, 228);
            this.label_Config11.Name = "label_Config11";
            this.label_Config11.Size = new System.Drawing.Size(24, 15);
            this.label_Config11.TabIndex = 70;
            this.label_Config11.Text = "IP2";
            this.label_Config11.Click += new System.EventHandler(this.label_Config11_Click);
            // 
            // label_Config10
            // 
            this.label_Config10.AutoSize = true;
            this.label_Config10.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config10.Location = new System.Drawing.Point(3, 161);
            this.label_Config10.Name = "label_Config10";
            this.label_Config10.Size = new System.Drawing.Size(24, 15);
            this.label_Config10.TabIndex = 69;
            this.label_Config10.Text = "IP1";
            // 
            // label_Config9
            // 
            this.label_Config9.AutoSize = true;
            this.label_Config9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config9.Location = new System.Drawing.Point(3, 63);
            this.label_Config9.Name = "label_Config9";
            this.label_Config9.Size = new System.Drawing.Size(31, 15);
            this.label_Config9.TabIndex = 68;
            this.label_Config9.Text = "APN";
            // 
            // label_Config8
            // 
            this.label_Config8.AutoSize = true;
            this.label_Config8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config8.Location = new System.Drawing.Point(3, 398);
            this.label_Config8.Name = "label_Config8";
            this.label_Config8.Size = new System.Drawing.Size(80, 15);
            this.label_Config8.TabIndex = 67;
            this.label_Config8.Text = "Status period";
            // 
            // label_Config7
            // 
            this.label_Config7.AutoSize = true;
            this.label_Config7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config7.Location = new System.Drawing.Point(253, 66);
            this.label_Config7.Name = "label_Config7";
            this.label_Config7.Size = new System.Drawing.Size(123, 15);
            this.label_Config7.TabIndex = 66;
            this.label_Config7.Text = "Speed limit  Lo,Me,Hi";
            this.label_Config7.Click += new System.EventHandler(this.label_Config7_Click);
            // 
            // label_Config6
            // 
            this.label_Config6.AutoSize = true;
            this.label_Config6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config6.Location = new System.Drawing.Point(3, 264);
            this.label_Config6.Name = "label_Config6";
            this.label_Config6.Size = new System.Drawing.Size(38, 15);
            this.label_Config6.TabIndex = 65;
            this.label_Config6.Text = "Port2";
            // 
            // label_Config5
            // 
            this.label_Config5.AutoSize = true;
            this.label_Config5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config5.Location = new System.Drawing.Point(253, 34);
            this.label_Config5.Name = "label_Config5";
            this.label_Config5.Size = new System.Drawing.Size(118, 15);
            this.label_Config5.TabIndex = 64;
            this.label_Config5.Text = "Vehicle battery alert";
            // 
            // label_Config4
            // 
            this.label_Config4.AutoSize = true;
            this.label_Config4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config4.Location = new System.Drawing.Point(3, 30);
            this.label_Config4.Name = "label_Config4";
            this.label_Config4.Size = new System.Drawing.Size(85, 15);
            this.label_Config4.TabIndex = 63;
            this.label_Config4.Text = "SMS password";
            // 
            // textBox_Config27
            // 
            this.textBox_Config27.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config27.Location = new System.Drawing.Point(635, 57);
            this.textBox_Config27.Name = "textBox_Config27";
            this.textBox_Config27.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config27.TabIndex = 27;
            this.toolTip2.SetToolTip(this.textBox_Config27, "Description:\r\nan option to make the reconnection of GPRS socket in case of not re" +
        "ceiving the ACK from the server. \r\nValid data:\r\nnumber");
            this.toolTip1.SetToolTip(this.textBox_Config27, "Description:\r\nan option to make the reconnection of GPRS socket in case of not re" +
        "ceiving the ACK from the server. \r\nValid data:\r\nnumber");
            this.textBox_Config27.TextChanged += new System.EventHandler(this.textBox_Config27_TextChanged);
            // 
            // textBox_Config26
            // 
            this.textBox_Config26.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config26.Location = new System.Drawing.Point(383, 152);
            this.textBox_Config26.Name = "textBox_Config26";
            this.textBox_Config26.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config26.TabIndex = 14;
            this.toolTip2.SetToolTip(this.textBox_Config26, "Description:\r\nan option to configure the sensitivity of the Anti Jamming detectio" +
        "n. \r\nValid data:\r\n20-70");
            this.toolTip1.SetToolTip(this.textBox_Config26, "Description:\r\nan option to configure the sensitivity of the Anti Jamming detectio" +
        "n. \r\nValid data:\r\n20-70");
            this.textBox_Config26.TextChanged += new System.EventHandler(this.textBox_Config26_TextChanged);
            // 
            // textBox_Config25
            // 
            this.textBox_Config25.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config25.Location = new System.Drawing.Point(384, 88);
            this.textBox_Config25.Name = "textBox_Config25";
            this.textBox_Config25.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config25.TabIndex = 13;
            this.toolTip2.SetToolTip(this.textBox_Config25, "Description:\r\nan option to set the value of initial odometer. \r\nValid data:\r\nFloa" +
        "t number\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config25, "Description:\r\nan option to set the value of initial odometer. \r\nValid data:\r\nFloa" +
        "t number\r\n\r\n");
            this.textBox_Config25.TextChanged += new System.EventHandler(this.textBox_Config25_TextChanged);
            // 
            // textBox_Config19
            // 
            this.textBox_Config19.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config19.Location = new System.Drawing.Point(384, 352);
            this.textBox_Config19.Name = "textBox_Config19";
            this.textBox_Config19.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config19.TabIndex = 20;
            this.toolTip2.SetToolTip(this.textBox_Config19, "Description:\r\nThe sensitivity of the sensor. \r\n· 1 - High sensitivity \r\n· 25 - Mi" +
        "ddle sensitivity \r\n· 49 - Low sensitivity \r\nValid data:\r\nnumber < Tilt Const\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config19, "Description:\r\nThe sensitivity of the sensor. \r\n· 1 - High sensitivity \r\n· 25 - Mi" +
        "ddle sensitivity \r\n· 49 - Low sensitivity \r\nValid data:\r\nnumber < Tilt Const\r\n");
            this.textBox_Config19.TextChanged += new System.EventHandler(this.textBox_Config19_TextChanged);
            // 
            // textBox_Config18
            // 
            this.textBox_Config18.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config18.Location = new System.Drawing.Point(384, 318);
            this.textBox_Config18.Name = "textBox_Config18";
            this.textBox_Config18.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config18.TabIndex = 19;
            this.toolTip2.SetToolTip(this.textBox_Config18, "Description:\r\nThe default value should not be changed. \r\nValid data:\r\nnumber");
            this.toolTip1.SetToolTip(this.textBox_Config18, "Description:\r\nThe default value should not be changed. \r\nValid data:\r\nnumber");
            this.textBox_Config18.TextChanged += new System.EventHandler(this.textBox_Config18_TextChanged);
            // 
            // textBox_Config17
            // 
            this.textBox_Config17.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config17.Location = new System.Drawing.Point(384, 286);
            this.textBox_Config17.Name = "textBox_Config17";
            this.textBox_Config17.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config17.TabIndex = 18;
            this.toolTip2.SetToolTip(this.textBox_Config17, "Description:\r\nangle (in degrees unit) for tow detection. \r\nValid data:\r\n0-360\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config17, "Description:\r\nangle (in degrees unit) for tow detection. \r\nValid data:\r\n0-360\r\n");
            this.textBox_Config17.TextChanged += new System.EventHandler(this.textBox_Config17_TextChanged);
            // 
            // textBox_Config24
            // 
            this.textBox_Config24.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config24.Location = new System.Drawing.Point(384, 119);
            this.textBox_Config24.Name = "textBox_Config24";
            this.textBox_Config24.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config24.TabIndex = 12;
            this.toolTip2.SetToolTip(this.textBox_Config24, "Description:\r\nan option enable/disable anti jamming detection. In this case outpu" +
        "t 1 will be activated. \r\nValid data:\r\n0-1\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config24, "Description:\r\nan option enable/disable anti jamming detection. In this case outpu" +
        "t 1 will be activated. \r\nValid data:\r\n0-1");
            this.textBox_Config24.TextChanged += new System.EventHandler(this.textBox_Config24_TextChanged);
            // 
            // textBox_Config23
            // 
            this.textBox_Config23.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config23.Location = new System.Drawing.Point(384, 385);
            this.textBox_Config23.Name = "textBox_Config23";
            this.textBox_Config23.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config23.TabIndex = 21;
            this.toolTip2.SetToolTip(this.textBox_Config23, "Description:\r\nIs Logger mode enable\r\nValid data:\r\n0-1\r\n\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config23, "Description:\r\nIs Logger mode enable\r\nValid data:\r\n0-1\r\n");
            this.textBox_Config23.TextChanged += new System.EventHandler(this.textBox_Config23_TextChanged);
            // 
            // textBox_Config22
            // 
            this.textBox_Config22.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config22.Location = new System.Drawing.Point(125, 292);
            this.textBox_Config22.Name = "textBox_Config22";
            this.textBox_Config22.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config22.TabIndex = 6;
            this.toolTip2.SetToolTip(this.textBox_Config22, "Description:\r\nan option to set time interval of position message which will be se" +
        "nt to remote server. \r\nValid data:\r\nnumber");
            this.toolTip1.SetToolTip(this.textBox_Config22, "Description:\r\nan option to set time interval of position message which will be se" +
        "nt to remote server. \r\nValid data:\r\nnumber\r\n");
            this.textBox_Config22.TextChanged += new System.EventHandler(this.textBox_Config22_TextChanged);
            // 
            // textBox_Config21
            // 
            this.textBox_Config21.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config21.Location = new System.Drawing.Point(124, 325);
            this.textBox_Config21.Name = "textBox_Config21";
            this.textBox_Config21.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config21.TabIndex = 7;
            this.toolTip2.SetToolTip(this.textBox_Config21, "Description:\r\nan option to send POS message every predefined distance value. \r\nVa" +
        "lid data:\r\nnumber");
            this.toolTip1.SetToolTip(this.textBox_Config21, "Description:\r\nan option to send POS message every predefined distance value. \r\nVa" +
        "lid data:\r\nnumber");
            this.textBox_Config21.TextChanged += new System.EventHandler(this.textBox_Config21_TextChanged);
            // 
            // textBox_Config20
            // 
            this.textBox_Config20.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config20.Location = new System.Drawing.Point(124, 357);
            this.textBox_Config20.Name = "textBox_Config20";
            this.textBox_Config20.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config20.TabIndex = 8;
            this.toolTip2.SetToolTip(this.textBox_Config20, "Description:\r\nIn case of deviation from traffic lane to preconfigured degrees, un" +
        "it will send position message. \r\nValid data:\r\n0-360\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config20, "Description:\r\nIn case of deviation from traffic lane to preconfigured degrees, un" +
        "it will send position message. \r\nValid data:\r\n0-360");
            this.textBox_Config20.TextChanged += new System.EventHandler(this.textBox_Config20_TextChanged);
            // 
            // textBox_Config16
            // 
            this.textBox_Config16.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config16.Location = new System.Drawing.Point(384, 253);
            this.textBox_Config16.Name = "textBox_Config16";
            this.textBox_Config16.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config16.TabIndex = 17;
            this.toolTip2.SetToolTip(this.textBox_Config16, "Description:\r\nThe sensitivity of the sensor. \r\n 1 - High sensitivity \r\n 25 - Mi" +
        "ddle sensitivity \r\n 49 - Low sensitivity \r\nValid data:\r\nnumber < Tilt Const");
            this.toolTip1.SetToolTip(this.textBox_Config16, "Description:\r\nThe sensitivity of the sensor. \r\n· 1 - High sensitivity \r\n· 25 - Mi" +
        "ddle sensitivity \r\n· 49 - Low sensitivity \r\nValid data:\r\nnumber < Tilt Const");
            this.textBox_Config16.TextChanged += new System.EventHandler(this.textBox_Config16_TextChanged);
            // 
            // textBox_Config15
            // 
            this.textBox_Config15.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config15.Location = new System.Drawing.Point(384, 221);
            this.textBox_Config15.Name = "textBox_Config15";
            this.textBox_Config15.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config15.TabIndex = 16;
            this.toolTip2.SetToolTip(this.textBox_Config15, "Description:\r\nThe default value should not be changed. \r\nValid data:\r\nnumber");
            this.toolTip1.SetToolTip(this.textBox_Config15, "Description:\r\nThe default value should not be changed. \r\nValid data:\r\nnumber");
            this.textBox_Config15.TextChanged += new System.EventHandler(this.textBox_Config15_TextChanged);
            // 
            // textBox_Config14
            // 
            this.textBox_Config14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config14.Location = new System.Drawing.Point(383, 185);
            this.textBox_Config14.Name = "textBox_Config14";
            this.textBox_Config14.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config14.TabIndex = 15;
            this.toolTip2.SetToolTip(this.textBox_Config14, "Description:\r\nangle (in degrees unit) for tilt detection. \r\nValid data:\r\n0-360");
            this.toolTip1.SetToolTip(this.textBox_Config14, "Description:\r\nangle (in degrees unit) for tilt detection. \r\nValid data:\r\n0-360\r\n");
            this.textBox_Config14.TextChanged += new System.EventHandler(this.textBox_Config14_TextChanged);
            // 
            // textBox_Config12
            // 
            this.textBox_Config12.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config12.Location = new System.Drawing.Point(124, 187);
            this.textBox_Config12.Name = "textBox_Config12";
            this.textBox_Config12.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config12.TabIndex = 3;
            this.toolTip2.SetToolTip(this.textBox_Config12, "Description:\r\nModem Port for IP1 For communicate with the Server\r\nValid data:\r\nVa" +
        "lid Port 0-99999\r\n\r\n\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config12, "Description:\r\nModem Port for IP1 For communicate with the Server\r\nValid data:\r\nVa" +
        "lid Port 0-99999\r\n\r\n");
            this.textBox_Config12.TextChanged += new System.EventHandler(this.textBox_Config12_TextChanged);
            // 
            // textBox_Config11
            // 
            this.textBox_Config11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config11.Location = new System.Drawing.Point(124, 221);
            this.textBox_Config11.Name = "textBox_Config11";
            this.textBox_Config11.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config11.TabIndex = 4;
            this.toolTip2.SetToolTip(this.textBox_Config11, "Description:\r\nModem IP2 For communicate with the Server\r\nValid data:\r\nValid TCP/I" +
        "P address");
            this.toolTip1.SetToolTip(this.textBox_Config11, "Description:\r\nModem IP2 For communicate with the Server\r\nValid data:\r\nValid TCP/I" +
        "P address\r\n");
            this.textBox_Config11.TextChanged += new System.EventHandler(this.textBox_Config11_TextChanged);
            // 
            // textBox_Config10
            // 
            this.textBox_Config10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config10.Location = new System.Drawing.Point(124, 154);
            this.textBox_Config10.Name = "textBox_Config10";
            this.textBox_Config10.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config10.TabIndex = 2;
            this.toolTip2.SetToolTip(this.textBox_Config10, "Description:\r\nModem IP1 For communicate with the Server\r\nValid data:\r\nValid TCP/I" +
        "P address\r\n\r\n\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config10, "Description:\r\nModem IP1 For communicate with the Server\r\nValid data:\r\nValid TCP/I" +
        "P address\r\n\r\n");
            this.textBox_Config10.TextChanged += new System.EventHandler(this.textBox_Config10_TextChanged);
            // 
            // textBox_Config9
            // 
            this.textBox_Config9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config9.Location = new System.Drawing.Point(124, 57);
            this.textBox_Config9.Name = "textBox_Config9";
            this.textBox_Config9.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config9.TabIndex = 1;
            this.toolTip2.SetToolTip(this.textBox_Config9, "Description:\r\nan option to set SIM card details according to cellular provider op" +
        "erator. \r\nValid Data:\r\nstring");
            this.toolTip1.SetToolTip(this.textBox_Config9, "Description:\r\nan option to set SIM card details according to cellular provider op" +
        "erator. \r\nValid Data:\r\nstring");
            this.textBox_Config9.TextChanged += new System.EventHandler(this.textBox_Config9_TextChanged);
            // 
            // textBox_Config8
            // 
            this.textBox_Config8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config8.Location = new System.Drawing.Point(124, 391);
            this.textBox_Config8.Name = "textBox_Config8";
            this.textBox_Config8.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config8.TabIndex = 9;
            this.toolTip2.SetToolTip(this.textBox_Config8, "Description:\r\nan option to set time interval of status message which will be sent" +
        " to remote server. \r\nValid data:\r\nnumber\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config8, "Description:\r\nan option to set time interval of status message which will be sent" +
        " to remote server. \r\nValid data:\r\nnumber\r\n");
            this.textBox_Config8.TextChanged += new System.EventHandler(this.textBox_Config8_TextChanged);
            // 
            // textBox_Config6
            // 
            this.textBox_Config6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config6.Location = new System.Drawing.Point(124, 257);
            this.textBox_Config6.Name = "textBox_Config6";
            this.textBox_Config6.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config6.TabIndex = 5;
            this.toolTip2.SetToolTip(this.textBox_Config6, "Description:\r\nModem Port for IP2 For communicate with the Server\r\nValid data:\r\nVa" +
        "lid Port 0-99999");
            this.toolTip1.SetToolTip(this.textBox_Config6, "Description:\r\nModem Port for IP2 For communicate with the Server\r\nValid data:\r\nVa" +
        "lid Port 0-99999\r\n\r\n");
            this.textBox_Config6.TextChanged += new System.EventHandler(this.textBox_Config6_TextChanged);
            // 
            // textBox_Config5
            // 
            this.textBox_Config5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config5.Location = new System.Drawing.Point(383, 23);
            this.textBox_Config5.Name = "textBox_Config5";
            this.textBox_Config5.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config5.TabIndex = 10;
            this.toolTip2.SetToolTip(this.textBox_Config5, "Description:\r\nan option to configure vehicle\'s thresholds for low level battery. " +
        "\r\nValid data:\r\n0-9\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config5, "Description:\r\nan option to configure vehicle\'s thresholds for low level battery. " +
        "\r\nValid data:\r\n0-9\r\n");
            this.textBox_Config5.TextChanged += new System.EventHandler(this.textBox_Config5_TextChanged);
            // 
            // textBox_Config4
            // 
            this.textBox_Config4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config4.Location = new System.Drawing.Point(124, 24);
            this.textBox_Config4.Name = "textBox_Config4";
            this.textBox_Config4.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config4.TabIndex = 0;
            this.toolTip2.SetToolTip(this.textBox_Config4, "Description:\r\nchange the password for the unit.\r\nValid Data:\r\nstring  Max 15");
            this.toolTip1.SetToolTip(this.textBox_Config4, "Description:\r\nchange the password for the unit.\r\nValid Data:\r\nstring  Max 15\r\n\r\n\r" +
        "\n");
            this.textBox_Config4.TextChanged += new System.EventHandler(this.textBox_Config4_TextChanged);
            // 
            // textBox_Config7
            // 
            this.textBox_Config7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config7.Location = new System.Drawing.Point(351, 503);
            this.textBox_Config7.Name = "textBox_Config7";
            this.textBox_Config7.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config7.TabIndex = 11;
            this.toolTip2.SetToolTip(this.textBox_Config7, "Description:\r\nto set the speed limit threshold. \r\nValid data:\r\n40-350\r\n");
            this.toolTip1.SetToolTip(this.textBox_Config7, "Description:\r\nto set the speed limit threshold. \r\nValid data:\r\n40-350\r\n");
            this.textBox_Config7.Visible = false;
            this.textBox_Config7.TextChanged += new System.EventHandler(this.textBox_Config7_TextChanged);
            // 
            // label_Config13
            // 
            this.label_Config13.AutoSize = true;
            this.label_Config13.Enabled = false;
            this.label_Config13.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Config13.Location = new System.Drawing.Point(252, 542);
            this.label_Config13.Name = "label_Config13";
            this.label_Config13.Size = new System.Drawing.Size(93, 15);
            this.label_Config13.TabIndex = 72;
            this.label_Config13.Text = "Alarm Via SMS :";
            this.label_Config13.Visible = false;
            // 
            // textBox_Config13
            // 
            this.textBox_Config13.Enabled = false;
            this.textBox_Config13.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Config13.Location = new System.Drawing.Point(351, 539);
            this.textBox_Config13.Name = "textBox_Config13";
            this.textBox_Config13.Size = new System.Drawing.Size(119, 27);
            this.textBox_Config13.TabIndex = 43;
            this.toolTip2.SetToolTip(this.textBox_Config13, resources.GetString("textBox_Config13.ToolTip"));
            this.toolTip1.SetToolTip(this.textBox_Config13, resources.GetString("textBox_Config13.ToolTip1"));
            this.textBox_Config13.Visible = false;
            this.textBox_Config13.TextChanged += new System.EventHandler(this.textBox_Config13_TextChanged);
            // 
            // button30
            // 
            this.button30.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button30.Location = new System.Drawing.Point(515, 150);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(140, 27);
            this.button30.TabIndex = 87;
            this.button30.Text = "Clear Config";
            this.button30.UseVisualStyleBackColor = true;
            this.button30.Click += new System.EventHandler(this.button30_Click_1);
            // 
            // comboBox_SystemConfigType
            // 
            this.comboBox_SystemConfigType.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_SystemConfigType.FormattingEnabled = true;
            this.comboBox_SystemConfigType.Items.AddRange(new object[] {
            "AVL",
            "AVL CAN",
            "Cellular Alarm"});
            this.comboBox_SystemConfigType.Location = new System.Drawing.Point(807, 149);
            this.comboBox_SystemConfigType.Name = "comboBox_SystemConfigType";
            this.comboBox_SystemConfigType.Size = new System.Drawing.Size(193, 27);
            this.comboBox_SystemConfigType.TabIndex = 33;
            this.comboBox_SystemConfigType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox_ParseMessages);
            this.tabPage1.Controls.Add(this.textBox_IDKey);
            this.tabPage1.Controls.Add(this.label_TimeDate2);
            this.tabPage1.Controls.Add(this.groupBox_FOTA);
            this.tabPage1.Controls.Add(this.checkBox_EchoResponse);
            this.tabPage1.Controls.Add(this.groupBox_ServerSettings);
            this.tabPage1.Controls.Add(this.groupBox_ConnectionTimedOut);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1900, 936);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Server";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox_ParseMessages
            // 
            this.checkBox_ParseMessages.AutoSize = true;
            this.checkBox_ParseMessages.Location = new System.Drawing.Point(116, 343);
            this.checkBox_ParseMessages.Name = "checkBox_ParseMessages";
            this.checkBox_ParseMessages.Size = new System.Drawing.Size(124, 22);
            this.checkBox_ParseMessages.TabIndex = 103;
            this.checkBox_ParseMessages.Text = "Parse messages";
            this.checkBox_ParseMessages.UseVisualStyleBackColor = true;
            this.checkBox_ParseMessages.CheckedChanged += new System.EventHandler(this.checkBox_ParseMessages_CheckedChanged);
            // 
            // textBox_IDKey
            // 
            this.textBox_IDKey.Location = new System.Drawing.Point(944, 161);
            this.textBox_IDKey.Name = "textBox_IDKey";
            this.textBox_IDKey.Size = new System.Drawing.Size(317, 152);
            this.textBox_IDKey.TabIndex = 102;
            this.textBox_IDKey.Text = "";
            // 
            // label_TimeDate2
            // 
            this.label_TimeDate2.AutoSize = true;
            this.label_TimeDate2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TimeDate2.Location = new System.Drawing.Point(1030, 5);
            this.label_TimeDate2.Name = "label_TimeDate2";
            this.label_TimeDate2.Size = new System.Drawing.Size(17, 19);
            this.label_TimeDate2.TabIndex = 98;
            this.label_TimeDate2.Text = "0";
            // 
            // groupBox_FOTA
            // 
            this.groupBox_FOTA.Controls.Add(this.button_StartFOTAProcess);
            this.groupBox_FOTA.Controls.Add(this.textBox_TotalFileLength);
            this.groupBox_FOTA.Controls.Add(this.textBox_MaximumNumberReceivedRequest);
            this.groupBox_FOTA.Controls.Add(this.button35);
            this.groupBox_FOTA.Controls.Add(this.button_StartFOTA);
            this.groupBox_FOTA.Controls.Add(this.textBox_TotalFrames1280Bytes);
            this.groupBox_FOTA.Controls.Add(this.textBox_FOTA);
            this.groupBox_FOTA.Controls.Add(this.button5);
            this.groupBox_FOTA.Location = new System.Drawing.Point(5, 391);
            this.groupBox_FOTA.Name = "groupBox_FOTA";
            this.groupBox_FOTA.Size = new System.Drawing.Size(269, 331);
            this.groupBox_FOTA.TabIndex = 12;
            this.groupBox_FOTA.TabStop = false;
            this.groupBox_FOTA.Text = "FOTA";
            // 
            // button_StartFOTAProcess
            // 
            this.button_StartFOTAProcess.Enabled = false;
            this.button_StartFOTAProcess.Location = new System.Drawing.Point(206, 107);
            this.button_StartFOTAProcess.Name = "button_StartFOTAProcess";
            this.button_StartFOTAProcess.Size = new System.Drawing.Size(57, 44);
            this.button_StartFOTAProcess.TabIndex = 21;
            this.button_StartFOTAProcess.Text = "Start FOTA";
            this.button_StartFOTAProcess.UseVisualStyleBackColor = true;
            this.button_StartFOTAProcess.Click += new System.EventHandler(this.button34_Click_1);
            // 
            // textBox_TotalFileLength
            // 
            this.textBox_TotalFileLength.Location = new System.Drawing.Point(206, 78);
            this.textBox_TotalFileLength.Name = "textBox_TotalFileLength";
            this.textBox_TotalFileLength.ReadOnly = true;
            this.textBox_TotalFileLength.Size = new System.Drawing.Size(57, 26);
            this.textBox_TotalFileLength.TabIndex = 20;
            this.toolTip2.SetToolTip(this.textBox_TotalFileLength, "Total file length in bytes");
            this.toolTip1.SetToolTip(this.textBox_TotalFileLength, "Total file length in bytes");
            // 
            // textBox_MaximumNumberReceivedRequest
            // 
            this.textBox_MaximumNumberReceivedRequest.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_MaximumNumberReceivedRequest.Location = new System.Drawing.Point(4, 107);
            this.textBox_MaximumNumberReceivedRequest.Name = "textBox_MaximumNumberReceivedRequest";
            this.textBox_MaximumNumberReceivedRequest.Size = new System.Drawing.Size(196, 218);
            this.textBox_MaximumNumberReceivedRequest.TabIndex = 19;
            this.textBox_MaximumNumberReceivedRequest.Text = "";
            // 
            // button35
            // 
            this.button35.Location = new System.Drawing.Point(206, 300);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(57, 23);
            this.button35.TabIndex = 18;
            this.button35.Text = "Clear";
            this.button35.UseVisualStyleBackColor = true;
            this.button35.Click += new System.EventHandler(this.button35_Click);
            // 
            // button_StartFOTA
            // 
            this.button_StartFOTA.Enabled = false;
            this.button_StartFOTA.Location = new System.Drawing.Point(206, 273);
            this.button_StartFOTA.Name = "button_StartFOTA";
            this.button_StartFOTA.Size = new System.Drawing.Size(57, 23);
            this.button_StartFOTA.TabIndex = 16;
            this.button_StartFOTA.Text = "--->";
            this.button_StartFOTA.UseVisualStyleBackColor = true;
            this.button_StartFOTA.Click += new System.EventHandler(this.button33_Click);
            // 
            // textBox_TotalFrames1280Bytes
            // 
            this.textBox_TotalFrames1280Bytes.Location = new System.Drawing.Point(206, 49);
            this.textBox_TotalFrames1280Bytes.Name = "textBox_TotalFrames1280Bytes";
            this.textBox_TotalFrames1280Bytes.ReadOnly = true;
            this.textBox_TotalFrames1280Bytes.Size = new System.Drawing.Size(57, 26);
            this.textBox_TotalFrames1280Bytes.TabIndex = 14;
            this.toolTip2.SetToolTip(this.textBox_TotalFrames1280Bytes, "Total Frames 1280 Bytes");
            this.toolTip1.SetToolTip(this.textBox_TotalFrames1280Bytes, "Total Frames 1280 Bytes");
            this.textBox_TotalFrames1280Bytes.TextChanged += new System.EventHandler(this.textBox_TotalFrames256Bytes_TextChanged);
            // 
            // textBox_FOTA
            // 
            this.textBox_FOTA.Location = new System.Drawing.Point(7, 49);
            this.textBox_FOTA.Multiline = true;
            this.textBox_FOTA.Name = "textBox_FOTA";
            this.textBox_FOTA.Size = new System.Drawing.Size(193, 52);
            this.textBox_FOTA.TabIndex = 13;
            this.textBox_FOTA.TextChanged += new System.EventHandler(this.textBox_FOTA_TextChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(7, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(98, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "Choose File";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // checkBox_EchoResponse
            // 
            this.checkBox_EchoResponse.AutoSize = true;
            this.checkBox_EchoResponse.Location = new System.Drawing.Point(5, 343);
            this.checkBox_EchoResponse.Name = "checkBox_EchoResponse";
            this.checkBox_EchoResponse.Size = new System.Drawing.Size(117, 22);
            this.checkBox_EchoResponse.TabIndex = 10;
            this.checkBox_EchoResponse.Text = "Send ACK Back";
            this.checkBox_EchoResponse.UseVisualStyleBackColor = true;
            this.checkBox_EchoResponse.CheckedChanged += new System.EventHandler(this.checkBox_EchoResponse_CheckedChanged);
            // 
            // groupBox_ConnectionTimedOut
            // 
            this.groupBox_ConnectionTimedOut.Controls.Add(this.textBox_CurrentTimeOut);
            this.groupBox_ConnectionTimedOut.Controls.Add(this.button_SetTimedOut);
            this.groupBox_ConnectionTimedOut.Controls.Add(this.textBox_ConnectionTimedOut);
            this.groupBox_ConnectionTimedOut.Location = new System.Drawing.Point(3, 288);
            this.groupBox_ConnectionTimedOut.Name = "groupBox_ConnectionTimedOut";
            this.groupBox_ConnectionTimedOut.Size = new System.Drawing.Size(273, 53);
            this.groupBox_ConnectionTimedOut.TabIndex = 9;
            this.groupBox_ConnectionTimedOut.TabStop = false;
            this.groupBox_ConnectionTimedOut.Text = "Server Connection Timed Out (seconds)";
            // 
            // textBox_CurrentTimeOut
            // 
            this.textBox_CurrentTimeOut.Location = new System.Drawing.Point(146, 21);
            this.textBox_CurrentTimeOut.Name = "textBox_CurrentTimeOut";
            this.textBox_CurrentTimeOut.ReadOnly = true;
            this.textBox_CurrentTimeOut.Size = new System.Drawing.Size(62, 26);
            this.textBox_CurrentTimeOut.TabIndex = 10;
            this.toolTip1.SetToolTip(this.textBox_CurrentTimeOut, "Current Timed Out");
            // 
            // button_SetTimedOut
            // 
            this.button_SetTimedOut.Location = new System.Drawing.Point(65, 21);
            this.button_SetTimedOut.Name = "button_SetTimedOut";
            this.button_SetTimedOut.Size = new System.Drawing.Size(75, 23);
            this.button_SetTimedOut.TabIndex = 9;
            this.button_SetTimedOut.Text = "Set";
            this.toolTip1.SetToolTip(this.button_SetTimedOut, "Set Timed Out");
            this.button_SetTimedOut.UseVisualStyleBackColor = true;
            this.button_SetTimedOut.Click += new System.EventHandler(this.button_SetTimedOut_Click);
            // 
            // textBox_ConnectionTimedOut
            // 
            this.textBox_ConnectionTimedOut.Location = new System.Drawing.Point(6, 22);
            this.textBox_ConnectionTimedOut.Name = "textBox_ConnectionTimedOut";
            this.textBox_ConnectionTimedOut.Size = new System.Drawing.Size(53, 26);
            this.textBox_ConnectionTimedOut.TabIndex = 8;
            this.textBox_ConnectionTimedOut.Text = "300";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.groupBox39);
            this.tabPage7.Controls.Add(this.groupBox37);
            this.tabPage7.Controls.Add(this.groupBox35);
            this.tabPage7.Controls.Add(this.groupBox34);
            this.tabPage7.Controls.Add(this.groupBox33);
            this.tabPage7.Location = new System.Drawing.Point(4, 27);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(1900, 936);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "SMS";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // groupBox39
            // 
            this.groupBox39.Controls.Add(this.listBox_SMSCommands);
            this.groupBox39.Controls.Add(this.button37);
            this.groupBox39.Controls.Add(this.button38);
            this.groupBox39.Controls.Add(this.button39);
            this.groupBox39.Controls.Add(this.button40);
            this.groupBox39.Controls.Add(this.button41);
            this.groupBox39.Location = new System.Drawing.Point(476, 7);
            this.groupBox39.Name = "groupBox39";
            this.groupBox39.Size = new System.Drawing.Size(315, 429);
            this.groupBox39.TabIndex = 6;
            this.groupBox39.TabStop = false;
            this.groupBox39.Text = "SMS commands";
            this.groupBox39.Enter += new System.EventHandler(this.groupBox39_Enter);
            // 
            // listBox_SMSCommands
            // 
            this.listBox_SMSCommands.FormattingEnabled = true;
            this.listBox_SMSCommands.ItemHeight = 18;
            this.listBox_SMSCommands.Location = new System.Drawing.Point(6, 17);
            this.listBox_SMSCommands.Name = "listBox_SMSCommands";
            this.listBox_SMSCommands.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_SMSCommands.Size = new System.Drawing.Size(303, 328);
            this.listBox_SMSCommands.TabIndex = 6;
            this.listBox_SMSCommands.SelectedIndexChanged += new System.EventHandler(this.listBox_SMSCommands_SelectedIndexChanged_1);
            // 
            // button37
            // 
            this.button37.Location = new System.Drawing.Point(169, 359);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(75, 23);
            this.button37.TabIndex = 5;
            this.button37.Text = "Edit";
            this.button37.UseVisualStyleBackColor = true;
            this.button37.Click += new System.EventHandler(this.button37_Click);
            // 
            // button38
            // 
            this.button38.Location = new System.Drawing.Point(88, 395);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(75, 23);
            this.button38.TabIndex = 4;
            this.button38.Text = "Import";
            this.button38.UseVisualStyleBackColor = true;
            this.button38.Click += new System.EventHandler(this.button38_Click);
            // 
            // button39
            // 
            this.button39.Location = new System.Drawing.Point(7, 395);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(75, 23);
            this.button39.TabIndex = 3;
            this.button39.Text = "Export";
            this.button39.UseVisualStyleBackColor = true;
            this.button39.Click += new System.EventHandler(this.button39_Click_1);
            // 
            // button40
            // 
            this.button40.Location = new System.Drawing.Point(88, 359);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(75, 23);
            this.button40.TabIndex = 2;
            this.button40.Text = "Remove";
            this.button40.UseVisualStyleBackColor = true;
            this.button40.Click += new System.EventHandler(this.button40_Click);
            // 
            // button41
            // 
            this.button41.Location = new System.Drawing.Point(7, 359);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(75, 23);
            this.button41.TabIndex = 1;
            this.button41.Text = "Add";
            this.button41.UseVisualStyleBackColor = true;
            this.button41.Click += new System.EventHandler(this.button41_Click);
            // 
            // groupBox37
            // 
            this.groupBox37.Controls.Add(this.richTextBox_SMSConsole);
            this.groupBox37.Controls.Add(this.checkBox_RecordSMSConsole);
            this.groupBox37.Controls.Add(this.checkBox_PauseSMSConsole);
            this.groupBox37.Controls.Add(this.button_ClearSMSConsole);
            this.groupBox37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox37.Location = new System.Drawing.Point(797, 7);
            this.groupBox37.Name = "groupBox37";
            this.groupBox37.Size = new System.Drawing.Size(463, 721);
            this.groupBox37.TabIndex = 8;
            this.groupBox37.TabStop = false;
            this.groupBox37.Text = "SMS Console";
            // 
            // richTextBox_SMSConsole
            // 
            this.richTextBox_SMSConsole.EnableAutoDragDrop = true;
            this.richTextBox_SMSConsole.Location = new System.Drawing.Point(6, 17);
            this.richTextBox_SMSConsole.Name = "richTextBox_SMSConsole";
            this.richTextBox_SMSConsole.Size = new System.Drawing.Size(451, 607);
            this.richTextBox_SMSConsole.TabIndex = 0;
            this.richTextBox_SMSConsole.Text = "";
            // 
            // checkBox_RecordSMSConsole
            // 
            this.checkBox_RecordSMSConsole.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_RecordSMSConsole.AutoSize = true;
            this.checkBox_RecordSMSConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_RecordSMSConsole.Location = new System.Drawing.Point(222, 630);
            this.checkBox_RecordSMSConsole.Name = "checkBox_RecordSMSConsole";
            this.checkBox_RecordSMSConsole.Size = new System.Drawing.Size(99, 26);
            this.checkBox_RecordSMSConsole.TabIndex = 7;
            this.checkBox_RecordSMSConsole.Text = "Record Log";
            this.checkBox_RecordSMSConsole.UseVisualStyleBackColor = true;
            // 
            // checkBox_PauseSMSConsole
            // 
            this.checkBox_PauseSMSConsole.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_PauseSMSConsole.AutoSize = true;
            this.checkBox_PauseSMSConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_PauseSMSConsole.Location = new System.Drawing.Point(327, 630);
            this.checkBox_PauseSMSConsole.Name = "checkBox_PauseSMSConsole";
            this.checkBox_PauseSMSConsole.Size = new System.Drawing.Size(62, 26);
            this.checkBox_PauseSMSConsole.TabIndex = 5;
            this.checkBox_PauseSMSConsole.Text = "Pause";
            this.checkBox_PauseSMSConsole.UseVisualStyleBackColor = true;
            // 
            // button_ClearSMSConsole
            // 
            this.button_ClearSMSConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ClearSMSConsole.Location = new System.Drawing.Point(395, 630);
            this.button_ClearSMSConsole.Name = "button_ClearSMSConsole";
            this.button_ClearSMSConsole.Size = new System.Drawing.Size(62, 26);
            this.button_ClearSMSConsole.TabIndex = 6;
            this.button_ClearSMSConsole.Text = "Clear";
            this.button_ClearSMSConsole.UseVisualStyleBackColor = true;
            // 
            // groupBox35
            // 
            this.groupBox35.Controls.Add(this.checkBox_DebugSMS);
            this.groupBox35.Controls.Add(this.checkBox_OpenPortSMS);
            this.groupBox35.Controls.Add(this.button36);
            this.groupBox35.Controls.Add(this.comboBox_ComportSMS);
            this.groupBox35.Controls.Add(this.richTextBox_ModemStatus);
            this.groupBox35.Location = new System.Drawing.Point(8, 587);
            this.groupBox35.Name = "groupBox35";
            this.groupBox35.Size = new System.Drawing.Size(456, 147);
            this.groupBox35.TabIndex = 7;
            this.groupBox35.TabStop = false;
            this.groupBox35.Text = "Modem Status";
            // 
            // checkBox_DebugSMS
            // 
            this.checkBox_DebugSMS.AutoSize = true;
            this.checkBox_DebugSMS.Location = new System.Drawing.Point(390, 54);
            this.checkBox_DebugSMS.Name = "checkBox_DebugSMS";
            this.checkBox_DebugSMS.Size = new System.Drawing.Size(67, 22);
            this.checkBox_DebugSMS.TabIndex = 11;
            this.checkBox_DebugSMS.Text = "Debug";
            this.checkBox_DebugSMS.UseVisualStyleBackColor = true;
            // 
            // checkBox_OpenPortSMS
            // 
            this.checkBox_OpenPortSMS.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_OpenPortSMS.AutoSize = true;
            this.checkBox_OpenPortSMS.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_OpenPortSMS.Location = new System.Drawing.Point(363, 20);
            this.checkBox_OpenPortSMS.Name = "checkBox_OpenPortSMS";
            this.checkBox_OpenPortSMS.Size = new System.Drawing.Size(84, 29);
            this.checkBox_OpenPortSMS.TabIndex = 10;
            this.checkBox_OpenPortSMS.Text = "Open Port";
            this.checkBox_OpenPortSMS.UseVisualStyleBackColor = true;
            this.checkBox_OpenPortSMS.CheckedChanged += new System.EventHandler(this.checkBox_OpenPortSMS_CheckedChanged);
            // 
            // button36
            // 
            this.button36.Location = new System.Drawing.Point(269, 109);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(75, 23);
            this.button36.TabIndex = 6;
            this.button36.Text = "Clear";
            this.button36.UseVisualStyleBackColor = true;
            this.button36.Click += new System.EventHandler(this.button36_Click);
            // 
            // comboBox_ComportSMS
            // 
            this.comboBox_ComportSMS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ComportSMS.FormattingEnabled = true;
            this.comboBox_ComportSMS.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            this.comboBox_ComportSMS.Location = new System.Drawing.Point(290, 22);
            this.comboBox_ComportSMS.Name = "comboBox_ComportSMS";
            this.comboBox_ComportSMS.Size = new System.Drawing.Size(67, 26);
            this.comboBox_ComportSMS.TabIndex = 9;
            this.comboBox_ComportSMS.Tag = "1";
            this.comboBox_ComportSMS.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_2);
            // 
            // richTextBox_ModemStatus
            // 
            this.richTextBox_ModemStatus.Location = new System.Drawing.Point(7, 19);
            this.richTextBox_ModemStatus.Name = "richTextBox_ModemStatus";
            this.richTextBox_ModemStatus.Size = new System.Drawing.Size(256, 115);
            this.richTextBox_ModemStatus.TabIndex = 0;
            this.richTextBox_ModemStatus.Text = "";
            // 
            // groupBox34
            // 
            this.groupBox34.Controls.Add(this.button_Ring);
            this.groupBox34.Controls.Add(this.GrooupBox_Encryption);
            this.groupBox34.Controls.Add(this.checkBox_SMSencrypted);
            this.groupBox34.Controls.Add(this.checkBox_SendSMSAsIs);
            this.groupBox34.Controls.Add(this.checkBox1);
            this.groupBox34.Controls.Add(this.label_SMSSendCharacters);
            this.groupBox34.Controls.Add(this.button_SendSelectedSMS);
            this.groupBox34.Controls.Add(this.button_SendAllCheckedSMS);
            this.groupBox34.Controls.Add(this.richTextBox_TextSendSMS);
            this.groupBox34.Location = new System.Drawing.Point(8, 436);
            this.groupBox34.Name = "groupBox34";
            this.groupBox34.Size = new System.Drawing.Size(783, 147);
            this.groupBox34.TabIndex = 6;
            this.groupBox34.TabStop = false;
            this.groupBox34.Text = "SMS text";
            // 
            // button_Ring
            // 
            this.button_Ring.Location = new System.Drawing.Point(88, 112);
            this.button_Ring.Name = "button_Ring";
            this.button_Ring.Size = new System.Drawing.Size(141, 23);
            this.button_Ring.TabIndex = 14;
            this.button_Ring.Text = "Ring";
            this.toolTip2.SetToolTip(this.button_Ring, "Ring to contact");
            this.toolTip1.SetToolTip(this.button_Ring, "Ring to contact");
            this.button_Ring.UseVisualStyleBackColor = true;
            this.button_Ring.Click += new System.EventHandler(this.button_Ring_Click);
            // 
            // GrooupBox_Encryption
            // 
            this.GrooupBox_Encryption.Controls.Add(this.label5);
            this.GrooupBox_Encryption.Controls.Add(this.textBox_CodeArrayForSMS);
            this.GrooupBox_Encryption.Controls.Add(this.label2);
            this.GrooupBox_Encryption.Controls.Add(this.textBox_UnitIDForSMS);
            this.GrooupBox_Encryption.Enabled = false;
            this.GrooupBox_Encryption.Location = new System.Drawing.Point(595, 38);
            this.GrooupBox_Encryption.Name = "GrooupBox_Encryption";
            this.GrooupBox_Encryption.Size = new System.Drawing.Size(184, 103);
            this.GrooupBox_Encryption.TabIndex = 13;
            this.GrooupBox_Encryption.TabStop = false;
            this.GrooupBox_Encryption.Text = "Encryption";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Code";
            // 
            // textBox_CodeArrayForSMS
            // 
            this.textBox_CodeArrayForSMS.Location = new System.Drawing.Point(54, 46);
            this.textBox_CodeArrayForSMS.MaxLength = 4;
            this.textBox_CodeArrayForSMS.Name = "textBox_CodeArrayForSMS";
            this.textBox_CodeArrayForSMS.Size = new System.Drawing.Size(124, 26);
            this.textBox_CodeArrayForSMS.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "UnitID";
            // 
            // textBox_UnitIDForSMS
            // 
            this.textBox_UnitIDForSMS.Location = new System.Drawing.Point(54, 17);
            this.textBox_UnitIDForSMS.MaxLength = 16;
            this.textBox_UnitIDForSMS.Name = "textBox_UnitIDForSMS";
            this.textBox_UnitIDForSMS.Size = new System.Drawing.Size(124, 26);
            this.textBox_UnitIDForSMS.TabIndex = 0;
            // 
            // checkBox_SMSencrypted
            // 
            this.checkBox_SMSencrypted.AutoSize = true;
            this.checkBox_SMSencrypted.Location = new System.Drawing.Point(595, 20);
            this.checkBox_SMSencrypted.Name = "checkBox_SMSencrypted";
            this.checkBox_SMSencrypted.Size = new System.Drawing.Size(89, 22);
            this.checkBox_SMSencrypted.TabIndex = 12;
            this.checkBox_SMSencrypted.Text = "Encrypted";
            this.checkBox_SMSencrypted.UseVisualStyleBackColor = true;
            this.checkBox_SMSencrypted.CheckedChanged += new System.EventHandler(this.checkBox_SMSencrypted_CheckedChanged);
            // 
            // checkBox_SendSMSAsIs
            // 
            this.checkBox_SendSMSAsIs.AutoSize = true;
            this.checkBox_SendSMSAsIs.Location = new System.Drawing.Point(240, 115);
            this.checkBox_SendSMSAsIs.Name = "checkBox_SendSMSAsIs";
            this.checkBox_SendSMSAsIs.Size = new System.Drawing.Size(116, 22);
            this.checkBox_SendSMSAsIs.TabIndex = 11;
            this.checkBox_SendSMSAsIs.Text = "Send SMS as is";
            this.checkBox_SendSMSAsIs.UseVisualStyleBackColor = true;
            this.checkBox_SendSMSAsIs.CheckedChanged += new System.EventHandler(this.checkBox_SendSMSAsIs_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(145, 145);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(92, 22);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label_SMSSendCharacters
            // 
            this.label_SMSSendCharacters.AutoSize = true;
            this.label_SMSSendCharacters.Location = new System.Drawing.Point(12, 119);
            this.label_SMSSendCharacters.Name = "label_SMSSendCharacters";
            this.label_SMSSendCharacters.Size = new System.Drawing.Size(42, 18);
            this.label_SMSSendCharacters.TabIndex = 9;
            this.label_SMSSendCharacters.Text = "0/160";
            // 
            // button_SendSelectedSMS
            // 
            this.button_SendSelectedSMS.Location = new System.Drawing.Point(482, 115);
            this.button_SendSelectedSMS.Name = "button_SendSelectedSMS";
            this.button_SendSelectedSMS.Size = new System.Drawing.Size(107, 23);
            this.button_SendSelectedSMS.TabIndex = 8;
            this.button_SendSelectedSMS.Text = "Send SMS One";
            this.toolTip2.SetToolTip(this.button_SendSelectedSMS, "Send SMS to the selected contact");
            this.toolTip1.SetToolTip(this.button_SendSelectedSMS, "Send SMS to the selected contact");
            this.button_SendSelectedSMS.UseVisualStyleBackColor = true;
            this.button_SendSelectedSMS.Click += new System.EventHandler(this.button_SendSelectedSMS_Click);
            // 
            // button_SendAllCheckedSMS
            // 
            this.button_SendAllCheckedSMS.Location = new System.Drawing.Point(353, 115);
            this.button_SendAllCheckedSMS.Name = "button_SendAllCheckedSMS";
            this.button_SendAllCheckedSMS.Size = new System.Drawing.Size(123, 23);
            this.button_SendAllCheckedSMS.TabIndex = 7;
            this.button_SendAllCheckedSMS.Text = "Send SMS Multi";
            this.toolTip2.SetToolTip(this.button_SendAllCheckedSMS, "Send SMS to all the checked contacts");
            this.toolTip1.SetToolTip(this.button_SendAllCheckedSMS, "Send SMS to all the checked contacts");
            this.button_SendAllCheckedSMS.UseVisualStyleBackColor = true;
            this.button_SendAllCheckedSMS.Click += new System.EventHandler(this.button39_Click);
            // 
            // richTextBox_TextSendSMS
            // 
            this.richTextBox_TextSendSMS.AutoWordSelection = true;
            this.richTextBox_TextSendSMS.EnableAutoDragDrop = true;
            this.richTextBox_TextSendSMS.Location = new System.Drawing.Point(10, 18);
            this.richTextBox_TextSendSMS.Name = "richTextBox_TextSendSMS";
            this.richTextBox_TextSendSMS.Size = new System.Drawing.Size(579, 91);
            this.richTextBox_TextSendSMS.TabIndex = 2;
            this.richTextBox_TextSendSMS.Text = "";
            this.richTextBox_TextSendSMS.TextChanged += new System.EventHandler(this.richTextBox_TextSendSMS_TextChanged);
            // 
            // groupBox33
            // 
            this.groupBox33.Controls.Add(this.button34);
            this.groupBox33.Controls.Add(this.richTextBox_ContactDetails);
            this.groupBox33.Controls.Add(this.button33);
            this.groupBox33.Controls.Add(this.button_ImportToXML);
            this.groupBox33.Controls.Add(this.button_ExportToXML);
            this.groupBox33.Controls.Add(this.button_RemoveContact);
            this.groupBox33.Controls.Add(this.button_AddContact);
            this.groupBox33.Controls.Add(this.checkedListBox_PhoneBook);
            this.groupBox33.Location = new System.Drawing.Point(8, 7);
            this.groupBox33.Name = "groupBox33";
            this.groupBox33.Size = new System.Drawing.Size(462, 429);
            this.groupBox33.TabIndex = 1;
            this.groupBox33.TabStop = false;
            this.groupBox33.Text = "Phone Book";
            this.groupBox33.Enter += new System.EventHandler(this.groupBox33_Enter);
            // 
            // button34
            // 
            this.button34.Location = new System.Drawing.Point(169, 400);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(75, 23);
            this.button34.TabIndex = 7;
            this.button34.Text = "Backup";
            this.button34.UseVisualStyleBackColor = true;
            this.button34.Click += new System.EventHandler(this.button34_Click_2);
            // 
            // richTextBox_ContactDetails
            // 
            this.richTextBox_ContactDetails.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox_ContactDetails.Location = new System.Drawing.Point(290, 19);
            this.richTextBox_ContactDetails.Name = "richTextBox_ContactDetails";
            this.richTextBox_ContactDetails.Size = new System.Drawing.Size(166, 328);
            this.richTextBox_ContactDetails.TabIndex = 6;
            this.richTextBox_ContactDetails.Text = "";
            this.richTextBox_ContactDetails.TextChanged += new System.EventHandler(this.richTextBox_ContactDetails_TextChanged);
            // 
            // button33
            // 
            this.button33.Location = new System.Drawing.Point(169, 371);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(75, 23);
            this.button33.TabIndex = 5;
            this.button33.Text = "Edit";
            this.button33.UseVisualStyleBackColor = true;
            this.button33.Click += new System.EventHandler(this.button33_Click_2);
            // 
            // button_ImportToXML
            // 
            this.button_ImportToXML.Location = new System.Drawing.Point(88, 400);
            this.button_ImportToXML.Name = "button_ImportToXML";
            this.button_ImportToXML.Size = new System.Drawing.Size(75, 23);
            this.button_ImportToXML.TabIndex = 4;
            this.button_ImportToXML.Text = "Import";
            this.button_ImportToXML.UseVisualStyleBackColor = true;
            this.button_ImportToXML.Click += new System.EventHandler(this.button_ImportToXML_Click);
            // 
            // button_ExportToXML
            // 
            this.button_ExportToXML.Location = new System.Drawing.Point(7, 400);
            this.button_ExportToXML.Name = "button_ExportToXML";
            this.button_ExportToXML.Size = new System.Drawing.Size(75, 23);
            this.button_ExportToXML.TabIndex = 3;
            this.button_ExportToXML.Text = "Export";
            this.button_ExportToXML.UseVisualStyleBackColor = true;
            this.button_ExportToXML.Click += new System.EventHandler(this.button_ExportToXML_Click);
            // 
            // button_RemoveContact
            // 
            this.button_RemoveContact.Location = new System.Drawing.Point(88, 371);
            this.button_RemoveContact.Name = "button_RemoveContact";
            this.button_RemoveContact.Size = new System.Drawing.Size(75, 23);
            this.button_RemoveContact.TabIndex = 2;
            this.button_RemoveContact.Text = "Remove";
            this.button_RemoveContact.UseVisualStyleBackColor = true;
            this.button_RemoveContact.Click += new System.EventHandler(this.button_RemoveContact_Click);
            // 
            // button_AddContact
            // 
            this.button_AddContact.Location = new System.Drawing.Point(7, 371);
            this.button_AddContact.Name = "button_AddContact";
            this.button_AddContact.Size = new System.Drawing.Size(75, 23);
            this.button_AddContact.TabIndex = 1;
            this.button_AddContact.Text = "Add";
            this.button_AddContact.UseVisualStyleBackColor = true;
            this.button_AddContact.Click += new System.EventHandler(this.button33_Click_1);
            // 
            // checkedListBox_PhoneBook
            // 
            this.checkedListBox_PhoneBook.FormattingEnabled = true;
            this.checkedListBox_PhoneBook.Location = new System.Drawing.Point(5, 19);
            this.checkedListBox_PhoneBook.Name = "checkedListBox_PhoneBook";
            this.checkedListBox_PhoneBook.Size = new System.Drawing.Size(279, 340);
            this.checkedListBox_PhoneBook.TabIndex = 0;
            this.checkedListBox_PhoneBook.SelectedIndexChanged += new System.EventHandler(this.checkedListBox_PhoneBook_SelectedIndexChanged);
            this.checkedListBox_PhoneBook.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkedListBox_PhoneBook_KeyDown);
            this.checkedListBox_PhoneBook.MouseDown += new System.Windows.Forms.MouseEventHandler(this.checkedListBox_PhoneBook_MouseDown);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listBox_Charts);
            this.tabPage3.Controls.Add(this.button_OpenFolder2);
            this.tabPage3.Controls.Add(this.button_GraphPause);
            this.tabPage3.Controls.Add(this.Button_Export_excel);
            this.tabPage3.Controls.Add(this.button_ResetGraphs);
            this.tabPage3.Controls.Add(this.textBox_graph_XY);
            this.tabPage3.Controls.Add(this.button_ScreenShot);
            this.tabPage3.Controls.Add(this.chart1);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1900, 936);
            this.tabPage3.TabIndex = 7;
            this.tabPage3.Text = "Charts";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button_OpenFolder2
            // 
            this.button_OpenFolder2.Location = new System.Drawing.Point(5, 183);
            this.button_OpenFolder2.Name = "button_OpenFolder2";
            this.button_OpenFolder2.Size = new System.Drawing.Size(108, 26);
            this.button_OpenFolder2.TabIndex = 77;
            this.button_OpenFolder2.Text = "Open Folder";
            this.button_OpenFolder2.UseVisualStyleBackColor = true;
            this.button_OpenFolder2.Click += new System.EventHandler(this.button_OpenFolder2_Click);
            // 
            // button_GraphPause
            // 
            this.button_GraphPause.Location = new System.Drawing.Point(4, 78);
            this.button_GraphPause.Name = "button_GraphPause";
            this.button_GraphPause.Size = new System.Drawing.Size(123, 23);
            this.button_GraphPause.TabIndex = 8;
            this.button_GraphPause.Text = "Pause";
            this.button_GraphPause.UseVisualStyleBackColor = true;
            this.button_GraphPause.Click += new System.EventHandler(this.button_GraphPause_Click);
            // 
            // Button_Export_excel
            // 
            this.Button_Export_excel.Location = new System.Drawing.Point(4, 215);
            this.Button_Export_excel.Name = "Button_Export_excel";
            this.Button_Export_excel.Size = new System.Drawing.Size(123, 23);
            this.Button_Export_excel.TabIndex = 7;
            this.Button_Export_excel.Text = "Export to excel";
            this.Button_Export_excel.UseVisualStyleBackColor = true;
            this.Button_Export_excel.Click += new System.EventHandler(this.Button_Export_excel_Click);
            // 
            // button_ResetGraphs
            // 
            this.button_ResetGraphs.Location = new System.Drawing.Point(4, 46);
            this.button_ResetGraphs.Name = "button_ResetGraphs";
            this.button_ResetGraphs.Size = new System.Drawing.Size(123, 23);
            this.button_ResetGraphs.TabIndex = 6;
            this.button_ResetGraphs.Text = "Reset Graphs";
            this.button_ResetGraphs.UseVisualStyleBackColor = true;
            this.button_ResetGraphs.Click += new System.EventHandler(this.button_ResetGraphs_Click);
            // 
            // textBox_graph_XY
            // 
            this.textBox_graph_XY.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_graph_XY.Location = new System.Drawing.Point(4, 111);
            this.textBox_graph_XY.Multiline = true;
            this.textBox_graph_XY.Name = "textBox_graph_XY";
            this.textBox_graph_XY.Size = new System.Drawing.Size(185, 68);
            this.textBox_graph_XY.TabIndex = 4;
            // 
            // button_ScreenShot
            // 
            this.button_ScreenShot.Location = new System.Drawing.Point(4, 15);
            this.button_ScreenShot.Name = "button_ScreenShot";
            this.button_ScreenShot.Size = new System.Drawing.Size(123, 23);
            this.button_ScreenShot.TabIndex = 1;
            this.button_ScreenShot.Text = "Take screen shot";
            this.button_ScreenShot.UseVisualStyleBackColor = true;
            this.button_ScreenShot.Click += new System.EventHandler(this.button_ScreenShot_Click);
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(195, 0);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(1688, 917);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 27);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(1900, 936);
            this.tabPage8.TabIndex = 8;
            this.tabPage8.Text = "Errors";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.label10);
            this.tabPage9.Controls.Add(this.label9);
            this.tabPage9.Controls.Add(this.button_ClearRx);
            this.tabPage9.Controls.Add(this.richTextBox_ClientRx);
            this.tabPage9.Controls.Add(this.button43);
            this.tabPage9.Controls.Add(this.button_ClientClose);
            this.tabPage9.Controls.Add(this.button_ClientConnect);
            this.tabPage9.Controls.Add(this.button3);
            this.tabPage9.Controls.Add(this.richTextBox_ClientTx);
            this.tabPage9.Controls.Add(this.textBox_ClientPort);
            this.tabPage9.Controls.Add(this.textBox_ClientIP);
            this.tabPage9.Controls.Add(this.label8);
            this.tabPage9.Controls.Add(this.label7);
            this.tabPage9.Location = new System.Drawing.Point(4, 27);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(1900, 936);
            this.tabPage9.TabIndex = 9;
            this.tabPage9.Text = "Client";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(599, 303);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 23);
            this.label10.TabIndex = 13;
            this.label10.Text = "Rx - Data Received";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(599, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 23);
            this.label9.TabIndex = 12;
            this.label9.Text = "Tx - Data Send";
            // 
            // button_ClearRx
            // 
            this.button_ClearRx.Location = new System.Drawing.Point(1214, 334);
            this.button_ClearRx.Name = "button_ClearRx";
            this.button_ClearRx.Size = new System.Drawing.Size(75, 23);
            this.button_ClearRx.TabIndex = 11;
            this.button_ClearRx.Text = "Clear Rx";
            this.button_ClearRx.UseVisualStyleBackColor = true;
            this.button_ClearRx.Click += new System.EventHandler(this.button_ClearRx_Click);
            // 
            // richTextBox_ClientRx
            // 
            this.richTextBox_ClientRx.Location = new System.Drawing.Point(34, 334);
            this.richTextBox_ClientRx.Name = "richTextBox_ClientRx";
            this.richTextBox_ClientRx.ReadOnly = true;
            this.richTextBox_ClientRx.Size = new System.Drawing.Size(1174, 167);
            this.richTextBox_ClientRx.TabIndex = 9;
            this.richTextBox_ClientRx.Text = "";
            // 
            // button43
            // 
            this.button43.Location = new System.Drawing.Point(1215, 146);
            this.button43.Name = "button43";
            this.button43.Size = new System.Drawing.Size(75, 23);
            this.button43.TabIndex = 8;
            this.button43.Text = "Clear Tx";
            this.button43.UseVisualStyleBackColor = true;
            this.button43.Click += new System.EventHandler(this.button43_Click_1);
            // 
            // button_ClientClose
            // 
            this.button_ClientClose.Location = new System.Drawing.Point(149, 80);
            this.button_ClientClose.Name = "button_ClientClose";
            this.button_ClientClose.Size = new System.Drawing.Size(75, 23);
            this.button_ClientClose.TabIndex = 7;
            this.button_ClientClose.Text = "Close";
            this.button_ClientClose.UseVisualStyleBackColor = true;
            this.button_ClientClose.Click += new System.EventHandler(this.button42_Click_1);
            // 
            // button_ClientConnect
            // 
            this.button_ClientConnect.Location = new System.Drawing.Point(34, 80);
            this.button_ClientConnect.Name = "button_ClientConnect";
            this.button_ClientConnect.Size = new System.Drawing.Size(75, 23);
            this.button_ClientConnect.TabIndex = 6;
            this.button_ClientConnect.Text = "Connect";
            this.button_ClientConnect.UseVisualStyleBackColor = true;
            this.button_ClientConnect.Click += new System.EventHandler(this.button_ClientConnect_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1215, 117);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Send";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_4);
            // 
            // richTextBox_ClientTx
            // 
            this.richTextBox_ClientTx.Location = new System.Drawing.Point(34, 117);
            this.richTextBox_ClientTx.Name = "richTextBox_ClientTx";
            this.richTextBox_ClientTx.Size = new System.Drawing.Size(1174, 167);
            this.richTextBox_ClientTx.TabIndex = 4;
            this.richTextBox_ClientTx.Text = "Send Data to Server";
            // 
            // textBox_ClientPort
            // 
            this.textBox_ClientPort.Location = new System.Drawing.Point(124, 47);
            this.textBox_ClientPort.Name = "textBox_ClientPort";
            this.textBox_ClientPort.Size = new System.Drawing.Size(100, 26);
            this.textBox_ClientPort.TabIndex = 3;
            this.textBox_ClientPort.Text = "2002";
            // 
            // textBox_ClientIP
            // 
            this.textBox_ClientIP.Location = new System.Drawing.Point(124, 17);
            this.textBox_ClientIP.Name = "textBox_ClientIP";
            this.textBox_ClientIP.Size = new System.Drawing.Size(100, 26);
            this.textBox_ClientIP.TabIndex = 2;
            this.textBox_ClientIP.Text = "127.0.0.1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(30, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 23);
            this.label8.TabIndex = 1;
            this.label8.Text = "Port";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(30, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Host or IP";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.S1_Configuration);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1406, 776);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "S1 Configuration";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // S1_Configuration
            // 
            this.S1_Configuration.Controls.Add(this.groupBox12);
            this.S1_Configuration.Controls.Add(this.groupBox22);
            this.S1_Configuration.Controls.Add(this.groupBox28);
            this.S1_Configuration.Controls.Add(this.groupBox30);
            this.S1_Configuration.Controls.Add(this.groupBox29);
            this.S1_Configuration.Controls.Add(this.groupBox27);
            this.S1_Configuration.Controls.Add(this.groupBox26);
            this.S1_Configuration.Controls.Add(this.groupBox25);
            this.S1_Configuration.Controls.Add(this.groupBox24);
            this.S1_Configuration.Controls.Add(this.groupBox23);
            this.S1_Configuration.Controls.Add(this.groupBox21);
            this.S1_Configuration.Controls.Add(this.groupBox20);
            this.S1_Configuration.Controls.Add(this.groupBox19);
            this.S1_Configuration.Controls.Add(this.groupBox18);
            this.S1_Configuration.Controls.Add(this.groupBox17);
            this.S1_Configuration.Controls.Add(this.groupBox11);
            this.S1_Configuration.Controls.Add(this.groupBox10);
            this.S1_Configuration.Controls.Add(this.groupBox9);
            this.S1_Configuration.Controls.Add(this.groupBox8);
            this.S1_Configuration.Controls.Add(this.groupBox7);
            this.S1_Configuration.Controls.Add(this.groupBox6);
            this.S1_Configuration.Controls.Add(this.groupBox13);
            this.S1_Configuration.Controls.Add(this.groupBox14);
            this.S1_Configuration.Controls.Add(this.groupBox15);
            this.S1_Configuration.Controls.Add(this.groupBox16);
            this.S1_Configuration.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.S1_Configuration.Location = new System.Drawing.Point(3, 3);
            this.S1_Configuration.Name = "S1_Configuration";
            this.S1_Configuration.Size = new System.Drawing.Size(924, 741);
            this.S1_Configuration.TabIndex = 12;
            this.S1_Configuration.TabStop = false;
            this.S1_Configuration.Text = "S1 Configuration";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.button13);
            this.groupBox12.Location = new System.Drawing.Point(716, 24);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(164, 58);
            this.groupBox12.TabIndex = 67;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "RF pairing";
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(10, 20);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(152, 26);
            this.button13.TabIndex = 49;
            this.button13.Text = "RF Pairing";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.TextBox_Odometer);
            this.groupBox22.Controls.Add(this.button19);
            this.groupBox22.Location = new System.Drawing.Point(718, 88);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(200, 78);
            this.groupBox22.TabIndex = 68;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Odometer";
            // 
            // TextBox_Odometer
            // 
            this.TextBox_Odometer.Location = new System.Drawing.Point(6, 23);
            this.TextBox_Odometer.Name = "TextBox_Odometer";
            this.TextBox_Odometer.Size = new System.Drawing.Size(100, 22);
            this.TextBox_Odometer.TabIndex = 64;
            // 
            // button19
            // 
            this.button19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button19.Location = new System.Drawing.Point(6, 50);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(74, 26);
            this.button19.TabIndex = 63;
            this.button19.Text = "Odometer Config";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // groupBox28
            // 
            this.groupBox28.Controls.Add(this.textBox_ModemSocket);
            this.groupBox28.Controls.Add(this.textBox_ModemRetries);
            this.groupBox28.Controls.Add(this.textBox_ModemTimeOut);
            this.groupBox28.Controls.Add(this.button25);
            this.groupBox28.Controls.Add(this.textBox_ModemPrimeryPort);
            this.groupBox28.Controls.Add(this.textBox_ModemPrimeryHost);
            this.groupBox28.Location = new System.Drawing.Point(188, 499);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Size = new System.Drawing.Size(146, 195);
            this.groupBox28.TabIndex = 45;
            this.groupBox28.TabStop = false;
            this.groupBox28.Text = "Modem Config";
            // 
            // textBox_ModemSocket
            // 
            this.textBox_ModemSocket.Location = new System.Drawing.Point(8, 77);
            this.textBox_ModemSocket.Name = "textBox_ModemSocket";
            this.textBox_ModemSocket.Size = new System.Drawing.Size(132, 22);
            this.textBox_ModemSocket.TabIndex = 80;
            this.toolTip1.SetToolTip(this.textBox_ModemSocket, "Modem Socket");
            // 
            // textBox_ModemRetries
            // 
            this.textBox_ModemRetries.Location = new System.Drawing.Point(8, 50);
            this.textBox_ModemRetries.Name = "textBox_ModemRetries";
            this.textBox_ModemRetries.Size = new System.Drawing.Size(132, 22);
            this.textBox_ModemRetries.TabIndex = 79;
            this.toolTip1.SetToolTip(this.textBox_ModemRetries, "Modem retries");
            // 
            // textBox_ModemTimeOut
            // 
            this.textBox_ModemTimeOut.Location = new System.Drawing.Point(8, 23);
            this.textBox_ModemTimeOut.Name = "textBox_ModemTimeOut";
            this.textBox_ModemTimeOut.Size = new System.Drawing.Size(132, 22);
            this.textBox_ModemTimeOut.TabIndex = 78;
            this.toolTip1.SetToolTip(this.textBox_ModemTimeOut, "Modem Time Out");
            // 
            // button25
            // 
            this.button25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button25.Location = new System.Drawing.Point(8, 157);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(132, 26);
            this.button25.TabIndex = 44;
            this.button25.Text = "Config Modem";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.button25_Click);
            // 
            // textBox_ModemPrimeryPort
            // 
            this.textBox_ModemPrimeryPort.Location = new System.Drawing.Point(8, 129);
            this.textBox_ModemPrimeryPort.Name = "textBox_ModemPrimeryPort";
            this.textBox_ModemPrimeryPort.Size = new System.Drawing.Size(132, 22);
            this.textBox_ModemPrimeryPort.TabIndex = 37;
            this.toolTip1.SetToolTip(this.textBox_ModemPrimeryPort, "Primery Port");
            // 
            // textBox_ModemPrimeryHost
            // 
            this.textBox_ModemPrimeryHost.Location = new System.Drawing.Point(8, 101);
            this.textBox_ModemPrimeryHost.Name = "textBox_ModemPrimeryHost";
            this.textBox_ModemPrimeryHost.Size = new System.Drawing.Size(132, 22);
            this.textBox_ModemPrimeryHost.TabIndex = 36;
            this.toolTip1.SetToolTip(this.textBox_ModemPrimeryHost, "Primery Host");
            // 
            // groupBox30
            // 
            this.groupBox30.Controls.Add(this.textBox_ForginPassword);
            this.groupBox30.Controls.Add(this.button27);
            this.groupBox30.Controls.Add(this.textBox_ForginAcessPoint);
            this.groupBox30.Controls.Add(this.textBox_ForginSecondaryDNS);
            this.groupBox30.Controls.Add(this.textBox_ForginUserName);
            this.groupBox30.Controls.Add(this.textBox_ForginPrimeryDNS);
            this.groupBox30.Location = new System.Drawing.Point(344, 499);
            this.groupBox30.Name = "groupBox30";
            this.groupBox30.Size = new System.Drawing.Size(160, 195);
            this.groupBox30.TabIndex = 47;
            this.groupBox30.TabStop = false;
            this.groupBox30.Text = "Config Forgin Network";
            // 
            // textBox_ForginPassword
            // 
            this.textBox_ForginPassword.Location = new System.Drawing.Point(8, 77);
            this.textBox_ForginPassword.Name = "textBox_ForginPassword";
            this.textBox_ForginPassword.Size = new System.Drawing.Size(146, 22);
            this.textBox_ForginPassword.TabIndex = 35;
            this.toolTip1.SetToolTip(this.textBox_ForginPassword, "Password");
            // 
            // button27
            // 
            this.button27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button27.Location = new System.Drawing.Point(8, 157);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(146, 26);
            this.button27.TabIndex = 44;
            this.button27.Text = "Config Forgin Net";
            this.button27.UseVisualStyleBackColor = true;
            this.button27.Click += new System.EventHandler(this.button27_Click);
            // 
            // textBox_ForginAcessPoint
            // 
            this.textBox_ForginAcessPoint.Location = new System.Drawing.Point(7, 23);
            this.textBox_ForginAcessPoint.Name = "textBox_ForginAcessPoint";
            this.textBox_ForginAcessPoint.Size = new System.Drawing.Size(147, 22);
            this.textBox_ForginAcessPoint.TabIndex = 33;
            this.toolTip1.SetToolTip(this.textBox_ForginAcessPoint, "Aceess point");
            // 
            // textBox_ForginSecondaryDNS
            // 
            this.textBox_ForginSecondaryDNS.Location = new System.Drawing.Point(8, 129);
            this.textBox_ForginSecondaryDNS.Name = "textBox_ForginSecondaryDNS";
            this.textBox_ForginSecondaryDNS.Size = new System.Drawing.Size(146, 22);
            this.textBox_ForginSecondaryDNS.TabIndex = 37;
            this.toolTip1.SetToolTip(this.textBox_ForginSecondaryDNS, "Secondary DNS");
            // 
            // textBox_ForginUserName
            // 
            this.textBox_ForginUserName.Location = new System.Drawing.Point(8, 51);
            this.textBox_ForginUserName.Name = "textBox_ForginUserName";
            this.textBox_ForginUserName.Size = new System.Drawing.Size(146, 22);
            this.textBox_ForginUserName.TabIndex = 34;
            this.toolTip1.SetToolTip(this.textBox_ForginUserName, "User Name");
            // 
            // textBox_ForginPrimeryDNS
            // 
            this.textBox_ForginPrimeryDNS.Location = new System.Drawing.Point(8, 101);
            this.textBox_ForginPrimeryDNS.Name = "textBox_ForginPrimeryDNS";
            this.textBox_ForginPrimeryDNS.Size = new System.Drawing.Size(146, 22);
            this.textBox_ForginPrimeryDNS.TabIndex = 36;
            this.toolTip1.SetToolTip(this.textBox_ForginPrimeryDNS, "Primery DNS");
            // 
            // groupBox29
            // 
            this.groupBox29.Controls.Add(this.textBox_HomePassword);
            this.groupBox29.Controls.Add(this.button26);
            this.groupBox29.Controls.Add(this.textBox_HomeAcessPoint);
            this.groupBox29.Controls.Add(this.textBox_HomeSecondaryDNS);
            this.groupBox29.Controls.Add(this.textBox_HomeUserName);
            this.groupBox29.Controls.Add(this.textBox_HomePrimeryDNS);
            this.groupBox29.Location = new System.Drawing.Point(345, 298);
            this.groupBox29.Name = "groupBox29";
            this.groupBox29.Size = new System.Drawing.Size(160, 195);
            this.groupBox29.TabIndex = 46;
            this.groupBox29.TabStop = false;
            this.groupBox29.Text = "Config Home Net";
            // 
            // textBox_HomePassword
            // 
            this.textBox_HomePassword.Location = new System.Drawing.Point(8, 77);
            this.textBox_HomePassword.Name = "textBox_HomePassword";
            this.textBox_HomePassword.Size = new System.Drawing.Size(146, 22);
            this.textBox_HomePassword.TabIndex = 35;
            this.textBox_HomePassword.Text = "Password";
            // 
            // button26
            // 
            this.button26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button26.Location = new System.Drawing.Point(8, 157);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(146, 26);
            this.button26.TabIndex = 44;
            this.button26.Text = "Config Home Net";
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.button26_Click);
            // 
            // textBox_HomeAcessPoint
            // 
            this.textBox_HomeAcessPoint.Location = new System.Drawing.Point(7, 23);
            this.textBox_HomeAcessPoint.Name = "textBox_HomeAcessPoint";
            this.textBox_HomeAcessPoint.Size = new System.Drawing.Size(147, 22);
            this.textBox_HomeAcessPoint.TabIndex = 33;
            this.textBox_HomeAcessPoint.Text = "Aceess point";
            // 
            // textBox_HomeSecondaryDNS
            // 
            this.textBox_HomeSecondaryDNS.Location = new System.Drawing.Point(8, 129);
            this.textBox_HomeSecondaryDNS.Name = "textBox_HomeSecondaryDNS";
            this.textBox_HomeSecondaryDNS.Size = new System.Drawing.Size(146, 22);
            this.textBox_HomeSecondaryDNS.TabIndex = 37;
            this.textBox_HomeSecondaryDNS.Text = "Secondary DNS";
            // 
            // textBox_HomeUserName
            // 
            this.textBox_HomeUserName.Location = new System.Drawing.Point(8, 51);
            this.textBox_HomeUserName.Name = "textBox_HomeUserName";
            this.textBox_HomeUserName.Size = new System.Drawing.Size(146, 22);
            this.textBox_HomeUserName.TabIndex = 34;
            this.textBox_HomeUserName.Text = "User Name";
            // 
            // textBox_HomePrimeryDNS
            // 
            this.textBox_HomePrimeryDNS.Location = new System.Drawing.Point(8, 101);
            this.textBox_HomePrimeryDNS.Name = "textBox_HomePrimeryDNS";
            this.textBox_HomePrimeryDNS.Size = new System.Drawing.Size(146, 22);
            this.textBox_HomePrimeryDNS.TabIndex = 36;
            this.textBox_HomePrimeryDNS.Text = "Primery DNS";
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.maskedTextBox1);
            this.groupBox27.Controls.Add(this.button24);
            this.groupBox27.Location = new System.Drawing.Point(315, 107);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Size = new System.Drawing.Size(145, 78);
            this.groupBox27.TabIndex = 72;
            this.groupBox27.TabStop = false;
            this.groupBox27.Text = "Sleep Status Duration";
            this.toolTip1.SetToolTip(this.groupBox27, "Sleep Status Duration");
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(6, 18);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBox1.TabIndex = 71;
            // 
            // button24
            // 
            this.button24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button24.Location = new System.Drawing.Point(6, 45);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(131, 26);
            this.button24.TabIndex = 70;
            this.button24.Text = "Duration sleep";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.TextBox_NormalStatusDuration);
            this.groupBox26.Controls.Add(this.button23);
            this.groupBox26.Location = new System.Drawing.Point(334, 24);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(171, 77);
            this.groupBox26.TabIndex = 71;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "Normal Status Duration";
            // 
            // TextBox_NormalStatusDuration
            // 
            this.TextBox_NormalStatusDuration.Location = new System.Drawing.Point(6, 17);
            this.TextBox_NormalStatusDuration.Name = "TextBox_NormalStatusDuration";
            this.TextBox_NormalStatusDuration.Size = new System.Drawing.Size(100, 22);
            this.TextBox_NormalStatusDuration.TabIndex = 71;
            // 
            // button23
            // 
            this.button23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button23.Location = new System.Drawing.Point(6, 45);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(111, 26);
            this.button23.TabIndex = 70;
            this.button23.Text = "Set Duration";
            this.toolTip1.SetToolTip(this.button23, "Normal Status Duration");
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.maskedTextBox_SpeedLimit2);
            this.groupBox25.Controls.Add(this.maskedTextBox_SpeedLimit3);
            this.groupBox25.Controls.Add(this.maskedTextBox_SpeedLimit1);
            this.groupBox25.Controls.Add(this.button22);
            this.groupBox25.Location = new System.Drawing.Point(510, 557);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(200, 89);
            this.groupBox25.TabIndex = 70;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "Speed Limit Config";
            // 
            // maskedTextBox_SpeedLimit2
            // 
            this.maskedTextBox_SpeedLimit2.Location = new System.Drawing.Point(53, 20);
            this.maskedTextBox_SpeedLimit2.Name = "maskedTextBox_SpeedLimit2";
            this.maskedTextBox_SpeedLimit2.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_SpeedLimit2.TabIndex = 80;
            // 
            // maskedTextBox_SpeedLimit3
            // 
            this.maskedTextBox_SpeedLimit3.Location = new System.Drawing.Point(101, 19);
            this.maskedTextBox_SpeedLimit3.Name = "maskedTextBox_SpeedLimit3";
            this.maskedTextBox_SpeedLimit3.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_SpeedLimit3.TabIndex = 79;
            // 
            // maskedTextBox_SpeedLimit1
            // 
            this.maskedTextBox_SpeedLimit1.Location = new System.Drawing.Point(6, 20);
            this.maskedTextBox_SpeedLimit1.Name = "maskedTextBox_SpeedLimit1";
            this.maskedTextBox_SpeedLimit1.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_SpeedLimit1.TabIndex = 78;
            // 
            // button22
            // 
            this.button22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button22.Location = new System.Drawing.Point(6, 47);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(140, 26);
            this.button22.TabIndex = 65;
            this.button22.Text = "Speed Limit Alert";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.comboBox_DispatchSpeed);
            this.groupBox24.Controls.Add(this.button21);
            this.groupBox24.Location = new System.Drawing.Point(228, 377);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(106, 103);
            this.groupBox24.TabIndex = 68;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Dispatch Speed Limit";
            // 
            // comboBox_DispatchSpeed
            // 
            this.comboBox_DispatchSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_DispatchSpeed.FormattingEnabled = true;
            this.comboBox_DispatchSpeed.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_DispatchSpeed.Location = new System.Drawing.Point(8, 44);
            this.comboBox_DispatchSpeed.Name = "comboBox_DispatchSpeed";
            this.comboBox_DispatchSpeed.Size = new System.Drawing.Size(94, 21);
            this.comboBox_DispatchSpeed.TabIndex = 63;
            this.comboBox_DispatchSpeed.Text = "Speed";
            // 
            // button21
            // 
            this.button21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button21.Location = new System.Drawing.Point(8, 71);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(94, 26);
            this.button21.TabIndex = 64;
            this.button21.Text = "Dispatch Speed";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.comboBox_KillEngine);
            this.groupBox23.Controls.Add(this.button20);
            this.groupBox23.Location = new System.Drawing.Point(230, 287);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(109, 91);
            this.groupBox23.TabIndex = 67;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Kill Engine";
            // 
            // comboBox_KillEngine
            // 
            this.comboBox_KillEngine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_KillEngine.FormattingEnabled = true;
            this.comboBox_KillEngine.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_KillEngine.Location = new System.Drawing.Point(6, 20);
            this.comboBox_KillEngine.Name = "comboBox_KillEngine";
            this.comboBox_KillEngine.Size = new System.Drawing.Size(58, 21);
            this.comboBox_KillEngine.TabIndex = 63;
            this.comboBox_KillEngine.Text = "Engine";
            // 
            // button20
            // 
            this.button20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.Location = new System.Drawing.Point(6, 43);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(98, 26);
            this.button20.TabIndex = 64;
            this.button20.Text = "Kill Engine";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.maskedTextBox_TiltTowSens);
            this.groupBox21.Controls.Add(this.comboBox_TiltTowSensState);
            this.groupBox21.Controls.Add(this.button18);
            this.groupBox21.Location = new System.Drawing.Point(510, 451);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(200, 100);
            this.groupBox21.TabIndex = 65;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Tilt Tow Sensitivity";
            // 
            // maskedTextBox_TiltTowSens
            // 
            this.maskedTextBox_TiltTowSens.Location = new System.Drawing.Point(81, 32);
            this.maskedTextBox_TiltTowSens.Name = "maskedTextBox_TiltTowSens";
            this.maskedTextBox_TiltTowSens.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBox_TiltTowSens.TabIndex = 83;
            // 
            // comboBox_TiltTowSensState
            // 
            this.comboBox_TiltTowSensState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_TiltTowSensState.FormattingEnabled = true;
            this.comboBox_TiltTowSensState.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_TiltTowSensState.Location = new System.Drawing.Point(17, 32);
            this.comboBox_TiltTowSensState.Name = "comboBox_TiltTowSensState";
            this.comboBox_TiltTowSensState.Size = new System.Drawing.Size(58, 21);
            this.comboBox_TiltTowSensState.TabIndex = 82;
            this.comboBox_TiltTowSensState.Text = "State";
            // 
            // button18
            // 
            this.button18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.Location = new System.Drawing.Point(17, 59);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(140, 26);
            this.button18.TabIndex = 61;
            this.button18.Text = "Tilt/Tow Sensitivity";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.maskedTextBox_HitSensitivity);
            this.groupBox20.Controls.Add(this.comboBox_HitState);
            this.groupBox20.Controls.Add(this.button17);
            this.groupBox20.Location = new System.Drawing.Point(510, 345);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(200, 100);
            this.groupBox20.TabIndex = 64;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Hit Sensitivity";
            // 
            // maskedTextBox_HitSensitivity
            // 
            this.maskedTextBox_HitSensitivity.Location = new System.Drawing.Point(81, 32);
            this.maskedTextBox_HitSensitivity.Name = "maskedTextBox_HitSensitivity";
            this.maskedTextBox_HitSensitivity.Size = new System.Drawing.Size(100, 22);
            this.maskedTextBox_HitSensitivity.TabIndex = 82;
            // 
            // comboBox_HitState
            // 
            this.comboBox_HitState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_HitState.FormattingEnabled = true;
            this.comboBox_HitState.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_HitState.Location = new System.Drawing.Point(17, 32);
            this.comboBox_HitState.Name = "comboBox_HitState";
            this.comboBox_HitState.Size = new System.Drawing.Size(58, 21);
            this.comboBox_HitState.TabIndex = 62;
            this.comboBox_HitState.Text = "State";
            // 
            // button17
            // 
            this.button17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button17.Location = new System.Drawing.Point(17, 59);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(140, 26);
            this.button17.TabIndex = 61;
            this.button17.Text = "Hit Sensitivity";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.maskedTextBox_ShockDetectNum);
            this.groupBox19.Controls.Add(this.maskedTextBox_ShockWindow);
            this.groupBox19.Controls.Add(this.comboBox_ShockState);
            this.groupBox19.Controls.Add(this.button16);
            this.groupBox19.Location = new System.Drawing.Point(718, 276);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(200, 100);
            this.groupBox19.TabIndex = 63;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Config Shock";
            // 
            // maskedTextBox_ShockDetectNum
            // 
            this.maskedTextBox_ShockDetectNum.Location = new System.Drawing.Point(111, 24);
            this.maskedTextBox_ShockDetectNum.Name = "maskedTextBox_ShockDetectNum";
            this.maskedTextBox_ShockDetectNum.Size = new System.Drawing.Size(46, 22);
            this.maskedTextBox_ShockDetectNum.TabIndex = 82;
            // 
            // maskedTextBox_ShockWindow
            // 
            this.maskedTextBox_ShockWindow.Location = new System.Drawing.Point(59, 24);
            this.maskedTextBox_ShockWindow.Name = "maskedTextBox_ShockWindow";
            this.maskedTextBox_ShockWindow.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_ShockWindow.TabIndex = 81;
            // 
            // comboBox_ShockState
            // 
            this.comboBox_ShockState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_ShockState.FormattingEnabled = true;
            this.comboBox_ShockState.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_ShockState.Location = new System.Drawing.Point(1, 24);
            this.comboBox_ShockState.Name = "comboBox_ShockState";
            this.comboBox_ShockState.Size = new System.Drawing.Size(48, 21);
            this.comboBox_ShockState.TabIndex = 61;
            this.comboBox_ShockState.Text = "State";
            // 
            // button16
            // 
            this.button16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.Location = new System.Drawing.Point(6, 54);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(140, 26);
            this.button16.TabIndex = 42;
            this.button16.Text = "Config Shock";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.maskedTextBox_TiltDetectNum);
            this.groupBox18.Controls.Add(this.maskedTextBox_TiltWindow);
            this.groupBox18.Controls.Add(this.maskedTextBox_TiltAngle);
            this.groupBox18.Controls.Add(this.comboBox1_TiltState);
            this.groupBox18.Controls.Add(this.button15);
            this.groupBox18.Location = new System.Drawing.Point(718, 170);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(200, 100);
            this.groupBox18.TabIndex = 62;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Config Tow";
            // 
            // maskedTextBox_TiltDetectNum
            // 
            this.maskedTextBox_TiltDetectNum.Location = new System.Drawing.Point(100, 29);
            this.maskedTextBox_TiltDetectNum.Name = "maskedTextBox_TiltDetectNum";
            this.maskedTextBox_TiltDetectNum.Size = new System.Drawing.Size(42, 22);
            this.maskedTextBox_TiltDetectNum.TabIndex = 83;
            // 
            // maskedTextBox_TiltWindow
            // 
            this.maskedTextBox_TiltWindow.Location = new System.Drawing.Point(53, 29);
            this.maskedTextBox_TiltWindow.Name = "maskedTextBox_TiltWindow";
            this.maskedTextBox_TiltWindow.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_TiltWindow.TabIndex = 82;
            // 
            // maskedTextBox_TiltAngle
            // 
            this.maskedTextBox_TiltAngle.Location = new System.Drawing.Point(10, 29);
            this.maskedTextBox_TiltAngle.Name = "maskedTextBox_TiltAngle";
            this.maskedTextBox_TiltAngle.Size = new System.Drawing.Size(37, 22);
            this.maskedTextBox_TiltAngle.TabIndex = 81;
            // 
            // comboBox1_TiltState
            // 
            this.comboBox1_TiltState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1_TiltState.FormattingEnabled = true;
            this.comboBox1_TiltState.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox1_TiltState.Location = new System.Drawing.Point(152, 29);
            this.comboBox1_TiltState.Name = "comboBox1_TiltState";
            this.comboBox1_TiltState.Size = new System.Drawing.Size(42, 21);
            this.comboBox1_TiltState.TabIndex = 38;
            this.comboBox1_TiltState.Text = "State";
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.Location = new System.Drawing.Point(6, 56);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(140, 26);
            this.button15.TabIndex = 42;
            this.button15.Text = "Config Tilt";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.maskedTextBox_TowDetectNum);
            this.groupBox17.Controls.Add(this.maskedTextBox_TowWindow);
            this.groupBox17.Controls.Add(this.maskedTextBox_TowAngle);
            this.groupBox17.Controls.Add(this.button14);
            this.groupBox17.Location = new System.Drawing.Point(516, 17);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(157, 100);
            this.groupBox17.TabIndex = 61;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Tow Configuration";
            // 
            // maskedTextBox_TowDetectNum
            // 
            this.maskedTextBox_TowDetectNum.Location = new System.Drawing.Point(100, 24);
            this.maskedTextBox_TowDetectNum.Name = "maskedTextBox_TowDetectNum";
            this.maskedTextBox_TowDetectNum.Size = new System.Drawing.Size(42, 22);
            this.maskedTextBox_TowDetectNum.TabIndex = 80;
            // 
            // maskedTextBox_TowWindow
            // 
            this.maskedTextBox_TowWindow.Location = new System.Drawing.Point(53, 24);
            this.maskedTextBox_TowWindow.Name = "maskedTextBox_TowWindow";
            this.maskedTextBox_TowWindow.Size = new System.Drawing.Size(41, 22);
            this.maskedTextBox_TowWindow.TabIndex = 79;
            // 
            // maskedTextBox_TowAngle
            // 
            this.maskedTextBox_TowAngle.Location = new System.Drawing.Point(10, 24);
            this.maskedTextBox_TowAngle.Name = "maskedTextBox_TowAngle";
            this.maskedTextBox_TowAngle.Size = new System.Drawing.Size(37, 22);
            this.maskedTextBox_TowAngle.TabIndex = 78;
            // 
            // button14
            // 
            this.button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.Location = new System.Drawing.Point(6, 54);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(140, 26);
            this.button14.TabIndex = 42;
            this.button14.Text = "Config Tow";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.comboBox_SleepPolicy);
            this.groupBox11.Controls.Add(this.button12);
            this.groupBox11.Location = new System.Drawing.Point(15, 598);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(167, 84);
            this.groupBox11.TabIndex = 57;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Sleep Policy";
            // 
            // comboBox_SleepPolicy
            // 
            this.comboBox_SleepPolicy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_SleepPolicy.FormattingEnabled = true;
            this.comboBox_SleepPolicy.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.comboBox_SleepPolicy.Location = new System.Drawing.Point(6, 27);
            this.comboBox_SleepPolicy.Name = "comboBox_SleepPolicy";
            this.comboBox_SleepPolicy.Size = new System.Drawing.Size(80, 21);
            this.comboBox_SleepPolicy.TabIndex = 47;
            this.comboBox_SleepPolicy.Text = "Sleep Policy";
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(6, 51);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(152, 26);
            this.button12.TabIndex = 48;
            this.button12.Text = "Set Sleep Policy";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.comboBox_AlarmPilicy);
            this.groupBox10.Controls.Add(this.button11);
            this.groupBox10.Location = new System.Drawing.Point(15, 492);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(166, 100);
            this.groupBox10.TabIndex = 56;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Set Alarm Configuration";
            // 
            // comboBox_AlarmPilicy
            // 
            this.comboBox_AlarmPilicy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_AlarmPilicy.FormattingEnabled = true;
            this.comboBox_AlarmPilicy.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.comboBox_AlarmPilicy.Location = new System.Drawing.Point(8, 28);
            this.comboBox_AlarmPilicy.Name = "comboBox_AlarmPilicy";
            this.comboBox_AlarmPilicy.Size = new System.Drawing.Size(80, 21);
            this.comboBox_AlarmPilicy.TabIndex = 42;
            this.comboBox_AlarmPilicy.Text = "Alarm Policy";
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(8, 52);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(152, 26);
            this.button11.TabIndex = 43;
            this.button11.Text = "Set Alarm Policy";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.dateTimePicker_SetTimeDate);
            this.groupBox9.Controls.Add(this.button10);
            this.groupBox9.Location = new System.Drawing.Point(353, 193);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(204, 81);
            this.groupBox9.TabIndex = 55;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Set Time and Date";
            // 
            // dateTimePicker_SetTimeDate
            // 
            this.dateTimePicker_SetTimeDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dateTimePicker_SetTimeDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_SetTimeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_SetTimeDate.Location = new System.Drawing.Point(6, 20);
            this.dateTimePicker_SetTimeDate.Name = "dateTimePicker_SetTimeDate";
            this.dateTimePicker_SetTimeDate.Size = new System.Drawing.Size(179, 21);
            this.dateTimePicker_SetTimeDate.TabIndex = 41;
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(6, 47);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(87, 26);
            this.button10.TabIndex = 40;
            this.button10.Text = "Time Date Config";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.comboBox_BatThreshold);
            this.groupBox8.Controls.Add(this.button9);
            this.groupBox8.Location = new System.Drawing.Point(187, 183);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(160, 91);
            this.groupBox8.TabIndex = 54;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Vehicle Battery threshold ";
            this.toolTip1.SetToolTip(this.groupBox8, "Set Vehicle Battery threshold ");
            // 
            // comboBox_BatThreshold
            // 
            this.comboBox_BatThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_BatThreshold.FormattingEnabled = true;
            this.comboBox_BatThreshold.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBox_BatThreshold.Location = new System.Drawing.Point(6, 20);
            this.comboBox_BatThreshold.Name = "comboBox_BatThreshold";
            this.comboBox_BatThreshold.Size = new System.Drawing.Size(49, 21);
            this.comboBox_BatThreshold.TabIndex = 39;
            this.toolTip1.SetToolTip(this.comboBox_BatThreshold, "Battery");
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(6, 47);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(135, 26);
            this.button9.TabIndex = 38;
            this.button9.Text = "Vehicle Battery";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.maskedTextBox_OutputDuration);
            this.groupBox7.Controls.Add(this.comboBox_OutputNum);
            this.groupBox7.Controls.Add(this.comboBox_OutputControl);
            this.groupBox7.Controls.Add(this.button8);
            this.groupBox7.Controls.Add(this.comboBox_OutputPulseLevel);
            this.groupBox7.Location = new System.Drawing.Point(9, 386);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(215, 94);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Set Input Config";
            // 
            // maskedTextBox_OutputDuration
            // 
            this.maskedTextBox_OutputDuration.Location = new System.Drawing.Point(164, 48);
            this.maskedTextBox_OutputDuration.Name = "maskedTextBox_OutputDuration";
            this.maskedTextBox_OutputDuration.Size = new System.Drawing.Size(39, 22);
            this.maskedTextBox_OutputDuration.TabIndex = 38;
            // 
            // comboBox_OutputNum
            // 
            this.comboBox_OutputNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_OutputNum.FormattingEnabled = true;
            this.comboBox_OutputNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_OutputNum.Location = new System.Drawing.Point(6, 20);
            this.comboBox_OutputNum.Name = "comboBox_OutputNum";
            this.comboBox_OutputNum.Size = new System.Drawing.Size(71, 21);
            this.comboBox_OutputNum.TabIndex = 33;
            this.comboBox_OutputNum.Text = "Output Num";
            // 
            // comboBox_OutputControl
            // 
            this.comboBox_OutputControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_OutputControl.FormattingEnabled = true;
            this.comboBox_OutputControl.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_OutputControl.Location = new System.Drawing.Point(83, 20);
            this.comboBox_OutputControl.Name = "comboBox_OutputControl";
            this.comboBox_OutputControl.Size = new System.Drawing.Size(71, 21);
            this.comboBox_OutputControl.TabIndex = 34;
            this.comboBox_OutputControl.Text = "Cntl";
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(5, 47);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(152, 26);
            this.button8.TabIndex = 36;
            this.button8.Text = "Set Output Config";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // comboBox_OutputPulseLevel
            // 
            this.comboBox_OutputPulseLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_OutputPulseLevel.FormattingEnabled = true;
            this.comboBox_OutputPulseLevel.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_OutputPulseLevel.Location = new System.Drawing.Point(160, 20);
            this.comboBox_OutputPulseLevel.Name = "comboBox_OutputPulseLevel";
            this.comboBox_OutputPulseLevel.Size = new System.Drawing.Size(43, 21);
            this.comboBox_OutputPulseLevel.TabIndex = 37;
            this.comboBox_OutputPulseLevel.Text = "Pulse\\Level";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.maskedTextBox_InputDuration);
            this.groupBox6.Controls.Add(this.comboBox_InputNum1);
            this.groupBox6.Controls.Add(this.comboBox_Interupt);
            this.groupBox6.Controls.Add(this.button7);
            this.groupBox6.Location = new System.Drawing.Point(9, 280);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(215, 100);
            this.groupBox6.TabIndex = 53;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Input Configuration";
            // 
            // maskedTextBox_InputDuration
            // 
            this.maskedTextBox_InputDuration.Location = new System.Drawing.Point(157, 31);
            this.maskedTextBox_InputDuration.Name = "maskedTextBox_InputDuration";
            this.maskedTextBox_InputDuration.Size = new System.Drawing.Size(46, 22);
            this.maskedTextBox_InputDuration.TabIndex = 33;
            // 
            // comboBox_InputNum1
            // 
            this.comboBox_InputNum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_InputNum1.FormattingEnabled = true;
            this.comboBox_InputNum1.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_InputNum1.Location = new System.Drawing.Point(6, 31);
            this.comboBox_InputNum1.Name = "comboBox_InputNum1";
            this.comboBox_InputNum1.Size = new System.Drawing.Size(71, 21);
            this.comboBox_InputNum1.TabIndex = 29;
            this.comboBox_InputNum1.Text = "Input Num";
            // 
            // comboBox_Interupt
            // 
            this.comboBox_Interupt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Interupt.FormattingEnabled = true;
            this.comboBox_Interupt.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_Interupt.Location = new System.Drawing.Point(83, 31);
            this.comboBox_Interupt.Name = "comboBox_Interupt";
            this.comboBox_Interupt.Size = new System.Drawing.Size(71, 21);
            this.comboBox_Interupt.TabIndex = 30;
            this.comboBox_Interupt.Text = "Interrupt";
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(5, 58);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(152, 26);
            this.button7.TabIndex = 32;
            this.button7.Text = "Set Input Config";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.btn_ChangePassword);
            this.groupBox13.Controls.Add(this.textBox_NewPassword);
            this.groupBox13.Location = new System.Drawing.Point(9, 174);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(172, 100);
            this.groupBox13.TabIndex = 52;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Change Password";
            // 
            // btn_ChangePassword
            // 
            this.btn_ChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ChangePassword.Location = new System.Drawing.Point(8, 48);
            this.btn_ChangePassword.Name = "btn_ChangePassword";
            this.btn_ChangePassword.Size = new System.Drawing.Size(152, 26);
            this.btn_ChangePassword.TabIndex = 28;
            this.btn_ChangePassword.Text = "Change Password";
            this.btn_ChangePassword.UseVisualStyleBackColor = true;
            // 
            // textBox_NewPassword
            // 
            this.textBox_NewPassword.Location = new System.Drawing.Point(6, 19);
            this.textBox_NewPassword.Name = "textBox_NewPassword";
            this.textBox_NewPassword.Size = new System.Drawing.Size(120, 22);
            this.textBox_NewPassword.TabIndex = 27;
            this.toolTip1.SetToolTip(this.textBox_NewPassword, "New Password");
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.comboBox_SMSControl);
            this.groupBox14.Controls.Add(this.button_SMSControl);
            this.groupBox14.Location = new System.Drawing.Point(187, 105);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(122, 80);
            this.groupBox14.TabIndex = 51;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "SMS Control";
            // 
            // comboBox_SMSControl
            // 
            this.comboBox_SMSControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_SMSControl.FormattingEnabled = true;
            this.comboBox_SMSControl.Items.AddRange(new object[] {
            "0",
            "1"});
            this.comboBox_SMSControl.Location = new System.Drawing.Point(6, 20);
            this.comboBox_SMSControl.Name = "comboBox_SMSControl";
            this.comboBox_SMSControl.Size = new System.Drawing.Size(101, 21);
            this.comboBox_SMSControl.TabIndex = 25;
            this.toolTip1.SetToolTip(this.comboBox_SMSControl, "SMS Cntl");
            // 
            // button_SMSControl
            // 
            this.button_SMSControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SMSControl.Location = new System.Drawing.Point(6, 47);
            this.button_SMSControl.Name = "button_SMSControl";
            this.button_SMSControl.Size = new System.Drawing.Size(113, 26);
            this.button_SMSControl.TabIndex = 26;
            this.button_SMSControl.Text = "SMS Control";
            this.button_SMSControl.UseVisualStyleBackColor = true;
            this.button_SMSControl.Click += new System.EventHandler(this.button_SMSControl_Click);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.textBox_FreeText);
            this.groupBox15.Controls.Add(this.comboBox_InputIndex);
            this.groupBox15.Controls.Add(this.button_SetFreeText);
            this.groupBox15.Location = new System.Drawing.Point(187, 24);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(141, 75);
            this.groupBox15.TabIndex = 50;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Set Input Free Text";
            // 
            // textBox_FreeText
            // 
            this.textBox_FreeText.Location = new System.Drawing.Point(52, 16);
            this.textBox_FreeText.Name = "textBox_FreeText";
            this.textBox_FreeText.Size = new System.Drawing.Size(67, 22);
            this.textBox_FreeText.TabIndex = 25;
            // 
            // comboBox_InputIndex
            // 
            this.comboBox_InputIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_InputIndex.FormattingEnabled = true;
            this.comboBox_InputIndex.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBox_InputIndex.Location = new System.Drawing.Point(8, 17);
            this.comboBox_InputIndex.Name = "comboBox_InputIndex";
            this.comboBox_InputIndex.Size = new System.Drawing.Size(37, 21);
            this.comboBox_InputIndex.TabIndex = 20;
            this.toolTip1.SetToolTip(this.comboBox_InputIndex, "Input index");
            // 
            // button_SetFreeText
            // 
            this.button_SetFreeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_SetFreeText.Location = new System.Drawing.Point(8, 40);
            this.button_SetFreeText.Name = "button_SetFreeText";
            this.button_SetFreeText.Size = new System.Drawing.Size(111, 26);
            this.button_SetFreeText.TabIndex = 24;
            this.button_SetFreeText.Text = "Set Free Text";
            this.button_SetFreeText.UseVisualStyleBackColor = true;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.maskedTextBox3_Subscriber3);
            this.groupBox16.Controls.Add(this.maskedTextBox2_Subscriber2);
            this.groupBox16.Controls.Add(this.maskedTextBox1_Subscriber1);
            this.groupBox16.Controls.Add(this.button4);
            this.groupBox16.Location = new System.Drawing.Point(9, 20);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(172, 149);
            this.groupBox16.TabIndex = 20;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Subscribers";
            // 
            // maskedTextBox3_Subscriber3
            // 
            this.maskedTextBox3_Subscriber3.Location = new System.Drawing.Point(8, 76);
            this.maskedTextBox3_Subscriber3.Name = "maskedTextBox3_Subscriber3";
            this.maskedTextBox3_Subscriber3.Size = new System.Drawing.Size(153, 22);
            this.maskedTextBox3_Subscriber3.TabIndex = 28;
            // 
            // maskedTextBox2_Subscriber2
            // 
            this.maskedTextBox2_Subscriber2.Location = new System.Drawing.Point(8, 49);
            this.maskedTextBox2_Subscriber2.Name = "maskedTextBox2_Subscriber2";
            this.maskedTextBox2_Subscriber2.Size = new System.Drawing.Size(153, 22);
            this.maskedTextBox2_Subscriber2.TabIndex = 27;
            // 
            // maskedTextBox1_Subscriber1
            // 
            this.maskedTextBox1_Subscriber1.Location = new System.Drawing.Point(8, 24);
            this.maskedTextBox1_Subscriber1.Name = "maskedTextBox1_Subscriber1";
            this.maskedTextBox1_Subscriber1.Size = new System.Drawing.Size(153, 22);
            this.maskedTextBox1_Subscriber1.TabIndex = 26;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(6, 107);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(154, 26);
            this.button4.TabIndex = 20;
            this.button4.Text = "Set Subscribers";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1406, 776);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "S1 Requests and Qureies";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // textBox_SMSPhoneNumber
            // 
            this.textBox_SMSPhoneNumber.Location = new System.Drawing.Point(6, 22);
            this.textBox_SMSPhoneNumber.Name = "textBox_SMSPhoneNumber";
            this.textBox_SMSPhoneNumber.Size = new System.Drawing.Size(156, 26);
            this.textBox_SMSPhoneNumber.TabIndex = 10;
            this.toolTip2.SetToolTip(this.textBox_SMSPhoneNumber, "Phone number throgh SMS");
            this.toolTip1.SetToolTip(this.textBox_SMSPhoneNumber, "Phone number throgh SMS");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer_General_100ms
            // 
            this.timer_General_100ms.Enabled = true;
            this.timer_General_100ms.Tick += new System.EventHandler(this.timer_ConectionKeepAlive_Tick);
            // 
            // timer_General_1Second
            // 
            this.timer_General_1Second.Enabled = true;
            this.timer_General_1Second.Interval = 1000;
            this.timer_General_1Second.Tick += new System.EventHandler(this.timer_General_Tick);
            // 
            // groupBox36
            // 
            this.groupBox36.Location = new System.Drawing.Point(0, -60);
            this.groupBox36.Name = "groupBox36";
            this.groupBox36.Size = new System.Drawing.Size(138, 57);
            this.groupBox36.TabIndex = 11;
            this.groupBox36.TabStop = false;
            this.groupBox36.Text = "Comm Interface";
            // 
            // groupBox_PhoneNumber
            // 
            this.groupBox_PhoneNumber.Controls.Add(this.textBox_SMSPhoneNumber);
            this.groupBox_PhoneNumber.Location = new System.Drawing.Point(973, 5);
            this.groupBox_PhoneNumber.Name = "groupBox_PhoneNumber";
            this.groupBox_PhoneNumber.Size = new System.Drawing.Size(172, 55);
            this.groupBox_PhoneNumber.TabIndex = 12;
            this.groupBox_PhoneNumber.TabStop = false;
            this.groupBox_PhoneNumber.Text = "Phone Number";
            this.groupBox_PhoneNumber.Visible = false;
            // 
            // listBox_Charts
            // 
            this.listBox_Charts.FormattingEnabled = true;
            this.listBox_Charts.ItemHeight = 18;
            this.listBox_Charts.Location = new System.Drawing.Point(5, 245);
            this.listBox_Charts.Name = "listBox_Charts";
            this.listBox_Charts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_Charts.Size = new System.Drawing.Size(184, 184);
            this.listBox_Charts.TabIndex = 78;
            this.listBox_Charts.SelectedIndexChanged += new System.EventHandler(this.listBox_Charts_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 19);
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1924, 984);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox36);
            this.Controls.Add(this.groupBox_PhoneNumber);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Monitor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_ServerSettings.ResumeLayout(false);
            this.groupBox_ServerSettings.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox_Timer.ResumeLayout(false);
            this.groupBox_Timer.PerformLayout();
            this.groupBox_Stopwatch.ResumeLayout(false);
            this.groupBox_Stopwatch.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbPortSettings.ResumeLayout(false);
            this.gbPortSettings.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.groupBox38.ResumeLayout(false);
            this.groupBox_LoadedConfig.ResumeLayout(false);
            this.groupBox_LoadedConfig.PerformLayout();
            this.groupBox_Configuration.ResumeLayout(false);
            this.groupBox_Configuration.PerformLayout();
            this.groupBox31.ResumeLayout(false);
            this.groupBox31.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox_FOTA.ResumeLayout(false);
            this.groupBox_FOTA.PerformLayout();
            this.groupBox_ConnectionTimedOut.ResumeLayout(false);
            this.groupBox_ConnectionTimedOut.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.groupBox39.ResumeLayout(false);
            this.groupBox37.ResumeLayout(false);
            this.groupBox37.PerformLayout();
            this.groupBox35.ResumeLayout(false);
            this.groupBox35.PerformLayout();
            this.groupBox34.ResumeLayout(false);
            this.groupBox34.PerformLayout();
            this.GrooupBox_Encryption.ResumeLayout(false);
            this.GrooupBox_Encryption.PerformLayout();
            this.groupBox33.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage9.ResumeLayout(false);
            this.tabPage9.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.S1_Configuration.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox28.ResumeLayout(false);
            this.groupBox28.PerformLayout();
            this.groupBox30.ResumeLayout(false);
            this.groupBox30.PerformLayout();
            this.groupBox29.ResumeLayout(false);
            this.groupBox29.PerformLayout();
            this.groupBox27.ResumeLayout(false);
            this.groupBox27.PerformLayout();
            this.groupBox26.ResumeLayout(false);
            this.groupBox26.PerformLayout();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.groupBox24.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox_PhoneNumber.ResumeLayout(false);
            this.groupBox_PhoneNumber.PerformLayout();
            this.ResumeLayout(false);

        }

        int HistoryIndex = -1;
        private void TextBox_SendSerialPort_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {

                    case Keys.Enter:
                                button_SendSerialPort.PerformClick();
                        break;

                    case Keys.Up:
                                //SerialPortLogger.LogMessage(Color.Purple, Color.LightGray, " History Index: " + HistoryIndex.ToString(), New_Line = true, Show_Time = false);
                                if (HistoryIndex >= comboBox_SerialPortHistory.Items.Count - 1 || HistoryIndex < 0)
                                {
                                    HistoryIndex = comboBox_SerialPortHistory.Items.Count - 1;
                                }

                                textBox_SendSerialPort.Text = comboBox_SerialPortHistory.Items[HistoryIndex].ToString();
                                if (HistoryIndex > 0)
                                {
                                    HistoryIndex--;
                                }
                        break;

                    case Keys.Down:

                                    textBox_SendSerialPort.Text = comboBox_SerialPortHistory.Items[HistoryIndex].ToString();
                                    if (HistoryIndex < comboBox_SerialPortHistory.Items.Count - 1)
                                    {
                                        HistoryIndex++;
                                    }
                        break;

                    case Keys.Right:
                    case Keys.Tab:
                                    List<String> Strlist = new List<String>();
                                    foreach (String str in comboBox_SerialPortHistory.Items)
                                    {
                                        if (str.StartsWith(textBox_SendSerialPort.Text))
                                        {
                                            Strlist.Add(str);
                                        }
                                    }

                                    if (Strlist.Count > 1)
                                    {
                                        SerialPortLogger.LogMessage(Color.Black, Color.Yellow, "Total sub commands: " + Strlist.Count.ToString() + " ", New_Line = true, Show_Time = true);
                                        foreach (String str in Strlist)
                                        {
                                            SerialPortLogger.LogMessage(Color.Black, Color.Yellow, str, New_Line = true, Show_Time = false);
                                        }
                                    }
                                    else
                                        if (Strlist.Count == 1)
                                        {
                                            textBox_SendSerialPort.Text = Strlist[0];
                                        }
                        break;

                    default:
                        HistoryIndex = comboBox_SerialPortHistory.Items.Count - 1;
                    break;
                }

                comboBox_SerialPortHistory.SelectedIndex = HistoryIndex;
            }
            catch (Exception ex)
            {
                ServerLogger.LogMessage(Color.Blue, Color.White, ex.ToString(), New_Line = true, Show_Time = false);
            }
        }

        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //Change appearance of tabcontrol
            Brush backBrush;
            Brush foreBrush;

            backBrush = new SolidBrush(Color.Red);
            foreBrush = new SolidBrush(Color.Blue);

            e.Graphics.FillRectangle(backBrush, e.Bounds);

            //You may need to write the label here also?
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            Rectangle r = e.Bounds;
            r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
            e.Graphics.DrawString("my label", e.Font, foreBrush, r, sf);
        }

        private void ListBox_SMSCommands_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            bool isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
            int itemIndex = e.Index;
            if (itemIndex >= 0 && itemIndex < listBox_SMSCommands.Items.Count)
            {
                Graphics g = e.Graphics;

                // Background Color
                SolidBrush backgroundColorBrush = new SolidBrush((isItemSelected) ? Color.Red : Color.White);
                g.FillRectangle(backgroundColorBrush, e.Bounds);

                // Set text color
                string itemText = listBox_SMSCommands.Items[itemIndex].ToString();

                SolidBrush itemTextColorBrush = (isItemSelected) ? new SolidBrush(Color.White) : new SolidBrush(Color.Black);
                g.DrawString(itemText, e.Font, itemTextColorBrush, listBox_SMSCommands.GetItemRectangle(itemIndex).Location);

                // Clean up
                backgroundColorBrush.Dispose();
                itemTextColorBrush.Dispose();
            }

            e.DrawFocusRectangle();
        }

        void listBox_SMSCommands_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedCommand();
            }
        }

        void checkedListBox_PhoneBook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedContact();
            }
        }

        static Boolean PhoneBookIsChecked = false;
        void checkedListBox_PhoneBook_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PhoneBookIsChecked = !PhoneBookIsChecked;

                if (PhoneBookIsChecked == true)
                {
                    for (int x = 0; x < checkedListBox_PhoneBook.Items.Count; x++)
                    {
                        checkedListBox_PhoneBook.SetItemChecked(x, true);
                    }
                }
                else
                {
                    for (int x = 0; x < checkedListBox_PhoneBook.Items.Count; x++)
                    {
                        checkedListBox_PhoneBook.SetItemChecked(x, false);
                    }
                }

            }
        }

        void textBox_GeneralMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Then Enter key was pressed

                //button29.PerformClick();
            }
        }

        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.Run(new MainForm());


        }

        enum eComSource
        {
            SerialPort = 0,
            GPRS,
            SMS
        }
        private void GuiHandleData(eComSource i_ComSource, byte[] i_Data)
        {

            try
            {
                GetDataIntervalCounter = 0;

                //message has successfully been received
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] data = null;
                //SSP_Protocol.SSP_DataPayload data = SSP_Protocol.SSP_Protocol.SSPPacket_Decoder(i_Data);
                if (data != null)
                {

                    //ServerLogger.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                    //ServerLogger.LogMessage(Color.Blue, Color.White, "["+ i_ComSource.ToString() + "]" + "  SSP Message Received ", New_Line = false, Show_Time = false);
                    //ServerLogger.LogMessage(Color.Black, Color.White, " Type: ", New_Line = false, Show_Time = false);
                    //ServerLogger.LogMessage(Color.DarkGray, Color.White, data.MessageType.ToString(), New_Line = false, Show_Time = false);
                    //ServerLogger.LogMessage(Color.Black, Color.White, " Length: ", New_Line = false, Show_Time = false);
                    //ServerLogger.LogMessage(Color.DarkGray, Color.White, data.MessageLength.ToString(), New_Line = false, Show_Time = false);
                    //ServerLogger.LogMessage(Color.Black, Color.White, " Payload: ", New_Line = false, Show_Time = false);
                    //ServerLogger.LogMessage(Color.DarkGray, Color.White, ByteArrayToHexString(data.Data_Payload), New_Line = true, Show_Time = false);

                    ServerLogger.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                    ServerLogger.LogMessage(Color.Blue, Color.White, "[" + i_ComSource.ToString() + "]" + "  SSP Message Received ", New_Line = false, Show_Time = false);
                    ServerLogger.LogMessage(Color.Black, Color.White, " Data: ", New_Line = false, Show_Time = false);
                    ServerLogger.LogMessage(Color.DarkGray, Color.White, ByteArrayToHexString(i_Data), New_Line = true, Show_Time = false);

                    //switch (data)
                    //{
                    //    case SSP_Protocol.eMessegeType.CONFIG:
                    //        HandleConfigMessage(i_ComSource,data);
                    //        break;

                    //    case SSP_Protocol.eMessegeType.TRACE:
                    //        HandleTraceMessage(i_ComSource, data);
                    //        break;

                    //    case SSP_Protocol.eMessegeType.ACK:
                    //        HandleAckMessage(i_ComSource, data);
                    //        break;

                    //    case SSP_Protocol.eMessegeType.TEST:
                    //        HandleTestMessage(i_ComSource, data);
                    //        break;
                    //}

                }
                else
                {
                    // Gil: Not SSP Message
                    ServerLogger.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                    ServerLogger.LogMessage(Color.Blue, Color.White, "[ " + i_ComSource.ToString() + "]" + "  Non SSP Message Received", New_Line = false, Show_Time = false);
                    ServerLogger.LogMessage(Color.Black, Color.White, " \" ", New_Line = false, Show_Time = false);
                    ServerLogger.LogMessage(Color.DarkGray, Color.White, encoder.GetString(i_Data, 0, i_Data.Length), New_Line = false, Show_Time = false);
                    ServerLogger.LogMessage(Color.Black, Color.White, " \" ", New_Line = false, Show_Time = false);
                    ServerLogger.LogMessage(Color.Black, Color.White, " Payload: ", New_Line = false, Show_Time = false);
                    ServerLogger.LogMessage(Color.DarkGray, Color.White, ByteArrayToHexString(i_Data), New_Line = true, Show_Time = false);
                }

            }
            catch (Exception ex)
            {
                ServerLogger.LogMessage(Color.Black, Color.White, ex.ToString(), New_Line = true, Show_Time = true);
            }
        }










        // static int NumOfPositionMessage = 0;


        private void button1_Click(object sender, System.EventArgs e)
        {
            if (comboBox_ConnectionNumber.Text == "None")
            {
                return;
            }
            try
            {
                //int ConNum = int.Parse(comboBox_ConnectionNumber.Text);
                string SendString =/*tempcount.ToString() + "  " +*/ txtDataTx.Text;
                Object objData = SendString;
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                SendDataToServer(comboBox_ConnectionNumber.SelectedItem.ToString(), byData);
            }
            catch (Exception ex)
            {
                ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), true, true);
            }
        }

        bool SerialPortSMSSendData(byte[] i_SendData)
        {

            if (serialPort_SMS.IsOpen)
            {
                // Send the binary data out the port
                serialPort_SMS.Write(i_SendData, 0, i_SendData.Length);

                if (checkBox_DebugSMS.Checked == true)
                {
                    LogSMS.LogMessage(Color.Black, Color.LightGray, "", New_Line = false, Show_Time = true);
                    LogSMS.LogMessage(Color.DarkViolet, Color.LightGray, "Send Data: ", false, false);
                    LogSMS.LogMessage(Color.DarkGreen, Color.LightGray, Encoding.ASCII.GetString(i_SendData), true, false);
                }

                return true;

            }

            return false;
        }

        bool SerialPortSendData(byte[] i_SendData)
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    // Send the binary data out the port
                    serialPort.Write(i_SendData, 0, i_SendData.Length);

                    SerialPortLogger.LogMessage(Color.Purple, Color.LightGray, "", New_Line = false, Show_Time = true);
                    SerialPortLogger.LogMessage(Color.Purple, Color.LightGray, "Tx:>", false, false);
                    SerialPortLogger.LogMessage(Color.Purple, Color.LightGray, Encoding.ASCII.GetString(i_SendData), true, false);
                    return true;

                }
            }
            catch(Exception ex)
            {
                SendExceptionToTheMonitor(ex.Message.ToString());
                
            }


            return false;
        }

        private void SendExceptionToTheMonitor(String i_Message)
        {
            SerialPortLogger.LogMessage(Color.Red, Color.LightGray, i_Message, New_Line = true, Show_Time = true);
        }
        //Color oldColor;
        Gil_Server.Server m_Server;
        private void ListenBox_CheckedChanged(object sender, EventArgs e)
        {
            // Gil: Just to remove the warnings
            New_Line = !New_Line;
            Show_Time = !Show_Time;


            if (ListenBox.Checked)
            {
                //m_Exit = false;
                //oldColor = ListenBox.BackColor;
                ListenBox.BackColor = Color.Gray;
                try
                {


                    m_Server = new Gil_Server.Server(txtPortNo.Text);
                    m_Server.DataRecievedNotifyDelegate += new EventHandler(GilServer_DataRecievedNotifyDelegate);
                    m_Server.InformationNotifyDelegate += new EventHandler(m_Server_InformationNotifyDelegate);

                    m_Server.Open_Server();

                    txtPortNo.Enabled = false;



                }
                catch (SocketException se)
                {
                    ServerLogger.LogMessage(Color.Black, Color.White, "Exception:  " + se.ToString(), true, true);
                }
            }
            else
            {
                ListenBox.BackColor = default(Color);

                m_Server.Close_Server();

                txtPortNo.Enabled = true;

            }
        }

        void m_Server_InformationNotifyDelegate(object sender, EventArgs e)
        {
            Gil_Server.Server.stringEventArgs mye = (Gil_Server.Server.stringEventArgs)e;

            ServerLogger.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
            ServerLogger.LogMessage(Color.Brown, Color.White, "[Internal GPRS Server] ", New_Line = false, Show_Time = false);
            ServerLogger.LogMessage(Color.Black, Color.White, mye.StrData, New_Line = true, Show_Time = false);
        }

        static int LastIgn = 1;
        static int TimerStatusRingWait = 0;
        //string[] UnitNumberToConnections = new string[30];
        Dictionary<string, string> ConnectionToIDdictionary = new Dictionary<string, string>();
        Dictionary<string, string> IDToFOTA_Status = new Dictionary<string, string>();
        void GilServer_DataRecievedNotifyDelegate(object sender, EventArgs e)
        {

            Gil_Server.Server.DataEventArgs mye = (Gil_Server.Server.DataEventArgs)e;

            ASCIIEncoding encoder = new ASCIIEncoding();

            string IncomingString = System.Text.Encoding.Default.GetString(mye.BytesData);

            IncomingString = IncomingString.Replace("\0", "");

            ServerLogger.LogMessage(Color.Black, Color.White, "\n\nData Received: ", New_Line = false, Show_Time = true);
            ServerLogger.LogMessage(Color.Blue, Color.White, "Connection: " + mye.ConnectionNumber, New_Line = false, Show_Time = false);
            //     ServerLogger.LogMessage(Color.Black, Color.White, " \" ", New_Line = false, Show_Time = false);
            ServerLogger.LogMessage(Color.DarkGreen, Color.White, "    " + IncomingString, New_Line = true, Show_Time = false);
            //ServerLogger.LogMessage(Color.Black, Color.White, " \" ", New_Line = false, Show_Time = false);
            //ServerLogger.LogMessage(Color.Black, Color.White, " Payload: ", New_Line = false, Show_Time = false);
            //ServerLogger.LogMessage(Color.DarkGray, Color.White, ByteArrayToHexString(mye.BytesData), New_Line = true, Show_Time = false);

            // GuiHandleData(eComSource.GPRS,mye.BytesData);

            //if (checkBox_EchoResponse.Checked == true)
            //{
            //    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(IncomingString);
            //    ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back Data Length: " + b2.Length, New_Line = true, Show_Time = true);
            //    SendDataToServer(b2);
            //}
            if (checkBox_EchoResponse.Checked == true)
            {

                string ACKBack = string.Format("[{0}],ACK", IncomingString);
                //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                SendDataToServer(mye.ConnectionNumber, b2);
            }


            if (checkBox_ParseMessages.Checked == false)
            {
                return;
            }

            string[] ParseStrings = { "" };
            string[] Key = { "" };
            try
            {
                if (IncomingString.Contains(","))
                {
                    ParseStrings = IncomingString.Split(',');
                    Key = ParseStrings[1].Split('=');
                }
            }
            catch
            {
                ServerLogger.LogMessage(Color.Black, Color.White, "Data Not Valid: " + IncomingString, New_Line = true, Show_Time = true);
                return;
            }

            //string[] UnitNumberToConnections = new List<string>();

            if (ConnectionToIDdictionary.ContainsKey(mye.ConnectionNumber) == false)
            {
                ConnectionToIDdictionary.Add(mye.ConnectionNumber, ParseStrings[0]);
            }
            PrintDictineryIDKeys();
            //UnitNumberToConnections[mye.ConnectionNumber] = ParseStrings[0];

            //dataSource.Add("None");
            //comboBox_ConnectionNumber.DataSource = dataSource;

            //comboBox_ConnectionNumber.DataSource = mye.ConnectionNumber + " " + IncomingString[0];

            if (Key[0] == "POS")
            {

                //if (checkBox_ServerView.Checked == true)
                //{

                //    LogIWatcher.LogMessage(Color.Brown, Color.White, "Source: Server", New_Line = false, Show_Time = true);
                //    LogIWatcher.LogMessage(Color.Brown, Color.White, "POSITION Message Received: ", New_Line = false, Show_Time = true);

                //    string PositionString =
                //        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                //        "\n STATE = " + Key[1] +
                //        "\n GSM LINK QUALITY = " + ParseStrings[2] +
                //        "\n GPS STATUS = " + ParseStrings[3] +
                //        "\n GPS NUM OF SATELLITES = " + ParseStrings[4] +
                //        "\n CURRENT TIME AND DATE = " + ParseStrings[5] + " " + ParseStrings[6] +
                //        "\n LAST GPS TIME AND DATE = " + ParseStrings[7] + " " + ParseStrings[8] +
                //        "\n GPS LATITUDE = " + ParseStrings[9] +
                //        "\n GPS LONGTITUDE = " + ParseStrings[10] +
                //        "\n GPS SPEED = " + ParseStrings[11] +
                //        "\n GPS DIRECTION =" + ParseStrings[12] +
                //        "\n TRIP DISTANCE  = " + ParseStrings[13] +
                //        "\n TOTAL DISTANCE = " + ParseStrings[14] +
                //        "\n ANALOG 1  = " + ParseStrings[15] +
                //        "\n ANALOG 2  = " + ParseStrings[16] +
                //        "\n MESSAGE NUMBER  = " + ParseStrings[17];
                //    //  "\n GPRS MESSAGE  NUMBER = " + PosStrings[15];

                //    //string.Format("\n UNIT ID = {0} \n STATE = {1}\n GSM LINK QUALITY = {2}", PosStrings[0].Replace(";",""), Key[1], PosStrings[2]); 
                //    LogIWatcher.LogMessage(Color.Brown, Color.White, PositionString, New_Line = true, Show_Time = false);
                //}

              //  string ret = "";
                //if (checkBox_ShowURL.Checked)
                //{
                //    ret = "http://maps.google.com/maps?q=" + ParseStrings[9] + "," + ParseStrings[10] + "( " + " Current Time: " + DateTime.Now + "\r\n   S1TimeStamp: " + " )" + "&z=14&ll=" + "," + "&z=17";
                //    Show_WebBrowserUrl(ret);
                //}

                //if (checkBox_RecordLatLong.Checked)
                //{

                //    NumOfPositionMessage++;
                //    //354869050154426,POS=1,GSMLinkQual,5,8,12/9/2013,10:55:11,12/9/2013,10:55:11,32.155636,34.920308,0,304.2,


                //    KMl_text.Add("<Placemark>");
                //    KMl_text.Add("<name>" + "[" + NumOfPositionMessage + "]" + " " + DateTime.Now + "  </name>");
                //    KMl_text.Add("<Point>");
                //    KMl_text.Add("<coordinates>" + ParseStrings[10] + "," + ParseStrings[9] + "</coordinates> ");
                //    KMl_text.Add("</Point>");
                //    KMl_text.Add("</Placemark> ");
                //    KMl_text.Add("</Document> \n");
                //    KMl_text.Add("</kml> \n");

                //    File.Delete(log_file_S1_LatLong);
                //    using (System.IO.StreamWriter file = new System.IO.StreamWriter(log_file_S1_LatLong))
                //    {
                //        foreach (string str in KMl_text)
                //        {
                //            file.WriteLine(str);
                //        }
                //        //for (int i = 0; i < KML_Index; i++)
                //        //{

                //        //}
                //        KMl_text.RemoveAt(KMl_text.Count - 1);
                //        KMl_text.RemoveAt(KMl_text.Count - 1);
                //        // KML_Index -= 2;
                //    }


                //}

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ParseStrings[0], ParseStrings[ParseStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }


            }
            else
            if (Key[0] == "STAT")
            {

                //if (checkBox_ServerView.Checked == true)
                //{

                //    LogIWatcher.LogMessage(Color.Brown, Color.White, "Source: Server", New_Line = false, Show_Time = true);
                //    LogIWatcher.LogMessage(Color.Red, Color.White, "STATUS Message Received: ", New_Line = false, Show_Time = true);

                //    string PositionString =
                //        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                //        "\n SYSTEM STATE = " + Key[1] +
                //        "\n IGN STATE = " + ParseStrings[2] +
                //        "\n GP1 = " + ParseStrings[3] +
                //        "\n GP2 = " + ParseStrings[4] +
                //        "\n GP3 = " + ParseStrings[5] +
                //        "\n Main Power Source = " + ParseStrings[6] +
                //        "\n Back Up Battery problem indication = " + ParseStrings[7] +
                //        "\n OUTPUT 1  STATE = " + ParseStrings[8] +
                //        "\n OUTPUT 2  STATE = " + ParseStrings[9] +
                //        "\n OUTPUT 3  STATE = " + ParseStrings[10] +
                //        "\n OUTPUT 4  STATE = " + ParseStrings[11] +
                //        "\n DATE = " + ParseStrings[12] +
                //        "\n TIME  = " + ParseStrings[13] +
                //        "\n GPS LATITUDE = " + ParseStrings[14] +
                //        "\n GPS LONGTITUDE = " + ParseStrings[15] +
                //        "\n VEHICLE SPEED = " + ParseStrings[16] +
                //        "\n SPEED EVENT  = " + ParseStrings[17] +
                //        "\n BATTERY LOW EVENT =" + ParseStrings[18] +
                //        "\n BATTERY CUT OFF EVENT  = " + ParseStrings[19] +
                //        "\n ACCIDENT EVENT = " + ParseStrings[20] +
                //        "\n TOWING EVENT = " + ParseStrings[21] +
                //        "\n TILT EVENT = " + ParseStrings[22] +
                //        "\n ANTI JAMMING  EVENT = " + ParseStrings[23] +
                //        "\n MESSAGE NUMBER = " + ParseStrings[24];
                //    //  "\n GPRS MESSAGE  NUMBER = " + PosStrings[15];

                //    //string.Format("\n UNIT ID = {0} \n STATE = {1}\n GSM LINK QUALITY = {2}", PosStrings[0].Replace(";",""), Key[1], PosStrings[2]); 
                //    LogIWatcher.LogMessage(Color.Red, Color.White, PositionString, New_Line = true, Show_Time = false);
                //}

                string[] ign = ParseStrings[1].Split('=');
                int Newign = int.Parse(ign[1]);
                if (Newign == 1 && LastIgn == 0)
                {
                    ServerLogger.LogMessage(Color.Blue, Color.White, "New Driving Log Opened", New_Line = true, Show_Time = true);

                    //checkBox_RecordLatLong.Invoke(new EventHandler(delegate
                    //{

                    //    checkBox_RecordLatLong.Checked = false;
                    //    checkBox_RecordLatLong.Checked = true;

                    //}));


                }

                LastIgn = Newign;

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ParseStrings[0], ParseStrings[ParseStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

                // Gil: Comare if the Unit ID is the target Unit ID For encrypted GPRS
                if (TimerStatusRingWait > 0 && SendOneTimeFlag == 1)
                {
                    if (ParseStrings[0].Replace(";", "") == textBox_UnitIDForSMS.Text)
                    {
                        //TimerStatusRingWait = 0;
                        SendOneTimeFlag = 0;
                        byte[] b2 = System.Text.Encoding.ASCII.GetBytes(txtDataTx.Text);
                        SendDataToServer(mye.ConnectionNumber, b2);

                        button_Ring.Invoke(new EventHandler(delegate
                        {
                            button_Ring.BackColor = Color.Orange;
                        }));
                    }
                }
            }
            else
            if (ParseStrings[1].Contains("ACK"))
            {
                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

                if (Key[0] == OpcodeToCompare)
                {
                    OpcodeToCompare = "";
                    ServerLogger.LogMessage(Color.Black, Color.Yellow, "Command Recieved OK!! ", true, true);
                    button_Ring.Invoke(new EventHandler(delegate
                    {
                        button_Ring.BackColor = Color.Green;
                        button_Ring.Text = "Ring Ok";
                    }));

                }
            }
            else
            if (Key[0] == "SMSSTAT?")
            {

                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }
            }
            else
                if (Key[0] == "FMS1" || Key[0] == "FMS2" || Key[0] == "FMS3")
            {

                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

            }
            else
                    if (Key[0] == "MBL1")
            {


                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

            }
            else
                        if (Key[0] == "MBL2")
            {
                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

            }
            else
                    if (Key[0] == "OBD")
            {
                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

            }
            else
                        if (Key[0] == "GRM") //Gil: Garmin message
            {
                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

            }
            else
                            if (Key[0] == "DATA1") //Gil: Garmin message
            {


                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

            }
            else
            if (Key[0] == "GETCONFIG?")
            {
                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {
                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

            }
            else
                if (Key[0] == "CONFIG")
            {

                string[] ACKStrings = IncomingString.Split(',');

                if (checkBox_EchoResponse.Checked == true)
                {

                    string ACKBack = string.Format("{0},ACK,{1}", ACKStrings[0], ACKStrings[ACKStrings.Length - 1].Replace(";", ",;"));
                    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                    SendDataToServer(mye.ConnectionNumber, b2);
                }

                SendToConfigPage(IncomingString, "Server");

            }
            else
                        if (Key[0] == "FOTAU")
            {


                int PacketNumber = int.Parse(ParseStrings[2]);
                //int NumOfTransmitPackets = int.Parse(FOTAStrings[3]);
                //if (NumOfTransmitPackets > 5 || NumOfTransmitPackets < 1)
                //{
                //    ServerLogger.LogMessage(Color.Red, Color.White, "Warning: Number Of Received Packets is no between 1-5", New_Line = true, Show_Time = true);
                //    return;
                //}

                //byte[] buffer = new byte[256];
                if (ConfigFileName != null)
                {
                    // m_BinaryReader = new BinaryReader(File.Open(ConfigFileName, FileMode.Open));
                    string TotalStrToSend = string.Empty;
                    //for (int i = 0; i < NumOfTransmitPackets ; i++)
                    //{
                    int FrameNumber = (PacketNumber);
                    if (FrameNumber == 999999)
                    {
                        //textBox_FOTAEnd.Invoke(new EventHandler(delegate
                        //{
                        IDToFOTA_Status[ParseStrings[0].Replace(";", "")] = "Finish";

                        PrintFotaIDStatus();
                        //textBox_FOTAEnd.BackColor = Color.Green;
                        //textBox_FOTAEnd.Text = "Finish";
                        //}));

                        string ACKBack = string.Format("{0},ACK,{1}", ParseStrings[0], ParseStrings[ParseStrings.Length - 1].Replace(";", ",;"));
                        //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                        byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                        SendDataToServer(mye.ConnectionNumber, b2);
                    }
                    else
                        if (FrameNumber < int.Parse(textBox_TotalFrames1280Bytes.Text))
                    {


                        //m_BinaryReader.BaseStream.Position = 0;
                        //int PositionInFile = 1280 * FrameNumber;
                        //m_BinaryReader.ReadBytes(PositionInFile);
                        //byte[] buffer = new byte[1280];
                        //for(int i=0;i < 1280 ; i++)
                        //{
                        //    buffer[i] = 0x30;
                        //}
                        //byte[] temp = m_BinaryReader.ReadBytes(1280);

                        //temp.CopyTo(buffer, 0);
                        ////m_BinaryReader.Read(buffer, PositionInFile, 256);
                        //// CS,@%@, @$@FOTAS,PACK NUM,256 bytes
                        //string str = Encoding.ASCII.GetString(buffer);
                        //byte b = CalcCheckSumbuffer(buffer);
                        string SendString = string.Format("{0},{1},@%@", FOTAData[FrameNumber], ParseStrings[ParseStrings.Length - 1].Replace(";", ""));

                        TotalStrToSend = SendString;


                        IDToFOTA_Status[ParseStrings[0].Replace(";", "")] = FrameNumber.ToString() + " / " + textBox_TotalFrames1280Bytes.Text;

                        PrintFotaIDStatus();
                        //textBox_MaximumNumberReceivedRequest.Invoke(new EventHandler(delegate
                        //{
                        //    textBox_MaximumNumberReceivedRequest.Text = "";

                        //    IDToFOTA_Status[ParseStrings[0]] = FrameNumber.ToString();

                        //    foreach (var pair in IDToFOTA_Status)
                        //    {

                        //        textBox_MaximumNumberReceivedRequest.AppendText(pair.Key + " | " + pair.Value + " \n");

                        //    }

                        //    //textBox_MaximumNumberReceivedRequest.Text += "," + FrameNumber.ToString();
                        //    //textBox_MaximumNumberReceivedRequest.SelectionStart = textBox_MaximumNumberReceivedRequest.TextLength;
                        //    //textBox_MaximumNumberReceivedRequest.ScrollToCaret();

                        //}));
                    }
                    //}

                    if (TotalStrToSend != string.Empty)
                    {
                        byte[] ByteArr = Encoding.ASCII.GetBytes(TotalStrToSend);
                        byte[] DataToSend = new byte[1500];
                        for (int i = 0; i < 1500; i++)
                        {
                            DataToSend[i] = 0;
                        }

                        ByteArr.CopyTo(DataToSend, 0);
                        //ServerLogger.LogMessage(Color.Black, Color.White, "Send Data Length : " + ByteArr.Length, New_Line = true, Show_Time = true);
                        SendDataToServer(mye.ConnectionNumber, DataToSend);
                    }

                    m_BinaryReader.Close();

                }
                else
                {
                    ServerLogger.LogMessage(Color.Red, Color.White, "Warning: FOTA file wasn't Chosen", New_Line = true, Show_Time = true);
                }

            }



        }

        void PrintFotaIDStatus()
        {
            textBox_MaximumNumberReceivedRequest.Invoke(new EventHandler(delegate
            {
                textBox_MaximumNumberReceivedRequest.Text = "";



                foreach (var pair in IDToFOTA_Status)
                {
                    PhoneBookContact ContactFound = MyPhoneBook.GetContactByUnitID(pair.Key);

                    if (ContactFound != null)
                    {
                        textBox_MaximumNumberReceivedRequest.AppendText(ContactFound.Name + "   " + pair.Value + " \n");
                    }
                    else
                    {
                        textBox_MaximumNumberReceivedRequest.AppendText(pair.Key + "   " + pair.Value + " \n");
                    }
                }

                //textBox_MaximumNumberReceivedRequest.Text += "," + FrameNumber.ToString();
                //textBox_MaximumNumberReceivedRequest.SelectionStart = textBox_MaximumNumberReceivedRequest.TextLength;
                //textBox_MaximumNumberReceivedRequest.ScrollToCaret();

            }));
        }

        void SendToConfigPage(string i_ConfigString, string i_Source)
        {
            bool SuccessParse = ParseConfigString(i_ConfigString);

            if (SuccessParse == true)
            {
                textBox_SourceConfig.Invoke(new EventHandler(delegate
                {
                    textBox_SourceConfig.Text = "Configuration Loaded successfully from " + i_Source + "\nDate: " + DateTime.Now.ToString();
                    textBox_SourceConfig.BackColor = Color.LightGreen;
                }));

            }
            else
            {
            }
        }

        byte CalcCheckSumbufferSize(byte[] i_buffer)
        {
            byte ret = 0;
            for (int i = 0; i < i_buffer.Length; i++)
            {
                ret += i_buffer[i];
            }
            return (byte)ret;
        }

        byte CalcCheckSumbuffer(byte[] i_buffer)
        {
            byte ret = 0;
            for (int i = 0; i < 1280; i++)
            {
                ret += i_buffer[i];
            }
            return (byte)ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        void SendDataToServer(string i_Connection, byte[] i_Data)
        {
            bool Issent = false;

            Issent = WriteDataToServer(i_Connection, i_Data);

            ASCIIEncoding encoder = new ASCIIEncoding();

            string Str = encoder.GetString(i_Data);

            if (Issent == true)
            {
                ServerLogger.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                ServerLogger.LogMessage(Color.DarkViolet, Color.White, "Send Data: ", false, false);
                ServerLogger.LogMessage(Color.DarkViolet, Color.White, " Connection: " + i_Connection, false, false);
                ServerLogger.LogMessage(Color.DarkGreen, Color.White, "   " + Str, true, false);

                //LogIWatcher.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                //LogIWatcher.LogMessage(Color.DarkViolet, Color.White, "Send Data: ", false, false);
                //LogIWatcher.LogMessage(Color.DarkViolet, Color.White, " Connection: " + i_Connection, false, false);
                //LogIWatcher.LogMessage(Color.DarkGreen, Color.White, "   " + Str, true, false);

                //ServerLogger.LogMessage(Color.Black, Color.White, " \" ", false, false);
                //ServerLogger.LogMessage(Color.DarkGray, Color.White, ByteArrayToHexString(i_Data), false, false);
                //ServerLogger.LogMessage(Color.Black, Color.White, " \" ", true, false);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void txtDataTx_TextChanged(object sender, EventArgs e)
        {
            Spetrotec.Properties.Settings.Default.Default_Server_Message = txtDataTx.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                //List<string> S1frameArray = new List<string>();
                //S1frameArray.Add(S1_Protocol.S1_Messege_Builder.Get_Status());
                //SendS1Message(S1frameArray);


            }
            catch (SocketException ex)
            {
                ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), New_Line = true, Show_Time = true);
            }
        }


        //private void button5_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        List<string> S1frameArray = new List<string>();
        //        S1frameArray.Add(S1_Protocol.S1_Messege_Builder.Arm_Disarm_Unit(comboBox_ArmDisArm.Text));
        //        SendS1Message(S1frameArray);


        //    }
        //    catch (SocketException ex)
        //    {
        //        ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), New_Line = true, Show_Time = true);
        //    }
        //}




        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_S1frameArray"></param>
        /// <returns>return bool if sent or not</returns>
        bool SendS1Message(List<string> i_S1frameArray)
        {
            bool ret = false;

            return ret;
        }

        private bool WriteDataToServer(string i_ConnectionNumber, byte[] i_Data)
        {
            if (m_Server != null && m_Server.IsConnectedToClient && m_Server.IsServerActive)
            {
                m_Server.WriteDataToServer(i_ConnectionNumber, i_Data);
                return true;
            }

            return false;
        }



        private void comboBox_InputIndex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void button23_Click(object sender, EventArgs e)
        {

        }


        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void button_SMSControl_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }


        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void txtS1_Clear_Click_1(object sender, EventArgs e)
        {
            try
            {
                SerialPortLogger_TextBox.Invoke(new EventHandler(delegate
                {

                    SerialPortLogger_TextBox.Text = "";

                }));
            }
            catch
            {
            }
        }

        private void btn_GetPosition_Click(object sender, EventArgs e)
        {

        }

        private void btn_ResetUnit_Click(object sender, EventArgs e)
        {

        }

        private void button_GetTripInfo_Click(object sender, EventArgs e)
        {

        }



        private void btn_GetSet1_Click(object sender, EventArgs e)
        {

        }

        private void btn_GetSet2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        void UpdateDefaultsContacts()
        {
            Spetrotec.Properties.Settings.Default.PhoneBook.Clear();

            List<PhoneBookContact> ContactsList = MyPhoneBook.GetContacts();
            foreach (PhoneBookContact PhoneBookContact in ContactsList)
            {
                Spetrotec.Properties.Settings.Default.PhoneBook.Add(PhoneBookContact.Phone + ";;;;" + PhoneBookContact.Name + ";;;;" + PhoneBookContact.Notes + ";;;;" + PhoneBookContact.Password + ";;;;" + PhoneBookContact.UnitID);
            }

            Spetrotec.Properties.Settings.Default.Save();
        }

        void UpdateDefaultsCommands()
        {

            Spetrotec.Properties.Settings.Default.SMS_Commands.Clear();

            foreach (string str in listBox_SMSCommands.Items)
            {
                Spetrotec.Properties.Settings.Default.SMS_Commands.Add(str);
            }

            Spetrotec.Properties.Settings.Default.Save();
        }

        void UpdateSMSCommands()
        {
            //string[] strArray = new string[Spetrotec.Properties.Settings.Default.SMS_Commands.Count];
            //Spetrotec.Properties.Settings.Default.PhoneBook.CopyTo(strArray, 0);

            listBox_SMSCommands.Invoke(new EventHandler(delegate
            {
                listBox_SMSCommands.Items.Clear();
                foreach (string str in Spetrotec.Properties.Settings.Default.SMS_Commands)
                {
                    listBox_SMSCommands.Items.Add((object)str);
                    // comboBox_SMSCommands.Items.Add(str);
                }

                SortSMSCommands();


            }));



        }

        void UpdatePhoneBook()
        {
            string[] strArray = new string[Spetrotec.Properties.Settings.Default.PhoneBook.Count];
            Spetrotec.Properties.Settings.Default.PhoneBook.CopyTo(strArray, 0);
            MyPhoneBook = new PhoneBook(strArray);

            MyPhoneBook.SortPhoneBookByNotes();

            List<PhoneBookContact> ContactsList = MyPhoneBook.GetContacts();

            checkedListBox_PhoneBook.Invoke(new EventHandler(delegate
                    {
                        checkedListBox_PhoneBook.Items.Clear();
                        foreach (PhoneBookContact PhoneBookContact in ContactsList)
                        {
                            checkedListBox_PhoneBook.Items.Add(PhoneBookContact);
                        }
                    }));

        }

        void ClacPhoneBookTimeForPeriodOfSystem()
        {
            System.Windows.Forms.Application.Exit();
        }

        Logger ServerLogger;
        Logger SerialPortLogger;
        //   Logger LogIWatcher;
        Logger LogSMS;
        PhoneBook MyPhoneBook;

        Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series
        {
            Name = "Raw Data",
            //    Color = System.Drawing.Color.Green,
            IsVisibleInLegend = true,
            IsXValueIndexed = false,
            ChartType = SeriesChartType.Line,
            MarkerStyle = MarkerStyle.Diamond
    };

        Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series
        {
            Name = "Moving Avarage 30",
            //    Color = System.Drawing.Color.Blue,
            IsVisibleInLegend = true,
            IsXValueIndexed = false,
            ChartType = SeriesChartType.Line
        };

        Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series
        {
            Name = "0-100",
            //    Color = System.Drawing.Color.Blue,
            IsVisibleInLegend = true,
            IsXValueIndexed = false,
            ChartType = SeriesChartType.Line,
            MarkerStyle = MarkerStyle.Circle
        };

        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();

        void Chart1_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    if (prop != null)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 3 &&
                            Math.Abs(pos.Y - pointYPixel) < 3)
                        {
                            textBox_graph_XY.Text = "Chart=" + result.Series.Name + "\n, X=" + prop.XValue.ToString() + ", Y=" + prop.YValues[0].ToString();

                            tooltip.Show("X=" + prop.XValue + ", Y=" + prop.YValues[0], this.chart1,
                                            pos.X, pos.Y - 15,9999999);
                        }
                    }
                }
            }
        }

        void Chart1_MouseClick(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            //if (prevPosition.HasValue && pos == prevPosition.Value)
            //    return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false,
                                            ChartElementType.DataPoint);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.DataPoint)
                {
                    var prop = result.Object as DataPoint;
                    if (prop != null)
                    {
                        var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                        var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                        // check if the cursor is really close to the point (2 pixels around the point)
                        if (Math.Abs(pos.X - pointXPixel) < 4 &&
                            Math.Abs(pos.Y - pointYPixel) < 4)
                        {
                            chart1.Series[result.Series.Name].Points[(int)prop.XValue].Label = "X=" + prop.XValue + ", Y=" + prop.YValues[0].ToString("0.00");

                        }
                    }
                }
            }
        }

        private void Form1_Closed(object sender, System.EventArgs e)
        {
            ClientSocket.Close();

            if (this.ReceiveThread != null)
            {
                ReceiveThread.Abort();
                //   m_Exit = true;

            }
        }

        // List<S1_Protocol.S1_Messege_Builder.Command_Description> CommandsDescription;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // this.TopMost = true;
                //// this.FormBorderStyle = FormBorderStyle.None;
                // this.WindowState = FormWindowState.Maximized;
                listBox_Charts.Items.Add(series1.Name);
                listBox_Charts.Items.Add(series2.Name);
                listBox_Charts.Items.Add(series3.Name);

                textBox_SendSerialPort.PreviewKeyDown += TextBox_SendSerialPort_PreviewKeyDown;
                this.FormClosed += MainForm_FormClosed;
                chart1.Series.Clear();
                chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                //   chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                chart1.Series.Add(series1);
                chart1.Series.Add(series2);
                chart1.Series.Add(series3);
                //chart1.Series[0].BorderWidth = 2;
                //chart1.Series[1].BorderWidth = 2;

                //chart1.Series[0].IsValueShownAsLabel = true;
                //chart1.Series[1].IsValueShownAsLabel = false;
                //chart1.Series[1].SmartLabelStyle.IsMarkerOverlappingAllowed = false;
                //chart1.Series[0].SmartLabelStyle.IsMarkerOverlappingAllowed = false;
                //chart1.Series[1].SmartLabelStyle.Enabled = true;


                chart1.MouseMove += Chart1_MouseMove;
                chart1.MouseClick += Chart1_MouseClick;

                tabControl1.DrawItem += TabControl1_DrawItem1;
                textBox_SendSerialPort.KeyDown += TextBox_SendSerialPort_KeyDown;

                //tabControl1.TabPages.RemoveAt(2);
                UpdatePhoneBook();
                UpdateSMSCommands();

                //string temp ="";
                //foreach(string str in strArray)
                //{
                //    temp+=str + "\n";
                //}
                //MessageBox.Show(temp);

                //Spetrotec.Properties.Settings.Default.PhoneBook.Add(DateTime.Now.ToString());

                //Spetrotec.Properties.Settings.Default.Save();

                //    txtDataTx.Text = string.Format(";<{0}>STAT?,;", Spetrotec.Properties.Settings.Default.SystemPassword);

                txtPortNo.Text = Spetrotec.Properties.Settings.Default.Start_Port;
                txtDataTx.Text = Spetrotec.Properties.Settings.Default.Default_Server_Message;



                //pictureBox_logo.BringToFront();

                //Gil: Generate all the loggers
                ServerLogger = new Logger("Server", txtGeneral, Clear_btn, PauseCheck, checkBox_RecordGeneral, null, null, null, checkBox_StopLogging);
                SerialPortLogger = new Logger("Serial_Port", SerialPortLogger_TextBox, txtS1_Clear, checkBox_S1Pause, checkBox_S1RecordLog, textBox_SerialPortRecognizePattern, textBox_SerialPortRecognizePattern2, textBox_SerialPortRecognizePattern3, null);

                LogSMS = new Logger("Log_SMS", richTextBox_SMSConsole, button_ClearSMSConsole, checkBox_PauseSMSConsole, checkBox_RecordSMSConsole, null, null, null, null);

                //Gil: Active All the recorders
                checkBox_RecordGeneral.Checked = !checkBox_RecordGeneral.Checked;
                checkBox_S1RecordLog.Checked = !checkBox_S1RecordLog.Checked;
                //checkBox_RecordLatLong.Checked = !checkBox_RecordLatLong.Checked;

                //        checkBox_RecordTrace.Checked = !checkBox_RecordTrace.Checked;

                //Gil: Initialize the serial ports
                serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
                cmbStopBits.DataSource = Enum.GetValues(typeof(StopBits));
                cmbStopBits.SelectedIndex = (int)StopBits.One;
                cmbParity.DataSource = Enum.GetValues(typeof(Parity));
                cmbParity.SelectedIndex = (int)Parity.None;
                //cmbDataBits.DataSource = Enum.GetValues(typeof(Data


                scanComports();


                //cmbBaudRate.Text = Spetrotec.Properties.Settings.Default.Comport_BaudRate;
                //cmbDataBits.Text = Spetrotec.Properties.Settings.Default.Comport_DataBits;
                //cmbStopBits.Text = Spetrotec.Properties.Settings.Default.Comport_StopBit;
                //cmbParity.Text = Spetrotec.Properties.Settings.Default.Comport_Parity;
                //cmbPortName.Text = Spetrotec.Properties.Settings.Default.Comport_Port;


                //Gil: Set Versions Names
                string path = Directory.GetCurrentDirectory();
                string lastFolderName = Path.GetFileName(path);
                //string[] dir = Directory.GetCurrentDirectory().Split('\\');
                string version = lastFolderName;
                //if (ApplicationDeployment.IsNetworkDeployed)
                //{
                //    version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                //}
                //else
                //{
                //    version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                //}

                this.Text = " [ " + ", Version: " + version + ", Compiled: " + RetrieveLinkerTimestamp().ToString() + " ]";






                //Gil: Update Config dictionary
                Dictionary_ConfigurationTextBoxes = new Dictionary<string, TextBox>()
            {
                {"textBox_Config1", textBox_Config1},
                {"textBox_Config2", textBox_Config2},
                {"textBox_Config3", textBox_Config3},
                {"textBox_Config4", textBox_Config4},
                {"textBox_Config5", textBox_Config5},
                {"textBox_Config6", textBox_Config6},
                {"textBox_Config7", textBox_Config7},
                {"textBox_Config8", textBox_Config8},
                {"textBox_Config9", textBox_Config9},
                {"textBox_Config10", textBox_Config10},
                {"textBox_Config11", textBox_Config11},
                {"textBox_Config12", textBox_Config12},
                {"textBox_Config13", textBox_Config13},
                {"textBox_Config14", textBox_Config14},
                {"textBox_Config15", textBox_Config15},
                {"textBox_Config16", textBox_Config16},
                {"textBox_Config17", textBox_Config17},
                {"textBox_Config18", textBox_Config18},
                {"textBox_Config19", textBox_Config19},
                {"textBox_Config20", textBox_Config20},
                {"textBox_Config21", textBox_Config21},
                {"textBox_Config22", textBox_Config22},
                {"textBox_Config23", textBox_Config23},
                {"textBox_Config24", textBox_Config24},
                {"textBox_Config25", textBox_Config25},
                {"textBox_Config26", textBox_Config26},
                {"textBox_Config27", textBox_Config27},
                {"textBox_Config28", textBox_Config28},
                {"textBox_Config29", textBox_Config29},
                {"textBox_Config30", textBox_Config30},
                {"textBox_Config31", textBox_Config31},
                {"textBox_Config32", textBox_Config32},
                {"textBox_Config33", textBox_Config33},
                {"textBox_Config34", textBox_Config34},
                {"textBox_Config35", textBox_Config35},
                {"textBox_Config36", textBox_Config36},
                {"textBox_Config37", textBox_Config37},
                {"textBox_Config38", textBox_Config38},
                {"textBox_Config39", textBox_Config39},
                {"textBox_Config40", textBox_Config40},
                {"textBox_Config41", textBox_Config41},
                {"textBox_Config42", textBox_Config42}
            };

                comboBox_SystemConfigType.SelectedIndex = 0;

                UpdateSerialPortComboBox();

                ShowHidePages();


                TimeSpan TimeFromLastSave = DateTime.Now - Spetrotec.Properties.Settings.Default.LastSaveSMSTime;


                TimeSpan TimeFromLastRunTime = DateTime.Now - Spetrotec.Properties.Settings.Default.LastRunTime;
                //      TimeSpan TimeFromCompilation = DateTime.Now - RetrieveLinkerTimestamp();
                TimeSpan TimeForRunPhoneBookAtTime = DateTime.Now - RetrieveLinkerTimestamp();
                Spetrotec.Properties.Settings.Default.LastRunTime = DateTime.Now;
                Spetrotec.Properties.Settings.Default.Save();

                ///////////////////////////////// Leonid: Compilation time span (Remember this!!!!!!!!)
                if (TimeForRunPhoneBookAtTime.Days > 90)
                {
                    //   ClacPhoneBookTimeForPeriodOfSystem();

                }
                ///////////////////////////////
                if (TimeFromLastSave.Days > 3)
                {
                    SaveCommandsAndContacts();


                }

            }
            catch (Exception ex)
            {
                ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), true, true);
            }

        }

        private void TextBox_SendSerialPort_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
               // MessageBox.Show("Tab");
                e.IsInputKey = true;
            }
            if (e.KeyData == (Keys.Tab | Keys.Shift))
            {
              //  MessageBox.Show("Shift + Tab");
                e.IsInputKey = true;
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseClentConnection();
        }

        Color Tab0Color = default(Color);
        Color Tab1Color = default(Color);
        Color Tab2Color = default(Color);
        Color Tab3Color = default(Color);
        private void TabControl1_DrawItem1(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabControl1.TabPages[e.Index];
            Color TabColor;
            if(e.Index == tabControl1.SelectedIndex)
            {
                TabColor = Color.Aqua;
            }
            else
            {
                TabColor = default(Color);
            }

            //switch (e.Index)
            //{
            //    case 0:
            //        e.Graphics.FillRectangle(new SolidBrush(Tab0Color), e.Bounds);
            //        break;
            //    case 1:
            //        e.Graphics.FillRectangle(new SolidBrush(Tab1Color), e.Bounds);
            //        break;
            //    default:
            //        break;
            //}

            e.Graphics.FillRectangle(new SolidBrush(TabColor), e.Bounds);
            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, e.Font, paddedBounds, page.ForeColor);
        }

        private void TextBox_SendNumberOfTimes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBox_SendSerialDiff_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void SaveCommandsAndContacts()
        {
            string subPath = Directory.GetCurrentDirectory() + "\\SMS_Backup\\";
            string m_log_file_name = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_Contacts" + ".xml";
            string filesName = m_log_file_name;

            bool isExists = System.IO.Directory.Exists(subPath);

            if (!isExists)
            {
                System.IO.Directory.CreateDirectory(subPath);
            }

            using (Stream myStream = File.Create(subPath + m_log_file_name))
            {
                MyPhoneBook.ExportToXML(myStream);
                // Code to write the stream goes here.
                myStream.Close();
            }

            m_log_file_name = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "____________Commands" + ".xml";
            filesName += "\n" + m_log_file_name;
            using (Stream myStream = File.Create(subPath + m_log_file_name))
            {
                List<string> templist = new List<string>();
                foreach (var item in listBox_SMSCommands.Items)
                {
                    templist.Add((string)item);
                }
                XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                TextWriter textWriter = new StreamWriter(myStream);

                serializer.Serialize(textWriter, templist);
                textWriter.Close();
                // Code to write the stream goes here.
                myStream.Close();
            }

            Spetrotec.Properties.Settings.Default.LastSaveSMSTime = DateTime.Now;
            Spetrotec.Properties.Settings.Default.Save();

            LogSMS.LogMessage(Color.Brown, Color.White, " 2 Backup files of contacts and commands Created at \n" + subPath + "\n" + filesName, New_Line = true, Show_Time = true);


        }

        void ShowHidePages()
        {
            if (Spetrotec.Properties.Settings.Default.RemovePages != null)
            {
                int i = 0;
                foreach (string str in Spetrotec.Properties.Settings.Default.RemovePages)
                {
                    try
                    {
                        // comboBox_SerialPortHistory.Items.Add((object)str);
                        // comboBox_SMSCommands.Items.Add(str);
                        Int32 indexToRemove = Int32.Parse(str);

                        tabControl1.TabPages.RemoveAt(indexToRemove - i);
                        i++;
                    }
                    catch
                    {
                        break;
                    }

                }
            }
        }

        Dictionary<string, TextBox> Dictionary_ConfigurationTextBoxes;



        //static public List<string> GetAllCommands()
        //{
        //    Type type = typeof(S1_Protocol.S1_Messege_Builder);
        //    MethodInfo[] info = type.GetMethods();
        //    List<string> ret = new List<string>();

        //    Type type_Object = typeof(Object);
        //    MethodInfo[] info_Object = type_Object.GetMethods();
        //    foreach (MethodInfo inf in info)
        //    {
        //        bool Add = true;
        //        foreach (MethodInfo inf_Obj in info_Object)
        //        {
        //            if (inf_Obj.Name == inf.Name)
        //            {
        //                Add = false;
        //            }
        //        }
        //        if (Add)
        //        {
        //            ret.Add(inf.Name);
        //        }

        //    }
        //    return ret;

        //}

        //void toolStripMenuItem_CopyToSingle_Click(object sender, EventArgs e)
        //{
        //    textBox_AddSendSingleCommand.Text = richTextBox_GetConfig.SelectedText;
        //}




        private void txtbox_Password_TextChanged(object sender, EventArgs e)
        {
            //if (txtbox_Password.Text.Length < 4)
            //{
            //    txtbox_Password.BackColor = Color.OrangeRed;
            //}
            //else
            //{
            //    txtbox_Password.BackColor = Color.White;
            //}
        }


        string ConfigFileName;
        private void button28_Click(object sender, EventArgs e)
        {

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                ConfigFileName = openFileDialog1.FileName;

                //TextBox_File_Name.Text = openFileDialog1.FileName;



            }


        }


        int NumOfRemainCommands = 0;
        private void backgroundWorker_ConfigSystem_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;

            NumOfRemainCommands = 0;
            ConfigProcessExit = false;

            // Gil Calculate the percentage
            //int percent = CalculateProgressDonePercentage();
            worker.ReportProgress(0);

            while (CalculateProgressDonePercentage() < 100)
            {
                // Gil: Check if somthing worng happend
                if (ConfigProcessExit == true)
                {


                    //progressBar_ConfigSystem.Invoke(new EventHandler(delegate
                    //{
                    //    try
                    //    {
                    //        progressBar_ConfigSystem.Value = 100;
                    //        progressBar_ConfigSystem.ForeColor = Color.Red;
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), true, true);
                    //    }
                    //}));
                    break;
                }
                else
                {

                    //Gil: Do work
                    PerformStep();

                    // Gil Calculate the percentage
                    int percent = CalculateProgressDonePercentage();
                    worker.ReportProgress(percent);
                }




            }

            //Config_Sys.Invoke(new EventHandler(delegate
            //        {
            //            Config_Sys.Enabled = true;
            //        }));
            //worker.ReportProgress(CalculateProgressDonePercentage());
        }

        //void backgroundWorker_ConfigSystem_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    if (ConfigProcessExit == true)
        //    {
        //        return;
        //    }
        //    if (CalculateProgressDonePercentage() <= progressBar_ConfigSystem.Maximum && CalculateProgressDonePercentage() >= progressBar_ConfigSystem.Minimum)
        //    {

        //        progressBar_ConfigSystem.Invoke(new EventHandler(delegate
        //        {
        //            try
        //            {
        //                progressBar_ConfigSystem.Value = CalculateProgressDonePercentage();

        //                if (progressBar_ConfigSystem.Value == progressBar_ConfigSystem.Maximum)
        //                {
        //                    progressBar_ConfigSystem.ForeColor = Color.Green;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), true, true);
        //            }
        //        }));
        //    }

        //}

        // static int precentage = 0;

        //private void Config_Sys_Click(object sender, EventArgs e)
        //{


        //    Config_Sys.Enabled = false;
        //    //precentage = 0;
        //    progressBar_ConfigSystem.ForeColor = Color.Blue;
        //    progressBar_ConfigSystem.BackColor = Color.White;
        //    try
        //    {
        //        //backgroundWorker_ConfigSystem.RunWorkerAsync();
        //    }
        //    catch
        //    {
        //        progressBar_ConfigSystem.ForeColor = default(Color);
        //        progressBar_ConfigSystem.BackColor = default(Color);
        //    }

        //}

        enum eACKMessageReceived
        {
            UNDEFINED,
            ACK,
            NACK

        }
        bool ConfigProcessExit = false;
        private void PerformStep()
        {
            //int i;

            //// Gil: Send the command

            //TextBox_S1Commands.Invoke(new EventHandler(delegate
            //{
            //    TextBox_S1Commands.AppendText("Command Number: " + NumOfRemainCommands + " Sent \n\n");
            //    TextBox_S1Commands.ScrollToCaret();
            //}));

            //SendS1Message((List<string> )CommandsToSend[NumOfRemainCommands]);




            //// Gil: Wait for ACK or timeout

            //i = 0;
            //ExitLoopFileConfig = false;
            //int CommandSentTimeout = int.Parse(textBox_TimeoutForfileConfiguration.Text);
            //while (i < CommandSentTimeout && ExitLoopFileConfig == false)
            //{

            //    switch (ACKMessageReceived)
            //    {
            //        case eACKMessageReceived.ACK:
            //                                        TextBox_S1Commands.Invoke(new EventHandler(delegate
            //                                        {
            //                                            TextBox_S1Commands.AppendText("Command Number: " + NumOfRemainCommands + " ACK Received :-) \n\n");
            //                                            TextBox_S1Commands.ScrollToCaret();
            //                                        }));


            //                                        ExitLoopFileConfig = true;
            //            break;

            //        case eACKMessageReceived.NACK:
            //                                        ConfigProcessExit = true;

            //                                        TextBox_S1Commands.Invoke(new EventHandler(delegate
            //                                        {
            //                                            TextBox_S1Commands.AppendText("Command Number: " + NumOfRemainCommands + " NACK Received !!!!! \n\n");
            //                                            TextBox_S1Commands.ScrollToCaret();
            //                                        }));

            //                                        ExitLoopFileConfig = true;
            //            break;

            //        case eACKMessageReceived.UNDEFINED:
            //            break;

            //    }

            //    Thread.Sleep(1000);
            //    i++;

            //    textBox_TimeoutForfileConfiguration.Invoke(new EventHandler(delegate
            //    {
            //        textBox_TimeoutForfileConfiguration.ReadOnly = true;
            //        textBox_TimeoutForfileConfiguration.Text = (CommandSentTimeout - i).ToString();
            //    }));
            //    if (i == CommandSentTimeout)
            //    {
            //        ConfigProcessExit = true;

            //        TextBox_S1Commands.Invoke(new EventHandler(delegate
            //        {
            //            TextBox_S1Commands.AppendText("Command Number: " + NumOfRemainCommands + " TIMEOUT \n\n");
            //            TextBox_S1Commands.ScrollToCaret();
            //        }));
            //    }
            //}

            //textBox_TimeoutForfileConfiguration.Invoke(new EventHandler(delegate
            //{
            //    textBox_TimeoutForfileConfiguration.ReadOnly = false;
            //    textBox_TimeoutForfileConfiguration.Text = "20";
            //}));


            //if (ConfigProcessExit != true)
            //{
            //    NumOfRemainCommands++;
            //}



        }


        private int CalculateProgressDonePercentage()
        {
            float ret = ((float)NumOfRemainCommands / (float)CommandsToSend.Count) * 100;
            return (int)ret;
        }






        //Color originColor_LatLong;
        //string log_file_S1_LatLong;
        List<string> KMl_text = new List<string>();
        //       int KML_Index = 0;
        //   int DrivingNumber = 0;
        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {
            //if (checkBox_RecordLatLong.Checked)
            //{
            //    KMl_text.Clear();
            //    DrivingNumber++;
            //    originColor_LatLong = checkBox_RecordLatLong.BackColor;
            //    checkBox_RecordLatLong.BackColor = Color.Yellow;

            //    log_file_S1_LatLong = "Log_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_LatLong_Record_DRVNUM_" + DrivingNumber + ".kml";
            //    try
            //    {

            //        while (File.Exists(log_file_S1_LatLong))
            //        {
            //            log_file_S1_LatLong = "Log_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_LatLong_Record" + ".kml";
            //        }


            //        NumOfPositionMessage = 0;
            //        KMl_text.Add("<?xml version=\"1.0\" encoding=\"UTF-8\"?>"); 
            //        KMl_text.Add("<kml xmlns=\"http://www.google.com/earth/kml/2\">");
            //        KMl_text.Add("<Document>");




            //        SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, "File " + log_file_S1_LatLong + " opened in directory \" " + Directory.GetCurrentDirectory() + "\" \n\n", true, true);
            //        //}


            //    }
            //    catch (Exception)
            //    {
            //        SerialPortLogger.LogMessage(Color.Orange, Color.LightGray, "Can't Open File", true, true);
            //    }

            //}
            //else
            //{
            //    checkBox_RecordLatLong.BackColor = default(Color);

            //    SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, "File " + log_file_S1_LatLong + " closed \n\n", true, true);
            //}
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }


        List<List<string>> CommandsToSend = new List<List<string>>();












        private void button29_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox_GeneralMessage_TextChanged(object sender, EventArgs e)
        {

        }
        Double ChartCntX = 0, ChartCntY = 0;
        Double ChartCntY2 = 0;
        Double ChartCntY3 = 0;
        bool OppositeCount = false;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string PrintTimeSpan(TimeSpan t)
        {
            string answer;
            if (t.TotalMinutes < 1.0)
            {
                answer = String.Format("{0}.{1:D2}s", t.Seconds, t.Milliseconds / 10);
            }
            else if (t.TotalHours < 1.0)
            {
                //answer = String.Format("{0}m:{1:D2}.{2:D2}s", t.Minutes, t.Seconds, t.Milliseconds % 100);
                answer = String.Format("{0}m:{1:D2}", t.Minutes, t.Seconds);
            }
            else // more than 1 hour
            {
                answer = String.Format("{0}h:{1:D2}m:{2:D2}", (int)t.TotalHours, t.Minutes, t.Seconds);
            }

            return answer;
        }


        static int GetDataIntervalCounter;
        bool IsTimedOutTimerEnabled = false;
        /// <summary>
        /// 
        /// </summary>
        int Timer_100ms = 0;

        void ClientTCpipProcessing()
        {
            try
            {
                if (ClientSocket == null)
                {
                    button_ClientConnect.BackColor = default(Color);
                }
                else
                    if (ClientSocket.Connected && ClientSocket.Client.Connected && ClientSocket.GetStream() != null)
                    {
                        button_ClientConnect.BackColor = Color.Green;
                    }
                    else
                    {
                        button_ClientConnect.BackColor = default(Color);
                    }




            }
            catch
            {
                button_ClientConnect.BackColor = default(Color);
            }

        }

        private int TimeOutKeepAlivein100ms = 3000000;
        private void timer_ConectionKeepAlive_Tick(object sender, EventArgs e)
        {
            Timer_100ms++;

            ClientTCpipProcessing();

            if (stopwatch.IsRunning == true)
            {
                textBox_StopWatch.Text = PrintTimeSpan(stopwatch.Elapsed);
            }

            // Gil: In case Time Out Expiered close all the threads and connections
            if (IsTimedOutTimerEnabled == true)
            {
                GetDataIntervalCounter++;
                if (GetDataIntervalCounter >= TimeOutKeepAlivein100ms)
                {
                    //IsTimedOutTimerEnabled = false;
                    GetDataIntervalCounter = 0;
                    ServerLogger.LogMessage(Color.Orange, Color.White, "Connection Time Out ", New_Line = true, Show_Time = true);
                    ListenBox.Checked = !ListenBox.Checked;
                    ListenBox.Checked = !ListenBox.Checked;
                }
            }




            if (m_Server != null)
            {
                try
                {
                    if (m_Server.IsServerActive)
                    {
                        textBox_ServerActive.BackColor = Color.Green;
                    }
                    else
                    {
                        textBox_ServerActive.BackColor = default(Color);
                    }


                    if (m_Server.IsConnectedToClient)
                    {
                        IsTimedOutTimerEnabled = true;
                        textBox_ServerOpen.BackColor = Color.Green;
                        //ListenBox.BackColor = Color.Green;
                    }
                    else
                    {
                        IsTimedOutTimerEnabled = false;
                        textBox_ServerOpen.BackColor = default(Color);
                        // ListenBox.BackColor = Color.Yellow;
                    }


                    textBox_NumberOfOpenConnections.Text = m_Server.NumberOfOpenConnections.ToString();

                }
                catch (Exception ex)
                {
                    ServerLogger.LogMessage(Color.Red, Color.White, ex.ToString(), New_Line = true, Show_Time = true);
                }
            }



            if (IsPauseGraphs == false)
            {
                GraphPrint();
            }
            




        }

        List<double> ChartMem = new List<double>();
        List<double> ChartMem2 = new List<double>();
        Random rand = new Random();
        private const int MOVING_AVARAGE_SIZE = 30;
        void GraphPrint()
        {



            ChartCntY2 = 0;

            if(OppositeCount == true)
            {
                ChartCntY3++;
                ChartCntY3 *= 1.1;
                if (ChartCntY3 >= 100)
                {
                    OppositeCount = false;
                }
            }
            else
            {
                ChartCntY3--;
                ChartCntY3 *= 0.9;
                if (ChartCntY3 <= 0)
                {
                    OppositeCount = true;
                }
            }


            int cnt = 0;
            for (int i = series1.Points.Count - 1; i >= (series1.Points.Count - MOVING_AVARAGE_SIZE) && i >= 0; i--)
            {
                cnt++;
                ChartCntY2 += (int)series1.Points[i].YValues[0];
            }
            ChartCntY2 = ChartCntY2 / cnt;

            if (IsPauseGraphs == false)
            {
                series1.Points.AddXY(ChartCntX, ChartCntY);
                series2.Points.AddXY(ChartCntX, ChartCntY2);
                series3.Points.AddXY(ChartCntX, ChartCntY3);
            }
            else
            {
                ChartMem.Add(ChartCntY);
                ChartMem2.Add(ChartCntY2);
            }

            ChartCntX++;
            double temp = rand.Next(-1, 2);
            temp = temp * rand.NextDouble();
            ChartCntY = ChartCntY + temp;

            if(ChartCntY > ChartCntY2)
            {
                chart1.BackColor = Color.LightGreen;
            }
            else
            {
                chart1.BackColor = Color.Red;
            }
            //  ChartCntY2 = ChartCntY2 + rnd.Next(-1, 2);

            //if (ChartCntX > 1000)
            //{
            //    ChartCntX = 0;
            //    series1.Points.Clear();
            //    series2.Points.Clear();
            //}


                chart1.Refresh();
                chart1.Invalidate();
            
        }

        static float NextFloat(Random random)
        {
            double mantissa = (random.NextDouble() * 2.0) - 1.0;
            // choose -149 instead of -126 to also generate subnormal floats (*)
            double exponent = Math.Pow(2.0, random.Next(-126, 128));
            return (float)(mantissa * exponent);
        }

        private void TakeCroppedScreenShot()
        {
            string FileLocation = @".\MyPanelImage.bmp";
            Bitmap bmp = new Bitmap(chart1.Width, chart1.Height);
            chart1.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            bmp.Save(FileLocation);

            var filePath = FileLocation;
            ProcessStartInfo Info = new ProcessStartInfo()
            {
                FileName = "mspaint.exe",
                WindowStyle = ProcessWindowStyle.Maximized,
                Arguments = filePath
            };
            Process.Start(Info);
        }


        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void button_Set2_Click(object sender, EventArgs e)
        {

        }

        private void button_GenerateConfigFile_Click(object sender, EventArgs e)
        {

        }

        private void button_Set1_Click(object sender, EventArgs e)
        {



        }



        //bool timer_General_TranssmitionPeriodicallyEnable = false;
        //uint NumbeOfTransmmitions = 0;
        int TimerCounter100ms = 0, TimerClearModemStatus = 0, TimerExportContactsCommandsToFile = 0;
        //uint IntervalTimeBetweenTransmitions = 1;
        private void timer_General_Tick(object sender, EventArgs e)
        {
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            Tab0Color = randomColor;

            randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            Tab1Color = randomColor;

            randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            Tab2Color = randomColor;

            randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            Tab3Color = randomColor;
            tabControl1.Invalidate();

            if (IsTimerRunning == true)
            {
                int Result = 0;
                int.TryParse(textBox_TimerTime.Text, out Result);
                if (Result != 0)
                {
                    Result--;
                    if (Result == 0)
                    {
                        SerialPortLogger.LogMessage(Color.White, Color.DarkOrange, "Timer End", true, true);
                        checkBox_S1Pause.Checked = true;

                        ResetTimer();
                    }
                    else
                    {

                    }
                    textBox_TimerTime.Text = Result.ToString();
                }
            }


            //         label_TimeDate.Text = DateTime.Now.ToString();
            label_TimeDate2.Text = DateTime.Now.ToString();
            //label_TimeDate3.Text = DateTime.Now.ToString();

            if (TimerStatusRingWait > 0)
            {
                TimerStatusRingWait--;
                button_Ring.Text = "Ring Processing (" + TimerStatusRingWait + ")" + "(" + SendOneTimeFlag + ")";

            }
            else
            {
                button_Ring.BackColor = default(Color);
                button_Ring.Text = "Ring";
            }

            TimerCounter100ms++;

            TimerClearModemStatus++;

            TimerExportContactsCommandsToFile++;

            if (TimerClearModemStatus % 60 == 0)
            {
                richTextBox_ModemStatus.Invoke(new EventHandler(delegate
                {
                    richTextBox_ModemStatus.BackColor = default(Color);
                    richTextBox_ModemStatus.Text = "";
                }));
            }


            if (m_Server != null)
            {
                textBox_CurrentTimeOut.Text = ((TimeOutKeepAlivein100ms / 10) - (GetDataIntervalCounter / 10)).ToString();

            }




            if (CloseSerialPortTimer == true)
            {
                CloseSerialPortConter++;
                if (CloseSerialPortConter > 1)
                {
                    serialPort_DataReceived(null, null);
                    CloseSerialPortConter = 0;
                }
            }
            try
            {
                if (m_Server != null)
                {

                    if (m_Server.NumberOfOpenConnections == 0)
                    {
                        var dataSource = new List<string>();
                        dataSource.Add("None");
                        comboBox_ConnectionNumber.DataSource = dataSource;
                        LastConNum = m_Server.NumberOfOpenConnections;

                        ConnectionToIDdictionary.Clear();
                        //for (int i = 0; i < UnitNumberToConnections.Length; i++)
                        //{
                        //    UnitNumberToConnections[i] = "";
                        //}
                    }
                    else
                        if (LastConNum != m_Server.NumberOfOpenConnections)
                    {
                        List<string> ret = m_Server.GetAllOpenConnections();

                        List<string> listkeys = new List<string>(ConnectionToIDdictionary.Keys);
                        foreach (string str in listkeys)
                        {
                            bool found = false;

                            foreach (string str2 in ret)
                            {
                                if (str == str2)
                                {
                                    found = true;

                                }
                            }

                            if (found == false)
                            {
                                ConnectionToIDdictionary.Remove(str);
                            }
                        }

                        comboBox_ConnectionNumber.DataSource = ret;

                        LastConNum = m_Server.NumberOfOpenConnections;


                    }
                    PrintDictineryIDKeys();
                }



            }
            catch (Exception ex)
            {
                ServerLogger.LogMessage(Color.Red, Color.White, ex.ToString(), New_Line = true, Show_Time = true);
            }
            //if (ComPortClosing == true)
            //{
            //    Thread.Sleep(4000);
            //    serialPort_DataReceived(null, null);
            //}


        }

        void PrintDictineryIDKeys()
        {
            textBox_IDKey.Invoke(new EventHandler(delegate
            {
                textBox_IDKey.Text = "Connection       |      Unit ID \n";
                textBox_IDKey.AppendText("------------------------------------- \n");
            }));

            foreach (var pair in ConnectionToIDdictionary)
            {
                textBox_IDKey.Invoke(new EventHandler(delegate
                {
                    textBox_IDKey.AppendText(pair.Key + " | " + pair.Value.Replace(';', ' ') + " \n");
                }));
            }

        }

        static int LastConNum = 0;
        static int CloseSerialPortConter = 0;


        //private void UpdateConfigText()
        //{
        //    ConfigText = "";
        //    if (Set1_Configuration != null)
        //    {
        //        ConfigText += Set1_Configuration.Set1_Config();
        //    }

        //    if (Set2_Configuration != null)
        //    {
        //        ConfigText += Set2_Configuration.Set2_Config();
        //    }

        //    richTextBox_GetConfig.Text = ConfigText;
        //}
        private void checkBox_ComportOpen_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox_ComportOpen.Checked)
            {
                try
                {
                    checkBox_ComportOpen.BackColor = Color.Yellow;

                    ComPortClosing = false;

                    CloseSerialPortTimer = false;



                    // Set the port's settings

                    serialPort.BaudRate = int.Parse(cmbBaudRate.Text);

                    if (cmbBaudRate.Items.Contains(cmbBaudRate.Text) == false)
                    {
                        cmbBaudRate.Items.Add(cmbBaudRate.Text);
                    }

                    serialPort.DataBits = int.Parse(cmbDataBits.Text);
                    serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.Text);
                    serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text);
                    serialPort.PortName = cmbPortName.Text;




                    serialPort.WriteTimeout = 500;
                    serialPort.Open();

                    //ListenBox.Checked = false;
                    //groupBox_ServerSettings.Enabled = false;
                    IsTimedOutTimerEnabled = false;

                    SerialPortLogger.LogMessage(Color.Green, Color.LightGray,
                     " Serial port Opened with  " + " ,PortName = " + serialPort.PortName
                     + " ,BaudRate = " + serialPort.BaudRate +
                     " ,DataBits = " + serialPort.DataBits +
                     " ,StopBits = " + serialPort.StopBits +
                     " ,Parity = " + serialPort.Parity,
                     New_Line = true, Show_Time = true);

                    checkBox_ComportOpen.BackColor = Color.Green;


                    cmbBaudRate.Enabled = false;
                    cmbDataBits.Enabled = false;
                    cmbParity.Enabled = false;
                    cmbPortName.Enabled = false;
                    cmbStopBits.Enabled = false;

                    Spetrotec.Properties.Settings.Default.Comport_BaudRate = cmbBaudRate.Text;
                    Spetrotec.Properties.Settings.Default.Comport_DataBits = cmbDataBits.Text;
                    Spetrotec.Properties.Settings.Default.Comport_StopBit = cmbStopBits.Text;
                    Spetrotec.Properties.Settings.Default.Comport_Parity = cmbParity.Text;
                    Spetrotec.Properties.Settings.Default.Comport_Port = cmbPortName.Text;

                    Spetrotec.Properties.Settings.Default.Save();


                }
                catch (Exception ex)
                {
                    checkBox_ComportOpen.Checked = false;

                    //SerialException = true;

                    SerialPortLogger.LogMessage(Color.Red, Color.LightGray, ex.Message.ToString(), New_Line = true, Show_Time = true);
                    return;
                }




            }
            else
            {

                ComPortClosing = true;
                checkBox_ComportOpen.BackColor = default(Color);
                //checkBox_ComportOpen.Enabled = false;

                CloseSerialPortTimer = true;
                CloseSerialPortConter = 0;




                //groupBox_ServerSettings.Enabled = true;
            }
        }

        bool CloseSerialPortTimer = false;

        bool ComPortClosing = false;
        //List<byte> temp_serialBuff = new List<byte>();
        void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            // If the com port has been closed, do nothing
            if (!serialPort.IsOpen) return;


            if (ComPortClosing == true)
            {
                //Thread.Sleep(400);
                serialPort.Close();
                ComPortClosing = false;

                //checkBox_ComportOpen.Checked = false;

                cmbBaudRate.Invoke(new EventHandler(delegate
                 {
                     checkBox_ComportOpen.Checked = false;
                     checkBox_ComportOpen.Enabled = true;
                     checkBox_ComportOpen.BackColor = default(Color);
                     cmbBaudRate.Enabled = true;
                     cmbDataBits.Enabled = true;
                     cmbParity.Enabled = true;
                     cmbPortName.Enabled = true;
                     cmbStopBits.Enabled = true;
                 }));

                CloseSerialPortTimer = false;

                SerialPortLogger.LogMessage(Color.Orange, Color.LightGray, "Serial port Closed", New_Line = true, Show_Time = true);
                return;
            }

            // This method will be called when there is data waiting in the port's buffer
            Thread.Sleep(300);

            if (!serialPort.IsOpen) return;

            // Obtain the number of bytes waiting in the port's buffer
            int bytes = serialPort.BytesToRead;

            // Create a byte array buffer to hold the incoming data
            byte[] buffer = new byte[bytes];

            // Read the data from the port and store it in our buffer
            serialPort.Read(buffer, 0, bytes);


            string IncomingString = System.Text.Encoding.Default.GetString(buffer);



            SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, "Rx:>", New_Line = false, Show_Time = true);
            string[] lines = Regex.Split(IncomingString, "\r\n");

            foreach (string line in lines)
            {
                SerialPortLogger.LogMessage(Color.Blue, Color.LightGray, line, New_Line = true, Show_Time = false);
            }



            ParseSerialPortString(IncomingString);


        }

        enum SourceMessage
        {
            SMS,
            SerialPort,
            Server
        };

        void ParseStatuPos(string IncomingString, SourceMessage i_SourceMessage, PhoneBookContact i_Contact)
        {
            string[] ParseStrings = { "" };
            string[] Key = { "" };
            try
            {
                if (IncomingString.Contains(","))
                {
                    ParseStrings = IncomingString.Split(',');
                    Key = ParseStrings[1].Split('=');
                }
            }
            catch
            {
                //ServerLogger.LogMessage(Color.Black, Color.White, "Data Not Valid: " + IncomingString, New_Line = true, Show_Time = true);
                return;
            }

            Boolean IwatcherPrint = false;


            if (Key[0] == "POS")
            {

                if (IwatcherPrint == true)
                {
                    //LogIWatcher.LogMessage(Color.Brown, Color.White, "Source: " + i_SourceMessage.ToString(), New_Line = false, Show_Time = true);
                    //if (i_Contact != null)
                    //{
                    //    LogIWatcher.LogMessage(Color.DarkBlue, Color.White, "\nName: " + i_Contact.Name, New_Line = false, Show_Time = false);
                    //}
                    //else
                    //{
                    //    LogIWatcher.LogMessage(Color.DarkBlue, Color.White, "\nName: ", New_Line = false, Show_Time = false);
                    //}
                    //LogIWatcher.LogMessage(Color.DarkOrange, Color.White, "\nPOSITION Message Received: ", New_Line = false, Show_Time = false);

                    string PositionString =
                        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                        "\n STATE = " + Key[1] +
                        "\n GSM LINK QUALITY = " + ParseStrings[2] +
                        "\n GPS STATUS = " + ParseStrings[3] +
                        "\n GPS NUM OF SATELLITES = " + ParseStrings[4] +
                        "\n CURRENT TIME AND DATE = " + ParseStrings[5] + " " + ParseStrings[6] +
                        "\n LAST GPS TIME AND DATE = " + ParseStrings[7] + " " + ParseStrings[8] +
                        "\n GPS LATITUDE = " + ParseStrings[9] +
                        "\n GPS LONGTITUDE = " + ParseStrings[10] +
                        "\n GPS SPEED = " + ParseStrings[11] +
                        "\n GPS DIRECTION =" + ParseStrings[12] +
                        "\n TRIP DISTANCE  = " + ParseStrings[13] +
                        "\n TOTAL DISTANCE = " + ParseStrings[14];
                    //  "\n GPRS MESSAGE  NUMBER = " + PosStrings[15];

                    //string.Format("\n UNIT ID = {0} \n STATE = {1}\n GSM LINK QUALITY = {2}", PosStrings[0].Replace(";",""), Key[1], PosStrings[2]); 
                    //LogIWatcher.LogMessage(Color.Brown, Color.White, PositionString, New_Line = true, Show_Time = false);
                }

                //string ret = "";
                //if (checkBox_ShowURL.Checked)
                //{
                //    string ret = "http://maps.google.com/maps?q=" + ParseStrings[9] + "," + ParseStrings[10] + "( " + " Current Time: " + DateTime.Now + "\r\n   S1TimeStamp: " + " )" + "&z=14&ll=" + "," + "&z=17";
                //    Show_WebBrowserUrl(ret);
                //}

                //if (checkBox_RecordLatLong.Checked)
                //{

                //    NumOfPositionMessage++;
                //    //354869050154426,POS=1,GSMLinkQual,5,8,12/9/2013,10:55:11,12/9/2013,10:55:11,32.155636,34.920308,0,304.2,


                //    KMl_text.Add("<Placemark>");
                //    KMl_text.Add("<name>" + "[" + NumOfPositionMessage + "]" + " " + DateTime.Now + "  </name>");
                //    KMl_text.Add("<Point>");
                //    KMl_text.Add("<coordinates>" + ParseStrings[10] + "," + ParseStrings[9] + "</coordinates> ");
                //    KMl_text.Add("</Point>");
                //    KMl_text.Add("</Placemark> ");
                //    KMl_text.Add("</Document> \n");
                //    KMl_text.Add("</kml> \n");

                //    File.Delete(log_file_S1_LatLong);
                //    using (System.IO.StreamWriter file = new System.IO.StreamWriter(log_file_S1_LatLong))
                //    {
                //        foreach (string str in KMl_text)
                //        {
                //            file.WriteLine(str);
                //        }
                //        //for (int i = 0; i < KML_Index; i++)
                //        //{

                //        //}
                //        KMl_text.RemoveAt(KMl_text.Count - 1);
                //        KMl_text.RemoveAt(KMl_text.Count - 1);
                //        // KML_Index -= 2;
                //    }


                //}

                //if (checkBox_EchoResponse.Checked == true)
                //{

                //    string ACKBack = string.Format("{0},ACK,{1}", ParseStrings[0], ParseStrings[ParseStrings.Length - 1].Replace(";", ",;"));
                //    //ServerLogger.LogMessage(Color.DarkSalmon, Color.White, "Send Echo Back:  " + ACKBack, New_Line = true, Show_Time = true);
                //    byte[] b2 = System.Text.Encoding.ASCII.GetBytes(ACKBack);
                //    SendDataToServer(mye.ConnectionNumber, b2);
                //}


            }
            else
                if (Key[0] == "STAT")
            {
                if (IwatcherPrint == true)
                {
                    //LogIWatcher.LogMessage(Color.Brown, Color.White, "Source: " + i_SourceMessage.ToString(), New_Line = false, Show_Time = true);
                    //if (i_Contact != null)
                    //{
                    //    LogIWatcher.LogMessage(Color.DarkBlue, Color.White, "\nName: " + i_Contact.Name, New_Line = false, Show_Time = false);
                    //}
                    //else
                    //{
                    //    LogIWatcher.LogMessage(Color.DarkBlue, Color.White, "\nName: ", New_Line = false, Show_Time = false);
                    //}
                    //LogIWatcher.LogMessage(Color.DarkOrange, Color.White, "\nSTATUS Message Received: ", New_Line = false, Show_Time = false);

                    string PositionString =
                        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                        "\n SYSTEM STATE = " + Key[1] +
                        "\n IGN STATE = " + ParseStrings[2] +
                        "\n GP1 = " + ParseStrings[3] +
                        "\n GP2 = " + ParseStrings[4] +
                        "\n GP3 = " + ParseStrings[5] +
                        "\n Main Power Source = " + ParseStrings[6] +
                        "\n Back Up Battery problem indication = " + ParseStrings[7] +
                        "\n OUTPUT 1  STATE = " + ParseStrings[8] +
                        "\n OUTPUT 2  STATE = " + ParseStrings[9] +
                        "\n OUTPUT 3  STATE = " + ParseStrings[10] +
                        "\n OUTPUT 4  STATE = " + ParseStrings[11] +
                        "\n DATE = " + ParseStrings[12] +
                        "\n TIME  = " + ParseStrings[13] +
                        "\n GPS LATITUDE = " + ParseStrings[14] +
                        "\n GPS LONGTITUDE = " + ParseStrings[15] +
                        "\n VEHICLE SPEED = " + ParseStrings[16] +
                        "\n SPEED EVENT  = " + ParseStrings[17] +
                        "\n BATTERY LOW EVENT =" + ParseStrings[18] +
                        "\n BATTERY CUT OFF EVENT  = " + ParseStrings[19] +
                        "\n ACCIDENT EVENT = " + ParseStrings[20] +
                        "\n TOWING EVENT = " + ParseStrings[21] +
                        "\n TILT EVENT = " + ParseStrings[22];

                    //LogIWatcher.LogMessage(Color.Blue, Color.White, PositionString, New_Line = true, Show_Time = false);
                }
            }
            else
                    if (Key[0] == "GETCONFIG?")
            {
                if (IwatcherPrint == true)
                {
                    //LogIWatcher.LogMessage(Color.Brown, Color.White, "Source: " + i_SourceMessage.ToString(), New_Line = false, Show_Time = true);
                    //if (i_Contact != null)
                    //{
                    //    LogIWatcher.LogMessage(Color.DarkBlue, Color.White, "\nName: " + i_Contact.Name, New_Line = false, Show_Time = false);
                    //}
                    //else
                    //{
                    //    LogIWatcher.LogMessage(Color.DarkBlue, Color.White, "\nName: ", New_Line = false, Show_Time = false);
                    //}
                    //LogIWatcher.LogMessage(Color.DarkOrange, Color.White, "\nGETCONFIG: Message Received: ", New_Line = false, Show_Time = false);

                    // ,,, ,N/A,N/A;

                    string PositionString =
                        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                        "\n SUBSCRIBER 1 = " + ParseStrings[2] +
                        "\n SUBSCRIBER 2 = " + ParseStrings[3] +
                        "\n SUBSCRIBER 3 = " + ParseStrings[4] +
                        "\n SPEED LIMIT = " + ParseStrings[5] +
                        "\n vehicle battery threshold = " + ParseStrings[6] +
                        "\n pos message duration time interval = " + ParseStrings[7] +
                        "\n pos message according distance interval = " + ParseStrings[8] +
                        "\n status message duration time interval on sleep = " + ParseStrings[9] +
                        "\n Logger Counter = " + ParseStrings[10] +
                        "\n Tilt angle= " + ParseStrings[11] +
                        "\n Tilt sensitivity = " + ParseStrings[12] +
                        "\n Tilt Constant = " + ParseStrings[13] +
                        "\n TOW angle  = " + ParseStrings[14] +
                        "\n TOW sensitivity = " + ParseStrings[15] +
                        "\n TOW Constant = " + ParseStrings[16] +
                        "\n Anti Jamming detection = " + ParseStrings[17] +
                        "\n Anti Jamming configuration = " + ParseStrings[18] +
                        "\n GPRS reconnection = " + ParseStrings[19] +
                        "\n Satellite type = " + ParseStrings[20];

                    //LogIWatcher.LogMessage(Color.Blue, Color.White, PositionString, New_Line = true, Show_Time = false);
                }
            }
            else
                        if (Key[0] == "GETCONFIG2?")
            {
                if (IwatcherPrint == true)
                {
                    //LogIWatcher.LogMessage(Color.Brown, Color.White, "Source: " + i_SourceMessage.ToString(), New_Line = false, Show_Time = true);
                    //if (i_Contact != null)
                    //{
                    //    LogIWatcher.LogMessage(Color.DarkBlue, Color.White, "\nName: " + i_Contact.Name, New_Line = false, Show_Time = false);
                    //}
                    //else
                    //{
                    //    LogIWatcher.LogMessage(Color.DarkBlue, Color.White, "\nName: ", New_Line = false, Show_Time = false);
                    //}
                    //LogIWatcher.LogMessage(Color.DarkOrange, Color.White, "\nGETCONFIG2 Message Received: ", New_Line = false, Show_Time = false);

                    //  , , , ,  fota access point name, N/A ,software version, GPS num of used satellites,GPS last timestamp,;

                    string PositionString =
                        "\n UNIT ID = " + ParseStrings[0].Replace(";", "") +
                        "\n password = " + ParseStrings[2] +
                        "\n primary host address + port = " + ParseStrings[3] +
                        "\n primary access point name = " + ParseStrings[4] +
                        "\n fota host address + port = " + ParseStrings[5] +
                        "\n fota access point name = " + ParseStrings[6] +
                        "\n software version = " + ParseStrings[7] +
                        "\n GPS num of used satellites = " + ParseStrings[8] +
                        "\n GPS last timestamp  = " + ParseStrings[9];

                    //LogIWatcher.LogMessage(Color.Brown, Color.White, PositionString, New_Line = true, Show_Time = false);
                }
            }
        }
        private static Mutex mutexACKSMSReceived = new Mutex();

        void ParseSerialPortSMSString(string IncomingString)
        {
            Boolean ret;
            try
            {
                IncomingString = IncomingString.Replace(System.Environment.NewLine, "");
                ret = ParseSMSCommand(IncomingString);
            }
            catch (Exception ex)
            {
                LogSMS.LogMessage(Color.Red, Color.LightGray, ex.ToString(), New_Line = true, Show_Time = true);
                //    return;
            }
        }

        void ParseSerialPortString(string IncomingString)
        {
            // Boolean ret;
            try
            {
                ParseUnitVersion(IncomingString.Replace(System.Environment.NewLine, " "));
                IncomingString = IncomingString.Replace(System.Environment.NewLine, "");
                ParseConfigCommand(IncomingString);
                //ret = ParseSMSCommand(IncomingString);

                ParseStatuPos(IncomingString, SourceMessage.SerialPort, null);

                // ParseUnitVersion(IncomingString);





            }
            catch (Exception ex)
            {
                SerialPortLogger.LogMessage(Color.Red, Color.LightGray, ex.ToString(), New_Line = true, Show_Time = true);
                //    return;
            }
        }

        Boolean ParseSMSCommand(string IncomingString)
        {
            Boolean ret = false;
            Boolean IsCommandFound = true;
            while (IsCommandFound == true)
            {

                int StartCommand = IncomingString.IndexOf("{COMMAND_SMS_START}");
                int EndCommand = IncomingString.IndexOf("{COMMAND_SMS_END}");
                if (StartCommand >= 0 && EndCommand >= 0 && (EndCommand > StartCommand))
                {
                    ret = true;
                    StartCommand += "{COMMAND_SMS_START}".Length;
                    string CommandString = IncomingString.Substring(StartCommand, EndCommand - StartCommand);

                    //       LogSMS.LogMessage(Color.Cyan, Color.White, CommandString, New_Line = true, Show_Time = true);

                    EndCommand += "{COMMAND_SMS_END}".Length;
                    IncomingString = IncomingString.Substring(EndCommand);
                    IsCommandFound = true;

                    ModemStatus mdmStat = new ModemStatus(ref CommandString);

                    if (mdmStat.Valid == true)
                    {
                        richTextBox_ModemStatus.Invoke(new EventHandler(delegate
                        {
                            TimerClearModemStatus = 0;
                            if ((mdmStat.ModemRegistrationStatus == "1" || mdmStat.ModemRegistrationStatus == "5") && mdmStat.SIMStatus == "1")
                            {
                                richTextBox_ModemStatus.BackColor = Color.LightGreen;
                            }
                            else
                            {
                                richTextBox_ModemStatus.BackColor = Color.Red;
                            }

                            richTextBox_ModemStatus.Text =
                                  " Modem Registered: " + mdmStat.ModemRegistrationStatus +
                                "\n Sim: " + mdmStat.SIMStatus +
                                "\n Modem RSSI: " + mdmStat.RSSI +
                                "\n Operator Name: " + mdmStat.Operator +
                                "\n Modem IMEI: " + mdmStat.ModemIMEI +
                                "\n Sim IMSI: " + mdmStat.SimIMSI +
                                "\n Modem Update Counter: " + mdmStat.ModemEUpdateCounter;
                        }));

                    }

                    if (CommandString.Contains("SMS was Send To the Modem"))
                    {
                        mutexACKSMSReceived.WaitOne();
                        //   ACKSMSReceived = true;
                        mutexACKSMSReceived.ReleaseMutex();

                        LogSMS.LogMessage(Color.DarkBlue, Color.White, "SMS Send ACK received", New_Line = true, Show_Time = true);

                        if (checkBox_SMSencrypted.Checked == true)
                        {
                            string[] temp = CommandString.Split('[', ']');
                            LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                            LogSMS.LogMessage(Color.Green, Color.White, "Encrypted SMS (Copy to server Tab):\n" + temp[5], New_Line = true, Show_Time = false);

                            txtDataTx.Invoke(new EventHandler(delegate
                            {
                                txtDataTx.Text = temp[5];
                            }));

                        }
                    }
                    else
                    if (CommandString.Contains("Modem ring to Contact."))
                    {
                        string[] temp = CommandString.Split('[', ']');
                        LogSMS.LogMessage(Color.DarkBlue, Color.White, "Ring to contact, Phone Number: " + temp[3] + " Hangout: " + temp[5], New_Line = true, Show_Time = true);

                    }

                    if (CommandString.Contains("SMS_received Decrypted"))
                    {
                        string[] strsplit = CommandString.Split('[', ']');


                        ParseSMSText(strsplit[1], strsplit[3], Color.Brown);
                    }
                    else
                        if (CommandString.Contains("SMS_received"))
                    {
                        string[] strsplit = CommandString.Split('[', ']');


                        ParseSMSText(strsplit[1], strsplit[3], Color.Blue);
                    }
                }
                else
                {
                    IsCommandFound = false;
                }
            }

            return ret;
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        void ParseSMSText(string i_Subscriber, string i_SMSText, Color i_ColorDisplay)
        {
            i_Subscriber = i_Subscriber.Replace("\"", "");
            PhoneBookContact ContactFound = MyPhoneBook.IsNumberExist(i_Subscriber);

            string[] ParseStrings = { "" };
            string ReceivedUnitID = String.Empty;
            try
            {
                if (i_SMSText.Contains(","))
                {
                    ParseStrings = i_SMSText.Split(',');
                    ReceivedUnitID = ParseStrings[0].Replace(";", "");
                }
            }
            catch (Exception ex)
            {
                LogSMS.LogMessage(Color.Black, Color.White, ex.ToString(), New_Line = true, Show_Time = true);
                //return;
            }



            if (ContactFound != null)
            {
                LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                LogSMS.LogMessage(i_ColorDisplay, Color.White, "\n SMS Received: ", New_Line = false, Show_Time = false);
                LogSMS.LogMessage(Color.DarkBlue, Color.Yellow, "\n Contact:  " + ContactFound.ToString(), New_Line = false, Show_Time = false);
                LogSMS.LogMessage(i_ColorDisplay, Color.White, "\n Text:  " + i_SMSText, New_Line = true, Show_Time = false);

                if (ReceivedUnitID != String.Empty)
                {
                    if (IsDigitsOnly(ReceivedUnitID))
                    {
                        if (ContactFound.UnitID != ReceivedUnitID)
                        {
                            ContactFound.UnitID = ReceivedUnitID;

                            UpdateDefaultsContacts();

                            UpdatePhoneBook();
                        }
                    }
                }
            }
            else
            {
                LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                LogSMS.LogMessage(i_ColorDisplay, Color.White, "SMS Received: " + "\n Number:  " + i_Subscriber + "\n Text:  " + i_SMSText, New_Line = true, Show_Time = false);



                PhoneBookContact NewContact = new PhoneBookContact();
                NewContact.Name = "";            //values preserved after close
                NewContact.Phone = i_Subscriber;
                NewContact.Notes = "";

                if (ReceivedUnitID != String.Empty)
                {
                    if (IsDigitsOnly(ReceivedUnitID))
                    {
                        NewContact.UnitID = ReceivedUnitID;
                    }
                }
                //Do something here with these values

                MyPhoneBook.AddContactToPhoneBook(NewContact);

                UpdateDefaultsContacts();

                UpdatePhoneBook();

            }



            ParseStatuPos(i_SMSText, SourceMessage.SMS, ContactFound);



        }
        string UnitVersion;
        void ParseUnitVersion(string IncomingString)
        {
            if (IncomingString.Contains("******START******") == true)
            {
                int StartConfig = IncomingString.IndexOf("******START******");
                StartConfig += "******START******".Length;
                UnitVersion = IncomingString.Substring(StartConfig);
                int EndConfig = UnitVersion.IndexOf("*********************");
                UnitVersion = UnitVersion.Substring(0, EndConfig);


                textBox_UnitVersion_Text(UnitVersion, Color.LightGreen);

            }

        }

        void ParseConfigCommand(string IncomingString)
        {
            int StartConfig = IncomingString.IndexOf("{CONFIG_START}");
            int EndConfig = IncomingString.IndexOf("{CONFIG_END}");
            if (StartConfig >= 0 && EndConfig > 0 && (EndConfig > StartConfig))
            {
                StartConfig += "{CONFIG_START}".Length;
                string ConfigString = IncomingString.Substring(StartConfig, EndConfig - StartConfig);

                if (ConfigString.Contains("CONFIGOK"))
                {
                    textBox_GenerateConfigFile_Text("CONFIG OK Received", Color.LightGreen);
                }
                else
                {
                    SendToConfigPage(ConfigString, "Serial Port");
                }
            }
        }

        void Serial_TerminalDataLost(byte[] i_data)
        {

            ServerLogger.LogMessage(Color.Orange, Color.White, "[SerialPort]: Some Data Have been lost. ", New_Line = false, Show_Time = true);
            ServerLogger.LogMessage(Color.Black, Color.White, " Length: ", New_Line = false, Show_Time = false);
            ServerLogger.LogMessage(Color.DarkGray, Color.White, i_data.Length.ToString(), New_Line = false, Show_Time = false);
            ServerLogger.LogMessage(Color.Black, Color.White, " DATA: ", New_Line = false, Show_Time = false);
            ServerLogger.LogMessage(Color.DarkGray, Color.White, ByteArrayToHexString(i_data), New_Line = true, Show_Time = false);
        }

        private void button_StopPeriodaclly_Click(object sender, EventArgs e)
        {
            //timer_General_TranssmitionPeriodicallyEnable = false;

            //textBox_SendMessageNumOfTimes.Enabled = true;
            //button_SendPeriodaclly.Enabled = true;
            //textBox_SendMessageIntervalTime.Enabled = true;


        }

        private DateTime RetrieveLinkerTimestamp()
        {
            string filePath = System.Reflection.Assembly.GetCallingAssembly().Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;
            byte[] b = new byte[2048];
            System.IO.Stream s = null;

            try
            {
                s = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                s.Read(b, 0, 2048);
            }
            finally
            {
                if (s != null)
                {
                    s.Close();
                }
            }

            int i = System.BitConverter.ToInt32(b, c_PeHeaderOffset);
            int secondsSince1970 = System.BitConverter.ToInt32(b, i + c_LinkerTimestampOffset);
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
            dt = dt.AddSeconds(secondsSince1970);
            dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
            return dt;
        }


        private void button_SetTimedOut_Click(object sender, EventArgs e)
        {

            try
            {
                int Timeoutvalue = int.Parse(textBox_ConnectionTimedOut.Text);

                //if(m_Server != null)
                //{
                //     m_Server.SetTimeoutinSeconds = Timeoutvalue * 10;
                //}
                TimeOutKeepAlivein100ms = Timeoutvalue * 10;
                GetDataIntervalCounter = 0;


            }
            catch
            {
                textBox_ConnectionTimedOut.Text = "300";
            }
        }

        //  static int LastNumOfConnections = 0;
        private void textBox_NumberOfOpenConnections_TextChanged(object sender, EventArgs e)
        {

            if (m_Server != null)
            {

                if (m_Server.NumberOfOpenConnections > 1)
                {
                    // IsTimedOutTimerEnabled = true;
                    textBox_NumberOfOpenConnections.BackColor = Color.Orange;
                    //ListenBox.BackColor = Color.Green;

                    ServerLogger.LogMessage(Color.Orange, Color.White, "Num Of Connections is bigger than one, " + m_Server.NumberOfOpenConnections, true, true);

                }
                else
                    if (m_Server.NumberOfOpenConnections == 1)
                {
                    //IsTimedOutTimerEnabled = true;
                    //ListenBox.BackColor = Color.Green;
                    textBox_NumberOfOpenConnections.BackColor = Color.Green;
                }
                else
                {
                    // IsTimedOutTimerEnabled = false;
                    textBox_NumberOfOpenConnections.BackColor = default(Color);
                }

                GetDataIntervalCounter = 0;


                //if (LastNumOfConnections > m_Server.NumberOfOpenConnections)
                //{
                //    //ListenBox.BackColor = Color.Yellow;
                //}

                // LastNumOfConnections = m_Server.NumberOfOpenConnections;
            }

        }

        private void button_AddDendSingleCommand_Click(object sender, EventArgs e)
        {
            try
            {
                //textBox_AddSendSingleCommand.Text = CommandsDescription[comboBox_AddSendSingleCommand.SelectedIndex].Format;
            }
            catch
            {
            }
        }

        private void comboBox_AddSendSingleCommand_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  textBox_AddSendSingleCommand.Text = comboBox_AddSendSingleCommand.Text;
            //textBox_ValidCommand.BackColor = default(Color);
            //textBox_ValidCommand.Text = "";
            //richTextBox_CommandDescription.Text = "";

            //Font oldFont = richTextBox_CommandDescription.SelectionFont;

            //richTextBox_CommandDescription.SelectionFont = new Font(richTextBox_CommandDescription.SelectionFont, FontStyle.Bold | FontStyle.Underline);
            //richTextBox_CommandDescription.AppendText("Command Description:");
            //richTextBox_CommandDescription.SelectionFont = oldFont;
            //richTextBox_CommandDescription.AppendText(" " + CommandsDescription[comboBox_AddSendSingleCommand.SelectedIndex].Description + "\n");

            //richTextBox_CommandDescription.SelectionFont = new Font(richTextBox_CommandDescription.SelectionFont, FontStyle.Bold | FontStyle.Underline);
            //richTextBox_CommandDescription.AppendText("Format:");
            //richTextBox_CommandDescription.SelectionFont = oldFont;
            //richTextBox_CommandDescription.AppendText(" " + CommandsDescription[comboBox_AddSendSingleCommand.SelectedIndex].Format +"\n");

            //richTextBox_CommandDescription.SelectionFont = new Font(richTextBox_CommandDescription.SelectionFont, FontStyle.Bold | FontStyle.Underline);
            //richTextBox_CommandDescription.AppendText("Fields Description:");
            //richTextBox_CommandDescription.SelectionFont = oldFont;
            //richTextBox_CommandDescription.AppendText(" " + CommandsDescription[comboBox_AddSendSingleCommand.SelectedIndex].Field_Description + "\n");

        }

        List<string> S1CommandsForConfig = new List<string>();
        private void button_ValidateCommand_Click(object sender, EventArgs e)
        {


            //textBox_ValidCommand.Text = "";
            //textBox_ValidCommand.BackColor = default(Color);


            //string[] Command = textBox_AddSendSingleCommand.Text.Split(',');

            List<string> parms = new List<string>();
            // object[] parameters = new object[6];
            //for (int j = 1; j < Command.Length; j++)
            //{
            //    parms.Add(Command[j]);
            //}
            //object[] parameters = parms.ToArray();


            // Get MethodInfo.
            //Type type = typeof(S1_Protocol.S1_Messege_Builder);
            //MethodInfo info = type.GetMethod(Command[0]);
            //string ret = "";
            //try
            //{
            //    if (info == null)
            //    {
            //        textBox_ValidCommand.AppendText("Gil: Error Command not found  \n\n");
            //        return;
            //    }


            //    ret = (string)info.Invoke(null, parameters);

            //    List<string> S1frameArray = new List<string>();
            //    S1frameArray.Add(ret);

            //    //S1frameArray.Add(S1_Protocol.S1_Messege_Builder.Odomemter_Configuration(Odometer));
            //    bool IsSent = SendS1Message(S1frameArray);

            //    if (IsSent)
            //    {
            //        button_ValidateCommand.Enabled = false;
            //        bw_singleCommand = new BackgroundWorker();

            //        int CommandSentTimeout = int.Parse(textBox_TimeoutForSingleConfiguration.Text);
            //        // this allows our worker to report progress during work
            //        bw_singleCommand.WorkerReportsProgress = true;

            //        // what to do in the background thread
            //        bw_singleCommand.DoWork += new DoWorkEventHandler(
            //                                delegate(object o, DoWorkEventArgs args)
            //                                {
            //                                    textBox_ValidCommand.Invoke(new EventHandler(delegate
            //                                     {
            //                                         textBox_ValidCommand.BackColor = Color.Orange;
            //                                         textBox_ValidCommand.Text = "Sent Waiting for ACK"; ;
            //                                     }));


            //                                    int i = 0;
            //                                    ExitLoopSingleCommand = false;
            //                                    while (i < CommandSentTimeout && ExitLoopSingleCommand == false)
            //                                    {

            //                                        switch (ACKMessageReceived)
            //                                        {
            //                                            case eACKMessageReceived.ACK:

            //                                                textBox_ValidCommand.Invoke(new EventHandler(delegate
            //                                                {
            //                                                    textBox_ValidCommand.BackColor = Color.Green;
            //                                                    textBox_ValidCommand.Text = "Sent and ACK received";


            //                                                }));

            //                                                ExitLoopSingleCommand = true;
            //                                                break;

            //                                            case eACKMessageReceived.NACK:
            //                                                textBox_ValidCommand.Invoke(new EventHandler(delegate
            //                                                {
            //                                                    textBox_ValidCommand.BackColor = Color.Red;
            //                                                    textBox_ValidCommand.Text = "Sent and NACK received";
            //                                                }));

            //                                                ExitLoopSingleCommand = true;
            //                                                break;

            //                                            case eACKMessageReceived.UNDEFINED:
            //                                                break;

            //                                        }

            //                                        Thread.Sleep(1000);
            //                                        i++;
            //                                       textBox_TimeoutForSingleConfiguration.Invoke(new EventHandler(delegate
            //                                                {
            //                                                    textBox_TimeoutForSingleConfiguration.ReadOnly = true;
            //                                                    textBox_TimeoutForSingleConfiguration.Text = (CommandSentTimeout - i).ToString();
            //                                                }));

            //                                        if (i == CommandSentTimeout)
            //                                        {
            //                                            textBox_ValidCommand.Invoke(new EventHandler(delegate
            //                                            {
            //                                                textBox_ValidCommand.BackColor = Color.Red;
            //                                                textBox_ValidCommand.Text = "Sent TIMEOUT";
            //                                            }));

            //                                            ExitLoopSingleCommand = true;
            //                                        }
            //                                    }

            //                                    textBox_TimeoutForSingleConfiguration.Invoke(new EventHandler(delegate
            //                                    {
            //                                        textBox_TimeoutForSingleConfiguration.ReadOnly = false;
            //                                        textBox_TimeoutForSingleConfiguration.Text = "20";
            //                                        button_ValidateCommand.Enabled = true;
            //                                    }));

            //                                });

            //        bw_singleCommand.RunWorkerAsync();


            //    }
            //else
            //{
            //    textBox_ValidCommand.BackColor = Color.Orange;
            //    textBox_ValidCommand.Text = "Not Sent due to connection";
            //}
            //}
            //catch (System.NullReferenceException)
            //{
            //    textBox_ValidCommand.AppendText("Gil: NullReferenceException \n\n");
            //    textBox_ValidCommand.BackColor = Color.Red;
            //    return;
            //}
            //catch (Exception ex)
            //{
            //    try
            //    {
            //        textBox_ValidCommand.AppendText(ex.InnerException.Message + "\n\n");
            //        textBox_ValidCommand.BackColor = Color.Red;
            //        return;
            //    }
            //    catch
            //    {
            //        textBox_ValidCommand.AppendText("Gil: Parameters mismatch\n\n");
            //    }
            //}
        }


        private void button6_Click(object sender, EventArgs e)
        {
            //button_ValidateCommand.Enabled = true;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //Config_Sys.Enabled = true;
            ConfigProcessExit = true;
        }

        //private void button_clearTextBox_S1Commands_Click(object sender, EventArgs e)
        //{
        //    TextBox_S1Commands.Invoke(new EventHandler(delegate
        //    {
        //        TextBox_S1Commands.Text = "";
        //    }));
        //}

        //private void comboBox_SendThrough_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    switch (comboBox_SendThrough.SelectedIndex)
        //    {
        //        case (int)eComSource.GPRS:
        //                                      groupBox_ServerSettings.Visible = true;
        //                                      gbPortSettings.Visible = false;
        //                                      groupBox_PhoneNumber.Visible = false;
        //            break;
        //        case (int)eComSource.SerialPort:
        //                                      groupBox_ServerSettings.Visible = false;
        //                                      gbPortSettings.Visible = true;
        //                                      groupBox_PhoneNumber.Visible = false;
        //            break;
        //        case (int)eComSource.SMS:
        //                                     groupBox_ServerSettings.Visible = false;
        //                                     gbPortSettings.Visible = true;
        //                                     groupBox_PhoneNumber.Visible = true;
        //            break;
        //    }
        //}


        //void PauseTrace()
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        Thread.Sleep(200);
        //        byte[] Pause = new byte[1];
        //        Pause[0] = 1;
        //        byte[] SSP_DataToSendPause = SSP_Protocol.SSP_Protocol.SSPPacket_Encoder(SSP_Protocol.eMessegeType.TRACE, Pause);
        //        SerialPortSendSSPData(SSP_DataToSendPause);
        //    }

        //}

        //void ResumeTrace()
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        Thread.Sleep(200);
        //        byte[] Pause = new byte[1];
        //        Pause[0] = 0;
        //        byte[] SSP_DataToSendPause = SSP_Protocol.SSP_Protocol.SSPPacket_Encoder(SSP_Protocol.eMessegeType.TRACE, Pause);
        //        SerialPortSendSSPData(SSP_DataToSendPause);
        //    }
        //}
        //private void button31_Click(object sender, EventArgs e)
        //{
        //    PauseTrace();
        //}

        //private void button32_Click_1(object sender, EventArgs e)
        //{
        //    ResumeTrace();
        //}

        private void checkBox_EchoResponse_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        BinaryReader m_BinaryReader;
        Dictionary<int, string> FOTAData = new Dictionary<int, string>();
        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                ConfigFileName = openFileDialog1.FileName;

                textBox_FOTA.Text = openFileDialog1.FileName;

                try
                {
                    m_BinaryReader = new BinaryReader(File.Open(ConfigFileName, FileMode.Open));

                    int length = (int)m_BinaryReader.BaseStream.Length;
                    textBox_TotalFileLength.Text = length.ToString();
                    textBox_TotalFrames1280Bytes.Text = (Math.Ceiling((decimal)length / 1280)).ToString();

                    textBox_MaximumNumberReceivedRequest.Invoke(new EventHandler(delegate
                    {

                        textBox_MaximumNumberReceivedRequest.Text = "";

                    }));


                    //txtDataTx.Text = ";<1234>STARTFOTA=," + (Math.Ceiling((decimal)length / 1280)).ToString() + "," + length.ToString() + ",;";
                    string StartFota = string.Format(";<{0}>STARTFOTA=,{1},{2},;", "", textBox_TotalFrames1280Bytes.Text, textBox_TotalFileLength.Text);
                    txtDataTx.Text = StartFota;
                    richTextBox_TextSendSMS.Text = StartFota;
                    //AddCommandToCommands(StartFota);

                    FOTAData.Clear();
                    for (int i = 0; i < int.Parse(textBox_TotalFrames1280Bytes.Text); i++)
                    {


                        // int PositionInFile = 1280 * i;
                        //  m_BinaryReader.ReadBytes(PositionInFile);
                        byte[] buffer = new byte[1280];

                        for (int k = 0; k < 1280; k++)
                        {
                            buffer[k] = 0x30;
                        }
                        byte[] temp = m_BinaryReader.ReadBytes(1280);

                        temp.CopyTo(buffer, 0);

                        string str = Encoding.ASCII.GetString(buffer);
                        byte b = CalcCheckSumbuffer(buffer);
                        string SendString = string.Format("@$@FOTAS,{0},{1},{2}", i, Encoding.ASCII.GetString(buffer), CalcCheckSumbuffer(buffer).ToString("x2"));

                        FOTAData[i] = SendString;


                    }

                    m_BinaryReader.Close();




                    button_StartFOTAProcess.Enabled = true;



                }
                catch (Exception ex)
                {
                    ServerLogger.LogMessage(Color.Blue, Color.White, ex.ToString(), New_Line = true, Show_Time = false);
                }

                if (m_BinaryReader != null && ConfigFileName != null)
                {
                    button_StartFOTA.Enabled = true;
                }
                //AllFileLines = File.ReadAllText(ConfigFileName);



            }
        }

        private void textBox_FOTA_TextChanged(object sender, EventArgs e)
        {
            if (textBox_FOTA.Text.Length > 0)
            {
                textBox_FOTA.BackColor = Color.White;
            }
        }

        private void textBox_MaximumNumberReceivedRequest_TextChanged(object sender, EventArgs e)
        {
            if (textBox_MaximumNumberReceivedRequest.Text.Length > 0)
            {
                textBox_MaximumNumberReceivedRequest.BackColor = Color.White;
            }
        }

        private void textBox_TotalFrames256Bytes_TextChanged(object sender, EventArgs e)
        {
            //if (textBox_TotalFrames256Bytes.Text.Length > 0)
            //{
            //    textBox_TotalFrames256Bytes.BackColor = Color.White;
            //}
        }

        private void button33_Click(object sender, EventArgs e)
        {
            //if (textBox_TotalFrames1280Bytes.Text.Length > 0 && textBox_TotalFileLength.Text.Length > 0)
            //{
            //    //txtDataTx.Text = ";<" + Spetrotec.Properties.Settings.Default.SystemPassword + ">STARTFOTA=," + textBox_TotalFrames1280Bytes.Text + "," + textBox_TotalFileLength.Text + ",;";
            //    txtDataTx.Text = string.Format(";<{0}>STARTFOTA=,{1},{2},;", Spetrotec.Properties.Settings.Default.SystemPassword, textBox_TotalFrames1280Bytes.Text, textBox_TotalFileLength.Text);           
            //}


            ServerLogger.LogMessage(Color.Blue, Color.White, "****************** System ID's Status ****************** ", New_Line = true, Show_Time = true);
            foreach (var pair in IDToFOTA_Status)
            {
                ServerLogger.LogMessage(Color.Blue, Color.White, pair.Key + "   " + pair.Value + " \n", New_Line = false, Show_Time = false);

            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            //textBox_MaximumNumberReceivedRequest.Text = "";
            IDToFOTA_Status.Clear();
            PrintFotaIDStatus();
            //textBox_FOTAEnd.BackColor = default(Color);
            //textBox_FOTAEnd.Text = "";
        }

        private void button34_Click(object sender, EventArgs e)
        {
            int NumOfSendingPackets = 0, NumOfMissingPackets = 0;
            string[] StringSplt = textBox_MaximumNumberReceivedRequest.Text.Split(',');
            try
            {
                int NumOfPacketes = int.Parse(textBox_TotalFrames1280Bytes.Text);

                ServerLogger.LogMessage(Color.Blue, Color.White, "****************** Packets Reusults Which Didn't Found ****************** ", New_Line = true, Show_Time = true);
                for (int i = 0; i < NumOfPacketes; i++)
                {
                    bool found = false;
                    foreach (string str in StringSplt)
                    {
                        try
                        {
                            int PacketNum = int.Parse(str);
                            if (i == 0)
                            {
                                NumOfSendingPackets++;
                            }
                            if (i == PacketNum)
                            {
                                found = true;
                            }
                        }
                        catch
                        {
                        }
                    }
                    if (found == true)
                    {
                        //   ServerLogger.LogMessage(Color.Blue, Color.White,  i + " X ", New_Line = true, Show_Time = false);
                    }
                    else
                    {
                        NumOfMissingPackets++;
                        ServerLogger.LogMessage(Color.Blue, Color.White, i + ",  ", New_Line = false, Show_Time = false);
                    }
                }
                ServerLogger.LogMessage(Color.Blue, Color.White, "\n\nTotal Packets: " + NumOfPacketes + ", ToTal Sending Packets: " + NumOfSendingPackets + ", ToTal Missing Packets: " + NumOfMissingPackets, New_Line = true, Show_Time = false);
                ServerLogger.LogMessage(Color.Blue, Color.White, "****************** Packets Reusults End ****************** ", New_Line = true, Show_Time = true);
            }
            catch (Exception ex)
            {
                ServerLogger.LogMessage(Color.Orange, Color.White, ex.ToString(), true, true);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void UpdateSerialPortHistory(string i_SendString)
        {
            Boolean Found = false;

            foreach (string str in Spetrotec.Properties.Settings.Default.SerialPort_History)
            {
                //comboBox_SerialPortHistory.Items.Add((object)str);
                // comboBox_SMSCommands.Items.Add(str);
                if (str == i_SendString)
                {
                    Found = true;
                }
            }

            if (Found == false)
            {
                Spetrotec.Properties.Settings.Default.SerialPort_History.Add(i_SendString);
                Spetrotec.Properties.Settings.Default.Save();
            }
        }

        void UpdateSerialPortComboBox()
        {
            if (Spetrotec.Properties.Settings.Default.SerialPort_History != null)
            {
                comboBox_SerialPortHistory.Items.Clear();
                foreach (string str in Spetrotec.Properties.Settings.Default.SerialPort_History)
                {
                    comboBox_SerialPortHistory.Items.Add((object)str);
                    // comboBox_SMSCommands.Items.Add(str);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            String tempStr = textBox_SendSerialPort.Text.Replace("\\n", "\n");
            tempStr = tempStr.Replace("\\r", "\r");
            byte[] buffer = Encoding.ASCII.GetBytes(tempStr);

            bool IsSent = SerialPortSendData(buffer);

            if (IsSent == true)
            {
                UpdateSerialPortHistory(textBox_SendSerialPort.Text);

                UpdateSerialPortComboBox();

                if (checkBox_DeleteCommand.Checked == true)
                {
                    textBox_SendSerialPort.Text = "";
                }

            }


        }

        private void button29_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_GenerateConfigFile_Clear();
                bool IsAllGreen = CheckAllTextboxConfig();

                if (IsAllGreen == false)
                {
                    //textBox_GenerateConfigFile.Text = " Some Of filds are Red!!!";
                    //textBox_GenerateConfigFile.BackColor = Color.Red;
                    return;
                }
                else
                {
                    //textBox_GenerateConfigFile.BackColor = Color.LightGreen;
                }

                string UnitID = textBox_ConfigUnitID.Text;

                string Config_file_name = "Config_Date-" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_UnitID-" + UnitID + ".txt";

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "Text Files | *.txt";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File.Delete(saveFileDialog1.FileName);
                    using (StreamWriter sw = File.AppendText(saveFileDialog1.FileName))
                    {
                        //List<S1_Protocol.S1_Messege_Builder.Command_Description> ret = S1_Protocol.S1_Messege_Builder.NonCommand_GetALLconfigCommandsDescription();

                        sw.WriteLine("// " + "Date: " + DateTime.Now.ToString() + "  Unit ID: " + UnitID);
                        sw.WriteLine();
                        sw.WriteLine();

                        string SendStr = GenerateConfigCommand();

                        SendStr = SendStr.Replace(";", ",");

                        byte[] buf = Encoding.ASCII.GetBytes(SendStr);
                        int Size = buf.Length;
                        Byte CheckSum = CalcCheckSumbufferSize(buf);


                        SendStr = ";{CONFIG_START}," + SendStr + "," + Size + "," + CheckSum + ",{CONFIG_END};";

                        sw.Write(SendStr);

                    }
                }

                // This text is always added, making the file longer over time 
                // if it is not deleted. 


                //textBox_GenerateConfigFile.BackColor = Color.Green;
                //textBox_GenerateConfigFile.Text = "File has been saved: \n" + saveFileDialog1.FileName ;
                //textBox_GenerateConfigFile.BackColor = Color.LightGreen;
            }
            catch (Exception ex)
            {
                //textBox_GenerateConfigFile.Text = ex.ToString();
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            textBox_SourceConfig_Clear();

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                ConfigFileName = openFileDialog1.FileName;

                textBox_SourceConfig.Text = "File have been chosen: \n" + openFileDialog1.FileName;

                string[] lines = System.IO.File.ReadAllLines(ConfigFileName);

                foreach (string line in lines)
                {
                    if (line.Contains("//") || line == "")
                    {

                    }
                    else
                    {
                        string str;
                        //";{CONFIG_START}," + SendStr + ",{CONFIG_END};";
                        str = line.Replace(";{CONFIG_START},,", "");
                        str = str.Replace(",{CONFIG_END};", "");
                        SendToConfigPage(str, "File");
                    }
                }


            }



            //ParseConfigString(";23421342134,CONFIG=,12321321,434343434,656565656,55554,43434,66665,6565645456,6,6,6,6,6,6,6,6,5,5,5,5,5,5,5,5,5,4,4,4,4,4,4,4,4,4,3,3,3,3,6,6,6,41,3;");

        }

        bool ParseConfigString(string i_Config)
        {
            try
            {

                string[] StringSplit = i_Config.Replace(";", "").Split(',');

                if (StringSplit[0].Length > 17 || StringSplit[0].Length < 12)
                {
                    return false;
                }

                textBox_ConfigUnitID.Invoke(new EventHandler(delegate
                {
                    textBox_ConfigUnitID.Text = StringSplit[0];
                }));

                // Store keys in a List
                List<string> list = new List<string>(Dictionary_ConfigurationTextBoxes.Keys);
                // Loop through list
                int i = 2;
                foreach (string k in list)
                {
                    TextBox temp = Dictionary_ConfigurationTextBoxes[k];

                    temp.Invoke(new EventHandler(delegate
                    {
                        if (i < StringSplit.Length)
                        {
                            temp.Text = StringSplit[i];
                        }
                    }));
                    i++;
                }
                //textBox_Config1.Text = StringSplit[2];
                //textBox_Config2.Text = StringSplit[3];
                //textBox_Config3.Text = StringSplit[4];
                //textBox_Config4.Text = StringSplit[5];
                //textBox_Config5.Text = StringSplit[6];
                //textBox_Config6.Text = StringSplit[7];
                //textBox_Config7.Text = StringSplit[8];
                //textBox_Config8.Text = StringSplit[9];
                //textBox_Config9.Text = StringSplit[10];
                //textBox_Config10.Text = StringSplit[11];
                //textBox_Config11.Text = StringSplit[12];
                //textBox_Config12.Text = StringSplit[13];
                //textBox_Config13.Text = StringSplit[14];
                //textBox_Config14.Text = StringSplit[15];
                //textBox_Config15.Text = StringSplit[16];
                //textBox_Config16.Text = StringSplit[17];
                //textBox_Config17.Text = StringSplit[18];
                //textBox_Config18.Text = StringSplit[19];
                //textBox_Config19.Text = StringSplit[20];
                //textBox_Config20.Text = StringSplit[21];
                //textBox_Config21.Text = StringSplit[22];
                //textBox_Config22.Text = StringSplit[23];
                //textBox_Config23.Text = StringSplit[24];
                //textBox_Config24.Text = StringSplit[25];
                //textBox_Config25.Text = StringSplit[26];
                //textBox_Config26.Text = StringSplit[27];
                //textBox_Config27.Text = StringSplit[28];

                return true;
            }
            catch (Exception ex)
            {
                textBox_SourceConfig.Invoke(new EventHandler(delegate
                {
                    textBox_SourceConfig.Text = ex.ToString();
                    textBox_SourceConfig.BackColor = Color.Red;
                }));


                return false;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click_2(object sender, EventArgs e)
        {
            //   textBox_SendSerialPort.Text = "<1234>READ?,;";
            textBox_SourceConfig_Clear();

            string Sendstr = string.Format(";READ?,;");
            byte[] buffer = Encoding.ASCII.GetBytes(Sendstr);
            bool IsSent = SerialPortSendData(buffer);

            if (IsSent == true)
            {
                textBox_SourceConfig.Text = "Command sent";

            }

        }

        private void textBox_GenerateConfigFile_TextChanged(object sender, EventArgs e)
        {

        }

        //bool IsDigitsOnly(string str)
        //{
        //    foreach (char c in str)
        //    {
        //        if (c < '0' || c > '9')
        //            return false;
        //    }

        //    return true;
        //}

        enum ConfigDataType
        {
            PosPeriod5Sec,
            AutoARM,
            Angel,
            PeriodStatus,
            SpeedLimit,
            Number,
            Float,
            BatLevel,
            JammingSens,
            EveryThing,
            AlarmViaSMS,
            Unit_ID,
            Subscriber,
            Password,
            Boolean,
            IpAddress,
            Port,
            GPRSDisconnectNum,
            GPSType,
            DISARMCODE,
            CutSpeed
        };
        bool CheckSubscriberValid(string i_String, ConfigDataType i_DataType)
        {
            bool ret = false;
            try
            {


                switch (i_DataType)
                {
                    case ConfigDataType.CutSpeed:
                        if (i_String.Length <= 3 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 0 && Num <= 20 || Num == 255)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;
                    case ConfigDataType.DISARMCODE:
                        if (i_String.Length == 4 && (Regex.IsMatch(i_String, @"^[1-5]+$") || Regex.IsMatch(i_String, @"^[0]+$") || i_String == "9999"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;
                    case ConfigDataType.GPSType:
                        if (i_String.Length == 1 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 0 && Num <= 2)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.PosPeriod5Sec:
                        if (i_String.Length < 5 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num > 0)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.AutoARM:
                        if (i_String.Length < 5 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 2 && Num <= 300)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.EveryThing:
                        ret = true;
                        break;

                    case ConfigDataType.PeriodStatus:

                        if (i_String.Length < 5 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 0 && Num <= 96)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.Angel:

                        if (i_String.Length < 5 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 0 && Num <= 360)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.SpeedLimit:


                        if (Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Temp = int.Parse(i_String);

                            int Speed1 = Temp & 0xff;
                            int Speed2 = (Temp >> 8) & 0xff;
                            int Speed3 = (Temp >> 16) & 0xff;

                            if (textBox_SpeedLimit1.Text == "" || textBox_SpeedLimit2.Text == "" || textBox_SpeedLimit3.Text == "")
                            {
                                ret = false;
                            }
                            else
                                if (Speed2 <= Speed1 && Speed2 != 0 && Speed1 != 0)
                            {
                                ret = false;
                            }
                            else
                                if (Speed3 <= Speed2 && Speed3 != 0)
                            {
                                ret = false;
                            }
                            else
                                    if (Speed3 <= Speed1 && Speed3 != 0)
                            {
                                ret = false;
                            }
                            else
                            {
                                ret = true;
                                UpdateSpeedLimitTextBoxs(Speed1, Speed2, Speed3);
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.BatLevel:

                        if (i_String.Length < 3 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Num = int.Parse(i_String);

                            if (Num >= 0 && Num <= 9)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.JammingSens:

                        if (i_String.Length < 3 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            int Jamming = int.Parse(i_String);

                            if (Jamming >= 20 && Jamming <= 70)
                            {
                                ret = true;
                            }
                            else
                            {
                                ret = false;
                            }
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.Float:
                        float f;

                        if (float.TryParse(i_String, out f))
                        {

                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }



                        break;

                    case ConfigDataType.Number:
                        if (Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;
                    case ConfigDataType.GPRSDisconnectNum:
                        if (i_String.Length < 6 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;
                    case ConfigDataType.Port:
                        if (i_String.Length < 6 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.AlarmViaSMS:
                        if (i_String.Length < 8 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            ret = true;
                            UpdateAlarmCheckBoxes(int.Parse(i_String));
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.IpAddress:
                        //                IPAddress address;
                        //if (IPAddress.TryParse(i_String, out address))
                        if (i_String.Length > 4)
                        {
                            //Valid IP, with address containing the IP
                            ret = true;
                        }
                        else
                        {
                            //Invalid IP
                            ret = false;
                        }
                        break;
                    case ConfigDataType.Subscriber:
                        if (i_String == "0")
                        {
                            ret = true;
                        }
                        else
                        if (i_String.Length < 6)
                        {
                            ret = false;
                        }
                        else
                            if (i_String.Length < 20 && (i_String.StartsWith("+") || i_String.StartsWith("00")) && Regex.IsMatch(i_String.Substring(1), @"^[0-9]+$"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.Password:

                        if (i_String.Length < 15)
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.Boolean:
                        if (i_String == "0" || i_String == "1")
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    case ConfigDataType.Unit_ID:
                        if (i_String.Length > 14 && i_String.Length < 17 && Regex.IsMatch(i_String, @"^[0-9]+$"))
                        {
                            ret = true;
                        }
                        else
                        {
                            ret = false;
                        }
                        break;

                    default:
                        ret = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                textBox_GenerateConfigFile_Text(ex.ToString(), Color.Red);
                ret = false;
            }

            return ret;
        }

        bool CheckAllTextboxConfig()
        {
            if (textBox_ConfigUnitID.BackColor == Color.Red)
            {

                return false;
            }
            List<string> list = new List<string>(Dictionary_ConfigurationTextBoxes.Keys);
            // Loop through list
            //bool IsAllGreen = true;
            foreach (string k in list)
            {
                TextBox temp = Dictionary_ConfigurationTextBoxes[k];
                if (temp.BackColor == Color.Red && temp.Visible == true)
                {
                    return false;
                }
            }

            return true;
        }

        private void textBox_Config1_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Subscriber);
        }

        private void textBox_Config2_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Subscriber);
        }

        private void textBox_Config3_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Subscriber);
        }

        void CheckConfigTextboxValidData(TextBox i_TextBox, ConfigDataType i_ConfigDataType)
        {

            i_TextBox.Invoke(new EventHandler(delegate
            {
                if (i_TextBox.Text == "" || i_TextBox.Text == "@%@")
                {
                    i_TextBox.Text = "";
                    i_TextBox.BackColor = default(Color);
                }
                else
                    if (CheckSubscriberValid(i_TextBox.Text, i_ConfigDataType) == true)
                {
                    i_TextBox.BackColor = Color.LightGreen;
                }
                else
                {
                    //  i_TextBox.Visible = true;
                    i_TextBox.BackColor = Color.Red;
                }
            }));
        }

        private void textBox_Config4_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Password);
        }

        private void textBox_Config5_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.BatLevel);
        }

        void textBox_SourceConfig_Clear()
        {
            textBox_SourceConfig.BackColor = default(Color);
            textBox_SourceConfig.Text = "";
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            //   textBox_SendSerialPort.Text = "<1234>READ?,;"

            textBox_SourceConfig_Clear();

            using (var form = new System_Password())
            {
                form.Load += new EventHandler(Password_form_Load);
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.Password;            //values preserved after close
                                                           //Do something here with these values

                    //      Spetrotec.Properties.Settings.Default.SystemPassword = val;

                    Spetrotec.Properties.Settings.Default.Save();

                    string Sendstr = string.Format("<{0}>READ?,;", val);


                    if (form.ConnectionNumbers.Text == "None")
                    {
                        return;
                    }
                    try
                    {
                        string SendString = Sendstr;
                        Object objData = SendString;
                        byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                        SendDataToServer(form.ConnectionNumbers.SelectedItem.ToString(), byData);

                        textBox_SourceConfig.Text = "Message has been sent";
                        textBox_SourceConfig.BackColor = Color.LightGreen;
                    }
                    catch (Exception ex)
                    {
                        textBox_SourceConfig.Text = ex.ToString();
                        textBox_SourceConfig.BackColor = Color.Red;
                    }



                }
            }


        }

        void Password_form_Load(object sender, EventArgs e)
        {
            System_Password form = (System_Password)sender;
            form.ConnectionNumbers.DataSource = comboBox_ConnectionNumber.DataSource;
            form.PasswordText.Text = "";
        }

        string GenerateConfigCommand()
        {
            string UnitID = textBox_ConfigUnitID.Text;
            if (UnitID == "")
            {
                UnitID = "1111111111111111";
            }
            string SendStr = ";" + UnitID + ",CONFIG=,";
            //sw.Write(";" + UnitID + ",CONFIG=,");
            List<string> list = new List<string>(Dictionary_ConfigurationTextBoxes.Keys);
            // Loop through list

            foreach (string k in list)
            {
                TextBox temp = Dictionary_ConfigurationTextBoxes[k];
                string Field = temp.Text;
                if (Field == "")
                {
                    Field = "@%@";
                }
                SendStr += Field + ",";
            }

            SendStr += ";";

            return SendStr;
        }


        //void CleartextBox_GenerateConfigFile()
        //{
        //    textBox_GenerateConfigFile.Text = "";
        //    textBox_GenerateConfigFile.BackColor = default(Color);
        //}

        private void button28_Click_1(object sender, EventArgs e)
        {
            try
            {
                textBox_GenerateConfigFile_Clear();

                bool IsAllGreen = CheckAllTextboxConfig();

                if (IsAllGreen == false)
                {
                    //textBox_GenerateConfigFile.Text = " Some Of filds are Red!!!";
                    //textBox_GenerateConfigFile.BackColor = Color.Red;
                    return;
                }
                else
                {
                    //textBox_GenerateConfigFile.BackColor = Color.LightGreen;
                }

                string UnitID = textBox_ConfigUnitID.Text;


                using (var form = new System_Password())
                {
                    form.Load += new EventHandler(Password_form_Load);
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string val = form.Password;            //values preserved after close
                        //Do something here with these values

                        string SendStr = GenerateConfigCommand();

                        SendStr = SendStr.Replace(";", ",");

                        SendStr = ";{CONFIG_START}," + SendStr + ",{CONFIG_END};";


                        if (form.ConnectionNumbers.Text == "None")
                        {
                            return;
                        }
                        try
                        {
                            string SendString = SendStr;
                            Object objData = SendString;
                            byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                            SendDataToServer(form.ConnectionNumbers.SelectedItem.ToString(), byData);

                            //textBox_GenerateConfigFile.Text = "Message has been sent";
                            //textBox_GenerateConfigFile.BackColor = Color.LightGreen;
                        }
                        catch (Exception ex)
                        {
                            //textBox_GenerateConfigFile.Text = ex.ToString();
                            //textBox_GenerateConfigFile.BackColor = Color.Red;
                        }



                    }
                }

                //string Config_file_name = "Config_Date-" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_UnitID-" + UnitID + ".txt";


                // This text is always added, making the file longer over time 
                // if it is not deleted. 

                //List<S1_Protocol.S1_Messege_Builder.Command_Description> ret = S1_Protocol.S1_Messege_Builder.NonCommand_GetALLconfigCommandsDescription();




                //textBox_GenerateConfigFile.BackColor = Color.Green;

            }
            catch (Exception ex)
            {
                //textBox_GenerateConfigFile.Text = ex.ToString();
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                textBox_GenerateConfigFile_Clear();
                bool IsAllGreen = CheckAllTextboxConfig();

                if (IsAllGreen == false)
                {
                    //textBox_GenerateConfigFile.Text = " Some Of filds are Red!!!";
                    //textBox_GenerateConfigFile.BackColor = Color.Red;
                    return;
                }
                else
                {

                }

                string UnitID = textBox_ConfigUnitID.Text;

                //string Config_file_name = "Config_Date-" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss") + "_UnitID-" + UnitID + ".txt";


                // This text is always added, making the file longer over time 
                // if it is not deleted. 

                //List<S1_Protocol.S1_Messege_Builder.Command_Description> ret = S1_Protocol.S1_Messege_Builder.NonCommand_GetALLconfigCommandsDescription();

                string SendStr = GenerateConfigCommand();

                SendStr = SendStr.Replace(";", ",");

                byte[] buf = Encoding.ASCII.GetBytes(SendStr);
                int Size = buf.Length;
                Byte CheckSum = CalcCheckSumbufferSize(buf);


                SendStr = ";{CONFIG_START}," + SendStr + "," + Size + "," + CheckSum + ",{CONFIG_END};";
                byte[] buffer = Encoding.ASCII.GetBytes(SendStr);
                bool IsSent = SerialPortSendData(buffer);

                if (IsSent == true)
                {
                    //textBox_GenerateConfigFile.BackColor = Color.Yellow;
                    //textBox_GenerateConfigFile.Text = "Config has been sent";

                }

                //textBox_GenerateConfigFile.BackColor = Color.Green;
                //textBox_GenerateConfigFile.Text = "File " +  + " saved in directory \n" + Directory.GetCurrentDirectory();
            }
            catch (Exception ex)
            {
                //textBox_GenerateConfigFile.Text = ex.ToString();
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            using (var form = new System_Password())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.Password;            //values preserved after close
                    //Do something here with these values

                    //for example
                    this.textBox_SourceConfig.Text = val;
                }
            }
        }

        //textBox_UnitVersion
        void textBox_UnitVersion_Text(string i_Text, Color i_BackColor)
        {
            textBox_UnitVersion.Invoke(new EventHandler(delegate
            {
                textBox_UnitVersion.Text = i_Text;
                textBox_UnitVersion.BackColor = i_BackColor;
            }));
        }

        void textBox_GenerateConfigFile_Text(string i_Text, Color i_BackColor)
        {
            //textBox_GenerateConfigFile.Invoke(new EventHandler(delegate
            //{
            //    textBox_GenerateConfigFile.Text = i_Text;
            //    textBox_GenerateConfigFile.BackColor = i_BackColor;
            //}));
        }

        void textBox_GenerateConfigFile_Clear()
        {
            //textBox_GenerateConfigFile.Invoke(new EventHandler(delegate
            //    {
            //        textBox_GenerateConfigFile.Text = "";
            //        textBox_GenerateConfigFile.BackColor = default(Color);
            //    }));
        }

        void UpdateSpeedLimitTextBoxs(int i_SpeedLimit1, int i_SpeedLimit2, int i_SpeedLimit3)
        {
            textBox_SpeedLimit1.Text = i_SpeedLimit1.ToString();
            textBox_SpeedLimit2.Text = i_SpeedLimit2.ToString();
            textBox_SpeedLimit3.Text = i_SpeedLimit3.ToString();
        }

        private void button30_Click_1(object sender, EventArgs e)
        {
            textBox_ConfigUnitID.Invoke(new EventHandler(delegate
                {
                    textBox_SourceConfig_Clear();
                    textBox_GenerateConfigFile_Clear();
                    textBox_ConfigUnitID.Text = "";
                    textBox_UnitVersion_Text("", default(Color));

                    UpdateAlarmCheckBoxes(0);
                    UpdateSpeedLimitTextBoxs(0, 0, 0);
                    List<string> list = new List<string>(Dictionary_ConfigurationTextBoxes.Keys);
                    // Loop through list

                    foreach (string k in list)
                    {
                        TextBox temp = Dictionary_ConfigurationTextBoxes[k];
                        temp.BackColor = default(Color);
                        temp.Text = "";
                    }


                }));
        }

        private void textBox_ConfigUnitID_TextChanged(object sender, EventArgs e)
        {
            textBox_ConfigUnitID.Invoke(new EventHandler(delegate
            {
                if (textBox_ConfigUnitID.Text == "")
                {
                    textBox_ConfigUnitID.BackColor = default(Color);
                }
                else
                    if (CheckSubscriberValid(textBox_ConfigUnitID.Text, ConfigDataType.Unit_ID) == true)
                {
                    textBox_ConfigUnitID.BackColor = Color.LightGreen;
                }
                else
                {
                    textBox_ConfigUnitID.BackColor = Color.Red;
                }

                //CheckAllTextboxConfig();

            }));
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //List<string> list = new List<string>(Dictionary_ConfigurationTextBoxes.Keys);
            //// Loop through list

            //foreach (string k in list)
            //{
            //    TextBox temp = Dictionary_ConfigurationTextBoxes[k];
            //    temp.Visible = true;
            //}

            switch (comboBox_SystemConfigType.SelectedIndex)
            {
                // AVL
                case 0:
                    textBox_Config28.Visible = false;
                    label_Config28.Visible = false;
                    textBox_Config29.Visible = false;
                    label_Config29.Visible = false;
                    textBox_Config30.Visible = false;
                    label_Config30.Visible = false;
                    textBox_Config31.Visible = false;
                    label_Config31.Visible = false;
                    textBox_Config33.Visible = false;
                    label_Config33.Visible = false;
                    textBox_Config34.Visible = false;
                    label_Config34.Visible = false;
                    textBox_Config38.Visible = true;
                    label_Config38.Visible = true;
                    textBox_Config39.Visible = false;
                    label_Config39.Visible = false;
                    textBox_Config42.Visible = false;
                    label_Config42.Visible = false;
                    break;
                // AVL CAN
                case 1:
                    textBox_Config28.Visible = true;
                    label_Config28.Visible = true;
                    textBox_Config29.Visible = false;
                    label_Config29.Visible = false;
                    textBox_Config30.Visible = true;
                    label_Config30.Visible = true;
                    label_Config30.Text = "Can message Time";
                    textBox_Config31.Visible = false;
                    label_Config31.Visible = false;
                    textBox_Config33.Visible = false;
                    label_Config33.Visible = false;
                    textBox_Config34.Visible = true;
                    label_Config34.Visible = true;
                    textBox_Config38.Visible = false;
                    label_Config38.Visible = false;
                    textBox_Config39.Visible = false;
                    label_Config39.Visible = false;
                    textBox_Config42.Visible = true;
                    label_Config42.Visible = true;
                    break;
                // Cellular Alarm
                case 2:
                    textBox_Config28.Visible = false;
                    label_Config28.Visible = false;
                    textBox_Config29.Visible = true;
                    label_Config29.Visible = true;
                    textBox_Config30.Visible = true;
                    label_Config30.Visible = true;
                    label_Config30.Text = "Doors filter delay";
                    textBox_Config31.Visible = true;
                    label_Config31.Visible = true;
                    textBox_Config33.Visible = true;
                    label_Config33.Visible = true;
                    textBox_Config34.Visible = true;
                    label_Config34.Visible = true;
                    textBox_Config38.Visible = true;
                    label_Config38.Visible = true;
                    textBox_Config39.Visible = true;
                    label_Config39.Visible = true;
                    textBox_Config42.Visible = false;
                    label_Config42.Visible = false;
                    break;
                default:
                    textBox_Config28.Visible = true;
                    label_Config28.Visible = true;
                    textBox_Config29.Visible = true;
                    label_Config29.Visible = true;
                    textBox_Config30.Visible = true;
                    label_Config30.Visible = true;
                    textBox_Config31.Visible = false;
                    label_Config31.Visible = false;
                    textBox_Config33.Visible = false;
                    label_Config33.Visible = false;
                    textBox_Config34.Visible = false;
                    label_Config34.Visible = false;
                    break;

            }
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void groupBox_LoadedConfig_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void textBox_Config13_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.AlarmViaSMS);

        }

        void UpdateAlarmCheckBoxes(int i_Num)
        {
            try
            {
                int Alarm = i_Num;
                //string result = Convert.ToString(Alarm, 2);

                if ((Alarm & 0x1) > 0)
                {
                    checkBox_config_Bit0.Checked = true;
                }
                else
                {
                    checkBox_config_Bit0.Checked = false;
                }

                if ((Alarm & 0x2) > 0)
                {
                    checkBox_config_Bit1.Checked = true;
                }
                else
                {
                    checkBox_config_Bit1.Checked = false;
                }


                if ((Alarm & 0x4) > 0)
                {
                    checkBox_config_Bit2.Checked = true;
                }
                else
                {
                    checkBox_config_Bit2.Checked = false;
                }


                if ((Alarm & 0x8) > 0)
                {
                    checkBox_config_Bit3.Checked = true;
                }
                else
                {
                    checkBox_config_Bit3.Checked = false;
                }


                if ((Alarm & 0x10) > 0)
                {
                    checkBox_config_Bit4.Checked = true;
                }
                else
                {
                    checkBox_config_Bit4.Checked = false;
                }


                if ((Alarm & 0x20) > 0)
                {
                    checkBox_config_Bit5.Checked = true;
                }
                else
                {
                    checkBox_config_Bit5.Checked = false;
                }


                if ((Alarm & 0x40) > 0)
                {
                    checkBox_config_Bit6.Checked = true;
                }
                else
                {
                    checkBox_config_Bit6.Checked = false;
                }


                if ((Alarm & 0x80) > 0)
                {
                    checkBox_config_Bit7.Checked = true;
                }
                else
                {
                    checkBox_config_Bit7.Checked = false;
                }


                if ((Alarm & 0x100) > 0)
                {
                    checkBox_config_Bit8.Checked = true;
                }
                else
                {
                    checkBox_config_Bit8.Checked = false;
                }


                if ((Alarm & 0x200) > 0)
                {
                    checkBox_config_Bit9.Checked = true;
                }
                else
                {
                    checkBox_config_Bit9.Checked = false;
                }

                if ((Alarm & 0x400) > 0)
                {
                    checkBox_config_Bit10.Checked = true;
                }
                else
                {
                    checkBox_config_Bit10.Checked = false;
                }



            }
            catch (Exception ex)
            {
                textBox_GenerateConfigFile_Text(ex.ToString(), Color.Red);
            }
        }

        private void checkBox_config_Bit0_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        void UpdateTextBox13()
        {
            int AlarmValue = 0;

            if (checkBox_config_Bit0.Checked)
            {
                AlarmValue = AlarmValue | 0x1;
            }

            if (checkBox_config_Bit1.Checked)
            {
                AlarmValue = AlarmValue | 0x2;
            }

            if (checkBox_config_Bit2.Checked)
            {
                AlarmValue = AlarmValue | 0x4;
            }

            if (checkBox_config_Bit3.Checked)
            {
                AlarmValue = AlarmValue | 0x8;
            }

            if (checkBox_config_Bit4.Checked)
            {
                AlarmValue = AlarmValue | 0x10;
            }

            if (checkBox_config_Bit5.Checked)
            {
                AlarmValue = AlarmValue | 0x20;
            }

            if (checkBox_config_Bit6.Checked)
            {
                AlarmValue = AlarmValue | 0x40;
            }

            if (checkBox_config_Bit7.Checked)
            {
                AlarmValue = AlarmValue | 0x80;
            }

            if (checkBox_config_Bit8.Checked)
            {
                AlarmValue = AlarmValue | 0x100;
            }

            if (checkBox_config_Bit9.Checked)
            {
                AlarmValue = AlarmValue | 0x200;
            }

            if (checkBox_config_Bit10.Checked)
            {
                AlarmValue = AlarmValue | 0x400;
            }

            textBox_Config13.Text = AlarmValue.ToString();

        }

        private void checkBox_config_Bit4_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void checkBox_config_Bit5_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void checkBox_config_Bit6_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void checkBox_config_Bit7_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void checkBox_config_Bit8_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void checkBox_config_Bit9_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void checkBox_config_Bit10_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            UpdateTextBox13();
        }

        private void textBox_Config10_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.IpAddress);
        }

        private void textBox_Config11_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.IpAddress);
        }

        private void textBox_Config12_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Port);
        }

        private void textBox_Config24_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);
        }

        private void textBox_Config23_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);
        }

        private void textBox_Config27_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.GPRSDisconnectNum);
        }

        private void textBox_Config9_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.EveryThing);
        }

        private void textBox_Config29_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);
        }

        private void textBox_Config26_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.JammingSens);
        }

        private void textBox_Config6_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Port);
        }

        private void textBox_Config7_TextChanged(object sender, EventArgs e)
        {

            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.SpeedLimit);

            textBox_SpeedLimit1.BackColor = textBox_Config7.BackColor;
            textBox_SpeedLimit2.BackColor = textBox_Config7.BackColor;
            textBox_SpeedLimit3.BackColor = textBox_Config7.BackColor;
            textBox_Config7.Visible = false;

        }

        private void textBox_Config8_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.PeriodStatus);
        }

        private void textBox_Config14_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Angel);
        }

        private void textBox_Config15_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void textBox_Config16_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void textBox_Config17_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Angel);
        }

        private void textBox_Config18_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void textBox_Config19_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void textBox_Config20_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Angel);
        }

        private void textBox_Config21_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void textBox_Config22_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.PosPeriod5Sec);
        }

        private void textBox_Config28_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void textBox_Config30_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        private void textBox_Config25_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Float);
        }

        private void checkBox_RecordGeneral_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button32_Click_1(object sender, EventArgs e)
        {
            groupBox_Configuration.Enabled = !groupBox_Configuration.Enabled;
        }

        private void textBox_IDKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPortNo_TextChanged(object sender, EventArgs e)
        {
            Spetrotec.Properties.Settings.Default.Start_Port = txtPortNo.Text.ToString();

            Spetrotec.Properties.Settings.Default.Save();
        }

        private void button33_Click_1(object sender, EventArgs e)
        {
            using (var form = new AddContact())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {

                    PhoneBookContact NewContact = new PhoneBookContact();
                    NewContact.Name = form.ContactName;            //values preserved after close
                    NewContact.Phone = form.ContactPhone;
                    NewContact.Notes = form.ContactNotes;
                    NewContact.Password = form.ContactPassword;
                    NewContact.UnitID = form.ContactIMEI;
                    //Do something here with these values

                    MyPhoneBook.AddContactToPhoneBook(NewContact);

                    UpdateDefaultsContacts();

                    UpdatePhoneBook();


                }
            }
        }

        bool CheckValidSMS(string i_SMS)
        {
            try
            {
                //;<S1BM>CDC=,1111,;
                if (i_SMS.Contains("CDC"))
                {
                    int CommaIndex = i_SMS.IndexOf(',');
                    string str = i_SMS.Substring(CommaIndex + 1, 4);
                    if (!(str.Length == 4 && (Regex.IsMatch(str, @"^[1-5]+$") || Regex.IsMatch(str, @"^[0]+$"))))
                    {
                        return false;
                    }


                }
                return true;

            }
            catch (Exception ex)
            {
                LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                LogSMS.LogMessage(Color.Red, Color.White, ex.ToString(), New_Line = true, Show_Time = false);

                return false;
            }
        }

        string ReturnCommandWithPassword(string i_Command, PhoneBookContact i_Contact)
        {
            string temp = string.Empty;
            string command = i_Command;
            int endindex = command.IndexOf('>');
            if (endindex >= 0 && checkBox_SendSMSAsIs.Checked == false)
            {
                temp = ";<" + i_Contact.Password + ">" + command.Substring(endindex + 1);
            }
            else
            {
                temp = command;
            }

            return temp;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            groupBox34.Enabled = false;
            foreach (var item in checkedListBox_PhoneBook.CheckedItems)
            {
                if (item != null)
                {
                    string SMSText = ReturnCommandWithPassword(richTextBox_TextSendSMS.Text, (PhoneBookContact)item);
                    SendSMSToContact((PhoneBookContact)item, SMSText);
                }
            }
            //     AddCommandToCommands(richTextBox_TextSendSMS.Text);
            groupBox34.Enabled = true;
        }

        void RemoveSelectedContact()
        {
            try
            {
                int i = checkedListBox_PhoneBook.SelectedIndex;
                MyPhoneBook.RemoveContactFromPhoneBook((PhoneBookContact)checkedListBox_PhoneBook.SelectedItem);

                UpdateDefaultsContacts();

                UpdatePhoneBook();

                if (i < checkedListBox_PhoneBook.Items.Count)
                {
                    checkedListBox_PhoneBook.SelectedIndex = i;
                }
                else
                {
                    checkedListBox_PhoneBook.SelectedIndex = checkedListBox_PhoneBook.Items.Count - 1;
                }
            }
            catch (Exception ex)
            {
                //LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                LogSMS.LogMessage(Color.Red, Color.White, ex.Message, New_Line = true, Show_Time = true);

            }
        }

        private void button_RemoveContact_Click(object sender, EventArgs e)
        {
            RemoveSelectedContact();
        }

        private void button_ExportToXML_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.FileName = "MyContacts";
            saveFileDialog1.Filter = "XML files (*.xml)|*.xml";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    MyPhoneBook.ExportToXML(myStream);
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }







        }

        private void button_ImportToXML_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // Test result.
                {
                    MyPhoneBook.ImportToXML(openFileDialog1.FileName);

                    UpdateDefaultsContacts();

                    UpdatePhoneBook();

                }
            }
            catch (Exception ex)
            {
                //LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                LogSMS.LogMessage(Color.Red, Color.White, ex.Message, New_Line = true, Show_Time = true);

            }

        }

        void AddCommandToCommands(string i_SMSText)
        {
            Boolean IsExist = false;
            foreach (string str in Spetrotec.Properties.Settings.Default.SMS_Commands)
            {
                if (i_SMSText == str)
                {
                    IsExist = true;
                }
            }

            if (IsExist == false)
            {
                if (Spetrotec.Properties.Settings.Default.SMS_Commands.Count >= 100)
                {
                    Spetrotec.Properties.Settings.Default.SMS_Commands.RemoveAt(Spetrotec.Properties.Settings.Default.SMS_Commands.Count - 40);
                }

                Spetrotec.Properties.Settings.Default.SMS_Commands.Add(i_SMSText);
                Spetrotec.Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// 
        /// </summary>
      //  bool ACKSMSReceived = false;
        void SendSMSToContact(PhoneBookContact i_Contact, string i_SMSText)
        {
            // AddCommandToCommands(i_SMSText);
            int PosStr = 0;
            if (i_Contact == null)
            {
                return;
            }

            //i_SMSText = i_SMSText.Replace("\n", string.Empty);
            //i_SMSText = i_SMSText.Replace("\r", string.Empty);
            while (PosStr < i_SMSText.Length)
            {

                string SMSToSend = "";
                int CharsLeft = i_SMSText.Length - PosStr;
                //.SubString( 0, dec.Length > 240 ? 240 : dec.Length )

                if (CharsLeft > 160)
                {
                    SMSToSend = i_SMSText.Substring(PosStr, 160);

                }
                else
                {
                    SMSToSend = i_SMSText.Substring(PosStr, CharsLeft);
                }
                PosStr += 160;

                string StrToSend = "{SMS_SEND}," + i_Contact.Phone + "," + SMSToSend + "\r{SMS_END}";

                StrToSend = ReturnSMSEncryiepted(StrToSend);

                byte[] buffer = Encoding.ASCII.GetBytes(StrToSend);

                bool IsSent = SerialPortSMSSendData(buffer);

                if (IsSent == true)
                {
                    //  mutexACKSMSReceived.WaitOne();
                    //ACKSMSReceived = false;
                    //   ACKSMSReceived = true;
                    //Thread.Sleep(1000);
                    //   mutexACKSMSReceived.ReleaseMutex();

                    //int cnt = 0;
                    //while (ACKSMSReceived == false && cnt < 100)
                    //{
                    //    Thread.Sleep(50);
                    //    cnt++;
                    //}
                    //if (ACKSMSReceived)
                    //{
                    LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                    LogSMS.LogMessage(Color.Green, Color.White, "  SMS was Sent:\n Contact: " + i_Contact.ToString() + "\n Text:  " + SMSToSend, New_Line = true, Show_Time = false);

                    Thread.Sleep(1500);
                    //}
                    //else
                    //{
                    //    LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                    //    LogSMS.LogMessage(Color.Red, Color.White, "  SMS wasn't Sent to " + i_Contact.ToString() + "  Text:  " + SMSToSend, New_Line = true, Show_Time = false);
                    //}

                    //return true;
                }
            }
        }

        //bool ACKSMSReceived = false;
        void RingToContact(PhoneBookContact i_Contact)
        {
            // AddCommandToCommands(i_SMSText);
            //  int PosStr = 0;
            if (i_Contact == null)
            {
                return;
            }



            string StrToSend = "{RING," + i_Contact.Phone + ",}";

            byte[] buffer = Encoding.ASCII.GetBytes(StrToSend);

            bool IsSent = SerialPortSMSSendData(buffer);

            if (IsSent == true)
            {
                //  mutexACKSMSReceived.WaitOne();
                //ACKSMSReceived = false;
                //   ACKSMSReceived = true;
                //Thread.Sleep(1000);
                //   mutexACKSMSReceived.ReleaseMutex();

                //int cnt = 0;
                //while (ACKSMSReceived == false && cnt < 100)
                //{
                //    Thread.Sleep(50);
                //    cnt++;
                //}
                //if (ACKSMSReceived)
                //{
                LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                LogSMS.LogMessage(Color.Green, Color.White, "  Ring to Contact:\n Contact: " + i_Contact.ToString(), New_Line = true, Show_Time = false);

                Thread.Sleep(1500);
                //}
                //else
                //{
                //    LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                //    LogSMS.LogMessage(Color.Red, Color.White, "  SMS wasn't Sent to " + i_Contact.ToString() + "  Text:  " + SMSToSend, New_Line = true, Show_Time = false);
                //}

                //return true;
            }

        }

        string ReturnSMSEncryiepted(string i_SMSText)
        {
            if (checkBox_SMSencrypted.Checked == true)
            {
                return "{ENCRYPED," + textBox_UnitIDForSMS.Text + "," + textBox_CodeArrayForSMS.Text + "," + i_SMSText;
            }
            else
            {
                return i_SMSText;
            }
        }

        private void button_SendSelectedSMS_Click(object sender, EventArgs e)
        {

            if (checkedListBox_PhoneBook.SelectedItem != null)
            {
                groupBox34.Enabled = false;

                string SMSText = ReturnCommandWithPassword(richTextBox_TextSendSMS.Text, (PhoneBookContact)checkedListBox_PhoneBook.SelectedItem);

                if (CheckValidSMS(SMSText))
                {


                    SendSMSToContact((PhoneBookContact)checkedListBox_PhoneBook.SelectedItem, SMSText);
                }
                else
                {
                    LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                    LogSMS.LogMessage(Color.Red, Color.White, "SMS Not Valid", New_Line = true, Show_Time = false);
                }

                // AddCommandToCommands(richTextBox_TextSendSMS.Text);
                groupBox34.Enabled = true;
            }
        }

        private void button33_Click_2(object sender, EventArgs e)
        {
            using (var form = new AddContact())
            {
                PhoneBookContact Contact = (PhoneBookContact)checkedListBox_PhoneBook.SelectedItem;
                form.Load += new EventHandler(form_Load);

                if (Contact != null)
                {
                    form.ContactName = Contact.Name;
                    form.ContactName = Contact.Phone;
                    form.ContactNotes = Contact.Notes;
                    form.ContactPassword = Contact.Password;
                    form.ContactIMEI = Contact.UnitID;

                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Contact.Name = form.ContactName;            //values preserved after close
                        Contact.Phone = form.ContactPhone;
                        Contact.Notes = form.ContactNotes;
                        Contact.Password = form.ContactPassword;
                        Contact.UnitID = form.ContactIMEI;
                        //Do something here with these values

                        //MyPhoneBook.AddContactToPhoneBook(NewContact);

                        UpdateDefaultsContacts();

                        UpdatePhoneBook();


                    }
                }
            }
        }

        void form_Load(object sender, EventArgs e)
        {
            PhoneBookContact Contact = (PhoneBookContact)checkedListBox_PhoneBook.SelectedItem;
            if (Contact != null)
            {
                AddContact form = (AddContact)sender;
                form.TextBoxName = Contact.Name;
                form.TextBoxPhone = Contact.Phone;
                form.TextBoxNotes = Contact.Notes;
                form.TextBoxPassword = Contact.Password;
                form.TextBoxIMEI = Contact.UnitID;
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            richTextBox_ModemStatus.BackColor = default(Color);
            richTextBox_ModemStatus.Text = "";
        }

        private void richTextBox_TextSendSMS_TextChanged(object sender, EventArgs e)
        {
            label_SMSSendCharacters.Text = richTextBox_TextSendSMS.Text.Length.ToString() + "/160 = " + (richTextBox_TextSendSMS.Text.Length / 160 + 1);
            //if (richTextBox_TextSendSMS.Text.Length < 160)
            //{
            //    richTextBox_TextSendSMS.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    richTextBox_TextSendSMS.BackColor = Color.Red;
            //}
        }

        private void button_SMSOpenPort_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Config31_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.AutoARM);
        }

        private void pictureBox_logo_Click(object sender, EventArgs e)
        {

        }

        private void button_SetConfigSMS_Click(object sender, EventArgs e)
        {

        }

        private void button_EndFOTAReset_Click(object sender, EventArgs e)
        {
            if (textBox_TotalFrames1280Bytes.Text.Length > 0 && textBox_TotalFileLength.Text.Length > 0)
            {
                //txtDataTx.Text = ";<1234>ENDFOTA=," + textBox_TotalFrames1280Bytes.Text + "," + textBox_TotalFileLength.Text + ",;";
                txtDataTx.Text = string.Format(";<{0}>ENDFOT=,{1},{2},;", "", textBox_TotalFrames1280Bytes.Text, textBox_TotalFileLength.Text);
            }
        }

        private void textBox_Config32_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.GPSType);
        }

        private void checkBox_S1RecordLog_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button_AddToSendSMS_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox_SMSCommands.SelectedItem != null)
                {
                    richTextBox_TextSendSMS.Text = listBox_SMSCommands.SelectedItem.ToString();
                }

            }
            catch (Exception ex)
            {
                LogSMS.LogMessage(Color.Black, Color.White, ex.ToString(), New_Line = false, Show_Time = true);
            }
        }

        private void textBox_Config33_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.DISARMCODE);
        }

        private void comboBox_SMSCommands_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        private void listBox_SMSCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBox_SMSCommands.SelectedItem != null)
                {

                    richTextBox_TextSendSMS.Text = listBox_SMSCommands.SelectedItem.ToString();
                }

            }
            catch (Exception ex)
            {
                LogSMS.LogMessage(Color.Black, Color.White, ex.ToString(), New_Line = false, Show_Time = true);
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            using (var form = new SMSCommand())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    AddCommandToCommands(form.Command);



                }
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            using (var form = new SMSCommand())
            {
                string Command = (string)listBox_SMSCommands.SelectedItem;
                form.Load += new EventHandler(SMSCommandForm_Load);

                if (Command != null)
                {
                    form.Command = Command;

                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        Command = form.Command;            //values preserved after close

                        Spetrotec.Properties.Settings.Default.SMS_Commands.Remove((string)listBox_SMSCommands.SelectedItem);
                        AddCommandToCommands(Command);

                        SortSMSCommands();


                    }
                }
            }
        }

        void SortSMSCommands()
        {
            ArrayList q = new ArrayList();
            foreach (object o in listBox_SMSCommands.Items)
            {
                q.Add(o);
            }
            q.Sort();
            listBox_SMSCommands.Items.Clear();
            foreach (object o in q)
            {

                listBox_SMSCommands.Items.Add(o);
            }
        }

        void SMSCommandForm_Load(object sender, EventArgs e)
        {
            string Command = (string)listBox_SMSCommands.SelectedItem;
            if (Command != null)
            {
                SMSCommand form = (SMSCommand)sender;
                form.TextBoxCommand = Command;

            }
        }

        void RemoveSelectedCommand()
        {
            try
            {
                int i = listBox_SMSCommands.SelectedIndex;
                //MyPhoneBook.RemoveContactFromPhoneBook((PhoneBookContact)checkedListBox_PhoneBook.SelectedItem);

                listBox_SMSCommands.Items.Remove(listBox_SMSCommands.SelectedItem);

                UpdateDefaultsCommands();

                UpdateSMSCommands();

                if (i < listBox_SMSCommands.Items.Count)
                {
                    listBox_SMSCommands.SelectedIndex = i;
                }
                else
                {
                    listBox_SMSCommands.SelectedIndex = listBox_SMSCommands.Items.Count - 1;
                }
            }
            catch (Exception ex)
            {
                //LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                LogSMS.LogMessage(Color.Red, Color.White, ex.Message, New_Line = true, Show_Time = true);

            }



        }

        private void button40_Click(object sender, EventArgs e)
        {
            RemoveSelectedCommand();

        }

        private void button39_Click_1(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.FileName = "MySMSCommands";
            saveFileDialog1.Filter = "XML files (*.xml)|*.xml";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    List<string> templist = new List<string>();
                    foreach (var item in listBox_SMSCommands.Items)
                    {
                        templist.Add((string)item);
                    }
                    XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                    TextWriter textWriter = new StreamWriter(myStream);

                    serializer.Serialize(textWriter, templist);
                    textWriter.Close();
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1 = new OpenFileDialog();
                DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // Test result.
                {

                    XmlSerializer deserializer = new XmlSerializer(typeof(List<string>));
                    TextReader textReader = new StreamReader(openFileDialog1.FileName);
                    List<string> ImportedCommands;
                    ImportedCommands = (List<string>)deserializer.Deserialize(textReader);
                    textReader.Close();

                    Spetrotec.Properties.Settings.Default.SMS_Commands.Clear();
                    listBox_SMSCommands.Items.Clear();
                    foreach (string str in ImportedCommands)
                    {
                        AddCommandToCommands(str);
                    }
                    UpdateSMSCommands();



                }
            }
            catch (Exception ex)
            {
                //LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                LogSMS.LogMessage(Color.Red, Color.White, ex.Message, New_Line = true, Show_Time = true);

            }
        }





        private void checkedListBox_PhoneBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox_PhoneBook.SelectedItem != null)
            {
                PhoneBookContact contact = (PhoneBookContact)checkedListBox_PhoneBook.SelectedItem;

                richTextBox_ContactDetails.Text = string.Format("Name: \n{0}\n\nPhone: \n{1}\n\nPassword: \n{3}\n\nUnit ID: \n{4}\n\nNotes: \n{2}\n ", contact.Name, contact.Phone, contact.Notes, contact.Password, contact.UnitID);

                textBox_UnitIDForSMS.Text = contact.UnitID;

            }

        }

        private void textBox_Config34_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.GPSType);
        }

        private void button34_Click_1(object sender, EventArgs e)
        {
            string StartFota = string.Format(";<{0}>STARTFOTA=,{1},{2},;", "", textBox_TotalFrames1280Bytes.Text, textBox_TotalFileLength.Text);
            txtDataTx.Text = StartFota;
            richTextBox_TextSendSMS.Text = StartFota;
        }

        private void label_Config12_Click(object sender, EventArgs e)
        {

        }

        private void label_Config32_Click(object sender, EventArgs e)
        {

        }

        private void label_Config31_Click(object sender, EventArgs e)
        {

        }

        private void label_Config11_Click(object sender, EventArgs e)
        {

        }

        private void label_Config3_Click(object sender, EventArgs e)
        {

        }

        private void label_Config28_Click(object sender, EventArgs e)
        {

        }

        private void label_Config29_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void checkBox_OpenPortSMS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_OpenPortSMS.Checked)
            {
                try
                {
                    checkBox_OpenPortSMS.BackColor = Color.Yellow;


                    serialPort_SMS.BaudRate = 38400;
                    serialPort_SMS.DataBits = 8;
                    serialPort_SMS.StopBits = StopBits.One;
                    serialPort_SMS.Parity = Parity.None;
                    serialPort_SMS.PortName = comboBox_ComportSMS.Text;






                    serialPort_SMS.Open();



                    LogSMS.LogMessage(Color.Green, Color.LightGray,
                     " Serial port Opened with  " + " ,PortName = " + serialPort_SMS.PortName
                     + " ,BaudRate = " + serialPort_SMS.BaudRate +
                     " ,DataBits = " + serialPort_SMS.DataBits +
                     " ,StopBits = " + serialPort_SMS.StopBits +
                     " ,Parity = " + serialPort_SMS.Parity,
                     New_Line = true, Show_Time = true);

                    checkBox_OpenPortSMS.BackColor = Color.Green;

                    serialPort_SMS.DataReceived += new SerialDataReceivedEventHandler(serialPort_SMS_DataReceived);

                    comboBox_ComportSMS.Enabled = false;
                }
                catch (Exception ex)
                {
                    checkBox_OpenPortSMS.Checked = false;
                    checkBox_OpenPortSMS.BackColor = default(Color);



                    LogSMS.LogMessage(Color.Red, Color.LightGray, ex.Message.ToString(), New_Line = true, Show_Time = true);
                    return;
                }




            }
            else
            {

                checkBox_OpenPortSMS.BackColor = default(Color);
                //checkBox_ComportOpen.Enabled = false;


                serialPort_SMS.Close();

                comboBox_ComportSMS.Enabled = true;
                //groupBox_ServerSettings.Enabled = true;
            }
        }

        void serialPort_SMS_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // If the com port has been closed, do nothing
            if (!serialPort_SMS.IsOpen) return;

            // This method will be called when there is data waiting in the port's buffer
            Thread.Sleep(300);

            if (!serialPort_SMS.IsOpen) return;

            // Obtain the number of bytes waiting in the port's buffer
            int bytes = serialPort_SMS.BytesToRead;

            // Create a byte array buffer to hold the incoming data
            byte[] buffer = new byte[bytes];

            // Read the data from the port and store it in our buffer
            serialPort_SMS.Read(buffer, 0, bytes);


            string IncomingString = System.Text.Encoding.Default.GetString(buffer);

            if (checkBox_DebugSMS.Checked == true)
            {

                LogSMS.LogMessage(Color.Black, Color.LightGray, "", New_Line = false, Show_Time = true);
                LogSMS.LogMessage(Color.Black, Color.LightGray, IncomingString, New_Line = true, Show_Time = false);
            }


            ParseSerialPortSMSString(IncomingString);
        }

        private void textBox_Config35_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.EveryThing);
        }

        private void textBox_Config36_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.EveryThing);
        }

        private void button_SerialPortAdd_Click(object sender, EventArgs e)
        {
            if (comboBox_SerialPortHistory.SelectedItem != null)
            {
                textBox_SendSerialPort.Text = comboBox_SerialPortHistory.SelectedItem.ToString();
            }
        }

        private void textBox_Config37_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);
        }

        private void textBox_Config38_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);

            if (textBox_Config38.Text == "1")
            {
                //textBox_GenerateConfigFile.Text = "Serial Port Baudrate 9600! ";
                //textBox_GenerateConfigFile.BackColor = Color.Orange;
                textBox_Config33.Text = "9999";
                textBox_Config33.Enabled = false;
            }

            if (textBox_Config38.Text == "0")
            {
                //textBox_GenerateConfigFile.Text = "Serial Port Baudrate 38400!";
                //textBox_GenerateConfigFile.BackColor = Color.Orange;
                textBox_Config33.Enabled = true;
            }
        }

        private void checkBox_SendSMSAsIs_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_SMSencrypted_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_SMSencrypted.Checked == true)
            {
                GrooupBox_Encryption.Enabled = true;
            }
            else
            {
                GrooupBox_Encryption.Enabled = false;
            }
        }

        private void textBox_SpeedLimit1_TextChanged(object sender, EventArgs e)
        {

            SetSpeedThreeSpeedLimit();
        }

        void SetSpeedThreeSpeedLimit()
        {
            int Speed1 = 0, Speed2 = 0, Speed3 = 0;

            Int32.TryParse(textBox_SpeedLimit1.Text, out Speed1);
            Int32.TryParse(textBox_SpeedLimit2.Text, out Speed2);
            Int32.TryParse(textBox_SpeedLimit3.Text, out Speed3);


            int temp = (Speed3 & 0xff) << 16 | (Speed2 & 0xff) << 8 | (Speed1 & 0xff);
            textBox_Config7.Text = "";
            textBox_Config7.Text = temp.ToString();



        }

        private void textBox_SpeedLimit2_TextChanged(object sender, EventArgs e)
        {
            SetSpeedThreeSpeedLimit();
        }

        private void textBox_SpeedLimit3_TextChanged(object sender, EventArgs e)
        {
            SetSpeedThreeSpeedLimit();
        }

        private void label_Config37_Click(object sender, EventArgs e)
        {

        }

        private void label_Config27_Click(object sender, EventArgs e)
        {

        }

        private void label_Config7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox_Configuration_Enter(object sender, EventArgs e)
        {

        }

        private void label_Config1_Click(object sender, EventArgs e)
        {

        }

        private void label_Config2_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Config39_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.GPSType);
        }

        private void button34_Click_2(object sender, EventArgs e)
        {
            SaveCommandsAndContacts();
        }

        private void checkBox_S1Pause_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox33_Enter(object sender, EventArgs e)
        {

        }

        private void richTextBox_ContactDetails_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox39_Enter(object sender, EventArgs e)
        {

        }

        private void textBox_Config40_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.CutSpeed);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Boolean);
        }

        string OpcodeToCompare = "";
        int SendOneTimeFlag = 0;
        private void button_Ring_Click(object sender, EventArgs e)
        {
            if (checkedListBox_PhoneBook.SelectedItem != null
                //           && checkBox_SMSencrypted.Checked == true 
                && listBox_SMSCommands.SelectedItem != null
                && listBox_SMSCommands.SelectedItem != null
                && textBox_UnitIDForSMS.Text.Length >= 10
                //        && textBox_CodeArrayForSMS.Text.Length == 4
                && serialPort_SMS.IsOpen
                && ((checkBox_SMSencrypted.Checked == false) || (textBox_CodeArrayForSMS.Text.Length == 4))
                )
            {


                groupBox34.Enabled = false;

                button_Ring.BackColor = Color.Yellow;
                button_Ring.Text = "Ring Processing";

                SendOneTimeFlag = 1;
                TimerStatusRingWait = 300;
                RingToContact((PhoneBookContact)checkedListBox_PhoneBook.SelectedItem);

                Thread.Sleep(1000);



                if (checkBox_SMSencrypted.Checked == true)
                {


                    string[] temp = richTextBox_TextSendSMS.Text.Split('>', '=');

                    OpcodeToCompare = temp[1];

                    string SMSText = ReturnCommandWithPassword(richTextBox_TextSendSMS.Text, (PhoneBookContact)checkedListBox_PhoneBook.SelectedItem);

                    //SMSText = ReturnSMSEncryiepted(SMSText);

                    if (CheckValidSMS(SMSText))
                    {
                        PhoneBookContact Temp = new PhoneBookContact();
                        Temp.Phone = "+00000000000";

                        SendSMSToContact(Temp, SMSText);
                    }
                    else
                    {
                        LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                        LogSMS.LogMessage(Color.Red, Color.White, "SMS Not Valid", New_Line = true, Show_Time = false);
                    }

                    // AddCommandToCommands(richTextBox_TextSendSMS.Text);

                }
                else
                {
                    string SMSText = ReturnCommandWithPassword(richTextBox_TextSendSMS.Text, (PhoneBookContact)checkedListBox_PhoneBook.SelectedItem);
                    txtDataTx.Text = SMSText;
                }

                groupBox34.Enabled = true;

            }
            else
            {
                LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
                string RingExplain = @"In Order to Ring you have to:
1. Select the contact 
2. Select the command
3. Check that the password is the right password
4. Check the Encripted checkbox
5. Check the unit ID (IMEI),it should be the same IMEI target ID (when the status received it compare the IMEI recieved vs the UnitID TextBox)
6. Check the Unit code it the right code
7. Comport must be open ";
                LogSMS.LogMessage(Color.Red, Color.White, RingExplain, New_Line = true, Show_Time = false);

                button_Ring.BackColor = default(Color);
                button_Ring.Text = "Ring";
                SendOneTimeFlag = 0;
                TimerStatusRingWait = 0;

            }
        }

        void scanComports()
        {
            cmbPortName.Items.Clear();
            comboBox_ComportSMS.Items.Clear();

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cmbPortName.Items.Add(port);
                comboBox_ComportSMS.Items.Add(port);
            }
            cmbPortName.SelectedIndex = 0;
            comboBox_ComportSMS.SelectedIndex = 0;
        }

        private void button_ReScanComPort_Click(object sender, EventArgs e)
        {
            scanComports();
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        Stopwatch stopwatch = new Stopwatch();

        private void textBox_StopWatch_TextChanged(object sender, EventArgs e)
        {

        }

        int TimerLogNumber = 0;
        private void button_StopwatchReset_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            TimerLogNumber = 0;
            textBox_StopWatch.Text = PrintTimeSpan(stopwatch.Elapsed);
            button_Stopwatch_Start_Stop.BackColor = default(Color);
        }

        private void button_Stopwatch_Start_Stop_Click(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning == false)
            {
                button_Stopwatch_Start_Stop.BackColor = Color.LightGreen;
                stopwatch.Start();
            }
            else
            {
                button_Stopwatch_Start_Stop.BackColor = default(Color);
                stopwatch.Stop();
            }

        }

        private void button_TimerLog_Click(object sender, EventArgs e)
        {
            TimerLogNumber++;
            SerialPortLogger.LogMessage(Color.DarkBlue, Color.White, "Stopwatch Log: " + TimerLogNumber + ">  " + PrintTimeSpan(stopwatch.Elapsed), true, true);
        }

        private void checkBox_ParseMessages_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Config42_TextChanged(object sender, EventArgs e)
        {
            CheckConfigTextboxValidData((TextBox)sender, ConfigDataType.Number);
        }

        Boolean IsTimerRunning = false;
        int TimerMemory = 0;
        private void button_StartStopTimer_Click(object sender, EventArgs e)
        {
            IsTimerRunning = !IsTimerRunning;
            if (IsTimerRunning == true && (textBox_SetTimerTime.Text != "0" || textBox_TimerTime.Text != "0"))
            {

                int Result = 0;
                int.TryParse(textBox_SetTimerTime.Text, out Result);
                if (Result != 0)
                {
                    button_StartStopTimer.BackColor = Color.LightGreen;
                    TimerMemory = Result;
                    button_ResetTimer.Text = "Reset (" + TimerMemory + ")";
                    textBox_TimerTime.Text = textBox_SetTimerTime.Text;
                    textBox_SetTimerTime.Text = "0";
                }
                else
                {

                }
            }
            else
            {
                button_StartStopTimer.BackColor = default(Color);

            }
        }

        private void cmbPortName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox32_Enter(object sender, EventArgs e)
        {

        }

        private void button42_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages[5].BackColor = Color.Red;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            Process.Start(@".");
        }

        private void textBox_SendSerialPort_TextChanged(object sender, EventArgs e)
        {
            ////    textBox_SendSerialPort.Text = textBox_SendSerialPort.Text.Replace("/n",Environment.NewLine);
            //textBox_SendSerialPort.SelectionStart = textBox_SendSerialPort.Text.Length;
            //textBox_SendSerialPort.SelectionLength = 0;
        }

        private void textBox_SourceConfig_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_SendTimer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox_SendSerialDiff_TextChanged(object sender, EventArgs e)
        {

        }

        private Random rnd = new Random();

        private void button_ScreenShot_Click(object sender, EventArgs e)
        {
            TakeCroppedScreenShot();


        }


        private void listBox_SMSCommands_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = false, Show_Time = true);
            for (int i = 0; i < listBox_SMSCommands.Items.Count; i++)
            {
                if (listBox_SMSCommands.GetSelected(i) == true)
                {
                    LogSMS.LogMessage(Color.Black, Color.White, "[" + listBox_SMSCommands.Items[i].ToString() + "]", New_Line = true, Show_Time = false);
                }
            }
            LogSMS.LogMessage(Color.Black, Color.White, "", New_Line = true, Show_Time = false);
        }

        private void button_ResetGraphs_Click(object sender, EventArgs e)
        {
            ChartCntX = 0;
            foreach (var ser in chart1.Series)
            {
                ser.Points.Clear();
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //public System.Data.DataTable ExportToExcel(Series ser)
        //{
        //    System.Data.DataTable table = new System.Data.DataTable();
        //    table.Columns.Add("Chart name", typeof(string));
        //    table.Columns.Add("X", typeof(double));
        //    table.Columns.Add("Y", typeof(double));

        //    //foreach (var ser in chart1.Series)
        //    //{
        //    DataPoint[] TotalPoints = new DataPoint[ser.Points.Count];
        //    ser.Points.CopyTo(TotalPoints,0);
        //        foreach(var Point in TotalPoints)
        //        {
        //            table.Rows.Add(ser.Name , Point.XValue,Point.YValues[0]);
        //        }
        //    //}

        //    //table.Columns.Add("Chart", typeof(int));
        //    //table.Columns.Add("X", typeof(string));
        //    //table.Columns.Add("Y", typeof(string));

        //    //table.Columns.Add("Subject1", typeof(int));
        //    //table.Columns.Add("Subject2", typeof(int));
        //    //table.Columns.Add("Subject3", typeof(int));
        //    //table.Columns.Add("Subject4", typeof(int));
        //    //table.Columns.Add("Subject5", typeof(int));
        //    //table.Columns.Add("Subject6", typeof(int));
        //    //table.Rows.Add(1, "Amar", "M", 78, 59, 72, 95, 83, 77);
        //    //table.Rows.Add(2, "Mohit", "M", 76, 65, 85, 87, 72, 90);
        //    //table.Rows.Add(3, "Garima", "F", 77, 73, 83, 64, 86, 63);
        //    //table.Rows.Add(4, "jyoti", "F", 55, 77, 85, 69, 70, 86);
        //    //table.Rows.Add(5, "Avinash", "M", 87, 73, 69, 75, 67, 81);
        //    //table.Rows.Add(6, "Devesh", "M", 92, 87, 78, 73, 75, 72);
        //    return table;
        //}


        private void Button_Export_excel_Click(object sender, EventArgs e)
        {
            // writetext.WriteLine("writing in text file");


            this.Invoke((MethodInvoker)delegate ()
            {
                textBox_graph_XY.Text = "";
            });

            Series[] Serias_Graphs = new Series[chart1.Series.Count];
            chart1.Series.CopyTo(Serias_Graphs, 0);
            foreach (var ser in Serias_Graphs)
            {
                String fileName = ser.Name;
                String Location = AppDomain.CurrentDomain.BaseDirectory + fileName + DateTime.Now.ToString("MM_DD_HH_mm_ss") + ".csv";
                using (StreamWriter writetext = new StreamWriter(@Location))
                {

                    foreach (DataPoint point_ in ser.Points)
                    {
                        writetext.WriteLine(point_.XValue + "," + point_.YValues[0]);
                    }

                    this.Invoke((MethodInvoker)delegate ()
                    {
                        textBox_graph_XY.Text += "Excel Generated at " + Location;
                    });
                }
            }


        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            Tab0Color = randomColor;
        }

        bool IsPauseGraphs = false;
        private void button_GraphPause_Click(object sender, EventArgs e)
        {

            if(IsPauseGraphs == false)
            {
                IsPauseGraphs = true;
                button_GraphPause.BackColor = Color.Yellow;
            }
            else
            {

                IsPauseGraphs = false;
                button_GraphPause.BackColor = default(Color);
            }
        }

        private void button1_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Help.ShowHelp(this, "helpfile.chm", HelpNavigator.TopicId, "1234");
        }

        private void button_OpenFolder2_Click(object sender, EventArgs e)
        {
            Process.Start(@".");
        }

        void CloseClentConnection()
        {
            if (ClientSocket != null)
            {
                //ClientSocket.GetStream().Close();
                ClientSocket.Close();
            }

            if (ReceiveThread != null)
            {
                ReceiveThread.Abort();
                //   m_Exit = true;

            }

            button_ClientConnect.BackColor = default(Color);

            richTextBox_ClientRx.AppendText("Connection closed \n");
        }
        private void button42_Click_1(object sender, EventArgs e)
        {
            CloseClentConnection();

        }

        void ReceiveData()
        {
            TcpClient PClientSocket = ClientSocket;
            try
            {
                while (true)
                {
                    if (m_Exit == true)
                    {
                        return;
                    }

                    if (PClientSocket != null)
                    {
                        try
                        {
                            byte[] buffer = new byte[4096];
                            Stream stm = PClientSocket.GetStream();



                            stm.Read(buffer, 0, buffer.Length);
                            //SSP_Protocol.SSP_DataPayload data = SSP_Protocol.SSP_Protocol.SSPPacket_Decoder(buffer);
                            richTextBox_ClientRx.Invoke(new EventHandler(delegate
                            {
                                DateTime dt = DateTime.Now;
                                richTextBox_ClientRx.AppendText("[" + dt.TimeOfDay.ToString().Substring(0, 11) + "] " + Encoding.ASCII.GetString(buffer) + " \n");
                                richTextBox_ClientRx.AppendText(" \n");


                            }));
                            PClientSocket = ClientSocket;

                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        PClientSocket.Close();
                    }

                }
            }
            catch (System.Net.Sockets.SocketException se)
            {
                //MessageBox.Show(se.Message);
            }
        }

        bool m_Exit = false;
        TcpClient ClientSocket;
        Thread ReceiveThread;
        private void button_ClientConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //create a new client socket ...
                m_Exit = false;
                //m_socWorker = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                String szIPSelected = textBox_ClientIP.Text;
                String szPort = textBox_ClientPort.Text;
                int alPort = System.Convert.ToInt16(szPort, 10);

                ClientSocket = new TcpClient();

                ClientSocket.Connect(textBox_ClientIP.Text, alPort);

                //System.Net.IPAddress	remoteIPAddress	 = System.Net.IPAddress.Parse(szIPSelected);
                //System.Net.IPEndPoint	remoteEndPoint = new System.Net.IPEndPoint(remoteIPAddress, alPort);
                //m_socWorker.Connect(remoteEndPoint);

                if (ClientSocket.Connected)
                {
                    this.ReceiveThread = new Thread(new ThreadStart(ReceiveData));
                    this.ReceiveThread.Start();
                }
            }
            catch (System.Net.Sockets.SocketException se)
            {
                richTextBox_ClientRx.AppendText(se.Message + "\n");
            }
        }

        int ClentSendData = 0;
        private void button3_Click_4(object sender, EventArgs e)
        {
            try
            {
                String str = richTextBox_ClientTx.Text;
                Stream stm = ClientSocket.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);

                //byte[] sspData = SSP_Protocol.SSP_Protocol.SSPPacket_Encoder(SSP_Protocol.eMessegeType.TRACE, ba);

                // Console.WriteLine("Sending...");

                stm.Write(ba, 0, ba.Length);

                ClentSendData++;
                richTextBox_ClientTx.Text = "Send Data to Server " + ClentSendData;

                // byte[] bb = new byte[100];

            }
            catch
            {
                //MessageBox.Show (se.Message );
            }
        }

        private void button43_Click_1(object sender, EventArgs e)
        {
            richTextBox_ClientTx.Text = "";
        }

        private void button_ClearRx_Click(object sender, EventArgs e)
        {
            richTextBox_ClientRx.Text = "";
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void listBox_Charts_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox_Charts.Items.Count; i++)
            {
                if (listBox_Charts.GetSelected(i) == true)
                {
                    chart1.Series[listBox_Charts.Items[i].ToString()].Enabled = true;
                }
                else
                {
                    chart1.Series[listBox_Charts.Items[i].ToString()].Enabled = false;
                }
            }
        }

        void ResetTimer()
        {
            textBox_TimerTime.Text = TimerMemory.ToString();
            textBox_SetTimerTime.Text = "0";
            IsTimerRunning = false;
            button_StartStopTimer.BackColor = default(Color);
        }

        private void button_ResetTimer_Click(object sender, EventArgs e)
        {
            ResetTimer();
        }

        //private void comboBox_SendThrough_SelectedIndexChanged_1(object sender, EventArgs e)
        //{
        //    switch (comboBox_SendThrough.SelectedIndex)
        //    {
        //        case (int)eComSource.GPRS:
        //            groupBox_ServerSettings.Visible = true;
        //            gbPortSettings.Visible = false;
        //            groupBox_PhoneNumber.Visible = false;
        //            break;
        //        case (int)eComSource.SerialPort:
        //            groupBox_ServerSettings.Visible = false;
        //            gbPortSettings.Visible = true;
        //            groupBox_PhoneNumber.Visible = false;
        //            break;
        //        case (int)eComSource.SMS:
        //            groupBox_ServerSettings.Visible = false;
        //            gbPortSettings.Visible = true;
        //            groupBox_PhoneNumber.Visible = true;
        //            break;
        //    }
        //}

        //private bool m_EchoResponse = false;
        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkBox1.Checked == true)
        //    {
        //        m_EchoResponse = true;
        //    }
        //    else
        //    {
        //        m_EchoResponse = false;
        //    }
        //}


        /*Modem Registration Status = [1], RSSI = [31], Modem GPRS = [0],
         * Temperature Level = [0],Board Temperature = [31] , Sim Status = [1] ,
         * OperatorName = ["Cellcom"], Modem Voltage = [3.924000], Modem SIMIdentificationNumber = [899720201108447424] ,
         * ModemIMEI = [354869050098417], SimIMSI = [425020110844742], ModemVersion = [Cinterion,BGS2-W,REVISION 02.000,A-REVISION 01.000.08,OK,], 
         * ModemConnectionStatus = [], ModemServiceStatus = [], ModemServiceStatus2 = [], ModemErrorServiceStatus = [], ModemEUpdateCounter = [4],*/

        class ModemStatus
        {
            public bool Valid = false;
            public string ModemRegistrationStatus = "";
            public string RSSI = "";
            public string SIMStatus = "";
            public string Operator = "";
            public string ModemVoltage = "";
            public string SIMIdentificationNumber = "";
            public string ModemIMEI = "";
            public string SimIMSI = "";
            public string ModemVersion = "";
            public string ModemEUpdateCounter = "";

            public ModemStatus(ref string i_ModemStatus)
            {
                if (i_ModemStatus.Contains("Modem Registration Status") &&
                    i_ModemStatus.Contains("RSSI") &&
                    i_ModemStatus.Contains("SIMIdentificationNumber") &&
                    i_ModemStatus.Contains("SMS_ONLY") &&
                    i_ModemStatus.Contains("SIMIdentificationNumber"))
                {
                    i_ModemStatus = i_ModemStatus.Substring(i_ModemStatus.LastIndexOf("SMS_ONLY"));
                    string[] values = i_ModemStatus.Split('[', ']');
                    if (values.Length >= 33)
                    {
                        this.ModemRegistrationStatus = values[1];
                        this.RSSI = values[3];
                        this.SIMStatus = values[11];
                        this.Operator = values[13];
                        this.ModemVoltage = values[15];
                        this.SIMIdentificationNumber = values[17];
                        this.ModemIMEI = values[19];
                        this.SimIMSI = values[21];
                        this.ModemVersion = values[23];
                        this.ModemEUpdateCounter = values[33];

                        Valid = true;
                    }
                    else
                    {
                        Valid = false;
                    }

                }
                else
                {
                    Valid = false;
                }
            }
        }



    }
}