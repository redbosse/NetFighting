using UnityEngine;

namespace Controller.GamePlay
{
    public class AttackNegativeEffect : INegativeEffect
    {
        public int GetDamage()
        {
            return Random.Range(6,16);
        }
    }
}