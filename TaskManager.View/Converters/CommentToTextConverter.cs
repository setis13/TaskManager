using System;
using System.Globalization;
using System.Windows.Data;
using TaskManager.View.ViewModels;

namespace TaskManager.View.Converters {
    public class CommentToTextConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var comment = (CommentViewModel)value;
            return String.Format("{0:d}: {1}", comment.CreatedDate, comment.Text);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
