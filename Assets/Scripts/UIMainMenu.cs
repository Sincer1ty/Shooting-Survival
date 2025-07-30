using System;
using UnityEngine;
using UnityEngine.UIElements;

public class UIMainMenu : MonoBehaviour
{
    public GameObject startUI;
    public GameObject mainUI;
    public GameObject optionUI;

    private GameObject[] allPanels;

    private void Start()
    {
        allPanels = new GameObject[] { startUI, mainUI };
        ShowStartUI(); // 시작 시 Start UI만 보이게
    }

    private void ShowOnly(GameObject targetPanel)
    {
        for (int i = 0; i < allPanels.Length; i++)
        {
            GameObject panel = allPanels[i];
            panel.SetActive(panel == targetPanel); // 다를 때는 false를 반환
        }
    }

    public void ShowStartUI()
    {
        ShowOnly(startUI);
    }

    public void ShowMainUI()
    {
        ShowOnly(mainUI);
    }

    public void ShowOptionUI()
    {
        optionUI.SetActive(true);
    }

    public void OnExitButtonClick()
    {
        Debug.Log("Exit button clicked!");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

// OptionUI전용 스크립트 만들고 hideoptionui는 전용스크립트로 보내고

