using System;
using UnityEngine;

namespace Controller.Hp
{
    public class HpController
    {
        private int _hp;

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
            
            if (_hp == 0)
            {
                onDeathEvent?.Invoke();  
                
            }
        }
        
        public void Heal(int damage)
        {
            _hp += Mathf.Abs(damage);

            onHpChanged?.Invoke(Mathf.Clamp(_hp,0,100));
            
        }
    }
}