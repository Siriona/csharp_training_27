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
            ContactData contact = new ContactData("First name 712", "Last name 712");
            contact.Middlename = "Middle 71";
            contact.Address = "address test line 71";
            contact.Bday = "7";
            //   contact.Bday_path = "//option[@value='10']";
            contact.Bmonth = "June";
            //   contact.Bmonth_path = "//option[@value='June']";
            contact.Aday = "7";
            contact.Amonth = "July";
            contact.New_group = "[none]";

            app.Contacts.Create(contact);

            //app.Navigator.ReturnHomePage();
            //  Logout();
        }



      
 

           

       



        
    }
}
