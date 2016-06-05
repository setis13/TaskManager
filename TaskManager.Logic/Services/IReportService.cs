using System;
using System.Collections.Generic;
using TaskManager.Logic.Dtos;

namespace TaskManager.Logic.Services {
    public interface IReportService : IService {
		IReadOnlyCollection<TaskDto> DayReport(DateTime dateTime);
    }
}
