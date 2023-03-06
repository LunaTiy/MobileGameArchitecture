using CodeBase.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(HeroAnimator), typeof(CharacterController))]
    public class HeroAttack : MonoBehaviour, ISavedProgressReader
    {
        [SerializeField] private HeroAnimator _heroAnimator;
        [SerializeField] private CharacterController _characterController;

        private IInputService _inputService;

        private readonly Collider[] _hits = new Collider[3];
        private int _layerMask;
        
        private Stats _heroStats;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
            _layerMask = 1 << LayerMask.NameToLayer("Hittable");
        }

        private void Update()
        {
            if(_inputService.IsAttackButtonUp() && !_heroAnimator.IsAttacking)
                _heroAnimator.PlayAttack();
        }

        private void OnAttack()
        {
            for (var i = 0; i < Hit(); i++)
                _hits[i].transform.parent.GetComponent<IHealth>().TakeDamage(_heroStats.damage);
        }

        public void LoadProgress(PlayerProgress progress) => 
            _heroStats = progress.heroStats;

        private int Hit() =>
            Physics.OverlapSphereNonAlloc(GetWeaponStartPoint() + transform.forward, _heroStats.attackRadius, _hits, _layerMask);

        private Vector3 GetWeaponStartPoint() =>
            new(transform.position.x, _characterController.center.y / 2, transform.position.z);
    }
}