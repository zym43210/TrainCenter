   M S B A M L   `   `   `  ����F  BTrainCenter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TrainCenter.ViewTrainCenter.View  5      +    %TrainCenter.View.GiveTrainProgramPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:TrainCenter.View     5      V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  MyStatusPage��5
      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      .+�5   
   � $��0��6   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ White��6#    � Offset$ 0Q�61   � 5      $ 	#FFE2E2E2��6#   $ 1Q�65   5      .+�5      �� $
��Left=�6   $��20(�63   
�������$��Center=�6S   $��
74,10,0,12q�6n   $	��288��6�   �� 6�   $$�Страница выдачи ��6�   �� 6�   $� тренировки��6�   6�   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Center=�6M   5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      �� 5       $	��39* �6#   .+�5#      �� $ Vertical=�6   $��2��60   .+�5$      �� $��35��6   $��20,30,0,-10q�6(   $)��#Выбор пользователя��6=   $��20(�6W   �� 5%      -   5        $��MailText��5%   9   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Пользователь��6_   	 �� 
IsEditable	 .  &  "MaterialDesignFloatingHintComboBox#��[  6�   $��16(�6�   $��20q�6�   ���	#FF292929���	#89DCD8D8��6   �� *Mails+
 �� Text
 6I   �� *Mail+6$  �� 5&      $ 
Horizontal=�6   $��	0,10,0,20q�66   �� 5'      -   5        $��	TitleText��5'   @   $��50��61    �� TextWrapping$
 Wrap=�6Q    �� AcceptsReturn .  �� 
AcceptsTab .  �� 	IsEnabled . $+ %Название тренировки��6�    % !MaterialDesignFloatingHintTextBox#��[ 6�   $��
10,10,10,0q�6  ���	#FF464648$��16(�6E   �� SelectionBrush
 ��p��$��0,0,0,2q�6q  $��49��6�  ��6   �� *Title+6�  �� 5(      -   5        $��TextText��5(   @   $	��400��60   $
 Wrap=�6P    .  .  . $ Описание ��6�   #��[ 6�   $��
10,50,10,0q�6  ���	#FF464648$��16(�6:  
 ��p��$��0,0,0,2q�6f  $��84��6�  ��6   �� *Text+6�  )  #MaterialDesignThemes.Wpf.TimePicker  5*      -   5        $��StartTimeText��5*   G   $A ;Введите время начала тренировки��6\   $��Stretch=�6�   $��45��6�      	Is24Hours . $��150,0q�6�      Text 6,   �� *	StartTime+6�     5+      -   5        $��EndTimeText��5+   E   $? 9Введите время конца тренировки��6X   $��Stretch=�6�   $��45��6�    . $��150,0q�6�    6,   �� *	EndTime+6�   �� 5,      $��Center=�62   $��16(�6O   
���  ��$��Center=�6r   $��400,0,400,20q�6�   $��46��6�   ��6   �� *Info+6�   �� 5-      -   5         ��Name$ 	addButton��5-      $	��150��6,   $��40��68   ���	#FF555555$��0,50,0,0q�6[   $��Center=�6m   $��Выдать��6�   ���	#FFA6A6A66�   5.      50      51      52      