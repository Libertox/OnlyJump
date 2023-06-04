using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private List<Quest> quests;
    private GameManager gameManager;

    private void Awake() => gameManager = GetComponent<GameManager>();
    
    public void CheckQuestStatus()
    {
        foreach (Quest quest in quests)
        {
            switch(quest.questType)
            {
                case QuestType.Jump:
                    CheckQuestRequest(quest, gameManager.TotalJumps);
                    break;
                case QuestType.Attempt:
                    CheckQuestRequest(quest, gameManager.TotalAttempt);
                    break;
                case QuestType.LevelComplete:
                    CheckQuestRequest(quest, gameManager.QuantityOfCompleteLevel);
                    break;
                case QuestType.GainCoins:
                    CheckQuestRequest(quest, gameManager.TotalGainCoins);
                    break;
                case QuestType.RecordMode:
                    CheckQuestRequest(quest, gameManager.TheBestRecord);
                    break;
                default:
                    break;
            }
        }        
    }

    private void CheckQuestRequest(Quest quest, int currentValue)
    {
        if (quest.questRequest <= currentValue)
        {
            if (PlayerPrefs.GetInt(quest.questName) == 0)
                gameManager.UpdateAmountOfCoins(quest.questAward);

            PlayerPrefs.SetInt(quest.questName, 1);
        }
        else
            PlayerPrefs.SetInt(quest.questName, 0);

        PlayerPrefs.Save();
    }

   
    public void RestartQuestProgress()
    {
        foreach (Quest quest in quests)
            PlayerPrefs.SetInt(quest.questName, 0);
    }

    public List<Quest> GetQuestsList() => quests;
}   
