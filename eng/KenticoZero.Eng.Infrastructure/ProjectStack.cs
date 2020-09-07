using Pulumi;
using Pulumi.Azure.Core;

namespace KenticoZero.Eng.Infrastructure
{
    class ProjectStack : Stack
    {
        public ProjectStack()
        {
            // Create Resource Group

            var resourceGroupName = ResourceNameFactory.Instance.CreateResourceGroupName();

            var resourceGroup = new ResourceGroup(
                resourceGroupName.LogicalName,
                new ResourceGroupArgs
                {
                    Name = resourceGroupName.PhysicalName
                }
            );
        }
    }
}
