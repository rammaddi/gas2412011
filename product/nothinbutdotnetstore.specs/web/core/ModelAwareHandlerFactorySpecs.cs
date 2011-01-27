 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web.core
{   
    public class ModelAwareHandlerFactorySpecs
    {
        public abstract class concern : Observes<ModelAwareHandlerFactory,
                                            DefaultModelAwareHandlerFactory>
        {
        
        }

        [Subject(typeof(DefaultModelAwareHandlerFactory))]
        public class when_getting_model_aware_handler : concern
        {
            Establish c = () => {
               model = 23;
               int_handler = an<ModelAwareHandler<int>>();
               provide_a_basic_sut_constructor_argument<TemplateIntantiator>((x,type) => int_handler);
               mapper = the_dependency<PathMapper>();
                                    mapper.Stub(x => x.lookup(model)).Return("~/views/DepartmentBrowser.aspx");
            };

            Because b = () =>
                handler = sut.create(model);

            It should_call_the_mapper_to_get_the_correct_path_by_model = () =>
                  mapper.received(x => x.lookup(model));

            It should_return_model_aware_handler = () =>
                handler.ShouldBeAn<ModelAwareHandler<int>>();
            

            static int model;
            static ModelAwareHandler<int> handler;
            static PathMapper mapper;
            static TemplateIntantiator template_instantiator;
            static ModelAwareHandler<int> int_handler;
        }
    }
}
