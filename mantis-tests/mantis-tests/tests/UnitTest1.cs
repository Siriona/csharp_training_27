﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace mantis_tests
{
  
    [TestFixture]
    public class UnitTest1: TestBase
    {
        

        [Test]
        public void TestMethod1()
        {
            AccountData account = new AccountData()
            {
                Name = "xxxx",
                Password = "yyyy"
            };

            Assert.IsFalse(app.James.Verify(account));
            app.James.Add(account);
            Assert.IsTrue(app.James.Verify(account));
            app.James.Delete(account);
            Assert.IsFalse(app.James.Verify(account));

        }
    }
}
