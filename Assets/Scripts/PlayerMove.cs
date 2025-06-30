using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Camera _mainCamera;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _mainCamera = Camera.main;
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("스킬 Q");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("스킬 W");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("스킬 E");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("스킬 R");
        }
    }
}
