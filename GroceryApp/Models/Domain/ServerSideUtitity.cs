using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace GroceryApp.Models.Domain
{
    public class ServerSideUtitity
    {
        public int Visitors { get; set; }

        public string IPAddress { get; set; }



        public void GetIPConfig()
        {
            //IPAddress = Request.UserHostAddress;
        }
    }

    
}