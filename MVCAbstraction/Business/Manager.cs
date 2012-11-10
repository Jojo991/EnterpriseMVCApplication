using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVCAbstraction.Services;


namespace GroceryStore.Business
{
    /**
     * Manager
     Layer Super-Type Implementation*/
    public abstract class Manager
    {
        private Factory factory = Factory.GetInstance();

        protected IService GetService(String name)
        {
          
            return factory.GetService(name);
        }

    }
}
