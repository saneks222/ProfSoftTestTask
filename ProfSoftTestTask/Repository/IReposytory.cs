namespace ProfSoftTestTask.Repository
{
    public interface IReposytory<T> where T : class
    {
        public void Add(T config);
        public void AddRange(IEnumerable<T> configs);
        public IEnumerable<T> Get(Func<T,bool> filter=null);
    }
}
