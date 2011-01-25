using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface RequestFactory
    {
        object create(HttpContext the_incoming_context);
    }
}