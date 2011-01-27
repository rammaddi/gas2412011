namespace nothinbutdotnetstore.web.core
{
    public interface PathMapper
    {
        string get_path_to_template_for<ReportModel>(ReportModel model);
    }
}