   M S B A M L   `   `   `  ����   CompareFolders    CompareFolders.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Compare Directories��$��508.537��$��999.627��.��� $��0,0,0,-1q� � ColumnDefinitions �� $
��509* ��� $��8* �.+��� -    ��Name$ MissingFileList1��$
��Left=�$	��264��$��
309,79,0,0q�$	��Top=�$	��153��$��5q����	#FFEA1111 � Cursor$
 Hand�� �� View �� .P��� $��Missing file�� �� Width$	 150�� �� DisplayMemberBinding �� �� $3��-Enter the directory path of the first folder:��$
��Left=�$��	10,25,0,0q�$	��Top=�$��26��$	��230���� -    ��Name$ Folder1Path��$
��Left=�$��23��$��	10,56,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��230���� -   $ Folder2Path��$
��Left=�$��23��$��
10,208,0,0q�$
 Wrap=�$	��Top=�$	��230���� $
��Left=�$��	309,9,0,0q�$
��Wrap=�$e��_The list below shows the files missing in the second folder (but first folder has those files).��$	��Top=�$	��175��$��70���� -   	 ��Name$	 Compare��$��COMPARE!��$
��Left=�$��
86,298,0,0q�$	��Top=�$��98��
 J� RenderTransformOrigin$
 0.059,-0.016&�#��� ��$��38���� $
��Left=�$��	560,9,0,0q�$
��Wrap=�$^��XThe list below shows the files missing in the first folder (but second has those files).��$	��Top=�$	��153���� -   $ MissingFileList2��$
��Left=�$	��264��$��
560,79,0,0q�$	��Top=�$	��153��$��5q����	#FFECEC0E$
 Hand�� �� .P��� $��Missing file��$	 150�� �� � -    �Name$ ComparingProgress��$
��Left=�$��34��$��
10,422,0,0q�$	��Top=�$	��230���� -   $ SameFileList��$
��Left=�$	��264��$��
784,79,0,0q�$	��Top=�$	��153�����	#FF33E20C$��5q� �� .P��� $��Similar Files��$	 150�� �� �� $
��Left=�$��	784,9,0,0q�$
��Wrap=�$>��8The list below shows the files that are in both folders.��$	��Top=�$	��153���� $
��Left=�$��
10,162,0,0q�$
��Wrap=�$Q��KEnter the directory path of the second folder: (commonly the backup folder)��$	��Top=�$	��246���� -	    ��Name$ Months��$
��Left=�$��103,369,0,0q�$	��Top=�$��58���� -
   $
 Year��$
��Left=�$��23��$��
10,369,0,0q�$
 Wrap=�$	��Top=�$��69��$
 0.138,0.891&��� -   $
 Days��$
��Left=�$��189,370,0,0q�$	��Top=�$��51��$
 -0.657,1&��� $��Year:��$
��Left=�$��
10,336,0,0q�$	��Top=��� $
��Day:��$
��Left=�$��189,337,0,0q�$	��Top=��� $��Month:��$
��Left=�$��103,336,0,0q�$	��Top=��� $
��Left=�$	��100��$��-103,41,0,0q�$	��Top=�$	��100���� -   $	 Browse2��$��	Browse...��$
��Left=�$��
10,236,0,0q�$	��Top=�$��75���� -   $	 Browse1��$��	Browse...��$
��Left=�$��	10,84,0,0q�$	��Top=�$��75���� -    ��Name$ RedCount��$��File Count: ��$
��Left=�$��351,365,0,0q�$	��Top=��� -   $ YellowCount��$��File Count: ��$
��Left=�$��609,365,0,0q�$	��Top=��� -   $ 
GreenCount��$��File Count: ��$
��Left=�$��828,365,0,0q�$	��Top=�