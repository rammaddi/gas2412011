using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class Container
    {
        public static ContainerResolver facade_resolver = delegate
        {
            throw new NotImplementedException("This needs to be configured by the startup pipeline");
        };

        public static DependencyContainer fetch
        {
            get { return facade_resolver(); }
        }
    }
}