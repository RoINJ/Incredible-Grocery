using GameControllerScripts;
using UnityEngine;

public class CloudSoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip appearanceSound;
    [SerializeField] private AudioClip disappearanceSound;

    private void Start()
    {
        SoundManager.Instanse.PlaySound(appearanceSound, transform.position);
    }
    
    private void OnDestroy()
    {
        SoundManager.Instanse.PlaySound(disappearanceSound, transform.position);
    }
}
