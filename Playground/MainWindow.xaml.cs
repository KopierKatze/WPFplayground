using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace Playground
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TaskViewModel taskViewModel;

        public MainWindow()
        {
            InitializeComponent();
            taskViewModel = new TaskViewModel();

            SpawnExampleTasks(taskViewModel.Tasks);
        }


        private void OnAddNewTODO(object sender, RoutedEventArgs e)
        {
            StackPanel todoPanel = (StackPanel)FindName("TODO");
            if (todoPanel == null)
            {
                return;
            }
            Task templateTask = new Task();
            templateTask.Title = "new task";
            templateTask.Description = "add a description";
            templateTask.Assignee = "assign a user";
            templateTask.Priority = 0;
            templateTask.State = Task.taskState.TODO;

            Control taskControl = TaskControlFactory.CreateTaskControl(templateTask);
            todoPanel.Children.Add(taskControl);

            ScrollDown();
        }


        private void SpawnExampleTasks(List<Task> tasks)
        {
            StackPanel todoPanel = (StackPanel) FindName("TODO");
            if (todoPanel == null)
            {
                return;
            }
            foreach (Task t in tasks)
            {
                Control taskControl = TaskControlFactory.CreateTaskControl(t);
                todoPanel.Children.Add(taskControl);
            }

            ScrollDown();
        }

        private void ScrollDown()
        {
            ScrollViewer scrollView = (ScrollViewer)FindName("ScrollView");
            if (scrollView == null)
            {
                return;
            }

            scrollView.ScrollToBottom();
        }
    }
}
