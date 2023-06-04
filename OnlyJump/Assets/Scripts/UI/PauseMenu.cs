using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace OnlyJump.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private Slider sfxVolume;
        [SerializeField] private Slider bgmVolume;
        [SerializeField] private FadeImage fadeImage;
        private void Start()
        {
            bgmVolume.value = AudioManager.Instance.GetBgmVolume();
            sfxVolume.value = AudioManager.Instance.GetSfxVolume();

            sfxVolume.onValueChanged.AddListener((float value) => AudioManager.Instance.ChangeSfxVolume(value));
            bgmVolume.onValueChanged.AddListener((float value) => AudioManager.Instance.ChangeBgmVolume(value));

            fadeImage.FadeFromBlack();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (LevelManager.Instance.IsPlayState())
                    OpenPauseMenu();
                else if (LevelManager.Instance.IsPauseState())
                    ClosePauseMenu();
            }
        }

        public void OpenPauseMenu()
        {
            Time.timeScale = 0.0f;
            AudioManager.Instance.PlayButtonSound();
            pauseMenu.SetActive(true);
            LevelManager.Instance.SetGameState(GameState.Pause);
            AudioManager.Instance.PauseMusic();
        }

        public void ClosePauseMenu()
        {
            Time.timeScale = 1.0f;
            AudioManager.Instance.PlayButtonSound();
            pauseMenu.SetActive(false);
            LevelManager.Instance.SetGameState(GameState.Play);
            AudioManager.Instance.UnpauseMusic();
        }

        public void BackToMainMenu()
        {
            fadeImage.FadeToBlack();
            LoaderScene.LoadScene(Scence.MainMenu);
            GameManager.Instance.UpdateStatistic();
            GameManager.Instance.SaveGameData.SaveData();
            Time.timeScale = 1f;
        }
    }
}
