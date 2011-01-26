namespace nothinbutdotnetstore.web.core
{
    public interface Template
    {
        void render<ReportModel>(ReportModel report_model);
    }
}