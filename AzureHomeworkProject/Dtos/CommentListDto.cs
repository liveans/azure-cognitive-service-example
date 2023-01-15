namespace AzureHomeworkProject.Dtos
{
    public class CommentListDto
    {
        public List<CommentDto> Comments { get; set; }
        public CommentListDto() { }
        public CommentListDto(List<CommentDto> comments)
        {
            Comments = comments;
        }
    }
}
