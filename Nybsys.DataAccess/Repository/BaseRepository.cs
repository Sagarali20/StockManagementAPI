using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nybsys.DataAccess.Repository
{
    public abstract class BaseRepository<T> where T : class
    { 
        private readonly NybsysDbContext _db;
        public BaseRepository(NybsysDbContext nybsysDbContext)
        {
            _db = nybsysDbContext;
        }
        public  DbSet<T> Table
        {
            get
            {
                return _db.Set<T>();
            }
        }
        public virtual bool Create(T entity)
        {
            Table.Add(entity);
            return Save();
        }
        public virtual bool Update(T entity)
        {
            Table.Update(entity);
            return Save();
        }
        public virtual bool Delete(T entity)
        {
            Table.Remove(entity);
            return Save();
        }
        public virtual T GetById(int id)
        {         
            return  Table.Find(id);
        }
        public virtual bool Save()
        {
            return _db.SaveChanges() > 0;
        }
        public virtual ICollection<T> GetAll()
        {
            return Table.ToList();
        }
        public virtual ICollection<T> GetAllDesignation()
        {
            return Table.ToList();
        }
    }
}
