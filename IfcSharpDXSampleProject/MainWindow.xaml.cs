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

namespace IfcSharpDXSampleProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel vm;

        public MainWindow()
        {
            InitializeComponent();
            vm = new ViewModel(viewport,treeview);
            DataContext = vm;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "ifc Files (*.ifc, *.ifcxml)|*.ifc;*.ifcxml";
            dialog.Title = "Open ifc file";
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                vm.ParseFile(dialog.FileName);
                window.Title = string.Format("{0} - Ifc Viewer", System.IO.Path.GetFileNameWithoutExtension(dialog.FileName));
            }
        }

    }
}
