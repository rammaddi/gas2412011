using System.Web;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using NUnit.Framework;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class when_processing_nunit_style : BaseConcern<RawHandler>
    {
        FrontController controller;
        RequestFactory request_factory;
        Request request;
        HttpContext the_context;

        protected override void arrange()
        {
            controller = an<FrontController>();
            request_factory = an<RequestFactory>();
            request = an<Request>();
            the_context = ObjectMother.create_http_context();

            request_factory.Stub(x => x.create(the_context))
                .Return(request);

        }

        protected override RawHandler create_sut()
        {
            return new RawHandler(controller, request_factory);
        }

        protected override void act()
        {
            sut.ProcessRequest(the_context);
        }

        [Test]
        public void should_tell_the_front_controller_to_process_the_request()
        {
            controller.AssertWasCalled(x => x.process(request));
        }
    }
}