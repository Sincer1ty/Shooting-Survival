using UnityEngine;

namespace Skills
{
    public class SkillR : ISkill
    {
        public string Name => "";
        public float Damage => 1f;
        
        public void Use()
        {
            Debug.Log("스킬 R");
            // 이펙트, 데미지, 쿨타임 등 처리
        }
    }
}