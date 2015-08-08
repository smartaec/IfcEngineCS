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
        IFCViewerWrapper ifcViewerWrapper = null;
        public MainForm()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            InitializeComponent();

            // initialize ifc viewer 
            //      - set destination window where ifc object to be drawn
            ifcViewerWrapper = new IFCViewerWrapper();
            ifcViewerWrapper.InitGraphics(this.splitContainer1.Panel2, this.treeView1);

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "ifc Files (*.ifc)|*.ifc";
            dialog.Title = "Open ifc file";

            if (dialog.ShowDialog() == DialogResult.OK) {
                if (ifcViewerWrapper.OpenIFCFile(dialog.FileName)) {
                    this.Text = string.Format("{0} - ifcviewer", System.IO.Path.GetFileNameWithoutExtension(dialog.FileName));
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

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null != ifcViewerWrapper) {
                ifcViewerWrapper.Reset();
                ifcViewerWrapper.Redraw();
            }
        }

        private void viewFacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // -------------------------------------------------
            // 
            if (null == ifcViewerWrapper) {
                return;
            }

            // -------------------------------------------------
            if (viewFacesToolStripMenuItem == sender) {
                ifcViewerWrapper.Faces = viewFacesToolStripMenuItem.Checked;

                // -------------------------------------------------
                // apply changes to the drawn figure

                ifcViewerWrapper.Redraw();
            }

        }

        private void viewWireFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // -------------------------------------------------
            // 
            if (null == ifcViewerWrapper) {
                return;
            }

            // -------------------------------------------------
            if (viewWireFrameToolStripMenuItem == sender) {
                ifcViewerWrapper.WireFrames = viewWireFrameToolStripMenuItem.Checked;

                // -------------------------------------------------
                // apply changes to the drawn figure

                ifcViewerWrapper.Redraw();
            }

        }

        private void selectOnOverIn3DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // -------------------------------------------------
            // 
            if (null == ifcViewerWrapper) {
                return;
            }

            // -------------------------------------------------
            if (selectOnOverIn3DToolStripMenuItem == sender) {
                selectOnOverIn3DToolStripMenuItem.Checked = !selectOnOverIn3DToolStripMenuItem.Checked;

                ifcViewerWrapper.Hover = selectOnOverIn3DToolStripMenuItem.Checked;

                // -------------------------------------------------
                // apply changes to the drawn figure

                ifcViewerWrapper.Redraw();
            }
        }

        /// <summary>
        /// Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
        }

        /// <summary>
        /// Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right) {
                treeView1.SelectedNode = e.Node;
                contextMenuStrip1.Show(treeView1, new Point(e.X, e.Y));
            } else {
                if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                    ifcViewerWrapper._treeData.OnNodeMouseClick(sender, e);
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ifcViewerWrapper._treeData.OnAfterSelect(sender, e);
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            ifcViewerWrapper._treeData.OnContextMenu_Opened(sender, e);
        }

        private void aboutIfcviewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ifc Viewer based on Helix3D and IfcEngine.", "About");
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
