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

            int count = app.Groups.GetGroupCount();
            Assert.AreEqual(oldGroups.Count - 1, count);


            List<GroupData> newGroups = app.Groups.GetGroupList();


            GroupData toBeRemoved = oldGroups[0]; 
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group1 in newGroups)
                {
                Assert.AreNotEqual(group1.Id, toBeRemoved.Id);

            }

        }








    }
}


/*
 
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
            app.Groups.Remove();

        }


    }

*/