using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WebAddressbookTests.tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            double total = 999;
            bool vipClient = true;

            // if (total > 1000 && vipClient) - and
            if (total > 1000 || vipClient)  // - or
            {

                total = total* 0.9;
                System.Console.Out.Write("Discount 10%, Total =" + total);
            }

          /*
            else
            {

                System.Console.Out.Write("No Discount, Total =" + total);



            }
          */ 

        }
    }
}
