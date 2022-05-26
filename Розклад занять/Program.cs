using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace try4
{
    class XML
    {
        public void LoadXmlIntoDocument(string namer) //добавление xml в форму
        {
            XDocument FacultyXml = new XDocument(new XElement("Faculties",
            new XElement("Faculty")));

            FacultyXml.Save($"{namer}.xml");
        }
        public void SaveIntoXml(string a, string namer)
        {
            XDocument xdoc = XDocument.Load($"{namer}.xml");
            XElement? root = xdoc.Element("Faculties");

            if (root != null)
            {
                // добавляем новый элемент
                root.Add(new XElement("Faculty",
                            new XAttribute("FacultyAtt", a)));

                xdoc.Save($"{namer}.xml");
            }
        }
        public Boolean FileExit(string path)
        {
            /*
             * @"C:\app\content.txt"
             */
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ComboBox LoadFromXml(ComboBox combobox, string namer) //выгрузка из xml в форму 
        {

            XDocument XML = XDocument.Load($"{namer}.xml");
            // получаем корневой узел
            XElement? Faculties = XML.Element("Faculties");
            if (Faculties is not null)
            {
                // проходим по всем элементам person
                foreach (XElement Faculty in Faculties.Elements("Faculty"))
                {
                    XAttribute? FacultyAtt = Faculty.Attribute("FacultyAtt");



                    try
                    {
                        combobox.Items.Add(FacultyAtt?.Value);
                    }
                    catch { }
                }
            }
            return combobox;


        }
        public void RemoveFromXml(string a, string namer)
        {
            XDocument xdoc = XDocument.Load($"{namer}.xml");
            XElement? root = xdoc.Element("Faculties");

            if (root != null)
            {
                var delthis = root.Elements("Faculty")
        .FirstOrDefault(p => p.Attribute("FacultyAtt")?.Value == a);
                // и удалим его
                if (delthis != null)
                {
                    delthis.Remove();
                    xdoc.Save($"{namer}.xml");
                }






            }



        }
        public void saveForButton(int countOfButton, string namer, int index, string title)
        {
            XDocument xdoc = XDocument.Load($"{namer}.xml");
            XElement? root = xdoc.Element("root");

            if (root != null)
            {
                // добавляем новый элемент
                root.Add(new XElement("Buttons",
                            new XAttribute("countOfButton", countOfButton), //0-39
                            new XElement("title", title),                   //text in button
                            new XElement("index", index)));                  //0-1


                xdoc.Save($"{namer}.xml");
            }
        }
        public void LoadXmlIntoDocumentForButton(string namer)//добавление xml в форму
        {
            XDocument FacultyXml = new XDocument(new XElement("root",
            new XElement("Buttons")));

            FacultyXml.Save($"{namer}.xml");
        }
        public int[] LoadFromXmlForButton(string namer) //выгрузка из xml в форму 
        {
            int m = 0;
            int[] massive = new int[41];
            XDocument XML = XDocument.Load($"{namer}.xml");
            // получаем корневой узел
            XElement? root = XML.Element("root");
            if (root is not null)
            {
                // проходим по всем элементам person
                foreach (XElement Buttons in root.Elements("Buttons"))
                {
                    XAttribute? countOfButton = Buttons.Attribute("countOfButton");
                    XElement? title = Buttons.Element("title");
                    XElement? index = Buttons.Element("index");

                    if (index is not null)
                    {

                        if (index?.Value == "1")
                        {

                            massive[m] = 1;
                        }
                        else
                        {
                            massive[m] = 0;
                        }
                        m++;
                    }
                }

            }


            return massive;

        }
        public void SaveDataForIndex(int i, String namer, int numb)
        {
            XDocument xdoc = XDocument.Load($"{namer}.xml");

            // получим элемент person с name = "Tom"
            var findingElement = xdoc.Element("root")?
                .Elements("Buttons")
                .FirstOrDefault(p => p.Attribute("countOfButton")?.Value == i.ToString());

            if (findingElement != null)
            {

                //  меняем вложенный элемент index
                var newindex = findingElement.Element("index");
                if (newindex != null) newindex.Value = numb.ToString();

                xdoc.Save($"{namer}.xml");
            }
        }//Запись индексов
        public String[] SaveTextForButton(String namer)
        {
            {
                int m = 0;
                string[] massive = new string[41];
                XDocument XML = XDocument.Load($"{namer}.xml");
                // получаем корневой узел
                XElement? root = XML.Element("root");
                if (root is not null)
                {
                    // проходим по всем элементам person
                    foreach (XElement Buttons in root.Elements("Buttons"))
                    {
                        XAttribute? countOfButton = Buttons.Attribute("countOfButton");
                        XElement? title = Buttons.Element("title");
                        XElement? index = Buttons.Element("index");
                            
                        if (title is not null)
                        {

                            massive[m] = title?.Value;
                            m++;
                        }
                    }

                }


                return massive;

            }

















































        }//выгрузка для кнопок слева
        public void SaveDataForText(int i, String namer, String text)
        {
            XDocument xdoc = XDocument.Load($"{namer}.xml");

            // получим элемент person с name = "Tom"
            var findingElement = xdoc.Element("root")?
                .Elements("Buttons")
                .FirstOrDefault(p => p.Attribute("countOfButton")?.Value == i.ToString());

            if (findingElement != null)
            {

                //  меняем вложенный элемент age
                var newtext = findingElement.Element("title");
                if (newtext != null) newtext.Value = text;

                xdoc.Save($"{namer}.xml");
            }
        }//Запись текста
        public void SaveDataToRecover(String namer, int count)//название, кнопка слева (которую нужно востановить), номер востанавливаемого элемента
        {
            int m = 0;
            XML xml = new XML();
            XDocument XML = XDocument.Load($"new\\{namer}.xml");
            // получаем корневой узел
            XElement? root = XML.Element("root");        
            if (root is not null)
            {
                // проходим по всем элементам person
                foreach (XElement Buttons in root.Elements("Buttons"))
                {
                    XAttribute? countOfButton = Buttons.Attribute("countOfButton");
                    XElement? title = Buttons.Element("title");
                    XElement? index = Buttons.Element("index");

                    if (countOfButton is not null && title is not null)
                    {

                        if (countOfButton?.Value == count.ToString())
                        {
                            if (xml.FileExit($"{title.Value}.xml") == true)
                            {
                                XDocument xdoc = XDocument.Load($"{title.Value}.xml");//для файла учителя
                                var findingElement = xdoc.Element("root")?
                .Elements("Buttons")
                .FirstOrDefault(p => p.Attribute("countOfButton")?.Value == count.ToString());

                                if (findingElement != null)
                                {

                                    //  меняем вложенный элемент age
                                    var newtext = findingElement.Element("index");
                                    if (newtext != null) newtext.Value = "1";

                                    xdoc.Save($"{title.Value}.xml");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
        internal static class Program
        {
            /// <summary>
            /// Главная точка входа для приложения.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
}