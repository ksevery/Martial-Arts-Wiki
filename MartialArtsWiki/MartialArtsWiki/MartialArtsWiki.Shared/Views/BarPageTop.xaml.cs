using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Parse;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace MartialArtsWiki.Views
{
    public sealed partial class BarPageTop : UserControl
    {
        public event RoutedEventHandler OnLogout;
        public event RoutedEventHandler OnFavoritesSelect;

        public BarPageTop ()
        {
            this.InitializeComponent();

            (this.Content as FrameworkElement).DataContext = this;
        }

        public string Username
        {
            get
            {
                return ParseUser.CurrentUser.Username;
            }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValueDp(TitleProperty, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void SetValueDp (DependencyProperty property, object value, [System.Runtime.CompilerServices.CallerMemberName] String p = null)
        {
            SetValue(property, value);
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(BarPageTop), new PropertyMetadata(null));

        private void LogoutButtonClick (object sender, RoutedEventArgs e)
        {
            ParseUser.LogOut();
            if (OnLogout != null)
            {
                OnLogout.Invoke(sender, e);                
            }
        }

        private void FavoritesButtonClick (object sender, RoutedEventArgs e)
        {
            if (OnFavoritesSelect != null)
            {
                OnFavoritesSelect.Invoke(sender, e);
            }
        }
    }
}
