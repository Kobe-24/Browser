using System;
using System.Windows;
using System.Windows.Input;
using MyBrowser.ViewModel;

namespace MyBrowser.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SiteFactory _siteFactory = new SiteFactory();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new SiteViewModel();
        }

        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                case Key.Q:
                    if (MyListBox.Visibility == Visibility.Visible)
                    {
                        Application.Current.Shutdown();
                    }
                    else
                    {
                        ShowMenu();
                    }
                    break;
                case Key.D0:
                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                case Key.D7:
                case Key.D8:
                case Key.D9:
                    string addressKey = e.Key.ToString()[1].ToString();
                    ShowBrowser(addressKey); 
                    break;
            }
        }

        private void ShowBrowser(string addressName)
        {
            var site = _siteFactory.GetSite(addressName);
            if (site == null) return;
            var addressWithoutPrefix = site.Address;

            if (String.IsNullOrEmpty(addressWithoutPrefix)) return;

            MyListBox.Visibility = Visibility.Collapsed;
            MyBrowser.Visibility = Visibility.Visible;
            var address = HelperFunctions.AddAddressPrefix(addressWithoutPrefix);
            MyBrowser.Navigate(address);
            HelperFunctions.TrySetSuppressScriptErrors(MyBrowser, true);
        }

        private void ShowMenu()
        {
            MyListBox.Visibility = Visibility.Visible;
            MyBrowser.Visibility = Visibility.Collapsed;
        }
    }
}
