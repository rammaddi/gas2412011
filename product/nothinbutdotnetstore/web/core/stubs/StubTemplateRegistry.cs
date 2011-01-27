using System;
using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubTemplateRegistry : TemplateRegistry
    {
        public Template find_template()
        {
            return new WebFormTemplate(new DefaultModelAwareHandlerFactory(),
                                       () => HttpContext.Current);
        }
    }
}