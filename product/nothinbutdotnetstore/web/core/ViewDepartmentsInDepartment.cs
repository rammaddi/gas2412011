using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core.stubs;
using nothinbutdotnetstore.web.model;

namespace nothinbutdotnetstore.web.core
{
	public class ViewDepartmentsInDepartment :ApplicationCommand
	{
        Catalog repository;
        Renderer renderer;

		public ViewDepartmentsInDepartment()
			: this(new StubCatalog(),
            new StubRenderer())
        {
        }

        public ViewDepartmentsInDepartment(Catalog repository, Renderer renderer)
        {
            this.repository = repository;
            this.renderer = renderer;
        }

        public void run(Request request)
        {
			renderer.display(repository.get_departments_in(request.map<Department>()));
        }
	}

   
}