﻿using NUnit.Framework;
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
            ContactData newContact = new ContactData("F new", "L new");
            newContact.Middlename = "";
            newContact.Nickname = "";
            newContact.Company = "";
            newContact.Title = "";
            newContact.Address = "";
            newContact.Bday = "7";
            newContact.Bmonth = "June";
            newContact.Byear = "2000";
            newContact.Aday = "7";
            newContact.Amonth = "June";
            newContact.Ayear = "2000";
            newContact.Address = "address 11";
            newContact.Home = "+9(000)5к65767+111";
            newContact.Work = "9(bvggvn)--11";
            newContact.Mobile = "0(45567)-565-65756-76-7";
            newContact.Fax = "0(4)";
            newContact.Email = "mail11@ee.ru";
            newContact.Email2 = "mail22@.ru";
            newContact.Email3 = "33@33.ru";
            newContact.Homepage = "";
            newContact.New_group = "[none]";
            newContact.Address2 = "";
            newContact.Phone2 = "";
            newContact.Notes = "";


            if (GroupData.GetAll().Count == 0)
            {
                GroupData newGroup = new GroupData("Group1");
                app.Groups.Create(newGroup);
            }

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> contactList = group.GetContacts();

            List<ContactData> oldList = ContactData.GetAll();


            ContactData contact = oldList.Except(contactList).FirstOrDefault();

            


            if (contact == null)
            {
               

                app.Contacts.Create(newContact);
                oldList.Add(newContact);
            }

            ContactData contactToAdd = ContactData.GetAll().Except(group.GetContacts()).First();


            app.Contacts.AddContactToGroup(contactToAdd, group);

            List<ContactData> newList = group.GetContacts();

            newList.Sort();
            oldList.Sort();

             foreach (ContactData contact1 in oldList)
             System.Console.WriteLine($"{contact1.Lastname}");

            System.Console.WriteLine("----------------");

            foreach (ContactData contact1 in newList)
                System.Console.WriteLine($"{contact1.Lastname}");




               Assert.AreEqual(oldList, newList);






        }

       

        [Test]

        public void TestDeletingContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];


            ContactData newContact = new ContactData("F new", "L new");
             
            newContact.Middlename = "";
            newContact.Nickname = "";
            newContact.Company = "";
            newContact.Title = "";
            newContact.Address = "";
            newContact.Bday = "7";
            newContact.Bmonth = "June";
            newContact.Byear = "2000";
            newContact.Aday = "7";
            newContact.Amonth = "June";
            newContact.Ayear = "2000";
            newContact.Address = "address 11";
            newContact.Home = "+9(000)5к65767+111";
            newContact.Work = "9(bvggvn)--11";
            newContact.Mobile = "0(45567)-565-65756-76-7";
            newContact.Fax = "0(4)";
            newContact.Email = "mail11@ee.ru";
            newContact.Email2 = "mail22@.ru";
            newContact.Email3 = "33@33.ru";
            newContact.Homepage = "";
            newContact.New_group = group.Id;
            newContact.Address2 = "";
            newContact.Phone2 = "";
            newContact.Notes = "";


            if (GroupData.GetAll().Count == 0)
            {
                GroupData newGroup = new GroupData("Group1");
                app.Groups.Create(newGroup);
            }


            List<ContactData> oldList = ContactData.GetAll();

            List<ContactData> contactList = group.GetContacts();


            ContactData contact = oldList.Except(contactList).FirstOrDefault();

            if (contact == null)
            {
                
                app.Contacts.Create(newContact);
                oldList.Add(newContact);


            }

            ContactData contactToDel = ContactData.GetAll().Intersect(group.GetContacts()).First();

            app.Contacts.DeleteContactFromGroup(contactToDel, group);

            List<ContactData> newList = ContactData.GetAll();

            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);


        }

        [Test]

        public void Lists()
        {

            GroupData group = GroupData.GetAll()[0];

            List<ContactData> contactList = group.GetContacts();

            List<ContactData> oldList = ContactData.GetAll();


            ContactData contact = oldList.Except(contactList).FirstOrDefault();
            
            
                System.Console.WriteLine($"{contact.Lastname}");

           // foreach (ContactData contact1 in contactList)
           //     System.Console.WriteLine($"{contact1.Lastname}");







        }

    }
}
