using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class ContactModificationTests : AuthTestBase
    {



        // 1st contact = 2 line in table


        [Test]
        public void ContactModificationTest_pencil_fromDB()
        {

            ContactData newData = new ContactData("First New11", "Last New11");
            newData.Middlename = "";
            newData.Nickname = "";
            newData.Company = "";
            newData.Title = "";
            newData.Address = "";
            newData.Bday = "7";
            newData.Bmonth = "June";
            newData.Byear = "2000";
            newData.Aday = "7";
            newData.Amonth = "June";
            newData.Ayear = "2000";
            newData.Address = "address 11";
            newData.Home = "+9(000)5к65767+111";
            newData.Work = "9(bvggvn)--11";
            newData.Mobile = "0(45567)-565-65756-76-7";
            newData.Fax = "0(4)";
            newData.Email = "mail11@ee.ru";
            newData.Email2 = "mail22@.ru";
            newData.Email3 = "33@33.ru";
            newData.Homepage = "";
            newData.New_group = "[none]";
            newData.Address2 = "";
            newData.Phone2 = "";
            newData.Notes = "";



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


            app.Contacts.CheckContactCreate(contact);


            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeModified = oldContacts[0];

            app.Contacts.ModifyByPencil(newData, toBeModified);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            app.Contacts.CompareContactsUiDb();


        }


        

        [Test]
        public void ContactModificationTest_card_fromDB()
        {

            ContactData newData = new ContactData("First New22", "Last New2222");
            newData.Middlename = "";
            newData.Nickname = "";
            newData.Company = "";
            newData.Title = "";
            newData.Address = "";
            newData.Bday = "7";
            newData.Bmonth = "June";
            newData.Byear = "2000";
            newData.Aday = "7";
            newData.Amonth = "June";
            newData.Ayear = "2000";
            newData.Address = "address 11";
            newData.Home = "+9(000)5к65767+111";
            newData.Work = "9(bvggvn)--11";
            newData.Mobile = "0(45567)-565-65756-76-7";
            newData.Fax = "0(4)";
            newData.Email = "mail11@ee.ru";
            newData.Email2 = "mail22@.ru";
            newData.Email3 = "33@33.ru";
            newData.Homepage = "";
            newData.New_group = "[none]";
            newData.Address2 = "";
            newData.Phone2 = "";
            newData.Notes = "";



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

            app.Contacts.CheckContactCreate(contact);


            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeModified = oldContacts[0];

            app.Contacts.ModifyFromCard(newData, toBeModified);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());


            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            app.Contacts.CompareContactsUiDb();

        }

        /*
         * 
         * [Test]
        public void ContactModificationTest_pencil()
        {

            ContactData newData = new ContactData("First New", "Last New");
            newData.Middlename = "";
            newData.Address = "";
            newData.Bday = "7";
            newData.Bmonth = "June";
            newData.Aday = "7";
            newData.Amonth = "June";
            newData.Address = "address 11";
            newData.Home = "+9(000)5к65767+111";
            newData.Work = "9(bvggvn)--11";
            newData.Mobile = "0(45567)-565-65756-76-7";
            newData.Email = "mail11@ee.ru";
            newData.Email2 = "mail22@.ru";
            newData.Email3 = "33@33.ru";



            ContactData contact = new ContactData("First", "Last");
            contact.Middlename = "";
            contact.Address = "";
            contact.Bday = "8";
            contact.Bmonth = "July";
            contact.Aday = "8";
            contact.Amonth = "July";
            contact.New_group = "[none]";
            contact.Address = "address 11";
            contact.Home = "+9(000)5к65767+111";
            contact.Work = "9(bvggvn)--11";
            contact.Mobile = "0(45567)-565-65756-76-7";
            contact.Email = "mail11@ee.ru";
            contact.Email2 = "mail22@.ru";
            contact.Email3 = "33@33.ru";


            app.Contacts.CheckContactCreate(contact);


            List<ContactData> oldContacts = app.Contacts.GetContactList();


            app.Contacts.ModifyByPencil(newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());


            List<ContactData> newContacts = app.Contacts.GetContactList();
          
                oldContacts[0].Firstname = newData.Firstname;
                oldContacts[0].Lastname = newData.Lastname;
            

           


            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }

          [Test]
        public void ContactModificationTest_card()
        {

            ContactData newData = new ContactData("First New", "Last New");
            newData.Middlename = "";
            newData.Address = "";
            newData.Bday = "7";
            newData.Bmonth = "June";
            newData.Aday = "7";
            newData.Amonth = "June";
            newData.Address = "address 11";
            newData.Home = "+9(000)5к65767+111";
            newData.Work = "9(bvggvn)--11";
            newData.Mobile = "0(45567)-565-65756-76-7";
            newData.Email = "mail11@ee.ru";
            newData.Email2 = "mail22@.ru";
            newData.Email3 = "33@33.ru";



            ContactData contact = new ContactData("First", "Last");
            contact.Middlename = "";
            contact.Address = "";
            contact.Bday = "8";
            contact.Bmonth = "July";
            contact.Aday = "8";
            contact.Amonth = "July";
            contact.New_group = "[none]";
            contact.Address = "address 11";
            contact.Home = "+9(000)5к65767+111";
            contact.Work = "9(bvggvn)--11";
            contact.Mobile = "0(45567)-565-65756-76-7";
            contact.Email = "mail11@ee.ru";
            contact.Email2 = "mail22@.ru";
            contact.Email3 = "33@33.ru";

            app.Contacts.CheckContactCreate(contact);


            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.ModifyFromCard(newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());


            List<ContactData> newContacts = app.Contacts.GetContactList();
            
                oldContacts[0].Firstname = newData.Firstname;
                oldContacts[0].Lastname = newData.Lastname;
                  oldContacts.Sort();
                newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
       

        // tests for change group - from home page

        // 1st variant of opening group page - by CssSelector

        [Test]
        public void ContactChangeGroup()
        {

            app.Contacts.ContactChangeGroup(1, "Test 1", 18);

            


        }


        // 2nd variant of opening group page - by LinkText
        [Test]
        public void ContactChangeGroup_2()
        {

            app.Contacts.ContactChangeGroup_2("3", "Test 1", "\"Test 1\"");

        }


        // test for edit contact - from current group page
        [Test]

        public void ModifyContactFromGroupPage_pencil()

        {
            ContactData newData = new ContactData("NEW first name 1", "NEW last name 1");
            newData.Middlename = "Middle 71";
            newData.Address = "address test line 71";
            newData.Bday = "7";
            newData.Bmonth = "June";
            newData.Aday = "7";
            newData.Amonth = "July";
            newData.New_group = "[none]";

            app.Contacts.ModifyContactFromGroupPage_pencil("18", 30, newData);

        }

        */



    }
}
