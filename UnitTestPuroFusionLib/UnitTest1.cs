using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PuroFusionLib;

namespace UnitTestPuroFusionLib
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string strExpectedVal = PuroReportingServiceClass.strRetCodeOK;
            PuroReportingServiceClass o = new PuroReportingServiceClass(PuroReportingServiceClass.ConnString.PatientLocal);
            string result = o.TestConn();

            Assert.AreEqual(strExpectedVal,result);
        }
    }
}
