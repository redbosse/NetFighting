using System;
using Controller.Player;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class VisualizeActions : MonoBehaviour
    {
        [SerializeField]
        private Renderer _renderer;

        [SerializeField]
        Ease _easeType = Ease.Linear;
        
        [SerializeField]
        float _duration = 0.5f;
        
        [SerializeField]
        NetworkPlayer _player;

        private void Start()
        {
            if (_renderer == null)
            {
                _renderer = GetComponent<Renderer>();
            }
        }

        private void OnEnable()
        {
            _player.OnAttackedEvent += OnAttack;
            _player.OnDamageEvent += OnDamage;
            _player.OnDeathEvent += OnDeath;


        }

        private void OnDisable()
        {
            _player.OnAttackedEvent -= OnAttack;
            _player.OnDamageEvent -= OnDamage;
            _player.OnDeathEvent -= OnDeath;
        }

        void OnAttack()
        {
            transform.DOPunchScale(Vector3.one * 0.6f,_duration).SetEase(_easeType);
        }

        void OnDamage()
        {
            transform.DOPunchPosition(Vector3.up * 0.5f,_duration).SetEase(_easeType);
        }

        void OnDeath()
        {
            
            transform.DOPunchScale(Vector3.one * 0.1f,_duration).SetEase(_easeType);
        }
    }
}