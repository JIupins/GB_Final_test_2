   M S B A M L   `   `   `  ����H  DGB_Final_test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:GB_Final_testGB_Final_test  5   	       GB_Final_test.MainWindow   5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:GB_Final_test     5   	   -   5          � Title$  Animals��5	   	   $	��330��6   $	��350��6&    � AllowsTransparency$
 True��5
   	   
������  � WindowStyle$
 None=�6<   .��5      �� 
������� �� CornerRadius$ 40��6$   $��0 0 0 0q�66   ._�5   
   �  � RowDefinitions 5      �� 5      $��30 �6    �� 5      .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6&   $��Right=�6?   $��0 0 25 0q�6[   
������ .+�5      �� -   5         ��Name$ btnMinimize��5      $
��🗕��6.   $��20(�6;   $
��Bold"�6I   
���   �$��Center=�6n   $��Center=�6�   $��0q�5      $��30��6"   $��30��6-       MaterialDesignFlatDarkButton#��[  69   6o   �� 5      -   5        $ btnMaximize��5      $
��🗖��6.   $��20(�6;   $
��Bold"�6I   
���   �$��Center=�6n   $��Center=�6�   $��0q�5      $��30��6"   $��30��6-   #��[  69   6o   �� 5      -   5        $ btnClose��5      $��X��6+   $��20(�67   $
��Bold"�6E   
���   �$��Center=�6j   $��Center=�6�   $��0q�5      $��30��6"   $��30��6-   #��[  69   6p   5      �� 5      $��1��6   
������ .+�5      �� $��Основное меню��6   $��20(�61   $
��Bold"�6?   $��Center=�6Q   $��
0 15 0 15 q�6o      MaterialDesignBody2TextBlock#��[ 6�   �� 5      -   5        $ CreateAnimal��5      $��10��60   $��50��6?   $%��Создать животное��6M   
�������#��[  6   6�   �� 5#      -   5        $ AllAnimalsData��5#      $��10��62   $��50��6A   $/��)Данные о всех животных��6O   
�������#��[  6�   6�   5$      5&      5'      5(      