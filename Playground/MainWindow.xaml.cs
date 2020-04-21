using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            Console.WriteLine("ADD");
            StackPanel todoPanel = (StackPanel)FindName("TODO");
            if (todoPanel == null)
            {
                Console.WriteLine("Could not find todo panel");
                return;
            }
            Task templateTask = new Task();
            templateTask.Title = "new task";
            templateTask.Description = "add a description";
            templateTask.Assigned = false;
            templateTask.Assignee = "assign a user";
            templateTask.Priority = 0;
            templateTask.State = Task.taskState.TODO;

            StackPanel taskControl = TaskControlFactory.CreateTaskControl(templateTask);
            todoPanel.Children.Add(taskControl);
        }


        private void SpawnExampleTasks(List<Task> tasks)
        {
            StackPanel todoPanel = (StackPanel) FindName("TODO");
            if (todoPanel == null)
            {
                Console.WriteLine("Could not find todo panel");
                return;
            }
            foreach (Task t in tasks)
            {
                StackPanel taskControl = TaskControlFactory.CreateTaskControl(t);
                todoPanel.Children.Add(taskControl);
            }
        }
    }
}
