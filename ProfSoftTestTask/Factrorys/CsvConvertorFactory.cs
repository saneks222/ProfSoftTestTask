using ProfSoftTestTask.Converters.CSV;
using ProfSoftTestTask.Servise;


namespace ProfSoftTestTask.Factrorys
{
    internal class CsvConvertorFactory : AbstractConvertorFactory
    {
        CsvConverter _converter;
        public CsvConvertorFactory()
        {
            _converter= new CsvConverter();
        }

        public override IEnumerable<IConfiguration> GetConfigurations(string[] filePaths)
        {
            foreach (string path in filePaths)
            {
                yield return MapServise.MapToConfigurationObj(_converter.Convert(path));
            }
        }
    }
}
