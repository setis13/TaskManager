using TaskManager.Logic.Dtos;

namespace TaskManager.Logic.Services {
    public interface ICommentService : ICrudService<CommentDto> {
        void SaveComment(CommentDto comment);
    }
}
