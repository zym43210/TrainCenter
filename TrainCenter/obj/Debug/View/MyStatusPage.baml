   M S B A M L   `   `   `  ����F  BTrainCenter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TrainCenter.ViewTrainCenter.View  5      #    TrainCenter.View.MyStatusPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:TrainCenter.View     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  MyStatusPage��5
      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      .+�5   
   � $��0��6   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ White��6#    � Offset$ 0Q�61   � 5      $ 	#FFE2E2E2��6#   $ 1Q�65   5      .+�5      �� $
��Left=�6   $��20(�63   
�������$��Center=�6S   $��
74,10,0,12q�6n   �� 6�   $
�Мо��6�   �� 6�   $�й��6�   �� 6�   $� ��6�   �� 6�   $'�!статус абонемента��6�   6�   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Center=�6M   �� 5      -   5        $��Right=�5      $��	0,0,100,0q�6L      NavigationButtonStyle#���   6_   .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Update=�6*   $��25��68   $��24��6D   $��Center=�6O   5      �� 5      -   5        $��Right=�5      $	��0,5q�6I   #���   6V    J� RenderTransformOrigin$ 0.971,0.498&�6�   �� 5      -   5        $��Right=�5      $��0,5,33,5q�6I   #���   6[   .��5         $	 Add=�6*   $��30��65   $��30��6A   $��Center=�6L   $ 1.249,0.498&�6i   5!      5"      � 5$   
   $��1��6   .+�5%      �� 
�������$��16(�6?   $��0,20,140, 0q�6M   $	��Top=�6b   $��Right=�6z   ��6   �� *Info+6z   �� 5&      $��16(�6   $��0,70,0,0q�6$   $��Stretch=�66   	 � Cursor$
	 Hand��6�   ��6[   �� *	Visitings+
 �� SelectedItem
 6}   �� *SelectedItem+��5'      �� 5(      .R�5)      ]� $��5,5,5,5q�6$   .+�5*      �� $ 
Horizontal=�6)   .+�5,   "   �� $ Vertical=�6-   $��
20,10,0,10q�6D   .+�5-   &   �� $��15(�6K   
����� �$��5q�6o   ��60   �� *	VisitDate+6o   �� 5.   &   $��18(�6L   $	��500��6Z   $��WordEllipsis=�6g   $��NoWrap=�6�   $��SemiBold"�6�   $��5q�6�   ��60   �� *
Commentary+6�   50   #   51      53      54      56      57      58      59      