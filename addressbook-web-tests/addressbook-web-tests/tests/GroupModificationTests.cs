using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;
using System.Collections.Generic;



namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : AuthTestBase
    {

        [Test]
        public void GroupModificationTest_WithCreating()
        {

            GroupData newData = new GroupData("test_name new");
            GroupData group = new GroupData("test_name first");

            newData.Header = null;
            newData.Footer = null;
            group.Header = null;
            group.Footer = null;


            app.Groups.CheckGroupCreate(group);

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(newData);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }



    }
    
}
