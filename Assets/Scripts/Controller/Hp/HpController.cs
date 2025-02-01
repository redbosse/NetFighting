using System;
using UnityEngine;

namespace Controller.Hp
{
    public class HpController
    {
        [SerializeField]
        private int _hp = 100;

        public event Action onDeathEvent;
        public event  Action<int> onHpChanged;

        public int HitPoint
        {
            get { return _hp; }
            set { _hp = Mathf.Clamp(value,0,100); }
        }

        public void ResetHp()
        {
            _hp = 100;
            
            onHpChanged?.Invoke(100);
        }

        public void Damage(int damage)
        {
            _hp -= Mathf.Abs(damage);

            onHpChanged?.Invoke(Mathf.Clamp(_hp,0,100));
            
            if (_hp <= 0)
            {
                onDeathEvent?.Invoke();  
                
            }
        }
        
        public void Heal(int heal)
        {
            _hp += Mathf.Abs(heal);

            onHpChanged?.Invoke(Mathf.Clamp(_hp,0,100));
            
        }
    }
}