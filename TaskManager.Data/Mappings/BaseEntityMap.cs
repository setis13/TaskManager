using System.Data.Entity.ModelConfiguration;
using TaskManager.Data.Entities;

namespace TaskManager.Data.Mappings {
    /// <summary>
    ///     Base entities mapping
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    internal class BaseEntityMap<T> : EntityTypeConfiguration<T> where T : BaseEntity {
        /// <summary>
        ///     Create map instance
        /// </summary>
        public BaseEntityMap() {
        }
    }
}