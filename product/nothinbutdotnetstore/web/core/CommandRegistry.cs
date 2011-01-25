namespace nothinbutdotnetstore.web.core
{
    public interface CommandRegistry
    {
        RequestCommand get_command_that_can_run(Request request);
    }
}