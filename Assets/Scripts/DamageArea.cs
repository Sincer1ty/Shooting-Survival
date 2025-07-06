using Enemies;
using UnityEngine;

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