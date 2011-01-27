using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class ContainerSpecs
    {
        public abstract class concern : Observes
        {
        }

        [Subject(typeof(Container))]
        public class when_accessing_container_services : concern
        {
            Establish c = () =>
            {
                the_underlying_container = an<DependencyContainer>();
                ContainerResolver resolver = () => the_underlying_container;
                change(() => Container.facade_resolver).to(resolver);

            };


            Because b = () =>
                result = Container.fetch;

            It should_provide_access_to_the_underlying_container_facade = () =>
                result.ShouldEqual(the_underlying_container);

            static DependencyContainer result;
            static DependencyContainer the_underlying_container;
        }
    }
}