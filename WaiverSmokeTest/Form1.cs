using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace Smocktest
{

   

    public partial class Form1 : Form
    {

       public string Casenumber { get; set; }
        public string Programcode { get; set; }
        public string Programstatuscode { get; set; }
        public string Begindate { get; set; }
        public string EndDate { get; set; }
        public bool Currentflow { get;  set;}
        public string Currenttask { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string Datest { get; set; }

        public string Servername { get; set; }
        public string IID { get; set; }
        public Form1()
        {
            
            InitializeComponent();
            this.NewApp.Checked = true;
           this.ProgramCodeSelection.SelectedIndex=0;
        }
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

        private void Environment_Click(object sender, EventArgs e)
        {

        }

        private void Server_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Individual_ID_lable_Click(object sender, EventArgs e)
        {

        }

        private void Individual_ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {

            Programcode = this.ProgramCodeSelection.Text.ToString();
            IID = this.Individual_ID.Text;
            Servername = this.Server_Name.Text;

            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=HFS1VD-SQNE001.chfs.ds.ky.gov\"+Servername+";db parrameters ;";
            cnn = new SqlConnection(connetionString);

            cnn.Open();

            SqlCommand command;
            SqlDataReader datareader;
            string sql;

            sql = "select * from DataCollection.DCIndividual (nolock) where IndividualId="+IID;

            command = new SqlCommand(sql, cnn);
            datareader = command.ExecuteReader();
            
            while (datareader.Read())
            {
                Firstname = datareader.GetValue(1).ToString();
                Lastname= datareader.GetValue(2).ToString();
                Middlename= datareader.GetValue(3).ToString();
                Datest = Convert.ToDateTime(datareader.GetValue(12).ToString()).ToString("MM/dd/yyyy");

               
            }
            cnn.Close();




            Applicationintake A = new Applicationintake();
            ApplicationReview AR = new ApplicationReview();
            CapReview CR = new CapReview();
            Assessments Ass = new Assessments();
            Assesmentsreview assrev = new Assesmentsreview();
            IncidentReport createIncidentReportTest = new IncidentReport();
            RiskMitigationReport riskMitigationReport = new RiskMitigationReport();

            Email mail = new Email();
            if (this.Individual_ID.Text.Length<9)
            {
                MessageBox.Show("Please enter a valid Individual ID");
            }
            if (this.Server_Name.Text.Length < 0)
            {
                MessageBox.Show("Please enter a valid Server name");
            }

            IWebDriver driver = new ChromeDriver(); 

            if (this.NewApp.Checked)
            {
                driver = A.Appintake(driver, IID, Servername, Firstname, Middlename ,lastname: Lastname);

                driver = AR.AppReview(driver, IID, Servername,false,ProgramCode: Programcode);

                //Capacity review 
                driver = CR.CapicityReview(driver, IID, Servername, false);

                //Assessments

                cnn.Open();

                sql = "SELECT top 1  *  from DataCollection.CaseProgramIndividual (nolock) where individualId=" + IID + "and CaseProgramStatusCode in ('CR','PENLOCASS')and Programcode='"+Programcode+"'";

                command = new SqlCommand(sql, cnn);
                datareader = command.ExecuteReader();

                while (datareader.Read())
                {
                    Casenumber = datareader.GetValue(1).ToString();

                    Programcode = datareader.GetValue(2).ToString();
                    Begindate = Convert.ToDateTime(datareader.GetValue(4).ToString()).ToString("MM/dd/yyyy");
                    DateTime Enddate = Convert.ToDateTime(datareader.GetValue(4).ToString());
                    EndDate = Enddate.AddYears(1).ToString("MM/dd/yyyy");
                }

                cnn.Close();
                Currentflow = true;

                Ass.Assessmentsnew(driver, IID, Servername, Firstname, Lastname, Datest,Begindate,EndDate, Casenumber, Programcode, false,false,Currentflow,Currenttask);

                assrev.assesmentsreview(driver, IID, Servername, Begindate, EndDate, false);
                
               
                cnn.Open();

                sql = "SELECT top 1  *  from DataCollection.CaseProgramIndividual (nolock) where individualId="+IID+"and CaseProgramStatusCode = 'PENME' ";

                command = new SqlCommand(sql, cnn);
                datareader = command.ExecuteReader();

                while (datareader.Read())
                {

                    Casenumber = datareader.GetValue(1).ToString();

                    Programstatuscode = datareader.GetValue(9).ToString();

                }
                cnn.Close();
                
                if (Programstatuscode == "PENME")
                    mail.SendEMailThroughOUTLOOK("Assessments complete for the Individual ID " + IID + " Case Number " + Casenumber,Servername);
                if (Programstatuscode != "PENME")
                    mail.SendEMailThroughOUTLOOK("Assessments Not complete for the Individual ID " + IID + " Case Number " + Casenumber + " The Case Program status code is " + Programstatuscode + " Please Take the required steps", Servername );

               
                driver.Quit();

            }

            if(this.AppReview.Checked)
            {
                driver = AR.AppReview(driver, IID, Servername, this.AppReview.Checked, ProgramCode: Programcode);

                //Capacity review 
                driver = CR.CapicityReview(driver, IID, Servername, false);



                //Assessments



                cnn.Open();


                sql = "SELECT top 1  *  from DataCollection.CaseProgramIndividual (nolock) where individualId=" + IID + "and CaseProgramStatusCode in ('CR','PENLOCASS')and Programcode=" + Programcode;

                command = new SqlCommand(sql, cnn);
                datareader = command.ExecuteReader();

                while (datareader.Read())
                {
                    Casenumber = datareader.GetValue(1).ToString();

                    Programcode = datareader.GetValue(2).ToString();
                    Begindate = Convert.ToDateTime(datareader.GetValue(4).ToString()).ToString("MM/dd/yyyy");
                    DateTime Enddate = Convert.ToDateTime(datareader.GetValue(4).ToString());
                    EndDate = Enddate.AddYears(1).ToString("MM/dd/yyyy");
                }

                cnn.Close();
                Currentflow = true;

                Ass.Assessmentsnew(driver, IID, Servername, Firstname, Lastname, Datest,Begindate,EndDate, Casenumber, Programcode, false,false,Currentflow,Currenttask);
                assrev.assesmentsreview(driver, IID, Servername, Begindate, EndDate, false);

                cnn.Open();

                sql = "SELECT top 1  *  from DataCollection.CaseProgramIndividual (nolock) where individualId=" + IID + "and CaseProgramStatusCode = 'PENME' ";

                command = new SqlCommand(sql, cnn);
                datareader = command.ExecuteReader();

                while (datareader.Read())
                {

                    Casenumber = datareader.GetValue(1).ToString();

                    Programstatuscode = datareader.GetValue(9).ToString();

                }
                cnn.Close();

                if (Programstatuscode == "PENME")
                    mail.SendEMailThroughOUTLOOK("Assessments complete for the Individual ID " + IID + " Case Number " + Casenumber, Servername);
                if (Programstatuscode != "PENME")
                    mail.SendEMailThroughOUTLOOK("Assessments Not complete for the Individual ID " + IID + " Case Number " + Casenumber + " The Case Program status code is " + Programstatuscode + " Please Take the required steps", Servername);
                driver.Quit();
            }
            if (this.Capreview.Checked)
            {
                

                //Capacity review 
                driver = CR.CapicityReview(driver, IID, Servername, true);



                //Assessments



                cnn.Open();


                sql = "SELECT top 1  *  from DataCollection.CaseProgramIndividual (nolock) where individualId=" + IID + "and CaseProgramStatusCode in ('CR','PENLOCASS')and Programcode='" + Programcode + "'";

                command = new SqlCommand(sql, cnn);
                datareader = command.ExecuteReader();

                while (datareader.Read())
                {
                    Casenumber = datareader.GetValue(1).ToString();

                    Programcode = datareader.GetValue(2).ToString();
                    Begindate = Convert.ToDateTime(datareader.GetValue(4).ToString()).ToString("MM/dd/yyyy");
                    DateTime Enddate = Convert.ToDateTime(datareader.GetValue(4).ToString());
                    EndDate = Enddate.AddYears(1).ToString("MM/dd/yyyy");
                }

                cnn.Close();
                Currentflow = true;

                Ass.Assessmentsnew(driver, IID, Servername, Firstname, Lastname, Datest, Begindate, EndDate, Casenumber, Programcode, false, false, Currentflow, Currenttask);
                assrev.assesmentsreview(driver, IID, Servername, Begindate, EndDate, false);

                cnn.Open();

                sql = "SELECT top 1  *  from DataCollection.CaseProgramIndividual (nolock) where individualId=" + IID + "and CaseProgramStatusCode = 'PENME' ";

                command = new SqlCommand(sql, cnn);
                datareader = command.ExecuteReader();

                while (datareader.Read())
                {

                    Casenumber = datareader.GetValue(1).ToString();

                    Programstatuscode = datareader.GetValue(9).ToString();

                }
                cnn.Close();

                if (Programstatuscode == "PENME")
                    mail.SendEMailThroughOUTLOOK("Assessments complete for the Individual ID " + IID + " Case Number " + Casenumber, Servername);
                if (Programstatuscode != "PENME")
                    mail.SendEMailThroughOUTLOOK("Assessments Not complete for the Individual ID " + IID + " Case Number " + Casenumber + " The Case Program status code is " + Programstatuscode + " Please Take the required steps", Servername);
                driver.Quit();
            }

            if (Assessments_assin.Checked||AssessmentTask.Checked)
            {
                cnn.Open();


                sql = "SELECT top 1  *  from DataCollection.CaseProgramIndividual (nolock) where individualId=" + IID + "and CaseProgramStatusCode in ('CR','PENLOCASS')and Programcode='" + Programcode + "'"; ;

                command = new SqlCommand(sql, cnn);
                datareader = command.ExecuteReader();

                while (datareader.Read())
                {
                    Casenumber = datareader.GetValue(1).ToString();

                    Programcode = datareader.GetValue(2).ToString();
                    Begindate = Convert.ToDateTime(datareader.GetValue(4).ToString()).ToString("MM/dd/yyyy");
                    DateTime Enddate = Convert.ToDateTime(datareader.GetValue(4).ToString());
                    EndDate = Enddate.AddYears(1).ToString("MM/dd/yyyy");

                }
                cnn.Close();

                cnn.Open();
                sql = "select * from TaskManagement.WorkflowTask where individualId=" + IID + "and StatusCode<>'closed'";

                command = new SqlCommand(sql, cnn);
                datareader = command.ExecuteReader();
                
                while (datareader.Read())
                {
                    Currenttask= datareader.GetValue(15).ToString();

                }


                cnn.Close();
                Currentflow = false;
                Ass.Assessmentsnew(driver, IID, Servername, Firstname, Lastname, Datest,Begindate,EndDate, Casenumber, Programcode, Assessments_assin.Checked,AssessmentTask.Checked,Currentflow,Currenttask);
                assrev.assesmentsreview(driver, IID, Servername, Begindate, EndDate, false);

                cnn.Open();

                sql = "SELECT top 1  *  from DataCollection.CaseProgramIndividual (nolock) where individualId=" + IID + "and CaseProgramStatusCode = 'PENME' ";

                command = new SqlCommand(sql, cnn);
                datareader = command.ExecuteReader();

                while (datareader.Read())
                {

                    Casenumber = datareader.GetValue(1).ToString();

                    Programstatuscode = datareader.GetValue(9).ToString();

                }
                cnn.Close();

                if (Programstatuscode == "PENME")
                    mail.SendEMailThroughOUTLOOK("Assessments complete for the Individual ID " + IID + " Case Number " + Casenumber, Servername);
                if (Programstatuscode != "PENME")
                    mail.SendEMailThroughOUTLOOK("Assessments Not complete for the Individual ID " + IID + " Case Number " + Casenumber + " The Case Program status code is " + Programstatuscode + " Please Take the required steps", Servername);
                driver.Quit();
            }

            if (AssessmentsReview.Checked)
            {
                cnn.Open();


                sql = "SELECT top 1  *  from DataCollection.CaseProgramIndividual (nolock) where individualId=" + IID + "and CaseProgramStatusCode ='PENLOCDET' ";

                command = new SqlCommand(sql, cnn);
                datareader = command.ExecuteReader();

                while (datareader.Read())
                {
                    Casenumber = datareader.GetValue(1).ToString();

                    Programcode = datareader.GetValue(2).ToString();
                    Begindate = Convert.ToDateTime(datareader.GetValue(4).ToString()).ToString("MM/dd/yyyy");
                    DateTime Enddate = Convert.ToDateTime(datareader.GetValue(4).ToString());
                    EndDate = Enddate.AddYears(1).ToString("MM/dd/yyyy");

                }

                cnn.Close();

                assrev.assesmentsreview(driver, IID, Servername, Begindate, EndDate, AssessmentsReview.Checked);

                cnn.Open();

                sql = "SELECT top 1  *  from DataCollection.CaseProgramIndividual (nolock) where individualId=" + IID + "and CaseProgramStatusCode = 'PENME' ";

                command = new SqlCommand(sql, cnn);
                datareader = command.ExecuteReader();

                while (datareader.Read())
                {

                    Casenumber = datareader.GetValue(1).ToString();

                    Programstatuscode = datareader.GetValue(9).ToString();

                }
                cnn.Close();
                driver.Close();
                if (Programstatuscode == "PENME")
                    mail.SendEMailThroughOUTLOOK("Assessments complete for the Individual ID " + IID + " Case Number " + Casenumber, Servername);
                if (Programstatuscode != "PENME")
                    mail.SendEMailThroughOUTLOOK("Assessments Not complete for the Individual ID " + IID + " Case Number " + Casenumber + " The Case Program status code is " + Programstatuscode + " Please Take the required steps", Servername);

                driver.Quit();
            }

            if (Create_Incident_Report.Checked)
            {
                cnn.Open();

                sql = "SELECT top 1  *  from DataCollection.CaseProgramIndividual (nolock) where individualId=" + IID + "and EffectiveEndDate IS NULL";

                command = new SqlCommand(sql, cnn);
                datareader = command.ExecuteReader();

                while (datareader.Read())
                {
                    Casenumber = datareader.GetValue(1).ToString();

                    Programcode = datareader.GetValue(2).ToString();
                    Begindate = Convert.ToDateTime(datareader.GetValue(4).ToString()).ToString("MM/dd/yyyy");
                    DateTime Enddate = Convert.ToDateTime(datareader.GetValue(4).ToString());
                    EndDate = Enddate.AddYears(1).ToString("MM/dd/yyyy");

                }

                cnn.Close();
                createIncidentReportTest.CreateIncidentReport(driver, Servername, IID);

            }

            if (Create_Risk_Mitigation_Report.Checked)
            {
                cnn.Open();

                sql = "SELECT top 1  *  from DataCollection.CaseProgramIndividual (nolock) where individualId=" + IID + "and EffectiveEndDate IS NULL";

                command = new SqlCommand(sql, cnn);
                datareader = command.ExecuteReader();

                while (datareader.Read())
                {
                    Casenumber = datareader.GetValue(1).ToString();

                    Programcode = datareader.GetValue(2).ToString();
                    Begindate = Convert.ToDateTime(datareader.GetValue(4).ToString()).ToString("MM/dd/yyyy");
                    DateTime Enddate = Convert.ToDateTime(datareader.GetValue(4).ToString());
                    EndDate = Enddate.AddYears(1).ToString("MM/dd/yyyy");

                }

                cnn.Close();


                #region IncidentSearch
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://" + Servername + ".kywaiver.chfsinet.ky.gov");

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
                    if (Servername.ToUpper() != "EXPL")
                    {
                        driver.FindElement(By.Id("ContentPlaceHolder1_txtUsername")).SendKeys(Servername.ToUpper() + ConfigurationManager.AppSettings.Get("PREre_CMAinternel"));
                    }
                    else
                    {
                        driver.FindElement(By.Id("ContentPlaceHolder1_txtUsername")).SendKeys(ConfigurationManager.AppSettings.Get("Postre_cmainte"));
                    }
                    driver.FindElement(By.Id("ContentPlaceHolder1_txtPassword")).SendKeys("Pa$$w0rd.1");
                    driver.FindElement(By.Id("ContentPlaceHolder1_SubmitButton")).Click();
                }


                driver.FindElement(By.Name("Accept")).Click();
                driver.FindElement(By.Id("primary_nav_menu_5")).Click();
                driver.FindElement(By.Id("IdentifierType")).Click();
                {
                    var dropdown = driver.FindElement(By.Id("IdentifierType"));
                    dropdown.FindElement(By.XPath("//option[. = 'Individual Id']")).Click();
                }
                driver.FindElement(By.Id("IdentifierType")).Click();
                driver.FindElement(By.Id("IdentifierValue")).Click();
                driver.FindElement(By.Id("IdentifierValue")).SendKeys(IID);
                driver.FindElement(By.Id("btnSearch1")).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.ClassName("openIndividualSummary"), 100).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.CssSelector("li:nth-child(12) > .button-Summary")).Click();
                Thread.Sleep(100);
                #endregion

                riskMitigationReport.CreateRiskMitigationReport(driver);

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NewApp_CheckedChanged(object sender, EventArgs e)
        {
            
            this.AppReview.Checked = false;
            this.Capreview.Checked = false;
            this.Assessments_assin.Checked = false;
            this.AssessmentsReview.Checked = false;
            this.AssessmentTask.Checked = false;

        }

        private void AppReview_CheckedChanged(object sender, EventArgs e)
        {
           
            this.NewApp.Checked = false;
            this.Capreview.Checked = false;
            this.Assessments_assin.Checked = false;
            this.AssessmentsReview.Checked = false;
            this.AssessmentTask.Checked = false;

        }

        private void Capreview_CheckedChanged(object sender, EventArgs e)
        {
            
            this.NewApp.Checked = false;
            this.AppReview.Checked = false;
            this.Assessments_assin.Checked = false;
            this.AssessmentsReview.Checked = false;
            this.AssessmentTask.Checked = false;

        }

        private void Assessments_assin_CheckedChanged(object sender, EventArgs e)
        {
            
            this.NewApp.Checked = false;
            this.AppReview.Checked = false;
            this.Capreview.Checked = false;
            this.AssessmentsReview.Checked = false;
            this.AssessmentTask.Checked = false;
        }

        private void AssessmentTask_CheckedChanged(object sender, EventArgs e)
        {
            
            this.NewApp.Checked = false;
            this.AppReview.Checked = false;
            this.Capreview.Checked = false;
            this.AssessmentsReview.Checked = false;
            this.Assessments_assin.Checked = false;
        }

        private void AssessmentsReview_CheckedChanged(object sender, EventArgs e)
        {
            
            this.NewApp.Checked = false;
            this.AppReview.Checked = false;
            this.Capreview.Checked = false;
            this.AssessmentTask.Checked = false;
            this.Assessments_assin.Checked = false;
        }

        private void ProgramCodeSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Create_Incident_Report_CheckedChanged(object sender, EventArgs e)
        {
            this.NewApp.Checked = false;
            this.AppReview.Checked = false;
            this.Capreview.Checked = false;
            this.AssessmentTask.Checked = false;
            this.Assessments_assin.Checked = false;
            this.AssessmentsReview.Checked = false;
            this.Create_Incident_Report.Checked = true;
        }

        private void Create_RiskMitigation_Report_CheckedChanged(object sender, EventArgs e)
        {
            this.NewApp.Checked = false;
            this.AppReview.Checked = false;
            this.Capreview.Checked = false;
            this.AssessmentTask.Checked = false;
            this.Assessments_assin.Checked = false;
            this.AssessmentsReview.Checked = false;
            this.Create_Incident_Report.Checked = false;
            this.Create_Risk_Mitigation_Report.Checked = true;

        }
    }
    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    try
                    {
                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                        wait.Timeout = TimeSpan.FromSeconds(timeoutInSeconds);
                        wait.PollingInterval = TimeSpan.FromMilliseconds(250);
                        for (int i = 0; i < timeoutInSeconds; i++)
                        {
                                    
                                   bool test=IsElementPresent(driver, by);
                                    if(test)
                                    {
                                        try
                                        {

                                            driver.FindElement(by);

                                        }
                                        catch (NoSuchElementException)
                                        { }
                                    }
                                    else
                                    {
                                        Thread.Sleep(1000);
                                        i++;
                                    }
                                    
                            if(i>20)
                            {

                                //MessageBox.Show("Could not find Element"+ by);
                            }
                                
                        }

                    }
                    catch
                    {
                        return driver.FindElement(by);
                    };
                }
            }
            catch
            {

            }
            
                return driver.FindElement(by);
            
        }

        private static bool IsElementPresent(IWebDriver driver, By by)
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
