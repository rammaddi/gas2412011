using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubSetOfCommands : IEnumerable<RequestCommand>
    {
        public IEnumerator<RequestCommand> GetEnumerator()
        {
			yield return new DefaultRequestCommand(x => true,
												   new ViewMainDepartments());
			yield return new DefaultRequestCommand(x => true,
                                                   new ViewDepartmentsInDepartment());
            yield return new DefaultRequestCommand(x => true,
                                                   new ViewProductsInDepartment());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}