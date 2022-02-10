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
                Name = "0000001-white"
            };

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (oldGroups.Count == 1) //application doesn't allow to delete the last group, at least one group always exists
            {
                app.Groups.Add(newGroup);
                oldGroups = app.Groups.GetGroupList();

            }

            GroupData groupToRemove = oldGroups[0];

            app.Groups.Remove(groupToRemove);


            List<GroupData> newGroups = app.Groups.GetGroupList();


            oldGroups.Remove(groupToRemove);
            oldGroups.Sort();
            newGroups.Sort();
          
            Assert.AreEqual(oldGroups, newGroups);

            /*
            foreach (GroupData old in oldGroups)
                System.Console.WriteLine($"{old.Name}");

            System.Console.WriteLine("----------------");

            foreach (GroupData new1 in newGroups)
                System.Console.WriteLine($"{new1.Name}");
            */



        }



    }
}
