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
using Windows.Web.Http;
using Windows.Storage.Streams;
using Windows.Graphics.Imaging;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ClipboardSync
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TestPage : Page
    {
        IOneDriveClient oneDriveClient;
        HttpClient httpClient = new HttpClient();
        public TestPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //var clipboardData = Clipboard.GetContent();
            ////if (clipboardData.Contains("Bitmap"))
            
                //var clipboardImage = await clipboardData.GetBitmapAsync();
            BitmapImage bitmapImage = new BitmapImage();
                //var smth = await clipboardImage.OpenReadAsync();
            //    await bitmapImage.SetSourceAsync(smth);
            //    image.Source = bitmapImage;
                //Windows.Storage.Streams.IBuffer buffer = new Windows.Storage.Streams.Buffer((uint)(smth.Size * 64));
                //Windows.Storage.Streams.InputStreamOptions iso = new Windows.Storage.Streams.InputStreamOptions();
                //var buf = await smth.ReadAsync(buffer, (uint)(smth.Size * 64), iso);
                //byte[] array = new byte[buf.Length];
                //buffer.CopyTo(array);

           
            string bearer = "bearer EwD4Aq1DBAAUGCCXc8wU/zFu9QnLdZXy+YnElFkAAUw6OuVDNCwoISZhBaSpLI/5Cjt2GBreoQ4wHU9uQevJiC5zKSmXblEYLGij/c6EgNysINDk9RYT3jbcF3eS01sAq9XFmMocR3VJtMXTqvVds6EqfRy1OIOVbLw7rvvmyAKtkqWuaRzPT1F6wV7fF6h7Eylixd3ESrlEmU2RMy8fmPQj2dksaFaARPXC+UiK0CuPo8frk7Z731PcKiQij6qVqbwZDZhyEuYZgEmCEoX9OQYwC+FcFALcY70TlFvZF2AYs6sVGjVyXkyT79ImZVeLt5uOf5XDbdNPz6piHXNQ5RJm/mntRjBSX1h85M0/cZONj+i26b2AC/6k++64bmcDZgAACN0ygy3RQjbEyAGbef4SFIFjG3oQooA3iryfq11EXZCuOif1CchURXpy19qacSWMJoM4/FigbgMAY8Re9pWH4IoKyPjxfzGJ18uDjiyJdLnumAvDlQCS4sVho9L1f9OQHkSD6nw5vy+I+xY1yuBmIgD+MXN2XXe6oH/fQ6xp6l7qHTGsHuh9aBrqAIrSGxaiG28z1jxab0lQn/M3zlt0YFV9kLecxNhpbMcQCmPA5JNHILMLTFtHnvjRk9MJRR6QKkKvLLLB630Bg2j993P6WgPzE6sBLJvOD4dqJgefDeAZEWY2A9VbaxrcSg/c/LO9wYIA3FEDvBj0oDm0zv7jPUlVVYmCfxEMsim6aQNFeAYvjZQxB77QB2re9ChrFQxdwx4N7zMOVXaTovWtSwGoCIkbHEIsMVOzoMiZ8VTpuds58JBnDPLYFHI3Q1v79pxY9S9a+TDLNurQRZoElO1qD5RC/0ZD6my5nj1R5ZUYJFU3okJWnIRK6YAEvnyYzI263TCEgRdsS6wsSRpx0xN2jrp0vTXunqc9gWkeLrMPKeq2El8siiqy3fdypEaqkt9ZI9vnKLPbkfrG2Oq+mbqUlv0IBFmOnP7GaOBdY/l96yFzdWr+AQ==";
            KeyValuePair<string, string> authHeader = new KeyValuePair<string, string>("Authorization", bearer);
            KeyValuePair<string, string> contentType = new KeyValuePair<string, string>("Content-Type", "text/plain");
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri("https://api.onedrive.com/v1.0/drive"));
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri("https://api.onedrive.com/v1.0/drive/root:/clipboardSync/image1.jpg:/content"));
            request.Headers.Add(authHeader);
            //request.Content.Headers.Add(contentType);
            //request.Content = new HttpStreamContent(smth);
            HttpResponseMessage responce = await httpClient.SendRequestAsync(request);
            var s1 = await responce.Content.ReadAsBufferAsync();
            var memoryStream = new MemoryStream(s1.ToArray());
            if (memoryStream != null)
            {
                await bitmapImage.SetSourceAsync(memoryStream.AsRandomAccessStream());
            }
            //var resp = await responce.Content.ReadAsStringAsync();
            //var read = s1.AsStreamForRead();
            //var s = await responce.Content.ReadAsBufferAsync();
            //InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream();
            //await stream.WriteAsync(s);
            
            //string str = System.Text.Encoding.UTF8.GetString(array);
            //bitmapImage.SetSource(stream);
            
            image.Source = bitmapImage;
           




            //if (clipboardData.Contains("Text"))
            //{
            //    var clipboardText = await clipboardData.GetTextAsync();
            //    textBlock.Text += "\n" + clipboardText;
            //}
            //else
            //    textBlock.Text += "\n There are no text or image in clipboard";
            ////var dataPackage = new DataPackage();
            ////dataPackage.SetText("set some text to your clipboard");
            ////Clipboard.SetContent(dataPackage);
        }




        //IReadOnlyList<User> users = await User.FindAllAsync();
        //var current = users.Where(p => p.AuthenticationStatus == UserAuthenticationStatus.LocallyAuthenticated &&
        //                p.Type == UserType.LocalUser).FirstOrDefault();

        //// user may have username
        //var data = await current.GetPropertyAsync(KnownUserProperties.AccountName);
        //string displayName = (string)data;



        ////or may be authinticated using hotmail 
        //if (String.IsNullOrEmpty(displayName))
        //{

        //    string a = (string)await current.GetPropertyAsync(KnownUserProperties.FirstName);
        //    string b = (string)await current.GetPropertyAsync(KnownUserProperties.LastName);
        //    displayName = string.Format("{0} {1}", a, b);
        //}

        //textBlock.Text = displayName;
    }
}
