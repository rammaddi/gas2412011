namespace nothinbutdotnetstore.web.core.stubs
{
    public class IncomingRequest
    {
        public static RequestCriteria is_for<Command>() where Command : ApplicationCommand
        {
            return new RequestContains<Command>().matches;
        }
    }
}