using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzureHomeworkProject.Models
{
    public class CommentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Language { get; set; }
        public string ISOName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public CommentModel(string name, string comment, string language, string iSOName)
        {
            Name = name;
            Comment = comment;
            Language = language;
            ISOName = iSOName;
        }
    }
}
