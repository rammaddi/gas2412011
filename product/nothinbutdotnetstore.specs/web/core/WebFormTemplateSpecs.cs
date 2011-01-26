 using System.Web;
 using System.Web.Compilation;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web.core
{   
    public class WebFormTemplateSpecs
    {
        public abstract class concern : Observes<Template,
                                            WebFormTemplate>
        {
        
        }

        [Subject(typeof(WebFormTemplate))]
        public class when_rendering_a_report_model : concern
        {
            Establish c = () =>
            {
                the_active_context = ObjectMother.create_http_context();
                handler = an<ModelAwareHandler<int>>();
                provide_a_basic_sut_constructor_argument<GetTheCurrentContext>(() => the_active_context);
                model_aware_handler_factory = the_dependency<ModelAwareHandlerFactory>();
                model_aware_handler_factory.Stub(x => x.create(23))
                    .Return(handler);

            };

            Because b = () =>
                sut.render(23);


            It should_tell_the_web_form_handler_to_process_using_the_active_context = () =>
                handler.received(x => x.ProcessRequest(the_active_context));



            static HttpContext the_active_context;
            static ModelAwareHandlerFactory model_aware_handler_factory;
            static ModelAwareHandler<int> handler;
        }
    }
}
