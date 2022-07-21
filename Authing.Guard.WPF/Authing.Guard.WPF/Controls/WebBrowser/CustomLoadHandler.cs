using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authing.Guard.WPF.Controls
{
    internal sealed class CustomLoadHandler : CefSharp.Handler.LoadHandler
    {
        private bool hasInject = false;

        protected override void OnFrameLoadStart(IWebBrowser chromiumWebBrowser, FrameLoadStartEventArgs args)
        {
            if (!hasInject)
            {
                string Script = @"
                    const postMessageHandler = e => {  cefSharp.postMessage(e.data); };
                    window.addEventListener(""message"", postMessageHandler, true);
                    window.addEventListener(""message"", postMessageHandler, true);
                    ";

                args.Frame.ExecuteJavaScriptAsync(Script);

                hasInject = true;
            }
            base.OnFrameLoadStart(chromiumWebBrowser, args);
        }

        protected override void OnFrameLoadEnd(IWebBrowser chromiumWebBrowser, FrameLoadEndEventArgs args)
        {
            base.OnFrameLoadEnd(chromiumWebBrowser, args);
        }
    }
}
