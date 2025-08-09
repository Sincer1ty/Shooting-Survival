using UnityEngine;

[CreateAssetMenu(fileName = "CharactorStat", menuName = "Scriptable Objects/CharactorStatSO")]
public class CharactorStatSo : ScriptableObject
{
    public string characterId;
    public int strength = 5;
    public int intelligence = 5;
    public int hp = 100;
    public int mp= 50;
}
