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
using System.Windows.Shapes;
using ass.ASSASINS_CREEDDataSetTableAdapters;

namespace ass
{
    public partial class Window1 : Window
    {
        GAMESTableAdapter games = new GAMESTableAdapter();
        public Window1()
        {
            InitializeComponent();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            games.InsertQuery(Tbx1.Text, Convert.ToString(Tbx2.Text), Tbx3.Text, Convert.ToDecimal(Tbx4.Text), Tbx5.Text);
            tyopoiGrid1.ItemsSource = games.GetData();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            object id = (tyopoiGrid1.SelectedItem as DataRowView).Row[0];
            games.UpdateQuery(Tbx1.Text, Convert.ToString(Tbx2.Text), Tbx3.Text, Convert.ToDecimal(Tbx4.Text), Tbx5.Text, Convert.ToInt32(id));
            tyopoiGrid1.ItemsSource = games.GetData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (tyopoiGrid1.SelectedItem as DataRowView).Row[0];
            games.DeleteQuery(Convert.ToInt32(id));
            tyopoiGrid1.ItemsSource = games.GetData();
        }
    }
 }
