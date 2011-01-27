using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubSetOfCommands : IEnumerable<RequestCommand>
    {

    	public IEnumerator<RequestCommand> GetEnumerator()
        {

			yield return new DefaultRequestCommand(new CommandIncomingRequestMatcher().Match<ViewDepartmentsInDepartment>,
                                                   new ViewDepartmentsInDepartment());
			yield return new DefaultRequestCommand(new CommandIncomingRequestMatcher().Match<ViewMainDepartments>,
                                                   new ViewMainDepartments());
			yield return new DefaultRequestCommand(new CommandIncomingRequestMatcher().Match<ViewProductsInDepartment>,
                                                   new ViewProductsInDepartment());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}