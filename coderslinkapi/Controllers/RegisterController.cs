using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coderslinkapi.Data;
using coderslinkapi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace coderslinkapi.Controllers
{  
    [ApiController]
    [Route("[controller]")]

    public class RegisterController: ControllerBase
    {
                       
        private IRepository<Register> _repository = null;
                        
        public RegisterController(IRepository<Register> repository)
        {
     
        _repository= repository;
        
        }
    

      
             [HttpGet("/api/findPerson/")]
              [ProducesResponseType(typeof(Register), 200)]
        
        public  List<Register> Get(string lastName = null ,  bool Ascending =true)
        {
         //create  a object type:Parameters ,to configure all the necesary parameters
        var parameters = new Parameters<Register>();
        
        if (lastName != null)
        {
         parameters.Where = x => x.LastName==lastName;
        }
           
            parameters.OrderAscending = Ascending;
            parameters.OrderBy = x => (x.LastName,x.FirstName);
         
            var result=  _repository.Get( parameters);
        
            return  result.ToList();

        }

   [HttpPost("/api/insertPerson/")]
    public IActionResult Add(Register newRegister)
    {
        try
        {

         // validate duplicate data   :( sorry i didnt have time
        _repository.Insert(newRegister);
  
        return Ok("process successful, file saved successfully");
        }
    
      
       catch (System.Exception ex)
            {
              return BadRequest("Error:"+ ex);
            }
              
 
    }


       
    }
}