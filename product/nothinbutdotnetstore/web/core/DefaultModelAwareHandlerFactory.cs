using System;
using System.Collections.Generic;
using System.Web.Compilation;
using nothinbutdotnetstore.web.model;

namespace nothinbutdotnetstore.web.core
{
    public delegate object TemplateIntantiator(string template_path,Type type);

    public class DefaultModelAwareHandlerFactory : ModelAwareHandlerFactory
    {
        PathMapper pathMapper;
        TemplateIntantiator template_instantiator;
        public DefaultModelAwareHandlerFactory():this(new StubPathMapper(),BuildManager.CreateInstanceFromVirtualPath)
        {
            
        }
        public DefaultModelAwareHandlerFactory(PathMapper path_mapper, TemplateIntantiator template_instantiator)
        {
            pathMapper = path_mapper;
            this.template_instantiator = template_instantiator;
        }

        public ModelAwareHandler<ReportModel> create<ReportModel>(ReportModel model)
        {
            string path = pathMapper.lookup(model);
            var raw_page = template_instantiator(path,
                                                     typeof(ModelAwareHandler<ReportModel>));

            var handler = (ModelAwareHandler<ReportModel>)raw_page;
            handler.model = model;
            return handler;
        }
    }

    public class StubPathMapper : PathMapper
    {
        public string lookup<ReportModel>(ReportModel model)
        {
            string template = string.Empty;
            if(model.GetType() ==  typeof(IEnumerable<Department>)) 
                template = "DepartmentBrowser.aspx";
            if(model.GetType() == typeof(IEnumerable<Product>))
                template = "ProductBrowser.aspx";
            return string.Format(@"~\Views\{0}", template);


        }
    }
}