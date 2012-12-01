using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroceryApp.Models.Domain;

namespace GroceryApp.Models.Services
{
    public interface IAuthenticationSvc:IService
    {

      
        /**sends credentials*/
        Boolean SendCredentials(string username, string password) ;
    
     /**closes client connection */
       void closeClientConnection();
    }
}