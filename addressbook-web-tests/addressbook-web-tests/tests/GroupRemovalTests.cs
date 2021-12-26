using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        
        /*
        [Test]
        public void GroupRemovalTest() 
        {

            GroupData group = new GroupData("test_name first");
            group.Header = null;
            group.Footer = null;

            app.Groups.CheckedRemove(group, 1);

        }
        */


        [Test]
        public void GroupRemovalTest_checked()
        {
            GroupData group = new GroupData("test_name first");
            group.Header = null;
            group.Footer = null;

            app.Groups.Remove_2(group);

        }








    }
}
