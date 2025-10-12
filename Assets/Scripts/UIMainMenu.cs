using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    public GameObject startUIObj;
    public GameObject mainUIObj;
    public GameObject optionUIObj;
    public GameObject inGameUIObj;
    public GameObject statusUIObj; // 통합 스탯 UI
    public CharacterStatus statusUI; // statsUI에 붙은 스크립트

    // 캐릭터 데이터
    public CharactorStatSo knightSo;
    public CharactorStatSo mageSo;
    public CharactorStatSo archorSo;

    private GameObject[] allPanels;

    private void Start()
    {
        allPanels = new GameObject[] { startUIObj, mainUIObj, statusUIObj, inGameUIObj };
        ShowStartUI();
    }

    private void ShowOnly(GameObject targetPanel)
    {
        foreach (var panel in allPanels)
        {
            panel.SetActive(panel == targetPanel);
        }
    }

    public void ShowStartUI()
    {
        ShowOnly(startUIObj);
    }

    public void ShowMainUI()
    {
        ShowOnly(mainUIObj);
    }

    public void ShowStatsUI(string characterId)
    {
        switch (characterId)
        {
            case "Knight":
                statusUI.SetCharacter(knightSo);
                break;
            case "Mage":
                statusUI.SetCharacter(mageSo);
                break;
            case "Archor":
                statusUI.SetCharacter(archorSo);
                break;
            default:
                Debug.LogWarning("Unknown character id: " + characterId);
                break;
        }
        ShowOnly(statusUIObj);
    }
    
    public void ShowInGameUI()
    {
        ShowOnly(inGameUIObj);
    }

    public void ShowOptionUI()
    {
        optionUIObj.SetActive(true);
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