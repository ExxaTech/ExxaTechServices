using System.Threading.Tasks;

namespace Microsoft.ExxaTechServices.BuildingBlocks.EventBus.Abstractions
{
    public interface IDynamicIntegrationEventHandler
    {
        Task Handle(dynamic eventData);
    }
}
