using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace coderslinkapi.Services
{

    //Generic interface, in any  interface yo only defines behaviors
    //is generic because i dont need a specific class, i can work with all my models (T)  :)
 public interface IRepository<T> where T :class
    {
    IEnumerable<T> Get(   Parameters<T> parameters);
    void Insert(T obj);

    IEnumerable<T> GetAll();


    }
}