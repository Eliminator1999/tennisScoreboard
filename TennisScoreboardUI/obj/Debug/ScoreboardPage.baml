   M S B A M L   `   `   `  ����M  ITennisScoreboardUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TennisScoreboardUITennisScoreboardUI  5      '    !TennisScoreboardUI.ScoreboardPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:TennisScoreboardUI     5        N� Title$  ScoreboardPage��5	      .��5      � .+�5   
   �� -   5         ��Name$ AddScoreFirstPlayer��5      $��	Add Point��6.   $
��Left=�6B   $��	48,89,0,0q�6]   $	��Top=�6p   $��75��6�   
 � Tag$ firstPlayer��6�   $��44��6�   �� 5   
   -   5         ��Name$ FirstPlayerName��5      $
��Left=�6-   $��
156,60,0,0q�6H   $
��Wrap=�6\   $	��Top=�6p   $	��122��6�   $	��122��6�   $��20(�6�   $
��Bold"�6�   �� 5   
   -   5        $ SecondPlayerName��5      $
��Left=�6.   $��156,243,0,0q�6I   $
��Wrap=�6^   $	��Top=�6r   $	��148��6�   $	��122��6�   $
��Bold"�6�   $��20(�6�   �� 5   
   -   5        $ FirstPlayerPointScore��5      $
��Left=�63   $��
283,60,0,0q�6N   $
��Wrap=�6b   $	��Top=�6v   $	��106��6�   $	��119��6�   $��0��6�   $
��Bold"�6�   $��80(�6�    �� TextAlignment$ Center=�6�   �� 5   
   -   5        $ SecondPlayerPointScore��5      $
��Left=�64   $��283,253,0,0q�6O   $
��Wrap=�6d   $	��Top=�6x   $	��106��6�   $	��119��6�   $��0��6�   $
��Bold"�6�   $��80(�6�   $ Center=�6�   �� 5   
   -   5        $ AddScoreSecondPlayer��5      $��	Add Point��6/   $
��Left=�6C   $��
48,277,0,0q�6^   $	��Top=�6r   $��75��6�   $ secondPlayer��6�   $��44��6�   � 5   
   -   5         �Name$ 	ScoreGrid��5      .+�5      �� -   5        $ FirstPlayerFirstSetScore��5      $ 00��6:   $
��Left=�6C   $��
407,60,0,0q�6^   $
��Wrap=�6r   $	��Top=�6�   $	��106��6�   $	��119��6�   $��0��6�   $
��Bold"�6�   $��80(�6�   $ Center=�6�   �� 5      -	   5        $ FirstPlayerSecondSetScore��5      $ 01��6;   $
��Left=�6D   $��
531,60,0,0q�6_   $
��Wrap=�6s   $	��Top=�6�   $	��106��6�   $	��119��6�   $��0��6�   $
��Bold"�6�   $��80(�6�   $ Center=�6�   �� 5      -
   5        $ FirstPlayerThirdSetScore��5      $ 02��6:   $
��Left=�6C   $��
655,60,0,0q�6^   $
��Wrap=�6r   $	��Top=�6�   $	��106��6�   $	��119��6�   $��0��6�   $
��Bold"�6�   $��80(�6�   $ Center=�6�   �� 5      -   5        $ SecondPlayerFirstSetScore��5      $ 10��6;   $
��Left=�6D   $��407,253,0,0q�6_   $
��Wrap=�6t   $	��Top=�6�   $	��106��6�   $	��119��6�   $��0��6�   $
��Bold"�6�   $��80(�6�   $ Center=�6�   �� 5      -   5        $  SecondPlayerSecondSetScore��5      $ 11��6<   $
��Left=�6E   $��531,253,0,0q�6`   $
��Wrap=�6u   $	��Top=�6�   $	��106��6�   $	��119��6�   $��0��6�   $
��Bold"�6�   $��80(�6�   $ Center=�6�   �� 5      -   5        $ SecondPlayerThirdSetScore��5      $ 12��6;   $
��Left=�6D   $��655,253,0,0q�6_   $
��Wrap=�6t   $	��Top=�6�   $	��106��6�   $	��119��6�   $��0��6�   $
��Bold"�6�   $��80(�6�   $ Center=�6�   5      �� 5   
   $
��Left=�6   $��
407,33,0,0q�6/   $
��Wrap=�6C   $��          1��6W   $	��Top=�6j   $	��119��6�   ���	#FFE6F1F0$
��Bold"�6�   $��20(�6�   �� 5   
   $
��Left=�6   $��
531,33,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $	��119��6o   ���	#FFE6F1F0$
��Bold"�6�   $��20(�6�   $��          2��6�   �� 5   
   $
��Left=�6   $
��Wrap=�6/   $��          3��6C   $	��Top=�6V   $	��119��6n   ���	#FFE6F1F0$
��Bold"�6�   $��20(�6�   $��
655,33,0,0q�6�   5      5      