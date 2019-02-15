using System.Linq;

namespace ProjetoLoja.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        bool Insert(TEntity entity);        
        bool SaveChanges();
        bool Delete(TEntity entity);
    }
}