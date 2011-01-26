using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.model;
using Rhino.Mocks;
using System.Linq;

namespace nothinbutdotnetstore.specs.web.core
{
    class ViewMainDepartmentsSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewMainDepartments>
        {
        }

        public class when_run : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                catalog = the_dependency<Catalog>();
                the_main_departments = new List<Department>();

                renderer = the_dependency<Renderer>();

                catalog.Stub(x => x.get_main_departments())
                    .Return(the_main_departments);
            };

            Because b = () =>
                sut.run(request);

            It should_tell_the_renderer_to_display_the_set_of_main_deparments = () =>
                renderer.received(x => x.display(the_main_departments));

        	It should_have_a_valid_url = () =>
        		the_main_departments.First().url.ShouldNotBeNull();

            static Request request;
            static Catalog catalog;
            static Renderer renderer;
            static IEnumerable<Department> the_main_departments;
        }
    }
}