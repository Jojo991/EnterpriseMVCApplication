using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroceryApp.Models.Services.Exceptions;
using GroceryApp.Models.Services;
using System.Net.Sockets;

namespace GroceryApp.Models.Business
{
    public class AuthenticationMgr : Manager
    {
        public Boolean ValidateUser(string username, string password)
        {

            try
            {
                IAuthenticationSvc authSvc = (IAuthenticationSvc)GetService(typeof(IAuthenticationSvc).Name);
                return authSvc.SendCredentials(username,password);
            }
            catch (ServiceLoadException e)
            {
                throw new AuthenticationException(e.Message);
            }
            catch (AuthenticationException e)
            {
                throw new AuthenticationException(e.Message);
            }
            catch (SocketException e)
            {
                throw new AuthenticationException(e.Message);
            }
           
        }
    }
}