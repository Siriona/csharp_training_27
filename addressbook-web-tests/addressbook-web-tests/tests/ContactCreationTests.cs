using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {


        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add
                    (new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                    {
                        Middlename = GenerateRandomString(100),
                        Nickname = GenerateRandomString(100),
                        Company = GenerateRandomString(100),
                        Title = GenerateRandomString(100),
                        Address = GenerateRandomString(100),
                        Home = GenerateRandomString(100),
                        Mobile = GenerateRandomString(100),
                        Work = GenerateRandomString(100),
                        Fax = GenerateRandomString(100),
                        Email = GenerateRandomString(100),
                        Email2 = GenerateRandomString(100),
                        Email3 = GenerateRandomString(100),
                        Homepage = GenerateRandomString(100),
                        Bday = "1",
                        Bmonth = "July",
                        Byear = "2000",
                        Aday = "1",
                        Amonth = "July",
                        Ayear = "2000",
                        New_group = "[none]",
                        Address2 = GenerateRandomString(100),
                        Phone2 = GenerateRandomString(100),
                        Notes = GenerateRandomString(100)

                    }
                    );

            }

            return contacts;

        }

        

        [Test]
        public void ContactCreationTest_fromDB()
        {

            ContactData contact = new ContactData("First", "Last");
            contact.Middlename = "";
            contact.Nickname = "";
            contact.Company = "";
            contact.Title = "";
            contact.Address = "";
            contact.Bday = "7";
            contact.Bmonth = "June";
            contact.Byear = "2000";
            contact.Aday = "7";
            contact.Amonth = "June";
            contact.Ayear = "2000";
            contact.Address = "address 11";
            contact.Home = "+9(000)5к65767+111";
            contact.Work = "9(bvggvn)--11";
            contact.Mobile = "0(45567)-565-65756-76-7";
            contact.Fax = "0(4)";
            contact.Email = "mail11@ee.ru";
            contact.Email2 = "mail22@.ru";
            contact.Email3 = "33@33.ru";
            contact.Homepage = "";
            contact.New_group = "[none]";
            contact.Address2 = "";
            contact.Phone2 = "";
            contact.Notes = "";



            List<ContactData> oldContacts = ContactData.GetAll();


            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());


            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            app.Contacts.CompareContactsUiDb();


            //app.Navigator.ReturnHomePage();
            //  Logout();
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
            


            List<ContactData> oldContacts = app.Contacts.GetContactList();


            app.Contacts.Create(contact);
            
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());


            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
            


            //app.Navigator.ReturnHomePage();
            //  Logout();
        }



        /*
        
         [Test]
        public void ContactCreationTest_0()
        {

            ContactData contact = new ContactData("First New", "Last New");
            contact.Middlename = "";
            contact.Nickname = "";
            contact.Company = "";
            contact.Title = "";
            contact.Address = "";
            contact.Bday = "7";
            contact.Bmonth = "June";
            contact.Byear = "2000";
            contact.Aday = "7";
            contact.Amonth = "June";
            contact.Ayear = "2000";
            contact.Address = "address 11";
            contact.Home = "+9(000)5к65767+111";
            contact.Work = "9(bvggvn)--11";
            contact.Mobile = "0(45567)-565-65756-76-7";
            contact.Fax = "0(4)";
            contact.Email = "mail11@ee.ru";
            contact.Email2 = "mail22@.ru";
            contact.Email3 = "33@33.ru";
            contact.Homepage = "";
            contact.New_group = "[none]";
            contact.Address2 = "";
            contact.Phone2 = "";
            contact.Notes = "";



            List<ContactData> oldContacts = app.Contacts.GetContactist();


            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());


            List<ContactData> newContacts = app.Contacts.GetContactist();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);



            //app.Navigator.ReturnHomePage();
            //  Logout();
        }
        */






    }
}
