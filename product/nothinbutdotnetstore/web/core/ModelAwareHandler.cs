using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface ModelAwareHandler<ReportModel>:IHttpHandler
    {
        ReportModel model { get; set; }
    }
}