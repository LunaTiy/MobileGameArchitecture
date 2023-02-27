using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentMoveToHero : Follow
    {
        private const float MinimalDistance = 1;
        
        [SerializeField] private NavMeshAgent _agent;
        
        private IGameFactory _gameFactory;
        private Transform _heroTransform;

        private void Start()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();

            if (_gameFactory.Hero != null)
                InitializeHeroTransform();
            else
                _gameFactory.HeroCreated += HeroCreatedHandler;
        }

        private void Update()
        {
            if (HasHeroTransform() && HeroNotReached())
                _agent.destination = _heroTransform.position;
        }

        private void HeroCreatedHandler() => 
            InitializeHeroTransform();

        private void InitializeHeroTransform() => 
            _heroTransform = _gameFactory.Hero.transform;

        private bool HasHeroTransform() => 
            _heroTransform != null;

        private bool HeroNotReached() =>
            Vector3.Distance(_agent.transform.position, _heroTransform.position) >= MinimalDistance;
    }
}