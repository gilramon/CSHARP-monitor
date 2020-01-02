using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;



namespace Spetrotec
{
    /// <summary>
    /// 
    /// </summary>
    public class CommandDescription
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Opcode")]
        public string Opcode;
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Help")]
        public string Help;


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return  Opcode + "=" + "[" + Help + "]"  ;
        }
    }

    class CommandsBook
    {
        List<CommandDescription> m_ListSystemCommands = new List<CommandDescription>();
        public CommandsBook(string[] i_AllCommandsInString)
        {
            try
            {
                foreach (string str in i_AllCommandsInString)
                {
                    CommandDescription OneCommand = new CommandDescription();

                    string[] strsplit = str.Split(new string[] { ";;;;" }, StringSplitOptions.None);
                    OneCommand.Opcode = strsplit[0];
                    OneCommand.Help = strsplit[1];

                    m_ListSystemCommands.Add(OneCommand);

                }
            }
            catch 
            {

            }
        }

        public void SortPhoneBookByNotes()
        {
            m_ListSystemCommands = m_ListSystemCommands.OrderBy(q => q.Opcode).ToList();
        }

        //public PhoneBook(List<PhoneBookContact> i_Phones)
        //{
        //    Contacts = i_Phones.ToList();
        //}

        public void AddCommandToCommandsBook(CommandDescription i_Opcode)
        {
            m_ListSystemCommands.Add(i_Opcode);
        }

        public void RemoveCommandToCommandsBook(CommandDescription i_Opcode)
        {
            m_ListSystemCommands.Remove(i_Opcode);
        }


        public CommandDescription IsCommandExist(string i_Opcode)
        {
            foreach (CommandDescription cont in m_ListSystemCommands)
            {
                if (cont.Opcode == i_Opcode)
                {
                    return cont;
                }
            }
            return null;
        }

        //public PhoneBookContact GetContactByUnitID(string i_UnitID)
        //{
        //    foreach (PhoneBookContact cont in Contacts)
        //    {
        //        if (cont.UnitID == i_UnitID)
        //        {
        //            return cont;
        //        }
        //    }
        //    return null;
        //}

        public List<CommandDescription> GetAllCommands()
        {
            return m_ListSystemCommands;
        }

        //static void SerializeToXML(List<PhoneBookContact> movies)
        //{
        //    XmlSerializer serializer = new XmlSerializer(typeof(List<PhoneBookContact>));
        //    TextWriter textWriter = new StreamWriter(@".\PhoneContacts.xml");
        //    serializer.Serialize(textWriter, movies);
        //    textWriter.Close();
        //}

        //static List<PhoneBookContact> DeserializeFromXML()
        //{
        //    XmlSerializer deserializer = new XmlSerializer(typeof(List<PhoneBookContact>));
        //    TextReader textReader = new StreamReader(@".\PhoneContacts.xml");
        //    List<PhoneBookContact> movies;
        //    movies = (List<PhoneBookContact>)deserializer.Deserialize(textReader);
        //    textReader.Close();

        //    return movies;
        //}
        public void ExportToXML(Stream myStream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<PhoneBookContact>));
            TextWriter textWriter = new StreamWriter(myStream);
            serializer.Serialize(textWriter, m_ListSystemCommands);
            textWriter.Close();
        }

        public void ImportToXML(string i_Name)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<CommandDescription>));
            TextReader textReader = new StreamReader(i_Name);
            List<CommandDescription> ImportedContacts;
            ImportedContacts = (List<CommandDescription>)deserializer.Deserialize(textReader);
            textReader.Close();

            foreach(CommandDescription cmd in ImportedContacts)
            {
                m_ListSystemCommands.Add(cmd);
            }
            
        }

        

    }
}
