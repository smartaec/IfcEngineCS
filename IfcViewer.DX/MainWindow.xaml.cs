using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataFormats = System.Windows.Forms.DataFormats;
using DragEventArgs = System.Windows.DragEventArgs;

namespace IfcViewer.DX
{
    /// <summary>
    /// MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainViewModel(this.view1, this.tree1);
            this.DataContext = viewModel;
        }

        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);
            Console.WriteLine(e.Data.GetData(typeof(string)));
        }

        protected override void OnPreviewDragEnter(DragEventArgs e)
        {
            base.OnPreviewDragEnter(e);
            Console.WriteLine(e.Data.GetDataPresent(DataFormats.FileDrop));
        }

        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);
            Console.WriteLine(e.Data.GetDataPresent(DataFormats.FileDrop));

        }

        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "ifc Files (*.ifc, *.ifcxml)|*.ifc;*.ifcxml";
            dialog.Title = "Open ifc file";
            dialog.ShowDialog();
            if (dialog.FileName != "") {
                viewModel.OpenFile(dialog.FileName);
                viewModel.ZoomExtent(this.view1);
                this.view1.ReAttach();//without this, we'll get error when rendering
                this.Title = string.Format("{0}(IfcViewer)", System.IO.Path.GetFileNameWithoutExtension(dialog.FileName));
            }
        }
    }
}
