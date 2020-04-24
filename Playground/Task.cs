using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Playground
{
    public class Task
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


        //public Task()
        //{
        //    Task t = new Task { Title = "title", Description = "description", Assignee = "assignee", Priority = 0, State = taskState.TODO };
        //}

        public static List<Task> ReturnExampleTasks()
        {
            return new List<Task>()
            {
                new Task{Title = "awesome task", Description = "very first task in list", Assignee = "me", Priority = 0, State = taskState.TODO},
                new Task{Title = "next in line", Description = "is this", Assignee = "sloth", Priority = 0, State = taskState.TODO},
                new Task{Title = "yaat", Description = "yet another awesome task", Assignee = "panda", Priority = 3, State = taskState.TODO},
                new Task{Title = "whopeee", Description = "going fast", Assignee = "turtle", Priority = 5, State = taskState.TODO},
                new Task{Title = "bogus task", Description = "getting hungry", Assignee = "rabbit", Priority = 1, State = taskState.TODO},
                new Task{Title = "one more", Description = "penultimate task", Assignee = "lama", Priority = -1, State = taskState.TODO},
                new Task{Title = "last task", Description = "to be done at the very end", Assignee = "alpaka", Priority = 10, State = taskState.TODO}
            };
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
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
              
    }
}
