using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MbDotNet.Tests.Client
{
    [TestClass]
    public class CreateHttpsImposterTests : MountebankClientTestBase
    {
        [TestMethod]
        public void ShouldNotAddNewImposterToCollection()
        {
            Client.CreateHttpsImposter(123);
            Assert.AreEqual(0, Client.Imposters.Count);
        }
        
        [TestMethod]
        public void WithoutName_SetsNameToNull()
        {
            var imposter = Client.CreateHttpsImposter(123);
            
            Assert.IsNotNull(imposter);
            Assert.IsNull(imposter.Name);
        }

        [TestMethod]
        public void WithName_SetsName()
        {
            const string expectedName = "Service";

            var imposter = Client.CreateHttpsImposter(123, expectedName);
            
            Assert.IsNotNull(imposter);
            Assert.AreEqual(expectedName, imposter.Name);
        }

        [TestMethod]
        public void WithKey_SetsKey()
        {
            const string expectedKey = "key";

            var imposter = Client.CreateHttpsImposter(123, null, expectedKey);

            Assert.IsNotNull(imposter);
            Assert.AreEqual(expectedKey, imposter.Key);
        }

        [TestMethod]
        public void WithCert_SetsCert()
        {
            const string expectedCert = "cert";

            var imposter = Client.CreateHttpsImposter(123, null, null, expectedCert);

            Assert.IsNotNull(imposter);
            Assert.AreEqual(expectedCert, imposter.Cert);
        }

        [TestMethod]
        public void WithoutPortAndName_SetsPortAndNameToNull()
        {
            var imposter = Client.CreateHttpsImposter();

            Assert.IsNotNull(imposter);
            Assert.IsNull(imposter.Port);
            Assert.IsNull(imposter.Name);
        }
    }
}