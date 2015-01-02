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

            SetupCustom();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            if (Client != null)
            {
                Client = null;
            }

            TearDownCustom();
        }

        protected virtual void SetupCustom() { }

        protected virtual void TearDownCustom() { }
    }
}
