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
        public void ContactModificationTest_pencil()
        {

            ContactData newData = new ContactData("First New", "Last New");
            newData.Middlename = "";
            newData.Address = "";
            newData.Bday = "7";
            newData.Bmonth = "June";
            newData.Aday = "7";
            newData.Amonth = "June";

            ContactData contact = new ContactData("First", "Last");
            contact.Middlename = "";
            contact.Address = "";
            contact.Bday = "8";
            contact.Bmonth = "July";
            contact.Aday = "8";
            contact.Amonth = "July";
            contact.New_group = "[none]";

            app.Contacts.CheckContactCreate(contact);


            List<ContactData> oldContacts = app.Contacts.GetContactist();


            app.Contacts.ModifyByPencil(newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());


            List<ContactData> newContacts = app.Contacts.GetContactist();
          
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

            ContactData contact = new ContactData("First", "Last");
            contact.Middlename = "";
            contact.Address = "";
            contact.Bday = "8";
            contact.Bmonth = "July";
            contact.Aday = "8";
            contact.Amonth = "July";
            contact.New_group = "[none]";

            app.Contacts.CheckContactCreate(contact);


            List<ContactData> oldContacts = app.Contacts.GetContactist();

            app.Contacts.ModifyFromCard(newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());


            List<ContactData> newContacts = app.Contacts.GetContactist();
            
                oldContacts[0].Firstname = newData.Firstname;
                oldContacts[0].Lastname = newData.Lastname;
                  oldContacts.Sort();
                newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }

        /*
       

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
