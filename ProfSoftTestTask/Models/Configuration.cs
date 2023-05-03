namespace ProfSoftTestTask.Models
{
    public class Configuration : IConfiguration
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Configuration(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return $"Configuration \n\r Name: {Name} \n\r Description: {Description}";
        }
    }
}
