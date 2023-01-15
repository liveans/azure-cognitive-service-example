using AzureHomeworkProject.Models;

namespace AzureHomeworkProject.Repository.Abstract
{
    public interface ICommentRepository
    {
        Task<CommentModel> CreateComment(CommentModel comment);
        Task<CommentModel?> GetComment(int commentId);
        Task<List<CommentModel>> GetComments();
    }
}
