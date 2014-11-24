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
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
