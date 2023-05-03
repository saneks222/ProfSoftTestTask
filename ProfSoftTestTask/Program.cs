using ProfSoftTestTask.Application;
using ProfSoftTestTask.Application.Extensions;
using ProfSoftTestTask.Factrorys;


IApp app = new ConfigurationApp();

app.AddIoC()
   .SetFolderNameForFile("\\confFiles")
   .RegisterSuopportedFileType(
    new ConverterRegistrationModel(".CSV", new CsvConvertorFactory()), 
    new ConverterRegistrationModel(".XML",new XmlConvertorFactory()))
   .Build()
   .Run();
