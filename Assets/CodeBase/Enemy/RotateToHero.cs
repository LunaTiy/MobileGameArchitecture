using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class RotateToHero : Follow
    {
        [SerializeField] private float _speed;
        
        private IGameFactory _gameFactory;
        private Transform _heroTransform;
        private Vector3 _positionToLook;

        private void Start()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();

            if (IsHeroExists())
                InitializeHeroTransform();
            else
                _gameFactory.HeroCreated += InitializeHeroTransform;
        }

        private void Update()
        {
            if (IsInitializedHeroTransform())
                RotateTowardsHero();
        }

        private bool IsInitializedHeroTransform() => 
            _heroTransform != null;

        private void RotateTowardsHero()
        {
            UpdatePositionToLookAt();
            transform.rotation = SmoothedRotation(transform.rotation, _positionToLook);
        }

        private void UpdatePositionToLookAt()
        {
            Vector3 positionDiff = _heroTransform.position - transform.position;
            _positionToLook = new Vector3(positionDiff.x, transform.position.y, positionDiff.z);
        }

        private Quaternion SmoothedRotation(Quaternion rotation, Vector3 positionToLook) => 
            Quaternion.Lerp(rotation, TargetRotation(positionToLook), SpeedFactor());

        private bool IsHeroExists() => 
            _gameFactory.Hero != null;

        private void InitializeHeroTransform() => 
            _heroTransform = _gameFactory.Hero.transform;

        private float SpeedFactor() => 
            _speed * Time.deltaTime;

        private static Quaternion TargetRotation(Vector3 positionToLook) => 
            Quaternion.LookRotation(positionToLook);
    }
}