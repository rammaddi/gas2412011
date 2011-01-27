namespace nothinbutdotnetstore.web.core
{
    public class StubPathMapper : PathMapper
    {
        public string get_path_to_template_for<ReportModel>(ReportModel model)
        {
            return "~/views/DepartmentBrowser.aspx";
        }
    }
}