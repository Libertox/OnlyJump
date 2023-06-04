using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnlyJump.UI
{
    public class CampaignWindow : MonoBehaviour
    {
        [SerializeField] private GameObject menuWindow;
        [SerializeField] private GameObject levelWindowButtons;
        [SerializeField] private FadeImage fadeImage;

        [SerializeField] private LevelChooseMenu[] levels;
        [SerializeField] private float buttonDelay;
        [SerializeField] private float closeWindowDelay;

        private int numberOfLevels;
        private int chooseLevel;
        private bool buttonIsPress;

        private void Start()
        {
            numberOfLevels = levels.Length - 1;
            if (GameManager.Instance.IsPlayCampaign)
                OpenWindow();
     
            fadeImage.FadeFromBlack();
        }

        public void OpenWindow()
        {
            AudioManager.Instance.PlayButtonSound();
            menuWindow.SetActive(false);
            levelWindowButtons.SetActive(true);
            chooseLevel = 0;
            levels[chooseLevel].LevelAnimation.RightOpenAnimation();
        }

        public void CloseWindow()
        {
            AudioManager.Instance.PlayButtonSound();
            levels[chooseLevel].LevelAnimation.RightCloseAnimation();
            levelWindowButtons.SetActive(false);
            fadeImage.FadeToBlack();
            StartCoroutine(CloseWindowDelay(closeWindowDelay));

        }

        public void NextLevel()
        {
            if (!buttonIsPress)
            {
                buttonIsPress = true;
                chooseLevel++;
                if (chooseLevel >= levels.Length)
                {
                    levels[0].LevelAnimation.SwapPlaceOnRightAnimation();
                    levels[numberOfLevels].LevelAnimation.LeftCloseAnimation();
                    levels[0].LevelAnimation.RightOpenAnimation();
                    chooseLevel = 0;
                }
                else
                {
                    levels[chooseLevel].LevelAnimation.SwapPlaceOnRightAnimation();
                    levels[chooseLevel - 1].LevelAnimation.LeftCloseAnimation();
                    levels[chooseLevel].LevelAnimation.RightOpenAnimation();
                }

                StartCoroutine(PressButtonDelay(buttonDelay));
            }

        }

        public void PreviousLevel()
        {
            if (!buttonIsPress)
            {
                buttonIsPress = true;

                chooseLevel--;
                if (chooseLevel < 0)
                {
                    levels[numberOfLevels].LevelAnimation.SwapPlaceOnLeftAnimation();
                    levels[0].LevelAnimation.RightCloseAnimation();
                    levels[numberOfLevels].LevelAnimation.LeftOpenAnimation();
                    chooseLevel = numberOfLevels;
                }
                else
                {
                    levels[chooseLevel].LevelAnimation.SwapPlaceOnLeftAnimation();
                    levels[chooseLevel + 1].LevelAnimation.RightCloseAnimation();
                    levels[chooseLevel].LevelAnimation.LeftOpenAnimation();

                }
                StartCoroutine(PressButtonDelay(buttonDelay));
            }
        }

        private IEnumerator PressButtonDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            buttonIsPress = false;
        }

        private IEnumerator CloseWindowDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            menuWindow.SetActive(true);
            fadeImage.FadeFromBlack();
        }
    }
}
