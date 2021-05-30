using System;
using System.Windows;

namespace PAIN_wpf.MVVM
{
    public class WindowService : IWindowService
    {
        public void Show(IViewModel viewModel)
        {
            Window window = new Window();

            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.Content = viewModel;
            window.Title = "WPF - Song Library";

            viewModel.Close = window.Close;
            window.Show();
        }

        public void ShowDialog(IViewModel viewModel)
        {
            Console.WriteLine("execute"); 
            Window window = new Window();

            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.Content = viewModel;
            window.Title = "Edit Song Data";
            viewModel.Close = window.Close;

            window.ShowDialog();
        }
    }
}
