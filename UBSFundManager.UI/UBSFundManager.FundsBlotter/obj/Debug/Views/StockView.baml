   M S B A M L   `   `   `  ����X  TUBSFundManager.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Zclr-namespace:UBSFundManager.Infrastructure.Utility;assembly=UBSFundManager.Infrastructure%UBSFundManager.Infrastructure.Utility  5       UBSFundManager.FundsBlotter1   +UBSFundManager.FundsBlotter.Views.StockView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      P LPrism.Wpf, Version=6.1.0.0, Culture=neutral, PublicKeyToken=91a96d2a154366d8)prismhttp://www.codeplex.com/prism  5      flocalZclr-namespace:UBSFundManager.Infrastructure.Utility;assembly=UBSFundManager.Infrastructure  5      
�������.  (System.Windows.Interactivity.Interaction    Triggers  5      F  @Prism.Interactivity.InteractionRequest.InteractionRequestTrigger  5      3  -System.Windows.Interactivity.EventTriggerBase   SourceObject 6+   �� *NotificationRequest+ �� Mode$ OneWay=�.  (System.Windows.Interactivity.TriggerBase   Actions. 5      +  %Prism.Interactivity.PopupWindowAction     IsModal . !   CenterOverAssociatedObject . 65   5      .��5      � -   5         �Name$ 
LayoutRoot��5      $��Stretch=�6   $��Center=�6=   $��3q�6X    � RowDefinitions 5   
   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5    
   �� $��0��6   $��0��6!   $��Right=�61   $��45��6M   $
��Auto��6X   ���	#FFAE4728$��Center=�5!   +   $��5,0,0,0q�6F   $
��Bold"�6W   ��5"      �� 	 �� Path$	 StockAction�$ TwoWay=��� 5$   
   $��0��6   $��1��6!   $��Right=�61   $
��Auto��6M   $
��Auto��6Z   $��Stock Type:��6h   ���	#FF444444$��Center=�5%   +   $��5,0,0,0q�6F   �� 5&   
   -   5        
 ��Name$
 cmbbxStockType��5&      4  .System.Windows.Automation.AutomationProperties   AutomationId$ cmbbxStockType��6+   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6^   $��0��5(      $��2��6    $	��120��60   $
��Auto��6<   $��Center=�6J   $��Stretch=�6e   $��5,0,0,0q�6�    �� DisplayMemberPath$
 Type��5)       �� SelectedValuePath$ Id��6,    �� SelectedValue 5'      �� $	 SelectedStockTypeId�$ TwoWay=���6S   �� *
StockTypes+{�5)   C   �� $	 IsSelectable�$ OneWay=�5*      �� 5,   
   $��0��6   $��3��6!   $��Price :��61   ���	#FF444444$��Center=�6W   $
��Auto��5-      $
��Auto��6!   $��Right=�6/   $��1��6K   $��5,0,0,0q�6_   �� 5.   
   -   5        $��
stockPrice��5.   ^   $��0��6   $��4��6   $ 
stockPrice��6/    �� 	MaxLength$ 10��6p   $��Stretch=�50      $	��120��60   $
��Auto��6<   $��Center=�6J   $��5,0,0,0q�6e   ��5/      �� $	 Price�$ TwoWay=�.��50   w      	Behaviors 51      @   :UBSFundManager.Infrastructure.Utility.TextBoxInputBehavior  52         	InputMode$ DecimalInput=�6-      JustPositivDecimalInput . 6F   .��53   '   54      �� 56   
   $��0��6   $��5��6!   $��
Quantity :��61   ���	#FF444444$��Center=�6Z   $
��Auto��57      $
��Auto��6!   $��Right=�6/   $��1��6K   $��5,0,0,0q�6_   �� 58   
   -   5        $��stockQuantity��58   a   $��0��6   $��6��6   $ stockQuantity��6/   $ 10��6v   $��Stretch=�5:      $	��120��60   $
��Auto��6<   $��Center=�6J   $��5,0,0,0q�6e   ��59      �� $	 Quantity�$ TwoWay=�.��5:   w    5;        5<      $ 
DigitInput=�6-   .��5=   '   5>      �� 5@   
   $��0��6   $��7��6"   $��2��63    �� Orientation$ 
Horizontal=�6G   $��5,0,5,0q�6`   $
��Left=�6q   .+�5A      �� -   5        $��SubmitButton��5A      $��0,0,3,0q�6T   $��60��6e    � Cursor$
 Hand��6p   ��6)   �� *SaveStockDetailCommand+.��6~   Submit6�   �� 5B      -   5        $��CancelButton��5B      $��3,0,0,0q�6V   $��75��6g   $
 Hand��6r   ��6)   �� *CancelStockDetailCommand+.��6�   Cancel6�   5C      5E      5F      