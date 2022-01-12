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

            GroupData oldData = oldGroups[0];

            app.Groups.Modify(newData);

            int count = app.Groups.GetGroupCount();
            Assert.AreEqual(oldGroups.Count, count);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group1 in newGroups)
            {
                if (group1.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group1.Name);


                }
            }

        }



    }
    
}
