using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillSystem : MonoBehaviour
{
    [SerializeField]
    private GraphicRaycaster graphicRaycaster;

    [SerializeField]
    private Skill[] skills;

    private List<RaycastResult> raycastResults;
    private PointerEventData pointerEventData;

    private void Awake()
    {
        raycastResults = new List<RaycastResult>();
        pointerEventData = new PointerEventData(null);
    }

    private void Update()
    {
        if (!Input.anyKeyDown) return;

        if (int.TryParse(Input.inputString, out int key) && (key >= 1 && key <= skills.Length))
        {
            skills[key-1].UseSkill();
        }

        if (Input.GetMouseButtonDown(0))
        {
            raycastResults.Clear();
            
            pointerEventData.position = Input.mousePosition;
            graphicRaycaster.Raycast(pointerEventData, raycastResults);

            if (raycastResults.Count > 0)
            {
                if (raycastResults[0].gameObject.TryGetComponent<Skill>(out var skill))
                {
                    skill.UseSkill();
                }    
            }
        }

    }
}
