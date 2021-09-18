using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook_DataDrivenFramework
{
    class UnitTest:Base.BaseClass
    {
        ExtentReports reports = ReportClass.report();
        ExtentTest test;
        [Test]
        public void ReadingData()
        {
            test = reports.CreateTest("Tests");
            test.Log(Status.Info, "Automating ajio Login PAge");

            ExcelOperations.PopulateInCollection(@"C:\Users\girish.v\source\repos\Facebook_DataDrivenFramework\Facebook_DataDrivenFramework\ExcelData\TestData.xlsx");
            DoAction.Action.LoginToFaceBook(driver);
            DoAction.Action.SearchKey(driver);
            Takescreenshot();

            test.Log(Status.Pass, "Test PAsses");
            reports.Flush();
        }
      
    }
}
