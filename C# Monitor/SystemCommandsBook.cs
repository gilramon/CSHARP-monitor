using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public String Format;
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
