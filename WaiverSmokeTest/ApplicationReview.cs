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
    class ApplicationReview
    {
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

        public IWebDriver AppReview(IWebDriver driver, string IID, string Env, bool AppReview, String ProgramCode)
        {
            if (AppReview || Env.ToUpper() == "EXPL" || Env.ToUpper() == "DEV3" || Env.ToUpper() == "DEV5" || Env.ToUpper() == "DEV2")
            {
                if (AppReview)
                {
                    driver.Url = "https://" + Env + ".kywaiver.chfsinet.ky.gov";
                    driver.Manage().Window.Maximize();
                }
                if (IsElementPresent(driver, By.Id("ContentPlaceHolder2_LoginButton")))
                {
                    driver.FindElement(By.Id("ContentPlaceHolder2_LoginButton")).Click();

                }

                if (IsElementPresent(driver, By.Id("ContentPlaceHolder1_lbtnBackToRealm")))
                {
                    driver.FindElement(By.Id("ContentPlaceHolder1_lbtnBackToRealm")).Click();
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
                    { if (IsElementPresent(driver, By.Id("InternalUserWithEmailAddress")))
                        {
                            driver.FindElement(By.Id("InternalUserWithEmailAddress")).Click();
                            driver.FindElement(By.Id("InternalUserWithEmailAddress")).Click();
                            driver.FindElement(By.ClassName("button")).Click();
                        }
                    }
                    if (Env.ToUpper() != "EXPL" && Env.ToUpper() != "DEV3" && Env.ToUpper() != "DEV5" && Env.ToUpper() != "DEV2")
                    {
                        driver.FindElement(By.Id("ContentPlaceHolder1_txtUsername")).SendKeys(Env.ToUpper() + ConfigurationManager.AppSettings.Get("PREre_CMAinternel"));
                    }
                    else
                    {
                        if (Env.ToUpper() == "EXPL")
                        {
                            driver.FindElement(By.Id("ContentPlaceHolder1_txtUsername")).SendKeys(ConfigurationManager.AppSettings.Get("LOCRWR_CMA"));
                        }
                        else if (Env.ToUpper() == "DEV3")
                        {
                            driver.FindElement(By.Id("ContentPlaceHolder1_txtUsername")).SendKeys(ConfigurationManager.AppSettings.Get("LOCRWR_CMA_dev3"));
                        }
                        else if (Env.ToUpper() == "DEV5")
                        {
                            driver.FindElement(By.Id("ContentPlaceHolder1_txtUsername")).SendKeys(ConfigurationManager.AppSettings.Get("LOCRWR_CMA_dev5"));
                        }
                        else if (Env.ToUpper() == "DEV2")
                        {
                            driver.FindElement(By.Id("ContentPlaceHolder1_txtUsername")).SendKeys(ConfigurationManager.AppSettings.Get("LOCRWR_CMA_dev2"));
                        }

                        else
                        {
                            driver.FindElement(By.Id("ContentPlaceHolder1_txtUsername")).SendKeys(ConfigurationManager.AppSettings.Get("Postre_cmainte"));
                        }
                    }
                    if (Env.ToUpper() == "DEV3")
                    {
                        driver.FindElement(By.Id("ContentPlaceHolder1_txtPassword")).SendKeys(ConfigurationManager.AppSettings.Get("LOCRWR_CMA_dev3_password"));
                    }
                    else
                    {
                        driver.FindElement(By.Id("ContentPlaceHolder1_txtPassword")).SendKeys("Pa$$w0rd.1");
                    }

                    driver.FindElement(By.Id("ContentPlaceHolder1_SubmitButton")).Click();

                }
                 if (IsElementPresent(driver, By.XPath(" //*[@id=\"myAppsContent\"]/div[3]/div/div/div[3]/button")))
                {
                    driver.FindElement(By.XPath(" //*[@id=\"myAppsContent\"]/div[3]/div/div/div[3]/button")).Click();
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                }
                if (Env.ToUpper() == "EXPL"|| Env.ToUpper() == "DEV3")
                {
                    driver.SwitchTo().Window(driver.WindowHandles.Last());
                    driver.Url = "https://" + Env + ".kywaiver.chfsinet.ky.gov";
                }
                 driver.FindElement(By.Name("Accept")).Click();
                Thread.Sleep(2000);
            }

            SearchP.SearchTask(driver, IID);
            Thread.Sleep(4000);
            if (IsElementPresent(driver, By.LinkText("Start")))
            {
                driver.FindElement(By.LinkText("Start"), 100);

                driver.FindElement(By.LinkText("Start")).Click();
            }
            else if ((IsElementPresent(driver, By.LinkText("Continue"))))
            {
                driver.FindElement(By.LinkText("Continue"), 100);

                driver.FindElement(By.LinkText("Continue")).Click();
            }
            Thread.Sleep(3000);
            driver.FindElement(By.Id("btnNext"), 100);
            driver.FindElement(By.Id("btnNext")).Click();
            driver.FindElement(By.XPath("//*[@id=\"Services\"]")).Click();
            driver.FindElement(By.Id("btnNext")).Click();
            driver.FindElement(By.Id("btnNext")).Click();
            driver.FindElement(By.Id("btnNext")).Click();
            driver.FindElement(By.Id("btnNext")).Click();
            driver.FindElement(By.Id("btnNext")).Click();
            driver.FindElement(By.Id("Documents_0__Status"), 100);
            Thread.Sleep(3000);
            driver.FindElement(By.Id("Documents_0__Status")).Click();
            {
                SelectDropDown(driver, By.XPath("//*[@id=\"Documents_0__Status\"]"), "CO");
            }
            driver.FindElement(By.Id("Documents_0__Status")).Click();
            if (IsElementPresent(driver, By.XPath("//*[@id=\"Documents_1__Status\"]")))
            {
                driver.FindElement(By.Id("Documents_1__Status")).Click();
                {
                    SelectDropDown(driver, By.XPath("//*[@id=\"Documents_1__Status\"]"), "CO");
                }
                driver.FindElement(By.Id("Documents_1__Status")).Click();

            }
            if (IsElementPresent(driver, By.XPath("//*[@id=\"Documents_2__Status\"]")))
            {
                driver.FindElement(By.Id("Documents_2__Status")).Click();
                {
                    SelectDropDown(driver, By.XPath("//*[@id=\"Documents_2__Status\"]"), "CO");
                }
                driver.FindElement(By.Id("Documents_2__Status")).Click();

            }


            driver.FindElement(By.Id("btnNext")).Click();
            driver.FindElement(By.Id("rdbIsWaiverComplete[0]")).Click();
            driver.FindElement(By.Id("ddlQuestion3")).Click();
            {
                SelectDropDown(driver, By.XPath("//*[@id=\"ddlQuestion3\"]"), ProgramCode);
            }
            driver.FindElement(By.Id("ddlQuestion3")).Click();
            driver.FindElement(By.Id("btnDone")).Click();
            driver.FindElement(By.Id("btnNext")).Click();

            if (Env.ToUpper() == "EXPL" || Env.ToUpper() == "DEV3" || Env.ToUpper() == "DEV5" || Env.ToUpper() == "DEV2")
            {
                driver.Url = "https://" + Env + ".kywaiver.chfsinet.ky.gov/SelfService/SignOutConfirmation";
                Thread.Sleep(3000);
                driver.FindElement(By.Name("Logout")).Click();

            }

            return driver;

        }
    }
}
