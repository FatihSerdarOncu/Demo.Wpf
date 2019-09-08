using Demo.Helpers;
using Demo.Wpf.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Demo.Wpf.ViewModel.DepartmentModel;

namespace Demo.Wpf.WpfPage.Department
{
    /// <summary>
    /// Interaction logic for DepartmentListPage.xaml
    /// </summary>
    public partial class DepartmentListPage : Page
    {
        public DepartmentListPage()
        {
            InitializeComponent();
        }

		private void Page_Load(object sender, RoutedEventArgs e)
		{
			DepartmentModel pm = new DepartmentModel();
			DGDepartment.ItemsSource = pm.DepartmentList();
		}

		private void Button_Click_AddNewDepartment(object sender, RoutedEventArgs e)
		{
			AddNewDepartment_Page nextPage = new AddNewDepartment_Page();
			NavigationService.Navigate(nextPage);
		}

		private void Button_Click_Edit(object sender, RoutedEventArgs e)
		{
			var selectedItemId = (DGDepartment.SelectedItem as Departman);
			
			EditDepartment_Page nextPage = new EditDepartment_Page(new Server.Svc.DataContracts.DepartmentDto()
			{
				DepartmentName = selectedItemId.DepartmentName,
				DepartmentManager = selectedItemId.DepartmentManager
			});
			NavigationService.Navigate(nextPage);
		}

		private void Button_Click_Delete(object sender, RoutedEventArgs e)
		{
			try
			{
				var selectedItemId = (DGDepartment.SelectedItem as Departman);
				var depId = ServiceAdapter.Instance.GetDepartmentList().FirstOrDefault(x => x.DepartmentName == selectedItemId.DepartmentName).DepartmentId;

				var count = ServiceAdapter.Instance.GetEmployeeList().Where(x => x.Department == depId).Count();

				if (count != 0)
				{
					MessageBox.Show("Bu departmana kayıtlı personeller bulunmaktadır.Bu yüzden silinemez!","Kayıt Silinemez");
				}
				else
				{
					var result = ServiceAdapter.Instance.DeleteDepartment(depId);
					MessageBox.Show("Kayıt silinmiştir!");
				}
			}
			catch (Exception ex)
			{

				throw;
			}

			NavigationService.Refresh();
		}

		
	}
}
