﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;



namespace WebAddressbookTests
{
    [TestFixture]

public class SearchTests : AuthTestBase

    {
        [Test]

        public void TestSearch()
        {

            System.Console.Out.Write(app.Contacts.GetNumberOfSearchResults());

        }



    }




}    