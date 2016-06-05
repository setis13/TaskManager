using System;
using System.Data.Entity.Infrastructure;

namespace TaskManager.Data.Context {
    /// <summary>
    ///     TruckCall Database context interface
    /// </summary>
    public interface ITaskManagerDbContext : IDisposable {
        int SaveChanges();

        DbChangeTracker ChangeTracker { get; }
    }
}