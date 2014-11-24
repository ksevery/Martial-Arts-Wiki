using System;
using System.Collections.Generic;
using System.Text;

using Parse;
using GalaSoft.MvvmLight;

using MartialArtsWiki.Models;

namespace MartialArtsWiki.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public Category Category { get; set; }

        public MainPageViewModel ()
        {
            
        }
    }
}
