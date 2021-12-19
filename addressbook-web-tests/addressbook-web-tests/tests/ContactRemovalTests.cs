﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests.tests
{
    public class ContactRemovalTests : TestBase
    {

        [Test]
        public void ContactRemovalTest_home_dismiss()
        {
            app.Contacts.Remove_home("21");
            app.Contacts.Remove_dismiss();
        }

        [Test]
        public void ContactRemovalTest_home_accept()
        {
            app.Contacts.Remove_home("21");
            app.Contacts.Remove_accept();
        }

        
        // no alert for this way 
        [Test]
        public void ContactRemovalTest_card()
        {
            app.Contacts.Remove_FromCard(27);
        }

        
    }
}
