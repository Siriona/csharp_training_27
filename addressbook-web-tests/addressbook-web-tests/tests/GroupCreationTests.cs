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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.StartNewGroupCreation();
            GroupData group = new GroupData("test_name");
            group.Header = "test_header";
            group.Footer = "test_footer";
            app.Groups.FillGroupEditForm(group);
            app.Groups.SubmitGroupCreation();
            app.Navigator.ReturnGroupPage();
            app.Auth.LogOut();
        }

        

      

       

      

  

      

    

    }
}
