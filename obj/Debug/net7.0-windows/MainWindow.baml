   M S B A M L   `   `   `  ����K  GLesDelicesDeTata, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:LesDelicesDeTataLesDelicesDeTata  5   	   !    LesDelicesDeTata.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:LesDelicesDeTata     5   	     � Title$  LesDelicesDeTata��5	   	   $	��450��6"   $	��800��6/    � DataContext 5   	   ��  �� RelativeSource �� *Self+ � 	Resources 5          BooleanToVisibilityConverter �� 
TargetType �� Property �� Value �� Triggers �� Binding	 �� Value��%�  &	        '��      �� 5   
   6'   �� 5   
   " ��6   .�5      ��  � ��$ 0q�60   �� 5       � ��
 ���� 6+   �� 5       � ��
 �   �6+    5      �� 5       6   �� *
IsSelected+	 True6=   .a�5      ��  � ��
 ��ح�63   5      �� 5       6   �� *
IsSelected+		 False6=   .a�5      ��  � ��
 ���� 63   5      5      5      .��5      � 
 � RowDefinitions
 5   
   �� 5       $
��Auto �6   �� 5!      $��* �6   .+�5%   
   �� 
������� �� Padding$ 10q�6$   ._�5&      ��  �� Orientation$ 
Horizontal=�6   $
��Left=�62   .+�5'      �� $��/medias/logo.png��6   $	��100��62   $	��100��6>   $��5q�6K   �� 5(      $��LesDelicesDeTata��6   $��20(�64   �� 5*      ��6   �� *	Categorie+��5+      �� 5,      .R�5-      �� $ 
Horizontal=�6)   5.      ��50      �� 51      .R�52      �� $��5q�55   %   ��52   %   �� *
NomCateg+��53   %   �� *,*DataContext.ToggleCategorySelectionCommand+ ��  �� AncestorType
 Window��54   %   �� {�56   %   �� *
IsSelected+ �� 	Converter# [  57      59      o� 5;      .@�5<      �� -   5        $��Ajouter��5<      
���   �$��1��6C   $��0��6P   $��3��6`   $	��100��6t   $��20��6�   $��Center=�6�   $��Center=�6�   $��10q�6�   5A      5B      5C      �� 5G   
   $��1��6   .��5H      �� ��6   �� *
Produits+��5I      �� 5J      .R�5K      �� 
���   �$��1q�65   $��5q�6I   $	��200��6T   ._�5L      �� .+�5M   "   �� $	��200��6(   $	��300��64   ��5N   &   �� 5O   *    �� 	UriSource 66   �� *Image+5Q   #   �� 5S   "   -   5        
������ $��0q�5S   C   ._�5T   &   �� .+�5U   *   �� $��Center=�6I   $
��Bold"�6f   ��64   �� *Nom+6f   �� 5V   *   $��Center=�6J   ��64   �� *Prix+6J   �� 5W   *   -   5        $��	Supprimer��5W   1   $��10q�6]   
 � Tag 6i   �� *id+�� 5X   *   -   5        $��Modifier��5X   1   $��10q�6[   5Y   '   5Z   #   5[      5]      5^      ��5`      �� 5a      .R�5b      �  � Orientation$ 
Horizontal=�6$   5c      5e      5f      5h      5i      