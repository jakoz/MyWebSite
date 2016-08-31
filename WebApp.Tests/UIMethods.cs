using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebApp.Tests
{
    public class UIMethods : IDisposable
    {
        public static IWebDriver driver;
        public static string baseUrl;
        public static string date;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                driver = null;
                baseUrl = "";
            }
            // free native resources if there are any.
        }
        public static void Login()
        {
            driver = new ChromeDriver();
            baseUrl = "http://localhost:2034/";
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseUrl);
            if (driver.FindElement(By.Id("btnLogin")) == null)
            {
                driver.FindElement(By.Id("logoutForm")).Click();
            }
            driver.FindElement(By.Id("Email")).SendKeys("mywebsitemaster2016@gmail.com");
            driver.FindElement(By.Id("Password")).SendKeys("Test123$");
            driver.FindElement(By.Id("btnLogin")).Click();
        }

        public static void CreateScheduleWithCurrentDay()
        {
            driver.FindElement(By.Id("lnkSchedule")).Click();
            driver.FindElement(By.Id("createSchedule")).Click();
            driver.FindElement(By.Id("btnSaveSchedule")).Click();
            if (driver.Url.Contains("CreateSchedule"))
            {
                Assert.True(driver.Title.Contains("CreateSchedule"), "Date already exist [VALIDATION]");
                driver.Dispose();

            }

        }
        public static void CheckIfCurrentDayScheduleExistAndCreateIfNot()
        {
            date = DateTime.Now.Date.ToShortDateString();
            driver.FindElement(By.Id("lnkSchedule")).Click();
            if ( !UIMethods.IsElementPresent(By.Id(date)))
            {
                CreateScheduleWithCurrentDay();
            }
            
        }

        public static void CreateTask()
        {
            driver.FindElement(By.Id("btnCreateScheduleTask")).Click();
            driver.FindElement(By.Id("boxHHStart")).SendKeys("12");
            driver.FindElement(By.Id("boxHHStart")).SendKeys("23");
            driver.FindElement(By.Id("boxHHStart")).SendKeys("1");
            driver.FindElement(By.Id("boxHHStart")).SendKeys("13");
            driver.FindElement(By.Id("btnSaveScheduleTask")).Click();
        }

        public static void DiplayListOfSelectedSchedule(string date = null)
        {
            if (date == null)
            {
                date = DateTime.Now.Date.ToShortDateString();
            }
            driver.FindElement(By.Id(date)).Click();
        }

        public static bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
