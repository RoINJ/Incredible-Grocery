using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static void SetBackgroundMusic(bool value)
    {
        var audioSource = GameObject.FindWithTag("GameController")
            .GetComponent<AudioSource>();

        audioSource.mute = !value;
    }
    
    public static void PlaySound(AudioClip audioClip, Vector3 position)
    {
        if (SettingsManager.IsSoundsEnabled)
        {
            AudioSource.PlayClipAtPoint(audioClip, position);
        }
    }

    private void Start()
    {
        SetBackgroundMusic(SettingsManager.IsMusicEnabled);
    }
}
