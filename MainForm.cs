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
    public partial class MainForm : Form
    {
        Document document = new Document();

        public MainForm()
        {
            InitializeComponent();
            IsMdiContainer = true;
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SongsForm songsForm = new SongsForm( document );
            songsForm.MdiParent = this;
            songsForm.Show();
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Resize(object sender, EventArgs e)
        { 
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void newTreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SongsFormTree songsFormTree = new SongsFormTree(document);
            songsFormTree.MdiParent = this;
            songsFormTree.Show();
            LayoutMdi(MdiLayout.TileVertical);  
        }
    }
}
