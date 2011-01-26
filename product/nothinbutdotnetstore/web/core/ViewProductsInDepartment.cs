using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core.stubs;
using nothinbutdotnetstore.web.model;

namespace nothinbutdotnetstore.web.core
{
    public class ViewProductsInDepartment : ApplicationCommand
	{
        DepartmentsRepository repository;
        Renderer renderer;

		public ViewProductsInDepartment()
			: this(new StubDepartmentRepository(),
            new StubRenderer())
        {
        }

        public ViewProductsInDepartment(DepartmentsRepository repository, Renderer renderer)
        {
            this.repository = repository;
            this.renderer = renderer;
        }

        public void run(Request request)
        {
			renderer.display(repository.get_products_in_department(request.map<Department>()));
        }
	}
}