using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(HeroHealth))]
    public class HeroDeath : MonoBehaviour
    {
        [SerializeField] private HeroHealth _health;
        [SerializeField] private HeroMover _heroMover;
        [SerializeField] private HeroAnimator _heroAnimator;
        
        [SerializeField] private GameObject _deathFx;
        [SerializeField] private Vector3 _fxOffset;
        
        private bool _isDead;

        private void OnEnable() => 
            _health.healthChanged += HealthChangedHandler;

        private void OnDisable() => 
            _health.healthChanged -= HealthChangedHandler;

        private void HealthChangedHandler()
        {
            if (CanDie())
                Die();
        }

        private bool CanDie() => 
            !_isDead && _health.CurrentHp <= 0;

        private void Die()
        {
            _isDead = true;
            _heroMover.enabled = false;
            _heroAnimator.PlayDeath();

            Instantiate(_deathFx, transform.position + _fxOffset, Quaternion.identity);
        }
    }
}