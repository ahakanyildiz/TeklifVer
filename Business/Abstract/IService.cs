namespace Business.Abstract
{
    public interface IService<T> where T : class, new()
    {
        public Task Create();
        public Task Update();
        public void Delete();
        public IEnumerable<T> GetAll();

    }
}
