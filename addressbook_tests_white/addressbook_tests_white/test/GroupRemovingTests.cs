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

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (oldGroups.Count == 1) //application doesn't allow to delete the last group, at least one group always exists
            {
                app.Groups.Add(newGroup);
            }
            
            GroupData groupToRemove = app.Groups.GetGroupList()[0];
            

            app.Groups.Remove(groupToRemove);

            
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Remove(groupToRemove); 
            oldGroups.Sort();
            newGroups.Sort();
            
            Assert.AreEqual(oldGroups, newGroups);
            

        }



    }
}
