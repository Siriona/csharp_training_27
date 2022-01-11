﻿using System;
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

            List<GroupData> oldGroups = app.Groups.GetGroupList();


           app.Groups.CheckGroupCreate(group);
          app.Groups.Remove();

            List<GroupData> newGroups = app.Groups.GetGroupList();

           oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

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