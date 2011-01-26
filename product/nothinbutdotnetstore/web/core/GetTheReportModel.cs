using nothinbutdotnetstore.tasks;

namespace nothinbutdotnetstore.web.core
{
    public delegate ReportModel GetTheReportModel<ReportModel>(Catalog catalog,Request request);
}