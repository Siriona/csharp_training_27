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
    public class NavigationHelper : HelperBase
    {

        private string baseURL;
        private string groupURL;


        public NavigationHelper(ApplicationManager manager, string baseURL, string groupURL)
            : base(manager)
        {
            this.baseURL = baseURL;
            this.groupURL = groupURL;


        }

        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ReturnGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void ReturnHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }

        public void OpenCertainGroupPage(string groupID)
        {
            driver.Navigate().GoToUrl(groupURL + groupID);
        }


    }
}
