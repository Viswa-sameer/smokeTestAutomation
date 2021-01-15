using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;



namespace Smocktest{

    class Applicationintake
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
       
        public IWebDriver Appintake(IWebDriver driver,string IID,string Env,string firstname, string middlename,string lastname)
        {
           
            driver.Url = "https://" + Env + ".kywaiver.chfsinet.ky.gov";
            driver.Manage().Window.Maximize();
            if (IsElementPresent(driver, By.Id("details-button")))
            {
                driver.FindElement(By.Id("details-button")).Click();
                driver.FindElement(By.Id("proceed-link")).Click();
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
                if (Env.ToUpper() == "DEV1")
                {
                    driver.FindElement(By.Id("ContentPlaceHolder1_txtUsername")).SendKeys(Env.ToUpper() + ConfigurationManager.AppSettings.Get("PREre_CMAinternelDev1"));
                }
                else if (Env.ToUpper() != "EXPL")
                {
                    driver.FindElement(By.Id("ContentPlaceHolder1_txtUsername")).SendKeys(Env.ToUpper() + ConfigurationManager.AppSettings.Get("PREre_CMAinternel"));
                }
                else
                {
                    driver.FindElement(By.Id("ContentPlaceHolder1_txtUsername")).SendKeys(ConfigurationManager.AppSettings.Get("Postre_cmainte"));
                }
                driver.FindElement(By.Id("ContentPlaceHolder1_txtPassword")).SendKeys("Pa$$w0rd.1");
                driver.FindElement(By.Id("ContentPlaceHolder1_SubmitButton")).Click();
            }
            driver.FindElement(By.Name("Accept")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("primary_nav_menu_5"), 100);

            driver.FindElement(By.Id("primary_nav_menu_5")).Click();
            driver.FindElement(By.Id("IdentifierType"), 100);
            driver.FindElement(By.Id("IdentifierType")).Click();
            {
                SelectDropDown(driver, By.Id("IdentifierType"), "INDVID");
            }
            driver.FindElement(By.Id("IdentifierValue")).Click();
            driver.FindElement(By.Id("IdentifierValue")).SendKeys(IID);


            driver.FindElement(By.Id("btnSearch1")).Click();
            
            Thread.Sleep(5000);


            driver.FindElement(By.ClassName("openIndividualSummary"), 100).Click();
            Thread.Sleep(4000);

            if (IsElementPresent(driver, By.Id("ContentPlaceHolder2_lblApplicationError")))
            {
                Thread.Sleep(4000);
                driver.FindElement(By.XPath("//*[@id=\"HomeSubHeaderHyperLink\"]")).Click();
                Thread.Sleep(1000);
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                if(IsElementPresent(driver, By.XPath("//*[@id=\"myAppsContent\"]/div[3]/div/div/div[3]/button")))
                {
                    driver.FindElement(By.XPath("//*[@id=\"myAppsContent\"]/div[3]/div/div/div[3]/button")).Click();

                }
                
                Thread.Sleep(1000);
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                driver.FindElement(By.Name("Accept")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("primary_nav_menu_5"), 100);

                driver.FindElement(By.Id("primary_nav_menu_5")).Click();
                driver.FindElement(By.Id("IdentifierType"), 100);
                driver.FindElement(By.Id("IdentifierType")).Click();
                {
                    SelectDropDown(driver, By.Id("IdentifierType"), "INDVID");
                }
                driver.FindElement(By.Id("IdentifierValue")).Click();
                driver.FindElement(By.Id("IdentifierValue")).SendKeys(IID);


                driver.FindElement(By.Id("btnSearch1")).Click();

                Thread.Sleep(5000);
                driver.FindElement(By.ClassName("openIndividualSummary"), 100).Click();

            }

            Thread.Sleep(3000);
            bool NEWAPP=true;
            if (IsElementPresent(driver, By.Id("caseActionList")))
            {
                if (!driver.FindElement(By.Id("lblCaseNumber")).Text.Contains("N / A"))
                {

                    IWebElement countrydropdown = driver.FindElement(By.Id("caseActionList"));
                    if (Env.ToUpper() == "EXPL")
                    {
                        driver.Url = "https://" + Env + ".kywaiver.chfsinet.ky.gov/WebIntegration/NavigateToSSPBenefindDashboard";

                        Thread.Sleep(5000);
                    }


                    else
                    {
                        driver.FindElement(By.XPath("//*[@id=\"caseActionList\"]/li[12]/input")).Click();
                        if (IsElementPresent(driver, By.Id("ContentPlaceHolder2_lblApplicationError")))
                        {
                            Thread.Sleep(4000);
                            driver.FindElement(By.XPath("//*[@id=\"HomeSubHeaderHyperLink\"]")).Click();
                            Thread.Sleep(1000);
                            driver.SwitchTo().Window(driver.WindowHandles.Last());
                            driver.FindElement(By.XPath("//*[@id=\"myAppsContent\"]/div[3]/div/div/div[3]/button")).Click();
                            Thread.Sleep(1000);
                            driver.SwitchTo().Window(driver.WindowHandles.Last());
                            driver.FindElement(By.Name("Accept")).Click();
                            Thread.Sleep(2000);
                            driver.FindElement(By.Id("primary_nav_menu_5"), 100);

                            driver.FindElement(By.Id("primary_nav_menu_5")).Click();
                            driver.FindElement(By.Id("IdentifierType"), 100);
                            driver.FindElement(By.Id("IdentifierType")).Click();
                            {
                                SelectDropDown(driver, By.Id("IdentifierType"), "INDVID");
                            }
                            driver.FindElement(By.Id("IdentifierValue")).Click();
                            driver.FindElement(By.Id("IdentifierValue")).SendKeys(IID);


                            driver.FindElement(By.Id("btnSearch1")).Click();

                            Thread.Sleep(5000);
                            driver.FindElement(By.ClassName("openIndividualSummary"), 100).Click();
                            Thread.Sleep(2000);
                            driver.FindElement(By.XPath("//*[@id=\"caseActionList\"]/li[12]/input")).Click();

                        }
                    }
                }

                if (IsElementPresent(driver, By.Id("details-button")))
                {
                    driver.FindElement(By.Id("details-button")).Click();
                    driver.FindElement(By.Id("proceed-link")).Click();
                }

                else
                {
                    NEWAPP = false;
                }

            }

            if (!IsElementPresent(driver, By.LinkText("Continue")))
            {
                driver.FindElement(By.LinkText("Start Waiver Application"), 100);

                driver.FindElement(By.LinkText("Start Waiver Application")).Click();
                driver.FindElement(By.Id("rbl_RequireAssistance_0"), 100);
                driver.FindElement(By.Id("rbl_RequireAssistance_0[0]")).Click();
                driver.FindElement(By.Id("rbl_HasBrainInjury_0[1]")).Click();
                driver.FindElement(By.Id("rbl_IsVentilatorDependent_0[1]")).Click();
                driver.FindElement(By.Id("rbl_HasDevelopmentalDisability_0[1]")).Click();
                driver.FindElement(By.Id("rbl_WillContinueServices_0[1]")).Click();
                driver.FindElement(By.Name("WaiverGatePostNextScreen"),100).Click();
                Thread.Sleep(3000);
               
                    driver.FindElement(By.XPath("//*[@id=\"EncodedIndividualId\"]"), 100);
                    
                    driver.FindElement(By.XPath("//*[@id=\"EncodedIndividualId\"]")).Click();
            }
            else
            {
                driver.FindElement(By.LinkText("Continue")).Click();
                driver.FindElement(By.XPath("//*[@id=\"EncodedIndividualId\"]"), 100);

                driver.FindElement(By.XPath("//*[@id=\"EncodedIndividualId\"]")).Click();

            }
            

            driver.FindElement(By.XPath("//*[@id=\"Services\"]")).Click();
            driver.FindElement(By.Id("ServicesReceiving15")).Click();
            driver.FindElement(By.Id("ServicesNeeded5")).Click();
            driver.FindElement(By.Id("dplQuestion26")).Click();
            {
                SelectDropDown(driver, By.Id("dplQuestion26"), "WIT");

            }
            driver.FindElement(By.Id("dplQuestion26")).Click();
            driver.FindElement(By.Id("txtQuestion27")).Click();
            driver.FindElement(By.Id("txtQuestion27")).SendKeys("test");
            driver.FindElement(By.Id("IsCurrentlyWaitlisted[1]")).Click();
            driver.FindElement(By.Id("HasPreviouslyAccessedProgram[1]")).Click();
            driver.FindElement(By.Id("btnNext")).Click();
            Thread.Sleep(2000);


            driver.FindElement(By.XPath("//*[@id=\"rbtnIsIndividualPhysicallyDisabled[1]\"]")).Click();

            driver.FindElement(By.XPath("//*[@id=\"rbtnIsNursingCareNeeded[1]\"]")).Click();
            bool additionaldocument=false;
           if( IsElementPresent(driver, By.XPath("//*[@id=\"rdbIntellectualDisabilityCode[1]\"]")))
            {
                driver.FindElement(By.XPath("//*[@id=\"rdbIntellectualDisabilityCode[1]\"]")).Click();
                driver.FindElement(By.XPath("//*[@id=\"rdbDevelopmentDisabilityCode[1]\"]")).Click();
                driver.FindElement(By.XPath("//*[@id=\"rbtnIsVentilatorUserMoreThan12Hours[1]\"]")).Click();
                driver.FindElement(By.XPath("//*[@id=\"rbtnIsVentilatorStimulateRespiration[1]\"]")).Click();
                driver.FindElement(By.XPath("//*[@id=\"rbtnIsPermanentTracheotomy[1]\"]")).Click();
                driver.FindElement(By.XPath("//*[@id=\"chkQuestion30\"]")).Click();
                driver.FindElement(By.XPath("//*[@id=\"chkQuestion40\"]")).Click();
                driver.FindElement(By.XPath("//*[@id=\"chkQuestion53\"]")).Click();
                driver.FindElement(By.XPath("//*[@id=\"dtpDateOfBirth\"]")).Click();
                driver.FindElement(By.XPath("//*[@id=\"dtpDateOfBirth\"]")).SendKeys("04/08/2019");
                additionaldocument = true;
            }
            driver.FindElement(By.Id("btnNext")).Click();
            driver.FindElement(By.Id("dplCurrentLivingSituation")).Click();
            {
                SelectDropDown(driver, By.Id("dplCurrentLivingSituation"), "LFAM");
            }
            driver.FindElement(By.Id("dplCurrentLivingSituation")).Click();
            driver.FindElement(By.XPath("//*[@id=\"rdbIsLivingSituationworking[0]\"]")).Click();
            driver.FindElement(By.Id("btnNext")).Click();
            driver.FindElement(By.XPath("//*[@id=\"rdbIsIndividualHavingPrimaryCareGiver[1]\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"rdbIsFamilyAvailableToBeInvolved[1]\"]")).Click();
            driver.FindElement(By.Id("btnNext")).Click();
            driver.FindElement(By.XPath("//*[@id=\"ddlIndividualMobilityCode\"]")).Click();
            {
                SelectDropDown(driver, By.XPath("//*[@id=\"ddlIndividualMobilityCode\"]"), "1");
            }
            driver.FindElement(By.XPath("//*[@id=\"ddlIndividualMobilityCode\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"ddlAssistanceNeededCode\"]")).Click();
            {
                SelectDropDown(driver, By.XPath("//*[@id=\"ddlAssistanceNeededCode\"]"), "1");
            }
            driver.FindElement(By.XPath("//*[@id=\"ddlAssistanceNeededCode\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"ddlCommunicationMode\"]")).Click();
            {
                SelectDropDown(driver, By.XPath("//*[@id=\"ddlCommunicationMode\"]"), "1");
            }
            driver.FindElement(By.XPath("//*[@id=\"ddlCommunicationMode\"]")).Click();

            driver.FindElement(By.XPath("//*[@id=\"ddlAssuringSafetyPeriod\"]")).Click();
            {
                SelectDropDown(driver, By.XPath("//*[@id=\"ddlAssuringSafetyPeriod\"]"), "1");
            }
            driver.FindElement(By.XPath("//*[@id=\"ddlAssuringSafetyPeriod\"]")).Click();
            driver.FindElement(By.Id("txtAssuringSafetyDetails")).Click();
            driver.FindElement(By.Id("txtAssuringSafetyDetails")).SendKeys("test");
            driver.FindElement(By.Id("rdbAreAbuseComplaints[1]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"chkBehavioralChallengesList[9]\"]")).Click();
            driver.FindElement(By.Id("btnNext")).Click();
            Thread.Sleep(2000);
            string Name = driver.FindElement(By.XPath("//*[@id=\"SubdvIndividualInformation\"]/div/div[2]/div[2]"), 100).Text;            // vars.put("Name", driver.FindElement(By.XPath("//div[@Id=\'SubdvIndivIdualInformation\']/div/div[2]/div[2]")).getText());
            string[] Namesplit = Name.Split(' ');
            driver.FindElement(By.XPath("//*[@id=\"chkIsConsentCorrectInformation\"]"), 100);
            //vars.put("FirstName", driver.FindElement(By.XPath("//div[@Id=\'SubdvIndivIdualInformation\']/div/div[2]/div[2].split(\" \")[0]")).getAttribute("value"));
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"chkIsConsentCorrectInformation\"]")).Click();
            driver.FindElement(By.Id("txtFirstName")).SendKeys(firstname);
            if (middlename != null)
            {
                driver.FindElement(By.Id("txtMiddleInitial")).SendKeys(middlename);
            }
            driver.FindElement(By.Id("txtLastName")).SendKeys(lastname);
            if(IsElementPresent(driver,By.Id("rdbGender")))
            {
                driver.FindElement(By.XPath("//*[@id=\"rdbGender[1]\"]")).Click();
            }
            driver.FindElement(By.Id("btnSaveAndContinue")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("btnContinue"), 100).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"DocumentType\"]"), 100).Click();
            {

                SelectDropDown(driver, By.XPath("//*[@id=\"DocumentType\"]"), "MAP115");
            }
            driver.FindElement(By.XPath("//*[@id=\"DocumentType\"]")).Click();
            //driver.FindElement(By.Id("File")).Click();
            IWebElement fileInput = driver.FindElement(By.Id("File"));
            fileInput.SendKeys(ConfigurationManager.AppSettings.Get("filepath"));
            // Added a wait to make you notice the difference.

            driver.FindElement(By.Id("AttachDocument"), 100);


            driver.FindElement(By.Id("AttachDocument")).Click();

            if (additionaldocument)
            {

                driver.FindElement(By.XPath("//*[@id=\"DocumentType\"]"), 100).Click();
                {

                    SelectDropDown(driver, By.XPath("//*[@id=\"DocumentType\"]"), "M10");
                }
                driver.FindElement(By.XPath("//*[@id=\"DocumentType\"]")).Click();
                //driver.FindElement(By.Id("File")).Click();
                IWebElement fileInput1 = driver.FindElement(By.Id("File"));
                fileInput1.SendKeys(ConfigurationManager.AppSettings.Get("filepath"));
                // Added a wait to make you notice the difference.

                driver.FindElement(By.Id("AttachDocument"), 100);


                driver.FindElement(By.Id("AttachDocument")).Click();
            }
            driver.FindElement(By.XPath("//*[@id=\"UploadDocumentsForm\"]/div[7]/div/div/div/div[2]/div/div[2]"), 100).Click();
            Thread.Sleep(7000);
            string con=driver.FindElement(By.Id("btnContinue"), 100).Text;
            Thread.Sleep(5000);
            driver.FindElement(By.Id("btnContinue")).Click();

            if (Env.ToUpper() == "EXPL" || Env.ToUpper() == "DEV3"||Env.ToUpper() == "DEV5"|| Env.ToUpper() == "DEV2")
            {
                driver.Url = "https://" + Env + ".kywaiver.chfsinet.ky.gov/SelfService/SignOutConfirmation";
                Thread.Sleep(3000);
                driver.FindElement(By.Name("Logout")).Click();
                
            }
            

            return driver;
        }

    }
}
