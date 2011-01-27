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
                contract_registry = the_dependency<ContractRegistry>();
                
                contract_registry.Stub(x => x.lookup<IDummy>()).Return(typeof(Dummy));
            };

            Because b = () =>
                actual = sut.a<IDummy>();
                
            It should_look_up_in_contract_registry = () =>
                contract_registry.received(x => x.lookup<IDummy>());

            It should_have_dependency = () =>
                actual.ShouldBeOfType(typeof(Dummy));

            static IDummy actual,expected;
            static ContractRegistry contract_registry;
        }
        
    }

    interface IDummy
    {

    }

    public class Dummy:IDummy
    {
    

    }
}
