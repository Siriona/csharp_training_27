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
        public void TestContactInformation_Table()
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


        [Test]

        public void TestContactInformation_ContactPage()

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

            contact.Middlename = "Mid_n1";
            contact.Nickname = "Nick_n1";
            contact.Title = "Title1111";
            contact.New_group = "[none]";




            app.Contacts.CheckContactCreate(contact);

            ContactData contactInfoPage = app.Contacts.GetContactInformationFromContactPage(0);
            ContactData contactInfoEditForm = app.Contacts.GetContactInformationFromEditForm_all(0);


            // System.Console.Out.Write(contactInfo.AllInfo);

            // System.Console.Out.Write(contactInfo1.AllInfoEditForm);

            Assert.AreEqual(contactInfoPage.AllInfo, contactInfoEditForm.AllInfoEditForm);



            /*

            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            ContactData fromPage = app.Contacts.GetContactInformationFromContactPage(0);

            Assert.AreEqual(fromPage, fromForm);
            Assert.AreEqual(fromPage.Address, fromForm.Address);
            Assert.AreEqual(fromPage.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromPage.AllEmails, fromForm.AllEmails);
            */

        }

    }
}
