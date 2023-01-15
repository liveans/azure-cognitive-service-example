namespace AzureHomeworkProject.Helpers
{
    public class Result : IResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }

        public Result() { }
        public Result(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
