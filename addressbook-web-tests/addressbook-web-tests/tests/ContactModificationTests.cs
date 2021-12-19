using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest_pencil()
        {

            ContactData newData = new ContactData("First name 712_new", "Last name 712_new");
            newData.Middlename = "Middle 71";
            newData.Address = "address test line 71";
            newData.Bday = "7";
            //   contact.Bday_path = "//option[@value='10']";
            newData.Bmonth = "June";
            newData.Aday = "7";
            newData.Amonth = "July";
            newData.New_group = "[none]";

            app.Contacts.ModifyByPencil(4, newData);


        }

        [Test]
        public void ContactModificationTest_card()
        {

            ContactData newData = new ContactData("First name Modified 1", "Last name Modified 1");
            newData.Middlename = "Middle 71";
            newData.Address = "address test line 71";
            newData.Bday = "7";
            newData.Bmonth = "June";
            //   contact.Bmonth_path = "//option[@value='June']";
            newData.Aday = "7";
            newData.Amonth = "July";
            newData.New_group = "[none]";

        }

        // tests for change group - from home page

        // 1st variant of opening group page - by CssSelector

        [Test]
        public void ContactChangeGroup()
        {

            app.Contacts.ContactChangeGroup("7", "Test 1", 18);

            


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

    }
}
