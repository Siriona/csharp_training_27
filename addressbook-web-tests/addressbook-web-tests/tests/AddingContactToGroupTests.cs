using NUnit.Framework;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using LinqToDB;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests: AuthTestBase
    {
        [Test]

        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();

            ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);


        }

        [Test]

        public void TestDeletingContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();

            ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group); //oterwise method Select in group can't find the contact received by GetAll().Except(oldList).First();


            app.Contacts.DeleteContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);


        }

    }
}
