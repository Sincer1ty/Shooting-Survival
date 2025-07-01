using UnityEngine;

namespace Enemies
{
    public enum EnemyType
    {
        Normal,
        Boss
    }

    public abstract class EnemyBase : MonoBehaviour
    {
        protected float hp;
        
        public abstract EnemyType Type { get; }
        
        // public abstract void Attack();
        // public abstract void Damage();
    }
}