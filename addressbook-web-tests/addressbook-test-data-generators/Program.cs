using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using WebAddressbookTests;








namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];

            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)


                });
            

            }


            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                {
                    Middlename = TestBase.GenerateRandomString(10),
                    Nickname = TestBase.GenerateRandomString(10),
                    Company = TestBase.GenerateRandomString(10),
                    Title = TestBase.GenerateRandomString(10),
                    Address = TestBase.GenerateRandomString(10),
                    Home = TestBase.GenerateRandomString(10),
                    Mobile = TestBase.GenerateRandomString(10),
                    Work = TestBase.GenerateRandomString(10),
                    Fax = TestBase.GenerateRandomString(10),
                    Email = TestBase.GenerateRandomString(10),
                    Email2 = TestBase.GenerateRandomString(10),
                    Email3 = TestBase.GenerateRandomString(10),
                    Homepage = TestBase.GenerateRandomString(10),
                    Bday = "1",
                    Bmonth = "July",
                    Byear = "2000",
                    Aday = "1",
                    Amonth = "July",
                    Ayear = "2000",
                    New_group = "",
                    Address2 = TestBase.GenerateRandomString(10),
                    Phone2 = TestBase.GenerateRandomString(10),
                    Notes = TestBase.GenerateRandomString(10)


                });


            }

            StreamWriter writer = new StreamWriter(filename);


            if (type == "group")
            {
                if (format == "excel")
                {
                    WriteGroupsToExcelFile(groups, filename);

                }
                else
                {

                    if (format == "csv")
                    {
                        WriteGroupsToCSVFile(groups, writer);
                    }
                    else if (format == "xml")
                    {
                        WriteGroupsToXMLFile(groups, writer);

                    }
                    else if (format == "json")
                    {
                        WriteGroupsToJsonFile(groups, writer);

                    }
                    else
                    {
                        System.Console.Out.Write("Inrecognized format " + format);
                    }
                    writer.Close();

                }


            }
            else if (type == "contact")
            {
                
                     if (format == "xml")
                    {
                        WriteContactsToXMLFile(contacts, writer);

                    }
                    else if (format == "json")
                    {
                        WriteContactsToJsonFile(contacts, writer);

                    }
                    else
                    {
                        System.Console.Out.Write("Inrecognized format " + format);
                    }
                    writer.Close();

                

            }
            else
            {
                System.Console.Out.Write("Inrecognized type " + type);

            }

            writer.Close();



        }

        static void WriteGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;

            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);

            wb.Close();
            app.Visible = false;
            app.Quit();
            
        }

        static void WriteGroupsToCSVFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
               writer.WriteLine(String.Format("${0},${1},${2}",
                   group.Name, group.Header, group.Footer));

            }
        }

        static void WriteGroupsToXMLFile(List<GroupData> groups, StreamWriter writer)
        {
           
                new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);

            
        }


        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void WriteContactsToXMLFile(List<ContactData> contacts, StreamWriter writer)
        {

            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);


        }


        static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }


    }
}
