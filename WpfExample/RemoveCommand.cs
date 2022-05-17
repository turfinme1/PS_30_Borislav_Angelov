using System;
using System.Windows.Input;

namespace WpfExample
{
    public class RemoveCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            NamesList? nameList = parameter as NamesList;
            return nameList != null && nameList.SelectedName != null;
        }

        public void Execute(object? parameter)
        {
            NamesList? nameList = parameter as NamesList;
            string oldName = nameList.SelectedName;
            nameList.Names.Remove(oldName);
        }
    }
}
