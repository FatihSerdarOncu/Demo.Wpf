﻿using Demo.Helpers;
using Demo.Wpf.WpfPage;
using Demo.Wpf.WpfPage.Department;
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

namespace Demo.Wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
            InitializeComponent();
           
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GridOfTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnClikPersonel(object sender, RoutedEventArgs e)
        {
            Main.Content = new PersonelListPage();
        }

		private void Btn_Department_Click(object sender, RoutedEventArgs e)
		{
			Main.Content = new DepartmentListPage();
		}
	}
}
