using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<RequestCommand> all_commands;

        public DefaultCommandRegistry(IEnumerable<RequestCommand> all_commands)
        {
            this.all_commands = all_commands;
        }

        public RequestCommand get_command_that_can_run(Request request)
        {
        	try
        	{
				return all_commands.First(x => x.can_process(request));
        	}
        	catch (Exception)
        	{
        		return new MissingRequestCommand();
        	}
            
        }
    }
}