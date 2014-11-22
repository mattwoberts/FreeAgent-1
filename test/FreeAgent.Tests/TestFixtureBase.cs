using NUnit.Framework;
using System.Threading.Tasks;

namespace FreeAgent.Tests
{
    [TestFixture]
    public abstract class TestFixtureBase
    {
        protected FreeAgentClient Client;

        [TestFixtureSetUp]
        public void Setup()
        {
            if (Client == null)
            {
                Client = new FreeAgentClient(Helper.Configuration());
                Client.RenewAccessIfRequired().Wait();
            }
        }

    }
}
