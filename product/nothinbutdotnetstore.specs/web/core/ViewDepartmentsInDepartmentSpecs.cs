 
using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.model;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web.core
{
	public class ViewDepartmentsInDepartmentSpecs
	{
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewDepartmentsInDepartment>
        {
        }

		public class when_run : concern
		{
			Establish c = () =>
			{
				request = an<Request>();
				departments_repository = the_dependency<DepartmentsRepository>();
				the_departments_in_department = new List<Department>();
                the_parent_department = new Department();

				renderer = the_dependency<Renderer>();

			    request.Stub(x => x.map<Department>()).Return(the_parent_department);


				departments_repository.Stub(x => x.get_departments_in_department(the_parent_department))
					.Return(the_departments_in_department);
			};

			Because b = () =>
				sut.run(request);

			It should_tell_the_renderer_to_display_the_set_of_main_deparments = () =>
				renderer.received(x => x.display(the_departments_in_department));

			static Request request;
			static DepartmentsRepository departments_repository;
			static Renderer renderer;
			static IEnumerable<Department> the_departments_in_department;
		    static Department the_parent_department;
		}
	}
}
