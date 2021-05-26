using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using PhysioCam.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PhysioCam.ViewModels
{
    public class ExerciseVm : PhysioCamVm
    {
        public delegate void AddExercise(Exercise exercise);

        private AddExercise _addExercise;

        public void Attach(AddExercise ex)
        {
            _addExercise += ex;
        }
        
        public ExerciseVm(Exercise exercise)
        {
            PhotoPaths = new ObservableCollection<Models.Image>();

            if (exercise == null)
            {
                _exercise = new Exercise();
                NewExercise = true;
            }
            else
            {
                _exercise = exercise;
            }

            SaveToProgramCommand = new Command(async() =>
            {
                _addExercise(_exercise);
                await Application.Current.MainPage.Navigation.PopAsync();
            });

            AddPictureCommand = new Command(async () =>
            {
                var addPicture = await App.Current.MainPage.DisplayActionSheet("Camera or Gallery?", "Cancel", null, "Camera", "Gallery");
                if(addPicture == "Camera")
                {
                    var path = await TakePicture();
                    PhotoPaths.Add(new Models.Image() { Path = path });
                }
                if(addPicture == "Gallery")
                {
                    var path = await PickFromGallery();
                    PhotoPaths.Add(new Models.Image() { Path = path });
                }
            });
        }

        private Exercise _exercise;

        public bool NewExercise { get; }

        public string Name
        {
            get => _exercise.Name;
            set => _exercise.Name = value;
        }

        public string Description
        {
            get => _exercise.Description;
            set => _exercise.Description = value;
        }

        private string _AddPicutre;

        public string AddPicture
        {
            get { return _AddPicutre; }
            set { _AddPicutre = value; OnPropertyChanged("AddPicture"); }
        }


        public bool StandardExercise { get; set; }

        public ICollection<string> Images { get; set; }

        public ICommand SaveToProgramCommand { get; set; }

        public ICommand AddPictureCommand { get; set; }

        private ObservableCollection<Models.Image> _photoPaths;

        public ObservableCollection<Models.Image> PhotoPaths
        {
            get { return _photoPaths; }
            set { _photoPaths = value; OnPropertyChanged("PhotoPaths"); }
        }


        public async Task<string> TakePicture()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                var path = await LoadPhotoAsync(photo);

                return path;
            }
            catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Error when adding photo to exercise: {ex.Message.ToString()}", "OK");
                return null;
            }
        }

        public async Task<string> PickFromGallery()
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                var path = await LoadPhotoAsync(photo);

                return path;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Error when adding photo to exercise: {ex.Message.ToString()}", "OK");
                return null;
            }
        }

        private async Task<string> LoadPhotoAsync(FileResult photo)
        {
            string PhotoPath = "";
            // canceled
            if (photo == null)
            {
                PhotoPath = null;
                return PhotoPath;
            }
            // save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

            PhotoPath = newFile;

            return PhotoPath;
        }
    }
}