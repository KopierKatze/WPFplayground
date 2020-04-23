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
        private Point dragStartMousePosition;
        private TaskControl draggedTask;
        private bool dragStarted = false;

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


        private void TODO_DragEnter(object sender, DragEventArgs e)
        {
            draggedTask = e.Data.GetData("DraggedTask") as TaskControl;

            Canvas canvas = FindName("Canvas") as Canvas;
            if (canvas != null && draggedTask != null)
            {
                dragStartMousePosition = e.GetPosition(canvas);
                e.Effects = DragDropEffects.Move;
                dragStarted = true;

                if (draggedTask != null && draggedTask.Parent != canvas)
                {
                    draggedTask.DetachFromParent();

                    canvas.Children.Add(draggedTask);

                    Canvas.SetLeft(draggedTask, dragStartMousePosition.X);
                    Canvas.SetTop(draggedTask, dragStartMousePosition.Y);
                    Console.WriteLine("TODO ENTER");
                }

            }
        }

        private void TODO_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && dragStarted)
            {
                if (draggedTask != null)
                {
                    Point mousePos = e.GetPosition(null);
                    Vector diff = dragStartMousePosition - mousePos;

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
            }
        }


        private void DockPanel_DragEnter(object sender, DragEventArgs e)
        {
            Canvas canvas = sender as Canvas;

            if (draggedTask != null)
            {
                Console.WriteLine("CANVAS ENTER");
                //draggedTask.DetachFromParent();
                //canvas.Children.Add(draggedTask);
                Canvas.SetLeft(draggedTask, e.GetPosition(canvas).X);
                Canvas.SetTop(draggedTask, e.GetPosition(canvas).Y);
                e.Effects = DragDropEffects.Move;
            }
            
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
                        Point mousePos = e.GetPosition(canvas);
                        Vector diff = dragStartMousePosition - mousePos;

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
                else
                    Console.WriteLine(sender.GetType());
            }
            
        }

        
    }
}
