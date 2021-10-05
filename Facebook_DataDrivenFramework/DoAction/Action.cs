using NUnit.Framework;
using OpenQA.Selenium;
using AutoItX3Lib;
using Facebook_DataDrivenFramework.Pages;
using System;

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
            ExcelOperations.PopulateInCollection(@"C:\Users\girish.v\source\repos\Facebook_DataDrivenFramework\Facebook_DataDrivenFramework\ExcelData\TestData.xlsx");
            LogIn login = new LogIn(driver);

            login.email.SendKeys(ExcelOperations.ReadData(1, "email"));
            System.Threading.Thread.Sleep(1000);

            login.password.SendKeys(ExcelOperations.ReadData(1, "password"));
            System.Threading.Thread.Sleep(1000);

            login.loginBt.Click();
            System.Threading.Thread.Sleep(1000);

            Assert.AreEqual(driver.Url, "https://www.facebook.com/?sk=welcome");
            try
            {
                Console.WriteLine("Successfull logg in");
            }
            catch
            {
                Console.WriteLine("Failed");
            }
        }

        public static void UploadPhoto(IWebDriver driver)
        {
            AutoItX3 autoIt = new AutoItX3();
            UploadPhoto upload = new UploadPhoto(driver);
            upload.home.Click();

            string expected = "Find Friends";
            string actual = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div/div[3]/div/div/div[1]/div[1]/div/div[1]/div/div/div[1]/div/div/div[1]/div[1]/ul/li[1]/div/a/div[1]/div[2]/div")).Text;
            Console.WriteLine(" Meassage: {0}", actual);
            Assert.AreEqual(expected, actual);

            try
            {
                Console.WriteLine("Successfull");
            }
            catch
            {
                throw new CustomException(CustomException.ExceptionType.NoSuchElement, "No such element found");
            }
            System.Threading.Thread.Sleep(1000);

            upload.createPost.Click();
            System.Threading.Thread.Sleep(2000);

            upload.uploadPhoto.Click();
            System.Threading.Thread.Sleep(1000);

            upload.addPhoto.Click();
            System.Threading.Thread.Sleep(1000);

            autoIt.WinActivate("Open");

            autoIt.Send(@"C:\Users\girish.v\Downloads\KSRJ9891.jpg");
            System.Threading.Thread.Sleep(2000);

            autoIt.Send("{Enter}");
            System.Threading.Thread.Sleep(2000);

            upload.post.Click();
            System.Threading.Thread.Sleep(1000);
        }
        public static void Searchkey(IWebDriver driver)
        {
            Search search = new Search(driver);

            search.search.Click();
            System.Threading.Thread.Sleep(1000);

            search.search.SendKeys("Dhoni");

            search.search.SendKeys(Keys.Enter);

        }
        public static void Logout(IWebDriver driver)
        {
            LogOut logout = new LogOut(driver);

            logout.accountBtn.Click();
            System.Threading.Thread.Sleep(1000);

            logout.logOut.Click();
            System.Threading.Thread.Sleep(1000);
        }
    }
}
