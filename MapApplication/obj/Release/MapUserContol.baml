   M S B A M L   `   `   `  ���� d  `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF   MapApplication#   MapApplication.MapUserControl   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     `mRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     .��� .+�'   !Microsoft.Maps.MapControl.WPF.Map  -   $��MyMap��+   %Microsoft.Maps.MapControl.WPF.MapCore    	ZoomLevel  �� *Value+ �� ElementName$ ZoomBar�� �� Mode$ TwoWay=�   Children ,   &Microsoft.Maps.MapControl.WPF.MapLayer  -   $��	DataLayer��  .+�� -    �Name$ Infobox��   Position<   6Microsoft.Maps.MapControl.WPF.Design.LocationConverter$	 0,0 $y�	Collapsed=�$��0,-155,-15,0q�.+��� $	��300��$	��110��
���   � J� Opacity$	 0.8Q�
�������$��2q� �� CornerRadius$ 5���� $	��100��$��5q�.+�� $��25��.+��� -   $��X��
 � Tag$ Close��$��Right=�$	��Top=��� -   	 ��Name$	 InfoboxTitle�����#1cff1c$��12(�$	��280��$
��Wrap=�$
��Left=��� $
��Auto=�$
��Auto=�$��75��.���� -   $	 InfoboxDescription�����#1cff1c$��10(�$	��265��$
��Wrap=�$
��Auto��� $
��Left=�$	��Top=�$	��290��
 � ColumnDefinitions
 �� $��30 ��� $��30 ��� $��30 � � RowDefinitions �� $��30 ��� $��30 ��� $��30 ��� .+��� -   $	��⇑��$��25��$��25��$��1��$ Up���� -   $	��⇒��$��25��$��25��$��1��$��2��$ Right���� -	   $	��⇓��$��25��$��25��$��2��$��1��$
 Down���� -
   $	��⇐��$��25��$��25��$��1��$
 Left���� -   $��ZoomBar�� �� Orientation$ Vertical=�$	��180��$��20��$��10,10q�$��3��$��3��$��Center=� � Minimum$ 1Q� � Maximum$ 19Q� � SmallChange$ 1Q�