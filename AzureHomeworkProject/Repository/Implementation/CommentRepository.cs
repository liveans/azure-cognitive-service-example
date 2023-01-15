using AzureHomeworkProject.Models;
using AzureHomeworkProject.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace AzureHomeworkProject.Repository.Implementation
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;
        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CommentModel> CreateComment(CommentModel comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public Task<CommentModel?> GetComment(int commentId)
        {
            return _context.Comments.Where(x => x.Id == commentId).SingleOrDefaultAsync();
        }

        public Task<List<CommentModel>> GetComments()
        {
            return _context.Comments.ToListAsync();
        }

        public Task<List<CommentModel>> GetCommentsByLanguage(string iSOName)
        {
            return _context.Comments.Where(x => x.ISOName == iSOName).ToListAsync();
        }
    }
}
