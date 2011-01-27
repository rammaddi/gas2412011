using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.model;

namespace nothinbutdotnetstore.web.core
{
    public class ViewProductsInDepartment : ApplicationCommand
	{
        Catalog repository;
        Renderer renderer;

        public ViewProductsInDepartment(Catalog repository, Renderer renderer)
        {
            this.repository = repository;
            this.renderer = renderer;
        }

        public void run(Request request)
        {
			renderer.display(repository.get_products_in(request.map<Department>()));
        }
	}
}