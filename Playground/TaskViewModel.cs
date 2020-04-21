using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Playground
{
    class TaskViewModel
    {
        private List<Task> tasks;
        private ICommand updateCommand;

        public TaskViewModel()
        {
            tasks = new List<Task>()
            {
                new Task{Title = "awesome task", Description = "very first task in list", Assigned = false, Assignee = "me", Priority = 0, State = Task.taskState.TODO},
                new Task{Title = "next in line", Description = "is this", Assigned = false, Assignee = "sloth", Priority = 0, State = Task.taskState.TODO},
                new Task{Title = "yaat", Description = "yet another awesome task", Assigned = false, Assignee = "panda", Priority = 3, State = Task.taskState.TODO},
                new Task{Title = "whopeee", Description = "going fast", Assigned = false, Assignee = "turtle", Priority = 5, State = Task.taskState.TODO},
                new Task{Title = "bogus task", Description = "getting hungry", Assigned = false, Assignee = "rabbit", Priority = 1, State = Task.taskState.TODO},
                new Task{Title = "one more", Description = "penultimate task", Assigned = false, Assignee = "lama", Priority = -1, State = Task.taskState.TODO},
                new Task{Title = "last task", Description = "to be done at the very end", Assigned = false, Assignee = "alpaka", Priority = 10, State = Task.taskState.TODO}
            };
        }

        public List<Task> Tasks
        {
            get
            {
                return tasks;
            }
            set
            {
                tasks = value;
            }
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
