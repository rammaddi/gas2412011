 
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
				the_departments_in_departements = new List<Department>();

				renderer = the_dependency<Renderer>();

				departments_repository.Stub(x => x.get_departments_in_department())
					.Return(the_departments_in_departements);
			};

			Because b = () =>
				sut.run(request);

			It should_tell_the_renderer_to_display_the_set_of_main_deparments = () =>
				renderer.received(x => x.display(the_departments_in_departements));

			static Request request;
			static DepartmentsRepository departments_repository;
			static Renderer renderer;
			static IEnumerable<Department> the_departments_in_departements;
		}
	}
}
