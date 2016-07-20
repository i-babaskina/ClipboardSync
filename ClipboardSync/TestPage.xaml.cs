using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Media.Imaging;
using Windows.System;
using Microsoft.OneDrive.Sdk;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ClipboardSync
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TestPage : Page
    {
        public TestPage()
        {
            this.InitializeComponent();
            OneDriveClient ondc = new OneDriveClient();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            IReadOnlyList<User> users = await User.FindAllAsync();
            var current = users.Where(p => p.AuthenticationStatus == UserAuthenticationStatus.LocallyAuthenticated &&
                            p.Type == UserType.LocalUser).FirstOrDefault();

            // user may have username
            var data = await current.GetPropertyAsync(KnownUserProperties.AccountName);
            string displayName = (string)data;

            

            //or may be authinticated using hotmail 
            if (String.IsNullOrEmpty(displayName))
            {

                string a = (string)await current.GetPropertyAsync(KnownUserProperties.FirstName);
                string b = (string)await current.GetPropertyAsync(KnownUserProperties.LastName);
                displayName = string.Format("{0} {1}", a, b);
            }

            textBlock.Text = displayName;

            var clipboardData = Clipboard.GetContent();
            if (clipboardData.Contains("Bitmap"))
            {
                var clipboardImage = await clipboardData.GetBitmapAsync();
                BitmapImage bitmapImage = new BitmapImage();
                var smth = await clipboardImage.OpenReadAsync();
                await bitmapImage.SetSourceAsync(smth);
                image.Source = bitmapImage;
                //Windows.Storage.Streams.IBuffer buffer = new Windows.Storage.Streams.Buffer((uint)(smth.Size * 64));
                //Windows.Storage.Streams.InputStreamOptions iso = new Windows.Storage.Streams.InputStreamOptions();
                //var buf = await smth.ReadAsync(buffer, (uint)(smth.Size * 64), iso);
                //byte[] array = new byte[buf.Length];
                //buffer.CopyTo(array);

            }
            if (clipboardData.Contains("Text"))
            {
                var clipboardText = await clipboardData.GetTextAsync();
                textBlock.Text += "\n" + clipboardText;
            }
            else
                textBlock.Text += "\n There are no text or image in clipboard";
            //var dataPackage = new DataPackage();
            //dataPackage.SetText("set some text to your clipboard");
            //Clipboard.SetContent(dataPackage);
        }
    }
}
