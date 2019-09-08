using Demo.Helpers;
using Demo.Server.Svc.DataContracts;
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

namespace Demo.Wpf.WpfPage.Department
{
    /// <summary>
    /// Interaction logic for AddNewDepartment_Page.xaml
    /// </summary>
    public partial class AddNewDepartment_Page : Page
    {
		DepartmentDto depdto;
        public AddNewDepartment_Page()
        {
			depdto = new DepartmentDto();
            InitializeComponent();
        }

		private void Button_Click_AddDepartment(object sender, RoutedEventArgs e)
		{
			try
			{
				var temp = depdto;
				if (string.IsNullOrEmpty(temp.DepartmentName))
				{
					MessageBox.Show("Departman adı boş olamaz!");
					return;
				}
				if (string.IsNullOrEmpty(temp.DepartmentManager))
				{
					MessageBox.Show("Departman yöneticisi boş olamaz!");
					return;
				}

				ServiceAdapter.Instance.InsertDepartment(new DepartmentDto() {
					DepartmentName = temp.DepartmentName,
					DepartmentManager = temp.DepartmentManager
				});

				MessageBox.Show("Kayıt başarıyla eklendi!");
				DepartmentListPage nextPage = new DepartmentListPage();
				NavigationService.Navigate(nextPage);

			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}

		private void TextBox_DepartmentName_TextChanged(object sender, TextChangedEventArgs e)
		{
			try
			{
				TextBox tbSource = (sender as TextBox);
				depdto.DepartmentName = tbSource.Text;
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void TextBox_DepartmentManager_TextChanged(object sender, TextChangedEventArgs e)
		{
			try
			{
				TextBox tbSource = (sender as TextBox);
				depdto.DepartmentManager = tbSource.Text;
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
