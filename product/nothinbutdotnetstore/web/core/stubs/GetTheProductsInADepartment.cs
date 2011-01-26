using System.Collections.Generic;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.model;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class GetTheProductsInADepartment
    {
        public IEnumerable<Product> run(Catalog catalog, Request request)
        {
            return catalog.get_products_in(request.map<Department>());
        }
    }
}