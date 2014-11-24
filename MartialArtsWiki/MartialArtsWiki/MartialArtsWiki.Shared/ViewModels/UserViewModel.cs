using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using GalaSoft.MvvmLight;
using Parse;

namespace MartialArtsWiki.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        public static Expression<Func<ParseUser, UserViewModel>> FromParseUser
        {
            get
            {
                return user => new UserViewModel
                {
                    Username = user.Username,
                    Id = user.ObjectId
                };
            }
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public static UserViewModel ConvertParseUser (ParseUser user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserViewModel
            {
                Username = user.Username,
                Id = user.ObjectId
            };
        }
    }
}
