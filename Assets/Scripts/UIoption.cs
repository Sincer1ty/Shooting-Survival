using UnityEngine;

public class UIoption : MonoBehaviour
{
    // 클래스와 인스턴스.
    // 
    public GameObject optionUI;
    //
    
    public void HideOptionUI()
    {
        optionUI.SetActive(false);
    }
}
