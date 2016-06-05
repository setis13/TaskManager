using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TaskManager.Logic.Dtos;

namespace TaskManager.View.ViewModels {
    public class BaseViewModel : INotifyPropertyChanged {

		/// <summary>
		/// On property changed handler
		/// </summary>
		/// <param name="propertyName">Changed property name</param>
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
			// Raise event
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		/// <summary>
		/// Occurs when property has been changed
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		public BaseViewModel() {
        }

        /// <summary>
        ///     .ctor
        /// </summary>
        /// <param name="dto"></param>
        public BaseViewModel(BaseDto dto) {
            EntityId = dto.EntityId;
            CreatedDate = dto.CreatedDate;
            LastModifiedDate = dto.LastModifiedDate;
            IsDeleted = dto.IsDeleted;
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
