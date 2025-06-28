using UnityEngine;

namespace DefaultNamespace
{
    public class ButtonClickHandler : MonoBehaviour
    {
        public UIManager UImanager;

        public void OnStartButtonClick()
        {
            UImanager.ShowMainUI();
        }
    }
}