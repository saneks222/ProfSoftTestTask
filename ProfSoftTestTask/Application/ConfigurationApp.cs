using Autofac;
using ProfSoftTestTask.Application;
using ProfSoftTestTask.Repository;

public class ConfigurationApp :IApp
{
    private string _directoryPath;
    private List<string> _files;
    private Dictionary<string, List<string>> _sortedFiles;
    private readonly Dictionary<string, AbstractConvertorFactory> _converters;
    private IConfigurationRepository _repositoryInMemory;

    public IContainer Container { get; set; }

    public ConfigurationApp()
    {
        _files = new();
        _converters = new();
        _sortedFiles = new();
        _directoryPath = Directory.GetCurrentDirectory();   
    }

    public IApp SetFolderNameForFile(string folderName)
    {
        _directoryPath += folderName;

        return this;
    }

    public IApp RegisterSuopportedFileType(params ConverterRegistrationModel[] converters)
    {
        foreach (var extension in converters)
        {
            _sortedFiles.Add(extension.ExtensionsName, new List<string>());
            _converters.Add(extension.ExtensionsName, extension.Convertor);
        }
        return this;
    }

    public IApp Build() 
    {
        _repositoryInMemory = Container.Resolve<IConfigurationRepository>();

        return this;
    }

    public void Run() 
    {
        try
        {
            GetFiles();
            FillSortedFilesList();
            _repositoryInMemory.AddRange(GetConfigurations());
            PrintConfigs();
        }
        catch(Exception ex) 
        {
            Console.WriteLine($"Application error: {ex.Message}");
        }
    }

    private void GetFiles() 
    {
        foreach (var file in Directory.EnumerateFiles(_directoryPath)) 
        {
            if(ValidateFile(file))
                _files.Add(file);
        }   
    }

    private bool ValidateFile(string file) 
    {
        int index=-1;
        string fileExtension = ""; 
        for (int i = file.Length - 1; file[i] != '.'; i--) 
        {
            if(file[i-1] == '.')
                index = i-1;
        }
        fileExtension = file.Substring(index, file.Length-index);

        if(_sortedFiles.ContainsKey(fileExtension.ToUpper()))
            return true;
        return false;
    }

    private void FillSortedFilesList() 
    {
        string fileExtension = "";
        
        foreach (var file in _files) 
        {
            fileExtension = Path.GetExtension(file).ToUpper();
            if (_sortedFiles.ContainsKey(fileExtension)) 
            {
                _sortedFiles[fileExtension].Add(file);
            }
        } 
    }

    private List<IConfiguration> GetConfigurations() 
    {
        List<IConfiguration> result  =new();
        foreach (var item in _sortedFiles) 
        {
            var convertor = GetFactory(item.Key.ToUpper());
            result.AddRange(convertor.GetConfigurations(item.Value.ToArray()));
        }

        return result;
    }

    private AbstractConvertorFactory GetFactory(string extensions) 
    {
        return _converters[extensions];
    }

    private void PrintConfigs() 
    {
        foreach (var config in _repositoryInMemory.Get()) 
        {
            Console.WriteLine(config.ToString());
        }
    }
}