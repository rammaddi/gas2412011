using nothinbutdotnetstore.web.model;

namespace nothinbutdotnetstore.web.core
{
	public class LinkCommand
	{
		public static string GetName<Command>(Department department) where Command : ApplicationCommand
		{
			return typeof(Command).Name + ".invision?Department=" + department.name;
		}

		public static string GetName<Command>() where Command : ApplicationCommand
		{
			return typeof(Command).Name + ".invision";
		}
	}
}