using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Quest", menuName = "CreateQuest")]
public class Quest : ScriptableObject
{
    public QuestType questType;
    public string questName;
    public int questAward;
    public int questRequest;
}
public enum QuestType
{
    Jump,
    Attempt,
    LevelComplete,
    GainCoins,
    RecordMode,
}