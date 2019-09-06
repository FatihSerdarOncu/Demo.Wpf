using Demo.Helpers;
using Demo.Server.Svc.DataContracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Demo.Wpf.WpfPage
{
	/// <summary>
	/// Interaction logic for AddNewPersonalPAge.xaml
	/// </summary>
	public partial class AddNewPersonalPAge : Page
	{
		EmployeeInfoDto employeeInfoDto;
		Dictionary<int, string> departmentDict;
		Dictionary<int, string> townDict;
		public AddNewPersonalPAge()
		{
			employeeInfoDto = new EmployeeInfoDto();
			InitializeComponent();
			DepartmentObjectsDict_Load();
			TownObjectsDict_Load();

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
				//var comboBox = sender as ComboBox;
				//comboBox.ItemsSource = comboBoxlist;
				DepartmentComboBox.ItemsSource = comboBoxlist;
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
				//var comboBox = sender as ComboBox;
				//comboBox.ItemsSource = comboBoxlist;
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




		private void TextChanged_TCKN(object sender, TextChangedEventArgs e)
		{
			try
			{
				TextBox tbSource = (sender as TextBox);
				if (!tbSource.Text.Equals("TCKN"))
					employeeInfoDto.TCKN = Convert.ToInt64( tbSource.Text);
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void NumberValidationTCKN(object sender, TextCompositionEventArgs e)
		{
			try
			{
				Regex regex = new Regex("[^0-9]+");
				e.Handled = regex.IsMatch(e.Text);
			}
			catch (Exception)
			{

				throw;
			}
		}

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


		private void BtnClick_AddModel(object sender, RoutedEventArgs e)
		{
			var temp = employeeInfoDto;
			ServiceAdapter.Instance.InsertEmployee(new EmployeeDto()
			{
				EmployeeTCKN =temp.TCKN,
				EmployeeName =temp.EmployeeName,
				EmployeeSurname = temp.EmployeeSurname,
				Department = departmentDict.FirstOrDefault(x => x.Value == employeeInfoDto.DepartmentName).Key
			});
			
			ServiceAdapter.Instance.InsertAddress(new AddressDto()
			{
				FullAddress = temp.FullAddress,
				Town = townDict.FirstOrDefault(x=>x.Value == employeeInfoDto.TownName).Key
			});

			ServiceAdapter.Instance.InsertEmployeeAddress(new EmployeeAddressDto()
			{
				EmpId = temp.TCKN,
				AddId = ServiceAdapter.Instance.GetAddressList().FirstOrDefault(x => x.FullAddress == temp.FullAddress).AddressId

			});

			PersonelListPage nextPage = new PersonelListPage();
			NavigationService.Navigate(nextPage);
		}

		
	}
}
