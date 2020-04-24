using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Playground
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TaskViewModel taskViewModel;
        private TaskControl draggedTask;
        private bool dragStarted = false;
        private bool dragEnteredCanvas = false;
        private Point touchPointInTask;

        public MainWindow()
        {
            InitializeComponent();

            taskViewModel = new TaskViewModel();
            base.DataContext = taskViewModel;

            SpawnExampleTasks(Task.ReturnExampleTasks());
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


        private void TODO_DragEnter(object sender, DragEventArgs e)
        {
            /*
            draggedTask = e.Data.GetData("DraggedTask") as TaskControl;

            Canvas canvas = FindName("Canvas") as Canvas;
            if (canvas != null && draggedTask != null)
            {
                Point mousePos = e.GetPosition(canvas);
                e.Effects = DragDropEffects.Move;
                dragStarted = true;

                if (draggedTask != null && draggedTask.Parent != canvas)
                {
                    draggedTask.DetachFromParent();

                    canvas.Children.Add(draggedTask);

                    Canvas.SetLeft(draggedTask, mousePos.X);
                    Canvas.SetTop(draggedTask, mousePos.Y);
                    Console.WriteLine("TODO ENTER");
                }

            }
            */
        }

        private void TODO_MouseMove(object sender, MouseEventArgs e)
        {
            /*
            if (e.LeftButton == MouseButtonState.Pressed && dragStarted)
            {
                if (draggedTask != null)
                {
                    Point mousePos = e.GetPosition(null);
                    Vector diff = mousePos - mousePos;

                    if (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                        Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)
                    {
                        Console.WriteLine("MOOOOOVE");
                        //DataObject dataObject = new DataObject();
                        //dataObject.SetData("DraggedTask", draggedTask);
                        //DragDrop.DoDragDrop(sender as Canvas, dataObject, DragDropEffects.Move);
                        Canvas.SetLeft(draggedTask, mousePos.X);
                        Canvas.SetTop(draggedTask, mousePos.Y);
                    }
                }
                else
                {
                    Console.WriteLine("draggedtask null");
                    Console.WriteLine(e.OriginalSource.GetType());
                }
            }
            */
        }

        private void TODO_Drop(object sender, DragEventArgs e)
        {
            StackPanel todoPanel = sender as StackPanel;

            TaskControl draggedTask = e.Data.GetData("DraggedTask") as TaskControl;
            if (draggedTask != null)
            {
                draggedTask.DetachFromParent();
                todoPanel.Children.Add(draggedTask);
                draggedTask = null;
                dragEnteredCanvas = false;
                dragStarted = false;
            }
        }


        private void InProgress_Drop(object sender, DragEventArgs e)
        {
            StackPanel progressPanel = sender as StackPanel;

            TaskControl draggedTask = e.Data.GetData("DraggedTask") as TaskControl;
            if (draggedTask != null)
            {
                draggedTask.DetachFromParent();
                progressPanel.Children.Add(draggedTask);
                draggedTask = null;
                dragEnteredCanvas = false;
                dragStarted = false;
            }
        }


        private void DockPanel_DragEnter(object sender, DragEventArgs e)
        {
            //draggedTask = e.Data.GetData("DraggedTask") as TaskControl;
            //touchPointInTask = (Point) e.Data.GetData("TouchPos");
            //Canvas canvas = sender as Canvas;

            //if (draggedTask != null && canvas != null 
            //    && !dragEnteredCanvas && !dragStarted)
            //{
            //    dragStarted = true;
            //    Point mousePos = e.GetPosition(Application.Current.Windows[0]/*canvas*/);
            //    draggedTask.DetachFromParent();
            //    canvas.Children.Add(draggedTask);

            //    Point diff = new Point(mousePos.X - touchPointInTask.X,
            //        mousePos.Y - touchPointInTask.Y);

            //    Console.WriteLine("CANVAS ENTER " + diff.ToString() + " " + mousePos.ToString());
            //    Canvas.SetLeft(draggedTask, diff.X);
            //    Canvas.SetTop(draggedTask, diff.Y);
            //    e.Effects = DragDropEffects.Move;
            //    dragEnteredCanvas = true;
            //}
        }

        private void Dock_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (e.LeftButton == MouseButtonState.Pressed && dragStarted)
            {
                Canvas canvas = sender as Canvas;
                if (canvas != null)
                {
                    if (draggedTask != null)
                    {
                        Point mousePos = e.GetPosition(Application.Current.Windows[0]);
                        mousePos = new Point(mousePos.X - touchPointInTask.X, mousePos.Y - touchPointInTask.Y);
                        Console.WriteLine("Move " + mousePos.ToString());
                        //Vector diff = dragStartMousePosition - mousePos;

                        //if (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                        //    Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)
                        //{
                        //DataObject dataObject = new DataObject();
                        //dataObject.SetData("DraggedTask", draggedTask);
                        //DragDrop.DoDragDrop(sender as Canvas, dataObject, DragDropEffects.Move);
                        Canvas.SetLeft(draggedTask, mousePos.X);
                        Canvas.SetTop(draggedTask, mousePos.Y);
                        //}
                    }
                    else
                    {
                        Console.WriteLine("draggedtask null");
                        Console.WriteLine(e.OriginalSource.GetType());
                    }
                }
                else
                    Console.WriteLine(sender.GetType());
            }
        }
    }
}
