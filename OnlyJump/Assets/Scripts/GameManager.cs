using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OnlyJump.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event EventHandler OnStatsUpdated;
    public event EventHandler OnCompleteLevel;

    public int TotalAttempt { get; set; }
    public int TheBestRecord { get; set; }
    public int TotalGainCoins { get; set; }
    public int TotalJumps { get; set; }
    public int QuantityOfCompleteLevel { get; set; }
    public int Pocket { get; set; }
    public int CurrentAttempt { get; private set; } = 1;
    public int[] QuantityOfGettingCoins { get; set; }
    public float[] LevelProgress { get; set; }
    public Color PlayerColor { get; set; }
    public bool IsPlayCampaign { get; private set; }
    public QuestManager QuestManager { get; private set; }
    public SaveGameData SaveGameData { get; private set; }

    [SerializeField] private List<Color> availableSkins;
    [SerializeField] private int numberOfAllLevels;
    private int currentlyPlayLevel;
    
    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        LevelProgress = new float[numberOfAllLevels];
        QuantityOfGettingCoins = new int[numberOfAllLevels];
        QuestManager = GetComponent<QuestManager>();
        SaveGameData = GetComponent<SaveGameData>();
    }

    private void Start() 
    { 
        SaveGameData.LoadData();
        PlayerController.OnJumped += PlayerController_OnJumped;
    }

    private void PlayerController_OnJumped(object sender, EventArgs e) => TotalJumps++;

    public void PlayCampaign(int level)
    {
        CurrentAttempt = 1;
        IsPlayCampaign = true;
        currentlyPlayLevel = level;
    }
    public void PlayRecordMode() => IsPlayCampaign = false;
  
    public int GetNumberOfLevels() => numberOfAllLevels;

    public List<Color> GetAvailableSkinsList() => availableSkins;

    public void UpdateAmountOfCoins(int coinsToAdd)
    {
        Pocket += coinsToAdd;
        TotalGainCoins += coinsToAdd;
    }
    public void UpdateStatistic()
    {
        if (IsPlayCampaign)
        {   
            TotalAttempt++;
            CurrentAttempt++;
        }
        OnStatsUpdated?.Invoke(this, EventArgs.Empty);
    }
    public void CompleteLevel()
    {
        Time.timeScale = 0.0f;
        if (currentlyPlayLevel >= QuantityOfCompleteLevel) 
            QuantityOfCompleteLevel++;

        LevelProgress[currentlyPlayLevel] = 1;
 
        OnCompleteLevel?.Invoke(this, EventArgs.Empty);      
    }
    public void CheckLevelResult(int result)
    {
        if (result > QuantityOfGettingCoins[currentlyPlayLevel]) 
            QuantityOfGettingCoins[currentlyPlayLevel] = result;
    }
    public void CheckTheBestRecord(int currentRecord)
    {
        if (currentRecord > TheBestRecord) 
            TheBestRecord = currentRecord;
    }
    public void CheckLevelProgress(float progress)
    {
        if (LevelProgress[currentlyPlayLevel] < progress) 
            LevelProgress[currentlyPlayLevel] = (progress > 1) ? 1 : progress;
    }

    public void RestartStatistic()
    {  
        QuestManager.RestartQuestProgress();
        PlayerPrefs.DeleteAll();
        SaveGameData.LoadData();

        PlayerColor = Color.white;
        availableSkins.Clear();
        availableSkins.Add(Color.white);
    }
  
    public void BuySkin(ColorSelectionButton buySkin)
    {
        availableSkins.Add(buySkin.GetSkinColor());
        Pocket -= buySkin.GetSkinCost();
        PlayerColor = buySkin.GetSkinColor();
    }
}


