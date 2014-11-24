using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using MartialArtsWiki.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MartialArtsWiki.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        private const string InvalidLoginParametersMessage = "Invalid username or password!";

        private LoginPageViewModel viewModel;

        public LoginPage ()
            : this(new LoginPageViewModel())
        {

        }

        public LoginPage (LoginPageViewModel viewModel)
        {
            this.InitializeComponent();

            this.ViewModel = viewModel;

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        public LoginPageViewModel ViewModel
        {
            get
            {
                return this.viewModel;
            }
            set
            {
                this.viewModel = value;
                this.DataContext = this.viewModel;
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo (NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private async void ShowLoginError ()
        {
            var msgDialog = new MessageDialog(InvalidLoginParametersMessage);
            await msgDialog.ShowAsync();
        }

        private async void BtnLogin_Click (object sender, RoutedEventArgs e)
        {
            var isLoginSuccessful = await this.ViewModel.PerformLogin();
            if (isLoginSuccessful)
            {
                this.Frame.Navigate(typeof(MainPage));
            }
            else
            {
                this.ShowLoginError();
            }
        }

        private void BtnRegister_Click (object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegisterPage));
        }
    }
}
