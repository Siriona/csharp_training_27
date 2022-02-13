using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using SimpleBrowser.WebDriver;


namespace mantis_tests
{
    public class AdminHelper: HelperBase
    {
        private string baseURL;

        public AdminHelper(ApplicationManager manager, string baseURL) : base(manager) 
        {
            

            this.baseURL = baseURL;
        }

        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> accounts = new List<AccountData>();

            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL+ "/manage_user_page.php";
            IList<IWebElement> rows = driver.FindElements(By.XPath("//table[@class='table table-striped table-bordered table-condensed table-hover']/tbody/tr/td/a"));
            foreach (IWebElement row in rows)
            {
                // IWebElement link = row.FindElement(By.TagName("a"));
                string name = row.Text;
                string href = row.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;

                accounts.Add(new AccountData()
                {
                    Name = name,
                    Id = id

                }
                    );
            }
            return accounts;
        }

        public void DeleteAccount (AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "/manage_user_edit_page.php?user_id=" + account.Id;
            driver.FindElement(By.CssSelector("input[value=''Удалить учётную запись]")).Click();
            driver.FindElement(By.XPath("//input[@value = 'Удалить учётную запись']")).Click(); //confitm deleting on page /manage_user_delete.php

        }

        private IWebDriver OpenAppAndLogin()
        {
            IWebDriver driver = new SimpleBrowserDriver();
        //         driver.Url = baseURL + "/login_page.php";
            driver.Url = baseURL + "/login_page.php";

        
            driver.FindElement(By.Id("username")).SendKeys("administrator");
            driver.FindElement(By.XPath("//input[@type= 'submit']")).Click();
            driver.FindElement(By.Id("password")).SendKeys("root");
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        

            return driver;

        }
    }
}
