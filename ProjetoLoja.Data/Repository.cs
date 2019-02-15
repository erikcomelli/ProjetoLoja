using ProjetoLoja.Domain;
using ProjetoLoja.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoLoja.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly ProjetoLojaDBContext _context;

        public Repository(ProjetoLojaDBContext context)
        {
            _context = context;
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                return SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().SingleOrDefault(e => e.Id == id);
        }

        public bool Insert(TEntity entity)
        {
            try
            {
                if (entity.Id==0)
                    _context.Set<TEntity>().Add(entity);
                return SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SaveChanges()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }        
    }
}
