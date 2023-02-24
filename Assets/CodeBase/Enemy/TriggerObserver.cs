using System;
using UnityEngine;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(Collider))]
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider> triggerEntered;
        public event Action<Collider> triggerExited;
        private void OnTriggerEnter(Collider other) => 
            triggerEntered?.Invoke(other);

        private void OnTriggerExit(Collider other) => 
            triggerExited?.Invoke(other);
    }
}