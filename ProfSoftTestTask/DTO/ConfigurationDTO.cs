using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

[XmlRoot(ElementName = "config")]
public class ConfigurationDTO
{
    [XmlElement(ElementName = "name")]
    public string Name { get;  set; }
    [XmlElement(ElementName = "description")]
    public string Description { get;  set; }

}