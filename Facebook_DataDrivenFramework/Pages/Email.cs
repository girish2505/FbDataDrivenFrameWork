using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Facebook_DataDrivenFramework.Pages
{
    public class Email
    {
        public static ExcelForMail excel;

        public static void ReadDataFromExcel(IWebDriver driver)
        {
            excel = new ExcelForMail();
            excel.PopulateInCollection(@"C:\Users\girish.v\source\repos\Facebook_DataDrivenFramework\Facebook_DataDrivenFramework\ExcelData\EmailData.xlsx");
        }
        public static void SendMail(IWebDriver driver)
        {
            excel = new ExcelForMail();
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(excel.ReadData(1, "FromMail"));

            mail.To.Add(excel.ReadData(1, "ToMail"));

            mail.Subject = "Facebook Automation Test Report";

            mail.Body = "Facebook Automation Test report attachmement";

            Attachment attachment;

            attachment = new Attachment(@"C:\Users\girish.v\source\repos\Facebook_DataDrivenFramework\Facebook_DataDrivenFramework\report\index.html");
            Assert.NotNull(attachment);

            mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;

            SmtpServer.Credentials = new NetworkCredential(excel.ReadData(1, "FromMail"), excel.ReadData(1, "Password"));

            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}
