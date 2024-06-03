using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFrameworkCore.Helper;

[assembly:Parallelize(Workers =3, Scope = ExecutionScope.MethodLevel)]
namespace Selenium_Day2.Test
{
    [TestClass]
    public class AssemblyTest
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext TestContext)
        {
            BaseTest.ReportHelper = new ReportHelper();
        }
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            if (BaseTest.ReportHelper != null)
            {
                BaseTest.ReportHelper.ExportReport();
            }
        }


    }
}
