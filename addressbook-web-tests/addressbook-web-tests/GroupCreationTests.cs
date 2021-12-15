using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
     

        [Test]
        public void GroupCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            StartNewGroupCreation();
            GroupData group = new GroupData("test_name");
            group.Header = "test_header";
            group.Footer = "test_footer";
            FillGroupEditForm(group);
            SubmitGroupCreation();
            ReturnGroupPage();
            LogOut();
        }

        

      

       

      

  

      

    

    }
}
