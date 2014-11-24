using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Parse;
using SQLite;
using Windows.UI.Xaml.Media.Imaging;

namespace MartialArtsWiki.Models
{
    [ParseClassName("MartialArt")]
    public class MartialArt : ParseObject
    {
        [ParseFieldName("category")]
        public Category Category 
        {
            get { return GetProperty<Category>(); }
            set { SetProperty<Category>(value); }
        }

        [ParseFieldName("name")]
        public string Name
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("description")]
        public string Description
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("image")]
        public ParseFile ImageForParse
        {
            get { return GetProperty<ParseFile>(); }
            set { SetProperty<ParseFile>(value); }
        }
    }
}
