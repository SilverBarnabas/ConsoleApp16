using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace notepad
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeXML();
            OptionsMenu();
        }

        static void InitializeXML()
        {
            if (!System.IO.File.Exists("notes.xml"))
            {
                XmlWriter xmlWriter = XmlWriter.Create("notes.xml");
                xmlWriter.WriteStartDocument();

                xmlWriter.WriteStartElement("notes");

                xmlWriter.Close();
            }
        }

        static void ListNotes()
        {
            Console.Clear();

            XmlDocument doc = new XmlDocument();
            doc.Load("notes.xml");
            var rootNode = doc.DocumentElement;

            if (rootNode.ChildNodes.Count == 0)
            {
                Console.WriteLine("Pole märkmeid\n");
                return;
            }

            for (int i = 0; i < rootNode.ChildNodes.Count; i++)
                Console.WriteLine((i + 1) + ". " + rootNode.ChildNodes[i].Attributes["name"].Value);

            int userOption = Int32.Parse(Console.ReadLine());

            if (!(userOption > 0 && userOption <= rootNode.ChildNodes.Count))
            {
                Console.Clear();
                return;
            }

            Console.Clear();

            Console.WriteLine(rootNode.ChildNodes[userOption - 1].Attributes["text"].Value);
            Console.WriteLine();
        }

        static void WriteNote()
        {
            Console.Clear();
            Console.WriteLine("Pealkiri:");
            string Name = Console.ReadLine();
            Console.WriteLine("Tekst:");
            string Text = Console.ReadLine();

            XmlDocument doc = new XmlDocument();
            doc.Load("notes.xml");
            XmlElement newNote = doc.CreateElement("note");
            newNote.SetAttribute("name", Name);
            newNote.SetAttribute("text", Text);

            XmlNode rootNode = doc.DocumentElement;
            rootNode.AppendChild(newNote);

            doc.Save("notes.xml");

            Console.Clear();
            Console.WriteLine("Märge loodud\n");
        }

        static void OptionsMenu()
        {
            Console.Clear();

            while (true)
            {
                Console.WriteLine("1. Loe märkmeid");
                Console.WriteLine("2. Kirjuta märge");
                Console.WriteLine("3. Välju");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ListNotes();
                        break;
                    case "2":
                        WriteNote();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Tundmatu käsk");
                        break;
                }

            }
        }
    }
}
