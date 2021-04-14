using PhysioCam.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhysioCam.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExercisePage : ContentPage
    {
        string PhotoPath;
        public ExercisePage()
        {
            InitializeComponent();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            var button = (ImageButton)sender;

            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                await LoadPhotoAsync(photo);
                if (PhotoPath != null)
                    button.Source = ImageSource.FromFile(PhotoPath);
                else
                    button.Source = ImageSource.FromResource("PhysioCam.Images.TestCamera.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly);

            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", "Error when adding photo to exercise", "OK");
            }
            
        }

        private async void GalleryButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                await LoadPhotoAsync(photo);
                //if (PhotoPath != null)
                //    button.Source = ImageSource.FromFile(PhotoPath);
                //else
                //    button.Source = ImageSource.FromResource("PhysioCam.Images.TestCamera.png", typeof(ImageResourceExtension).GetTypeInfo().Assembly);

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error when adding photo to exercise", "OK");
            }

        }

        async Task LoadPhotoAsync(FileResult photo)
        {
            // canceled
            if (photo == null)
            {
                PhotoPath = null;
                return;
            }
            // save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

            PhotoPath = newFile;
        }
    }
}