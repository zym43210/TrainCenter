   M S B A M L   `   `   `  ����F  BTrainCenter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TrainCenter.ViewTrainCenter.View  5   	   '    !TrainCenter.View.AddMyTrainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:TrainCenter.View     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  	AddWindow��5	   	   $
��1000��6   $	��700��6)    � WindowStyle$
 None=�65    � WindowStartupLocation$ CenterScreen=�6H   .��5
      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      �� 5      $	��100 �6   .+�5   
   � $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5      �� -   5         ��Name$ closeButton��5      $��35��6.      CloseButtonStyle#���   6:   .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6.   $��20��6;   $��20��6G   ���	#FF464648$��Center=�6i   5      5      5      � 5   
   $��1��6   .+�5      �� $#��Отметка занятия��6   $��20(�6.   $
��Left=�6<   $	��Top=�6W   $��35��6o   $��
100,40,0,0q�6{   
�������6�   �� 5      $ Vertical=�6   $��100,82,100,169q�60   .+�5      �� $	��400��66    �� TextWrapping$
 Wrap=�6F    �� AcceptsReturn . 	 �� 
AcceptsTab	 . 
 �� 	IsEnabled
 . )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Описание��6�    �� 	MaxLength$
 1000��6�    % !MaterialDesignFloatingHintTextBox#��[ 6�   $��0,50,0,0q�6  ���	#FF464648$��16(�6>   �� SelectionBrush
 ��p��$��0,0,0,2q�6j  $	��105��6�  ��6   �� *
Commentary+6�  )  #MaterialDesignThemes.Wpf.TimePicker  5      $A ;Введите время начала тренировки��6G   $��Stretch=�6�   $��65��6�      	Is24Hours .    Text 6,   �� *	StartTime+6�     5      $? 9Введите время конца тренировки��6E   $��Stretch=�6�   $��65��6�    .  6,   �� *	EndTime+6�   5      5       � 5"   
   $��2��6   .+�5#      �� $ 
Horizontal=�6   $��Center=�62   $	��Top=�6O   .+�5$      ��  �� CornerRadius$ 25��6   $	��150��6+   $��50��67   ���	#FF464648$��0,0,40,0q�6Z   $��1q�6l   ._�5%      �� -   5        $ clearButton��5%      $��Очистить��62   $��Center=�6E   ���	#FFE4E4E4��6}   Z� ��6�   Z� 6�   5&      �� 5'      -   5         ��Name$ 	addButton��5'      $ 25��6,   $	��150��6>   $��50��6J   $��40,0,0,0q�6V   ���	#FF464648$��1q�6   ._�5(      �� -   5        $��Добавить��5(      $��Center=�61   ���	#FFE4E4E4��6f   Z� ��6}   Z� 6�   5)      5*      �� 5+      $��Center=�6.   $��16(�6K   
���  ��$��Bottom=�6n   $��0,0,0,20q�6�   ��6   �� *Info+6�   5,      5-      5.      