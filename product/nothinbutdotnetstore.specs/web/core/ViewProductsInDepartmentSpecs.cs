using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.model;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web.core
{   
    public class ViewProductsInDepartmentSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewProductsInDepartment>
        {
        
        }

        [Subject(typeof(ViewProductsInDepartment))]
        public class when_observation_name : concern
        {

            Establish c = () =>
            {

                GetTheReportModel<int> int_pointer = (x, y) => 2;
                GetTheReportModel<string> string_pointer = (x, y) => "";

                request = an<Request>();
                catalog = the_dependency<Catalog>();
                products_in_department = new List<Product>();
                the_department = new Department();
                renderer = the_dependency<Renderer>();

                request.Stub(x => x.map<Department>()).Return(the_department);
                catalog.Stub(x => x.get_products_in(the_department))
                    .Return(products_in_department);
            };

            Because b = () =>
                sut.run(request);

            It should_tell_render_to_display_products_in_department = () =>
                renderer.received(x => x.display(products_in_department));
            
            static Request request;
			static Catalog catalog;
			static Renderer renderer;
			static IEnumerable<Product> products_in_department;
		    
            static Department the_department;
        }
    }
}
