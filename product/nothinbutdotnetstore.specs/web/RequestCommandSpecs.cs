 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs.web
{   
    public class RequestCommandSpecs
    {
        public abstract class concern : Observes<RequestCommand,
                                            DefaultRequestCommand>
        {
        
        }
        public class when_processing_the_request : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                application_command = the_dependency<ApplicationCommand>();
                provide_a_basic_sut_constructor_argument<RequestCriteria>(x => false);
            };

            Because b = () =>
                sut.run(request);


            It should_delegate_to_the_application_specific_command = () =>
            {
                application_command.received(x => x.run(request));
            };

            static ApplicationCommand application_command;
            static Request request;
        }

        [Subject(typeof(DefaultRequestCommand))]
        public class when_determining_if_it_can_process_a_request : concern

        {
            Establish c = () =>
            {
                request = an<Request>();
                provide_a_basic_sut_constructor_argument<RequestCriteria>(x =>
                {
                    was_used = true;
                    return true;
                });

            };
            Because b = () =>
                result = sut.can_process(request);


            It should_make_the_determination_by_using_its_request_criteria = () =>
            {
                result.ShouldBeTrue();
                was_used.ShouldBeTrue();
            };


            static bool result;
            static Request request;
            static bool was_used;
        }
    }
}
