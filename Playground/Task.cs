using System.ComponentModel;

namespace Playground
{
    class Task : INotifyPropertyChanged
    {
        private string title;
        private string description;
        private string assignee;
        private bool assigned = false;
        private int priority;

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

        public bool Assigned
        {
            get
            {
                return assigned;
            }
            set
            {
                assigned = value;
                OnPropertyChanged("assigned");
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
