using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook_DataDrivenFramework.Pages
{
    public class LogOut
    {
        public LogOut(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[4]/div[1]/span[1]/div[1]/div[1]/i[1]")]
        [CacheLookup]
        public IWebElement accountBtn;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Log Out')]")]
        [CacheLookup]
        public IWebElement logOut;
    }
}
