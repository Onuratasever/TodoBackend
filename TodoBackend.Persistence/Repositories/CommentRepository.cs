using TodoBackend.Domain.Entities.Comment;

namespace TodoBackend.Persistence.Repositories;

public class CommentRepository: Repository<Comment>, ICommentRepository
{
    public CommentRepository(ApplicationDbContext context) : base(context)
    {
    }
}