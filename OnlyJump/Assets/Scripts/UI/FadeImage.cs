using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OnlyJump.UI
{
    public class FadeImage : MonoBehaviour
    {
        [SerializeField] private Image fadeScreen;
        [SerializeField] private float speedFade;

        private bool shouldFadeToBlack;
        private bool shouldFadeFromBlack;

        private void Update()
        {
            if (shouldFadeToBlack)
            {
                fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, speedFade * Time.deltaTime));

                if (fadeScreen.color.a == 1f)
                {
                    shouldFadeToBlack = false;
                }
            }
            if (shouldFadeFromBlack)
            {
                fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, speedFade * Time.deltaTime));

                if (fadeScreen.color.a == 0f)
                {
                    shouldFadeFromBlack = false;
                    gameObject.SetActive(false);
                }
            }
        }
        public void FadeToBlack()
        {
            gameObject.SetActive(true);
            shouldFadeToBlack = true;
            shouldFadeFromBlack = false;
        }
        public void FadeFromBlack()
        {
            shouldFadeFromBlack = true;
            shouldFadeToBlack = false;
        }

    }
}
