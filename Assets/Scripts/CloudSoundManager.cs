using UnityEngine;

public class CloudSoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip appearanceSound;
    [SerializeField] private AudioClip disappearanceSound;

    private void Start()
    {
        AudioSource.PlayClipAtPoint(appearanceSound, transform.position);
    }
    
    private void OnDestroy()
    {
        AudioSource.PlayClipAtPoint(disappearanceSound, transform.position);
    }
}
