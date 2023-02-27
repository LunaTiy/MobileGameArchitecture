using System.Linq;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(EnemyAnimator))]
    public class Attack : MonoBehaviour
    {
        [SerializeField] private EnemyAnimator _animator;
        [SerializeField] private float _attackCooldown = 2f;
        [SerializeField] private float _attackRange = 0.5f;
        [SerializeField] private float _weaponHitBoxRadius = 0.5f;
        [SerializeField] private float _weaponYOffset = 0.5f;

        private readonly Collider[] _hits = new Collider[1];

        private IGameFactory _gameFactory;
        private Transform _heroTransform;

        private float _elapsedCooldownTime;
        private bool _isAttacking;
        private int _layerMask;
        
        private bool _isActiveAttack;

        private void Start()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();
            _layerMask = 1 << LayerMask.NameToLayer("Player");

            if (_gameFactory.Hero != null)
                InitializeHeroTransform();
            else
                _gameFactory.HeroCreated += InitializeHeroTransform;
        }

        private void Update()
        {
            UpdateCooldown();

            if (CanAttack())
                StartAttack();
        }

        // Using from animation attack
        private void OnAttack()
        {
            if (Hit(out Collider hit))
            {
                DrawDebugTools.DrawSphere(GetWeaponStartPoint(), _weaponHitBoxRadius, 1f, Color.red);
            }
        }

        // Using from animation attack
        private void OnAttackEnded()
        {
            _elapsedCooldownTime = 0f;
            _isAttacking = false;
        }

        public void EnableAttack() => _isActiveAttack = true;

        public void DisableAttack() => _isActiveAttack = false;

        private bool Hit(out Collider hit)
        {
            int hitsCount = Physics.OverlapSphereNonAlloc(GetWeaponStartPoint(), _weaponHitBoxRadius, _hits, _layerMask);
            hit = _hits.FirstOrDefault();

            return hitsCount > 0;
        }

        private Vector3 GetWeaponStartPoint() =>
            new Vector3(transform.position.x, transform.position.y + _weaponYOffset, transform.position.z) +
            transform.forward * _attackRange;

        private void UpdateCooldown()
        {
            if (!IsUpCooldown())
                _elapsedCooldownTime += Time.deltaTime;
        }

        private bool CanAttack() =>
            _isActiveAttack && !_isAttacking && IsUpCooldown();

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