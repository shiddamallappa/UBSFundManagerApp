   M S B A M L   `   `   `  ����X  TUBSFundManager.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�]clr-namespace:UBSFundManager.Infrastructure.Converters;assembly=UBSFundManager.Infrastructure(UBSFundManager.Infrastructure.Converters  5       UBSFundManager.FundsBlotter3   -UBSFundManager.FundsBlotter.Views.BlotterView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8)prismhttp://www.codeplex.com/prism  5      ilocal]clr-namespace:UBSFundManager.Infrastructure.Converters;assembly=UBSFundManager.Infrastructure  5      .  (System.Windows.Interactivity.Interaction    Triggers  5
      F  @Prism.Interactivity.InteractionRequest.InteractionRequestTrigger  5   
   3  -System.Windows.Interactivity.EventTriggerBase   SourceObject 6*   �� *ConfirmationRequest+ �� Mode$ OneWay=�.  (System.Windows.Interactivity.TriggerBase   Actions. 5      +  %Prism.Interactivity.PopupWindowAction     IsModal . !   CenterOverAssociatedObject . 65   5       � 	Resources 5         CellRightAlign �� Property �� ValueB   <UBSFundManager.Infrastructure.Converters.ColorMultiConverter  colorMultiConverter��%l   &	        &	 E     �� 5   
   .�5      ��  � ��$ Right=�5      5        5   
   6B   5      .��5      � -   5        	 �Name$	 
LayoutRoot��5      ��5   
   �� 5      
 �� EndPoint$
 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF7B97D4��6   � 5      $ 	#FF244C8D��6    � Offset$ 1Q�61   5       � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5    
   �� 5!      $��* �6   .+�5$   
   &   System.Windows.Controls.DataGrid  -   5          Name$ gridStocksBlotter��5$         SelectionMode$ Single=�6/      AutoGenerateColumns .  $��2q�5%   h   $ �� IsSynchronizedWithCurrentItem$ FalseY�5'      4  .System.Windows.Automation.AutomationProperties   AutomationId$ gridStocksBlotter��5(         
IsReadOnly . ��5%      ��  �� Path$ Stocks�$ TwoWay=� �� SelectedItem 5&      �� $ SelectedStock�$ TwoWay=�   RowStyle 5)      �� 5*       �� 
TargetType)	  #System.Windows.Controls.DataGridRow" 	 6   �5+      �� 5,       � �� 5-      `� 5.   "    `� 	Converter# [ 6/   .1�5/   &   �� $
 Type�6.   �� 50   &   $ MarketValue�6.   �� 51   &   $ TransactionCost�6.   52   #   54      56         Columns 58      0
  *System.Windows.Controls.DataGridTextColumn
  59      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Stock Type��6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 75 6i   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� $
 Type�6i   
  5:      $ 
Stock Name��6%    . $ * 6n    69   �� $ 	StockName�6n   
  5;      $ Price��6%    . $ * 6{       ElementStyle#  [  6�    64   �� $ Price�! �� StringFormat$! {0:N8}��6�   
  5<      $ Quantity��6%    . $ * 6�   #  [  6�    67   �� $ Quantity�$! {0:N0}��6�   
  5=      $ Market Value��6%    . $ * 6�   #  [  6�    6;   �� $ MarketValue�$! {0:N2}��6�   
  5>      $ Transaction Cost��6%    . $ * 6�   #  [  6�    6?   �� $ TransactionCost�$! {0:N2}��6�   
  5?      $ Stock Weight��6%    . $ * 6�   #  [  6�    6;   �� $ StockWieght�$! {0:P}��6�   4  .System.Windows.Controls.DataGridTemplateColumn  5@      $ Delete��6)   "   CellTemplate" 5A      �� 5B      .R�5C      �� $��X��6%   ��5D      �� # �� RelativeSource# �� $ �� AncestorType"$  $$ DataContext.DeleteStockCommand���5F      �� 5G      5I      5K      5M      5P      