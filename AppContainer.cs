using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyTabs;

namespace WebPreglednik
{
    public partial class AppContainer : TitleBarTabs
    {
        public AppContainer()
        {
            

            AeroPeekEnabled = true;
            TabRenderer = new ChromeTabRenderer(this);
        }

        // Handle the method CreateTab that allows the user to create a new Tab
        // on your app when clicking
        public override TitleBarTab CreateTab()
        {
            return new TitleBarTab(this)
            {
                // The content will be an instance of another Form
                // In our example, we will create a new instance of the Form1
                Content = new Form1
                {
                    Text = "New Tab"
                }
            };
        }

        // The rest of the events in your app here if you need to .....
    }
}
