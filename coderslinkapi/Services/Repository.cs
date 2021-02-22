using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using coderslinkapi.Data;
using Microsoft.EntityFrameworkCore;

namespace coderslinkapi.Services
{
   //implementation of IRepository, here is the magic, we use any type of class(models) and we use a delegate to create lambda expressions
   //to find or order data.
 public  class Repository<T> : IRepository <T> where T : class
    {
   private CodersLinkDBContext _context = null;
        private DbSet<T> dbSet = null;
   public Repository()
        {
            this._context = new CodersLinkDBContext();
            dbSet = _context.Set<T>();
        }
        public Repository(CodersLinkDBContext _context)
        {
            this._context = _context;
            dbSet = _context.Set<T>();
        }
         public virtual IEnumerable<T> Get(Parameters<T> parameters)
         {
               IQueryable<T> query = dbSet;

               if (parameters.Where != null)
               {
                  query = query.Where(parameters.Where);
               }

                        if (parameters.OrderAscending)
                           {
                              return query.OrderBy(parameters.OrderBy).ToList();
                           }
                           else
                           {
                              return query.OrderByDescending(parameters.OrderBy).ToList();
                           }
     
          }
        public void Insert(T obj)
        {
               dbSet.Add(obj);
               Save();  
   
        }
        public  IEnumerable<T>  GetAll()
        {
           return(dbSet.ToList());
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}