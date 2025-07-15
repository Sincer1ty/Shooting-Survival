using System.Collections.Generic;
using Enemies;
using Skills;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Camera _mainCamera;
    
    private Dictionary<KeyCode, ISkill> _skills;
    
    public bool isAttacking = false;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _mainCamera = Camera.main;
    }

    private void Start()
    {
        _skills = new Dictionary<KeyCode, ISkill>
        {
            { KeyCode.Q, new SkillQ() },
            { KeyCode.W, new SkillW() },
            { KeyCode.E, new SkillE() },
            { KeyCode.R, new SkillR() }
        };
    }

    void Update()
    {
        // 우클릭 : 이동
        if (Input.GetMouseButton(1))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                _agent.SetDestination(hit.point);
            }
        }
        // 좌클릭 : 공격
        else if (Input.GetMouseButtonDown(0))
        {
            // 공격 함수
            Attack();
        }
        
        // 스킬
        foreach (var skillPair in _skills)
        {
            if (Input.GetKeyDown(skillPair.Key))
            {
                skillPair.Value.Use();
            }
        }
    }
    
    // 원거리시 : 총알, 화살 등에 부착
    // private void OnTriggerEnter(Collider other)
    // {
    //     var victim = other.gameObject;
    //     var damageArea = victim.GetComponent<DamageArea>();
    //     if (damageArea != null)
    //     {
    //         damageArea.OnDamage();
    //     }
    // }
    
    // 근거리시
    private void OnTriggerEnter(Collider other)
    {
        if (!isAttacking) return; // 공격 중이 아니면 무시
        
        var victim = other.gameObject;
        var enemy = victim.GetComponent<EnemyBase>();
        if (enemy != null)
        {
            enemy.Damage();
        }
    }

    private void Attack()
    {
        isAttacking = true;
        
        // 플레이어 한테 공격 전용 Collider
        // a 키를 누르고 있으면
        if (Input.GetKeyDown(KeyCode.A))
        {
            // 가장 가까운 적 자동으로 공격
            
        }
        
        Debug.Log("공격");
        // 돌리기
    }
}
