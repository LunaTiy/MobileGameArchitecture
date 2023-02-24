using System;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(NavMeshAgent), typeof(EnemyAnimator))]
    public class AnimateAlongAgent : MonoBehaviour
    {
        private const float MinimalVelocity = 0.1f;
        
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private EnemyAnimator _enemyAnimator;

        private void Update()
        {
            if(ShouldMove())
                _enemyAnimator.Move(_navMeshAgent.velocity.magnitude);
            else
                _enemyAnimator.StopMoving();
        }

        private bool ShouldMove() => 
            _navMeshAgent.velocity.magnitude > MinimalVelocity && _navMeshAgent.remainingDistance > _navMeshAgent.radius;
    }
}