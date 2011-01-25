using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultFrontController : FrontController
    {
        CommandRegistry registry;

        public DefaultFrontController(CommandRegistry registry)
        {
            this.registry = registry;
        }
        public void process(Request request)
        {
            registry.get_command_that_can_run(request).run(request);
        }
    }
}