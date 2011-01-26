using System.Web;
using System.Web.Configuration;

namespace nothinbutdotnetstore.web.core
{
    public class WebFormTemplate : Template
    {
        GetTheCurrentContext current_context;
        ModelAwareHandlerFactory model_aware_handler_factory;

        public WebFormTemplate(ModelAwareHandlerFactory model_aware_handler_factory):this(model_aware_handler_factory, 
            () => HttpContext.Current)
        {
        }

        public WebFormTemplate(ModelAwareHandlerFactory model_aware_handler_factory,
                               GetTheCurrentContext current_context)
        {
            this.model_aware_handler_factory = model_aware_handler_factory;
            this.current_context = current_context;
        }

        public void render<ReportModel>(ReportModel report_model)
        {
            model_aware_handler_factory.create(report_model).ProcessRequest(current_context());
        }
    }
}