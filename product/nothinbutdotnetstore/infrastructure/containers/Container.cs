using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class Container
    {
        public static ContainerResolver facade_resolver = delegate
        {
            throw new NotImplementedException("This needs to be configured by the startup pipeline");
        };

        public static DependencyContainer i_need
        {
            get { return facade_resolver(); }
        }
    }
}