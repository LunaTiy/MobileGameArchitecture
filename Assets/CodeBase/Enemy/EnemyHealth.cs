using System;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        public event Action HealthChanged;
        
        [SerializeField] private EnemyAnimator _animator;
        [SerializeField] private float _currentHp;
        [SerializeField] private float _maxHp;

        public float CurrentHp
        {
            get => _currentHp;
            set => _currentHp = value;
        }

        public float MaxHp
        {
            get => _maxHp;
            set => _maxHp = value;
        }

        public void TakeDamage(float damage)
        {
            CurrentHp -= damage;
            _animator.PlayHit();
            HealthChanged?.Invoke();
        }
    }
}