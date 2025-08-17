using TMPro;
using UnityEngine;
using System.IO;

public class CharacterStatus : MonoBehaviour
{
    public CharactorStatSo currentStat;
    
    public TextMeshProUGUI strengthText;
    public TextMeshProUGUI intelligenceText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI mpText;
    
    public void SetCharacter(CharactorStatSo stat)
    {
        currentStat = stat;
        CharacterDataManager.Load(currentStat);
        UpdateUI();
    }

    public void IncreaseStrength()
    {
        if (currentStat == null) return;
        currentStat.strength = Mathf.Min(currentStat.strength + 1, 20);
        CharacterDataManager.Save(currentStat);
        UpdateUI();
    }
    
    public void DecreaseStrength()
    {
        if (currentStat == null) return;
        currentStat.strength = Mathf.Max(currentStat.strength - 1, 5);
        CharacterDataManager.Save(currentStat);
        UpdateUI();
    }

    public void IncreaseIntelligence()
    {
        if (currentStat == null) return;
        currentStat.intelligence = Mathf.Min(currentStat.intelligence + 1, 20);
        CharacterDataManager.Save(currentStat);
        UpdateUI();
    }

    public void DecreaseIntelligence()
    {
        if (currentStat == null) return;
        currentStat.intelligence = Mathf.Max(currentStat.intelligence - 1, 5);
        CharacterDataManager.Save(currentStat);
        UpdateUI();
    }

    public void IncreaseHp()
    {
        if (currentStat == null) return;
        currentStat.hp = Mathf.Min(currentStat.hp + 10, 200);
        CharacterDataManager.Save(currentStat);
        UpdateUI();
    }

    public void DecreaseHp()
    {
        if (currentStat == null) return;
        currentStat.hp = Mathf.Max(currentStat.hp - 10, 100);
        CharacterDataManager.Save(currentStat);
        UpdateUI();
    }

    public void IncreaseMp()
    {
        if (currentStat == null) return;
        currentStat.mp = Mathf.Min(currentStat.mp + 5, 150);
        CharacterDataManager.Save(currentStat);
        UpdateUI();
    }

    public void DecreaseMp()
    {
        if (currentStat == null) return;
        currentStat.mp = Mathf.Max(currentStat.mp - 5, 100);
        CharacterDataManager.Save(currentStat);
        UpdateUI();
    }

    private void UpdateUI()
    {
        if  (currentStat == null) return;
        strengthText.text = currentStat.strength.ToString();
        intelligenceText.text = currentStat.intelligence.ToString();
        hpText.text = currentStat.hp.ToString();
        mpText.text = currentStat.mp.ToString();
    }
    
    public void ResetStat()
    {
        if (currentStat == null) return;
        
        string path = CharacterDataManager.GetFilePath(currentStat.characterId);
        
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        currentStat.ResetToDefault();
        CharacterDataManager.Save(currentStat);
        UpdateUI();
    }
}
