using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupRemovingTests : TestBase
    {
        [Test]
        public void TestGroupRemove()
        {


            
            GroupData newGroup = new GroupData()
            {
                Name = "01white"
            };
            

            // to be sure at least one group exists and to keep test data existing
            // if disable -> the first group in list will be removed if it exists 
            app.Groups.Add(newGroup);

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData groupToRemove = app.Groups.GetGroupForRemove();

            app.Groups.Remove();

            
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Remove(groupToRemove); 
            oldGroups.Sort();
            newGroups.Sort();
            
            Assert.AreEqual(oldGroups, newGroups);
            

        }



    }
}
