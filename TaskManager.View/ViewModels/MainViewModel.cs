using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using TaskManager.Common.Enums;
using TaskManager.Logic.Services;

namespace TaskManager.View.ViewModels {
    public class MainViewModel : BaseViewModel {
	    public List<TaskViewModel> Tasks {
		    get { return _tasks; }
		    set {
			    _tasks = value;
			    OnPropertyChanged();
		    }
	    }

	    public bool InProgressFlag {
		    get { return _inProgressFlag; }
		    set {
			    if (_inProgressFlag != value) {
				    _inProgressFlag = value;
					OnPropertyChanged();
				    LoadTasks();
			    }
		    }
	    }

	    public bool DoneFlag {
		    get { return _doneFlag; }
		    set {
				if (_doneFlag != value) {
					_doneFlag = value;
					OnPropertyChanged();
					LoadTasks();
				}

			}
	    }

	    private ITaskService _taskService;
	    private List<TaskViewModel> _tasks;
	    private bool _inProgressFlag = true;
	    private bool _doneFlag;

	    public MainViewModel(ITaskService taskService) {

			_taskService = taskService;

            Tasks = new List<TaskViewModel>();

		    LoadTasks();
	    }

        public void LoadTasks() {
            var tasks = _taskService.GetTasks(InProgressFlag, DoneFlag);
	        Tasks = null;
			Tasks = tasks.Select(t => new TaskViewModel(t)).ToList();
        }
    }
}
