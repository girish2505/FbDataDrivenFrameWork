using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook_DataDrivenFramework.DoAction
{
    public class Action
    {
        public static void AssertAfterLauching(IWebDriver driver)
        {
            string title1 = "Facebook – log in or sign up";
            string title = driver.Title;
            Assert.AreEqual(title1, title);
        }

        public static void LoginToFaceBook(IWebDriver driver)
        {
            driver.FindElement(By.Name("email")).SendKeys(ExcelOperations.ReadData(1, "email"));
            System.Threading.Thread.Sleep(3000);

            driver.FindElement(By.Id("pass")).SendKeys(ExcelOperations.ReadData(1, "password"));
            System.Threading.Thread.Sleep(3000);

            driver.FindElement(By.Name("login")).Click();
            System.Threading.Thread.Sleep(10000);
        }
    }
}
