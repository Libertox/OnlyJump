using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OnlyJump.UI
{
    public class SettingsWindow : MenuWindow
    {
        [SerializeField] private Slider sfxVolume;
        [SerializeField] private Slider bgmVolume;

        public override void Start()
        {
            base.Start();
            bgmVolume.value = AudioManager.Instance.GetBgmVolume();
            sfxVolume.value = AudioManager.Instance.GetSfxVolume();

            sfxVolume.onValueChanged.AddListener((float value) => AudioManager.Instance.ChangeSfxVolume(value));
            bgmVolume.onValueChanged.AddListener((float value) => AudioManager.Instance.ChangeBgmVolume(value));
        }

        public void RestartGame()
        {
            GameManager.Instance.RestartStatistic();
            LoaderScene.LoadTheSameScene();
        }

    }
}
