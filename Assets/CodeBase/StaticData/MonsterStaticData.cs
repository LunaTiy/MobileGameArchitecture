using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "MonsterData", menuName = "StaticData/Monster")]
    public class MonsterStaticData : ScriptableObject
    {
        public MonsterTypeId monsterTypeId;
        
        [Range(1f, 100f)] public float maxHp;
        
        [Range(1f, 30f)] public float damage;
        [Range(0.5f, 3f)] public float attackCooldown;
        [Range(0.5f, 2f)] public float attackRange;

        public GameObject prefab;
    }
}