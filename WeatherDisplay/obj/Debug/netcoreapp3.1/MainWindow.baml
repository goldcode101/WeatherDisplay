   M S B A M L   `   `   `  ����I  EWeatherDisplay, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WeatherDisplayWeatherDisplay  5   	   U QSystem.Runtime, Version=4.2.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a7,clr-namespace:System;assembly=System.RuntimeSystem 64       WeatherDisplay.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WeatherDisplay     5   	   <sys,clr-namespace:System;assembly=System.Runtime     64     � Title$  WeatherDisplay��5   	   $	��450��6    $	��800��6-    � Icon$R LC:\Users\itsch\dev\CSharp\WeatherDisplay\WeatherDisplay\Resources\github.ico��5	   	    � 	Resources 5
         strTemperature��%-   &	        ��5   
   Temperature��69   5      .��5      �� 
����+��.+�5   
   �� -   5         ��Name$ txtTemp��5      $��NoWrap=�6%   $��60(�6;    J� RenderTransformOrigin$ 1.676,0.499&�6I    �� Left$	 353��6m   
 �� Top$ 20��6   0 F6�   �� 5   
   -   5        $ txtDew��5      $��NoWrap=�6$   $��20(�6:   $ 1.676,0.499&�6H   $ 24��6l   $ 93��6}   
Dewpoint6�   �� 5   
   -   5        $ txtCity��5      $��NoWrap=�6%   $��20(�6;   $ 1.676,0.499&�6I   $ 24��6m   $ 5��6~   City6�   �� 5   
   -   5        $ txtState��5      $��NoWrap=�6&   $��20(�6<   $ 1.676,0.499&�6J   $ 24��6n   $ 25��6   State6�   �� 5   
   -   5        $ 
txtCountry��5      $��NoWrap=�6(   $��20(�6>   $ 1.676,0.499&�6L   $ 24��6p   $ 45��6�   	Country6�   �� 5   
   -   5        $ txtWindSpeed��5      $��NoWrap=�6*   $��20(�6@   $ 1.676,0.499&�6N   $ 24��6r   $	 124��6�   	WindSpd6�   �� 5   
   -   5        $ txtObservedTime��5      $��NoWrap=�6-   $��10(�6C   $ 1.676,0.499&�6Q   $ 12��6u   $	 376��6�   Observed Time:6�   �� 5   
   -   5        $ txtPressure��5      $��NoWrap=�6)   $��20(�6?   $ 1.676,0.499&�6M   $ 26��6q   $	 159��6�   
Pressure6�   �� 5   
   -	   5         ��Name$ btnClose��5      $��60��6#   $	��200��6/   $��Close��6;   $	 561��6b   $	 346��6t   �� 5   
   -
   5        $ btnCTemp��5      $��60��6#   $	��200��6/   $��C��6;   $	 561��6^   $	 246��6p   �� 5   
   -   5        $ btnFTemp��5      $��60��6#   $	��200��6/   $��F��6;   $	 561��6^   $	 146��6p   5      5!      