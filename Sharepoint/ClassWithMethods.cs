using Microsoft.ProjectServer.Client;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharepoint
{
    class ClassWithMethods
    {
        public static void displaySiteName(ClientContext context)
        {
            Web web = context.Web;

            // We want to retrieve the web's title and description.
            context.Load(web, w => w.Title, w => w.Description);

            // Execute the query to server.
            context.ExecuteQuery();

            // Now, only the web's title and description are available. If you
            // try to print out other properties, the code will throw
            // an exception because other properties aren't available.
            Console.WriteLine(web.Title + " " + web.Description);
        }

        public static void createNewWebsite(ClientContext context)
        {
       
            WebCreationInformation creation = new WebCreationInformation();
            Console.WriteLine("Enter the web endpoint on which this site will be hosted");

            creation.Url = Console.ReadLine();
            Console.WriteLine("Enter the site name which is going to be hosted at url web1");
            creation.Title = Console.ReadLine();
            Web newWeb = context.Web.Webs.Add(creation);

            // Retrieve the new web information.
            context.Load(newWeb, w => w.Title);
            context.ExecuteQuery();
            Console.WriteLine(newWeb.Title);
        }

        public static void changeSiteName(ClientContext context)
        {
            Web web = context.Web;
            Console.WriteLine("Enter the site new name");
            web.Title = Console.ReadLine();
            Console.WriteLine("Enter the site description");
            web.Description = Console.ReadLine();

            // Note that the web.Update() doesn't trigger a request to the server.
            // Requests are only sent to the server from the client library when
            // the ExecuteQuery() method is called.
            web.Update();

            // Execute the query to server.
            context.ExecuteQuery();
            Console.WriteLine("New title: " + web.Title + " new description " + web.Description);
        }

        public static void retrieveAllList(ClientContext context)
        {
            // The SharePoint web at the URL.
            Web web = context.Web;

            // Retrieve all lists from the server.
            // For each list, retrieve Title and Id.
            context.Load(web.Lists,
                         lists => lists.Include(list => list.Title,
                                                list => list.Id));

            // Execute query.
            context.ExecuteQuery();

            // Enumerate the web.Lists.
            foreach (List list in web.Lists)
            {
                Console.WriteLine(list.Title);
            }
        }

        public static void createNewList(ClientContext context)
        {
            // The SharePoint web at the URL.
            Web web = context.Web;

            ListCreationInformation creationInfo = new ListCreationInformation();
            Console.WriteLine("Enter the list name ");
            creationInfo.Title = Console.ReadLine();
            creationInfo.TemplateType = (int)ListTemplateType.Announcements;
            List list = web.Lists.Add(creationInfo);
            list.Description = "New Description";

            list.Update();
            context.ExecuteQuery();
            Console.WriteLine(list.Title);
        }

        public static void deleteList(ClientContext context)
        {
            Web web = context.Web;
            Console.WriteLine("enter the name of list to be deleleted");
            string name = Console.ReadLine();
            List list = web.Lists.GetByTitle(name);
            list.DeleteObject();

            context.ExecuteQuery();
        }


    }
}
