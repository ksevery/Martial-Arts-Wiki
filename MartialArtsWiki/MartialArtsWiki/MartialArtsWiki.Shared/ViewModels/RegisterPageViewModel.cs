using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Parse;

namespace MartialArtsWiki.ViewModels
{
    public class RegisterPageViewModel
    {
        public UserViewModel User { get; set; }

        public RegisterPageViewModel ()
        {
            this.User = new UserViewModel();
        }

        public async Task<bool> PerformRegister ()
        {
            if (this.User == null)
            {
                return false;
            }

            ParseUser newUser = new ParseUser()
            {
                Username = User.Username,
                Password = User.Password
            };

            try
            {
                await newUser.SignUpAsync();
                await ParseUser.LogInAsync(this.User.Username, this.User.Password);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
