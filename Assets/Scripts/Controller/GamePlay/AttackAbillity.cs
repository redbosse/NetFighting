
using System;
using Random = UnityEngine.Random;

namespace Controller.GamePlay
{
    public class AttackAbillity : IAbility // И так реализуем всё остальное
    {
        private INegativeEffect _negativeEffect;

        private float _delay = 2f;
        private float _timer = 0;

        public event Action OnEndAbilityEvent;
        public event Action OnCustomActionEvent;

        public void UseAbility()
        {
            _timer = Random.Range(1f, _delay);
        }
        
        public float AbilityTime()
        {
            return _timer;
        }

        public void InvokeAction()
        {
            OnCustomActionEvent?.Invoke();
        }

        public INegativeEffect NegativeEffect()
        {
            return new AttackNegativeEffect();
        }

        public void OnEndAbility()
        {
            OnEndAbilityEvent?.Invoke();
        }


        public void Update(float deltaTime)
        {
            _timer -= deltaTime;

            if (_timer < 0)
            {
                InvokeAction();
                OnEndAbility();
            }
        }
    }
}