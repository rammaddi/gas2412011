 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web.core
{   
    public class RendererSpecs
    {
        public abstract class concern : Observes<Renderer,
                                            DefaultRenderer>
        {
        
        }

        [Subject(typeof(DefaultRenderer))]
        public class when_displaying_a_report_model : concern
        {
            Establish c = () =>
            {
                template_registry = the_dependency<TemplateRegistry>();
                template = an<Template>();

                template_registry.Stub(x => x.find_template())
                    .Return(template);

            };

            Because b = () =>
                sut.display(23);



            It should_tell_the_template_to_render_the_model = () =>
                template.received(x => x.render(23));

  

            static TemplateRegistry template_registry;
            static Template template;
        }
    }
}
