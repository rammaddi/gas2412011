using System;
using System.Web.Compilation;

namespace nothinbutdotnetstore.web.core
{
    public delegate object TemplateFactory(string template_path,Type type);

    public class DefaultModelAwareHandlerFactory : ModelAwareHandlerFactory
    {
        PathMapper path_registry;
        TemplateFactory template_factory;

        public DefaultModelAwareHandlerFactory():this(new StubPathMapper(),BuildManager.CreateInstanceFromVirtualPath)
        {
            
        }
        public DefaultModelAwareHandlerFactory(PathMapper path_registry, TemplateFactory template_factory)
        {
            this.path_registry = path_registry;
            this.template_factory = template_factory;
        }

        public ModelAwareHandler<ReportModel> create<ReportModel>(ReportModel model)
        {
            var path = path_registry.get_path_to_template_for(model);
            var raw_page = template_factory(path, typeof(ModelAwareHandler<ReportModel>));

            var handler = (ModelAwareHandler<ReportModel>)raw_page;
            handler.model = model;
            return handler;
        }
    }
}