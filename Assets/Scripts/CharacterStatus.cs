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

    private void UpdateUI()
    {
        if  (currentStat == null) return;
        strengthText.text = currentStat.strength.ToString();
        // intelligenceText.text = currentStat.intelligence.ToString();
        // hpText.text = currentStat.hp.ToString();
        // mpText.text = currentStat.mp.ToString();
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
