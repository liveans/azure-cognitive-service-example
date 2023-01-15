namespace AzureHomeworkProject.Helpers
{
    public class ErrorDataResult<T> : DataResult<T> where T : class, new()
    {
        public ErrorDataResult(string message) : base(message, false)
        {
        }
    }
}
