using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnlyJump.UI
{
    public class MainMenu : MonoBehaviour
    {
        private bool menuButtonisPressed;
        public void OpenMenuWindow(MenuWindow window)
        {
            if (!menuButtonisPressed)
            {
                AudioManager.Instance.PlayButtonSound();
                window.OpenWindow();
                window.AppearWindow();
                menuButtonisPressed = true;
            }
        }
        public void CloseMenuWindow(MenuWindow window)
        {
            AudioManager.Instance.PlayButtonSound();
            window.CloseWindow();
            window.UnAppearWindow();
            menuButtonisPressed = false;
        }

        public void PlayRecordMode()
        {
            AudioManager.Instance.PlayButtonSound();
            GameManager.Instance.PlayRecordMode();
            LoaderScene.LoadScene(Scence.RecordMode);
        }

        public void CloseGame()
        {
            GameManager.Instance.SaveGameData.SaveData();
          #if !UNITY_WEBGL
            Application.Quit();
          #endif
        }
    }
}
