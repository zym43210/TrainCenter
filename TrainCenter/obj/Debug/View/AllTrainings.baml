   M S B A M L   `   `   `  ����F  BTrainCenter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TrainCenter.ViewTrainCenter.View  5      =#clr-namespace:TrainCenter.ViewModelTrainCenter.ViewModel  5      #    TrainCenter.View.AllTrainings   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:TrainCenter.View     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      3	viewmodel#clr-namespace:TrainCenter.ViewModel  5        N� Title$  AllTrainProgram��5      $��Stretch=�6   $��Stretch=�6=    N� 
Background 6Y   Z� .��5      �  � ColumnDefinitions 5   
   �� 5      $	��300 �6   �� 5      .+�5   
   �� 
�������$��0,0,2,0q�6)   ._�5      � $��0��6   
�������.+�5      ��  �� Orientation$ Vertical=�6   .+�5      �� $��50��6    $��20,40,0,-10q�6,   $(��"Поиск по критериям��6A   $��20(�6[   �� 5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Поиск��6:   $��20,30,20,20q�6a   $��16(�6v   $��40��6�    �� SelectionBrush �	#FF787878���	#FF292929���	#89DCD8D8��6   �� *
SearchText+6�   �� 5      $ Категория��6\    �� 
IsEditable .  &  "MaterialDesignFloatingHintComboBox#��[  6�   $��16(�6�   $��20q�6�   ���	#FF292929���	#89DCD8D8��6   �� *
Categories+ �� Text 6B   �� *
Category+6  �� 5      $ 
Horizontal=�6!   $��	0,20,0,20q�6:   �� 5      -   5         ��Name$ searchButton��5      $	��120��63   $��40��6?   ���	#FF555555$��	0,50,20,0q�6b   $��Right=�6u   $��
Поиск��6�   ���	#FFA6A6A66�   5      5      5      � 5!   
   $��1��6   .+�5#      �� -   5        $��16(�5#      $��0,70,0,0q�6$   $��Stretch=�66   	 � Cursor$
	 Hand��6�   ��6[   �� *TrainPrograms+
 �� SelectedItem
 6�   �� *SelectedItem+��5$      �� 5%      .R�5&      ]� $��5,5,5,5q�6$   .+�5'      �� $ 
Horizontal=�6)   .+�5)   "   �� $ Vertical=�6-   $��
20,10,0,10q�6D   .+�5*   &   �� $��15(�6G   
����� �$��5q�6k   ��60   �� *Title+6k   �� 5+   &   $��18(�6F   $	��500��6T   $��WordEllipsis=�6a   $��NoWrap=�6}   $��SemiBold"�6�   $��5q�6�   ��60   �� *Text+6�   5-   #   5.      50      51      53      �� 55      $��Все программы��6   
�������$��24(�6>   $��	30,15,0,0q�6L   $	��Top=�6_   �� 56      
�������$��16(�6?   $��0,20,140, 0q�6M   $	��Top=�6b   $��Right=�6z   ��6   �� *Info+6z   57      58      59      