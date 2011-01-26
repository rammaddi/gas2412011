using System;
using System.Web;
using System.Web.Compilation;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubTemplateRegistry : TemplateRegistry
    {
        public Template find_template()
        {
            return new WebFormTemplate(new StubHandlerFactory(),
                                       () => HttpContext.Current);
        }
    }

    public class StubHandlerFactory : ModelAwareHandlerFactory
    {
        public ModelAwareHandler<ReportModel> create<ReportModel>(ReportModel model)
        {
            var raw_page = BuildManager.CreateInstanceFromVirtualPath("~/views/DepartmentBrowser.aspx",
                                                       typeof(ModelAwareHandler<ReportModel>));

            var handler = (ModelAwareHandler<ReportModel>) raw_page;
            handler.model = model;
            return handler;
        }
    }
}