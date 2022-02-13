using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace mantis_tests
{
    
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        /*
        [OneTimeSetUp]
        public void setUpConfig()
        {
            app.Ftp.BackupFile("config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("config_inc.php", localFile);

            }
        }
        */
       

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {

                Name = "testuser7",
                Password = "password",
                Email = "testuser7@localhost.localdomain"

            };

            app.James.Delete(account);
            app.James.Add(account);

            app.Registration.Register(account);

        }

  

    }
}
