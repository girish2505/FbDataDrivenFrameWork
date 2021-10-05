using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook_DataDrivenFramework
{
    [TestFixture("chrome")]
    //[TestFixture("firefox")]
    //[Parallelizable(ParallelScope.Fixtures)]
    class FacebookTC:Base.BaseClass
    {
        public FacebookTC(string browser) : base(browser) { }
        ExtentReports reports = ReportClass.Report();
        ExtentTest test;
        [Test]
        public void Login()
        {
            test = reports.CreateTest("Tests");
            test.Log(Status.Info, "Automating facebook Login PAge");

            DoAction.Action.LoginToFaceBook(driver);
            Takescreenshot();

            test.Info("ScreenShot", MediaEntityBuilder.CreateScreenCaptureFromPath(@"C:\Users\girish.v\source\repos\Facebook_DataDrivenFramework\Facebook_DataDrivenFramework\screenshot\text1.png").Build());
            test.Log(Status.Pass, "Test PAsses");
            reports.Flush();
        }
        [Test]
        public void Search()
        {
            DoAction.Action.LoginToFaceBook(driver);
            DoAction.Action.Searchkey(driver);
            Takescreenshot();
        }
        [Test]
        public void UploadPhoto()
        {
            test = reports.CreateTest("Tests");
            test.Log(Status.Info, "Automating facebook and uploading photo");

            DoAction.Action.LoginToFaceBook(driver);
            DoAction.Action.UploadPhoto(driver);
            Takescreenshot();

            test.Info("ScreenShot", MediaEntityBuilder.CreateScreenCaptureFromPath(@"C:\Users\girish.v\source\repos\Facebook_DataDrivenFramework\Facebook_DataDrivenFramework\screenshot\text2.png").Build());
            test.Log(Status.Pass, "Test PAsses");
            reports.Flush();
        }

        [Test]
        public void Logout()
        {
            DoAction.Action.LoginToFaceBook(driver);
            DoAction.Action.Logout(driver);
        }

        [Test]
        public void Sendmail()
        {
            driver.Url = "https://accounts.google.com/ServiceLogin/identifier?";
            Pages.Email.ReadDataFromExcel(driver);
            Pages.Email.SendMail(driver);
        }
    }
}
