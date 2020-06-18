using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Tooling.Connector;

namespace WorkWithCsharp
{
    class Program
    {
        static void Main(string[] args)
        {

            CrmServiceClient crmSvc = new CrmServiceClient(ConfigurationManager.ConnectionStrings["MyCDSServer"].ConnectionString);
            if (crmSvc.IsReady)
            {
                WhoAmIRequest req = new WhoAmIRequest();
                WhoAmIResponse res= (WhoAmIResponse)crmSvc.Execute(req);
                Console.WriteLine("UserID:"+res.UserId);
            }

            Lead lead = new Lead();
            lead.firstname = "Test";
            //lead.lastname = "Testing";
            Console.WriteLine(lead.GetType().GetProperty("firstname").GetValue(lead, null));
            Console.WriteLine(lead.GetType().GetProperty("lastname").GetValue(lead, null));
        }
    }

    public class Lead
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
    }
}
