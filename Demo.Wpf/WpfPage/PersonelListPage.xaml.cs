using Demo.Helpers;
using Demo.Wpf.WpfPage.Personel;
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

			var selectedItemId = (DGPersonel.SelectedItem as Personnel);
			EditPersonelPage nextPage = new EditPersonelPage(new Server.Svc.DataContracts.EmployeeInfoDto() {
				 TCKN = selectedItemId.TCKN,
				 EmployeeName = selectedItemId.PersonelName,
				 EmployeeSurname = selectedItemId.PersonelSurname,
				 DepartmentName = selectedItemId.Department,
				 FullAddress = selectedItemId.Address,
				 TownName = selectedItemId.Town,
				 CityName = selectedItemId.City
			});
			NavigationService.Navigate(nextPage);
		}

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
			try
			{
				var selectedItemId = (DGPersonel.SelectedItem as Personnel).Address;
				var adrId = ServiceAdapter.Instance.GetAddressList().FirstOrDefault(x => x.FullAddress == selectedItemId).AddressId;
				var employeAdrId = ServiceAdapter.Instance.GetEmployeeAddressList().FirstOrDefault(x => x.AddId == adrId).Oid;

				if (employeAdrId != 0)
				{
					ServiceAdapter.Instance.DeleteEmployeeAddress(employeAdrId);
					ServiceAdapter.Instance.DeleteAddress(adrId);
				}
			}
			catch (Exception ex)
			{

				throw;
			}

			NavigationService.Refresh();


		}
        private void Button_Click_AddNewPersonel(object sender, RoutedEventArgs e)
        {
            AddNewPersonalPAge nextPage = new AddNewPersonalPAge();
            NavigationService.Navigate(nextPage);
        }
    }
}
