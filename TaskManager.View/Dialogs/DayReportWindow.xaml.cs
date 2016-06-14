using System;
using System.Linq;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using TaskManager.Common.Enums;
using TaskManager.Logic.Services;

namespace TaskManager.View.Dialogs {
    /// <summary>
    /// Interaction logic for DayReportWindow.xaml
    /// </summary>
    public partial class DayReportWindow : Window {
        public DayReportWindow() {
            InitializeComponent();
        }

        private void CreateReportClicked(object sender, RoutedEventArgs e) {
            if (datePicker1.SelectedDate == null) {
                MessageBox.Show("Please select date");
                return;
            }
            if (datePicker2.SelectedDate == null) {
                MessageBox.Show("Please select date");
                return;
            }
            var service = ServiceLocator.Current.GetInstance<IReportService>();
            var result = service.DayReport((DateTime)datePicker1.SelectedDate, (DateTime)datePicker2.SelectedDate);

            var text = String.Empty;
            double hours = 0;
            foreach (var taskDto in result) {
                var task = String.Empty;
                var comments = String.Empty;
                // name
                task = $"> {taskDto.Name}";
                // status
                var lastComment = taskDto.Comments.Last();
                if (lastComment.Hours <= 0) {
                    continue;
                }
                switch ((TaskStatus)lastComment.Status) {
                    case TaskStatus.InProgress:
                        if (lastComment.Progress != 0) {
                            task += $" ({lastComment.Progress}%)";
                        } else {
                            task += " (in progress)";
                        }
                        break;
                    case TaskStatus.Rejected:
                        task += " (rejected)";
                        break;
                    case TaskStatus.NeedFeedback:
                        task += " (need feedback)";
                        break;
                    case TaskStatus.Done:
                        task += " (done)";
                        break;
                    default:
                        task += " (unknown)";
                        break;
                }

                if (cbHasComments.IsChecked == true) {
                    double task_hours = 0;
                    // comments
                    foreach (var commentDto in taskDto.Comments) {
                        task_hours += commentDto.Hours;
                        hours += commentDto.Hours;
                        if (String.IsNullOrEmpty(commentDto.Text) == false) {
                            comments += $"  > {commentDto.Text.Replace("\n", "\n  > ")}";
                        }
                    }
                    text += task + $" ({task_hours}h)" + "\n" + comments + "\n";
                } else {
                    double task_hours = 0;
                    // tasks
                    foreach (var commentDto in taskDto.Comments) {
                        task_hours += commentDto.Hours;
                        hours += commentDto.Hours;
                    }
                    text += task + $" ({task_hours}h)" + "\n";
                }
            }
            if (datePicker1.SelectedDate == datePicker2.SelectedDate) {
                textBox.Text = $"{datePicker1.SelectedDate:d} ({hours:F1}h)\n" + text;
            } else {
                textBox.Text = $"{datePicker1.SelectedDate:d} - {datePicker2.SelectedDate:d} ({hours:F1}h)\n" + text;
            }
        }
    }
}
