using System.Collections.Generic;
using Skills;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Camera _mainCamera;
    
    private Dictionary<KeyCode, ISkill> _skills;

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
            Debug.Log("공격");
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
}
