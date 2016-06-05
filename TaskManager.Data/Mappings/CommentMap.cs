using TaskManager.Data.Entities;

namespace TaskManager.Data.Mappings {
    internal class CommentMap : BaseEntityMap<Comment> {
        public CommentMap() {
            this.ToTable("Comment");
        }
    }
}
