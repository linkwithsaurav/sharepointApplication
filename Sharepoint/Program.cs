using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SharePoint.Client;
using System.Security;
using Microsoft.SharePoint.Client.Taxonomy;

namespace Sharepoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string siteURL = "https://sauravshankara.sharepoint.com/sites/teamsite1";
            string userName = "testuser@sauravshankara.onmicrosoft.com";
            string password = "Saurav2196@";


            var clientContext = GetClientContext(siteURL, userName, password);
            do
            {
                Console.WriteLine("Enter the operation number \n1>To display site title" +
                    "\n2>To change site name and description \n3>To create a sharepoint website" +
                    "\n4>To retrieve all list of a site\n5>To create a new list in site" +
                    "\n5>To delete a list in site");

                string value = Console.ReadLine();

                switch (value)
                {
                    case "1":
                        ClassWithMethods.displaySiteName(clientContext);
                        break;

                    case "2":
                        ClassWithMethods.changeSiteName(clientContext);
                        break;

                    case "3":
                        ClassWithMethods.createNewWebsite(clientContext);
                        break;

                    case "4":
                        ClassWithMethods.retrieveAllList(clientContext);
                        break;

                    case "5":
                        ClassWithMethods.createNewList(clientContext);
                        break;

                    case "6":
                        ClassWithMethods.deleteList(clientContext);
                        break;

                    default:
                        Console.WriteLine("No legal choice chosen");
                        break;
                }
                Console.WriteLine("To continue with operations type(yes)");
            } while (Console.ReadLine().Equals("yes"));
        }

        static ClientContext GetClientContext(string siteURL, string userName, string password)
        {
            var credentials = new SharePointOnlineCredentials(userName, ToSecureString(password));
            var context = new ClientContext(siteURL);
            context.Credentials = credentials;

            return context;


        }

        public static SecureString ToSecureString(string Source)
        {
            if (string.IsNullOrWhiteSpace(Source))
                return null;
            else
            {
                SecureString Result = new SecureString();
                foreach (char c in Source.ToCharArray())
                    Result.AppendChar(c);
                return Result;
            }
        }
    }
}
