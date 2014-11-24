using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

using Parse;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Windows.UI.Popups;
using System.Threading.Tasks;

namespace MartialArtsWiki.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {

        public LoginPageViewModel ()
        {
            this.User = new UserViewModel();
        }

        public UserViewModel User { get; set; }

        public async Task<bool> PerformLogin ()
        {
            if (this.User == null)
            {
                return false;
            }

            try
            {
                await ParseUser.LogInAsync(this.User.Username, this.User.Password);
                return true;
            }
            catch (ParseException e)
            {
                return false;
            }
        }

        
    }
}
