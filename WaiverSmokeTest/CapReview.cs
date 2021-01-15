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

namespace Smocktest
{
    class CapReview
    {
        Form1 f = new Form1();

        WaiverSmokeTest.SearchT SearchP = new WaiverSmokeTest.SearchT();
        
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

        public IWebDriver CapicityReview(IWebDriver driver, string IID, string Env,bool startfromcapreview)
        {
            if (startfromcapreview || Env.ToUpper() == "EXPL" || Env.ToUpper() == "DEV3" || Env.ToUpper() == "DEV5"|| Env.ToUpper() == "DEV2")
            {
                if (startfromcapreview)
                {
                    driver.Url = "https://" + Env + ".kywaiver.chfsinet.ky.gov";
                    driver.Manage().Window.Maximize();
                }
                if (IsElementPresent(driver, By.Id("ContentPlaceHolder2_LoginButton")))
                {
                    driver.FindElement(By.Id("ContentPlaceHolder2_LoginButton")).Click();

                }

                if (!IsElementPresent(driver, By.Name("Accept")))
                {
                    if (IsElementPresent(driver, By.Id("ContentPlaceHolder1_lbtnBackToRealm")))
                    {
                        driver.FindElement(By.Id("ContentPlaceHolder1_lbtnBackToRealm")).Click();
                    }
                    if (IsElementPresent(driver, By.Id("ContentPlaceHolder1_InternalUserWithEmailAddressPlaceHolder")))
                    {
                        driver.FindElement(By.Id("ContentPlaceHolder1_InternalUserWithEmailAddressPlaceHolder")).Click();
                    }
                    else
                    {
                        driver.FindElement(By.Id("InternalUserWithEmailAddress")).Click();
                        driver.FindElement(By.Id("InternalUserWithEmailAddress")).Click();
                        driver.FindElement(By.ClassName("button")).Click();
                    }
                    if (Env.ToUpper() != "EXPL")
                    {
                        driver.FindElement(By.Id("ContentPlaceHolder1_txtUsername")).SendKeys(Env.ToUpper() + "_CMAWC_ADMIN_01");
                    }
                    else
                    {
                        driver.FindElement(By.Id("ContentPlaceHolder1_txtUsername")).SendKeys("dev_mwma_cmaint_01");
                    }
                    driver.FindElement(By.Id("ContentPlaceHolder1_txtPassword")).SendKeys("Pa$$w0rd.1");
                    driver.FindElement(By.Id("ContentPlaceHolder1_SubmitButton")).Click();
                }

                if (IsElementPresent(driver, By.XPath("//*[@id=\"myAppsContent\"]/div[3]/div/div/div[3]/button")))
                {
                    driver.FindElement(By.XPath(" //*[@id=\"myAppsContent\"]/div[3]/div/div/div[3]/button")).Click();
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    driver.Url = "https://" + Env + ".kywaiver.chfsinet.ky.gov";
                }
                driver.Url = "https://" + Env + ".kywaiver.chfsinet.ky.gov";
                driver.FindElement(By.Name("Accept")).Click();
                Thread.Sleep(2000);
            }
            Thread.Sleep(3000);
            SearchP.SearchTask(driver, IID);

            Thread.Sleep(3000);
            if (IsElementPresent(driver, By.LinkText("Start")))
            {
                driver.FindElement(By.LinkText("Start"), 100);
                Thread.Sleep(3000);
                driver.FindElement(By.LinkText("Start")).Click();
            }
            else if((IsElementPresent(driver, By.LinkText("Continue"))))
            {
                driver.FindElement(By.LinkText("Continue"), 100);
                Thread.Sleep(3000);
                driver.FindElement(By.LinkText("Continue")).Click();
            }
            Thread.Sleep(3000);
            
            driver.FindElement(By.Id("btnNext"), 100);
            driver.FindElement(By.Id("btnNext")).Click();
            driver.FindElement(By.Id("Services"), 100);
            driver.FindElement(By.XPath("//*[@id=\"Services\"]/a")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.Id("btnNext")).Click();

            driver.FindElement(By.Id("btnNext")).Click();
            driver.FindElement(By.Id("btnNext")).Click();
            driver.FindElement(By.Id("btnNext")).Click();
            driver.FindElement(By.Id("btnNext")).Click();
            driver.FindElement(By.Id("btnNext"), 100);
            Thread.Sleep(1000);
            driver.FindElement(By.Id("btnNext")).Click();
            driver.FindElement(By.Id("IsVerificationNeeded[1]")).Click();
           driver.FindElement(By.Id("IsWaiverCriteriaMet[0]")).Click();
           string date = driver.FindElement(By.XPath("//*[@id=\"dvApplicationDate table-row\"]/div[3]")).Text;
            if (IsElementPresent(driver, By.Id("rdbIsIndividualHasRespondentNetwork[1]")))
            {
                driver.FindElement(By.Id("rdbIsIndividualHasRespondentNetwork[1]")).Click();
            }

            driver.FindElement(By.Id("btnSave")).Click();
            if (IsElementPresent(driver, By.XPath("//*[@id=\"tasklisttable\"]/div/div[3]/div/a/span")))
            {
                driver.FindElement(By.XPath("//*[@id=\"tasklisttable\"]/div/div[3]/div/a/span")).Click();
                // string date = (DateTime.Today.Date.Month.ToString().PadLeft(2, '0') + DateTime.Today.Date.Day.ToString().PadLeft(2, '0') + DateTime.Today.Date.Year.ToString().PadLeft(2, '0')).ToString();
                driver.FindElement(By.XPath("//*[@id=\"dpRequestDate\"]")).Click();
                driver.FindElement(By.XPath("//*[@id=\"dpRequestDate\"]")).SendKeys(date);

                Thread.Sleep(3000);

                driver.FindElement(By.Id("ddlUrgency")).Click();
                {
                    SelectDropDown(driver, By.Id("ddlUrgency"), "EM");
                }
                driver.FindElement(By.Id("ddlUrgency")).Click();
                driver.FindElement(By.Id("btnSave")).Click();
            }
            if (IsElementPresent(driver, By.Id("DocumentTypeCode")))
            {
                driver.FindElement(By.Id("DocumentTypeCode")).Click();
                {
                    SelectDropDown(driver, By.Id("DocumentTypeCode"), "PHYLET");

                }
                driver.FindElement(By.Id("DocumentTypeCode")).Click();
                IWebElement fileInput = driver.FindElement(By.Id("File"));
                fileInput.SendKeys(ConfigurationManager.AppSettings.Get("filepath"));
                driver.FindElement(By.XPath("//*[@id=\"docUpload\"]/div/div/div[2]/div/div[4]/div[3]/div/div[2]/input"), 100);
                driver.FindElement(By.XPath("//*[@id=\"docUpload\"]/div/div/div[2]/div/div[4]/div[3]/div/div[2]/input")).Click();
                Thread.Sleep(4000);
            }
            driver.FindElement(By.Id("btnNext")).Click();
            driver.FindElement(By.Id("ddlWaiverCapacityActions")).Click();
            {
                SelectDropDown(driver, By.Id("ddlWaiverCapacityActions"), "RE");

            }
            driver.FindElement(By.Id("ddlWaiverCapacityActions")).Click();
        
            driver.FindElement(By.Id("ddlCapacityCategoryCode")).Click();
            {
                SelectDropDown(driver, By.Id("ddlCapacityCategoryCode"), "RE");
            }
            driver.FindElement(By.Id("ddlCapacityCategoryCode")).Click();
            driver.FindElement(By.Id("txtComments")).Click();
            driver.FindElement(By.Id("txtComments")).SendKeys("test");
            driver.FindElement(By.Id("btnSave")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("btnDone")).Click();
            
            Thread.Sleep(3000);
            driver.Url = "https://" + Env + ".kywaiver.chfsinet.ky.gov/SelfService/SignOutConfirmation";
            Thread.Sleep(3000);
            driver.Url = "https://" + Env + ".kywaiver.chfsinet.ky.gov/SelfService/SignOutConfirmation";

            driver.FindElement(By.Name("Logout")).Click();
            return driver;
        }
    }
}
