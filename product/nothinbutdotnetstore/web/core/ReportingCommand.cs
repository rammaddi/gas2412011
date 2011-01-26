using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class ReportingCommand<ViewDataType> : ApplicationCommand
    {
        GetTheReportModel<ViewDataType> query_method;
        Renderer renderer;
        Catalog catalog;

        public ReportingCommand(GetTheReportModel<ViewDataType> query_method):this(query_method, 
            new StubRenderer(),new StubCatalog())
        {
        }

        public ReportingCommand(GetTheReportModel<ViewDataType> query_method, Renderer renderer, Catalog catalog)
        {
            this.query_method = query_method;
            this.catalog = catalog;
            this.renderer = renderer;
        }

        public void run(Request request)
        {
            renderer.display(query_method(catalog, request));
        }
    }
}