namespace AzureHomeworkProject.Helpers
{
    public class DataResult<T> : IDataResult<T> where T : class, new()
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public T? Data { get; set; }

        public DataResult(string message, bool success, T data)
        {
            Message = message;
            Success = success;
            Data = data;
        }
        public DataResult(string message, bool success)
        {
            Message = message;
            Success = success;
        }
    }
}
