using Demo.Helpers;
using Demo.Server.Svc.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Demo.Wpf.WpfPage.Personel
{
	/// <summary>
	/// Interaction logic for EditPersonelPage.xaml
	/// </summary>
	public partial class EditPersonelPage : Page
	{
		EmployeeInfoDto employeeInfoDto;
		Dictionary<int, string> departmentDict;
		Dictionary<int, string> townDict;
		string InitialAddress;
		public EditPersonelPage()
		{

			InitializeComponent();
		}

		public EditPersonelPage(EmployeeInfoDto emp)
		{
			employeeInfoDto = emp;
			InitializeComponent();
			DepartmentObjectsDict_Load();
			TownObjectsDict_Load();
			InitialAddress = emp.FullAddress;

		}
		private void Page_Loaded(object sender, RoutedEventArgs e)
		{

		}

		#region Department 
		private void ComboBox_Department_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				var dep = ServiceAdapter.Instance.GetDepartmentList();
				List<string> comboBoxlist = new List<string>();
				foreach (DepartmentDto depDto in dep)
				{
					comboBoxlist.Add(depDto.DepartmentName);
				}
				DepartmentComboBox.ItemsSource = comboBoxlist;
				DepartmentComboBox.Text = employeeInfoDto.DepartmentName;
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void SelectionChanged_ComboBox_Department(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				employeeInfoDto.DepartmentName = DepartmentComboBox.SelectedValue.ToString();
			}
			catch (Exception)
			{

				throw;
			}

		}

		private void DepartmentObjectsDict_Load()
		{
			try
			{
				departmentDict = new Dictionary<int, string>();
				var depObjects = ServiceAdapter.Instance.GetDepartmentList();
				foreach (DepartmentDto depDto in depObjects)
				{
					departmentDict.Add(depDto.DepartmentId, depDto.DepartmentName);
				}
			}
			catch (Exception)
			{

				throw;
			}

		}


		#endregion

		#region Town

		private void ComboBox_Town_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				var town = ServiceAdapter.Instance.GetTownList().Where(x => x.City == 1);
				List<string> comboBoxlist = new List<string>();
				foreach (TownDto tDto in town)
				{
					comboBoxlist.Add(tDto.TownName);
				}
				TownComboBox.ItemsSource = comboBoxlist;
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void SelectionChanged_ComboBox_Town(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				employeeInfoDto.TownName = TownComboBox.SelectedValue.ToString();
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void TownObjectsDict_Load()
		{
			try
			{
				townDict = new Dictionary<int, string>();
				var townObjects = ServiceAdapter.Instance.GetTownList();
				foreach (TownDto tDto in townObjects)
				{
					townDict.Add(tDto.TownId, tDto.TownName);
				}
			}
			catch (Exception)
			{

				throw;
			}

		}
		#endregion

		#region TextChanged

		private void TexChanged_Name(object sender, TextChangedEventArgs e)
		{
			try
			{
				TextBox tbSource = (sender as TextBox);
				employeeInfoDto.EmployeeName = tbSource.Text;
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void TextChanged_Surname(object sender, TextChangedEventArgs e)
		{
			try
			{
				TextBox tbSource = (sender as TextBox);
				employeeInfoDto.EmployeeSurname = tbSource.Text;
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void TextChanged_Address(object sender, TextChangedEventArgs e)
		{
			try
			{
				TextBox tbSource = (sender as TextBox);
				employeeInfoDto.FullAddress = tbSource.Text;
			}
			catch (Exception)
			{

				throw;
			}
		}

		#endregion

		#region Text Loaded

		private void TextBox_Tc_Loaded(object sender, RoutedEventArgs e)
		{
			TextBox_Tc.Text = employeeInfoDto.TCKN.ToString();
		}

		private void TextBox_Name_Loaded(object sender, RoutedEventArgs e)
		{
			TextBox_Name.Text = employeeInfoDto.EmployeeName;
		}

		private void TextBox_Surname_Loaded(object sender, RoutedEventArgs e)
		{
			TextBox_Surname.Text = employeeInfoDto.EmployeeSurname;
		}

		private void TextBox_FullAdr_Loaded(object sender, RoutedEventArgs e)
		{
			TextBox_FullAdr.Text = employeeInfoDto.FullAddress;
		}

		#endregion

		private void Button_Click_Edit(object sender, RoutedEventArgs e)
		{
			try
			{
				ServiceAdapter.Instance.UpdateEmployee(new EmployeeDto()
				{
					EmployeeTCKN = employeeInfoDto.TCKN,
					EmployeeName = employeeInfoDto.EmployeeName,
					EmployeeSurname = employeeInfoDto.EmployeeSurname,
					Department = departmentDict.FirstOrDefault(x => x.Value == employeeInfoDto.DepartmentName).Key
				});

				var adrId = ServiceAdapter.Instance.GetAddressList().FirstOrDefault(x => x.FullAddress == InitialAddress).AddressId;

				if (adrId!=0)
					ServiceAdapter.Instance.UpdateAddress(new AddressDto()
					{
						AddressId = adrId,
						FullAddress = employeeInfoDto.FullAddress,
						Town = townDict.FirstOrDefault(x => x.Value == employeeInfoDto.TownName).Key
					});

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				throw;
			}
			PersonelListPage nextPage = new PersonelListPage();
			NavigationService.Navigate(nextPage);
		}
	}
}
