   M S B A M L   `   `   `  ����F  BTrainCenter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TrainCenter.ViewTrainCenter.View  5           TrainCenter.View.AdminPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:TrainCenter.View     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          N�Name$  	adminPage��5
      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $	��64* �6   .+�5   
   � $��0��6   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ White��6#    � Offset$ 0Q�61   � 5      $ 	#FFE2E2E2��6#   $ 1Q�65   5      .+�5      �� $
��Left=�6   $��20(�63   
�������$#��Меню управления��6S   $��Center=�6j   $��20,0,0,0q�6�   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�63   $��Center=�6N   $��	100,5,5,5q�6l   .+�5      	� -   5         	�Name$ radio1��5          MaterialDesignTabRadioButton#��[  6.   $��4q�6d   $��Пользователи��6o    � Cursor$
 Hand��6�   5      5      � 5   
   $��1��6    5       �� 5!      $	��37* �6    �� 5"      $��70 �6    .+�5$      � $��0��6   .+�5%      �� -   5        	 ��Name$	 listBox��5%      $��14(�6+   $��Stretch=�6_   $��Disabled=�6�   $��2��6�   $
 Hand��6�   
 �� SelectedItem
 69   �� *SelectedItem+6�   5&      � 5'      $��1��6   .+�5(      �� $ 
Horizontal=�6   $��Right=�66   .+�5)      �� -   5         ��Name$ NoButton��5)      $��Удалить��6/   $��Center=�6A   $��0,0,10,0q�6\   $	��110��6n   $��50��6z   
�������
���  ��$��0q�6�   ��6�   Z� 6�   �� 5*      -   5        $ 
infoButton��5*      $��Подробнее��61   $��Center=�6F   $��0,0,10,0q�6a   $	��110��6s   $��50��6   6�   �� 5+      -   5        $ OkButton��5+      $��Привелегии��6/   $��Center=�6D   $��0,0,10,0q�6_   $	��110��6q   $��50��6}   
�������
���2�2�$��0q�6�   ��6�   Z� 6�   5,      5-      5.      5/      50      