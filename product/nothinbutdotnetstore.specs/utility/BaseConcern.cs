using NUnit.Framework;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.utility
{
    [TestFixture]
    public abstract class BaseConcern<ItemToTest>
    {
        protected ItemToTest sut;

        [SetUp]
        public void setup()
        {
            arrange();
            sut = create_sut();
            act();
        }

        protected abstract ItemToTest create_sut();
        protected abstract void act();

        protected Dependency an<Dependency>() where Dependency : class
        {
            return MockRepository.GenerateStub<Dependency>();
        }

        protected virtual void arrange()
        {
        }
    }
}