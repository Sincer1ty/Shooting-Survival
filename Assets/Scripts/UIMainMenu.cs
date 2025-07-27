using System;
using UnityEngine;
using UnityEngine.UIElements;

public class UIMainMenu : MonoBehaviour
{
    public GameObject startUI;
    public GameObject mainUI;
    public GameObject optionUI;

    private void Start()
    {
        startUI.SetActive(true);
    }

    // UI (Panel)
    // 반복문으로 돌린다 : 하나만 키고 다 false
    
    // POPUP : 스택
    
    public void ShowStartUI()
    {
        startUI.SetActive(true);
        mainUI.SetActive(false);
        optionUI.SetActive(false);
    }

    public void ShowMainUI()
    {
        mainUI.SetActive(true);
        startUI.SetActive(false);
        // optionUI.SetActive(false);
    }

    public void ShowOptionUI()
    {
        // mainUI.SetActive(false);
        // startUI.SetActive(true);
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
