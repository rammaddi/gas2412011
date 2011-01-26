using System.Collections.Generic;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.model;

namespace nothinbutdotnetstore.web.core
{
    public class GetTheMainDepartments 
    {
        public IEnumerable<Department> run(Catalog catalog,Request request)
        {
            return catalog.get_main_departments();
        }
    }
}