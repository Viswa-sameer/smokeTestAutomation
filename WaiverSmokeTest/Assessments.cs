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
    class Assessments
    {
        WaiverSmokeTest.SearchT SearchP = new WaiverSmokeTest.SearchT();
        Form1 f = new Form1();
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
        public IWebDriver Assessmentsnew(IWebDriver driver, string IID, string Env, string firstname, string lastname, string DOB, string begindate, string enddate, string casenum, string programcode, bool AssesmentsNew, bool assessmentstask, bool currentflow, string currenttask)
        {


            driver.Url = "https://" + Env + ".kywaiver.chfsinet.ky.gov";
            driver.Manage().Window.Maximize();

            Thread.Sleep(3000);
            if (IsElementPresent(driver, By.Id("ContentPlaceHolder2_LoginButton")))
            {
                driver.FindElement(By.Id("ContentPlaceHolder2_LoginButton")).Click();

            }
            if (IsElementPresent(driver, By.Id("ContentPlaceHolder1_lbtnBackToRealm")))
            {
                driver.FindElement(By.Id("ContentPlaceHolder1_lbtnBackToRealm")).Click();
            }
            //*[@id="ContentPlaceHolder1_ExternalUserPlaceHolder"]/div[2]/div[1]/input

            if (IsElementPresent(driver, By.Id("details-button")))
            {
                driver.FindElement(By.Id("details-button")).Click();
                driver.FindElement(By.Id("proceed-link")).Click();
            }

            if (IsElementPresent(driver, By.XPath("//*[@id=\"ContentPlaceHolder1_ExternalUserPlaceHolder\"]/div[2]/div[1]/input")))
            {
                driver.FindElement(By.XPath("//*[@id=\"ContentPlaceHolder1_ExternalUserPlaceHolder\"]/div[2]/div[1]/input")).Click();
            }
            else
            {
                driver.FindElement(By.Id("ExternalUser")).Click();
                driver.FindElement(By.XPath("//*[@id=\"ExternalUserSpan\"]/input")).Click();
            }

            if (Env.ToUpper() != "EXPL"&& programcode != "SCL")
            {
                driver.FindElement(By.Id("ContentPlaceHolder1_txtUsername")).SendKeys(Env.ToUpper() + ConfigurationManager.AppSettings.Get("LOCRWR_ASSESS"));
            }
            else if (programcode == "SCL")
            {
                driver.FindElement(By.Id("ContentPlaceHolder1_txtUsername")).SendKeys(Env.ToUpper() + ConfigurationManager.AppSettings.Get("LOCRWR_ASSESS_SCL"));
            }
            else
            {
               driver.FindElement(By.Id("ContentPlaceHolder1_txtUsername")).SendKeys(Env.ToUpper() + ConfigurationManager.AppSettings.Get("LOCRWR_ASSESS_SCL"));
            }
            driver.FindElement(By.Id("ContentPlaceHolder1_txtPassword")).SendKeys("Pa$$w0rd.1");
            driver.FindElement(By.Id("ContentPlaceHolder1_SubmitButton")).Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.Url = "https://" + Env + ".kywaiver.chfsinet.ky.gov";
            if (IsElementPresent(driver, By.XPath("//*[@id=\"myAppsContent\"]/div[3]/div/div/div[3]/button")))
            {
                driver.FindElement(By.XPath("//*[@id=\"myAppsContent\"]/div[3]/div/div/div[3]/button")).Click();
            }
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"frmDashBoard\"]/div[5]/div[1]/div/div[2]/input")).Click();
            Thread.Sleep(2000);
            if (AssesmentsNew||currentflow)
            {
                driver.FindElement(By.LinkText("LOC Assessment Agency Selection")).Click();
                driver.FindElement(By.Id("FirstName")).Click();
                driver.FindElement(By.Id("FirstName")).SendKeys(firstname);
                driver.FindElement(By.Id("LastName")).SendKeys(lastname);
                driver.FindElement(By.Id("CaseNumber")).SendKeys(casenum);
                driver.FindElement(By.Id("DOB")).Click();
                driver.FindElement(By.Id("DOB")).SendKeys(DOB);
                driver.FindElement(By.Id("ProgramCode")).Click();
                {
                    SelectDropDown(driver, By.Id("ProgramCode"), programcode);
                }
                driver.FindElement(By.Id("ProgramCode")).Click();
                driver.FindElement(By.Id("AssessmentReasonCode")).Click();
                {
                    SelectDropDown(driver, By.Id("AssessmentReasonCode"), "INI");
                }
                driver.FindElement(By.Id("AssessmentReasonCode")).Click();
                driver.FindElement(By.Id("btnSearch")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.Id("btnSave")).Click();
                Thread.Sleep(4000);
                driver.FindElement(By.Id("btnOk")).Click();
                Thread.Sleep(4000);
                currentflow = true;
            }



            SearchP.SearchTask(driver, IID);
            Thread.Sleep(3000);
           

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

            if (currentflow || currenttask == "Perform Assessment")
            {

                driver.FindElement(By.Id("btnNext")).Click();
                if (IsElementPresent(driver, By.Id("AssessmentTool")))
                {
                    if (programcode != "SCL")
                    {
                        driver.FindElement(By.Id("AssessmentTool")).Click();
                        {
                            SelectDropDown(driver, By.Id("AssessmentTool"), "M351");
                        }
                        driver.FindElement(By.Id("AssessmentTool")).Click();
                    }
                    else
                    {
                        driver.FindElement(By.Id("AssessmentTool")).Click();
                        {
                            SelectDropDown(driver, By.Id("AssessmentTool"), "LOCRF");
                        }
                        driver.FindElement(By.Id("AssessmentTool")).Click();

                    }
                    driver.FindElement(By.Id("txtStartTime")).Click();
                    driver.FindElement(By.Id("txtStartTime")).SendKeys("1111");
                    driver.FindElement(By.Id("ddlAssessmentTimeAMPM")).Click();
                    {
                        SelectDropDown(driver, By.Id("ddlAssessmentTimeAMPM"), "AM");
                    }
                    driver.FindElement(By.Id("ddlAssessmentTimeAMPM")).Click();
                    driver.FindElement(By.Id("ddlAssessmentTimeZone")).Click();
                    {
                        SelectDropDown(driver, By.Id("ddlAssessmentTimeZone"), "CT");
                    }
                    driver.FindElement(By.Id("ddlAssessmentTimeZone")).Click();
                    driver.FindElement(By.Id("ddlAssessmentLocation")).Click();
                    {
                        SelectDropDown(driver, By.Id("ddlAssessmentLocation"), "IR");

                    }
                    Thread.Sleep(2000);
                    driver.FindElement(By.Id("ddlAssessmentLocation")).Click();
                    driver.FindElement(By.Id("btnDone")).Click();
                    Thread.Sleep(3000);
                    currentflow = true;
                }
                SearchP.SearchTask(driver, IID);
                Thread.Sleep(2000);
                //while (IsElementPresent(driver, By.ClassName("field-validation-error")))
                //{
                //    Thread.Sleep(2000);
                //    SearchP.SearchTaskdelay(driver, IID);
                //}
                //*[@id="TaskSearchResultContent"]/div[1]


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

            }

            if (currentflow || currenttask == "Record Assessment Results")
            {
                Thread.Sleep(3000);
                driver.FindElement(By.Id("btnNext")).Click();
                driver.FindElement(By.XPath("//*[@id=\"AssessmentRequestedStartDate\"]")).Click();
                driver.FindElement(By.XPath("//*[@id=\"AssessmentRequestedStartDate\"]")).SendKeys(begindate);
                driver.FindElement(By.XPath("//*[@id=\"AssessmentRequestedEndDate\"]")).Click();
                driver.FindElement(By.XPath("//*[@id=\"AssessmentRequestedEndDate\"]")).SendKeys(enddate);

                driver.FindElement(By.Id("ddlProvIderId")).Click();
                {

                    driver.FindElement(By.Id("ddlProvIderId")).SendKeys(Keys.Down);
                }
                if (IsElementPresent(driver, By.Id("ddlAssessmentTool")))
                {
                    driver.FindElement(By.Id("ddlAssessmentTool")).Click();
                    {

                        driver.FindElement(By.Id("ddlAssessmentTool")).SendKeys(Keys.Down);
                    }
                }
                driver.FindElement(By.Id("ddlAssessmentTool")).Click();
                driver.FindElement(By.Id("btnNext")).Click();
                if (!IsElementPresent(driver, By.Id("btnAddDiagnosis")))
                {
                    driver.FindElement(By.XPath("//*[@id=\"btnNext\"]")).Click();
                }
                
                driver.FindElement(By.Id("btnAddDiagnosis")).Click();
                driver.FindElement(By.Id("txtDiagnosis")).Click();
                driver.FindElement(By.Id("txtDiagnosis")).SendKeys("A1810");
                driver.FindElement(By.Id("Type[0]")).Click();
                driver.FindElement(By.Id("DateofDiagnosis")).Click();
                driver.FindElement(By.Id("DateofDiagnosis")).SendKeys(begindate);

                driver.FindElement(By.Id("Indicator[1]")).Click();
                driver.FindElement(By.Id("btnSaveDiagnosis")).Click();
                Thread.Sleep(4000);
                driver.FindElement(By.Id("btnNext")).Click();
                if (programcode == "SCL")
                {
                    SelectDropDown(driver, By.Id("DocumentTypeCode"), "ILOCF");
                }
                else
                {
                    driver.FindElement(By.Id("DocumentTypeCode")).Click();
                {
                    SelectDropDown(driver, By.Id("DocumentTypeCode"), "M351");
                }
                }
                driver.FindElement(By.Id("DocumentTypeCode")).Click();
                IWebElement fileInput = driver.FindElement(By.Id("File"));
                fileInput.SendKeys(ConfigurationManager.AppSettings.Get("filepath"));
                driver.FindElement(By.Name("AttachDocument")).Click();
                Thread.Sleep(4000);
                driver.FindElement(By.Id("btnNext")).Click();
                Thread.Sleep(1000);
                currentflow = true;
            }
            //if (programcode=="SCL"&& currentflow || currenttask == "Perform SIS Assessment")
            //{
            //    SearchP.SearchTask(driver, IID);
            //    Thread.Sleep(3000);


            //    if (IsElementPresent(driver, By.LinkText("Start")))
            //    {
            //        driver.FindElement(By.LinkText("Start"), 100);

            //        driver.FindElement(By.LinkText("Start")).Click();
            //    }
            //    else if ((IsElementPresent(driver, By.LinkText("Continue"))))
            //    {
            //        driver.FindElement(By.LinkText("Continue"), 100);

            //        driver.FindElement(By.LinkText("Continue")).Click();
            //    }
            //    Thread.Sleep(3000);
            //    driver.FindElement(By.Id("btnNext")).Click();
            //    SelectDropDown(driver, By.Id("AssessmentTool"), "SIS");
            //    driver.FindElement(By.Id("txtStartTime")).Click();
            //    driver.FindElement(By.Id("txtStartTime")).SendKeys("11:11");
            //    SelectDropDown(driver, By.Id("ddlAssessmentTimeAMPM"), "AM"); 
            //    SelectDropDown(driver, By.Id("ddlAssessmentTimeZone"), "CT"); 
            //    SelectDropDown(driver, By.Id("ddlAssessmentLocation"), "IR");
            //    driver.FindElement(By.Id("btnDone")).Click();
            //    currentflow = true;
            //}
            Thread.Sleep(4000);
            driver.FindElement(By.LinkText("Sign Out")).Click();
            driver.FindElement(By.Name("Logout")).Click();
            
            
            return driver;
        }
    }
}
