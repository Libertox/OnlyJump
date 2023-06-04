using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OnlyJump.UI
{
    public class AchievementSingle : MonoBehaviour
    {
        [SerializeField] private Image status;
        [SerializeField] private TextMeshProUGUI context;
        [SerializeField] private TextMeshProUGUI award;

        public void SetContext(string name) => context.SetText(name);

        public void SetAward(string award) => this.award.SetText(award);

        public void SetStatus(Sprite sprite) => status.sprite = sprite;
    }
}
