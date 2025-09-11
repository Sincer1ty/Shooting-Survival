using UnityEngine;

namespace Enemies
{
    public class EnemyManager : MonoBehaviour
    {
        public static EnemyManager Instance { get; private set; }
        
        public int enemyCount;
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
        }
        
        // private void SpawnAtRandomPoint(SpawnData spawnData)
        private void Spawn()
        {
            ++enemyCount;
        }
    }
}