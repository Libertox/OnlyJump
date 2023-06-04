using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace OnlyJump.UI
{
    public class AchievementsWindow : MenuWindow
    {
        [SerializeField] private Sprite completeQuestSprite;
        [SerializeField] private AchievementSingle achievementTemplate;
        [SerializeField] private Transform parentTransform;

        public override void Start()
        {
            base.Start();
            GameManager.Instance.QuestManager.CheckQuestStatus();
            UpdateAchievementData();

        }

        private void UpdateAchievementData()
        {
            foreach (Quest quest in GameManager.Instance.QuestManager.GetQuestsList())
            {
                AchievementSingle achievement = Instantiate(achievementTemplate, parentTransform);
                achievement.gameObject.SetActive(true);
                achievement.SetContext(quest.questName);
                achievement.SetAward(quest.questAward.ToString());
                if (PlayerPrefs.GetInt(quest.questName) == 1)
                    achievement.SetStatus(completeQuestSprite);
            }
        }

    }
}
