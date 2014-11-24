using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace MartialArtsWiki.ViewModels
{
    public class MartialArtDetailsPageViewModel : ViewModelBase
    {
        private MartialArtViewModel martialArt;

        public MartialArtDetailsPageViewModel ()
        {
            this.MartialArt = new MartialArtViewModel();
        }

        public MartialArtViewModel MartialArt 
        {
            get
            {
                if (this.martialArt == null)
                {
                    this.martialArt = new MartialArtViewModel();
                }

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
    }
}
