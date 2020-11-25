using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubertFedorowiczPAINLab1
{
    public class Document
    {
        public List<Song> songs = new List<Song>();

        public event Action<Song> AddSongEvent;
        public event Action<Song> RemoveSongEvent;
        public event Action<Song> EditSongEvent;

        public void AddSong( Song song ) // dodanie piosenki do dokumentu
        {
            songs.Add(song);
            AddSongEvent?.Invoke(song);
        }
        
        public void EditSong(Song oldSong, Song song) // edycja piosenki do dokumentu
        {
            int index = songs.IndexOf(oldSong);
            if (index != -1)
                songs[index] = song;
            EditSongEvent?.Invoke(song);
        }

        public void RemoveSong(Song song) // usuniecie piosenki z dokumentu
        {
            songs.Remove(song);
            RemoveSongEvent?.Invoke(song);
        }

        public void RemoveSong(string genre) // usuniecie piosenek z gatunku
        {
            List<Song> songsToRemove = songs.FindAll(item => item.Genre == genre);
            foreach (Song song in songsToRemove)
                RemoveSong(song);
        }

        public void RemoveSong(string genre, string author) // usuniecie piosenek z gatunku i autora
        {
            List<Song> songsToRemove = songs.FindAll(item => item.Genre == genre && item.Author == author);
            foreach (Song song in songsToRemove)
                RemoveSong(song);
        }

        public void RemoveSong(string genre, string author, string title) // usuniecie piosenek z gatunku, autora i tytułu
        {
            List<Song> songsToRemove = songs.FindAll(item => item.Genre == genre && item.Author == author && item.Title == title);
            foreach (Song song in songsToRemove)
                RemoveSong(song);
        }

        public void RemoveSong(string genre, string author, string title, string date)  // usuniecie piosenek z gatunku, autora, tytułu i dacier
        {
            List<Song> songsToRemove = songs.FindAll(item => item.Genre == genre && item.Author == author && item.Title == title && item.RecordingDate.ToShortDateString() == date);
            foreach (Song song in songsToRemove)
                RemoveSong(song);
        }

        public void EditSong(string genre, string newGenre) // usuniecie piosenek z gatunku
        {
            List<Song> songsToRemove = songs.FindAll(item => item.Genre == genre );
            foreach (Song song in songsToRemove)
                song.Genre = newGenre;
        }

        public void EditSong(string genre, string author, string newAuthor) // usuniecie piosenek z gatunku i autora
        {
            List<Song> songsToRemove = songs.FindAll(item => item.Genre == genre && item.Author == author );
            foreach (Song song in songsToRemove)
                song.Author = newAuthor;
        }

        public void EditSong(string genre, string author, string title, string newTitle) // usuniecie piosenek z gatunku, autora i tytułu
        {
            List<Song> songsToRemove = songs.FindAll(item => item.Genre == genre && item.Author == author && item.Title == title );
            foreach (Song song in songsToRemove)
                song.Title = newTitle;
        }

        public void EditSong(string genre, string author, string title, DateTime date, DateTime newDate)  // usuniecie piosenek z gatunku, autora, tytułu i dacier
        {
            List<Song> songsToRemove = songs.FindAll(item => item.Genre == genre && item.Author == author && item.Title == title && item.RecordingDate == date);
            foreach (Song song in songsToRemove)
                song.RecordingDate = newDate;
        }
    }
}
