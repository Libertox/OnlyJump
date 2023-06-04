using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SfxAudioClips", menuName = "AudioClips/SfxAudioClips")]
public class SfxAudioClips : ScriptableObject
{
    public AudioClip playerJump;
    public AudioClip playerDead;
    public AudioClip getCoin;
    public AudioClip victory;
    public AudioClip button;
    public AudioClip buy;
}