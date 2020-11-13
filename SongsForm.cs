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
    public partial class SongsForm : Form
    {
        string filter = "2000";

        private Document Document { get; set; }

        public SongsForm( Document document )
        {
            InitializeComponent();
            Document = document;
        }

        private void SongsForm_Load(object sender, EventArgs e)
        {
            UpdateItems();
            Document.AddSongEvent += Document_AddSongEvent;
            Document.RemoveSongEvent += Document_RemoveSongEvent;
            this.columnHeaderTitle.Width = this.toolStripContainer1.ContentPanel.Width/3;
            this.columnHeaderAuthor.Width = this.toolStripContainer1.ContentPanel.Width / 3;
            this.columnHeaderGenre.Width = this.toolStripContainer1.ContentPanel.Width / 3 - 85;
            this.songsCounter.Text = Document.songs.Count().ToString();
        }

        private void Document_AddSongEvent(Song song)
        {
            ListViewItem item = new ListViewItem();
            item.Tag = song;
            UpdateItem(item);
            songsListView.Items.Add(item);
        }

        private void Document_RemoveSongEvent(Song song)
        {
            var item = this.songsListView.Items.Cast<ListViewItem>()
                .Where(i => (
                       i.SubItems[0].Text == song.Title &&
                       i.SubItems[1].Text == song.Author &&
                       i.SubItems[2].Text == song.RecordingDate.ToShortDateString() &&
                       i.SubItems[3].Text == song.Genre 
                       )
                 )
                .FirstOrDefault();
            songsListView.Items.Remove((ListViewItem)item);
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SongForm songForm = new SongForm(null, Document.songs);
            if( songForm.ShowDialog() == DialogResult.OK)
            {
                Song newSong = new Song(songForm.SongTitle, songForm.SongAuthor, songForm.SongRecordingDay, songForm.SongGenre);

                Document.AddSong(newSong);

                this.songsCounter.Text = Document.songs.Count().ToString();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if( songsListView.SelectedItems.Count == 1)
            {
                Song song = (Song)songsListView.SelectedItems[0].Tag;
                SongForm songForm = new SongForm(song, Document.songs);
                if (songForm.ShowDialog() == DialogResult.OK)
                {
                    song.Title = songForm.SongTitle;
                    song.Author = songForm.SongAuthor;
                    song.RecordingDate = songForm.SongRecordingDay;
                    song.Genre = songForm.SongGenre;
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (songsListView.SelectedItems.Count == 1)
            {
                Song song = (Song)songsListView.SelectedItems[0].Tag;

                Document.RemoveSong(song);

                this.songsCounter.Text = Document.songs.Count().ToString();
            }
        }

        private void UpdateItem( ListViewItem item )
        {
            Song song = (Song)item.Tag;
            while (item.SubItems.Count < 4)
                item.SubItems.Add(new ListViewItem.ListViewSubItem());
            item.SubItems[0].Text = song.Title;
            item.SubItems[1].Text = song.Author;
            item.SubItems[2].Text = song.RecordingDate.ToShortDateString();
            item.SubItems[3].Text = song.Genre;
        }

        private void UpdateItems()
        {
            songsListView.Items.Clear();
            foreach (Song song in Document.songs)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = song;
                UpdateItem(item);
                if (filterSignButton.Text == ">")
                {
                    if (!filterButton.Checked || song.RecordingDate.Year > Int32.Parse(filterTextBox.Text))
                        songsListView.Items.Add(item);
                }
                else
                    if (!filterButton.Checked || song.RecordingDate.Year < Int32.Parse(filterTextBox.Text))
                        songsListView.Items.Add(item);
            }
            this.songsCounter.Text = Document.songs.Count().ToString();
        }

        private void SongsForm_Activated(object sender, EventArgs e)
        {
            ToolStripManager.Merge(toolStrip1, ((MainForm)MdiParent).toolStrip1);
        }

        private void SongsForm_Deactivate(object sender, EventArgs e)
        {
            ToolStripManager.RevertMerge(((MainForm)MdiParent).toolStrip1, toolStrip1);
        }

        private void SongsForm_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = ( Application.OpenForms.OfType<SongsForm>().Count() <= 1 );
        }

        private void toolStripContainer1_SizeChange(object sender, EventArgs e)
        {
            this.columnHeaderTitle.Width = this.toolStripContainer1.ContentPanel.Width / 3;
            this.columnHeaderAuthor.Width = this.toolStripContainer1.ContentPanel.Width / 3;
            this.columnHeaderGenre.Width = this.toolStripContainer1.ContentPanel.Width / 3 - 85;
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            if (filterButton.Checked == true)
            {
                filterButton.Checked = false;
                filterTextBox.Visible = false;
                filterSignButton.Visible = false;
            }
            else
            {
                filterButton.Checked = true;
                filterTextBox.Visible = true;
                filterSignButton.Visible = true;
            }
            UpdateItems();
        }

        private void filterTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!Int32.TryParse(filterTextBox.Text, out int filterValue))
                    throw new Exception("To nie liczba!");
                if (filterValue < 0)
                    throw new Exception("Nie może być mniejsze od 0!");
                if (filterValue > 2020)
                    throw new Exception("Nie może być większe od 2020!");
                filter = filterTextBox.Text;
            }
            catch (Exception exception)
            {
                e.Cancel = true;
                MessageBox.Show(exception.Message,
                                "Błędne dane filtorwania!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                               );
                filterTextBox.Text = filter;
            }
        }

        private void filterSignButton_Click(object sender, EventArgs e)
        {
            if (filterSignButton.Text == "<")
                filterSignButton.Text = ">";
            else
                filterSignButton.Text = "<";
            UpdateItems();
        }
    }
}
