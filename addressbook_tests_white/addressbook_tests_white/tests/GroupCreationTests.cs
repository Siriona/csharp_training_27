using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupCreationTests: TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
           

            GroupData newGroup = new GroupData()
            {
                Name = "test"
            };

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Add(newGroup);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

        }


        [Test]
        public void TestGroupRemoving()
        {


            GroupData newGroup = new GroupData()
            {
                Name = "test"
            };

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Add(newGroup);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
