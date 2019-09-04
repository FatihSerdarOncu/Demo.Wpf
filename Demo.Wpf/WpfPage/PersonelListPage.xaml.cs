using Demo.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static Demo.Wpf.PersonelModel;

namespace Demo.Wpf.WpfPage
{
    /// <summary>
    /// Interaction logic for PersonelListPage.xaml
    /// </summary>
    public partial class PersonelListPage : Page
    {
        
        
        public PersonelListPage()
        {
            InitializeComponent();
           
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PersonelModel pm = new PersonelModel();
            DGPersonel.ItemsSource = pm.PersonelList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            var selectedItemId = (DGPersonel.SelectedItem as Personel).TCKN;
            ServiceAdapter.Instance.DeleteEmployee(selectedItemId);
            
            

        }
    }
}
