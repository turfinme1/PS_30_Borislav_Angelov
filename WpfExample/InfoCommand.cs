﻿using System;
using System.Windows;
using System.Windows.Input;

namespace WpfExample
{
    public class InfoCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            MessageBox.Show("Hello, world!");
            NamesWindow namesWindow = new NamesWindow();
            namesWindow.Show();
        }
    }
}
