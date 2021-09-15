using NUnit.Framework;
using OpenQA.Selenium;

namespace Facebook_DataDrivenFramework
{
    public class ReadFromExcel:Base.BaseClass
    {
        [Test]
        public void ReadingData()
        {

            ExcelOperations.PopulateInCollection(@"C:\Users\girish.v\source\repos\Facebook_DataDrivenFramework\Facebook_DataDrivenFramework\ExcelData\TestData.xlsx");
            driver.FindElement(By.Name("email")).SendKeys(ExcelOperations.ReadData(1, "email"));
            System.Threading.Thread.Sleep(1000);

            driver.FindElement(By.Name("pass")).SendKeys(ExcelOperations.ReadData(1, "password"));
            System.Threading.Thread.Sleep(1000);

            driver.FindElement(By.Name("login")).Click();
            System.Threading.Thread.Sleep(1000);

            System.Threading.Thread.Sleep(1000);
        }
    }
}
