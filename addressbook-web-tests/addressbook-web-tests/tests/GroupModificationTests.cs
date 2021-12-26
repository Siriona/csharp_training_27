using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;


namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : AuthTestBase
    {

        [Test]
        public void GroupModificationTest()
        {

            GroupData newData = new GroupData("test_name new");
            GroupData group = new GroupData("test_name first");

            newData.Header = null;
            newData.Footer = null;
            group.Header = null;
            group.Footer = null;

            app.Groups.Modify(newData, group);

        }



    }
    
}
