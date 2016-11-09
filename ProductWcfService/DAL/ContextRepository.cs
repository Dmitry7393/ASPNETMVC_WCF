using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductWcfService.DAL
{
    public abstract class ContextRepository
    {
        protected DatabaseContext CreateContext()
        {
            return new DatabaseContext();
        }
    }
}