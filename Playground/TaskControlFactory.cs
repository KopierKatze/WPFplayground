using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Playground
{
    class TaskControlFactory
    {
        public static StackPanel CreateTaskControl(Task task)
        {
            /*
             * private string title;
                private string description;
                private string assignee;
                private bool assigned = false;
                private int priority;
            */
            StackPanel taskControl = new StackPanel();
            SolidColorBrush backgroundBrush = new SolidColorBrush();
            backgroundBrush.Color = Colors.Gray;
            taskControl.Background = backgroundBrush;


            Grid grid = new Grid();
            ColumnDefinition cd = new ColumnDefinition();
            cd.MinWidth = 45;
            grid.ColumnDefinitions.Add(cd);
            RowDefinition titleRow = new RowDefinition();
            titleRow.MinHeight = 5;
            grid.RowDefinitions.Add(titleRow);
            RowDefinition descriptionRow = new RowDefinition();
            descriptionRow.MinHeight = 5;
            grid.RowDefinitions.Add(descriptionRow);
            RowDefinition assigneeRow = new RowDefinition();
            assigneeRow.MinHeight = 5;
            grid.RowDefinitions.Add(assigneeRow);
            RowDefinition assignedRow = new RowDefinition();
            assignedRow.MinHeight = 5;
            grid.RowDefinitions.Add(assignedRow);

            Label titleLabel = new Label();
            titleLabel.Content = task.Title;
            Label descriptionLabel = new Label();
            descriptionLabel.Content = task.Description;
            Label assigneeLabel = new Label();
            assigneeLabel.Content = task.Assignee;
            RadioButton assignedBtn = new RadioButton();

            Grid.SetRow(titleLabel, 0);
            Grid.SetRow(titleLabel, 0);
            grid.Children.Add(titleLabel);

            Grid.SetRow(descriptionLabel, 0);
            Grid.SetRow(descriptionLabel, 1);
            grid.Children.Add(descriptionLabel);

            Grid.SetRow(assigneeLabel, 0);
            Grid.SetRow(assigneeLabel, 2);
            grid.Children.Add(assigneeLabel);

            Grid.SetRow(assignedBtn, 0);
            Grid.SetRow(assignedBtn, 3);
            grid.Children.Add(assignedBtn);


            taskControl.Children.Add(grid);

            return taskControl;
        }
    }
}
