using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;

namespace WaiverSmokeTest
{
    class SearchT
    {

        private bool IsElementPresent(IWebDriver driver, By by)
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
        private void SelectDropDown(IWebDriver driver, By by, String selectoption)
        {
            var dropdown = driver.FindElement(by);
            var selectElement = new SelectElement(dropdown);
            selectElement.SelectByValue(selectoption);

        }

        public IWebDriver SearchTask(IWebDriver driver, string IID)
        {
            Thread.Sleep(2000);

            driver.FindElement(By.LinkText("Search Tasks")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.Id("btnLookUp")).Click();
            Thread.Sleep(6000);
            driver.FindElement(By.Id("IdentifierValue")).Click();
            driver.FindElement(By.Id("IdentifierValue")).SendKeys(IID);
            driver.FindElement(By.Id("IdentifierType")).Click();
            {
                SelectDropDown(driver, By.Id("IdentifierType"), "INDVID");
            }
            try
            {

                driver.FindElement(By.Id("IdentifierType")).Click();
            }
            catch(NoSuchElementException)
            {
                Thread.Sleep(2000);
                if(IsElementPresent(driver, By.Id("IdentifierType")))
                {
                    driver.FindElement(By.Id("IdentifierType")).Click();

                }
            }
            Thread.Sleep(2000);
            driver.FindElement(By.Id("btnSearchIndivIdualLookUp")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id(IID)).Click();
            driver.FindElement(By.Id("btnSelect2")).Click();
            driver.FindElement(By.Id("btnSearchRecord")).Click();
            Thread.Sleep(3000);
            while (IsElementPresent(driver, By.ClassName("field-validation-error")))
            {
                Thread.Sleep(2000);
              SearchTaskdelay(driver, IID);
            }

            return driver;
        }


        public IWebDriver SearchTaskdelay(IWebDriver driver, string IID)
        {
            Thread.Sleep(2000);
            
            driver.FindElement(By.Id("btnLookUp")).Click();
            Thread.Sleep(6000);
            driver.FindElement(By.Id("IdentifierValue")).Click();
            driver.FindElement(By.Id("IdentifierValue")).SendKeys(IID);
            driver.FindElement(By.Id("IdentifierType")).Click();
            {
                SelectDropDown(driver, By.Id("IdentifierType"), "INDVID");
            }
            driver.FindElement(By.Id("IdentifierType")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("btnSearchIndivIdualLookUp")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.Id(IID)).Click();
            driver.FindElement(By.Id("btnSelect2")).Click();
            driver.FindElement(By.Id("btnSearchRecord")).Click();
            Thread.Sleep(3000);
            return driver;
        }



    }
}
