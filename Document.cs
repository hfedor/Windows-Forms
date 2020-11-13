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

        public void AddSong( Song song )
        {
            songs.Add(song);
            AddSongEvent?.Invoke(song);
        }

        public void RemoveSong(Song song)
        {
            songs.Remove(song);
            RemoveSongEvent?.Invoke(song);
        }

        public void RemoveSong(string genre)
        {
            List<Song> songsToRemove = songs.FindAll(item => item.Genre == genre );
            foreach (Song song in songsToRemove)
                RemoveSong(song);
        }

        public void RemoveSong(string genre, string author)
        {
            List<Song> songsToRemove = songs.FindAll(item => item.Genre == genre && item.Author == author );
            foreach (Song song in songsToRemove)
                RemoveSong(song);
        }

        public void RemoveSong(string genre, string author, string title)
        {
            List<Song> songsToRemove = songs.FindAll(item => item.Genre == genre && item.Author == author && item.Title == title );
            foreach (Song song in songsToRemove)
                RemoveSong(song);
        }

        public void RemoveSong(string genre, string author, string title, string date)
        {
            List<Song> songsToRemove = songs.FindAll(item => item.Genre == genre && item.Author == author && item.Title == title && item.RecordingDate.ToShortDateString() == date);
            foreach (Song song in songsToRemove)
                RemoveSong(song);
        }
    }
}
