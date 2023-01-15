namespace AzureHomeworkProject.Dtos
{
    public class GenericErrorDto
    {
        public string Message { get; set; }
        public List<string> ExtraInformations { get; set; } = new List<string>();

        public GenericErrorDto() { }
        public GenericErrorDto(string message) { Message = message; }
        public GenericErrorDto(string message, List<string> extraInformations)
        {
            Message = message;
            ExtraInformations = extraInformations;
        }
    }
}
