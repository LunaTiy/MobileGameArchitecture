using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class Attack : MonoBehaviour
    {
        [SerializeField] private float _attackCooldown = 2f;
        [SerializeField] private EnemyAnimator _animator;

        private IGameFactory _gameFactory;
        private Transform _heroTransform;

        private float _elapsedCooldownTime;
        private bool _isAttacking;

        private void Start()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();

            if (_gameFactory.Hero != null)
                InitializeHeroTransform();
            else
                _gameFactory.HeroCreated += InitializeHeroTransform;
        }

        private void Update()
        {
            UpdateCooldown();

            if(CanAttack())
                StartAttack();
        }

        private void AttackHandler()
        {
        }

        private void AttackEndedHandler()
        {
            _elapsedCooldownTime = 0f;
            _isAttacking = false;
        }

        private void UpdateCooldown()
        {
            if (!IsUpCooldown())
                _elapsedCooldownTime += Time.deltaTime;
        }

        private bool CanAttack() => 
            !_isAttacking && IsUpCooldown();

        private bool IsUpCooldown() => 
            _elapsedCooldownTime >= _attackCooldown;

        private void StartAttack()
        {
            transform.LookAt(_heroTransform);
            _animator.PlayAttack();

            _isAttacking = true;
        }

        private void InitializeHeroTransform() => 
            _heroTransform = _gameFactory.Hero.transform;
    }
}