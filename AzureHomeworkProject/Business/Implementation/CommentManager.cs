using AzureHomeworkProject.AI;
using AzureHomeworkProject.Business.Abstract;
using AzureHomeworkProject.Dtos;
using AzureHomeworkProject.Exceptions;
using AzureHomeworkProject.Helpers;
using AzureHomeworkProject.Models;
using AzureHomeworkProject.Repository.Abstract;

namespace AzureHomeworkProject.Business.Implementation
{
    public class CommentManager : ICommentService
    {
        private readonly ITextAnalyzer _textAnalyzer;
        private readonly ICommentRepository _commentRepository;
        public CommentManager(ITextAnalyzer textAnalyzer, ICommentRepository commentRepository)
        {
            _textAnalyzer = textAnalyzer;
            _commentRepository = commentRepository;
        }
        public async Task<DataResult<CommentDto>> CreateComment(CreateCommentDto comment)
        {
            try
            {
                var result = await _textAnalyzer.GetLanguageInformationsAsync(comment.Comment);
                CommentModel model = new CommentModel(comment.Name, comment.Comment, result.Name, result.ISOName);
                model = await _commentRepository.CreateComment(model);
                return new SuccessDataResult<CommentDto>((CommentDto)model);
            }
            catch (NotDetectedException)
            {
                return new ErrorDataResult<CommentDto>("We weren't be able to find the language for given text.");
            }
        }

        public async Task<DataResult<CommentDto>> GetComment(int id)
        {
            var result = await _commentRepository.GetComment(id);
            if (result is null)
            {
                return new ErrorDataResult<CommentDto>("There is no comment with given id.");
            }
            return new SuccessDataResult<CommentDto>((CommentDto)result);
        }

        public async Task<DataResult<CommentListDto>> GetComments()
        {
            var result = await _commentRepository.GetComments();
            return new SuccessDataResult<CommentListDto>(new(result.Select(x => (CommentDto)x).ToList()));
        }

        public async Task<DataResult<CommentListDto>> GetCommentsByLanguage(string iSOName)
        {
            var result = await _commentRepository.GetCommentsByLanguage(iSOName);
            return new SuccessDataResult<CommentListDto>(new(result.Select(x => (CommentDto)x).ToList()));
        }
    }
}
