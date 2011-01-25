using System;
using nothinbutdotnetstore.specs.web.core;

namespace nothinbutdotnetstore.web.core
{
    public class ViewMainDepartments : ApplicationCommand
    {
        DepartmentsDataAccessor dataAccessor;
        Renderer renderer;

        public ViewMainDepartments(DepartmentsDataAccessor data_accessor, Renderer renderer)
        {
            this.dataAccessor = data_accessor;
            this.renderer = renderer;
        }
        public void run(Request request)
        {
            dataAccessor.getMainDepartments();
        }
    }
}