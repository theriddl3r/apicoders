using System;
using System.Linq;
using System.Linq.Expressions;

namespace coderslinkapi.Services
{
    public class Parameters<T>
    {
      //this class was create to define any parameters that we could needs
            public Parameters()
        {
          
        }

       
    public Expression<Func<T,bool>>Where {get;set;}
    public bool OrderAscending {get;set;}
    public Func<T,object> OrderBy {get;set;}
    
    }
    }
