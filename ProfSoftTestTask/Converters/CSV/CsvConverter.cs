namespace ProfSoftTestTask.Converters.CSV
{
    internal class CsvConverter : IConverter<string, ConfigurationDTO>
    {
        public ConfigurationDTO Convert(string input)
        {
            var config = File.ReadAllLines(input)
                .Select(x => x.Split(';'))
                .Select(x => new ConfigurationDTO() { Name = x[0], Description = x[1] }).First();

            return config;
        }
    }
}
