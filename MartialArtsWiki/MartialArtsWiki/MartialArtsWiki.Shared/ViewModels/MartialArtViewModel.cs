using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Net.Http;
using System.Text;
using MartialArtsWiki.Models;
using Parse;
using SQLite;
using Windows.UI.Xaml.Media.Imaging;
using GalaSoft.MvvmLight;

namespace MartialArtsWiki.ViewModels
{

    [Table("MartialArts")]
    public class MartialArtViewModel : ViewModelBase
    {
        private ParseFile parseFile;
        private BitmapImage image;
        private string description;

        [Ignore]
        public static Expression<Func<MartialArt, MartialArtViewModel>> FromModel
        {
            get
            {
                return model => new MartialArtViewModel
                {
                    Name = model.Name,
                    Description = model.Description,
                    Category = model.Category.CategoryType,
                    ImageFromParse = model.ImageForParse,
                    Creator = UserViewModel.ConvertParseUser(model.Owner),
                    ObjectId = model.ObjectId
                };
            }
        }

        [Ignore]
        public string ObjectId { get; set; }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Ignore]
        public UserViewModel Creator { get; set; }

        public string Name { get; set; }

        public string Description 
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
                this.RaisePropertyChanged(() => this.Description);
            }
        }

        public Categories Category { get; set; }

        [Ignore]
        public ParseFile ImageFromParse 
        {
            get
            {
                return this.parseFile;
            }
            set
            {
                this.parseFile = value;
                this.SetImage();
            }
        }

        [Ignore]
        public BitmapImage Image 
        {
            get
            {
                this.SetImage();
                return this.image;
            }
            set
            {
                this.image = value;
            }
        }

        public byte[] ImageInSqlite { get; set; }

        private async void SetImage ()
        {
            if (this.ImageFromParse == null)
            {
                return;
            }

            //byte[] data = await new HttpClient().GetByteArrayAsync(this.ImageFromParse.Url);
            var image = new BitmapImage(this.ImageFromParse.Url);
            this.Image = image;
        }
    }
}
