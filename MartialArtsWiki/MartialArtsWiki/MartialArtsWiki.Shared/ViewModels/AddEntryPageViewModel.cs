using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Storage.Pickers;
using Windows.ApplicationModel.Activation;

using Parse;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using MartialArtsWiki.Models;

namespace MartialArtsWiki.ViewModels
{
    public class AddEntryPageViewModel : ViewModelBase
    {
        private MartialArt entry;
        private ICommand selectImageCommand;

        public AddEntryPageViewModel ()
        {
            this.MartialArt = new MartialArt();
        }
        public MartialArt MartialArt
        {
            get
            {
                if (this.entry == null)
                {
                    this.entry = new MartialArt();
                }

                return this.entry;
            }
            set
            {
                this.entry = value;
                this.RaisePropertyChanged(() => this.MartialArt);
            }
        }

        public MediaCapture PhotoManager { get; set; }

        public ICommand SelectImage
        {
            get
            {
                if (this.selectImageCommand == null)
                {
                    this.selectImageCommand = new RelayCommand(this.ExecuteSelectImage);
                }

                return this.selectImageCommand;
            }
        }

        private async void ExecuteSelectImage ()
        {
            var picker = new FileOpenPicker()
            {
                ViewMode = PickerViewMode.List,
                FileTypeFilter = { ".jpg"},
                SuggestedStartLocation = PickerLocationId.PicturesLibrary,
                CommitButtonText = "Pick this jpeg"
            };

            
#if WINDOWS_PHONE_APP
            picker.PickSingleFileAndContinue();
            
#elif WINDOWS_APP
            var file = await picker.PickSingleFileAsync();
            var stream = await file.OpenStreamForReadAsync();
            var fileType = file.FileType;
            this.MartialArt.ImageForParse = new ParseFile("image" + fileType, stream);
#endif
        } 

        public async Task<bool> SubmitNewEntry ()
        {
            if (this.MartialArt == null)
            {
                return false;
            }

            if (this.MartialArt.Name == null || this.MartialArt.Description == null
                || this.MartialArt.ImageForParse == null)
            {
                return false;
            }

            this.MartialArt.Owner = ParseUser.CurrentUser;
            await this.MartialArt.ImageForParse.SaveAsync();
            await this.MartialArt.SaveAsync();
            return true;
        }

        public async Task<bool> InitializePhotoManager ()
        {
            var captureSettings = new MediaCaptureInitializationSettings();
            captureSettings.StreamingCaptureMode = StreamingCaptureMode.Video;
            captureSettings.PhotoCaptureSource = PhotoCaptureSource.VideoPreview;

            this.PhotoManager = new MediaCapture();
            await this.PhotoManager.InitializeAsync(captureSettings);

            return true;
        }

        public async void StartPreview ()
        {
            await this.PhotoManager.StartPreviewAsync();
        }

        public async void TakePhoto ()
        {
            var imgFormat = ImageEncodingProperties.CreateJpeg();
            imgFormat.Height = 1000;
            imgFormat.Width = 1000;

            var file = await ApplicationData.Current.TemporaryFolder.CreateFileAsync("photo.jpg", CreationCollisionOption.ReplaceExisting);
            
            await this.PhotoManager.CapturePhotoToStorageFileAsync(imgFormat, file);

            var inputStream = await file.OpenStreamForReadAsync();
            this.MartialArt.ImageForParse = new ParseFile("test.jpg", inputStream);
        }

#if WINDOWS_PHONE_APP
        internal async void PhonePickedFile (FileOpenPickerContinuationEventArgs argument)
        {
            var file = argument.Files.First();
            var stream = await file.OpenStreamForReadAsync();
            var fileType = file.FileType;
            this.MartialArt.ImageForParse = new ParseFile("image" + fileType, stream);
        }
#endif
    }
}
