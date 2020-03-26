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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PlayerDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

           
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var player = new MediaElement()
            {
                Source = new Uri("ms-appx:///Assets/demo.mp4"),
                AreTransportControlsEnabled = true,
            };
            ((Grid)this.Content).Children.Add(player);

            var control = new EveryThingSampleTools.UWP.UI.ESMediaTransportControls(player);
            player.TransportControls = control;
             control.SetTitleUIContent("Demo.mp4");//设置标题头在 control.TopGrid里 control.SetTitleUIContent(new TextBlock() { Text = "Demo.mp4"});

            var but = new AppBarButton()
            {
                Icon = new SymbolIcon(Symbol.Like),
                Width = 48,
                Height = 48,
            };
            but.Click += But_Click;

            control.SetAppBarButtons(new List<AppBarButton>() {
               but,//可以增加更多按钮再 CommandBars 里面
            });

            control.RightGrid.Children.Add(new TextBlock() { Text = "Here is RightGrid"});

            player.Play();

            base.OnNavigatedTo(e);
        }

        private void But_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
