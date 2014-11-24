using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MartialArtsWiki.Models;
using Parse;

namespace MartialArtsWiki.ViewModels
{
    public class MartialArtDetailsPageViewModel : ViewModelBase
    {
        private MartialArtViewModel martialArt;

        public MartialArtDetailsPageViewModel ()
        {
            this.MartialArt = new MartialArtViewModel();
        }

        public bool IsEditing { get; set; }

        public MartialArtViewModel MartialArt 
        {
            get
            {

                return this.martialArt;
            }
            set
            {
                this.martialArt = value;
                this.RaisePropertyChanged(() => this.MartialArt);
            }
        }

        public async Task<bool> AddToLocalDbExecute ()
        {
            var isAddSuccessful = await DataSource.Instance.AddMartialArtToLocal(this.MartialArt);

            return isAddSuccessful;
        }

        public async Task UpdateEntry ()
        {
            var parseMartialArt = await new ParseQuery<MartialArt>()
            .Where(ma => ma.ObjectId == this.MartialArt.ObjectId)
            .FirstAsync();

            parseMartialArt.Description = this.MartialArt.Description;
            try
            {
                await parseMartialArt.SaveAsync();
            }
            catch (Exception)
            {
                
            }
        }

        public bool IsEditableEntry ()
        {
            if (this.MartialArt.Creator == null)
            {
                return false;
            }
            return ParseUser.CurrentUser.ObjectId == this.MartialArt.Creator.Id;
        }
    }
}
