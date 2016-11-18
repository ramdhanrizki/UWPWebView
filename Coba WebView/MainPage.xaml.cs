using System;
using Windows.ApplicationModel;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Coba_WebView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private SharedObject communicationWinRT = new SharedObject();

        public MainPage()
        {
            this.InitializeComponent();
           
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string src = "ms-appx-web:///Html/unikom.html";
            this.webViewControl.Navigate(new Uri(src));
        }

        private void webViewControl_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            this.webViewControl.AddWebAllowedObject("sharedObj", communicationWinRT);
        }
    }

    [AllowForWeb]
    public sealed class SharedObject
    {
        public string getApplicationVersion()
        {
            PackageVersion version = Package.Current.Id.Version;
            return String.Format("{0}.{1}.{2}.{3}",
                                 version.Major, version.Minor, version.Build, version.Revision);
        }
    }
}
