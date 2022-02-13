using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace mantis_tests
{

    [TestFixture]
    public class ProjectTests : AuthBase
    {

      

        [Test]

        public void TestProjectCreationAPI()
        {
            AccountData account = new AccountData()
            {

                Name = "administrator",
                Password = "root",

            };

            ProjectData project = new ProjectData()
            {

                Name = "Project" + " " + DateTime.Now,
                Description = "Test",

            };

            app.API.CreateNewProject(account, project);

        }

        [Test]
        public void TestProjectCreation()
        {
            AccountData account = new AccountData()
            {

                Name = "administrator",
                Password = "root",

            };

            ProjectData project = new ProjectData()
            {

                Name = "Project" + " " + DateTime.Now,
                Description = "Test",

            };

            app.Login.Login(account);
            app.MenuManager.OpenMenuProject();

            List<ProjectData> oldProjects = app.Project.GetProjectList();

            app.Project.Create(project);

            Assert.AreEqual(oldProjects.Count + 1, app.Project.GetProjectCount());

            List<ProjectData> newProjects = app.Project.GetProjectList();

            oldProjects.Add(project);  
            
            oldProjects.Sort();
            newProjects.Sort();
            
            /*
            
            foreach (ProjectData old in oldProjects)
                System.Console.WriteLine($"{old.Name}");

            System.Console.WriteLine("----------------");


            foreach (ProjectData newpr in newProjects)
                System.Console.WriteLine($"{newpr.Name}");

            

            Assert.AreEqual(oldProjects, newProjects);
            */
        }

        [Test]
        public void TestProjectRemovalAPI()
        {
            AccountData account = new AccountData()
            {

                Name = "administrator",
                Password = "root",

            };

            ProjectData project = new ProjectData()
            {

                Name = "Project" + " " + DateTime.Now,
                Description = "Test",

            };

            int projectsCount = app.API.GetProjectsList(account).Length;


            if (projectsCount == 0)
            {
                app.API.CreateNewProject(account, project);
            }

            //here begin old methods wihout API
           

            app.Login.Login(account);
            app.MenuManager.OpenMenuProject();
            List<ProjectData> oldProjects = app.Project.GetProjectList();

            app.Project.Remove();

  
            Assert.AreEqual(oldProjects.Count - 1, app.Project.GetProjectCount());        


            
        }

        [Test]
        public void TestProjectRemoval()
        {
            AccountData account = new AccountData()
            {

                Name = "administrator",
                Password = "root",

            };

            ProjectData project = new ProjectData()
            {

                Name = "Project" + " " + DateTime.Now,
                Description = "Test",

            };

            app.Login.Login(account);
            app.MenuManager.OpenMenuProject();


            if (app.Project.GetProjectCount() == 0)
            {
                app.Project.Create(project);
            }
            List<ProjectData> oldProjects = app.Project.GetProjectList();


            app.Project.Remove();

            Assert.AreEqual(oldProjects.Count - 1, app.Project.GetProjectCount());

            
        }

        [Test]

        public void GetListAPI()
        {
            AccountData account = new AccountData()
            {

                Name = "administrator",
                Password = "root",

            };

            Mantis.ProjectData[] projects = app.API.GetProjectsList(account);

            foreach (Mantis.ProjectData project in projects)
                Console.Out.WriteLine(project.name);

        }

        [Test]

        public void GetList()
        {
            AccountData account = new AccountData()
            {

                Name = "administrator",
                Password = "root",

            };

            ProjectData project = new ProjectData()
            {

                Name = "Project" + " " + DateTime.Now,
                Description = "Test",

            };

            app.Login.Logout();
            app.Login.Login(account);
            app.MenuManager.OpenMenuProject();
            app.Project.GetProjectList();
            app.Project.GetProjectCount();


        }







    }
}
