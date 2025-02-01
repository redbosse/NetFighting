using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller.GamePlay
{
    public class Ability: MonoBehaviour
    {
        private IAbility _currentAbility;
        
        public event Action<IAbility> AbilityAction;
        public event Action OnEndAbilityAction;


        public void ClearAbility()
        {
            if (_currentAbility != null)
            {
                _currentAbility.OnEndAbilityEvent -= OnEndAbillity;
                _currentAbility.OnCustomActionEvent -= AbilityActionCustom;
            
               _currentAbility = null;
            }
            
        }

        public void StartAbility(IAbility ability)
        {
            
            
            _currentAbility = ability;

            _currentAbility.UseAbility();
            
            _currentAbility.OnEndAbilityEvent += OnEndAbillity;
            _currentAbility.OnCustomActionEvent += AbilityActionCustom;
            
            
            
        }

        public void AbilityActionCustom()
        {
            
            AbilityAction?.Invoke(_currentAbility);
        }

        public void OnEndAbillity()
        {
           
            _currentAbility.OnEndAbilityEvent -= OnEndAbillity;
            _currentAbility.OnCustomActionEvent -= AbilityActionCustom;
            
            OnEndAbilityAction?.Invoke();
            
            _currentAbility = null;
        }

        private void Update()
        {
            if (_currentAbility != null)
            {
                _currentAbility.Update(Time.deltaTime);
                
            }
        }
    }
}