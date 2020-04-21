using System.Windows.Controls;
using System.Windows.Documents;
using System;

namespace Playground
{
    class TaskControlFactory
    {
        public static Control CreateTaskControl(Task task)
        {
            Control taskControl = new TaskControl();

            RichTextBox titleBox = (RichTextBox)taskControl.FindName("Title");
            RichTextBox descriptionBox = (RichTextBox)taskControl.FindName("Description");
            RichTextBox assigneeBox = (RichTextBox)taskControl.FindName("Assignee");

            if (titleBox != null)
            {
                titleBox.Document.Blocks.Clear();
                titleBox.Document.Blocks.Add(new Paragraph(new Run(task.Title)));
            }
            if (descriptionBox != null)
            {
                descriptionBox.Document.Blocks.Clear();
                descriptionBox.Document.Blocks.Add(new Paragraph(new Run(task.Description)));
            }
            if (assigneeBox != null)
            {
                assigneeBox.Document.Blocks.Clear();
                assigneeBox.Document.Blocks.Add(new Paragraph(new Run(task.Assignee)));
            }

            return taskControl;
        }
    }
}
