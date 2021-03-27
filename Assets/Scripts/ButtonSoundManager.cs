using GameControllerScripts;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip buttonSound;
    
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => SoundManager.Instanse.PlaySound(buttonSound, transform.position));
    }
}
