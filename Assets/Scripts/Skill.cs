using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Skill : MonoBehaviour
{
    [SerializeField]
    private string skillName; // 해당 스킬 이름
    [SerializeField] 
    private float maxCooldownTime; // 해당 스킬 재사용 대기시간
    [SerializeField]
    private TextMeshProUGUI textSkillData; // 스킬 시전 정보
    [SerializeField]
    private TextMeshProUGUI textCooldownTime; // 재사용 대기 시간을 텍스트로 출력 
    [SerializeField]
    private Image imageCooldownTime; // 재사용 대기시간을 이미지로 출력
    
    private float currentCooldownTime; // 현재 재사용 대기 시간
    private bool isCooldown; // 현재 쿨타임이 적용 중인지 확인하는 변수
    private bool initialized;

    private void Awake()
    {
        setCooldownIs(false);
    }

    private void Start()
    {
        initialized = true;
    }

    private void Update()
    {
        if (!initialized)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            UseSkill();
        }
    }

    public void UseSkill()
    {
        if (isCooldown == true)
        {
            textSkillData.text = $"[{skillName}] Cooldown Time : {currentCooldownTime:F1}";
            return;
        }

        textSkillData.text = $"Use Skill : {skillName}";
        
        StartCoroutine(nameof(OnCoolDownTime),maxCooldownTime);
    }

    private IEnumerator OnCoolDownTime(float maxCooldownTime)
    {
        currentCooldownTime = maxCooldownTime;
        
        setCooldownIs(true);

        while (currentCooldownTime > 0)
        {
            currentCooldownTime -= Time.deltaTime;
            // Image UI의 fillAmount를 조절해 채워지는 이미지 모양 설정
            imageCooldownTime.fillAmount = currentCooldownTime / maxCooldownTime;
            // Text UI에 쿨다운 시간 표시
            textCooldownTime.text = currentCooldownTime.ToString("F1");
            
            yield return null;
        }

        setCooldownIs(false);
    }
    
    private void setCooldownIs(bool boolean)
    {
        isCooldown                = boolean;
        textCooldownTime.enabled  = boolean;
        imageCooldownTime.enabled = boolean;
    }
}
