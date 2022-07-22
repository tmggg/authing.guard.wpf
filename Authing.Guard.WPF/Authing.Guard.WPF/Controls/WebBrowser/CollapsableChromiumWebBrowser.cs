using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CefSharp;

namespace Authing.Guard.WPF.Controls
{
    internal sealed class CollapsableChromiumWebBrowser : ChromiumWebBrowser
    {
        private string _openUrl;
        private bool _openNewWindow = false;

        public Action<string> LoginSuccessAction { get; set; }

        public CollapsableChromiumWebBrowser()
        {
            Loaded += BrowserLoaded;
        }

        public void OpenAuthWindow(string authUrl,string currentUrl )
        {

            Address = currentUrl;
            _openUrl = authUrl;
            _openNewWindow = true;

            if (!_openNewWindow)
            {
                return;
            }

        }

        private void BrowserLoaded(object sender, RoutedEventArgs e)
        {

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }

            ApplyTemplate();

            CustomLoadHandler customLoadHandler = new CustomLoadHandler { };
            LoadHandler = customLoadHandler;
            IsBrowserInitializedChanged += CollapsableChromiumWebBrowser_IsBrowserInitializedChanged;
            JavascriptMessageReceived += CollapsableChromiumWebBrowser_JavascriptMessageReceived;

            AddressChanged += CollapsableChromiumWebBrowser_AddressChanged;
        }

        private void CollapsableChromiumWebBrowser_AddressChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           // throw new NotImplementedException();
        }

        private void CollapsableChromiumWebBrowser_IsBrowserInitializedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsDisposed)
            {
                return;
            }

            string script = $"window.open('{_openUrl}')";

            this.ExecuteScriptAsync(script);

        }

        private void CollapsableChromiumWebBrowser_JavascriptMessageReceived(object sender, CefSharp.JavascriptMessageReceivedEventArgs e)
        {
            string message = Newtonsoft.Json.JsonConvert.SerializeObject(e.Message);

            LoginSuccessAction?.Invoke(message);
        }
    }
}
