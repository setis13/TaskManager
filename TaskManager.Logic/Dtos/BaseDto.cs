using System;

namespace TaskManager.Logic.Dtos {

    /// <summary>
    /// Base DTO
    /// </summary>
    public class BaseDto {
        /// <summary>
        ///     .ctor
        /// </summary>
        public BaseDto() {
            EntityId = Guid.NewGuid();
        }
        /// <summary>
        ///     Entity PK
        /// </summary>
        public Guid EntityId { get; set; }
        /// <summary>
        ///     First time creation date
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        ///     Last modified date
        /// </summary>
        public DateTime LastModifiedDate { get; set; }
        /// <summary>
        ///     Marked as deleted
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}