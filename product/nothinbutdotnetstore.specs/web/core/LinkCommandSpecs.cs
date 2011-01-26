 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;
 using nothinbutdotnetstore.web.model;

namespace nothinbutdotnetstore.specs.web.core
{   
	public class LinkCommandSpecs
	{
		public abstract class concern : Observes
		{
        
		}

		[Subject(typeof(LinkCommand))]
		public class when_observation_name : concern
		{

			Establish e = () =>
			{
				department = an<Department>();
				department.name = "Test";
			};

			It should_return_a_valid_url_for_the_department = () =>
				LinkCommand.GetName<ViewDepartmentsInDepartment>(department).ShouldEqual("ViewDepartmentsInDepartment.invision?Department=Test");

			static Department department;
				
		}
	}
}
