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
    /// Interaction logic for EditDepartment_Page.xaml
    /// </summary>
    public partial class EditDepartment_Page : Page
    {
		DepartmentDto depDto;
		string InitialDepartmentName;
		public EditDepartment_Page()
        {
			depDto = new DepartmentDto();
            InitializeComponent();
        }

		public EditDepartment_Page(DepartmentDto dep)
		{
			depDto = dep;
			InitialDepartmentName = depDto.DepartmentName;
			InitializeComponent();
			
		}

		private void TextBox_DepartmentName_Loaded(object sender, RoutedEventArgs e)
		{
			TextBox_DepartmentName.Text = depDto.DepartmentName;
		}

		private void TextBox_DepartmentManager_Loaded(object sender, RoutedEventArgs e)
		{
			TextBox_DepartmentManager.Text = depDto.DepartmentManager;
		}


		private void TextBox_DepartmentName_TextChanged(object sender, TextChangedEventArgs e)
		{
			try
			{
				TextBox tbSource = (sender as TextBox);
				depDto.DepartmentName = tbSource.Text;
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
				depDto.DepartmentManager = tbSource.Text;
			}
			catch (Exception)
			{

				throw;
			}
		}


		private void Button_Click_UpdateDepartment(object sender, RoutedEventArgs e)
		{
			try
			{
				depDto.DepartmentId = ServiceAdapter.Instance.GetDepartmentList().FirstOrDefault(x => x.DepartmentName == InitialDepartmentName).DepartmentId;

				ServiceAdapter.Instance.UpdateDepartment(new DepartmentDto()
				{
					DepartmentId = depDto.DepartmentId,
					DepartmentName = depDto.DepartmentName,
					DepartmentManager = depDto.DepartmentManager
				});

				MessageBox.Show("Kaydınız başarılı şekilde güncellendi!");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			DepartmentListPage nextPage = new DepartmentListPage();
			NavigationService.Navigate(nextPage);
		}
	}
}
