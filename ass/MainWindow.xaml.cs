using System;
using System.Collections.Generic;
using System.Data;
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
using ass.ASSASINS_CREEDDataSetTableAdapters;

namespace ass
{
    public partial class MainWindow : Window
    {
        CHARACTERSTableAdapter characters = new CHARACTERSTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            dolbaniGrid1.ItemsSource = characters.GetData();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            characters.InsertQuery(Tbx1.Text, Convert.ToInt32(Tbx2.Text), Tbx3.Text);
            dolbaniGrid1.ItemsSource = characters.GetData();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            object id = (dolbaniGrid1.SelectedItem as DataRowView).Row[0];
            characters.UpdateQuery(Tbx1.Text, Convert.ToInt32(Tbx2.Text), Tbx3.Text, Convert.ToInt32(id));
            dolbaniGrid1.ItemsSource = characters.GetData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (dolbaniGrid1.SelectedItem as DataRowView).Row[0];
            characters.DeleteQuery(Convert.ToInt32(id));
            dolbaniGrid1.ItemsSource = characters.GetData();
        }
    }
}
