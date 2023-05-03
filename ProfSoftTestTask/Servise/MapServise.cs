using ProfSoftTestTask.Models;

namespace ProfSoftTestTask.Servise
{
    public static class MapServise
    {
        public static Configuration MapToConfigurationObj(ConfigurationDTO dto)
        {
            return new Configuration(dto.Name, dto.Description);
        }
    }
}
