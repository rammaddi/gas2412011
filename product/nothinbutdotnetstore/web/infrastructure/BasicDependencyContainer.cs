using System;
using nothinbutdotnetstore.infrastructure.containers;
namespace nothinbutdotnetstore.web.infrastructure
{
    public class BasicDependencyContainer :DependencyContainer
    {
        readonly ContractRegistry contract_registry;

        public BasicDependencyContainer(ContractRegistry contract_registry)
        {
            this.contract_registry = contract_registry;
        }

        public Dependency a<Dependency>()
        {
            Type type = contract_registry.lookup<Dependency>();
            return (Dependency)Activator.CreateInstance(type);
        }
    }
}