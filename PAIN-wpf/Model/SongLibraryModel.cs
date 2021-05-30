using System;
using System.Collections.ObjectModel;

namespace PAIN_wpf.Model
{
    class SongLibraryModel
    {
        public ObservableCollection<Song> Songs { get; set; } = new ObservableCollection<Song>(); 

        public SongLibraryModel()
        {
            Songs.Add(new Song("A", "A", Enum.GetName(typeof(Genre), 1), 2015));
            Songs.Add(new Song("B", "B", Enum.GetName(typeof(Genre), 1), 2021));
            Songs.Add(new Song("C", "C", Enum.GetName(typeof(Genre), 2), 2016));
        }
    }
}
