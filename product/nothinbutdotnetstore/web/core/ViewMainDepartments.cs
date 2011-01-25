using nothinbutdotnetstore.tasks;

namespace nothinbutdotnetstore.web.core
{
    public class ViewMainDepartments : ApplicationCommand
    {
        DepartmentsRepository repository;
        Renderer renderer;

        public ViewMainDepartments(DepartmentsRepository repository, Renderer renderer)
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