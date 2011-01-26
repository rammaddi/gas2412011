using System.Web.UI;

namespace nothinbutdotnetstore.web.core
{
    public class SimpleReportModelHandler<ReportModel> : Page,ModelAwareHandler<ReportModel>
    {
        public ReportModel model { get; set; }
    }
}