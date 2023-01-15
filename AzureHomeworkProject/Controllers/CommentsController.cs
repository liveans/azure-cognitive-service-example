using AzureHomeworkProject.Business.Abstract;
using AzureHomeworkProject.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureHomeworkProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ILogger<CommentsController> _logger;
        private readonly ICommentService _commentService;

        public CommentsController(ILogger<CommentsController> logger, ICommentService commentService)
        {
            _logger = logger;
            _commentService = commentService;
        }

        [HttpGet]
        [ProducesDefaultResponseType(typeof(CommentListDto))]
        [ProducesErrorResponseType(typeof(GenericErrorDto))]
        public async Task<ActionResult<CommentListDto>> GetComments()
        {
            return Ok((await _commentService.GetComments())!.Data);
        }

        [HttpGet("list/{iSOName}")]
        [ProducesDefaultResponseType(typeof(CommentListDto))]
        [ProducesErrorResponseType(typeof(GenericErrorDto))]
        public async Task<ActionResult<CommentListDto>> GetComments(string iSOName)
        {
            return Ok((await _commentService.GetCommentsByLanguage(iSOName))!.Data);
        }

        [HttpGet("{id}")]
        [ProducesDefaultResponseType(typeof(CommentDto))]
        [ProducesErrorResponseType(typeof(GenericErrorDto))]
        public async Task<ActionResult<CommentDto>> GetComment(int id)
        {
            var result = await _commentService.GetComment(id);
            if (!result.Success)
            {
                return BadRequest(new GenericErrorDto(result.Message));
            }
            return Ok(result.Data!);
        }

        [HttpPost]
        public async Task<ActionResult<CommentDto>> CreateComment(CreateCommentDto commentDto)
        {
            var result = await _commentService.CreateComment(commentDto);
            if (!result.Success)
            {
                return BadRequest(new GenericErrorDto(result.Message));
            }
            return Ok(result.Data!);
        }
    }
}
