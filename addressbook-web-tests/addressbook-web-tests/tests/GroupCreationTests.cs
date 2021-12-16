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
            GroupData group = new GroupData("test_name 1");
            group.Header = "test_header 1";
            group.Footer = "test_footer 1";
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
