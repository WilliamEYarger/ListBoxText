using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListBoxText
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           
            InitializeComponent();
        }

        private void Click_FileOpen(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open files");
        }

        private void Click_FileSave(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save files");
        }

        private void Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Click_AddRootItem(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Add Root Element");
        }

        private void Click_AddChildItem(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Add Child Element");
        }

        private void Click_MoveToTree(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Move Selected Item to Tree");
        }

        private void Click_OpenWorkPage(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open selected Items work page");
        }
    }
}
