using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using TaskManager.Common.Enums;
using TaskManager.View.ViewModels;

namespace TaskManager.View.Converters {
    class TaskToColorConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            switch (((TaskViewModel)value).Status) {
                case TaskStatus.Done:
                    return Brushes.GreenYellow;
                case TaskStatus.InProgress:
                    switch ((TaskImportant)((TaskViewModel)value).Important) {
                         case TaskImportant.I1:
                            return new SolidColorBrush(Color.FromRgb(255, 120, 120));
                        case TaskImportant.I2:
                            return new SolidColorBrush(Color.FromRgb(255, 90, 90));
                        case TaskImportant.I3:
                            return new SolidColorBrush(Color.FromRgb(255, 60, 60));
                        case TaskImportant.I4:
                            return new SolidColorBrush(Color.FromRgb(255, 30, 30));
                        case TaskImportant.I5:
                            return new SolidColorBrush(Color.FromRgb(255,0,0));
                        case TaskImportant.I0:
                        default:
                            return new SolidColorBrush(Color.FromRgb(255, 150, 150));
                    }
                case TaskStatus.NeedFeedback:
                    return Brushes.LightBlue;
                case TaskStatus.None:
                case TaskStatus.Rejected:
                default:
                    return Brushes.LightGray;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
