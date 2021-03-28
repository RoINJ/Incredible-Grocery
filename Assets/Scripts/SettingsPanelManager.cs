using GameControllerScripts;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanelManager : MonoBehaviour
{
    [SerializeField] private Button soundButton;
    [SerializeField] private Button musicButton;
    
    [SerializeField] private Sprite buttonOn;
    [SerializeField] private Sprite buttonOff;
    
    private bool _isMusicEnabled;
    private bool IsMusicEnabled
    {
        get => _isMusicEnabled;
        set
        {
            _isMusicEnabled = value;
            SetButtonState(musicButton, value);
            SoundManager.Instanse.IsMusicEnabled = _isMusicEnabled;
        }
    }

    private bool _isSoundsEnabled;
    private bool IsSoundsEnabled
    {
        get => _isSoundsEnabled;
        set
        {
            _isSoundsEnabled = value;
            SetButtonState(soundButton, value);
            SoundManager.Instanse.IsSoundsEnabled = _isSoundsEnabled;
        }
    }

    public void Save()
    {
        gameObject.SetActive(false);
    }

    public void ToggleSound()
    {
        IsSoundsEnabled = !IsSoundsEnabled;
    }
    
    public void ToggleMusic()
    {
        IsMusicEnabled = !IsMusicEnabled;
    }

    private void OnEnable()
    {
        Time.timeScale = 0;

        IsMusicEnabled = SoundManager.Instanse.IsMusicEnabled;
        IsSoundsEnabled = SoundManager.Instanse.IsSoundsEnabled;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    private void SetButtonState(Button button, bool state)
    {
        button.image.sprite = state
            ? buttonOn
            : buttonOff;

        button.GetComponentInChildren<Text>().text = state
            ? "ON"
            : "OFF";
    }
}
