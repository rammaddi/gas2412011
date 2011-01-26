using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.model
{
    public class Department
    {
        public string name { get; set; }
		public string url { get { return typeof(ViewDepartmentsInDepartment).Name + ".invision?Department=" + name; } }
	}
}