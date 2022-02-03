using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
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



        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {


                    groupCache.Add(new GroupData(null) {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });

                }

                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupNames.Split('\n');
                int shift = groupCache.Count - parts.Length;
                for (int i = 0; i < groupCache.Count; i++)
                {
                    if (i < shift)
                    {
                        groupCache[i].Name = "";


                    }
                    else
                    {
                        groupCache[i].Name = parts[i - shift].Trim();

                    }


                }
            }



            return new List<GroupData>(groupCache);

        }

        public void CompareGroupsUiDb()
        {

            List<GroupData> fromUi = GetGroupList();
            fromUi.Sort();

            List<GroupData> fromDb = GroupData.GetAll();
            fromDb.Sort();

            Assert.AreEqual(fromUi, fromDb);
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;

        }

        public GroupHelper Modify(GroupData newData) // modify existing first group
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup();
            ModifyGroup(newData);
            manager.Navigator.GoToGroupsPage();

            return this;

        }

        public GroupHelper Modify(GroupData newData, GroupData group) 
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(group.Id);
            ModifyGroup(newData);
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


        public GroupHelper ModifyGroup(GroupData newData) // this method separately from "Modify" in order to use this method for different variants of modifying (e.g. any first group or some specific)
        {
            InitGroupModification();
            FillGroupEditForm(newData);
            SubmitGroupModification();
            return this;

        }


        public GroupHelper SelectGroup() //select existing first group
        {
            driver.FindElement(By.Name("selected[]")).Click();
            return this;

        }


        public GroupHelper SelectGroup(string id) 
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value= '"+id+"'])")).Click();
            return this;

        }


        public GroupHelper Remove()  //remove existing first group
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup();
            RemoveGroup();
            manager.Navigator.GoToGroupsPage();
            return this;


        }

        public GroupHelper Remove(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(group.Id);
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
            groupCache = null;
            return this;

        }





        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
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
            groupCache = null;
            return this;
        }


        // if needs to remove/modify certain group, not the first only
        /*
        
        
        
        /*public GroupHelper SelectGroup_2(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
            return this;

        }
        
        
      



        public GroupHelper Remove_2(int p) 
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
