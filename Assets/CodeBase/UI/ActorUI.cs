using CodeBase.Data;
using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.UI
{
    public class ActorUI : MonoBehaviour
    {
        [SerializeField] private HpBar _hpBar;

        private HeroHealth _health;

        public void Construct(HeroHealth health)
        {
            _health = health
                .With(x => x.healthChanged += HealthChangedHandler);
        }

        private void OnDestroy() => 
            _health.healthChanged -= HealthChangedHandler;

        private void HealthChangedHandler() => 
            _hpBar.SetValue(_health.CurrentHp, _health.MaxHp);
    }
}