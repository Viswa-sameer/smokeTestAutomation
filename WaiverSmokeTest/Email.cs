using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Smocktest
{
    class Email
    {

        public void SendEMailThroughOUTLOOK(string Body,string Env)
        {
            try
            {
                Microsoft.Office.Interop.Outlook.Application oApp = (Microsoft.Office.Interop.Outlook.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("0006F03A-0000-0000-C000-000000000046")));
                MailItem oMsg = (MailItem)((dynamic)oApp.CreateItem(OlItemType.olMailItem));
                oMsg.HTMLBody = string.Concat(" Hi Team, <br/> " + Body + "<br/> Regards,<br/>Sameer");
                oMsg.Subject = string.Concat("Smoke Test "+ Env.ToUpper());
                oMsg.Recipients.Add("vegali@deloitte.com").Resolve();
                oMsg.Display(false);
                oMsg = null;
                oApp = null;
                oMsg.Send();
            }
            catch (System.Exception e)
            {

            }
        }
    }
}
