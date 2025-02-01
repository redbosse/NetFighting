using System;
using UnityEngine;

namespace Controller.Hp
{
    [RequireComponent(typeof(Renderer))]
    public class HpBar : MonoBehaviour
    {
        [SerializeField]
        private Animator _hpAnimator;
        
        private string _propertyName = "time";
        private string _materialPropertyName = "_time";
        
        private HpController _hpController;
        
        private Renderer _renderer;
        
        private void Start()
        {
            if (_hpAnimator == null)
            {
                _hpAnimator = GetComponent<Animator>();
            }

            if (_renderer == null)
            {
                _renderer = GetComponent<Renderer>();
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
            float hpPercent = Mathf.Lerp(0.999f,0.001f,(float)hp/100f);
            
            _renderer.material.SetFloat(_materialPropertyName, 1.0f - hpPercent);
            _hpAnimator.SetFloat(_propertyName, hpPercent);
        }

        void OnDeath()
        {
        
        }
    }
}