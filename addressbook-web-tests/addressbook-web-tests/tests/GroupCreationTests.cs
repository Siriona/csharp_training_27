using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
     

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("test_name 100");
            group.Header = "test_header 100";
            group.Footer = "test_footer 100";
            app.Groups.Create(group);
  
        }


        [Test]
        public void EmptyGroupCreation()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
            
        }












    }
}
