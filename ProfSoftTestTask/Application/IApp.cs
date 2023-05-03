using Autofac;
using ProfSoftTestTask.Application;

public interface IApp 
{
    /// <summary>
    /// IoC Container
    /// </summary>
    public IContainer Container { get; set; }

    /// <summary>
    /// Регестрирует фабрики конвертации для новых типов файлов
    /// </summary>
    /// <returns>IApp</returns>
    public IApp RegisterSuopportedFileType(params ConverterRegistrationModel[] converters);

    /// <summary>
    /// Собирает объект приложения, регестрируя все зависимости.
    /// </summary>
    /// <returns>IApp</returns>
    public IApp Build();

    /// <summary>
    /// Устанавливает имя папки в которой лежат файлы для конвертации
    /// </summary>
    /// <returns>IApp</returns>
    public IApp SetFolderNameForFile(string folderName);

    /// <summary>
    /// Запускает сконфигурированной приложение
    /// </summary>
    public void Run(); 
}
