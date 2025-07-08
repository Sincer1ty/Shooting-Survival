using UnityEngine;

namespace Enemies
{
    public class DamageArea : MonoBehaviour
    {
        [HideInInspector] public EnemyBase enemy;

        void Awake()
        {
            enemy = GetComponentInParent<EnemyBase>();
        }

        public void OnDamage()
        {
            enemy.Damage();
        }
    }
}