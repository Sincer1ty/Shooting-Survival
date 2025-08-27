using UnityEngine;

namespace Enemies
{
    public class NormalEnemy : EnemyBase
    {
        public override EnemyType Type => EnemyType.Normal;
        
        // public override void Attack() {}
        // 시작할 때 HP 초기화
        private void Start()
        {
            hp = 5f;
        }

        public override void Damage()
        {
            Debug.Log($"{gameObject.name} 데미지 : HP {hp}");
            hp -= 1f;
            if (hp <= 0f)
            {
                // 사망
                Destroy(gameObject);
            }
        }
    }
}