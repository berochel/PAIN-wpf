using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PAIN_wpf.Model
{
    class Song : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title")); }
        }

        private string artist;
        public string Artist
        {
            get { return artist; }
            set { artist = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Artist")); }
        }

        private string genre;
        public string Genre
        {
            get { return genre;  }
            set { genre = value;  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Genre"));}
        }
        
        private int releaseDate;
        public int ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ReleaseDate"));}
        }


        public Song(string title, string artist, string genre, int releaseDate)
        {
            this.title = title;
            this.artist = artist;
            this.genre = genre;
            this.releaseDate = releaseDate;
        }
    }
}
