using ProfSoftTestTask.Servise;

public class XmlConvertorFactory : AbstractConvertorFactory
{
    XmlConverter _converter;
    public XmlConvertorFactory()
    {
        _converter= new XmlConverter();
    }
    public override IEnumerable<IConfiguration> GetConfigurations(string[] filePaths)
    {
       foreach(string path in filePaths) 
        {
            yield return MapServise.MapToConfigurationObj(_converter.Convert(path));
        }
    }
}