using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;



namespace WebAddressbookTests
{

    [TestFixture]

    class ContactInformationTests : AuthTestBase
    
    {
        [Test]


        public void TestContactInformation()

        {

            ContactData contact = new ContactData("First001", "Last001");
            contact.Bday = "10";
            contact.Bmonth = "June";
            contact.Aday = "10";
            contact.Amonth = "June";

            contact.Address = "address 11";
            contact.Home = "++9(111)33-22-33";
            contact.Work = "9(bvggvn)--11";
            contact.Mobile = "0(45567)-565-65756-76-7";

            contact.Email = "mail11@ee.ru";
            contact.Email2 = "mail22@.ru";
            contact.Email3 = "33@33.ru";

            app.Contacts.CheckContactCreate(contact);

            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);


        }

    }
}
