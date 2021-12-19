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
            //   contact.Bmonth_path = "//option[@value='June']";
            newData.Aday = "7";
            newData.Amonth = "July";
            newData.New_group = "[none]";

            //  app.Contacts.OpenEditFormByPencil(4);

            app.Contacts.ModifyByPencil(4, newData);


        }

        [Test]
        public void ContactModificationTest_card()
        {

            ContactData newData = new ContactData("First name Modified 1", "Last name Modified 1");
            newData.Middlename = "Middle 71";
            newData.Address = "address test line 71";
            newData.Bday = "7";
            //   contact.Bday_path = "//option[@value='10']";
            newData.Bmonth = "June";
            //   contact.Bmonth_path = "//option[@value='June']";
            newData.Aday = "7";
            newData.Amonth = "July";
            newData.New_group = "[none]";

            //  app.Contacts.OpenEditFormByPencil(4);
            //  app.Contacts.OpenEditFormByPencil(4);


            app.Contacts.ModifyFromCard(3, newData);


        }


        [Test]
        public void ContactChangeGroup()
        {


            app.Contacts.ContactChangeGroup("20", "test_name new");




        }

    }
}
