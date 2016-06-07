using System;
using System.Windows;
using TaskManager.Common.Enums;
using TaskManager.Logic.Dtos;
using TaskManager.Logic.Services;
using TaskManager.View.ViewModels;

namespace TaskManager.View.Dialogs {
    /// <summary>
    /// Interaction logic for CommentDialog.xaml
    /// </summary>
    public partial class CommentDialog : Window {
        public WrapCommentViewModel ViewModel { get { return DataContext as WrapCommentViewModel; } }

        private ICommentService _service;

        public CommentDialog(ICommentService service) {
            InitializeComponent();

            _service = service;


        }

        private void OkClicked(object sender, RoutedEventArgs e) {
            _service.SaveComment(new CommentDto() {
                CreatedDate = ViewModel.CommentViewModel.CreatedDate,
                Date = ViewModel.CommentViewModel.Date,
                Hours = ViewModel.CommentViewModel.Hours,
                EntityId = ViewModel.CommentViewModel.EntityId,
                IsDeleted = ViewModel.CommentViewModel.IsDeleted,
                LastModifiedDate = ViewModel.CommentViewModel.LastModifiedDate,
                Progress = ViewModel.CommentViewModel.Progress,
                TaskId = ViewModel.CommentViewModel.TaskId,
                Text = ViewModel.CommentViewModel.Text,
                Status = (byte)ViewModel.CommentViewModel.Status
            });
			DialogResult = true;
		}

        private void CancelClicked(object sender, RoutedEventArgs e) {
            Close();
			DialogResult = false;
		}
    }
}
