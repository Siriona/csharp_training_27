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

        public ContactHelper ModifyByPencil(int index, ContactData newData)
        {
            OpenEditFormByPencil(index);
            FillContactInfo(newData, true);
            SubmitContactModification();
            manager.Navigator.ReturnHomePage();
            return this;

        }

        public ContactHelper ModifyFromCard(int indexCard, ContactData newData)
        {
            OpenContactCard(indexCard);
            OpenMofidicationFromCard();
            FillContactInfo(newData, true);
            SubmitContactModification();
            manager.Navigator.ReturnHomePage();
            return this;
        }

        public ContactHelper ContactChangeGroup(string indexContact, string newGroup)
        {
            SelectContact(indexContact);
            ChooseNewGroup(newGroup);
            MovetoNewGroup();
            return this;
        }


        public ContactHelper SelectContact(string indexContact)
        {

            driver.FindElement(By.Id(indexContact)).Click();
            return this;
        }

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

        public ContactHelper OpenContactCard(int indexCard)
        {

            driver.FindElement(By.CssSelector("[href*='view.php?id=" + indexCard + "']")).Click();
            return this;
        }

        public ContactHelper OpenMofidicationFromCard()
        {

            driver.FindElement(By.Name("modifiy")).Click();
            return this;
        }

        public ContactHelper OpenEditFormByPencil(int index)
        {
            driver.FindElement(By.CssSelector("[href*='edit.php?id=" + index + "']")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

     
        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;

        }

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
            //   driver.FindElement(By.Name("photo")).Click();
            //   driver.FindElement(By.Name("photo")).Clear();
            //   driver.FindElement(By.Name("photo")).SendKeys("C:\\fakepath\\test.png");
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
            //   driver.FindElement(By.XPath(contact.Bday_path)).Click();
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            //  driver.FindElement(By.XPath(contact.Bmonth_path)).Click();
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(contact.Byear);
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            //  driver.FindElement(By.XPath("//div[@id='content']/form/select[3]/option[3]")).Click();
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
            //  driver.FindElement(By.XPath("//div[@id='content']/form/select[4]/option[3]")).Click();
            driver.FindElement(By.Name("ayear")).Click();
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys(contact.Ayear);
            if (!skipGroup)
            {
                driver.FindElement(By.Name("new_group")).Click();
                new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText(contact.New_group);
            }
            //   driver.FindElement(By.XPath("//div[@id='content']/form/select[5]/option[2]")).Click();
            driver.FindElement(By.Name("address2")).Click();
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys(contact.Address2);
            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys(contact.Phone2);
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(contact.Notes);
            return this;

        }


        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;

        }
    }
}
