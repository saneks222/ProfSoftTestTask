using System.Xml.Serialization;
public class XmlConverter : IConverter<string, ConfigurationDTO>
{
    private readonly XmlSerializer _serializer;

    public XmlConverter()
    {
        _serializer = new XmlSerializer(typeof(ConfigurationDTO));
    }
        
    public ConfigurationDTO Convert(string filePath)
    {
        ConfigurationDTO result;
        using (Stream reader = new FileStream(filePath, FileMode.Open))
        {
            // Call the Deserialize method to restore the object's state.
            result = (ConfigurationDTO)_serializer.Deserialize(reader);
        }

        return result != null? result : throw new ApplicationException("file is empty");
    }
}