using System.Web;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class RawHandler : IHttpHandler
    {
        FrontController controller;
        RequestFactory factory;


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