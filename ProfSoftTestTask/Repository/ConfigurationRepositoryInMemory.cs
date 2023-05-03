namespace ProfSoftTestTask.Repository
{
    internal class ConfigurationRepositoryInMemory : IConfigurationRepository
    {
        private List<IConfiguration> _configurations = new();

        public void Add(IConfiguration config)
        {
            _configurations.Add(config);
        }

        public void AddRange(IEnumerable<IConfiguration> configs)
        {
            _configurations.AddRange(configs);
        }

        public IEnumerable<IConfiguration> Get(Func<IConfiguration, bool> filter = null)
        {
            if(filter!=null)
                return _configurations.Where(filter);
            

            return _configurations;
        }
    }
}
