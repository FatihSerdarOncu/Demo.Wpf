﻿#pragma checksum "..\..\..\..\WpfPage\PersonelPages\AddNewPersonalPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "04F2BBE5468E3461DB1E75CE575D5108E5E00616"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Demo.Wpf.WpfPage;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Demo.Wpf.WpfPage {
    
    
    /// <summary>
    /// AddNewPersonalPAge
    /// </summary>
    public partial class AddNewPersonalPAge : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\WpfPage\PersonelPages\AddNewPersonalPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Tc;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\WpfPage\PersonelPages\AddNewPersonalPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Name;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\WpfPage\PersonelPages\AddNewPersonalPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Surname;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\WpfPage\PersonelPages\AddNewPersonalPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox DepartmentComboBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\WpfPage\PersonelPages\AddNewPersonalPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_FullAdr;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\WpfPage\PersonelPages\AddNewPersonalPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TownComboBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Demo.Wpf;component/wpfpage/personelpages/addnewpersonalpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\WpfPage\PersonelPages\AddNewPersonalPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TextBox_Tc = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\..\WpfPage\PersonelPages\AddNewPersonalPage.xaml"
            this.TextBox_Tc.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextChanged_TCKN);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\..\WpfPage\PersonelPages\AddNewPersonalPage.xaml"
            this.TextBox_Tc.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTCKN);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TextBox_Name = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\..\..\WpfPage\PersonelPages\AddNewPersonalPage.xaml"
            this.TextBox_Name.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TexChanged_Name);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TextBox_Surname = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\..\..\WpfPage\PersonelPages\AddNewPersonalPage.xaml"
            this.TextBox_Surname.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextChanged_Surname);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DepartmentComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 17 "..\..\..\..\WpfPage\PersonelPages\AddNewPersonalPage.xaml"
            this.DepartmentComboBox.Loaded += new System.Windows.RoutedEventHandler(this.ComboBox_Department_Loaded);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\..\WpfPage\PersonelPages\AddNewPersonalPage.xaml"
            this.DepartmentComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SelectionChanged_ComboBox_Department);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TextBox_FullAdr = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\..\..\WpfPage\PersonelPages\AddNewPersonalPage.xaml"
            this.TextBox_FullAdr.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextChanged_Address);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TownComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\..\..\WpfPage\PersonelPages\AddNewPersonalPage.xaml"
            this.TownComboBox.Loaded += new System.Windows.RoutedEventHandler(this.ComboBox_Town_Loaded);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\..\WpfPage\PersonelPages\AddNewPersonalPage.xaml"
            this.TownComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SelectionChanged_ComboBox_Town);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 20 "..\..\..\..\WpfPage\PersonelPages\AddNewPersonalPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnClick_AddModel);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

