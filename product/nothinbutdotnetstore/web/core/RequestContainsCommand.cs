namespace nothinbutdotnetstore.web.core
{
    public class RequestContains<Command> where Command : ApplicationCommand
    {
        public bool matches(Request request)
        {
            return (request.command_name == typeof(Command).Name);
        }
    }
}