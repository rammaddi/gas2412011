using System.Web;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.web.core
{
    public class RawHandler : IHttpHandler
    {
        FrontController controller;
        RequestFactory factory;

        public RawHandler():this(Container.fetch.a<FrontController>(),
            Container.fetch.a<RequestFactory>())
        {
        }

        public RawHandler(FrontController controller, RequestFactory factory)
        {
            this.controller = controller;
            this.factory = factory;
        }

        public void ProcessRequest(HttpContext context)
        {
            this.controller.process(factory.create(context));
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}