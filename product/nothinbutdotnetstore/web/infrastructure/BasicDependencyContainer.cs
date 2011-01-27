using System;
using nothinbutdotnetstore.infrastructure.containers;
namespace nothinbutdotnetstore.web.infrastructure
{
    public class BasicDependencyContainer :DependencyContainer
    {
        readonly DependencyRegistry dependency_registry;

        public BasicDependencyContainer(DependencyRegistry dependency_registry)
        {
            this.dependency_registry = dependency_registry;
        }

        public Dependency a<Dependency>()
        {
            Type type = dependency_registry.lookup<Dependency>();
            return (Dependency)Activator.CreateInstance(type);
        }
    }
}