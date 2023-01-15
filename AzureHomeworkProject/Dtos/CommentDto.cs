using AzureHomeworkProject.Models;

namespace AzureHomeworkProject.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Language { get; set; }
        public string ISOName { get; set; }
        public DateTime CreatedAt { get; set; }

        public CommentDto() { }
        public CommentDto(int id,string name, string comment, string language, string iSOName, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Comment = comment;
            Language = language;
            ISOName = iSOName;
            CreatedAt = createdAt;
        }

        public static explicit operator CommentDto(CommentModel model)
        {
            return new CommentDto(model.Id, model.Name, model.Comment, model.Language, model.ISOName, model.CreatedAt);
        }
    }
}
