using ProfSoftTestTask.Models;

public abstract class AbstractConvertorFactory 
{
    public abstract IEnumerable<IConfiguration> GetConfigurations(string[] filePaths);
}