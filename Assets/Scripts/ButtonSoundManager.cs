using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip buttonSound;
    
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => SoundManager.PlaySound(buttonSound, transform.position));
    }
}
