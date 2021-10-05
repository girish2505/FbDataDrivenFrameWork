using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Facebook_DataDrivenFramework.Pages
{
    public class Search
    {
        public Search(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/label[1]/input[1]")]
        [CacheLookup]
        public IWebElement search;
    }
}
