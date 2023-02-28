using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(HeroAnimator))]
    public class HeroHealth : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private HeroAnimator _heroAnimator;
        
        private State _state;

        public float CurrentHp
        {
            get => _state.currentHp;
            set => _state.currentHp = value;
        }

        public float MaxHp
        {
            get => _state.maxHp;
            set => _state.maxHp = value;
        }

        public void GetDamage(float damage)
        {
            if (CurrentHp <= 0)
                return;
            
            CurrentHp -= damage;
            _heroAnimator.PlayHit();
        }

        public void LoadProgress(PlayerProgress progress)
        {
            _state = progress.heroState;
        }

        public void SaveProgress(PlayerProgress progress)
        {
            progress.heroState.currentHp = CurrentHp;
            progress.heroState.maxHp = MaxHp;
        }
    }
}