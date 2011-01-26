using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class ViewMainDepartments : ApplicationCommand
    {
        Catalog repository;
        Renderer renderer;

        public ViewMainDepartments():this(new StubDepartmentRepository(),
            new StubRenderer())
        {
        }

        public ViewMainDepartments(Catalog repository, Renderer renderer)
        {
            this.repository = repository;
            this.renderer = renderer;
        }

        public void run(Request request)
        {
            renderer.display(repository.get_main_departments());
        }
    }
}