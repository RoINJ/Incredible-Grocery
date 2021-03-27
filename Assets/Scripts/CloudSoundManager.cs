using UnityEngine;

public class CloudSoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip appearanceSound;
    [SerializeField] private AudioClip disappearanceSound;

    private void Start()
    {
        SoundManager.PlaySound(appearanceSound, transform.position);
    }
    
    private void OnDestroy()
    {
        SoundManager.PlaySound(disappearanceSound, transform.position);
    }
}
