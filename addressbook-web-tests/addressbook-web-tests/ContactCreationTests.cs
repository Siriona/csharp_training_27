using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.IO; 

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
       
        [Test]
        public void ContactCreationTest()
        {

            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            AddNewContact();
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
            FillContactInfo(contact);
            SubmitContactCreation();
            ReturnHomePage();
            GoToHomePage();
            //  Logout();
        }

      
 

           

       



        
    }
}
