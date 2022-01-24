using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;
using System.Collections.Generic;



namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
        List<GroupData> groups= new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add
                    (new GroupData(GenerateRandomString(30))
                    {
                        Header = GenerateRandomString(100),
                        Footer = GenerateRandomString(100)
                    }
                    );

            }

        return groups;

        }

        

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {
    
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

         Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            // Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);  
        }
         

       


    
        
        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            int count = app.Groups.GetGroupCount();
            Assert.AreEqual(oldGroups.Count + 1, count);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }









    }
}





/*
namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
     







        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("test_name 100");
            group.Header = "test_header 100";
            group.Footer = "test_footer 100";
            app.Groups.Create(group);
  
        }


        [Test]
        public void EmptyGroupCreation()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
            
        }












    }
}
*/