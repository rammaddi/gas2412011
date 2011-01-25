using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class FrontControllerSpecs
    {
        public abstract class concern : Observes<FrontController,
                                            DefaultFrontController>
        {
        }

        [Subject(typeof(DefaultFrontController))]
        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                command_registry = the_dependency<CommandRegistry>();
                command_that_can_run_request = an<RequestCommand>();


                command_registry.Stub(x => x.get_command_that_can_run(request))
                    .Return(command_that_can_run_request);
            };

            Because b = () =>
                sut.process(request);


            It should_tell_the_command_that_can_process_the_request_to_run_the_request = () =>
                command_that_can_run_request.received(x => x.run(request));

            static RequestCommand command_that_can_run_request;
            static Request request;
            static CommandRegistry command_registry;
        }
    }
}