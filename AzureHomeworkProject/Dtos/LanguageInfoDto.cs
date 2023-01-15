namespace AzureHomeworkProject.Dtos
{
    public class LanguageInfoDto
    {
        public string Name { get; set; }
        public string ISOName { get; set; }

        public LanguageInfoDto(string name, string iSOName)
        {
            Name = name;
            ISOName = iSOName;
        }
    }
}
