namespace nothinbutdotnetstore.web.core
{
    public class DefaultRenderer : Renderer
    {
        TemplateRegistry template_registry;

        public DefaultRenderer(TemplateRegistry template_registry)
        {
            this.template_registry = template_registry;
        }

        public void display<DisplayModel>(DisplayModel item)
        {
            template_registry.find_template().render(item);
        }
    }
}