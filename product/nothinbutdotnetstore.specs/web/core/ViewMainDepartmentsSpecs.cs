using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.web.core
{
    class ViewMainDepartmentsSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewMainDepartments>
        {

        }
        public class when_processing_command_get_departments : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                departments_data_accesor = the_dependency<DepartmentsDataAccessor>();
                renderer = the_dependency<Renderer>();
            };

            Because b = () =>
                sut.run(request);

            It should_delegate_to_the_data_accessor = () =>
            {
                departments_data_accesor.received(x => x.getMainDepartments());
                renderer.received(x => x.display());
            };

            static Request request;
            static DepartmentsDataAccessor departments_data_accesor;
            static Renderer renderer;
        }

    }
}
