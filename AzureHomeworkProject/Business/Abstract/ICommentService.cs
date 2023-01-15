using AzureHomeworkProject.Dtos;
using AzureHomeworkProject.Helpers;

namespace AzureHomeworkProject.Business.Abstract
{
    public interface ICommentService
    {
        Task<DataResult<CommentDto>> GetComment(int id);
        Task<DataResult<CommentListDto>> GetComments();
        Task<DataResult<CommentDto>> CreateComment(CreateCommentDto comment);
    }
}
