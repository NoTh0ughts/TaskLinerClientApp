using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace TaskLinerClientApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowDrag(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            switch (Application.Current.MainWindow.WindowState)
            {
                case WindowState.Normal:
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
                    break;
                case WindowState.Maximized:
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                    break;
                default:
                    break;
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            tt_home.Visibility = Tg_NavBar.IsChecked == true ? Visibility.Collapsed : Visibility.Visible;
        }

        private void StackPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_NavBar.IsChecked = false;
        }

        private void Header_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
}
