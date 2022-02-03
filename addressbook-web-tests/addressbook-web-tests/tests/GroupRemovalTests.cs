using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;



namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        
 
        

        [Test]
        public void GroupRemovalTest_checked()
        {
            GroupData group = new GroupData("test_name first");
            group.Header = null;
            group.Footer = null;

            app.Groups.CheckGroupCreate(group);


            List<GroupData> oldGroups = app.Groups.GetGroupList();


            app.Groups.Remove();

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());


            List<GroupData> newGroups = app.Groups.GetGroupList();


            GroupData toBeRemoved = oldGroups[0]; 
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group1 in newGroups)
                {
                Assert.AreNotEqual(group1.Id, toBeRemoved.Id);

            }

        }



        [Test]
        public void GroupRemovalTest_fromDB()
        {
            GroupData group = new GroupData("test_name first");
            group.Header = null;
            group.Footer = null;

            app.Groups.CheckGroupCreate(group);


            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();


            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group1 in newGroups)
            {
                Assert.AreNotEqual(group1.Id, toBeRemoved.Id);

            }

            // compare group lists from UI and DB

            app.Groups.CompareGroupsUiDb();

        }




    }
}


