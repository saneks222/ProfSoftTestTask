namespace ProfSoftTestTask.Application
{
    public class ConverterRegistrationModel
    {
        public string ExtensionsName { get; set; }
        public AbstractConvertorFactory Convertor { get; set; }

        public ConverterRegistrationModel(string extensionsName, AbstractConvertorFactory convertor)
        {
            ExtensionsName = extensionsName;
            Convertor = convertor;
        }
    }
}
