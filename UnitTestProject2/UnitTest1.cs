using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeTask12;
namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Form1 form1 = new Form1();

            Form1.size = 10;
            form1.Make_Arrays();
            form1.Make_Sorts(0);
            form1.Make_Sorts(1);
            form1.Make_Sorts(2);

            Form1.size = 50;
            form1.Make_Arrays();
            form1.Make_Sorts(0);
            form1.Make_Sorts(1);
            form1.Make_Sorts(2);

            Form1.size = 100;
            form1.Make_Arrays();
            form1.Make_Sorts(0);
            form1.Make_Sorts(1);
            form1.Make_Sorts(2);
        }
    }
}
