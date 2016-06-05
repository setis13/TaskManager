using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using TaskManager.View.ViewModels;

namespace TaskManager.View.Converters {
	public class TaskToHoursConverter : IValueConverter {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			return String.Format("{0}h/{1}h", ((TaskViewModel)value).Hours, ((TaskViewModel)value).Comments.Sum(c => c.Hours));
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			throw new NotImplementedException();
		}
	}
}
