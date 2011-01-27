namespace nothinbutdotnetstore.web.core
{
    public interface PathMapper
    {
        string lookup<ReportModel>(ReportModel model);
    }
}