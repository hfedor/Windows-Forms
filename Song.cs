using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubertFedorowiczPAINLab1
{
    public class Song
    {
        public string Title
        {
            get;
            set;
        }

        public string Author
        {
            get;
            set;
        }

        public DateTime RecordingDate
        {
            get;
            set;
        }

        public string Genre
        {
            get;
            set;
        }

        public Song( string title, string author, DateTime recordingDate, string genre )
        {
            Title = title;
            Author = author;
            RecordingDate = recordingDate;
            Genre = genre;
        }
    }
}
