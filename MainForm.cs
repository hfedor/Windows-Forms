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
    public partial class MainForm : Form // glowny formularz
    {
        Document document = new Document();

        public MainForm()
        {
            InitializeComponent();
            IsMdiContainer = true;
        }

        // dodanie nowego okna listy
        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SongsForm songsForm = new SongsForm( document ); // stworzenie nowego formularza
            songsForm.MdiParent = this; // nadanie golnwego formularza jako rodzica
            songsForm.Show(); // wyswietlanie nowego formularza
            LayoutMdi(MdiLayout.TileVertical); // ustawianie nowego formularza w formularzu glownym
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Resize(object sender, EventArgs e)
        { 
            LayoutMdi(MdiLayout.TileVertical); // dopasowanie formularzy po zmianie rizmiaru formularza glownego
        }

        // nowe formularz drzewa
        private void newTreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SongsFormTree songsFormTree = new SongsFormTree(document); // stworzenie nowego formularza
            songsFormTree.MdiParent = this; // nadanie golnwego formularza jako rodzica
            songsFormTree.Show(); // wyswietlanie nowego formularza
            LayoutMdi(MdiLayout.TileVertical); // ustawianie nowego formularza w formularzu glownym
        }
    }
}
