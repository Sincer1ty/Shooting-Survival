using UnityEngine;

[CreateAssetMenu(fileName = "CharactorStat", menuName = "Scriptable Objects/CharactorStatSO")]
public class CharactorStatSo : ScriptableObject
{
    public string characterId;
    public int strength;
    public int intelligence;
    public int hp;
    public int mp;
    
    // 각 캐릭터의 초기값을 저장할 변수들
    [Header("Initial Values")]
    public int initialStrength;
    public int initialIntelligence;
    public int initialHp;
    public int initialMp;
    
    public void ResetToDefault()
    {
        strength = initialStrength;
        intelligence = initialIntelligence;
        hp = initialHp;
        mp = initialMp; 
    }
}
