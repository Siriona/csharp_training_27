using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;


namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : TestBase
    {

        [Test]
        public void GroupModificationTest()
        {

            GroupData newData = new GroupData("test_name new");
            newData.Header = "test_header new";
            newData.Footer = "test_footer new";

            app.Groups.Modify(1, newData);

        }



    }
    
}
