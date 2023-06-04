using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameData : MonoBehaviour
{
    private const string PREFS_TOTAL_ATTEMPT = "TotalAttempt";
    private const string PREFS_TOTAL_JUMPS = "TotalJumps";
    private const string PREFS_TOTAL_GAIN_COINS = "TotalGainCoin";
    private const string PREFS_QUANTIY_COMPLETE_LEVEL = "QuantityOfCompleteLevel";
    private const string PREFS_PLAYER_SKIN = "PlayerSkin";
    private const string PREFS_AVAILABLE_SKINS = "AvailableSkins";
    private const string PREFS_NUMBER_OF_AVAILABLE_SKINS = "NumberOfAvailableSkins";
    private const string PREFS_POCEKT = "Pocket";
    private const string PREFS_LEVEL_PROGRESS = "LevelProgress";
    private const string PREFS_QUANTITY_OF_GETTING_COINS = "QuantityOfGettingCoins";
    private const string PREFS_BEST_RECORD = "BestRecord";

    private GameManager gameManager;

    private void Awake() => gameManager = GetComponent<GameManager>();
   
    public void SaveData()
    {
        PlayerPrefs.SetInt(PREFS_TOTAL_ATTEMPT, gameManager.TotalAttempt);
        PlayerPrefs.SetInt(PREFS_TOTAL_JUMPS, gameManager.TotalJumps);
        PlayerPrefs.SetInt(PREFS_TOTAL_GAIN_COINS, gameManager.TotalGainCoins);
        PlayerPrefs.SetInt(PREFS_QUANTIY_COMPLETE_LEVEL, gameManager.QuantityOfCompleteLevel);

        PlayerPrefs.SetString(PREFS_PLAYER_SKIN, ColorUtility.ToHtmlStringRGB(gameManager.PlayerColor));

        for (int i = 1; i < gameManager.GetAvailableSkinsList().Count; i++)
        {
            PlayerPrefs.SetString(PREFS_AVAILABLE_SKINS + i, ColorUtility.ToHtmlStringRGBA(gameManager.GetAvailableSkinsList()[i]));
        }
        PlayerPrefs.SetInt(PREFS_NUMBER_OF_AVAILABLE_SKINS, gameManager.GetAvailableSkinsList().Count);

        PlayerPrefs.SetInt(PREFS_POCEKT, gameManager.Pocket);

        for (int i = 0; i < gameManager.GetNumberOfLevels(); i++)
        {
            PlayerPrefs.SetFloat(PREFS_LEVEL_PROGRESS + i, gameManager.LevelProgress[i]);
            PlayerPrefs.SetInt(PREFS_QUANTITY_OF_GETTING_COINS + i, gameManager.QuantityOfGettingCoins[i]);
        }
        PlayerPrefs.SetInt(PREFS_BEST_RECORD, gameManager.TheBestRecord);

        PlayerPrefs.Save();
    }
    public void LoadData()
    {
        gameManager.TotalAttempt = PlayerPrefs.GetInt(PREFS_TOTAL_ATTEMPT);
        gameManager.TotalJumps = PlayerPrefs.GetInt(PREFS_TOTAL_JUMPS);
        gameManager.TotalGainCoins = PlayerPrefs.GetInt(PREFS_TOTAL_GAIN_COINS);
        gameManager.QuantityOfCompleteLevel = PlayerPrefs.GetInt(PREFS_QUANTIY_COMPLETE_LEVEL);

        ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString(PREFS_PLAYER_SKIN), out Color tempColor);
        gameManager.PlayerColor = tempColor;

        for (int i = 1; i < PlayerPrefs.GetInt(PREFS_NUMBER_OF_AVAILABLE_SKINS); i++)
        {
            ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString(PREFS_AVAILABLE_SKINS + i), out Color temp);
            gameManager.GetAvailableSkinsList().Add(temp);
        }

        gameManager.Pocket = PlayerPrefs.GetInt(PREFS_POCEKT);

        for (int i = 0; i < gameManager.GetNumberOfLevels(); i++)
        {
            gameManager.LevelProgress[i] = PlayerPrefs.GetFloat(PREFS_LEVEL_PROGRESS + i);
            gameManager.QuantityOfGettingCoins[i] = PlayerPrefs.GetInt(PREFS_QUANTITY_OF_GETTING_COINS + i);

        }

        gameManager.TheBestRecord = PlayerPrefs.GetInt(PREFS_BEST_RECORD);
    }
}
