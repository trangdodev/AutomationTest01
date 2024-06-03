using AventStack.ExtentReports;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworkCore.Helper.Report
{
    public static class ReportHelperExtension
    {
        public static void LogMessage( this ExtentTest test, string message)
        {
            test.Log(Status.Info, message);
        }

        public static void AddResult(this ExtentTest test, string result)
        {
            if (result.Equals("Passed")) test.Pass("Testcase is passed");
            else test.Fail("Test case is failed");
        }

        public static void AddImageBase64(this ExtentTest test, string base64)
        {
            test.AddScreenCaptureFromBase64String(base64, "Screenshot");
        }
    }
}
