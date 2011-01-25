using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<RequestCommand> registry;
        public DefaultCommandRegistry(IEnumerable<RequestCommand> all_commands)
        {
            this.registry = all_commands;
        }

        public RequestCommand get_command_that_can_run(Request request)
        {
            RequestCommand retval = null;
            foreach (var request_command in registry)
            {
                if (request_command.can_process(request))
                {
                    retval = request_command;
                }
            }

            return retval;
        }
    }
}