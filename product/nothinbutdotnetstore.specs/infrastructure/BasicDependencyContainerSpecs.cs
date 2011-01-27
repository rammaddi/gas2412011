 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers;
 using nothinbutdotnetstore.web.infrastructure;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.infrastructure
{   
    public class BasicDependencyContainerSpecs
    {
        public abstract class concern : Observes<DependencyContainer,
                                            BasicDependencyContainer>
        {
        
        }

        [Subject(typeof(BasicDependencyContainer))]
        public class when_fetch_a_dependency : concern
        {
            Establish e = () =>
            {
                dependency_registry = the_dependency<DependencyRegistry>();
                dependency_registry.Stub(x => x.lookup<IDummy>()).Return(typeof(Dummy));
            };

            Because b = () =>
                result = sut.a<IDummy>();
                
            It should_look_up_in_contract_registry = () =>
                dependency_registry.received(x => x.lookup<IDummy>());

            It should_have_dependency = () =>
                result.ShouldBeAn<Dummy>();

            static IDummy result,expected;
            static DependencyRegistry dependency_registry;
        }
        
    }

    interface IDummy
    {

    }

    public class Dummy:IDummy
    {
    

    }
}
