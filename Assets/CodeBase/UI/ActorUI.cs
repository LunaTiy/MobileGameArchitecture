using System;
using CodeBase.Data;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.UI
{
    public class ActorUI : MonoBehaviour
    {
        [SerializeField] private HpBar _hpBar;

        private IHealth _health;

        public void Construct(IHealth health) =>
            _health = health
                .With(x => x.HealthChanged += HealthChangedHandler);

        private void Awake()
        {
            IHealth health = GetComponent<IHealth>();
            
            if(health != null)
                Construct(health);
        }

        private void OnDestroy() => 
            _health.HealthChanged -= HealthChangedHandler;

        private void HealthChangedHandler() => 
            _hpBar.SetValue(_health.CurrentHp, _health.MaxHp);
    }
}