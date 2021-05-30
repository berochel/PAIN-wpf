using PAIN_wpf.Model;
using PAIN_wpf.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PAIN_wpf.ViewModel
{
    class SongEditViewModel : IViewModel
    {
        private SongLibraryModel songLibraryModel;
        private Song song { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public int ReleaseDate { get; set; }
        public Action Close { get; set; }

        public SongEditViewModel(SongLibraryModel songLibraryModel, Song song)
        {
            this.songLibraryModel = songLibraryModel;
            this.song = song;

            if (song != null)
            {
                Title = song.Title;
                Artist = song.Artist;
                Genre = song.Genre;
                ReleaseDate = song.ReleaseDate;
            }

        }


        private RelayCommand<object> cancelCommand;
        public RelayCommand<object> CancelCommand => cancelCommand = cancelCommand ?? new RelayCommand<object>(o => Cancel());

        private RelayCommand<object> okCommand;
        public RelayCommand<object> OkCommand => okCommand = okCommand ?? new RelayCommand<object>(o => Ok());


        private void Cancel()
        {
            Close?.Invoke();
        }

        private void Ok()
        {
            if (song == null)
            {
                song = new Song(Title, Artist, Genre, ReleaseDate);
                songLibraryModel.Songs.Add(song);
            }
            else
            {
                song.Title = Title;
                song.Artist = Artist;
                song.Genre = Genre;
                song.ReleaseDate = ReleaseDate;
            }
            Close?.Invoke(); 
        }

        public Genre SelectedMyEnumType
        {
            get { if (Genre == null)
                    return (Genre)Enum.Parse(typeof(Genre), "ROCK");
                else
                    return (Genre)Enum.Parse(typeof(Genre), Genre);
            }
            set
            {
                Genre = value.ToString();
            }
        }

        public IEnumerable<Genre> MyEnumTypeValues
        {
            get
            {
                return Enum.GetValues(typeof(Genre))
                    .Cast<Genre>();
            }
        }



    }
}
