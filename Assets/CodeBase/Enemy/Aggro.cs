using UnityEngine;

namespace CodeBase.Enemy
{
    public class Aggro : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private AgentMoveToHero _follow;

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
        

        private void TriggerEnteredHandler(Collider obj) => 
            SwitchFollowOn();

        private void TriggerExitedHandler(Collider obj) => 
            SwitchFollowOff();

        private void SwitchFollowOn() => 
            _follow.enabled = true;

        private void SwitchFollowOff() => 
            _follow.enabled = false;
    }
}