   M S B A M L   `   `   `  ����F  BTrainCenter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TrainCenterTrainCenter  5   	   !    TrainCenter.View.AuthWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TrainCenter     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  
MainWindow��5   	   $	��600��6   $	��400��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterScreen=�6x    � WindowStyle$
 None=�6�   ���	#FF464648.��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $
��130* �6   �� 5      $	��70* �6   �� 5      $	��70* �6   �� 5      $	��70* �6   �� 5      $	��50* �6   .+�5   
   � -   5         �Name$ GridBarTitle��5      ���	#FF464648.+�5      �� -   5         ��Name$ buttonClose��5      $��Right=�6*      CloseButtonStyle#��[  6F   $��Bottom=�6�   .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6*   $��25��67   $��25��6C   $��Center=�6N   5      5      � 5   
   $��1��6   5      � 5!   
   $��2��6   .+�5"      ��  �� Orientation$ 
Horizontal=�6   $��Bottom=�62   $��50,10,50,10q�6M   .+�5#        $ Account=�6*   $��25��69   $��25��6E   $��Center=�6P   $��	0,10,15,0q�6k   
�������6~   �� 5$      -   5        	 ��Name$	 mailTextBox��5$      
 �� 	MaxLength$
 20��6/   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин��6V   $	��260��6}     	TextBoxes#��[ 6�   ���	#FF303032��6?   �� *Login+6�   5%      5&      � 5(   
   $��3��6   .+�5)      �� $ 
Horizontal=�6   $��Bottom=�62   $��50,10,50,10q�6M   .+�5*        $	 Key=�6*   $��25��65   $��25��6A   $��Center=�6L   $��	0,10,15,0q�6g   
�������6z   G� 5+      -   5         G�Name$ passwordBox��5+      $	��260��63    G� 	MaxLength$ 16��6?   $ Пароль��6N     PasswordBoxes#��[ 6v   ���	#FF3030326�   5,      5-      � 5/   
   $��4��6   .+�52      �� -   5        $��
Войти��52      $��0,10,0,0q�6%     AuthButtonStyle#���  6P   �� 53      -   5        $��Регистрация��53        RegistrationButtonStyle#���  6D   54      � 56   
   $��5��6   .+�58      �� 
����p��$��Center=�6I   $��Center=�6g   $��18(�6�   ��6   �� *Info+6�   59      5:      5<      