using nothinbutdotnetstore.tasks;

namespace nothinbutdotnetstore.web.core
{
    public delegate TReportModel GetTheReportModel<TReportModel>(Catalog catalog,Request request);
}