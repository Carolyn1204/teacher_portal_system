   M S B A M L   `   `   `  ����H  DTeacherPortal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TeacherPortalTeacherPortal  5   	       TeacherPortal.List   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:TeacherPortal     5   	     � Title$
  List��5   	   $	��800��6   $
��1000��6#   .��5	      � -   5         �Name$ bookListGrid��5	      $��0,0,-114,-16q�6!    � ColumnDefinitions 5
   
   �� 5      $��0* �6   �� 5      .+�5   
   �� -   5         ��Name$ addBook��5      $	��Add��6"   $
��Left=�60   $��
141,45,0,0q�6K   $	��Top=�6_   $��39��6w   $��82��6�   $��18(�6�   $��2��6�   �� 5   
   -   5        $ 
deleteBook��5      $��Delete��6%   $
��Left=�66   $��
245,45,0,0q�6Q   $	��Top=�6e   $��39��6}   $��82��6�   $��18(�6�   $��2��6�   �� 5   
   -   5        $ 
UpdateBook��5      $��Update��6%   $
��Left=�66   $��
345,45,0,0q�6Q   $	��Top=�6e   $��39��6}   $��82��6�   $��18(�6�   $��2��6�   �� 5   
   -   5        $ addBook1��5      $	��Add��6#   $
��Left=�61   $��
660,45,0,0q�6L   $	��Top=�6`   $��39��6x   $��82��6�   $��18(�6�   $��2��6�   �� 5   
   -   5        $ deleteBook1��5      $��Delete��6&   $
��Left=�67   $��
764,45,0,0q�6R   $	��Top=�6f   $��39��6~   $��82��6�   $��18(�6�   $��2��6�   �� 5   
   -   5        $ 
updateBook��5      $��Update��6%   $
��Left=�66   $��
864,45,0,0q�6Q   $	��Top=�6e   $��39��6}   $��82��6�   $��18(�6�   $��2��6�   �� 5   
   $��List of Books��6   $
��Left=�6(   $��196,114,0,0q�6C   $	��Top=�6X   $��20(�6p   $��2��6~   �� 5   
   $��List of Subjects��6   $
��Left=�6+   $��673,114,0,0q�6F   $	��Top=�6[   $��20(�6s   $��2��6�   �� 5   
   -   5         ��Name$ bookList��5      $
��Left=�6&   $��133,172,0,0q�6A   $
��Wrap=�6V   $	��Top=�6j   $	��432��6�   $	��245��6�   $��18(�6�   $��2��6�   �� 5   
   -	   5        $ subjectList��5      $
��Left=�6)   $��660,172,0,0q�6D   $
��Wrap=�6Y   $	��Top=�6m   $	��432��6�   $	��245��6�   $��18(�6�   $��2��6�   �� 5   
   -
   5        $ showBookList��5      $��ShowList��6'   $
��Left=�6:   $��	39,45,0,0q�6U   $	��Top=�6h   $��18(�6�   $��37��6�   $��75��6�   $��2��6�   �� 5   
   -   5        $ addBook1_Copy��5      $	��Add��6(   $
��Left=�66   $��
660,45,0,0q�6Q   $	��Top=�6e   $��39��6}   $��82��6�   $��18(�6�   $��2��6�   �� 5   
   -   5        $ deleteSubject��5      $��Delete��6(   $
��Left=�69   $��
764,45,0,0q�6T   $	��Top=�6h   $��39��6�   $��82��6�   $��18(�6�   $��2��6�   �� 5   
   -   5        $ updateSubject��5      $��Update��6(   $
��Left=�69   $��
864,45,0,0q�6T   $	��Top=�6h   $��39��6�   $��82��6�   $��18(�6�   $��2��6�   �� 5   
   -   5        $ showSubjectList��5      $��ShowList��6*   $
��Left=�6=   $��
537,45,0,0q�6X   $	��Top=�6l   $��37��6�   $��84��6�   $��18(�6�   $��2��6�   �� 5   
   -   5        $��Logout��5      $
��Left=�6"   $��782,652,0,0q�6=   $	��Top=�6R   $��50��6j   $	��123��6v   $��20(�6�   $��2��6�   5      5       