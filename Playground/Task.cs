using System.ComponentModel;

namespace Playground
{
    public class Task : INotifyPropertyChanged
    {
        private string title;
        private string description;
        private string assignee;
        private int priority;

        // Enabled by default until user permissions can be checked.
        private bool editEnabled = true;

        public enum taskState
        {
            TODO, IN_PROGRESS, IN_REVIEW, DONE
        }
        private taskState state;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged("title");
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged("description");
            }
        }

        public string Assignee
        {
            get
            {
                return assignee;
            }
            set
            {
                assignee = value;
                OnPropertyChanged("assignee");
            }
        }

        public int Priority
        {
            get
            {
                return priority;
            }
            set
            {
                priority = value;
                OnPropertyChanged("priority");
            }
        }

        public taskState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                OnPropertyChanged("state");
            }
        }

        public bool EditEnabled
        {
            get
            {
                return editEnabled;
            }
            private set
            {
                editEnabled = value;
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
    }
}
