using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(EnemyHealth), typeof(EnemyAnimator))]
    public class EnemyDeath : MonoBehaviour
    {
        public event Action OnDie;
            
        [SerializeField] private EnemyHealth _health;
        [SerializeField] private EnemyAnimator _animator;
        [SerializeField] private Follow _follow;
        [SerializeField] private GameObject _deathFx;
        [SerializeField] private Vector3 _fxOffset;
        [SerializeField] private float _delayToDestroy = 3f;

        private void OnEnable() => 
            _health.HealthChanged += HealthChangedHandler;

        private void OnDisable() => 
            _health.HealthChanged -= HealthChangedHandler;

        private void HealthChangedHandler()
        {
            if (_health.CurrentHp <= 0) 
                Die();
        }

        private void Die()
        {
            _health.HealthChanged -= HealthChangedHandler;
            _animator.PlayDeath();
            _follow.enabled = false;

            CreateDeathFx();
            StartCoroutine(DestroyRoutine());
            
            OnDie?.Invoke();
        }

        private void CreateDeathFx() => 
            Instantiate(_deathFx, transform.position + _fxOffset, Quaternion.identity);

        private IEnumerator DestroyRoutine()
        {
            yield return new WaitForSeconds(_delayToDestroy);
            Destroy(gameObject);
        }
    }
}