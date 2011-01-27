using System;
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
            Establish c = () =>
            {
                model = 23;
                path_to_view = "Blah.aspx";
                expected_buildmanager_args = new FactoryArgs{page_type = typeof(ModelAwareHandler<int>),
                    path = path_to_view};
                int_handler = an<ModelAwareHandler<int>>();
                provide_a_basic_sut_constructor_argument<TemplateFactory>((incoming_path,view_type) =>
                {
                    actual_args = new FactoryArgs{page_type = view_type,
                        path = incoming_path};
                    return int_handler;
                });
                mapper = the_dependency<PathMapper>();
                mapper.Stub(x => x.get_path_to_template_for(model)).Return(path_to_view);
            };

            Because b = () =>
                handler = sut.create(model);

            It should_correctly_dispatch_the_call_to_the_page_factory = () =>
                expected_buildmanager_args.equals(actual_args);

  
            It should_call_the_mapper_to_get_the_correct_path_by_model = () =>
                mapper.received(x => x.get_path_to_template_for(model));

            It should_return_model_aware_handler = () =>
                handler.ShouldBeAn<ModelAwareHandler<int>>();

            static int model;
            static ModelAwareHandler<int> handler;
            static PathMapper mapper;
            static TemplateFactory template_instantiator;
            static ModelAwareHandler<int> int_handler;
            static string path_to_view;
            static FactoryArgs expected_buildmanager_args;
            static FactoryArgs actual_args;
        }

        class FactoryArgs 
        {
            public string path { get; set; }
            public Type page_type { get; set; }

            public void equals(FactoryArgs other)
            {
                this.path.ShouldEqual(other.path);
                this.page_type.ShouldEqual(other.page_type);

            }
        }
    }
}