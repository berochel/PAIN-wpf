using System;
using System.ComponentModel; 
using PAIN_wpf.Model;
using PAIN_wpf.MVVM;
using System.Windows;
using System.Windows.Data;

namespace PAIN_wpf.ViewModel {
    class SongLibraryViewModel : IViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private SongLibraryModel songLibraryModel {get;}
        private readonly CollectionViewSource collectionViewSourceSongs;
        private Song selectedSong; 

        public Song SelectedSong
        {
            get { return selectedSong; }
            set
            {
                selectedSong = value;
                EditCommand.NotifyCanExecuteChanged();
                DeleteCommand.NotifyCanExecuteChanged();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedSong))); 
            }
        }
        
        public ICollectionView SongLibrary { get; }

        private RelayCommand<object> addCommand; 
        public RelayCommand<object> AddCommand => addCommand = addCommand ?? new RelayCommand<object>(o => AddSong());

        private RelayCommand<object> editCommand;
        public RelayCommand<object> EditCommand => editCommand = editCommand ?? new RelayCommand<object>(o => EditSong());

        private RelayCommand<object> deleteCommand;
        public RelayCommand<object> DeleteCommand => deleteCommand = deleteCommand ?? new RelayCommand<object>(o => DeleteSong()); 

        private RelayCommand<object> newWindowCommand;
        public RelayCommand<object> NewWindowCommand=> newWindowCommand= newWindowCommand?? new RelayCommand<object>(o =>NewWindow()); 

        public Action Close { get ; set ; }

        private string filterText = ""; 
        public string FilterText
        {
            get { return filterText; }
            set
            {
                filterText = value;
                UpdateFilter();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilterText)));
            }
        }

        private string filterCategory= "";
        public string FilterCategory
        {
            get { return filterCategory; }
            set
            {
                filterCategory= value;
                UpdateFilter();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilterCategory)));
            }
        }
        private void UpdateFilter()
        {
            collectionViewSourceSongs.View.Refresh(); 
        }

        private bool FilterSong(Song song)
        {
            if (filterCategory.Equals("Title"))
            {
                return song.Title.Contains(FilterText);
            }
            else if (filterCategory.Equals("Artist"))
            {
                return song.Artist.ToString().Contains(FilterText);
            }
            else if (filterCategory.Equals("Genre"))
            {
                return song.Genre.Contains(FilterText);
            }
            else if (filterCategory.Equals("Release Year"))
            {
                return song.ReleaseDate.ToString().Contains(FilterText);
            }
            return true; 
        }

        public void AddSong()
        {
            SongEditViewModel songViewModel = new SongEditViewModel(songLibraryModel, null);
            ((App)Application.Current).WindowService.ShowDialog(songViewModel); 
        }

        public void EditSong()
        {
            if(selectedSong != null)
            {
                SongEditViewModel songViewModel = new SongEditViewModel(songLibraryModel, selectedSong);
                ((App)Application.Current).WindowService.ShowDialog(songViewModel); 
            }
        }


        public void DeleteSong()
        {
            if(selectedSong != null)
            {
                songLibraryModel.Songs.Remove(selectedSong);
                selectedSong = null; 
            }
        }

        public void NewWindow()
        {
            SongLibraryViewModel songLibraryViewModel = new SongLibraryViewModel(songLibraryModel); 
            ((App)Application.Current).WindowService.Show(songLibraryViewModel); 
        }

        public SongLibraryViewModel(SongLibraryModel songs)
        {
            songLibraryModel = songs;
            collectionViewSourceSongs = new CollectionViewSource
            {
                Source = songLibraryModel.Songs
            };
            collectionViewSourceSongs.View.Filter = (o) => FilterSong((Song)o); 
            SongLibrary = collectionViewSourceSongs.View;

        }
    }
}
