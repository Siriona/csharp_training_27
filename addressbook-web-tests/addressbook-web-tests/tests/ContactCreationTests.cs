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

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("First name 712", "Last name 712");
            contact.Middlename = "Middle 71";
            contact.Address = "address test line 71";
            contact.Bday = "7";
            contact.Bmonth = "June";
            contact.Aday = "7";
            contact.Amonth = "July";
            contact.New_group = "[none]";

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



        








    }
}
