using Azure;
using Azure.AI.TextAnalytics;
using AzureHomeworkProject.Dtos;
using AzureHomeworkProject.Exceptions;

namespace AzureHomeworkProject.AI
{
    public class TextAnalyzer : ITextAnalyzer
    {
        private readonly TextAnalyticsClient _client;
        public TextAnalyzer(string endpoint, string key) 
        {
            _client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(key));
        }

        public async Task<LanguageInfoDto> GetLanguageInformationsAsync(string input)
        {
            var infos = await _client.DetectLanguageAsync(input);

            if (infos == null)
            {
                throw new NotDetectedException();
            }

            var infosValue = infos!.Value;

            return new(infosValue.Name, infosValue.Iso6391Name);
        }
    }
}
