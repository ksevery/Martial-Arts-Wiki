using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using GalaSoft.MvvmLight;
using Parse;

using MartialArtsWiki.Models;
using System.Collections.ObjectModel;

namespace MartialArtsWiki.ViewModels
{
    public class MartialArtsPageViewModel : ViewModelBase
    {
        private Category category;
        private ObservableCollection<MartialArtViewModel> martialArts;

        public Category Category
        {
            get
            {
                return this.category;
            }
            set
            {
                this.category = value;
                this.RaisePropertyChanged(() => this.Category);
            }
        }

        public IEnumerable<MartialArtViewModel> MartialArts 
        {
            get
            {
                if (this.martialArts == null)
                {
                    this.martialArts = new ObservableCollection<MartialArtViewModel>();
                }
                return this.martialArts;
            }
            set
            {
                if (this.martialArts == null)
                {
                    this.martialArts = new ObservableCollection<MartialArtViewModel>();
                }

                this.martialArts.Clear();
                this.martialArts.AddRange(value);
                this.RaisePropertyChanged(() => this.MartialArts);
            }
        }

        public async void LoadMartialArts (Category category)
        {
            var martialArts = await new ParseQuery<MartialArt>("MartialArt")
            .FindAsync();

            this.MartialArts = martialArts.Where(ma => ma.Category.ObjectId == category.ObjectId)
                .AsQueryable()
                .Select(MartialArtViewModel.FromModel);
        }
    }
}
