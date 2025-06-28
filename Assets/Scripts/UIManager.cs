using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject startUI;
    public GameObject mainUI;

    public void ShowStartUI()
    {
        startUI.SetActive(true);
        mainUI.SetActive(false);
    }

    public void ShowMainUI()
    {
        mainUI.SetActive(true);
        startUI.SetActive(false);
    }
    
}
