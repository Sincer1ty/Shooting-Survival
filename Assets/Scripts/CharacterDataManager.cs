using UnityEngine;
using System.IO;
using System;


[Serializable]
public class CharacterSaveData
{
    public int strength;
    public int intelligence;
    public int hp;
    public int mp;
}

public static class CharacterDataManager
{
    public static string GetFilePath(string characterId) =>
        Path.Combine(Application.persistentDataPath, $"{characterId}_stats.json");

    public static void Save(CharactorStatSo stat)
    {
        var data = new CharacterSaveData
        {
            strength = stat.strength,
            intelligence = stat.intelligence,
            hp = stat.hp,
            mp = stat.mp
        };
        string json = JsonUtility.ToJson(data,true);
        File.WriteAllText(GetFilePath(stat.characterId), json);
    }
    
    public static void Load(CharactorStatSo stat)
    {
        string path = GetFilePath(stat.characterId);
        if (!File.Exists(path))
        {
            Save(stat);
            return;
        }
        string json = File.ReadAllText(path);
        var data = JsonUtility.FromJson<CharacterSaveData>(json);
        stat.strength = data.strength;
        stat.intelligence = data.intelligence;
        stat.hp = data.hp;
        stat.mp = data.mp;
    }
    
}
