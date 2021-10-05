using log4net;
using log4net.Repository;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Facebook_DataDrivenFramework.Base
{

    public class BaseClass
    {
        public static IWebDriver driver;

        private static readonly ILog log = LogManager.GetLogger(typeof(ITest));

        private static readonly ILoggerRepository repository = log4net.LogManager.GetRepository(Assembly.GetCallingAssembly());

        protected string browser;
        public BaseClass()
        {

        }
        public BaseClass(string browser)
        {
            this.browser = browser;
        }

        [SetUp]
        public void SetUp()
        {
            
            var fileInfo = new FileInfo(@"Log4net.config");

            log4net.Config.XmlConfigurator.Configure(repository, fileInfo);
            try
            {
                switch (browser)
                {

                    case "chrome":
                        
                        ChromeOptions options = new ChromeOptions();
                        options.AddArguments("--disable-notifications");

                        driver = new ChromeDriver(options);
                        break;
                    case "firefox":
                       
                        driver = new FirefoxDriver();
                        break;
                    default:
                        driver = new ChromeDriver();
                        break;
                }

                
                Console.WriteLine(browser + " Started");
                log.Debug("navigating to url");
                log.Info("Entering Setup");

                driver.Manage().Window.Maximize();
                System.Threading.Thread.Sleep(200);
                driver.Url = "https://www.facebook.com/";

                log.Debug("navigating to url");
                log.Info("Exiting setup");

            }
            catch
            {
                Console.WriteLine("Successfull");
            }
        }
        public static void Takescreenshot()
        {
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(@"C:\Users\girish.v\source\repos\Facebook_DataDrivenFramework\Facebook_DataDrivenFramework\screenshot\text.png");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
