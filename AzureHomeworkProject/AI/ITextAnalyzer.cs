using AzureHomeworkProject.Dtos;

namespace AzureHomeworkProject.AI
{
    public interface ITextAnalyzer
    {
        Task<LanguageInfoDto> GetLanguageInformationsAsync(string input);
    }
}
