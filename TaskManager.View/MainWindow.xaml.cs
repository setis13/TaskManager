using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.ServiceLocation;
using TaskManager.Common.Enums;
using TaskManager.View.Dialogs;
using TaskManager.View.ViewModels;

namespace TaskManager.View {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {

		public MainViewModel ViewModel { get { return DataContext as MainViewModel; } }

		public MainWindow() {
			Initialize();

			InitializeComponent();
		}

		private void Initialize() {
			DataContext = ServiceLocator.Current.GetInstance<MainViewModel>();
		}

		private void Load() {
			ViewModel.LoadTasks();
		}

		private void CreateTaskClicked(object sender, RoutedEventArgs e) {
			var dialog = ServiceLocator.Current.GetInstance<TaskDialog>();
			dialog.DataContext = new TaskViewModel();
			if (dialog.ShowDialog() == true) {
				Load();
			}
		}

		private void OnEditClicked(object sender, RoutedEventArgs e) {
			var dialog = ServiceLocator.Current.GetInstance<TaskDialog>();
			dialog.DataContext = ((FrameworkElement)sender).DataContext;
			if (dialog.ShowDialog() == true) {
				Load();
			}
		}

		private void OnCommentClicked(object sender, RoutedEventArgs e) {
			var dialog = ServiceLocator.Current.GetInstance<CommentDialog>();
			dialog.DataContext = new WrapCommentViewModel((TaskViewModel)((FrameworkElement)sender).DataContext);
			if (dialog.ShowDialog() == true) {
				Load();
			}
		}

		private void DayReportClicked(object sender, RoutedEventArgs e) {
			var window = new DayReportWindow();
			window.ShowDialog();
		}

		private void TotalReportClicked(object sender, RoutedEventArgs e) {
		}
	}
}
