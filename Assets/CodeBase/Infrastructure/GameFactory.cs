using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameObject CreateHero(Vector3 position) => 
            _assetProvider.Instantiate(AssetPath.HeroPath, position);

        public void CreateHud() => 
            _assetProvider.Instantiate(AssetPath.HudPath);
    }
}