using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web.core
{
    public class CommandIncomingRequestMatcherSpecs
    {
        public abstract class concern : Observes<RequestContains<OurCommand>>
        {
        }

        [Subject(typeof(RequestContains<>))]
        public class when_matching_request_criteria_to_a_application_command : concern
        {
            Establish e = () =>
            {
                request = an<Request>();
                request.Stub(x => x.command_name).Return(typeof(OurCommand).Name);
            };

            Because b = () => { result = sut.matches(request); };

            It should_return_true_if_request_command_name_matches_command_class_name = () => { result.ShouldBeTrue(); };

            static bool result;
            static Request request;
        }

        class NotOurCommand : ApplicationCommand
        {
            public void run(Request request)
            {
                throw new NotImplementedException();
            }
        }

        public class OurCommand : ApplicationCommand
        {
            public void run(Request request)
            {
                throw new NotImplementedException();
            }
        }

        [Subject(typeof(RequestContains<>))]
        public class when_the_incoming_request_does_not_match_the_command_name : concern
        {
            Establish e = () =>
            {
                request = an<Request>();
                request.Stub(x => x.command_name).Return(typeof(NotOurCommand).Name);
            };

            Because b = () => { result = sut.matches(request); };

            It should_return_false_if_request_command_name_does_not_match_command_class_name =
                () => { result.ShouldBeFalse(); };

            static bool result;
            static Request request;
        }
    }
}