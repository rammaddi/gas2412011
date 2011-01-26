using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRenderer : Renderer
    {
        public void display<DisplayModel>(DisplayModel item)
        {
            HttpContext.Current.Items.Add("blah",item );
            HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx",true);
        }
    }
}