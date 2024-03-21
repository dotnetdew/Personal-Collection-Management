using CollectionManagement.Repositories;

namespace CollectionManagement.Services
{
    public class Service<T> : IService<T> where T : class
    {
        protected readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual void Delete(T entity)
        {
            _repository.Delete(entity);
            _repository.Save();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual T GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public virtual void Insert(T entity)
        {
            _repository.Insert(entity);
            _repository.Save();
        }

        public virtual void Update(T entity)
        {
            _repository.Update(entity);
            _repository.Save();
        }
    }
}