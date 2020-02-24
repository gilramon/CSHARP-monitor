using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Spetrotec
{
    class OneSystemCommand
    {
        //     [XmlElement("Contact_Name")]
        /// <summary>
        /// 
        /// </summary>
        public String Name;
        /// <summary>
        /// 
        /// </summary>
        //     [XmlElement("Contact_Phone")]

        public String Help;

        public String Format; // OPCODE={Num_Of_Argument},[arg1,Arg2...;
    }

    class SystemCommandsBook
    {
        List<OneSystemCommand> ALLCommandsList = new List<OneSystemCommand>();
        public SystemCommandsBook(List<String> i_InputList)
        {
            ALLCommandsList = DeSerializeStringListToCommandsList(i_InputList);

            //Gil: Sort the list by ABC
            ALLCommandsList = ALLCommandsList.OrderBy(o => o.Name).ToList();
        }

        public void AddCommand(String i_Name, String i_Format, String i_Help)
        {
            OneSystemCommand NewCommand = new OneSystemCommand();
            NewCommand.Name = i_Name;
            NewCommand.Format = i_Format;
            NewCommand.Help = i_Help;
            ALLCommandsList.Add(NewCommand);
        }


        //Only letters:
        //Regex.IsMatch(input, @"^[a-zA-Z]+$");

        //Only numbers:
        //Regex.IsMatch(input, @"^[0-9]+$");

        //Only letters and numbers:
        //Regex.IsMatch(input, @"^[a-zA-Z0-9]+$");

        //Only letters, numbers and underscore:
        //Regex.IsMatch(input, @"^[a-zA-Z0-9_]+$");

        //Gil Ramon: There is General format for the commands ^[0-9a-zA-Z]{3,15}=\{[0-9]\},([0-9a-zA-Z,]){0,100};$; and internal format for each command;

        public static bool CheckGeneralFormatOfCommand(String i_Format)
        {
            Regex ValidCommandFormat = new Regex(@"^[0-9a-zA-Z]{3,15}=\{[0-9]\},([0-9a-zA-Z,]){0,100};$"); // OPCODE=[Num_Of_Argument],[arg1,arg2...;
            bool ret = ValidCommandFormat.IsMatch(i_Format);
            return ret;
        }

        public static string CheckInputToCommandFormat(String i_Input)
        {
            string ret = "";
            //1. find the current command in the list
            //2. Get the format of the command.
            //3. compare the format to input.
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

        //int HistoryIndex = -1;
        //public String GetUpCommand(bool IsEmptyTextbox)
        //{
        //    if (HistoryIndex > ALLCommandsList.Count - 1 || HistoryIndex < 0)
        //    {
        //        HistoryIndex = ALLCommandsList.Count;
        //    }

        //    //if (textBox_SendSerialPort.Text == string.Empty)
        //    //{
        //    //    HistoryIndex = CommandsHistoy.Count;
        //    //}

        //    if(IsEmptyTextbox == true)
        //    {
        //        HistoryIndex = ALLCommandsList.Count;
        //    }


        //    if (HistoryIndex > 0)
        //    {
        //        HistoryIndex--;
        //    }
        //    return ALLCommandsList[HistoryIndex].Format;
        //}


        //public String GetDownCommand(bool IsEmptyTextbox)
        //{
        //    String ret = ALLCommandsList[HistoryIndex].Format;
        //    if (HistoryIndex < ALLCommandsList.Count - 1)
        //    {
        //        HistoryIndex++;
        //    }
        //    return ret;
        //}

        public List<String> SerializeCommandsToStringList()
        {
            List<String> ret = new List<String>();
            
            foreach (OneSystemCommand cmd in ALLCommandsList)
            {
                ret.Add(String.Format("{0}|||{1}|||{2}", cmd.Name, cmd.Format, cmd.Help));
            }
            return ret;
        }

        public List<OneSystemCommand> DeSerializeStringListToCommandsList(List<String> i_InputList)
        {
            List<OneSystemCommand> ret = new List<OneSystemCommand>();

            foreach (String cmd in i_InputList)
            {
                string[] Output = cmd.Split(new string[] { "|||" }, StringSplitOptions.None);
                OneSystemCommand NewCmd = new OneSystemCommand();
                NewCmd.Name = Output[1];
                NewCmd.Format = Output[2];
                NewCmd.Help = Output[3];
                ret.Add(NewCmd);
            }
            return ret;
        }

        public List<String> GetAllCommadsFormatStartWith(String i_StartString)
        {
            List<String> ret = new List<String>();
            foreach (OneSystemCommand cmd in ALLCommandsList)
            {
                if(cmd.Format.StartsWith(i_StartString) == true)
                {
                    ret.Add(cmd.Format);
                }
            }
            return ret;
        }

        public String GetHelpCommandWithName(String i_Name)
        {
            String ret = String.Empty;
            foreach (OneSystemCommand cmd in ALLCommandsList)
            {
                if (cmd.Name == i_Name)
                {
                    ret = cmd.Help;
                }
            }
            return ret;
        }

        public String GetHelpCommandWithFormat(String i_Format)
        {
            String ret = String.Empty;
            foreach (OneSystemCommand cmd in ALLCommandsList)
            {
                if (cmd.Format == i_Format)
                {
                    ret = cmd.Help;
                }
            }
            return ret;
        }


        public String GetFormatCommandWithName(String i_Name)
        {
            String ret = String.Empty;
            foreach (OneSystemCommand cmd in ALLCommandsList)
            {
                if (cmd.Name == i_Name)
                {
                    ret = cmd.Format;
                }
            }
            return ret;
        }



    }
}
