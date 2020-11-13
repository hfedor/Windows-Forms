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
            SongsFormTree songsFormTree = new SongsFormTree(document);
            songsForm.MdiParent = this;
            songsFormTree.MdiParent = this;
            songsForm.Show();
            songsFormTree.Show();
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Resize(object sender, EventArgs e)
        { 
            LayoutMdi(MdiLayout.TileVertical);
        }
    }
}
