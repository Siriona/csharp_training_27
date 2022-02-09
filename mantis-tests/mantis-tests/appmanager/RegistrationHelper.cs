﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class RegistrationHelper: HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();

        }         

        public void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.25.2/login_page.php";

        }

        public void OpenRegistrationForm()
        {
            driver.FindElement(By.XPath("//a[@href= 'signup_page.php']")).Click();
        }

        public void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);


        }

        public void SubmitRegistration()
        {
            driver.FindElement(By.XPath("//input[@type= 'submit']")).Click();
        }

    }
}
