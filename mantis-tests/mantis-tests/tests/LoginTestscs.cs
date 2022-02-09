using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace mantis_tests
{

    [TestFixture]
    public class LoginTests : TestBase
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
        public void TestLogin()
        {
            AccountData account = new AccountData()
            {

                Name = "administrator",
                Password = "root",

            };

            app.Login.Logout();

            app.Login.Login(account);

        }



    }
}
