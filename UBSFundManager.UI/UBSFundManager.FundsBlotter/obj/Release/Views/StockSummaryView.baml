   M S B A M L   `   `   `  ����   UBSFundManager.FundsBlotter8    2UBSFundManager.FundsBlotter.Views.StockSummaryView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � 	Resources     CellRightAlign �� Property �� Value��%+   &	        �� .���  � ��$ Right=�.���  � ColumnDefinitions �� $��* � � RowDefinitions �� $��* �.+��� $��1��$��0������  �� Path$ StockSummary� �� Mode$ OneWay=����� .R���  �� Padding$ 1q����	#77239E0F���#ffffff$��1,1,1,1q�$��3q� �� CornerRadius$ 3��$
��Auto��._��� $��0��$��0��$
��Auto��.+�� $��3q� �� $��* ��� $��* ��� $��* ��� $��* � �� $	��105 ��� $��* �.+��� $��0��$��0��$��2��$
��Left=�$��15(����	#FFAE4728$��Center=�$��5,0,0,0q�$��	ExtraBold"�$��	Underline{����� $ 	StockType�$ OneWay=��� $��Total Quantity: ��$��1��$��0��$
��Auto��$
��Left=�$��Center=��� $��1��$��1��$
��Left=����	#FFAE4728$��Center=�$��5,0,0,0q�$
��Bold"����� $ TotalQuantity�$ OneWay=�	 �� StringFormat$	 {0:N0}���� $��Total Market Value: ��$��2��$��0��$
��Auto��$
��Left=�$��Center=��� $��2��$��2��$
��Left=����	#FFAE4728$��Center=�$��5,0,0,0q�$
��Bold"����� $ TotalMarketValue�$ OneWay=�$	 {0:N2}���� $��Total Stock Weight: ��$��3��$��0��$
��Auto��$
��Left=�$��Center=��� $��3��$��1��$��Stretch=����	#FFAE4728$��Center=�$��5,0,0,0q�$
��Bold"����� $ TotalStockWeight�$ OneWay=�$	 {0:P}��