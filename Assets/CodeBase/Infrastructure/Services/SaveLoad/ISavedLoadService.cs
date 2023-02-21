using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public interface ISavedLoadService : IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}