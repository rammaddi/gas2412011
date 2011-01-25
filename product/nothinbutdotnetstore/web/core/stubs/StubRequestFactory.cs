using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create(HttpContext the_incoming_context)
        {
            return new StubRequest();
        }

        class StubRequest : Request
        {
        }
    }
}