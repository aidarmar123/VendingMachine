   M S B A M L   `   `   `  ����P  LDesktopVendingMachine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:DesktopVendingMachine.PagesDesktopVendingMachine.Pages  5      -    'DesktopVendingMachine.Pages.CompanyPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:DesktopVendingMachine.Pages     5        N� Title$  CompanyPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   �� .+�5      �� $#��Список компаний��6   �� 5      ��6   �� *Companys.Count+ �� StringFormat$) #Всего найдено {0} шт.��5      � 5   
   $��1��6    5      �� 5      $
��auto �6    �� 5      �� 5      $
��auto �6    .+�5      � .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Показать��6    �� 5      -   5         ��Name$ CbCountItem��5       �� SelectedItem 5       �� *	CountItem+5!      �� 5"      $��запиcей��6    5#      �� 5%      $��Center=�6   .+�5&      �� $	��250��6:   ��6   �� *
SearchText+6:   5'      �� 5)      $ 
Horizontal=�6   $��Right=�66   .+�5*      �� -   5         ��Name$
 BAdd��5*      $��➕ Добавить��5+      5,      �� 5-      -   5        $ BExport��5-      $��⤵ Экспорт��5.      5/      52      54      �� 55      $��1��6   .@�56      �� $��В строку��6   .��57      &   System.Windows.Controls.DataGrid  -   5          Name$ DGMacine��57       �� AlternationCount$ 2��58      	   AutoGenerateColumns	 .  
   
IsReadOnly
 .    RowStyle 5;      �� 5<       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6$    �� Triggers 5=   "   P� 5>   &    P� Property �@��AlternationIndex P� Value$ 0��6W   . �5?   *   ��  �� Property � �� �� Value
 �����5@   1   5A   '   5D         Columns 5F      0  *System.Windows.Controls.DataGridTextColumn  5I      ,  &System.Windows.Controls.DataGridColumn   Header$' !Название компании��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5J       �� *Name+  5M      $ Вышестоящия��61    5N       �� *PrimaryCompanyName+  5R      $ 
Адрес��61    5S       �� *Adress+  5U      $ Контакты��61    5V       �� *ContactCompany+  5Z      $ В работе с ��61    5[       �� *
InitWork+4  .System.Windows.Controls.DataGridTemplateColumn  5]         CellTemplate 5^   "   �� 5_   &   .R�5`   *   �� $ 
Horizontal=�65   .+�5a   .   �� $ BEdit��65   -   5        $	��✏��5b   $   
����ح�
������ $��0q�5f   $   �� 5h   .   $ BDelete��65   -   5        $
��🗑��5i   $   
����ح�
������ $��0q�5m   $   5o   +   5p   '   5r      5u      5v      �� 5w      $��Плиткой��6   .��5x      �� -   5         ��Name$ 	LVMachine��5x      ��5y      �� 5z      .R�5{   "   �� .+�5}   &   �� ��5~      �� *Name+$ Название  {0}���� 5�   &   ��5�      �� *PrimaryCompanyName+$  Вышестоящия {0}���� 5�   &   ��5�      �� *Adress+$ Адрес {0}���� 5�   &   ��5�      �� *ContactCompany+$ Контакты {0}���� 5�   &   ��5�      �� *
InitWork+$$ В работе с  dd.MM.yyyy���� 5�   &   $ 
Horizontal=�61   .+�5�   *   �� $ BEdit��61   -   5        $	��✏��5�      
����ح�
������ $��0q�5�      �� 5�   *   $ BDelete��61   -	   5        $
��🗑��5�      
����ح�
������ $��0q�5�      5�   '   5�   #   5�      ��5�      �� 5�      .R�5�   "   � 5�      5�      5�      5�      � 5�      $��2��6   .+�5�      �� $ 
Horizontal=�6   $��Right=�66   .+�5�      �� -
   5        $ BPrevous��5�      $	��◀��5�      
������ 5�      �� 5�      ��6    �� *	IndexPage+�� 5�      -   5        $ BNext��5�      $	��▶��5�      
������ 5�      5�      5�      5�      5�      5�      