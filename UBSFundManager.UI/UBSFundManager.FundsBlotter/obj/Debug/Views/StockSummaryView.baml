   M S B A M L   `   `   `  ����  UBSFundManager.FundsBlotter8    2UBSFundManager.FundsBlotter.Views.StockSummaryView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5         CellRightAlign �� Property �� Value��%O   &	        �� 5   
   .�5	      ��  � ��$ Right=�5
      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   .+�5    
   �� $��1��6   $��0��6$   ��65   ��  �� Path$ StockSummary� �� Mode$ OneWay=���5!      �� 5"      .R�5$      ��  �� Padding$ 1q�6!   ���	#77239E0F���#ffffff$��1,1,1,1q�6[   $��3q�6u    �� CornerRadius$ 3��6�   $
��Auto��6�   ._�5%      �� $��0��6)   $��0��66   $
��Auto��6F   .+�5&      � $��3q�6#    5'   "   �� 5(   &   $��* �64   �� 5)   &   $��* �64   �� 5*   &   $��* �64   �� 5+   &   $��* �64    5-   "   �� 5.   &   $	��105 �67   �� 5/   &   $��* �67   .+�52   "   �� $��0��6,   $��0��69   $��2��6I   $
��Left=�6^   $��15(�6z   ���	#FFAE4728$��Center=�53   @   $��5,0,0,0q�6[   $��	ExtraBold"�6l   $��	Underline{�6�   ��54   )   �� $ 	StockType�$ OneWay=��� 56   "   $��Total Quantity: ��6,   $��1��6E   $��0��6R   $
��Auto��6c   $
��Left=�6q   $��Center=�6�   �� 57   "   $��1��6,   $��1��69   $
��Left=�6I   ���	#FFAE4728$��Center=�58   @   $��5,0,0,0q�6[   $
��Bold"�6l   ��59   )   �� $ TotalQuantity�$ OneWay=�	 �� StringFormat$	 {0:N0}���� 5;   "   $��Total Market Value: ��6,   $��2��6I   $��0��6V   $
��Auto��6g   $
��Left=�6u   $��Center=�6�   �� 5<   "   $��2��6,   $��2��69   $
��Left=�6I   ���	#FFAE4728$��Center=�5=   @   $��5,0,0,0q�6[   $
��Bold"�6l   ��5>   )   �� $ TotalMarketValue�$ OneWay=�$	 {0:N2}���� 5@   "   $��Total Stock Weight: ��6,   $��3��6I   $��0��6V   $
��Auto��6g   $
��Left=�6u   $��Center=�6�   �� 5A   "   $��3��6,   $��1��69   $��Stretch=�6I   ���	#FFAE4728$��Center=�5B   @   $��5,0,0,0q�6[   $
��Bold"�6l   ��5C   )   �� $ TotalStockWeight�$ OneWay=�$	 {0:P}��5D      5E      5F      5G      5I      5K      5L      