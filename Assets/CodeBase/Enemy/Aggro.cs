using System.Collections;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class Aggro : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private AgentMoveToHero _follow;
        [SerializeField] private float _cooldown = 3f;

        private Coroutine _aggroCoroutine;
        private bool _hasAggroTarget;

        private void OnEnable()
        {
            _triggerObserver.triggerEntered += TriggerEnteredHandler;
            _triggerObserver.triggerExited += TriggerExitedHandler;
            
            SwitchFollowOff();
        }

        private void OnDisable()
        {
            _triggerObserver.triggerEntered -= TriggerEnteredHandler;
            _triggerObserver.triggerExited -= TriggerExitedHandler;

            SwitchFollowOff();
        }

        private void TriggerEnteredHandler(Collider obj)
        {
            if (_hasAggroTarget)
                return;

            _hasAggroTarget = true;
            StopRoutine();
            SwitchFollowOn();
        }

        private void TriggerExitedHandler(Collider obj)
        {
            if (!_hasAggroTarget)
                return;

            _hasAggroTarget = false;
            _aggroCoroutine = StartCoroutine(StopFollowRoutine());
        }

        private void StopRoutine()
        {
            if (_aggroCoroutine == null)
                return;
            
            StopCoroutine(_aggroCoroutine);
            _aggroCoroutine = null;
        }

        private IEnumerator StopFollowRoutine()
        {
            yield return new WaitForSeconds(_cooldown);
            SwitchFollowOff();
        }

        private void SwitchFollowOn() => 
            _follow.enabled = true;

        private void SwitchFollowOff() => 
            _follow.enabled = false;
    }
}