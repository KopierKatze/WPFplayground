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
    /// Interaction logic for Task.xaml
    /// </summary>
    public partial class TaskControl : UserControl
    {
        public Task task;
        private bool isInEditMode = false;
        StackPanel parentPanel;
        Point dragStartMousePosition;
        Point dragStartCtrlPosition;


        public TaskControl(Task newTask)
        {
            InitializeComponent();
            task = newTask;
            parentPanel = this.Parent as StackPanel;
        }

        public void OnTaskControlClicked(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Clicked");
            if (task.EditEnabled)
            {
                isInEditMode = true;
                OpenTaskEditMode();
            }
            else
            {
                // TODO user feedback? 
            }
        }

        private void OpenTaskEditMode()
        {
            SetUIElementsEnabled(isInEditMode);
        }

        private void SetUIElementsEnabled(bool newValue)
        {
            RichTextBox titleBox = (RichTextBox)FindName("Title");
            RichTextBox descriptionBox = (RichTextBox)FindName("Description");
            RichTextBox assigneeBox = (RichTextBox)FindName("Assignee");

            if (titleBox != null)
            {
                titleBox.IsReadOnly = !newValue;
            }

            if (descriptionBox != null)
            {
                descriptionBox.IsReadOnly = !newValue;
            }

            if (assigneeBox != null)
            {
                assigneeBox.IsReadOnly = !newValue;
            }
        }


        private void TaskMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {

                Point mousePos = e.GetPosition(null);
                Vector diff = dragStartMousePosition - mousePos;

                if (e.LeftButton == MouseButtonState.Pressed &&
                    Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                    Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    Border taskPanel = sender as Border;

                    if (parentPanel == null)
                    {
                        parentPanel = this.Parent as StackPanel;
                    }

                    //taskPanel.RenderTransform. = e.GetPosition(parentPanel);

                    DataObject dataObject = new DataObject();
                    dataObject.SetData("DraggedTask", this);
                    DragDrop.DoDragDrop(sender as Border, dataObject, DragDropEffects.Move);
                }
            }
        }


        private void TaskPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border taskPanel = sender as Border;

            if (parentPanel == null)
            {
                parentPanel = Parent as StackPanel;
            }

            dragStartMousePosition = e.GetPosition(Application.Current.Windows[0]);
            dragStartCtrlPosition = taskPanel.RenderTransformOrigin;
        }


        public void RemoveFromOtherPanel()
        {
            if (parentPanel == null)
            {
                parentPanel = Parent as StackPanel;
            }

            parentPanel.Children.Remove(this);
        }
    }
}
