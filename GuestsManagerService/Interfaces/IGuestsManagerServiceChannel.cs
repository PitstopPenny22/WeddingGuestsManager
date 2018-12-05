using GuestsShared.Interfaces;
using System.ServiceModel;

namespace GuestsManagerService.Interfaces
{
    public interface IGuestsManagerServiceChannel : IClientChannel, IGuestsService
    {
    }
}
