using System.Windows;
using TaskManager.Logic;

namespace TaskManager.View {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        public App() {
            Bootstrapper.Initialize();
        }
    }
}
