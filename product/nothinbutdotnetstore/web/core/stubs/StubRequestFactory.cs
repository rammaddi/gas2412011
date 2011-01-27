using System;
using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {

        public Request create(HttpContext the_incoming_context)
        {
            return new StubRequest();
        }

        class StubRequest : Request
        {
			string command = "ViewMainDepartments";
			
			public InputModel map<InputModel>()
            {
				throw new NotImplementedException();
            }

        	public string CommandName
        	{
				get { return command; }
				set { command = value; }
        	}
        }
    }
}