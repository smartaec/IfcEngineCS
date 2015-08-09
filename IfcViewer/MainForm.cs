using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace IFCViewer
{
    public partial class MainForm : Form
    {
        ViewController _viewController = null;
        public MainForm()
        {
            InitializeComponent();

            //initialize ifc viewer 
            //- set destination window where ifc object to be drawn
            _viewController = new ViewController();
            _viewController.InitGraphics(this.splitContainer1.Panel2, this.treeView1);

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "ifc Files (*.ifc, *.ifcxml)|*.ifc;*.ifcxml";
            dialog.Title = "Open ifc file";

            if (dialog.ShowDialog() == DialogResult.OK) {
                if (_viewController.OpenIFCFile(dialog.FileName)) {
                    this.Text = string.Format("{0} - Ifc Viewer", System.IO.Path.GetFileNameWithoutExtension(dialog.FileName));
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.BackColor = Color.Transparent;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewFacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == _viewController) {
                return;
            }

            if (viewFacesToolStripMenuItem == sender) {
                _viewController.Faces = viewFacesToolStripMenuItem.Checked;
            }

        }

        private void viewWireFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == _viewController) {
                return;
            }

            if (viewWireFrameToolStripMenuItem == sender) {
                _viewController.WireFrames = viewWireFrameToolStripMenuItem.Checked;
            }

        }

        private void selectOnOverin3DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == _viewController) {
                return;
            }

            if (selectOnOverin3DToolStripMenuItem == sender) {
                selectOnOverin3DToolStripMenuItem.Checked = !selectOnOverin3DToolStripMenuItem.Checked;

                _viewController.Hover = selectOnOverin3DToolStripMenuItem.Checked;
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right) {
                treeView1.SelectedNode = e.Node;
                contextMenuStrip1.Show(treeView1, new Point(e.X, e.Y));
            } else {
                if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                    _viewController._treeData.OnNodeMouseClick(sender, e);
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _viewController._treeData.OnAfterSelect(sender, e);
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            _viewController._treeData.OnContextMenu_Opened(sender, e);
        }

        private void aboutIfcviewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ifc Viewer based on Helix3D and IfcEngine.\n By lin(at)bimer.cn", "About");
        }

        private void Panel2_MouseEnter(object sender, EventArgs e)
        {
            if (!this.splitContainer1.Panel2.Focused) {
                this.splitContainer1.Panel2.Focus();
            }
        }

        private void Panel2_MouseLeave(object sender, EventArgs e)
        {
            if (this.splitContainer1.Panel2.Focused) {
                this.splitContainer1.Panel2.Parent.Focus();
            }
        }
    }
}
