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
    public partial class SongsFormTree : Form
    {
        private Document Document { get; set; }

        public SongsFormTree(Document document)
        {
            InitializeComponent();
            Document = document;
        }

        private void SongsFormTree_Load(object sender, EventArgs e)
        {
            songsTreeView.Nodes.Clear();
            UpdateItems();
            Document.AddSongEvent += Document_AddSongEvent;
            Document.RemoveSongEvent += Document_RemoveSongEvent;
        }

        private void Document_AddSongEvent(Song song)
        {
            songsTreeView.BeginUpdate();

            int genreIndex = -1;
            int authorIndex = -1;
            int titleIndex = -1;
            int dateIndex = -1;

            for (int i = 0; i < songsTreeView.Nodes.Count; i++)
            {
                if (songsTreeView.Nodes[i].Text == song.Genre)
                {
                    genreIndex = i;
                    break;
                }
            }

            if (genreIndex == -1)
            {
                songsTreeView.Nodes.Add(song.Genre);
                genreIndex = songsTreeView.Nodes.Count - 1;
            }

            for (int i = 0; i < songsTreeView.Nodes[genreIndex].Nodes.Count; i++)
            {
                if (songsTreeView.Nodes[genreIndex].Nodes[i].Text == song.Author)
                {
                    authorIndex = i;
                    break;
                }
            }

            if (authorIndex == -1)
            {
                songsTreeView.Nodes[genreIndex].Nodes.Add(song.Author);
                authorIndex = songsTreeView.Nodes[genreIndex].Nodes.Count - 1;
            }

            for (int i = 0; i < songsTreeView.Nodes[genreIndex].Nodes[authorIndex].Nodes.Count; i++)
            {
                if (songsTreeView.Nodes[genreIndex].Nodes[authorIndex].Nodes[i].Text == song.Title)
                {
                    titleIndex = i;
                    break;
                }
            }

            if (titleIndex == -1)
            {
                songsTreeView.Nodes[genreIndex].Nodes[authorIndex].Nodes.Add(song.Title);
                titleIndex = songsTreeView.Nodes[genreIndex].Nodes[authorIndex].Nodes.Count - 1;
            }

            for (int i = 0; i < songsTreeView.Nodes[genreIndex].Nodes[authorIndex].Nodes[titleIndex].Nodes.Count; i++)
            {
                if (songsTreeView.Nodes[genreIndex].Nodes[authorIndex].Nodes[titleIndex].Nodes[i].Text == song.Title)
                {
                    dateIndex = i;
                    break;
                }
            }

            if (dateIndex == -1)
            {
                songsTreeView.Nodes[genreIndex].Nodes[authorIndex].Nodes[titleIndex].Nodes.Add(song.RecordingDate.ToShortDateString());
                dateIndex = songsTreeView.Nodes[genreIndex].Nodes[authorIndex].Nodes[titleIndex].Nodes.Count - 1;
            }

            songsTreeView.EndUpdate();
        }

        private void Document_RemoveSongEvent(Song song)
        {
            songsTreeView.BeginUpdate();

            for (int i1 = 0; i1 < songsTreeView.Nodes.Count; i1++)
            {
                if (songsTreeView.Nodes[i1].Text == song.Genre)
                {
                    for (int i2 = 0; i2 < songsTreeView.Nodes[i1].Nodes.Count; i2++)
                    {
                        if (songsTreeView.Nodes[i1].Nodes[i2].Text == song.Author)
                        {
                            for (int i3 = 0; i3 < songsTreeView.Nodes[i1].Nodes[i2].Nodes.Count; i3++)
                            {
                                if (songsTreeView.Nodes[i1].Nodes[i2].Nodes[i3].Text == song.Title)
                                {
                                    for(int i4 = 0; i4 < songsTreeView.Nodes[i1].Nodes[i2].Nodes[i3].Nodes.Count; i4++)
                                    {
                                        if (songsTreeView.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Text == song.RecordingDate.ToShortDateString())
                                            songsTreeView.Nodes[i1].Nodes[i2].Nodes[i3].Nodes[i4].Remove();
                                    }
                                    if (songsTreeView.Nodes[i1].Nodes[i2].Nodes[i3].Nodes.Count == 0)
                                        songsTreeView.Nodes[i1].Nodes[i2].Nodes[i3].Remove();
                                }
                            }
                            if (songsTreeView.Nodes[i1].Nodes[i2].Nodes.Count == 0)
                                songsTreeView.Nodes[i1].Nodes[i2].Remove();
                        }
                    }
                    if (songsTreeView.Nodes[i1].Nodes.Count == 0)
                        songsTreeView.Nodes[i1].Remove();
                }
            }

            songsTreeView.EndUpdate();
        }

        private void UpdateItems()
        {
            songsTreeView.BeginUpdate();
            songsTreeView.Nodes.Clear();

            foreach (Song song in Document.songs)
            {
                int genreIndex = -1;
                int authorIndex = -1;
                int titleIndex = -1;
                int dateIndex = -1;

                for (int i = 0; i < songsTreeView.Nodes.Count; i++)
                {
                    if (songsTreeView.Nodes[i].Text == song.Genre)
                    {
                        genreIndex = i;
                        break;
                    }
                }

                if (genreIndex == -1)
                {
                    songsTreeView.Nodes.Add(song.Genre);
                    genreIndex = songsTreeView.Nodes.Count - 1;
                }

                for (int i = 0; i < songsTreeView.Nodes[genreIndex].Nodes.Count; i++)
                {
                    if (songsTreeView.Nodes[genreIndex].Nodes[i].Text == song.Author)
                    {
                        authorIndex = i;
                        break;
                    }
                }

                if (authorIndex == -1)
                {
                    songsTreeView.Nodes[genreIndex].Nodes.Add(song.Author);
                    authorIndex = songsTreeView.Nodes[genreIndex].Nodes.Count - 1;
                }

                for (int i = 0; i < songsTreeView.Nodes[genreIndex].Nodes[authorIndex].Nodes.Count; i++)
                {
                    if (songsTreeView.Nodes[genreIndex].Nodes[authorIndex].Nodes[i].Text == song.Title)
                    {
                        titleIndex = i;
                        break;
                    }
                }

                if (titleIndex == -1)
                {
                    songsTreeView.Nodes[genreIndex].Nodes[authorIndex].Nodes.Add(song.Title);
                    titleIndex = songsTreeView.Nodes[genreIndex].Nodes[authorIndex].Nodes.Count - 1;
                }

                for (int i = 0; i < songsTreeView.Nodes[genreIndex].Nodes[authorIndex].Nodes[titleIndex].Nodes.Count; i++)
                {
                    if (songsTreeView.Nodes[genreIndex].Nodes[authorIndex].Nodes[titleIndex].Nodes[i].Text == song.Title)
                    {
                        dateIndex = i;
                        break;
                    }
                }

                if (dateIndex == -1)
                {
                    songsTreeView.Nodes[genreIndex].Nodes[authorIndex].Nodes[titleIndex].Nodes.Add(song.RecordingDate.ToShortDateString());
                    dateIndex = songsTreeView.Nodes[genreIndex].Nodes[authorIndex].Nodes[titleIndex].Nodes.Count - 1;
                }

                songsTreeView.EndUpdate();
            }
            songsTreeView.EndUpdate();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SongForm songForm = new SongForm(null, Document.songs);
            if (songForm.ShowDialog() == DialogResult.OK)
            {
                Song newSong = new Song(songForm.SongTitle, songForm.SongAuthor, songForm.SongRecordingDay, songForm.SongGenre);

                Document.AddSong(newSong);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (songsTreeView.SelectedNode != null)
            {
                TreeNode node = songsTreeView.SelectedNode;
                int i = 0;
                while(node.Parent != null)
                {
                    node = node.Parent;
                    i++;
                }
                node = songsTreeView.SelectedNode;
                
                switch ( i )
                {
                    case 0:
                        Document.RemoveSong( node.Text );
                        break;
                    case 1:
                        Document.RemoveSong( node.Parent.Text, node.Text );
                        break;
                    case 2:
                        Document.RemoveSong( node.Parent.Parent.Text, node.Parent.Text, node.Text );
                        break;
                    case 3:
                        Document.RemoveSong( node.Parent.Parent.Parent.Text, node.Parent.Parent.Text, node.Parent.Text, node.Text);
                        break;
                }

                TreeNode parent = node.Parent;
                node.Remove();
                if (parent != null)
                    deleteEmptyParrents(parent);
            }
        }

        private void deleteEmptyParrents(TreeNode node)
        {
            if (node.Nodes.Count == 0)
            {
                TreeNode parent = node.Parent;
                node.Remove();
                if(parent != null)
                    deleteEmptyParrents(parent);
            }
        }

        private void SongsFormTree_Activated(object sender, EventArgs e)
        {
            ToolStripManager.Merge(toolStrip1, ((MainForm)MdiParent).toolStrip1);
        }

        private void SongsFormTree_Deactivate(object sender, EventArgs e)
        {
            ToolStripManager.RevertMerge(((MainForm)MdiParent).toolStrip1, toolStrip1);
        }

        private void SongsFormTree_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = (Application.OpenForms.OfType<SongsForm>().Count() + Application.OpenForms.OfType<SongsFormTree>().Count() <= 1);
        }
    }
}
