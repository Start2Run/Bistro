   M S B A M L   `   `   `  ����E  ASystemePAC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:SystemePAC.Help.ConvertorsSystemePAC.Help.Convertors  5   	   C&clr-namespace:SystemePAC.Help.LanguageSystemePAC.Help.Language  5   	   ,    &SystemePAC.Views.Controls.BasketWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?
convertors(clr-namespace:SystemePAC.Help.Convertors     5   	   7util&clr-namespace:SystemePAC.Help.Language     5   	   -   5          �Name$
  This��5   	      MaterialDesignPaper#���   5   	     MaterialDesignBody#���  5	   	   $	��450��5   	   $	��800��6    � WindowStartupLocation$ CenterOwner=�5   	    � 	Resources 5      <   6SystemePAC.Help.Convertors.ImageFromByteArrayConverter  ImageFromByteArrayConverter��%   &	         5   
   61   5      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $	��128 �6#   �� 5      $��4* �6#   �� 5      $��* �6#   �� 5      $	��128 �6#   .+�5      �� $��0��6   $��2��6$     ShoppingCart#���  68   $��Bottom=�6m   $
��Bold"�6�   $��20(�6�   �� 5       $��2��6   $��Bottom=�6H   $��52,0,0,0q�6c   ��6$   4   .SystemePAC.Help.Language.LocalizationExtension  *Price+6c   �� 5!      $��3��6   $��Bottom=�6K   $��Right=�6f   $��0,0,20,0q�6�   ��6$     *
Quantity+6�   5"      �� 5#   
   -   5        $	��Lst��5#      $��1��6   $��Stretch=�6N   $��Stretch=�6l   ��6*   �� *BasketItems+��5$      �� 5%      .R�5&      ��  �� Orientation$ Vertical=�6!   5'      ��5)      �� 5*       �� 
TargetType" ��6   .�5+      ��  �� Property � �� �� Value 5,      �� 5-      	 �� 
TargetType"	 ��6.   .R�5.   "   �� .+�5/   &   �� 
 ��Name$
 	Separator��60   $��0,10,0,0q�6C   �� 50   &   51   #    �� Triggers 52   "   �� 53   &    �� Binding 62   ��  �� RelativeSource �� *PreviousData+ �� Value 6s   Z� .a�54   *   ��  �� 
TargetName$ 	Separator��6G    � y�$ 	Collapsed=�6^   55   '   57      59      5:      ��5<      �� 5=      .R�5>      �  5?      �� 5@      $	��128 �6/   �� 5A      $��4* �6/   �� 5B      $��* �6/   �� 5C      $��64 �6/   .+�5E      �� $��0��6    $��0��6-   $��Center=�5F       $��UniformToFill=�5H       ��5G       �� *	MiImage+ �� 	Converter# [ 5H       � 5I      $��1��6   $��Stretch=�6/   $��Stretch=�6K    5J      �� 5K   "   �� 5L   "   .+�5N      �� 
����d�$
��Bold"�6[   $��16(�6m   ��6$   �� *MiName+6m   �� 5O      -   5        $��1��5O   %   $��Bottom=�6{   $	��128��6�   $
��Left=�6�   $��0q�6�   $��5q�6�   ��62     *Delete+
 � Tag 6k   �� 6�   5P      �� 5Q       �� ContentStringFormat$ {0:C}��6<   $��2��6Z   
��� � �$
��Bold"�6}   $��16(�6�   ��6    �� *	MiPrice+6�   �� 5R      $��3��6#   $��28��6�   $	��Top=�6�   $��0,5,20,0q�6�    �� SelectedIndex 63   �� *
MiQuantity+ �� UpdateSourceTrigger$ PropertyChanged=� �� FallbackValue$ 1��.@�5S      �� .��6+   06.   �� 5T      .��6+   16.   �� 5U      .��6+   26.   �� 5V      .��6+   36.   �� 5W      .��6+   46.   �� 5X      .��6+   56.   �� 5Y      .��6+   66.   �� 5Z      .��6+   76.   �� 5[      .��6+   86.   �� 5\      .��6+   96.   �� 5]      .��6+   106/   5^      5_      5`      5b      �� 5c   
   $��2��6   $��Right=�6   $��24��6:   $��75��6q   $��Stretch=�6|   
������ $��	20,5,20,5q�6�   
��� � ���6F     *Confirmation+��6�   ��  �� ElementName$
 This�� �� Path$% DataContext.ConfirmClickCommand���6"  �� $
 This��5d      5e      