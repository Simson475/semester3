   M S B A M L   `   `   `  ����P  LMVVMWPCaliburnMicroV2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:MVVMWPCaliburnMicroV2.ViewsMVVMWPCaliburnMicroV2.Views  5   	   +    %MVVMWPCaliburnMicroV2.Views.ShellView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:MVVMWPCaliburnMicroV2.Views     5   	     � Title$  	ShellView��5   	   $	��450��6   $	��800��6(   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      $
��auto �6   �� 5"      $��* �6   �� 5#      $��20 �6   .+�5&   
   �� $��1��6@   $��1��6M   $��2��6]   ��6   ��  �� Path$ FullName� �� Mode$ OneWay=�6]   �� 5'   
   -   5         ��Name$ 	FirstName��5'   !   $	��100��6   $��2��64   $��1��6A   �� 5(   
   -   5        $ LastName��5(   !   $	��100��6   $��2��63   $��2��6@   �� 5*   
   $��3��6   $��1��6     �� DisplayMemberPath$ 	FirstName��5,      ��5*   1   �� *People+ �� SelectedItem 5+      �� $ SelectedPerson�$ OneWayToSource=�5,      �� 5-   
   -   5         ��Name$ SelectedPerson_LastName��5-   1   $��3��6   $��2��6!   61   �� 5/   
   -   5        	 ��Name$	 	ClearText��5/      $��4��6%   $��1��62   .��6B   
Clear Text6N   �� 52   
   -   5        $	 LoadPageOne��52      $��5��6&   $��1��63   .��6C   Load First Page6T   �� 53   
   -   5        $	 LoadPageTwo��53      $��5��6&   $��2��63   .��6C   Load Second Page6U   �� 59   
   -   5        
 ��Name$

 Tabs��59   W   $��7��6   $��1��6"   $��4��62   $��4��6F   6W   �� 5<   
   $��11��6   $��1��6!    �� 
IsEditable$
 True��61    �� Text$ Reserve��6D   .@�5=      �� .��5>      �� .+�5?      �� Reservation6-   �� 5@      .��6   Reservation Name60   �� 5A      $
 True��6    �� 
IsReadOnly$
 True��61   $ Reservation Machines��6C   .@�5B      �� .��6'   OKU6,   �� 5C      .��6'   OKR6,   5D      �� 5E      Start Shift6-   (  "System.Windows.Controls.DatePicker  5F      �� 5G      $
 True��6   $
 True��61   $  ��6C   6M   5I      5J      5K      5L      5M      