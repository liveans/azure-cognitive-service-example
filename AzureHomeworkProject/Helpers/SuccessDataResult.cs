namespace AzureHomeworkProject.Helpers
{
    public class SuccessDataResult<T> : DataResult<T> where T : class, new()
    {
        public SuccessDataResult(T data, string message = "") : base(message, true, data) { }
    }
}
