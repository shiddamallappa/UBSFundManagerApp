   M S B A M L   `   `   `  ����   UBSFundManager.FundsBlotter1    +UBSFundManager.FundsBlotter.Views.StockView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8)prismhttp://www.codeplex.com/prism  
�������.  (System.Windows.Interactivity.Interaction    Triggers  F  @Prism.Interactivity.InteractionRequest.InteractionRequestTrigger  3  -System.Windows.Interactivity.EventTriggerBase   SourceObject �� *NotificationRequest+ �� Mode$ OneWay=�.  (System.Windows.Interactivity.TriggerBase   Actions. +  %Prism.Interactivity.PopupWindowAction     IsModal . !   CenterOverAssociatedObject . .��� -    �Name$ 
LayoutRoot��$��Stretch=�$��Center=�$��3q� � RowDefinitions �� $
��auto � � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0��$��0��$��Right=�$��45��$
��Auto�����	#FFAE4728$��Center=�$��5,0,0,0q�$
��Bold"����� 	 �� Path$	 StockAction�$ TwoWay=��� $��0��$��1��$��Right=�$
��Auto��$
��Auto��$��Stock Type:�����	#FF444444$��Center=�$��5,0,0,0q��� -   
 ��Name$
 cmbbxStockType��4  .System.Windows.Automation.AutomationProperties   AutomationId$ cmbbxStockType��$ �� IsSynchronizedWithCurrentItem$
 TrueY�$��0��$��2��$	��120��$
��Auto��$��Center=�$��Stretch=�$��5,0,0,0q� �� DisplayMemberPath$
 Type�� �� SelectedValuePath$ Id�� �� SelectedValue �� $	 SelectedStockTypeId�$ TwoWay=����� *
StockTypes+{��� $	 IsSelectable�$ OneWay=��� $��0��$��3��$��Price :�����	#FF444444$��Center=�$
��Auto��$
��Auto��$��Right=�$��1��$��5,0,0,0q��� -   $��
stockPrice��$��0��$��4��$ 
stockPrice��$��Stretch=�$	��120��$
��Auto��$��Center=�$��5,0,0,0q����� $	 Price� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnExceptions .  �� NotifyOnValidationError .  �� ValidatesOnDataErrors . �� $��0��$��5��$��
Quantity :�����	#FF444444$��Center=�$
��Auto��$
��Auto��$��Right=�$��1��$��5,0,0,0q��� -   $��stockQuantity��$��0��$��6��$ stockQuantity��$��Stretch=�$	��120��$
��Auto��$��Center=�$��5,0,0,0q����� $	 Quantity� �� StringFormat$ {0:N0}��$ PropertyChanged=� .  .  . �� $��0��$��7��$��2�� �� Orientation$ 
Horizontal=�$��5,0,5,0q�$
��Left=�.+��� -   $��SubmitButton��$��0,0,3,0q�$��60�� � Cursor$
 Hand������ *SaveStockDetailCommand+.��Submit�� -   $��CancelButton��$��3,0,0,0q�$��75��$
 Hand������ *CancelStockDetailCommand+.��Cancel