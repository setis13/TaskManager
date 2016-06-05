using System.Windows;
using TaskManager.Logic.Dtos;
using TaskManager.Logic.Services;
using TaskManager.View.ViewModels;

namespace TaskManager.View.Dialogs {
    /// <summary>
    /// Interaction logic for TaskDialog.xaml
    /// </summary>
    public partial class TaskDialog : Window {
        public TaskViewModel ViewModel { get { return DataContext as TaskViewModel; } }

        private ITaskService _service;

        public TaskDialog(ITaskService service) {
            InitializeComponent();

            _service = service;
        }

        private void OkClicked(object sender, RoutedEventArgs e) {
            _service.SaveTask(new TaskDto() {
                CreatedDate = ViewModel.CreatedDate,
                Hours = ViewModel.Hours,
                EntityId = ViewModel.EntityId,
                IsDeleted = ViewModel.IsDeleted,
                LastModifiedDate = ViewModel.LastModifiedDate,
                Description = ViewModel.Description,
                Important = ViewModel.Important,
                Name = ViewModel.Name
            });
	        DialogResult = true;
        }

        private void CancelClicked(object sender, RoutedEventArgs e) {
			DialogResult = false;
		}
    }
}
