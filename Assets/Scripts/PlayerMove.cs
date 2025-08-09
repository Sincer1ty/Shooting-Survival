using System.Collections.Generic;
using Skills;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Camera _mainCamera;
    private Vector3 _destination;
    private bool _isMove;
    [SerializeField] private float speed = 7f;
    
    private Dictionary<KeyCode, ISkill> _skills;

    private Animator _animator;
    private static readonly int IsAttackingHash = Animator.StringToHash("isAttacking");

    [SerializeField] private int maxColliders = 20;
    private Collider[] _hitBuffer;
    
    private void Awake()
    {
        _mainCamera = Camera.main;
        _animator = GetComponent<Animator>();
        
        _hitBuffer = new Collider[maxColliders];
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
                SetDestination(hit.point);
            }
        }
        // 좌클릭 : 공격
        else if (Input.GetMouseButtonDown(0))
        {
            // 공격 함수
            Attack();
        }
        Move();
        
        // 스킬
        foreach (var skillPair in _skills)
        {
            if (Input.GetKeyDown(skillPair.Key))
            {
                skillPair.Value.Use();
            }
        }
    }

    private void Move()
    {
        if (!_isMove) return;
        
        if (Vector3.Distance(transform.position, _destination) <= 0.1f) {
            _isMove = false; 
            return;
        }
        var dir = _destination - transform.position;
        transform.position += dir.normalized * (Time.deltaTime * speed);
    }

    private void SetDestination(Vector3 dest)
    {
        _destination = dest;
        _isMove = true;
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
    
    // 근거리시 : OverlapSphere 호출
    // private void OnTriggerEnter(Collider other)
    // { 
    //     if (!_animator.GetBool(IsAttackingHash)) return; // 공격 중이 아니면 무시
    //     
    //     var victim = other.gameObject;
    //     var enemy = victim.GetComponent<EnemyBase>();
    //     if (enemy != null)
    //     {
    //         enemy.Damage();
    //     }
    // }

    private void Attack()
    {
        _animator.SetBool(IsAttackingHash, true);
        
        // int hitCount = Physics.OverlapSphere(
        //     transform.position + transform.forward, 
        //     attackRadius, 
        //     _hitBuffer,
        //     LayerMask.GetMask("Enemy") // 레이어 마스크 추가
        // );

        // Collider[] hits = Physics.OverlapSphere(transform.position + transform.forward, 1.5f); // 공격 범위
        // foreach (var hit in hits)
        // {
        //     var enemy = hit.GetComponent<EnemyBase>();
        //     if (enemy != null)
        //     {
        //         enemy.Damage();
        //     }
        // }
        
        // 플레이어 한테 공격 전용 Collider
        // a 키를 누르고 있으면
        if (Input.GetKeyDown(KeyCode.A))
        {
            // 가장 가까운 적 자동으로 공격
            
        }
        
        Debug.Log("공격");
    }
    
    #region Animation Events
    private void FinishAttack()
    {
        _animator.SetBool(IsAttackingHash, false);
    }
    #endregion
}
