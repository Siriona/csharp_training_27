using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
       
        [Test]
        public void ContactCreationTest()
        {

            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.AddNewContact();
            ContactData contact = new ContactData("First name 71", "Last name 71");
            contact.Middlename = "Middle 71";
            contact.Address = "address test line 71";
            contact.Bday = "7";
        //   contact.Bday_path = "//option[@value='10']";
            contact.Bmonth = "June";
        //   contact.Bmonth_path = "//option[@value='June']";
            contact.Aday = "7";
            contact.Amonth = "July";
            contact.New_group = "[none]";
            app.Contacts.FillContactInfo(contact);
            app.Contacts.SubmitContactCreation();
            app.Navigator.ReturnHomePage();
            app.Navigator.GoToHomePage();
            //  Logout();
        }

      
 

           

       



        
    }
}
