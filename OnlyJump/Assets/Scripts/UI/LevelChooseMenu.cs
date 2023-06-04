using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace OnlyJump.UI
{
    public class LevelChooseMenu : MonoBehaviour
    {
        public LevelChooseAnimation LevelAnimation { get; private set; }
        [SerializeField] private TextMeshProUGUI levelProgress;
        [SerializeField] private Image[] gettingCoins;
        [SerializeField] private Slider progressStatus;
        [SerializeField] private GameObject paddlock;

        [SerializeField] private int level;
        [SerializeField] private Scence nameOfLevelToLoad;
        private bool levelUnlocked;

        private void Start()
        {
            LevelAnimation = GetComponent<LevelChooseAnimation>();
            UpdateStats();
            CheckLevelLocked();

        }
        private void UpdateStats()
        {
            levelProgress.SetText($"{(int)(GameManager.Instance.LevelProgress[level]*100)}%");
            progressStatus.value = GameManager.Instance.LevelProgress[level];

            for (int i = 0; i < GameManager.Instance.QuantityOfGettingCoins[level]; i++)
                gettingCoins[i].color = new Color(gettingCoins[i].color.r, gettingCoins[i].color.g, gettingCoins[i].color.b, 255);
        }

        private void CheckLevelLocked()
        {
            if (level <= GameManager.Instance.QuantityOfCompleteLevel)
            {
                paddlock.SetActive(false);
                levelUnlocked = true;
            }
            else
                paddlock.SetActive(true);
        }

        public void LoadLevel()
        {
            if (levelUnlocked)
            {
                GameManager.Instance.PlayCampaign(level);
                LoaderScene.LoadScene(nameOfLevelToLoad);
            }
        }
    }
}
