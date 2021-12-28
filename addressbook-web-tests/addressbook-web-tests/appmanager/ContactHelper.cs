using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        /*
        ---------------------------------------
        "Operations" with contacts - for tests
        ---------------------------------------
        */


        public ContactHelper(ApplicationManager manager) : base(manager)
        {

        }

        public ContactHelper Create(ContactData contact)
        {
            AddNewContact();
            FillContactInfo(contact);
            SubmitContactCreation();
            return this;

        }



        public ContactHelper ModifyByPencil(ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            OpenEditFormByPencil_2();
            EditContactInfo(newData);
            manager.Navigator.GoToHomePage();


            return this;

        }
          

       

        public ContactHelper ModifyFromCard(ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            OpenContactCard_2();
            OpenMofidicationFromCard();
            EditContactInfo(newData);
            manager.Navigator.GoToHomePage();
            return this;
        }





        public ContactHelper Remove_FromHomePage()
        {
            manager.Navigator.GoToHomePage();
            SelectContact_2();
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();

            return this;
        }

   
        

        public ContactHelper Remove_FromCard()
        {
            manager.Navigator.GoToHomePage();
            OpenContactCard_2();
            OpenMofidicationFromCard();
            driver.FindElement(By.XPath("//div[@id='content']/form[2]/input[2]")).Click();
            return this;
        }
        

        /*
        -----------------------------------
        "Base" contact methods  
        -----------------------------------
        */

        // Methods - Select and Opening pages

        public bool ContactIsPresent()
        {
            return IsElementPresent(By.Name("entry"));

        }

        public ContactHelper SelectContact_2()
        {
            manager.Navigator.GoToHomePage();

            driver.FindElement(By.Name("selected[]")).Click();
            return this;
        }

        
        public ContactHelper OpenContactCard_2()
     
        {
            manager.Navigator.GoToHomePage();

            driver.FindElement(By.XPath("//img[@title= 'Details']")).Click();
            return this;
        }


        // Methods - Creating

        public ContactHelper CheckContactCreate(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            if (!ContactIsPresent())
            {
                Create(contact); 

            }

            return this;

        }

        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;

        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;

        }

        // Methods - Modifications

        public ContactHelper OpenMofidicationFromCard()
        {

            driver.FindElement(By.Name("modifiy")).Click();
            return this;
        }

        public ContactHelper OpenEditFormByPencil_2()

        
        {
            manager.Navigator.GoToHomePage();

            driver.FindElement(By.XPath("//img[@title= 'Edit']")).Click();
            return this;
        }


        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper EditContactInfo(ContactData newData)
        {
            FillContactInfo(newData, true);
            SubmitContactModification();
            return this;
        }



        // Methods - Removing




        public ContactHelper Remove_accept()
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            return this;
        }

        public ContactHelper Remove_dismiss()
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Dismiss();
            return this;
        }

        
        // Methods - Filling info     

        public ContactHelper FillContactInfo(ContactData contact, bool skipGroup = false)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(contact.Title);
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(contact.Company);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(contact.Home);
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(contact.Mobile);
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(contact.Work);
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(contact.Fax);
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(contact.Email);
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(contact.Email2);
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(contact.Email3);
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(contact.Homepage);
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(contact.Byear);
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
            driver.FindElement(By.Name("ayear")).Click();
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys(contact.Ayear);


            /* ------------------ 
            Condition 
            - to choose if you need to fill group fields (for new contact) or not (for edit old contacts), because "add new" and "edit" forms are little different
            skipGroup = false -> for "add new" (default)
            skipGroup = true - > for "edit"
             */

            if (!skipGroup)
            {
                driver.FindElement(By.Name("new_group")).Click();
                new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText(contact.New_group);
            }

            // ------------------

            driver.FindElement(By.Name("address2")).Click();
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys(contact.Address2);
            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys(contact.Phone2);
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(contact.Notes);
            return this;

        }


        /*

    // Methods - Change groups

    public ContactHelper ChooseNewGroup(string newGroup)
    {
        new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(newGroup);
        return this;
    }


    public ContactHelper MovetoNewGroup()
    {

        driver.FindElement(By.Name("add")).Click();
        return this;
    }


    public ContactHelper ReturnGroupPageAfterChanging(int groupPage)
    {

        driver.FindElement(By.CssSelector("[href*='./?group=" + groupPage + "']")).Click();
        return this;
    }


    public ContactHelper ReturnGroupPageAfterChanging_2(string groupName)
    {

        driver.FindElement(By.LinkText("group page " + groupName + "")).Click();
        return this;
    }



         // 1st variant of opening group page - by CssSelector
    public ContactHelper ContactChangeGroup(int numberContact, string newGroup, int groupPage)
    {
      //  SelectContact(numberContact);
        ChooseNewGroup(newGroup);
        MovetoNewGroup();
        ReturnGroupPageAfterChanging(groupPage);
        return this;
    }

    // 2nd variant of opening group page - by LinkText
    public ContactHelper ContactChangeGroup_2(int numberContact, string newGroup, string groupName)
    {
      //  SelectContact(numberContact);
        ChooseNewGroup(newGroup);
        MovetoNewGroup();
        ReturnGroupPageAfterChanging_2(groupName);
        return this;
    }



    // open editing from certain group page - by pencil
    public ContactHelper ModifyContactFromGroupPage_pencil(string groupID, int index, ContactData newData)
    {

        manager.Navigator.OpenCertainGroupPage(groupID);
        OpenEditFormByPencil(index);
        FillContactInfo(newData, true);
        SubmitContactModification();
        manager.Navigator.ReturnHomePage();
        return this;
    }


   -----------------





      public ContactHelper SelectContact(int indexContact)
    {

        // contacts begin from 2nd line in table => 1st contact = tr [2] 
        driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + indexContact + "]/td/input")).Click();
        return this;
    }



     public ContactHelper Remove_home(int indexContact)
    {
        manager.Navigator.GoToHomePage();

        SelectContact(indexContact);
        driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
        return this;
    }

  

        public ContactHelper OpenContactCard(int indexCard)
        // 1st contact = 2 line, 7 column
        // 2nd contact = 3 line, 7 column, etc. 
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + indexCard + "]/td[7]")).Click();

            //  driver.FindElement(By.CssSelector("[href*='view.php?id=" + indexCard + "']")).Click();
            return this;
        }


        public ContactHelper OpenEditFormByPencil(int index)

        // 1st contact = 2 line, 8 column
        // 2nd contact = 3 line, 8 column, etc. 
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td[8]")).Click();
            return this;
        }


          */
    }
}
