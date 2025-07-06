namespace Enemies
{
    public class NormalEnemy : EnemyBase
    {
        public override EnemyType Type => EnemyType.Normal;
        
        // public override void Attack() {}
        // 시작할 때 HP 초기화
        private void Start()
        {
            hp = 10f;
        }

        public override void Damage()
        {
            hp -= 1f;
        }
    }
}