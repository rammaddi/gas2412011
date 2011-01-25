using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        public DefaultCommandRegistry(IEnumerable<RequestCommand> all_commands)
        {
            
        }

        public RequestCommand get_command_that_can_run(Request request)
        {
            throw new NotImplementedException();
        }
    }
}