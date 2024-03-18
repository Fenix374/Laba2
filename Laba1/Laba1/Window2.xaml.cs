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
    public partial class Window2 : Window
    {
        ASSASINS_CREEDEntities asc = new ASSASINS_CREEDEntities();  
        public Window2()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            CHARACTERS c = new CHARACTERS();
            c.NAMEe = Tbx1.Text;
            c.GAMEID = Convert.ToInt32(Tbx2.Text);
            c.DESCRIPTIONn = Tbx3.Text;

            asc.CHARACTERS.Add(c);

            asc.SaveChanges();
            tyopoiGrid2.ItemsSource = asc.CHARACTERS.ToList();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (tyopoiGrid2.SelectedItem != null)
            {
                var selected = tyopoiGrid2.SelectedItem as CHARACTERS;

                selected.NAMEe = Tbx1.Text;
                selected.GAMEID = Convert.ToInt32(Tbx2.Text);
                selected.DESCRIPTIONn = Tbx3.Text;
                asc.SaveChanges();
                tyopoiGrid2.ItemsSource = asc.CHARACTERS.ToList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (tyopoiGrid2.SelectedItem != null)
            {
                asc.CHARACTERS.Remove(tyopoiGrid2.SelectedItem as CHARACTERS);

                asc.SaveChanges();
                tyopoiGrid2.ItemsSource = asc.CHARACTERS.ToList();
            }
        }

        private void tyopoiGrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = tyopoiGrid2.SelectedItem as CHARACTERS;

            Tbx1.Text = selected.NAMEe;
            Tbx2.Text = Convert.ToString(selected.GAMEID);
            Tbx3.Text = selected.DESCRIPTIONn;
        }
    }
}
