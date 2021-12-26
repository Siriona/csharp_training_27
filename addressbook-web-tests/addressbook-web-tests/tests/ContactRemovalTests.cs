using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests.tests
{
    public class ContactRemovalTests : AuthTestBase
    {
        

        [Test]
        public void ContactRemovalTest_home_dismiss()
        {
            ContactData contact = new ContactData("First", "Last");
            contact.Middlename = "";
            contact.Address = "";
            contact.Bday = "8";
            contact.Bmonth = "July";
            contact.Aday = "8";
            contact.Amonth = "July";
            contact.New_group = "[none]";


            app.Contacts.Remove_home_2(contact);
            app.Contacts.Remove_dismiss();
        }

        [Test]
        public void ContactRemovalTest_home_accept()
        {

            ContactData contact = new ContactData("First", "Last");
            contact.Middlename = "";
            contact.Address = "";
            contact.Bday = "8";
            contact.Bmonth = "July";
            contact.Aday = "8";
            contact.Amonth = "July";
            contact.New_group = "[none]";


            app.Contacts.Remove_home_2(contact);
            app.Contacts.Remove_accept();

        }

        
        // no alert for this way 
        [Test]
        public void ContactRemovalTest_card()
        {
            ContactData contact = new ContactData("First", "Last");
            contact.Middlename = "";
            contact.Address = "";
            contact.Bday = "8";
            contact.Bmonth = "July";
            contact.Aday = "8";
            contact.Amonth = "July";
            contact.New_group = "[none]";

            app.Contacts.Remove_FromCard(contact);
        }

        
    }
}
