using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core;


namespace SharepointAppOnly
{
    class Program
    {
        static void Main(string[] args)
        {
            string siteUrl = "https://sauravshankara.sharepoint.com/sites/teamsite1";

            //Client id and Client secret created through appregnew.aspx and permissions granted through appinv.aspx
            string clientId = "74a908d2-e488-4cee-8328-7a9b8c0cb495";//e.g. 15107f17-5230-422b-873c-b3846211cba7
            string clientSecret = "zNpbEitvw7d1oLLSlNF/kZQ1y0ufwyIPNy+Q31+uAtQ=";//e.g. XeGMHUxRPOg0o1LeKqfWVYTzO0blGfXBPKvNiCQwHtc=

            var authManager = new AuthenticationManager();

            //PnP Core method
            ClientContext clientContext = authManager.GetAppOnlyAuthenticatedContext(siteUrl, clientId, clientSecret);


            Web web = clientContext.Web;
            clientContext.Load(web);
            clientContext.ExecuteQueryRetry();

            Console.WriteLine(web.Title);
        }
    }
}
