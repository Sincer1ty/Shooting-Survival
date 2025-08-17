using UnityEngine;

[CreateAssetMenu(fileName = "CharactorStat", menuName = "Scriptable Objects/CharactorStatSO")]
public class CharactorStatSo : ScriptableObject
{
    public string characterId;
    public int strength = 5;
    public int intelligence = 5;
    public int hp = 100;
    public int mp= 50;
    
    public void ResetToDefault()
    {
        strength = 5;
        intelligence = 5;
        hp = 100;
        mp = 100; 
    }
}
