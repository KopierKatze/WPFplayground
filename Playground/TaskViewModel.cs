using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Playground
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        private ICommand updateCommand;

        public Task Task { get; set; }

        public string Title
        {
            get
            {
                return Task.Title;
            }
            set
            {
                Task.Title = value;
                OnPropertyChanged("title");
            }
        }

        public string Description
        {
            get
            {
                return Task.Description;
            }
            set
            {
                Task.Description = value;
                OnPropertyChanged("description");
            }
        }

        public string Assignee
        {
            get
            {
                return Task.Assignee;
            }
            set
            {
                Task.Assignee = value;
                OnPropertyChanged("assignee");
            }
        }

        public int Priority
        {
            get
            {
                return Task.Priority;
            }
            set
            {
                Task.Priority = value;
                OnPropertyChanged("priority");
            }
        }

        public Task.taskState State
        {
            get
            {
                return Task.State;
            }
            set
            {
                Task.State = value;
                OnPropertyChanged("state");
            }
        }

        public bool EditEnabled
        {
            get
            {
                return Task.EditEnabled;
            }
            private set
            {
                Task.SetEditEnabledFlag(value);
            }
        }

        public void SetEditEnabledFlag(bool newValue)
        {
            // TODO check permissions (assignee)
            EditEnabled = newValue;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                    updateCommand = new Updater();
                return updateCommand;
            }
            set
            {
                updateCommand = value;
            }
        }

        private class Updater : ICommand
        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {

            }
        }
    }
}
