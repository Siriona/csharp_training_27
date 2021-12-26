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
    public class GroupHelper : HelperBase
    {


        public GroupHelper(ApplicationManager manager) : base(manager)
        {

        }

        

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            StartNewGroupCreation();
            FillGroupEditForm(group);
            SubmitGroupCreation();
            manager.Navigator.GoToGroupsPage();

            return this;


        }

        public GroupHelper Modify(GroupData newData, GroupData group) // newData and group together - for ability to use different names for creating and modifying 
        {
            manager.Navigator.GoToGroupsPage();
            CheckGroupCreate(group);
            SelectGroup_2();
            InitGroupModification();
            FillGroupEditForm(newData);
            SubmitGroupModification();
            manager.Navigator.GoToGroupsPage();

            return this;

        }

        public GroupHelper CheckGroupCreate(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            if (!GroupIsPresent())
            {
                Create(group);

            }

            return this;

        }



    


        public GroupHelper Remove_2(GroupData group) 
        {
            manager.Navigator.GoToGroupsPage();

            CheckGroupCreate(group);
            SelectGroup_2();
            RemoveGroup();
            manager.Navigator.GoToGroupsPage();
            return this;


        }

        public bool GroupIsPresent()
        {
            return IsElementPresent(By.Name("selected[]"));

        }

        public GroupHelper StartNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupEditForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);

            return this;

        }

        

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;

        }




        public GroupHelper SelectGroup_2()
        {
            driver.FindElement(By.Name("selected[]")).Click();
            return this;

        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;

        }


        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }


        // if needs to remove/modify certain group, not the first only
        /*
        
        
        
        /*public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
            return this;

        }
        
        
      



        public GroupHelper Remove(int p) 
        {
            manager.Navigator.GoToGroupsPage();
               
            
                SelectGroup(p);
                RemoveGroup();
                manager.Navigator.GoToGroupsPage();
            


                
            return this;


        }
        */

    }
}
