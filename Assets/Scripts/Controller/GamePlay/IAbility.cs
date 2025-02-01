using System;
using Unity.VisualScripting;

namespace Controller.GamePlay
{
    public interface IAbility
    {
        public event Action OnEndAbilityEvent; 
        public event Action OnCustomActionEvent; 
        public void UseAbility();
    
        public float AbilityTime();
        
        public void InvokeAction();
        
        public INegativeEffect NegativeEffect();
        public void OnEndAbility();
        

        public void Update(float deltaTime);
    }
}