using Eventify.IntegrationTests.Config.Fixtures;

namespace Eventify.IntegrationTests.Config.Collections
{
    [CollectionDefinition("InfraLayerCollection")]
    public class InfraLayerCollection : ICollectionFixture<InfraLayerFixture>
    {
        // This class has no code, and is never created. Its purpose is simply to be the place to apply [CollectionDefinition] and all the ICollectionFixture<> interfaces.
    }
}
