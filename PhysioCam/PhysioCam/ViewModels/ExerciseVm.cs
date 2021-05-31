using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using PhysioCam.Interfaces;
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

        private bool NewExercise { get; }

        public string DoneButtonText => NewExercise ? "Add to program" : "Update Exercise";

        public ExerciseVm() : this(new Exercise())
        {
            NewExercise = true;
        }
        
        public ExerciseVm(Exercise exercise)
        {
            PhotoPaths = new ObservableCollection<Models.Image>();

            _exercise = exercise;
            
            var userService = DependencyService.Get<IUserService>();
            _exercise.AppUsers.Add(userService.CurrentUser);

            SaveToProgramCommand = new Command(async() =>
            {
                _addExercise(_exercise);
                await Application.Current.MainPage.Navigation.PopAsync();
            });

            AddPictureCommand = new Command(async () =>
            {
                var addPicture = await App.Current.MainPage.DisplayActionSheet("Camera or Gallery?", "Cancel", null, "Camera", "Gallery");
                switch (addPicture)
                {
                    case "Camera":
                    {
                        var path = await TakePicture();
                        PhotoPaths.Add(new Models.Image { url = path });
                        break;
                    }
                    case "Gallery":
                    {
                        var path = await PickFromGallery();
                        PhotoPaths.Add(new Models.Image { url = path });
                        break;
                    }
                }
            });
        }

        private Exercise _exercise;

        public string Title
        {
            get => _exercise.Title;
            set => _exercise.Title = value;
        }

        public string Description
        {
            get => _exercise.Description;
            set => _exercise.Description = value;
        }

        private string _AddPicutre;

        public string AddPicture
        {
            get => _AddPicutre;
            set { _AddPicutre = value; }
        }


        public bool StandardExercise { get; set; }

        public ICommand SaveToProgramCommand { get; set; }

        public ICommand AddPictureCommand { get; set; }

        private ObservableCollection<Models.Image> _photoPaths;

        public ObservableCollection<Models.Image> PhotoPaths
        {
            get => _photoPaths;
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
                await App.Current.MainPage.DisplayAlert("Error", $"Error when adding photo to Exercise: {ex.Message.ToString()}", "OK");
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
                await App.Current.MainPage.DisplayAlert("Error", $"Error when adding photo to Exercise: {ex.Message.ToString()}", "OK");
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