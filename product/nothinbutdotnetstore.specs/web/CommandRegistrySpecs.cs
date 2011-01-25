using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class CommandRegistrySpecs
    {
        public abstract class concern : Observes<CommandRegistry,
                                            DefaultCommandRegistry>
        {
            Establish c = () =>
            {
                request = an<Request>();
                all_commands = Enumerable.Range(1, 100).Select(x => an<RequestCommand>()).ToList();
                provide_a_basic_sut_constructor_argument<IEnumerable<RequestCommand>>(all_commands);
            };

            protected static Request request;
            protected static RequestCommand result;
            protected static List<RequestCommand> all_commands;
        }

        [Subject(typeof(DefaultCommandRegistry))]
        public class when_finding_a_command_that_can_handle_a_request_and_it_has_the_command : concern
        {
            Establish c = () =>
            {
                the_command_that_can_handle_the_request = an<RequestCommand>();
                all_commands.Add(the_command_that_can_handle_the_request);
                the_command_that_can_handle_the_request.Stub(x => x.can_process(request)).Return(true);
            };

            Because b = () =>
                result = sut.get_command_that_can_run(request);

            It should_return_the_command_that_can_handle_the_request = () =>
                result.ShouldEqual(the_command_that_can_handle_the_request);

            static RequestCommand the_command_that_can_handle_the_request;
        }

        [Subject(typeof(DefaultCommandRegistry))]
        public class when_finding_a_command_that_can_handle_a_request_and_it_does_not_have_the_command : concern
        {
            Because b = () =>
                result = sut.get_command_that_can_run(request);

            It should_return_a_missing_command = () =>
                result.ShouldBeAn<MissingRequestCommand>();
            static List<RequestCommand> all_commands;
        }
    }
}