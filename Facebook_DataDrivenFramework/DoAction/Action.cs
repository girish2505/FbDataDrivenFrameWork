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
            LogIn login = new LogIn(driver);

            login.email.SendKeys(ExcelOperations.ReadData(1, "email"));
            System.Threading.Thread.Sleep(1000);

            login.password.SendKeys(ExcelOperations.ReadData(1, "password"));
            System.Threading.Thread.Sleep(1000);

            login.loginBt.Click();
            System.Threading.Thread.Sleep(1000);
        }
        public static void SearchKey(IWebDriver driver)
        {
            IWebElement MyElement = driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/label[1]/input[1]"));
            MyElement.SendKeys(Keys.NumberPad7); MyElement.SendKeys(Keys.Down);
            MyElement.SendKeys(Keys.Enter);
        }
    }
}
