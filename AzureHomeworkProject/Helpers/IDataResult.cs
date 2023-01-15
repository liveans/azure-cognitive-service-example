namespace AzureHomeworkProject.Helpers
{
    public interface IDataResult<T> : IResult where T : class, new()
    {
        public T Data { get; set; }
    }
}
