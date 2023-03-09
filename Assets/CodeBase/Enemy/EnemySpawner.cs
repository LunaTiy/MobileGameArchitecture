using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Logic;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(UniqueId))]
    public class EnemySpawner : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private MonsterTypeId _monsterTypeId;

        private string _id;
        [SerializeField] private bool _isSlain;

        private void Awake() => 
            _id = GetComponent<UniqueId>().id;
        
        public void LoadProgress(PlayerProgress progress)
        {
            if (progress.killData.clearedSpawners.Contains(_id))
                _isSlain = true;
            else
                Spawn();
        }

        public void SaveProgress(PlayerProgress progress)
        {
            if(_isSlain)
                progress.killData.clearedSpawners.Add(_id);
        }

        private void Spawn()
        {
            
        }
    }
}