using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;

namespace WebPreglednik
{

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            AppContainer container = new AppContainer();

            // Add the initial Tab
            container.Tabs.Add(
                // Our First Tab created by default in the Application will have as content the Form1
                new TitleBarTab(container)
                {
                    Content = new Form1
                    {
                        Text = "New Tab"
                    }
                }
            );

            // Set initial tab the first one
            container.SelectedTabIndex = 0;

            // Create tabs and start application
            TitleBarTabsApplicationContext applicationContext = new TitleBarTabsApplicationContext();
            applicationContext.Start(container);
            Application.Run(applicationContext);
        }
        
    }
}
