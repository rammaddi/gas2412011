namespace nothinbutdotnetstore.web.core
{
    public interface ModelAwareHandlerFactory
    {
        ModelAwareHandler<ReportModel> create<ReportModel>(ReportModel model);
    }
}