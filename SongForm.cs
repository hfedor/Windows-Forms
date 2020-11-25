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
    public partial class SongForm : Form // formularz dodawania/edytowania piosenki pisoenki
    {
        private Song song; // dodawana/edytowna piosenka
        private List<Song> songs; // lista piosenek
        private static string path = System.Windows.Forms.Application.StartupPath.Remove(System.Windows.Forms.Application.StartupPath.Length - 9);
        Image rock = Image.FromFile(path + @"rock.png");
        Image jazz = Image.FromFile(path + @"jazz.png");
        Image pop = Image.FromFile(path + @"pop.png");
        Image rap = Image.FromFile(path + @"rap.png");
        int genreNumber = 0;

        public string SongTitle // tytul wprowadzony w formularzu
        {
            get { return titleTextBox.Text; }
        }

        public string SongAuthor  // autor wprowadzony w formularzu
        {
            get { return authorTextBox.Text; }
        }

        public DateTime SongRecordingDay // data wprowadzony w formularzu
        {
            get { return recordingDayDateTimePicker.Value; }
        }

        public string SongGenre // gatunek wprowadzony w formularzu
        {
            get { return genreTextBox.Text; }
        }

        public SongForm(Song song, List<Song> songs)
        {
            InitializeComponent();
            this.song = song;
            this.songs = songs;
        }

        private void SongForm_Load(object sender, EventArgs e) // przy zaladowaniu formularzu
        {
            if (song != null) // przy edycji
            {
                titleTextBox.Text = song.Title;
                authorTextBox.Text = song.Author;
                recordingDayDateTimePicker.Value = song.RecordingDate;
                genreTextBox.Text = song.Genre;
            }
            else // przy dodawanu nowej
            {
                titleTextBox.Text = "Bez Tytułu";
                authorTextBox.Text = "Nieznany";
                recordingDayDateTimePicker.Value = new DateTime(2020, 1, 1);
                genreTextBox.Text = "Rock&Roll";
            }
        }

        private void OkButton_Click(object sender, EventArgs e) // zatwierdzenie
        {
            ValidateChildren(); // walidacja kontrolek w formularzu
            DialogResult = DialogResult.OK;
            foreach (Song s in songs) // sprawdzanie czy pisoneka już instnieje
                if ((s.RecordingDate == recordingDayDateTimePicker.Value && s.Title == titleTextBox.Text && s.Author == authorTextBox.Text && !ReferenceEquals(s, song)) || titleTextBox.Text == "")
                    DialogResult = DialogResult.None; // jeśli tak to nie można dodać
        }

        private void CancelButton_Click(object sender, EventArgs e) // anulowanie
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Validating(object sender, CancelEventArgs e) // walidacja
        {
            try
            {
                foreach (Song s in songs) // sprawdzanie czy piosneka jest juz na liscie
                {
                    if (s.RecordingDate == recordingDayDateTimePicker.Value && s.Title == titleTextBox.Text && s.Author == authorTextBox.Text && !ReferenceEquals(s, song))
                        throw new Exception("Piosenka już jest na liście. Zmień którąś z tych wartości.");
                }
            }
            catch( Exception exception ) // jesli jest na lsicie
            {
                errorProvider.SetError(titleTextBox, exception.Message);
                errorProvider.SetError(authorTextBox, exception.Message);
                errorProvider.SetError(recordingDayDateTimePicker, exception.Message);
            }
        }

        private void GenreTextBox_Validating(object sender, CancelEventArgs e) // validacja kontrolki gatunku
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

        private void ChangeGenre(object sender, EventArgs e) // zmiana gatunku przez nacisniecie ikony
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
