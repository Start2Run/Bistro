   M S B A M L   `   `   `  ����E  ASystemePAC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SystemePAC.Help.LanguageSystemePAC.Help.Language  5      1clr-namespace:SystemePAC.HelpSystemePAC.Help  5      G(clr-namespace:SystemePAC.Help.ConvertorsSystemePAC.Help.Convertors  5      %    SystemePAC.Views.Pages.MainPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7util&clr-namespace:SystemePAC.Help.Language     5      .helpclr-namespace:SystemePAC.Help     5      ?
convertors(clr-namespace:SystemePAC.Help.Convertors     5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      -   5        $
��This��5         MaterialDesignPaper  N� 
Background#  �   5
        MaterialDesignBody#���  5       N� Title$ MainPage��5       � 	Resources 5      <   6SystemePAC.Help.Convertors.ImageFromByteArrayConverter  ImageFromByteArrayConverter   BooleanToVisibilityConverter��%:   &	       &	        5   
   61   �� 5   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   � .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5      �� $
��Left=�6   $��0,0,10,0q�64   $��32��6F    # MaterialDesignRaisedLightButton#��[ 6R   $��0q�6�   y�6�   �� *IsModeAdmin+ �� 	Converter# [ ��6�   �� *ConfigClickCommand+.��5      �� $ 
Horizontal=�6!   .+�5      �� $1��+pack://application:,,,/Resources/config.png��6    $��UniformToFill=�6U   |�.   J� IsHitTestVisible .  6   �� 5      $��Center=�6L   $��0,0,5,3q�6i   |�.   .  ��6    4   .SystemePAC.Help.Language.LocalizationExtension  *Configuration+6�   5       5!      �� 5"      $��0��6   $��Center=�5$      $��Right=�5%      $��0,0,10,0q�5&      
�������$
��Bold"�5(      $��16(�5)      ��5#      ��  �� Path$ UserName� �� FallbackValue$ John Doe��5)      �� 5*      #��[ 6   
������ $��	10,0,10,0q�5,      $��48��5/      ��5-      �� *AppLanguage+$ En����5.      �� *LanguageClickCommand+5/      %  MaterialDesignThemes.Wpf.Badged  51      	   BadgeColorZoneMode$	 PrimaryDark=�6Z   $��0,5,0,0q�6{     ControlzEx.BadgedEx
   Badge
 6(   �� *CartItemsCount+$ 0��.��52      �� #��[ 6   ��6V   ��  �� ElementName$
 This��$$ DataContext.BasketClickCommand�.��53      �� $��0��6    $��2��6-   $1��+pack://application:,,,/Resources/basket.png��6>   $��UniformToFill=�6s   54      55      56      57      � 58   
   $��1��6    59      �� 5:      $��* �6    �� 5;      $��40 �6     � ColumnDefinitions 5=      �� 5>      $
��59.7 �6#   �� 5?      $��140.3 �6#   �� 5@      $��* �6#   .+�5B      �� $ Vertical=�6   $	��200��60   $��
0,0,0,39.6q�6<   $��2��6P   $��2��6d   .+�5C      �� $	��200��6    $  MaterialDesignRaisedAccentButton#��[ 6&   $��5q�5D      #���   5E      "   SystemePAC.Help.FoodCategory   Cooked#��Z 5F   k   $��0q�6�   ��6   �� $
 This��$, &DataContext.FoodCategoriesClickCommand�.��5G      � .+�5H      �� $5��/pack://application:,,,/Resources/platDuJour.png��6    $
��Fill=�6Y   5I      5J      �� 5K      #��[ 6   $	��200��5L      $��5q�5M      #���   5N         Snack#��Z 5O   k   $��0q�6�   ��6   �� $
 This��$, &DataContext.FoodCategoriesClickCommand�.��5P      � .+�5Q      �� $0��*pack://application:,,,/Resources/snack.png��6    $
��Fill=�6T   5R      5S      �� 5T      $	��200��6   $��5q�5U      #���   5V         Beverage#��Z 5W   k   $��0q�6�   ��6   �� $
 This��$, &DataContext.FoodCategoriesClickCommand�.��5X      � .+�5Y      �� $3��-pack://application:,,,/Resources/beverage.png��6    $
��Fill=�6W   5Z      5[      5\      �� 5]      -   5        $	��Lst��5]      $��2��6P   $��
0,0,0,39.6q�6`   $��2��6t   ��6!   �� *FoodProductsCollection+��5^      �� 5_      .R�5`      A�  A� Columns$ 3��6&   5a      ��5c      �� 5d       �� 
TargetType" ��6   .�5e      ��  �� Property � �� �� Value$	 300��65   �� 5f       � ��$	 300��66   �� 5g       � ��$ Stretch=�6G   �� 5h       � ��$ Stretch=�6E   �� 5i       �@��
IsSelected 67   �� *Content.IsSelected+ �� Mode$ TwoWay=� �� RelativeSource �� *Self+�� 5j       � �� 5k      �� 5l   "    �� 
TargetType" ��62   .R�5m   &   �� 5n   #   5p      5q      ��5s      �� 5t      .R�5u      #  MaterialDesignThemes.Wpf.Card  +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�6.      ShadowEdges$ Bottom,Right=�6_   $��10q�6�   .��5v      �  5w   "   �� 5x   &   $��* �64   �� 5y   &   $��10 �64   �� 5z   &   $��24 �64   .+�5|   "   �� $��UniformToFill=�6{   ��6(   �� *	MiImage+# [ 6{   � 5}   "   $��2��6'    5~   &   �� 5   *   $��2* �6;   �� 5�   *   $��* �6;   �� 5�   *   $��2* �6;   .+�5�   &   �� $��0��60   $��14(�6@   $��Bottom=�6w   ��6N   �� *MiName+$  ��6w   �� 5�   &   $��1��60   $��14(�5�   ,   $��Bottom=�5�   ,   $��Center=�6G   
���  ����5�   ,   �� *	MiPrice+$  �� �� StringFormat$ {0:C}��5�   d   �� 5�   &   -   5        #��[ 5�   )   $��2��5�   )   $��Center=�5�   )   $��Center=�5�   )   $��5,2,5,0q�5�   )   +  %MaterialDesignThemes.Wpf.RippleAssist   
IsCentered . ��5�   )     *Add+
 � Tag 5�   )   �� 5�   #   5�      5�      5�      5�      � 5�      $��1��6   $��2��6    $��0,5.4,0,-0.4q�60   .+�5�      �� $��Right=�6   $ 
Horizontal=�69   .+�5�      �� $��Center=�6E   
��� � �$
��Bold"�6s   $��16(�6�   ��6     *
TotalPrice+6�   �� 5�       �� ContentStringFormat$ {0:C}��5�      $��Center=�5�      
���  ��$
��Bold"�5�      $��16(�5�      ��5�      �� *
TotalPrice+$  ��5�      �� 5�      $��Center=�6D   ��6     *Refund+ d� 	IsChecked 6_   �� *IsRefundChecked+ �� UpdateSourceTrigger$ PropertyChanged=�y�6�   �� *IsModeAdmin+# [ �� 5�      $	��144��5�      $��Stretch=�5�      $��	24,2,24,2q�5�      ��5�        *Confirmation+��5�      �� $
 This��$% DataContext.ConfirmClickCommand�5�      5�      5�      5�      5�      