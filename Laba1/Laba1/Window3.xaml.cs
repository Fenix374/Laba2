using System;
using System.Collections.Generic;
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

namespace ass
{

    public partial class Window3 : Window
    {
        ASSASINS_CREEDEntities asc = new ASSASINS_CREEDEntities();
        public Window3()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            GAMES g = new GAMES();
            g.TITLE = Tbx1.Text;
            g.REALESEDATE = Convert.ToDateTime(Tbx2.Text);
            g.PLATFORMS = Tbx3.Text;
            g.RATING = Convert.ToDecimal(Tbx4.Text);
            g.DESCRIPTIONn = Tbx5.Text;

            asc.GAMES.Add(g);

            asc.SaveChanges();
            dolbaniGrid2.ItemsSource = asc.GAMES.ToList();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (dolbaniGrid2.SelectedItem != null)
            {
                var selected = dolbaniGrid2.SelectedItem as GAMES;

                selected.TITLE = Tbx1.Text;
                selected.REALESEDATE = Convert.ToDateTime(Tbx2.Text);
                selected.PLATFORMS = Tbx3.Text;
                selected.RATING = Convert.ToDecimal(Tbx4.Text);
                selected.DESCRIPTIONn = Tbx5.Text;
                asc.SaveChanges();
                dolbaniGrid2.ItemsSource = asc.GAMES.ToList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dolbaniGrid2.SelectedItem != null)
            {
                asc.GAMES.Remove(dolbaniGrid2.SelectedItem as GAMES);

                asc.SaveChanges();
                dolbaniGrid2.ItemsSource = asc.GAMES.ToList();
            }
        }

        private void dolbaniGrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = dolbaniGrid2.SelectedItem as GAMES;

            Tbx1.Text = selected.TITLE;
            Tbx2.Text = Convert.ToString(selected.REALESEDATE);
            Tbx3.Text = selected.PLATFORMS;
            Tbx4.Text = Convert.ToString(selected.RATING);
            Tbx5.Text = selected.DESCRIPTIONn;
        }
    }
}
