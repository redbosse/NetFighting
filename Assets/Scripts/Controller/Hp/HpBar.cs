using System;
using UnityEngine;

namespace Controller.Hp
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField]
        private Animator _hpAnimator;
        
        private HpController _hpController;

        [SerializeField] private string propertyName = "time";

        private void Start()
        {
            if (_hpAnimator == null)
            {
                _hpAnimator = GetComponent<Animator>();
            }
            
        }

        public void SetHpController(HpController controller)
        {
            _hpController = controller;
        }

        public void Subscribe()
        {
            _hpController.onDeathEvent += OnDeath;
            _hpController.onHpChanged += OnHpChanged;
        }

        public void Unsubscribe()
        {
            _hpController.onDeathEvent -= OnDeath;
            _hpController.onHpChanged -= OnHpChanged;
        }
        
        void OnHpChanged(int hp)
        {
            _hpAnimator.SetFloat(propertyName, (float)hp/100f);
        }

        void OnDeath()
        {
        
        }
    }
}