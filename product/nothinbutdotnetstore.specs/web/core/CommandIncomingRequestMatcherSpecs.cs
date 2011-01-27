 using System;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web.core
{   
	public class CommandIncomingRequestMatcherSpecs
	{
		public abstract class concern : Observes<IncomingRequestMatcher, CommandIncomingRequestMatcher>
		{
        
		}

		[Subject(typeof(CommandIncomingRequestMatcher))]
		public class when_matching_request_criteria_to_a_main_department_model : concern
		{
			Establish e = () =>
			{
				request = an<Request>();
				request.CommandName = "ViewMainDepartments";

				provide_a_basic_sut_constructor_argument(request.CommandName);

			};

			Because b = () =>
			{
				result = sut.Match<ViewMainDepartments>(request);
			};


			It should_return_true_if_request_command_name_matches_command_class_name = () =>
			{
				result.ShouldBeTrue();
			};

			It should_return_false_if_request_command_name_does_not_match_command_class_name = () =>
			{
				result.ShouldBeTrue();
			};

			static bool result;
			static Request request;
		}

		[Subject(typeof(CommandIncomingRequestMatcher))]
		public class when_not_matching_request_criteria_to_a_main_department_model : concern
		{
			Establish e = () =>
			{
				request = an<Request>();
				request.CommandName = "ViewDepartmentsInDepartment";

				provide_a_basic_sut_constructor_argument(request.CommandName);

			};

			Because b = () =>
			{
				result = sut.Match<ViewMainDepartments>(request);
			};


			It should_return_false_if_request_command_name_does_not_match_command_class_name = () =>
			{
				result.ShouldBeFalse();
			};

			static bool result;
			static Request request;
		}
	}
}
