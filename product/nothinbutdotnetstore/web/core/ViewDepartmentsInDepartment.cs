using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
	public class ViewDepartmentsInDepartment :ApplicationCommand
	{
        DepartmentsRepository repository;
        Renderer renderer;

		public ViewDepartmentsInDepartment()
			: this(new StubDepartmentRepository(),
            new StubRenderer())
        {
        }

		public ViewDepartmentsInDepartment(DepartmentsRepository repository, Renderer renderer)
        {
            this.repository = repository;
            this.renderer = renderer;
        }

        public void run(Request request)
        {
			renderer.display(repository.get_departments_in_department());
        }
	}
}