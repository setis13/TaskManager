using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Data.Entities {
    /// <summary>
    ///     Base entity implementation
    /// </summary>
    public class BaseEntity {

        /// <summary>
        ///     Creates a new entity instance
        /// </summary>
        public BaseEntity() {
            EntityId = Guid.NewGuid();
        }

        /// <summary>
        ///     Entity PK
        /// </summary>
        [Key]
        public Guid EntityId { get; set; }

        /// <summary>
        ///     First time creation date
        /// </summary>
        [Required]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        ///     Last modified date
        /// </summary>
        [Required]
        public DateTime LastModifiedDate { get; set; }

        /// <summary>
        ///     Marked as deleted
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; }
    }
}