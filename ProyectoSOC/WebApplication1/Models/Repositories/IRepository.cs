namespace ProyectoSOC.Models.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        int Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        void Save();
    }
}
