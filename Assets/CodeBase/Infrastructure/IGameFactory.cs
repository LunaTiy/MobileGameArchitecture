using UnityEngine;

namespace CodeBase.Infrastructure
{
    public interface IGameFactory
    {
        GameObject CreateHero(Vector3 position);
        void CreateHud();
    }
}