namespace AzureHomeworkProject.Dtos
{
    public class CreateCommentDto
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public CreateCommentDto() { }
        public CreateCommentDto(string name, string comment)
        {
            Name = name;
            Comment = comment;
        }
    }
}
