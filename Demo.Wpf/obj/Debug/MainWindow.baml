   M S B A M L   `   `   `  ����C  ?Demo.Wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Demo.WpfDemo.Wpf  5   	       Demo.Wpf.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Demo.Wpf     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
MainWindow��5	   	   $	��600��6   $
��1024��6)    � 
ResizeMode$ NoResize=�66    � WindowStartupLocation$ CenterScreen=�6L    � WindowStyle$
 None=�6q   .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   � $��1��6   $��1��6   ���	#FF80B680.+�5      �� .��5      � .+�5       � -   5          �Name$
 Main��5        � NavigationUIVisibility$ Hidden=�6*   6L   5      5      5      � 5   
   $��1��6   ���	#FFE0E4E6 5      �� 5       $	��100 �6    �� 5!      $��* �6     J� Effect 5#      3  -System.Windows.Media.Effects.DropShadowEffect  5$      	   RenderingBias$	 Quality=�6#   
   Color$
 	#FFD3C4C4��6;      
BlurRadius$ 20Q�6M   .+�5&      � ���	#FF54B3D6.+�5'      �� $��	DASHBOARD��6   $��Center=�6-   $��Center=�6J   $��Segoe UI Black)�6e   $��20(�6�   5)      5*      �� 5+      $��1��6   .+�5,      �� $��10q�6   ���	#FFC17B7B
����������	#FF8B8964$��35��6g   .��5-      � $	��150��6   .+�5.      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ ViewDashboard=�62   $��Center=�6G   6e   �� 5/      $��Center=�6$   $��	DASHBOARD��6A   6T   50      51      �� 53      -   5        $��10q�53      ���	#FFC17B7B
����������	#FF8B8964$��35��6g   .��54      � $	��150��6   .+�55        $ Account=�62   $��Center=�6A   6_   �� 56      $��Center=�6$   $��Personel��6A   $��16��6Q   $
��52,0q�6]   $	��Top=�6k   6�   57      58      �� 5:      -   5         ��Name$ Btn_Department��5:      $��10q�61   ���	#FFC17B7B
����������	#FF8B8964$��35��6   .��5;      � $	��150��6   .+�5<        $ ContentPaste=�62   $��Center=�6F   6d   �� 5=      $��Center=�6$   $��
Department��6A   6U   5>      5?      �� 5A      $��10q�6   ���	#FFC17B7B
����������	#FF8B8964$��35��6g   .��5B      � $	��150��6   .+�5C        $
 City=�62   $��Center=�6>   6\   �� 5D      $��Center=�6$   $��Şehir��6A   6P   5E      5F      5I      5J      � 5L   
   -   5         �Name$ GridOfTitle��5L      $��2��6$   ���	#FF1495C5.+�5M      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   $
��10,0q�6N   .+�5N      �� $��25��6   $��25��6%   
���������61   Z� ��6G   Z� .��5O        $
 Bell=�6.   6<   5P      �� 5Q      $��25��6   $��25��6%   
���������61   Z� ��6G   Z� .��5R        $ Account=�6.   6?   5S      �� 5T      -   5        $ ButtonClose��5T      $��25��6.   $��25��69   
���������6E   Z� ��6[   Z� .��5U        $ Power=�6.   6=   5V      5W      5X      5Y      5Z      