using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultFrontController : FrontController
    {
        CommandRegistry command_registry;

        public DefaultFrontController(CommandRegistry command_registry)
        {
            this.command_registry = command_registry;
        }

        public void process(Request request)
        {
            var command_that_can_run = command_registry.get_command_that_can_run(request);
            command_that_can_run.run(request);
        }
    }
}