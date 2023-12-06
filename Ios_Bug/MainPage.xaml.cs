
namespace Ios_Bug
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();            
            webview.Navigated += Webview_Navigated;
            webview.Source = "https://app.trackor.dev/";
        }

        private void Webview_Navigated(object? sender, WebNavigatedEventArgs e)
        {
            Console.WriteLine("Navigated URL"  + e.Url  );
        }

        protected override void OnHandlerChanged()
        {
           base.OnHandlerChanged();
#if IOS

            var nativeWebView = webview.Handler.PlatformView as WebKit.WKWebView;
            if (nativeWebView != null)
            {
                nativeWebView.AddObserver(new Foundation.NSString("URL"), Foundation.NSKeyValueObservingOptions.OldNew, (o) =>
                {
                    Console.WriteLine("new url is received");
                });
            }

#endif
        }
    }

}
