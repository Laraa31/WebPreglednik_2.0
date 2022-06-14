using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using EasyTabs;

namespace WebPreglednik
{
    public partial class Form1 : Form
    {
        public ChromiumWebBrowser chromeBrowser;

        protected TitleBarTabs ParentTabs
        {
            get
            {
                return (ParentForm as TitleBarTabs);
            }
        }

        public Form1()
        {
            InitializeComponent();
            InitializeChromium();
        }


        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser("https://www.google.com/");
            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }
        private void tsbtnGo_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUrl.Text) || txtUrl.Text.Equals("about:blank"))
            {
                MessageBox.Show("Enter URL!","Empty URL", MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtUrl.Focus();
                return;
            }
            OpenURLInBrowser(txtUrl.Text);

            
        }

        private void OpenURLInBrowser(string url)
        {

            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "https://" + url;
            }

            try
            {

                chromeBrowser.Load(url);
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        private void tsbtnHome_Click(object sender, EventArgs e)
        {
            chromeBrowser.Load("https://google.com");
        }

        private void tsbtnBack_Click(object sender, EventArgs e)
        {
            chromeBrowser.Back();
        }

        private void tsbtnForward_Click(object sender, EventArgs e)
        {
            chromeBrowser.Forward();
        }


        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void txtUrl_Click(object sender, EventArgs e)
        {

        }

      

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)

            {
                OpenURLInBrowser(txtUrl.Text);
            }
        }
    }

}
