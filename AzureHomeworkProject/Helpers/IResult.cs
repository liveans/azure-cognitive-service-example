namespace AzureHomeworkProject.Helpers
{
    public interface IResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
