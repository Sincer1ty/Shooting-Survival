using System;
using TMPro;
using UnityEngine;

public class ChracterStatus : MonoBehaviour
{

    public TextMeshProUGUI Text;
    
    public void IncreaseStrength()
    {
        int Defalt_str = PlayerPrefs.GetInt("Strength", 10);
        Defalt_str += 10;
        
        if (Defalt_str > 110)
            Defalt_str = 110;
        
        PlayerPrefs.SetInt("Strength", Defalt_str);
    }
    
    public void DecreaseStrength()
    {
        int Defalt_str = PlayerPrefs.GetInt("Strength", 10);
        Defalt_str -= 10;
        
        if (Defalt_str < 10)
            Defalt_str = 10;
        
        PlayerPrefs.SetInt("Strength", Defalt_str);

    }

    private void Update()
    {
        Text.text = PlayerPrefs.GetInt("Strength", 10).ToString();
    }
}
