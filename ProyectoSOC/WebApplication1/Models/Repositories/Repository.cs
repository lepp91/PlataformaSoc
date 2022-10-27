using ProyectoSOC.Data;

namespace ProyectoSOC.Models.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly SocDB _context;
        private readonly ILogger<T> _logger;

        public Repository(SocDB context, ILogger<T> logger)
        {
            _context = context;
            _logger = logger;
        }

        public int Create(T entity)
        {
            try
            {
              
                _context.Add(entity);
                return _context.SaveChanges();
            }
            catch (IOException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
        }

        public bool Delete(T entity)
        {
            try
            {

                _context.Remove(entity);
            }
            catch (IOException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }

            return _context.SaveChanges() > 0;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(string id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Save()
        {
        }

        public bool Update(T entity)
        {
            try
            {
                _context.Update(entity);
            }
            catch (IOException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }

            return _context.SaveChanges() > 0;
        }
    }
}
