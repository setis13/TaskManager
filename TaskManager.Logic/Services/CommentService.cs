using TaskManager.Data;
using TaskManager.Data.Entities;
using TaskManager.Logic.Dtos;

namespace TaskManager.Logic.Services {

    public class CommentService : EntityCrudService<ICommentService, CommentDto, Comment>, ICommentService {

        #region [ .ctor ]

        public CommentService(IServicesHost servicesHost, IUnitOfWork unitOfWork)
            : base(servicesHost, unitOfWork) {
        }

        #endregion [ .ctor ]

        public void SaveComment(CommentDto task) {
            this.Save(task);
        }
    }
}
