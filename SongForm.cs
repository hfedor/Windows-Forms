using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HubertFedorowiczPAINLab1
{   
    public partial class SongForm : Form
    {
        private Song song;
        private List<Song> songs;
        private static string path = System.Windows.Forms.Application.StartupPath.Remove(System.Windows.Forms.Application.StartupPath.Length - 9);
        Image rock = Image.FromFile(path + @"rock.png");
        Image jazz = Image.FromFile(path + @"jazz.png");
        Image pop = Image.FromFile(path + @"pop.png");
        Image rap = Image.FromFile(path + @"rap.png");
        int genreNumber = 0;

        public string SongTitle
        {
            get { return titleTextBox.Text; }
        }

        public string SongAuthor
        {
            get { return authorTextBox.Text; }
        }

        public DateTime SongRecordingDay
        {
            get { return recordingDayDateTimePicker.Value; }
        }

        public string SongGenre
        {
            get { return genreTextBox.Text; }
        }

        public SongForm(Song song, List<Song> songs)
        {
            InitializeComponent();
            this.song = song;
            this.songs = songs;
        }

        private void SongForm_Load(object sender, EventArgs e)
        {
            if (song != null)
            {
                titleTextBox.Text = song.Title;
                authorTextBox.Text = song.Author;
                recordingDayDateTimePicker.Value = song.RecordingDate;
                genreTextBox.Text = song.Genre;
            }
            else
            {
                titleTextBox.Text = "Bez Tytułu";
                authorTextBox.Text = "Nieznany";
                recordingDayDateTimePicker.Value = new DateTime(2020, 1, 1);
                genreTextBox.Text = "Rock&Roll";
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            ValidateChildren();
            DialogResult = DialogResult.OK;
            foreach (Song s in songs)
                if ((s.RecordingDate == recordingDayDateTimePicker.Value && s.Title == titleTextBox.Text && s.Author == authorTextBox.Text && !ReferenceEquals(s, song)) || titleTextBox.Text == "")
                    DialogResult = DialogResult.None;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Validating(object sender, CancelEventArgs e)
        {
            try
            {
                foreach (Song s in songs)
                {
                    if (s.RecordingDate == recordingDayDateTimePicker.Value && s.Title == titleTextBox.Text && s.Author == authorTextBox.Text && !ReferenceEquals(s, song))
                        throw new Exception("Piosenka już jest na liście. Zmień którąś z tych wartości.");
                }
            }
            catch( Exception exception )
            {
                errorProvider.SetError(titleTextBox, exception.Message);
                errorProvider.SetError(authorTextBox, exception.Message);
                errorProvider.SetError(recordingDayDateTimePicker, exception.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void GenreTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (genreTextBox.Text == "" )
                    throw new Exception("Gatunek musi zostać podany");
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                errorProvider.SetError(genreTextBox, exception.Message);
            }
        }

        private void ChangeGenre(object sender, EventArgs e)
        {
            genreNumber++;
            if ( genreNumber >= 4 )
                genreNumber = 0;
            switch ( genreNumber )
            {
                case 0:
                    genreButton.Image = rock;
                    genreTextBox.Text = "Rock&Roll";
                    break;
                case 1:
                    genreButton.Image = jazz;
                    genreTextBox.Text = "Jazz";
                    break;
                case 2:
                    genreButton.Image = pop;
                    genreTextBox.Text = "Pop";
                    break;
                case 3:
                    genreButton.Image = rap;
                    genreTextBox.Text = "Rap";
                    break;
            }
        }
    }
}
