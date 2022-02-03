using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;




namespace WebAddressbookTests
{
    public class ContactRemovalTests : AuthTestBase
    {
        

        [Test]
        public void ContactRemovalTest_home_dismiss_fromDB()
        {
            ContactData contact = new ContactData("First", "Last");
            contact.Middlename = "";
            contact.Address = "";
            contact.Bday = "8";
            contact.Bmonth = "July";
            contact.Aday = "8";
            contact.Amonth = "July";
            contact.New_group = "[none]";
            contact.Address = "address 11";
            contact.Home = "+9(000)5к65767+111";
            contact.Work = "9(bvggvn)--11";
            contact.Mobile = "0(45567)-565-65756-76-7";
            contact.Email = "mail11@ee.ru";
            contact.Email2 = "mail22@.ru";
            contact.Email3 = "33@33.ru";

            app.Contacts.CheckContactCreate(contact);


            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove_FromHomePage(toBeRemoved);
            app.Contacts.Remove_dismiss();
            app.Navigator.GoToHomePage();

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());


            List<ContactData> newContacts = ContactData.GetAll(); 
            Assert.AreEqual(oldContacts, newContacts);

        }

        [Test]
        public void ContactRemovalTest_home_accept_fromDB()
        {

            ContactData contact = new ContactData("First", "Last");
            contact.Middlename = "";
            contact.Nickname = "";
            contact.Company = "";
            contact.Title = "";
            contact.Address = "";
            contact.Bday = "7";
            contact.Bmonth = "June";
            contact.Byear = "2000";
            contact.Aday = "7";
            contact.Amonth = "June";
            contact.Ayear = "2000";
            contact.Address = "address 11";
            contact.Home = "+9(000)5к65767+111";
            contact.Work = "9(bvggvn)--11";
            contact.Mobile = "0(45567)-565-65756-76-7";
            contact.Fax = "0(4)";
            contact.Email = "mail11@ee.ru";
            contact.Email2 = "mail22@.ru";
            contact.Email3 = "33@33.ru";
            contact.Homepage = "";
            contact.New_group = "[none]";
            contact.Address2 = "";
            contact.Phone2 = "";
            contact.Notes = "";

            app.Contacts.CheckContactCreate(contact);

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove_FromHomePage(toBeRemoved);
            app.Contacts.Remove_accept();
            app.Navigator.GoToHomePage(); 

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount()); 

            //   app.WaitUpdatePage(); // wihout it there is a lag  and newContacts list is created with old deleted contact (because page isn't updated in time even with GoToHomePage method)

            List<ContactData> newContacts = ContactData.GetAll(); 
            oldContacts.RemoveAt(0);
          
            
            Assert.AreEqual(oldContacts, newContacts);

            app.Contacts.CompareContactsUiDb();
        }

        
        // no alert for this way 
        [Test]
        public void ContactRemovalTest_card_fromDB()
        {
            ContactData contact = new ContactData("First New", "Last New");
            contact.Middlename = "";
            contact.Nickname = "";
            contact.Company = "";
            contact.Title = "";
            contact.Address = "";
            contact.Bday = "7";
            contact.Bmonth = "June";
            contact.Byear = "2000";
            contact.Aday = "7";
            contact.Amonth = "June";
            contact.Ayear = "2000";
            contact.Address = "address 11";
            contact.Home = "+9(000)5к65767+111";
            contact.Work = "9(bvggvn)--11";
            contact.Mobile = "0(45567)-565-65756-76-7";
            contact.Fax = "0(4)";
            contact.Email = "mail11@ee.ru";
            contact.Email2 = "mail22@.ru";
            contact.Email3 = "33@33.ru";
            contact.Homepage = "";
            contact.New_group = "[none]";
            contact.Address2 = "";
            contact.Phone2 = "";
            contact.Notes = "";

            app.Contacts.CheckContactCreate(contact);


            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove_FromCard(toBeRemoved);
            app.Navigator.GoToHomePage();

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());


            List<ContactData> newContacts = ContactData.GetAll();
                       
            oldContacts.RemoveAt(0);
           
            Assert.AreEqual(oldContacts, newContacts);

            app.Contacts.CompareContactsUiDb();

        }

        /*
         * 
         * 
        [Test]
        public void ContactRemovalTest_home_accept()
        {

            ContactData contact = new ContactData("First", "Last");
            contact.Middlename = "";
            contact.Address = "";
            contact.Bday = "8";
            contact.Bmonth = "July";
            contact.Aday = "8";
            contact.Amonth = "July";
            contact.New_group = "[none]";
            contact.Address = "address 11";
            contact.Home = "+9(000)5к65767+111";
            contact.Work = "9(bvggvn)--11";
            contact.Mobile = "0(45567)-565-65756-76-7";
            contact.Email = "mail11@ee.ru";
            contact.Email2 = "mail22@.ru";
            contact.Email3 = "33@33.ru";

            app.Contacts.CheckContactCreate(contact);

            List<ContactData> oldContacts = app.Contacts.GetContactList();

             app.Contacts.Remove_FromHomePage();
              app.Contacts.Remove_accept();
            app.Navigator.GoToHomePage(); 

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount()); 

            //   app.WaitUpdatePage(); // wihout it there is a lag  and newContacts list is created with old deleted contact (because page isn't updated in time even with GoToHomePage method)

            List<ContactData> newContacts = app.Contacts.GetContactList();

          //  if (oldContacts.Count > 0) // if no contacts before test => lists are empty => no need RemoveAt
           // { 
                oldContacts.RemoveAt(0);
           // }
            
            Assert.AreEqual(oldContacts, newContacts);

        }



         [Test]
        public void ContactRemovalTest_home_dismiss()
        {
            ContactData contact = new ContactData("First", "Last");
            contact.Middlename = "";
            contact.Address = "";
            contact.Bday = "8";
            contact.Bmonth = "July";
            contact.Aday = "8";
            contact.Amonth = "July";
            contact.New_group = "[none]";
            contact.Address = "address 11";
            contact.Home = "+9(000)5к65767+111";
            contact.Work = "9(bvggvn)--11";
            contact.Mobile = "0(45567)-565-65756-76-7";
            contact.Email = "mail11@ee.ru";
            contact.Email2 = "mail22@.ru";
            contact.Email3 = "33@33.ru";

            app.Contacts.CheckContactCreate(contact);


            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove_FromHomePage();
            app.Contacts.Remove_dismiss();
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());


            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts, newContacts);

        }

                [Test]
        public void ContactRemovalTest_card()
        {
            ContactData contact = new ContactData("First", "Last");
            contact.Middlename = "";
            contact.Address = "";
            contact.Bday = "8";
            contact.Bmonth = "July";
            contact.Aday = "8";
            contact.Amonth = "July";
            contact.New_group = "[none]";
            contact.Address = "address 11";
            contact.Home = "+9(000)5к65767+111";
            contact.Work = "9(bvggvn)--11";
            contact.Mobile = "0(45567)-565-65756-76-7";
            contact.Email = "mail11@ee.ru";
            contact.Email2 = "mail22@.ru";
            contact.Email3 = "33@33.ru";

            app.Contacts.CheckContactCreate(contact);


            List<ContactData> oldContacts = app.Contacts.GetContactList();


            app.Contacts.Remove_FromCard();
            app.Navigator.GoToHomePage();

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());


            List<ContactData> newContacts = app.Contacts.GetContactList();
                       
            oldContacts.RemoveAt(0);
           
            Assert.AreEqual(oldContacts, newContacts);
        }

         */

    }
}
