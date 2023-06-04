using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private const string PREFS_SFX_VOLUME = "SfxVolume";
    private const string PREFS_BGM_VOLUME = "BgmVolue";

    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private SfxAudioClips sfxAudioClips;

    [SerializeField] private AudioSource bgmSource;

    [SerializeField] private float sfxVolume;
    public static AudioManager Instance { get; private set; }


    private void Awake()
    {
        if(!Instance)
            Instance = this;

        if (PlayerPrefs.HasKey(PREFS_SFX_VOLUME))
            sfxVolume = PlayerPrefs.GetFloat(PREFS_SFX_VOLUME);

        if (PlayerPrefs.HasKey(PREFS_BGM_VOLUME))
            bgmSource.volume = PlayerPrefs.GetFloat(PREFS_BGM_VOLUME);
    }

    private void Start()
    {
        if (LevelManager.Instance)
            LevelManager.Instance.OnGameOver += LevelManager_OnGameOver;

        GameManager.Instance.OnCompleteLevel += GameManager_OnCompleteLevel;

        PlayerController.OnJumped += PlayerController_OnJumped;
        Coin.OnRaised += Coin_OnRaised;
         
    }

  
    private void OnDestroy()
    {
        GameManager.Instance.OnCompleteLevel -= GameManager_OnCompleteLevel;
        PlayerController.OnJumped -= PlayerController_OnJumped;
        Coin.OnRaised -= Coin_OnRaised;
    }
    private void Coin_OnRaised(object sender, System.EventArgs e)
    {
        sfxSource.PlayOneShot(sfxAudioClips.getCoin, sfxVolume);
    }

    private void PlayerController_OnJumped(object sender, System.EventArgs e)
    {
        sfxSource.PlayOneShot(sfxAudioClips.playerJump, sfxVolume);
    }

    private void GameManager_OnCompleteLevel(object sender, System.EventArgs e)
    {
        sfxSource.PlayOneShot(sfxAudioClips.victory, sfxVolume);
        PauseMusic();
    }

    private void LevelManager_OnGameOver(object sender, System.EventArgs e)
    {
        PlayPlayerDeadSound();
        StopMusic();
    }

    public void PlayPlayerDeadSound() => sfxSource.PlayOneShot(sfxAudioClips.playerDead, sfxVolume);
   
    public void PlayButtonSound() => sfxSource.PlayOneShot(sfxAudioClips.button, sfxVolume);
   
    public void PlayBuySound() => sfxSource.PlayOneShot(sfxAudioClips.buy, sfxVolume);
  
    public void StopMusic() => bgmSource.Stop();

    public void PauseMusic() => bgmSource.Pause();

    public void UnpauseMusic() => bgmSource.UnPause();
    
    public void ChangeSfxVolume(float volume)
    {
        sfxVolume = volume;
        PlayerPrefs.SetFloat(PREFS_SFX_VOLUME, sfxVolume);
        PlayerPrefs.Save();
    }
    public void ChangeBgmVolume(float volume)
    {
        bgmSource.volume = volume;
        PlayerPrefs.SetFloat(PREFS_BGM_VOLUME, bgmSource.volume);
        PlayerPrefs.Save();
    }

    public float GetSfxVolume() => sfxVolume;

    public float GetBgmVolume() => bgmSource.volume;
    
}
