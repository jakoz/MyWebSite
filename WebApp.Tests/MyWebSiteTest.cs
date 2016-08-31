using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Xunit;
using OpenQA.Selenium.Chrome;

namespace WebApp.Tests
{
    public class MyWebSiteTest
    {
        [Fact]
        public void Login()
        {
            UIMethods.Login();
            IWebDriver driver = UIMethods.driver;
            Assert.Equal(UIMethods.baseUrl + "MainPage/Main", driver.Url);
            driver.Dispose();
        }

        [Fact]
        public void CreateSchedule()
        {
            UIMethods.Login();
            UIMethods.CreateScheduleWithCurrentDay();
            IWebDriver driver = UIMethods.driver;            
            bool newDateExist = UIMethods.IsElementPresent(By.Id(DateTime.Now.Date.ToShortDateString()));
            Assert.True(newDateExist);
            driver.Dispose();
        }

        [Fact]
        public void CreateScheduleTask()
        {
            UIMethods.Login();
            UIMethods.CheckIfCurrentDayScheduleExistAndCreateIfNot();
            UIMethods.CreateTask();
            
            
        }
    }

}
