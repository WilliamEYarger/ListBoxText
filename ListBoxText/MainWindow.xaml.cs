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

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(tbxName.Text != "")
            {
                lbx1.Items.Add(tbxName.Text);
            }
        }

        private void lbx1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
          
            if(lbx1.SelectedItem != null)
            {
                MessageBox.Show("You Double clicked" + lbx1.SelectedItem.ToString());
            }
            
        }
    }
}
