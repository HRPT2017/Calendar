   M S B A M L   `   `   `  ����C  ?Calendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CalendarCalendar  5   	       Calendar.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Calendar     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � Icon$ /Views/logo.ico��5
   	   
���   � � 	Resources 5         WindowBackgroundBrush �� Color  SolidBorderBrush  ControlBackgroundBrush  ControlBorderBrush  ToggleButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType J� SnapsToDevicePixels	 �� Triggers
 P� Property P� Value �� 
TargetName �� 	ClickMode d� 	IsChecked �� Path �� Mode �� RelativeSource �� SelectionBoxItemTemplate �� SelectionBoxItem# �� SelectionBoxItemStringFormat �� ContentStringFormat J� IsHitTestVisible F�Name � AllowsTransparency �� IsDropDownOpen �� Padding �� Triggers �� CornerRadius ��Name��%[  &	        &	 !     &	 B     &	 c     &	 �     7  7  '�� �    7  7   7  '�� �	    '��     '�� u    '�� O    '��     �� 5   
   $ #006cac��68   �� 5   
   $ #006cac��63   �� 5   
   $ #006cac��69   �� 5   
   $ #006cac��65   �� 5   
   " d�6*   .�5      ��  �@�OverridesDefaultStyle$
 True��66   �� 5       � ��$ False��6*   �� 5       � |�$ False��6*   �� 5       �@��	ClickMode$ Press=�6*   �� 5       � �� 5      �� 5      " d�6&   .R�5      �� $��Border��5      8��  8�� $��1q�5"      $
 True��5#      ._�5$      �� $��ContentPresenter��5%      $��Center=�5&      $��Center=�5'      $
 True��5(      $
��True��5)      5*      	 5+      P� 5,      
 �@d�	IsChecked$
 TrueY�6;   . �5-   "   �� $ Border��6)    � �� �#007ACC6S   5.      P� 5/      
 �@J�IsMouseOver$
 True��6=   . �50   "   �� $ Border��6)    � �� �#005A9E6S   51      P� 52      
 � ��$
 True��6;   . �53   "   �� $ Border��6)    � �� �#004A806S   54      P� 55      
 � {�$ False��6;   . �56   "   �� $ Border��6)    � �� �#4444446S   �� 57   "   $ Border��6)    � �� �#8888886T   �� 58   "    � �� �#8888886?   59      5;      5>      5?      �� 5A   
   " ��6   .�5B      ��  � ��
 �����6+   �� 5C       � �� �#2E2E2E6+   �� 5D       � �� �#006cac6,   �� 5E       � ��$ 2q�60   �� 5F       � ��$	 5,2q�6(   �� 5G       � ��$ 14(�6)   �� 5H       � �� 5I      �� 5J      " ��6&   .R�5K      � .+�5L      d� $��ToggleButton��5M      $��2��5N      $ Press=�5O      $|�false��5P      8��   5Q      �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+5R      �� 5S      $��ContentSite��5T      #��z 5U      #��z��5V      #��z 5W      # z 5X      $
��Left=�5Y      $ False��5Z      $��3,3,23,3q�5[      $��Center=�5\      F� 5]      $ Arrow��6#   $��1��5^      
�������$��0,0,10,0q�5`      $��Right=�5a      $��Center=�5b      "����        � 	=  	= � z     	5c      � 5d      $��Popup��5e      $
 True��5f      $|�False��5g      #��z 5h      $��Slide=�5i      .��5j   "   � $��DropDown��6'   $
 True��67   .+�5k   &   �� $��DropDownBorder��5l   "   8�� 8�� $��1q�5o   "   �� 5p   &   .��5q   *   �� 5r   '   5s   #   5t      5u      5v      5x      5y      �� 5{   
   " ��6   .�5|      ��  � ��
 �   �6+   �� 5}       � �� �#007ACC6,   �� 5~       � ��$ 0,0,0,1q�60   �� 5       � ��$ 5q�6(   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� #��z��5�      #��z��5�      #��z��5�      # z��5�      ._�5�      �� 5�      5�      5�       5�      P� 5�      
 �@��
IsSelected$
 True��60   . �5�      ��  � �� �#006cac63   �� 5�       � ��
 �����63   5�      P� 5�      
 �@J�IsMouseOver$
 True��61   . �5�      ��  � �� �#006cac63   5�      5�      �� 5�   
   " ��6   .�5�      ��  � ��
 �   �6,   �� 5�       � ��$ 1q�60   �� 5�       � ��
 �   �6+   �� 5�       � ��
 �����6+   �� 5�       �@J�SnapsToDevicePixels$
 True��64   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $��Bd��5�      #��z��5�      #��z��5�      #��z��5�      $ 1q�5�      ._�5�      �� .��5�   "   �� # z 61   5�      5�      5�      5�       5�      P� 5�      
 �@J�IsMouseOver$
 True��61   . �5�      ��  � �� �#005A9E64   5�      5�      �� 5�   
   " ��6   .�5�      ��  � ��
 �����6+   �� 5�       � ��$ 14(�6)   �� 5�       � ��$
 Bold"�6+   �� 5�       � ��$ 5q�6(   �� 5�       � ��$ 5q�6'   5�      �� 5�   
   " ��6   .�5�      ��  � �� �#006cac6+   �� 5�       � ��
 �����6+   �� 5�       � �� �#006cac6,   �� 5�       � ��$ 1q�60   �� 5�       � ��$ 10q�6(   �� 5�       � ��$ 5q�6'   �� 5�       � ��$ 14(�6)   �� 5�       � ��$
 Bold"�6+   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� #��z��6!   #��z��6K   #��z��6w   $ 5��6�   ._�5�      �� $��Center=�6/   $��Center=�6L   5�      5�      5�       5�      P� 5�      
 �@J�IsMouseOver$
 True��61   . �5�      ��  � �� �#006cac63   �� 5�       � �� �#006cac64   5�      5�      �� 5�   
   " ��6   .�5�      ��  � ��
 �����6+   �� 5�       � ��
 �   �6+   �� 5�       � �� �#007ACC6,   �� 5�       � ��$ 1q�60   �� 5�       � ��$ 5q�6(   �� 5�       � ��$ 14(�6)   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� #��z��6!   #��z��6M   #��z��6�   $
 True��6�   ._�5�      �� $ PART_ContentHost��6+   5�      5�      5�      5�      5�      .��5�      � .+�5�   
   �� -   5         ��Name$ l_modalidade��5�      $��
Modalidade��6&   $
��Left=�6<   $��	35,16,0,0q�6W   $	��Top=�6j   $	��120��6�   5�      �� 5�   
   -   5         ��Name$ cb_modalidade��5�      $
��Left=�6+   $��	35,42,0,0q�6F   $	��Top=�6Y   $	��205��6q   $��22��6�   �� 5�   
   -   5        $ l_competicao��5�      $��Competição��6&   $
��Left=�6<   $��	35,69,0,0q�6W   $	��Top=�6j   $	��120��6�   5�      �� 5�   
   -   5        $ cb_competicao��5�      $
��Left=�6*   $��	35,99,0,0q�6E   $	��Top=�6X   $	��205��6p   $��25��6|   6�   �� 5�   
   -   5        $ l_evento��5�      $��Evento��6"   $
��Left=�64   $��
35,138,0,0q�6O   $	��Top=�6c   $	��120��6{   5�      �� 5�   
   -   5          ��Name$  
lb_eventos��5�      $��35,182,373,67q�6&   ��5�      �� 5�      .R�5      �� .+�5     �� $
��Bold"�6:   ��6$   �� *Nome+6:   �� 5     $
��Left=�6U   $
��None=�6p   $��65��6�   ��6$   �� *Data+! �� StringFormat$! 
dd/MM/yyyy��6�   5     5     5     �� 5	  
   -   5        " ��Name$" bt_create_competicao��5	     $��Criar Competição��6R   $
��Left=�6m   $��
430,16,0,0q�6�   $	��Top=�6�   $��35��6�   $	��143��6�   �� 5  
   -	   5        $" bt_create_evento��5     $��Criar Evento��6J   $
��Left=�6a   $��
595,16,0,0q�6|   $	��Top=�6�   $��35��6�   $	��143��6�   �� 5  
   -
   5        $" bt_edit_menu_evento��5     $��Editar Evento��6P   $
��Left=�6h   $��
595,69,0,0q�6�   $	��Top=�6�   $��35��6�   $	��143��6�   �� 5  
   -   5        $" bt_edit_menu_competicao��5     $��Editar Competição��6X   $
��Left=�6t   $��
430,69,0,0q�6�   $	��Top=�6�   $��35��6�   $	��143��6�   �� 5  
   -   5        $" bt_remove_menu_evento��5     $��Eliminar Evento��6T   $
��Left=�6n   $��595,129,0,0q�6�   $	��Top=�6�   $��35��6�   $	��143��6�   �� 5  
   -   5        $" bt_delete_competicao��5     $��Eliminar Competição��6R   $
��Left=�6p   $��430,129,0,0q�6�   $	��Top=�6�   $��35��6�   $	��143��6�   �� 5  
   -   5        $" bt_ical��5     $��Exportar Ical��6"   $
��Left=�6P   $��502,182,0,0q�6k   $	��Top=�6�   $��35��6�   $	��164��6�   5     5     