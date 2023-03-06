using UnityEngine;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(Attack))]
    public class CheckAttackRange : MonoBehaviour
    {
        [SerializeField] private Attack _attack;
        [SerializeField] private TriggerObserver _triggerObserver;

        private void OnEnable()
        {
            _triggerObserver.triggerEntered += TriggerEnteredHandler;
            _triggerObserver.triggerExited += TriggerExitedHandler;

            _attack.DisableAttack();
        }

        private void TriggerEnteredHandler(Collider obj) => 
            _attack.EnableAttack();

        private void TriggerExitedHandler(Collider obj) => 
            _attack.DisableAttack();
    }
}